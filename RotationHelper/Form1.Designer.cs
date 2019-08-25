namespace RotationHelper
{
    partial class frmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblStart = new System.Windows.Forms.Label();
            this.lblStop = new System.Windows.Forms.Label();
            this.cmbStart = new System.Windows.Forms.ComboBox();
            this.cmbFinish = new System.Windows.Forms.ComboBox();
            this.lblMinimizeWindow = new System.Windows.Forms.Label();
            this.cmbMinimizeWindow = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(13, 16);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(36, 13);
            this.lblStart.TabIndex = 0;
            this.lblStart.Text = "Старт";
            // 
            // lblStop
            // 
            this.lblStop.AutoSize = true;
            this.lblStop.Location = new System.Drawing.Point(208, 16);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(31, 13);
            this.lblStop.TabIndex = 1;
            this.lblStop.Text = "Стоп";
            // 
            // cmbStart
            // 
            this.cmbStart.FormattingEnabled = true;
            this.cmbStart.Location = new System.Drawing.Point(56, 13);
            this.cmbStart.Name = "cmbStart";
            this.cmbStart.Size = new System.Drawing.Size(121, 21);
            this.cmbStart.TabIndex = 2;
            this.cmbStart.SelectedIndexChanged += new System.EventHandler(this.cmbStart_SelectedIndexChanged);
            // 
            // cmbFinish
            // 
            this.cmbFinish.FormattingEnabled = true;
            this.cmbFinish.Location = new System.Drawing.Point(251, 13);
            this.cmbFinish.Name = "cmbFinish";
            this.cmbFinish.Size = new System.Drawing.Size(121, 21);
            this.cmbFinish.TabIndex = 3;
            this.cmbFinish.SelectedIndexChanged += new System.EventHandler(this.cmbFinish_SelectedIndexChanged);
            // 
            // lblMinimizeWindow
            // 
            this.lblMinimizeWindow.AutoSize = true;
            this.lblMinimizeWindow.Location = new System.Drawing.Point(13, 49);
            this.lblMinimizeWindow.Name = "lblMinimizeWindow";
            this.lblMinimizeWindow.Size = new System.Drawing.Size(145, 13);
            this.lblMinimizeWindow.TabIndex = 4;
            this.lblMinimizeWindow.Text = "Свернуть/Развернуть окно";
            // 
            // cmbMinimizeWindow
            // 
            this.cmbMinimizeWindow.FormattingEnabled = true;
            this.cmbMinimizeWindow.Location = new System.Drawing.Point(174, 46);
            this.cmbMinimizeWindow.Name = "cmbMinimizeWindow";
            this.cmbMinimizeWindow.Size = new System.Drawing.Size(121, 21);
            this.cmbMinimizeWindow.TabIndex = 5;
            this.cmbMinimizeWindow.SelectedIndexChanged += new System.EventHandler(this.cmbMinimizeWindow_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 450);
            this.Controls.Add(this.cmbMinimizeWindow);
            this.Controls.Add(this.lblMinimizeWindow);
            this.Controls.Add(this.cmbFinish);
            this.Controls.Add(this.cmbStart);
            this.Controls.Add(this.lblStop);
            this.Controls.Add(this.lblStart);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Rotation Helper";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.ComboBox cmbStart;
        private System.Windows.Forms.ComboBox cmbFinish;
        private System.Windows.Forms.Label lblMinimizeWindow;
        private System.Windows.Forms.ComboBox cmbMinimizeWindow;
    }
}

