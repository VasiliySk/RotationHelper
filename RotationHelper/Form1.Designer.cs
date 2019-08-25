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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblStart = new System.Windows.Forms.Label();
            this.lblStop = new System.Windows.Forms.Label();
            this.cmbStart = new System.Windows.Forms.ComboBox();
            this.cmbFinish = new System.Windows.Forms.ComboBox();
            this.lblMinimizeWindow = new System.Windows.Forms.Label();
            this.cmbMinimizeWindow = new System.Windows.Forms.ComboBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.dgvRotation = new System.Windows.Forms.DataGridView();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ckbHideWindow = new System.Windows.Forms.CheckBox();
            this.btnRotation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRotation)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(13, 27);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(36, 13);
            this.lblStart.TabIndex = 0;
            this.lblStart.Text = "Старт";
            // 
            // lblStop
            // 
            this.lblStop.AutoSize = true;
            this.lblStop.Location = new System.Drawing.Point(208, 27);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(31, 13);
            this.lblStop.TabIndex = 1;
            this.lblStop.Text = "Стоп";
            // 
            // cmbStart
            // 
            this.cmbStart.FormattingEnabled = true;
            this.cmbStart.Location = new System.Drawing.Point(56, 24);
            this.cmbStart.Name = "cmbStart";
            this.cmbStart.Size = new System.Drawing.Size(121, 21);
            this.cmbStart.TabIndex = 2;
            this.cmbStart.SelectedIndexChanged += new System.EventHandler(this.cmbStart_SelectedIndexChanged);
            // 
            // cmbFinish
            // 
            this.cmbFinish.FormattingEnabled = true;
            this.cmbFinish.Location = new System.Drawing.Point(251, 24);
            this.cmbFinish.Name = "cmbFinish";
            this.cmbFinish.Size = new System.Drawing.Size(121, 21);
            this.cmbFinish.TabIndex = 3;
            this.cmbFinish.SelectedIndexChanged += new System.EventHandler(this.cmbFinish_SelectedIndexChanged);
            // 
            // lblMinimizeWindow
            // 
            this.lblMinimizeWindow.AutoSize = true;
            this.lblMinimizeWindow.Location = new System.Drawing.Point(13, 60);
            this.lblMinimizeWindow.Name = "lblMinimizeWindow";
            this.lblMinimizeWindow.Size = new System.Drawing.Size(145, 13);
            this.lblMinimizeWindow.TabIndex = 4;
            this.lblMinimizeWindow.Text = "Свернуть/Развернуть окно";
            // 
            // cmbMinimizeWindow
            // 
            this.cmbMinimizeWindow.FormattingEnabled = true;
            this.cmbMinimizeWindow.Location = new System.Drawing.Point(174, 57);
            this.cmbMinimizeWindow.Name = "cmbMinimizeWindow";
            this.cmbMinimizeWindow.Size = new System.Drawing.Size(121, 21);
            this.cmbMinimizeWindow.TabIndex = 5;
            this.cmbMinimizeWindow.SelectedIndexChanged += new System.EventHandler(this.cmbMinimizeWindow_SelectedIndexChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // dgvRotation
            // 
            this.dgvRotation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRotation.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvRotation.Location = new System.Drawing.Point(16, 107);
            this.dgvRotation.Name = "dgvRotation";
            this.dgvRotation.Size = new System.Drawing.Size(356, 240);
            this.dgvRotation.TabIndex = 6;
            this.dgvRotation.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvRotation_RowPrePaint);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Location = new System.Drawing.Point(16, 370);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(113, 23);
            this.btnDeleteRow.TabIndex = 7;
            this.btnDeleteRow.Text = "Удалить строку";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(16, 412);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(113, 23);
            this.btnTest.TabIndex = 8;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(135, 370);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(113, 23);
            this.btnAddRow.TabIndex = 9;
            this.btnAddRow.Text = "Добавить строку";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(392, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ckbHideWindow
            // 
            this.ckbHideWindow.AutoSize = true;
            this.ckbHideWindow.Location = new System.Drawing.Point(16, 84);
            this.ckbHideWindow.Name = "ckbHideWindow";
            this.ckbHideWindow.Size = new System.Drawing.Size(245, 17);
            this.ckbHideWindow.TabIndex = 11;
            this.ckbHideWindow.Text = "Сворачивать окно при запуске программы";
            this.ckbHideWindow.UseVisualStyleBackColor = true;
            this.ckbHideWindow.CheckedChanged += new System.EventHandler(this.ckbHideWindow_CheckedChanged);
            // 
            // btnRotation
            // 
            this.btnRotation.Location = new System.Drawing.Point(259, 370);
            this.btnRotation.Name = "btnRotation";
            this.btnRotation.Size = new System.Drawing.Size(113, 23);
            this.btnRotation.TabIndex = 12;
            this.btnRotation.Text = "Старт ротации";
            this.btnRotation.UseVisualStyleBackColor = true;
            this.btnRotation.Click += new System.EventHandler(this.btnRotation_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 450);
            this.Controls.Add(this.btnRotation);
            this.Controls.Add(this.ckbHideWindow);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnDeleteRow);
            this.Controls.Add(this.dgvRotation);
            this.Controls.Add(this.cmbMinimizeWindow);
            this.Controls.Add(this.lblMinimizeWindow);
            this.Controls.Add(this.cmbFinish);
            this.Controls.Add(this.cmbStart);
            this.Controls.Add(this.lblStop);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Rotation Helper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRotation)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.DataGridView dgvRotation;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox ckbHideWindow;
        private System.Windows.Forms.Button btnRotation;
    }
}

