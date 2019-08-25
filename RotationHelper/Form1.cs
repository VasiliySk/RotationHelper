using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotationHelper
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            //Определение свойств окна
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - Convert.ToInt32(this.Height * 1.5));//Переносим окно в левый нижний угол
            this.TopMost = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
