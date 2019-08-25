using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RotationHelper.UserOptions;

namespace RotationHelper
{
    public partial class frmMain : Form
    {      

        public frmMain()
        {
            InitializeComponent();
            UserOptions.LoadSettings();//Загружаем настройки программы            
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
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        //Обработка выбора элемента из ComboBox Start
        private void cmbStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserOptions.startRotation = cmbStart.SelectedIndex;
            UserOptions.SaveSettings();            
        }

        //Обработка выбора элемента из ComboBox Finish
        private void cmbFinish_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserOptions.stopRotation = cmbFinish.SelectedIndex;
            UserOptions.SaveSettings();
        }

        //Обработка выбора элемента из ComboBox Minimize Window
        private void cmbMinimizeWindow_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserOptions.minimizeWindow = cmbMinimizeWindow.SelectedIndex;
            UserOptions.SaveSettings();
        }
    }
}
