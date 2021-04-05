
namespace WindowsFormsTransport
{
    partial class FormBerth
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBerth));
            this.pictureBoxBerth = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBoxPlace = new System.Windows.Forms.MaskedTextBox();
            this.listBoxBerths = new System.Windows.Forms.ListBox();
            this.addBerthButton = new System.Windows.Forms.Button();
            this.takeBerthButton = new System.Windows.Forms.Button();
            this.textBoxNewLevelName = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddVehicle = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ЗагрузитьTooltopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.отчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.buttonSort = new System.Windows.Forms.Button();
            this.загрузитьИзБазыДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВБазуДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBerth)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxBerth
            // 
            this.pictureBoxBerth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxBerth.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.pictureBoxBerth.Location = new System.Drawing.Point(0, 27);
            this.pictureBoxBerth.Name = "pictureBoxBerth";
            this.pictureBoxBerth.Size = new System.Drawing.Size(660, 423);
            this.pictureBoxBerth.TabIndex = 0;
            this.pictureBoxBerth.TabStop = false;
            this.pictureBoxBerth.UseWaitCursor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.maskedTextBoxPlace);
            this.groupBox1.Location = new System.Drawing.Point(686, 348);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 87);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Забрать корабль";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(22, 46);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Забрать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ButtonTakeShip_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Место";
            // 
            // maskedTextBoxPlace
            // 
            this.maskedTextBoxPlace.Location = new System.Drawing.Point(63, 20);
            this.maskedTextBoxPlace.Name = "maskedTextBoxPlace";
            this.maskedTextBoxPlace.Size = new System.Drawing.Size(34, 20);
            this.maskedTextBoxPlace.TabIndex = 0;
            // 
            // listBoxBerths
            // 
            this.listBoxBerths.FormattingEnabled = true;
            this.listBoxBerths.Location = new System.Drawing.Point(686, 115);
            this.listBoxBerths.Name = "listBoxBerths";
            this.listBoxBerths.Size = new System.Drawing.Size(148, 95);
            this.listBoxBerths.TabIndex = 4;
            this.listBoxBerths.Click += new System.EventHandler(this.ListBoxBerhs_SelectedIndexChanged);
            // 
            // addBerthButton
            // 
            this.addBerthButton.Location = new System.Drawing.Point(686, 86);
            this.addBerthButton.Name = "addBerthButton";
            this.addBerthButton.Size = new System.Drawing.Size(148, 23);
            this.addBerthButton.TabIndex = 5;
            this.addBerthButton.Text = "Добавить причал";
            this.addBerthButton.UseVisualStyleBackColor = true;
            this.addBerthButton.Click += new System.EventHandler(this.ButtonAddBerth_Click);
            // 
            // takeBerthButton
            // 
            this.takeBerthButton.Location = new System.Drawing.Point(686, 216);
            this.takeBerthButton.Name = "takeBerthButton";
            this.takeBerthButton.Size = new System.Drawing.Size(148, 23);
            this.takeBerthButton.TabIndex = 6;
            this.takeBerthButton.Text = "Удалить причал";
            this.takeBerthButton.UseVisualStyleBackColor = true;
            this.takeBerthButton.Click += new System.EventHandler(this.ButtonDelBerth_Click);
            // 
            // textBoxNewLevelName
            // 
            this.textBoxNewLevelName.Location = new System.Drawing.Point(686, 60);
            this.textBoxNewLevelName.Name = "textBoxNewLevelName";
            this.textBoxNewLevelName.Size = new System.Drawing.Size(148, 20);
            this.textBoxNewLevelName.TabIndex = 7;
            this.textBoxNewLevelName.Text = "Причал 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(731, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Причалы";
            // 
            // buttonAddVehicle
            // 
            this.buttonAddVehicle.Location = new System.Drawing.Point(686, 288);
            this.buttonAddVehicle.Name = "buttonAddVehicle";
            this.buttonAddVehicle.Size = new System.Drawing.Size(148, 23);
            this.buttonAddVehicle.TabIndex = 9;
            this.buttonAddVehicle.Text = "Добавить корабль";
            this.buttonAddVehicle.UseVisualStyleBackColor = true;
            this.buttonAddVehicle.Click += new System.EventHandler(this.ButtonAddVehicle_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.отчетToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(652, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ЗагрузитьTooltopMenuItem,
            this.toolStripSeparator,
            this.сохранитьToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.загрузитьИзБазыДанныхToolStripMenuItem,
            this.сохранитьВБазуДанныхToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "&Файл";
            // 
            // ЗагрузитьTooltopMenuItem
            // 
            this.ЗагрузитьTooltopMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ЗагрузитьTooltopMenuItem.Image")));
            this.ЗагрузитьTooltopMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ЗагрузитьTooltopMenuItem.Name = "ЗагрузитьTooltopMenuItem";
            this.ЗагрузитьTooltopMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.ЗагрузитьTooltopMenuItem.Size = new System.Drawing.Size(216, 22);
            this.ЗагрузитьTooltopMenuItem.Text = "&Загрузить";
            this.ЗагрузитьTooltopMenuItem.Click += new System.EventHandler(this.ЗагрузитьToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(177, 6);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("сохранитьToolStripMenuItem.Image")));
            this.сохранитьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сохранитьToolStripMenuItem.Text = "&Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.СохранитьToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // отчетToolStripMenuItem
            // 
            this.отчетToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.показатьToolStripMenuItem});
            this.отчетToolStripMenuItem.Name = "отчетToolStripMenuItem";
            this.отчетToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.отчетToolStripMenuItem.Text = "Отчет";
            // 
            // показатьToolStripMenuItem
            // 
            this.показатьToolStripMenuItem.Name = "показатьToolStripMenuItem";
            this.показатьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.показатьToolStripMenuItem.Text = "Показать";
            this.показатьToolStripMenuItem.Click += new System.EventHandler(this.показатьToolStripMenuItem_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "txt file | *.txt";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "txt file | *.txt";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(652, 3);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(652, 27);
            this.toolStripContainer1.TabIndex = 11;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(686, 249);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(148, 23);
            this.buttonSort.TabIndex = 12;
            this.buttonSort.Text = "Сортировать";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // загрузитьИзБазыДанныхToolStripMenuItem
            // 
            this.загрузитьИзБазыДанныхToolStripMenuItem.Name = "загрузитьИзБазыДанныхToolStripMenuItem";
            this.загрузитьИзБазыДанныхToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.загрузитьИзБазыДанныхToolStripMenuItem.Text = "Загрузить из базы данных";
            // 
            // сохранитьВБазуДанныхToolStripMenuItem
            // 
            this.сохранитьВБазуДанныхToolStripMenuItem.Name = "сохранитьВБазуДанныхToolStripMenuItem";
            this.сохранитьВБазуДанныхToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.сохранитьВБазуДанныхToolStripMenuItem.Text = "Сохранить в базу данных";
            // 
            // FormBerth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 450);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.buttonAddVehicle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNewLevelName);
            this.Controls.Add(this.takeBerthButton);
            this.Controls.Add(this.addBerthButton);
            this.Controls.Add(this.listBoxBerths);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBoxBerth);
            this.Name = "FormBerth";
            this.Text = "Пристань";
            this.Load += new System.EventHandler(this.FormBerth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBerth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBerth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPlace;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBoxBerths;
        private System.Windows.Forms.Button addBerthButton;
        private System.Windows.Forms.Button takeBerthButton;
        private System.Windows.Forms.MaskedTextBox textBoxNewLevelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAddVehicle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ЗагрузитьTooltopMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.ToolStripMenuItem отчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьИзБазыДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВБазуДанныхToolStripMenuItem;
    }
}