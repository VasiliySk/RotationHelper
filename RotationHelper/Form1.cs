using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RotationHelper.EsoWindow;
using static RotationHelper.UserOptions;

namespace RotationHelper
{
    public partial class frmMain : Form
    {
        public enum ActionEnum
        {
            Клик, Двойной_клик, Пауза
        }

        bool isInitStart, isInitFinish, isInitMinimize;
        private LowLevelKeyboardListener _listener; //  Слушаем нажатие клавиш
        EsoWindow esoWindow;
        IntPtr hWnd;
        public static bool stopAction;

        public frmMain()
        {            
            InitializeComponent();
            UserOptions.LoadSettings();//Загружаем настройки программы
            stopAction = false;
            esoWindow = new EsoWindow(); //Инициируем экземпляр класса
            isInitStart = true;
            isInitFinish = true;
            isInitMinimize = true;
            //Определение свойств окна
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - Convert.ToInt32(this.Height * 1.5));//Переносим окно в левый нижний угол
            this.TopMost = true;
            //Присоеденяем к комбобокс перечисления
            cmbStart.DataSource = Enum.GetValues(typeof(FunctionKeys));
            cmbFinish.DataSource = Enum.GetValues(typeof(FunctionKeys));
            cmbMinimizeWindow.DataSource = Enum.GetValues(typeof(FunctionKeys));
            // Загружаем настройки в объекты            
            cmbStart.SelectedIndex = UserOptions.startRotation;
            cmbFinish.SelectedIndex = UserOptions.stopRotation;
            cmbMinimizeWindow.SelectedIndex = UserOptions.minimizeWindow;
            ckbHideWindow.Checked = UserOptions.hideWindow;
            //Формируем столбцы таблицы
            DataGridViewComboBoxColumn actionColumn = new DataGridViewComboBoxColumn();
            actionColumn.Name = "Действие";
            actionColumn.DataSource = Enum.GetValues(typeof(ActionEnum));
            actionColumn.ValueType = typeof(ActionEnum);
            actionColumn.Width = 150;
            dgvRotation.Columns.Add(actionColumn);
            DataGridViewTextBoxColumn valueColumn = new DataGridViewTextBoxColumn();
            valueColumn.Name = "Значение";
            valueColumn.Width = 140;
            dgvRotation.Columns.Add(valueColumn);
            //Сворачиваем окно в трей, если установлена соответствующая опция
            if (ckbHideWindow.Checked)
            {
                Hide();
                WindowState = FormWindowState.Minimized;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _listener = new LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;
            _listener.HookKeyboard();
           
        }

        //Обработка нажатия функциональных клавиш
        void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            String ePress = Convert.ToString(e.KeyPressed);
            if (ePress.Equals(Convert.ToString((FunctionKeys)UserOptions.startRotation)))
            {
                btnRotation_Click(null, null);
                return;
            }
            if (ePress.Equals(Convert.ToString((FunctionKeys)UserOptions.stopRotation)))
            {
                stopAction = true;
                return;
            }
            if (ePress.Equals(Convert.ToString((FunctionKeys)UserOptions.minimizeWindow)))
            {                
                if (WindowState == FormWindowState.Normal) {
                    Hide();
                    WindowState = FormWindowState.Minimized;                    
                }else                
                {
                    Show();
                    WindowState = FormWindowState.Normal;                    
                } 
                return;
            }           
        }

        //Обработка выбора элемента из ComboBox Start
        private void cmbStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitStart)
            {
                isInitStart = false;
            }
            else
            {
                UserOptions.startRotation = cmbStart.SelectedIndex;
                UserOptions.SaveSettings();
            }
        }

        //Выгружаем хук клавиатуры
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _listener.UnHookKeyboard();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) Hide();
        }

        //Удаляем выбранную строку
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewCell oneCell in dgvRotation.SelectedCells)
                {

                    if (oneCell.Selected)
                        dgvRotation.Rows.RemoveAt(oneCell.RowIndex);
                }
            }
            catch (InvalidOperationException) //Обрабатываем ошибку, когда строка не инициализирована
            {

            }
        }
        //Тестовые функции
        private void btnTest_Click(object sender, EventArgs e)
        {
            Console.WriteLine(dgvRotation.RowCount);
        }
        //Добавляем строку
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dgvRotation.SelectedCells)
            {

                if (oneCell.Selected)
                    dgvRotation.Rows.Insert(oneCell.RowIndex, 1);
            }
        }
        //Автоматическая номерация строк
        private void dgvRotation_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dgvRotation.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dgvRotation.Rows[index].HeaderCell.Value = indexStr;
        }
        //Выход из программы
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Сохраняем выбор Скрывать окно или нет
        private void ckbHideWindow_CheckedChanged(object sender, EventArgs e)
        {
            UserOptions.hideWindow = ckbHideWindow.Checked;
            UserOptions.SaveSettings();
        }
        //Запускаем ротацию
        private void btnRotation_Click(object sender, EventArgs e)
        {
            //Запуск в отдельном потоке, что бы можно было слушать нажатие клавиш в основном потоке.
            Thread MyThread1 = new Thread(delegate ()
            {
                do
                {
                    hWnd = esoWindow.FindWindow(null, "Elder Scrolls Online"); //Определяем идентификатор процесса
                    esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_LBUTTONDOWN, new IntPtr(0), new IntPtr(0));
                    Thread.Sleep(64);
                    esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_LBUTTONUP, new IntPtr(0), new IntPtr(0));
                    Thread.Sleep(1000);
                } while (!stopAction);
                stopAction = false;
            });
            MyThread1.Start();
            MyThread1.Join();
            
        }

        //Обработка выбора элемента из ComboBox Finish
        private void cmbFinish_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitFinish)
            {
                isInitFinish = false;
            }
            else
            {
                UserOptions.stopRotation = cmbFinish.SelectedIndex;
                UserOptions.SaveSettings();
            }
        }

        //Обработка выбора элемента из ComboBox Minimize Window
        private void cmbMinimizeWindow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitMinimize)
            {
                isInitMinimize = false;
            }
            else {
                UserOptions.minimizeWindow = cmbMinimizeWindow.SelectedIndex;
                UserOptions.SaveSettings();
            }

        }
    }
}
