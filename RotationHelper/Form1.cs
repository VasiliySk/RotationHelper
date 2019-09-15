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
            Light_Attack, Heavy_Attack, Клавиша, Пауза
        }

        bool isInitStart, isInitFinish, isInitMinimize;
        private LowLevelKeyboardListener _listener; //  Слушаем нажатие клавиш
        EsoWindow esoWindow;
        RotationHelperFile rotationHelperFile;
        IntPtr hWnd;
        Random random;
        public static bool stopAction, stopMultiRotation;
        List<RHelper> rHelpers;

        public frmMain()
        {            
            InitializeComponent();
            UserOptions.LoadSettings();//Загружаем настройки программы
            stopAction = false;
            stopMultiRotation = false;
            esoWindow = new EsoWindow(); //Инициируем экземпляр класса
            rotationHelperFile = new RotationHelperFile();
            random = new Random();
            rHelpers = new List<RHelper>();
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
            actionColumn.Width = 85;
            dgvRotation.Columns.Add(actionColumn);
            DataGridViewTextBoxColumn valueColumn = new DataGridViewTextBoxColumn();
            valueColumn.Name = "Значение";
            valueColumn.Width = 70;
            dgvRotation.Columns.Add(valueColumn);
            DataGridViewTextBoxColumn timeColumn = new DataGridViewTextBoxColumn();
            timeColumn.Name = "Время";
            timeColumn.Width = 70;
            dgvRotation.Columns.Add(timeColumn);
            DataGridViewTextBoxColumn skipColumn = new DataGridViewTextBoxColumn();
            skipColumn.Name = "Пропуск";
            skipColumn.Width = 70;
            dgvRotation.Columns.Add(skipColumn);
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
                show_unshow_window();
                return;
            }           
        }

        //Скрываем/восстанавливаем окно
        private void show_unshow_window()
        {
            if (WindowState == FormWindowState.Normal)
            {
                Hide();
                WindowState = FormWindowState.Minimized;
            }
            else
            {
                Show();
                WindowState = FormWindowState.Normal;
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
            int rCount = dgvRotation.RowCount - 1;
            rHelpers.Clear();
            for (int i = 0; i < rCount; i++)
            {
                rHelpers.Add(new RHelper((ActionEnum)dgvRotation.Rows[i].Cells[0].Value, Convert.ToString(dgvRotation.Rows[i].Cells[1].Value), Convert.ToInt32(dgvRotation.Rows[i].Cells[2].Value), Convert.ToString(dgvRotation.Rows[i].Cells[3].Value)));
            }
            Console.WriteLine(rHelpers.Count);
        }       

        //Добавляем строку
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DataGridViewCell oneCell in dgvRotation.SelectedCells)
            {

                if (oneCell.Selected && i == 0)
                {
                    dgvRotation.Rows.Insert(oneCell.RowIndex, 1);
                    i++;
                }
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
            if (stopMultiRotation) return;
            if (ckbHideWindow.Checked)
            {
                if (WindowState == FormWindowState.Normal)
                {
                    Hide();
                    WindowState = FormWindowState.Minimized;
                }
            }
            //Запуск в отдельном потоке, что бы можно было слушать нажатие клавиш в основном потоке.
            Thread MyThread1 = new Thread(delegate ()
            {
                stopMultiRotation = true;
                hWnd = esoWindow.FindWindow(null, "Elder Scrolls Online"); //Определяем идентификатор процесса
                int rCount = dgvRotation.RowCount - 1;
                rHelpers.Clear();
                for (int i = 0; i < rCount; i++)
                {
                    rHelpers.Add(new RHelper((ActionEnum)dgvRotation.Rows[i].Cells[0].Value,
                                              Convert.ToString(dgvRotation.Rows[i].Cells[1].Value),
                                              Convert.ToInt32(dgvRotation.Rows[i].Cells[2].Value),
                                              Convert.ToString(dgvRotation.Rows[i].Cells[3].Value)));
                }
                do
                {
                    foreach (RHelper rHelper in rHelpers)
                    {
                        if (stopAction) break;
                        switch (rHelper.action)
                        {
                            case ActionEnum.Light_Attack:
                                LightAttack();
                                break;
                            case ActionEnum.Heavy_Attack:
                                Console.WriteLine("Тяжелая атака");
                                esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_LBUTTONDOWN, new IntPtr(0), new IntPtr(0));
                                Thread.Sleep(2500);
                                esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_LBUTTONUP, new IntPtr(0), new IntPtr(0));
                                Thread.Sleep(random.Next(400, 600));
                                break;
                            case ActionEnum.Клавиша:                                
                                ushort keys=9999;
                                switch (Convert.ToString(rHelper.value))
                                {
                                    case "1":
                                        keys = (ushort)Keys.D1;
                                        break;
                                    case "2":
                                        keys = (ushort)Keys.D2;
                                        break;
                                    case "3":
                                        keys = (ushort)Keys.D3;
                                        break;
                                    case "4":
                                        keys = (ushort)Keys.D4;
                                        break;
                                    case "5":
                                        keys = (ushort)Keys.D5;
                                        break;
                                    case "~":
                                        keys = 192;
                                        break;
                                    case "`":
                                        keys = 192;
                                        break;
                                    case "ё":
                                        keys = 192;
                                        break;
                                }
                                if (keys != 9999) {
                                    if (rHelper.keyAction)
                                    {
                                        Console.WriteLine("Клавиша");
                                        esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYDOWN, new IntPtr(keys), new IntPtr(0));
                                        Thread.Sleep(random.Next(70, 100));
                                        esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_KEYUP, new IntPtr(keys), new IntPtr(0));
                                        Thread.Sleep(random.Next(100, 200));
                                        if (rHelper.initCountDown > 0)
                                        {
                                            rHelper.Start();
                                            Console.WriteLine(rHelper.initCountDown);
                                        }
                                    }
                                    else
                                    {
                                        LightAttack();
                                    }
                                }
                                break;
                            case ActionEnum.Пауза:
                                Console.WriteLine("Пауза");
                                int p = Convert.ToInt32(rHelper.value);                               
                                Thread.Sleep(p);                                
                                break;
                        }                        
                    }
                } while (!stopAction);
                stopAction = false;
                stopMultiRotation = false;
            });
            MyThread1.Start();
            MyThread1.Join();            
        }

        private void LightAttack()
        {
            Console.WriteLine("Легкая атака");
            esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_LBUTTONDOWN, new IntPtr(0), new IntPtr(0));
            Thread.Sleep(random.Next(64, 100));
            esoWindow.SendMessage(hWnd, (uint)WindowMessages.WM_LBUTTONUP, new IntPtr(0), new IntPtr(0));
            Thread.Sleep(random.Next(200, 300));
        }
        //Создаем новый файл с ротацией
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rotationHelperFile.CreateFile(dgvRotation, saveToolStripMenuItem);
        }
        //Сохраняем файл с ротацией
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rotationHelperFile.SaveFile(dgvRotation);
        }
        //Открываем файл с ротацией
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rotationHelperFile.OpenFile(openFileDialog1,dgvRotation, saveToolStripMenuItem);
        }

        //Сохраняем как... файл с ротацией
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rotationHelperFile.SaveFileAs(saveFileDialog1, dgvRotation, saveToolStripMenuItem);
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
