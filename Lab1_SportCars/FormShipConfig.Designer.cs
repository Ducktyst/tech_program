
namespace WindowsFormsTransport
{
    partial class FormShipConfig
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
			this.groupBoxShipType = new System.Windows.Forms.GroupBox();
			this.labelCruiser = new System.Windows.Forms.Label();
			this.labelWarShip = new System.Windows.Forms.Label();
			this.groupBoxConfig = new System.Windows.Forms.GroupBox();
			this.checkBoxHelicopter = new System.Windows.Forms.CheckBox();
			this.checkBoxGuns = new System.Windows.Forms.CheckBox();
			this.labelWeight = new System.Windows.Forms.Label();
			this.labelMaxSpeed = new System.Windows.Forms.Label();
			this.numericUpDownWeight = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownMaxSpeed = new System.Windows.Forms.NumericUpDown();
			this.pictureBoxShip = new System.Windows.Forms.PictureBox();
			this.panelShip = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panelDopColor4 = new System.Windows.Forms.Panel();
			this.panelDopColor2 = new System.Windows.Forms.Panel();
			this.panelDopColor3 = new System.Windows.Forms.Panel();
			this.panelDopColor1 = new System.Windows.Forms.Panel();
			this.panelMainColor4 = new System.Windows.Forms.Panel();
			this.panelMainColor2 = new System.Windows.Forms.Panel();
			this.panelMainColor3 = new System.Windows.Forms.Panel();
			this.panelMainColor1 = new System.Windows.Forms.Panel();
			this.labelDopColor = new System.Windows.Forms.Label();
			this.labelMainColor = new System.Windows.Forms.Label();
			this.buttonAddShip = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.groupBoxShipType.SuspendLayout();
			this.groupBoxConfig.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxShip)).BeginInit();
			this.panelShip.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxShipType
			// 
			this.groupBoxShipType.Controls.Add(this.labelCruiser);
			this.groupBoxShipType.Controls.Add(this.labelWarShip);
			this.groupBoxShipType.Location = new System.Drawing.Point(12, 12);
			this.groupBoxShipType.Name = "groupBoxShipType";
			this.groupBoxShipType.Size = new System.Drawing.Size(201, 146);
			this.groupBoxShipType.TabIndex = 0;
			this.groupBoxShipType.TabStop = false;
			this.groupBoxShipType.Text = "Тип корабля";
			// 
			// labelCruiser
			// 
			this.labelCruiser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelCruiser.Location = new System.Drawing.Point(18, 80);
			this.labelCruiser.Name = "labelCruiser";
			this.labelCruiser.Size = new System.Drawing.Size(166, 31);
			this.labelCruiser.TabIndex = 1;
			this.labelCruiser.Text = "Крейсер";
			this.labelCruiser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelCruiser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelObject_MouseDown);
			// 
			// labelWarShip
			// 
			this.labelWarShip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelWarShip.Location = new System.Drawing.Point(18, 35);
			this.labelWarShip.Name = "labelWarShip";
			this.labelWarShip.Size = new System.Drawing.Size(166, 30);
			this.labelWarShip.TabIndex = 0;
			this.labelWarShip.Text = "Военный корабль";
			this.labelWarShip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelWarShip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelObject_MouseDown);
			// 
			// groupBoxConfig
			// 
			this.groupBoxConfig.Controls.Add(this.checkBoxHelicopter);
			this.groupBoxConfig.Controls.Add(this.checkBoxGuns);
			this.groupBoxConfig.Controls.Add(this.labelWeight);
			this.groupBoxConfig.Controls.Add(this.labelMaxSpeed);
			this.groupBoxConfig.Controls.Add(this.numericUpDownWeight);
			this.groupBoxConfig.Controls.Add(this.numericUpDownMaxSpeed);
			this.groupBoxConfig.Location = new System.Drawing.Point(12, 178);
			this.groupBoxConfig.Name = "groupBoxConfig";
			this.groupBoxConfig.Size = new System.Drawing.Size(403, 140);
			this.groupBoxConfig.TabIndex = 1;
			this.groupBoxConfig.TabStop = false;
			this.groupBoxConfig.Text = "Параметры";
			// 
			// checkBoxHelicopter
			// 
			this.checkBoxHelicopter.AutoSize = true;
			this.checkBoxHelicopter.Location = new System.Drawing.Point(237, 68);
			this.checkBoxHelicopter.Name = "checkBoxHelicopter";
			this.checkBoxHelicopter.Size = new System.Drawing.Size(145, 17);
			this.checkBoxHelicopter.TabIndex = 5;
			this.checkBoxHelicopter.Text = "Вертолетная площадка";
			this.checkBoxHelicopter.UseVisualStyleBackColor = true;
			// 
			// checkBoxGuns
			// 
			this.checkBoxGuns.AutoSize = true;
			this.checkBoxGuns.Location = new System.Drawing.Point(237, 45);
			this.checkBoxGuns.Name = "checkBoxGuns";
			this.checkBoxGuns.Size = new System.Drawing.Size(65, 17);
			this.checkBoxGuns.TabIndex = 4;
			this.checkBoxGuns.Text = "Оружие";
			this.checkBoxGuns.UseVisualStyleBackColor = true;
			// 
			// labelWeight
			// 
			this.labelWeight.AutoSize = true;
			this.labelWeight.Location = new System.Drawing.Point(18, 72);
			this.labelWeight.Name = "labelWeight";
			this.labelWeight.Size = new System.Drawing.Size(26, 13);
			this.labelWeight.TabIndex = 3;
			this.labelWeight.Text = "Вес";
			// 
			// labelMaxSpeed
			// 
			this.labelMaxSpeed.AutoSize = true;
			this.labelMaxSpeed.Location = new System.Drawing.Point(17, 31);
			this.labelMaxSpeed.Name = "labelMaxSpeed";
			this.labelMaxSpeed.Size = new System.Drawing.Size(134, 13);
			this.labelMaxSpeed.TabIndex = 2;
			this.labelMaxSpeed.Text = "Максимальная скорость";
			// 
			// numericUpDownWeight
			// 
			this.numericUpDownWeight.Location = new System.Drawing.Point(76, 88);
			this.numericUpDownWeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownWeight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numericUpDownWeight.Name = "numericUpDownWeight";
			this.numericUpDownWeight.Size = new System.Drawing.Size(120, 20);
			this.numericUpDownWeight.TabIndex = 1;
			this.numericUpDownWeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// numericUpDownMaxSpeed
			// 
			this.numericUpDownMaxSpeed.Location = new System.Drawing.Point(76, 50);
			this.numericUpDownMaxSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownMaxSpeed.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numericUpDownMaxSpeed.Name = "numericUpDownMaxSpeed";
			this.numericUpDownMaxSpeed.Size = new System.Drawing.Size(120, 20);
			this.numericUpDownMaxSpeed.TabIndex = 0;
			this.numericUpDownMaxSpeed.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// pictureBoxShip
			// 
			this.pictureBoxShip.Location = new System.Drawing.Point(17, 14);
			this.pictureBoxShip.Name = "pictureBoxShip";
			this.pictureBoxShip.Size = new System.Drawing.Size(166, 103);
			this.pictureBoxShip.TabIndex = 2;
			this.pictureBoxShip.TabStop = false;
			// 
			// panelShip
			// 
			this.panelShip.AllowDrop = true;
			this.panelShip.Controls.Add(this.pictureBoxShip);
			this.panelShip.Location = new System.Drawing.Point(232, 23);
			this.panelShip.Name = "panelShip";
			this.panelShip.Size = new System.Drawing.Size(201, 135);
			this.panelShip.TabIndex = 3;
			this.panelShip.DragDrop += new System.Windows.Forms.DragEventHandler(this.PanelShip_DragDrop);
			this.panelShip.DragEnter += new System.Windows.Forms.DragEventHandler(this.PanelShip_DragEnter);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panelDopColor4);
			this.groupBox1.Controls.Add(this.panelDopColor2);
			this.groupBox1.Controls.Add(this.panelDopColor3);
			this.groupBox1.Controls.Add(this.panelDopColor1);
			this.groupBox1.Controls.Add(this.panelMainColor4);
			this.groupBox1.Controls.Add(this.panelMainColor2);
			this.groupBox1.Controls.Add(this.panelMainColor3);
			this.groupBox1.Controls.Add(this.panelMainColor1);
			this.groupBox1.Controls.Add(this.labelDopColor);
			this.groupBox1.Controls.Add(this.labelMainColor);
			this.groupBox1.Location = new System.Drawing.Point(452, 23);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(303, 135);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Цвета";
			// 
			// panelDopColor4
			// 
			this.panelDopColor4.BackColor = System.Drawing.SystemColors.Highlight;
			this.panelDopColor4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelDopColor4.Location = new System.Drawing.Point(212, 92);
			this.panelDopColor4.Name = "panelDopColor4";
			this.panelDopColor4.Size = new System.Drawing.Size(32, 29);
			this.panelDopColor4.TabIndex = 9;
			// 
			// panelDopColor2
			// 
			this.panelDopColor2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.panelDopColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelDopColor2.Location = new System.Drawing.Point(212, 54);
			this.panelDopColor2.Name = "panelDopColor2";
			this.panelDopColor2.Size = new System.Drawing.Size(32, 29);
			this.panelDopColor2.TabIndex = 7;
			// 
			// panelDopColor3
			// 
			this.panelDopColor3.BackColor = System.Drawing.Color.White;
			this.panelDopColor3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelDopColor3.Location = new System.Drawing.Point(174, 92);
			this.panelDopColor3.Name = "panelDopColor3";
			this.panelDopColor3.Size = new System.Drawing.Size(32, 29);
			this.panelDopColor3.TabIndex = 8;
			// 
			// panelDopColor1
			// 
			this.panelDopColor1.BackColor = System.Drawing.Color.Black;
			this.panelDopColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelDopColor1.Location = new System.Drawing.Point(174, 54);
			this.panelDopColor1.Name = "panelDopColor1";
			this.panelDopColor1.Size = new System.Drawing.Size(32, 29);
			this.panelDopColor1.TabIndex = 6;
			// 
			// panelMainColor4
			// 
			this.panelMainColor4.BackColor = System.Drawing.Color.Blue;
			this.panelMainColor4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelMainColor4.Location = new System.Drawing.Point(70, 92);
			this.panelMainColor4.Name = "panelMainColor4";
			this.panelMainColor4.Size = new System.Drawing.Size(32, 29);
			this.panelMainColor4.TabIndex = 5;
			// 
			// panelMainColor2
			// 
			this.panelMainColor2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.panelMainColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelMainColor2.Location = new System.Drawing.Point(70, 54);
			this.panelMainColor2.Name = "panelMainColor2";
			this.panelMainColor2.Size = new System.Drawing.Size(32, 29);
			this.panelMainColor2.TabIndex = 3;
			// 
			// panelMainColor3
			// 
			this.panelMainColor3.BackColor = System.Drawing.Color.Yellow;
			this.panelMainColor3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelMainColor3.Location = new System.Drawing.Point(32, 92);
			this.panelMainColor3.Name = "panelMainColor3";
			this.panelMainColor3.Size = new System.Drawing.Size(32, 29);
			this.panelMainColor3.TabIndex = 4;
			// 
			// panelMainColor1
			// 
			this.panelMainColor1.BackColor = System.Drawing.Color.Red;
			this.panelMainColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelMainColor1.Location = new System.Drawing.Point(32, 54);
			this.panelMainColor1.Name = "panelMainColor1";
			this.panelMainColor1.Size = new System.Drawing.Size(32, 29);
			this.panelMainColor1.TabIndex = 2;
			// 
			// labelDopColor
			// 
			this.labelDopColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelDopColor.Location = new System.Drawing.Point(161, 19);
			this.labelDopColor.Name = "labelDopColor";
			this.labelDopColor.Size = new System.Drawing.Size(100, 23);
			this.labelDopColor.TabIndex = 1;
			this.labelDopColor.Text = "Доп. цвет";
			this.labelDopColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelMainColor
			// 
			this.labelMainColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelMainColor.Location = new System.Drawing.Point(21, 19);
			this.labelMainColor.Name = "labelMainColor";
			this.labelMainColor.Size = new System.Drawing.Size(100, 23);
			this.labelMainColor.TabIndex = 0;
			this.labelMainColor.Text = "Основной цвет";
			this.labelMainColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonAddShip
			// 
			this.buttonAddShip.Location = new System.Drawing.Point(680, 189);
			this.buttonAddShip.Name = "buttonAddShip";
			this.buttonAddShip.Size = new System.Drawing.Size(75, 23);
			this.buttonAddShip.TabIndex = 5;
			this.buttonAddShip.Text = "Добавить";
			this.buttonAddShip.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(680, 228);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// FormShipConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(790, 337);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonAddShip);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panelShip);
			this.Controls.Add(this.groupBoxConfig);
			this.Controls.Add(this.groupBoxShipType);
			this.Name = "FormShipConfig";
			this.Text = "FormConfig";
			this.groupBoxShipType.ResumeLayout(false);
			this.groupBoxConfig.ResumeLayout(false);
			this.groupBoxConfig.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxShip)).EndInit();
			this.panelShip.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxShipType;
        private System.Windows.Forms.Label labelCruiser;
        private System.Windows.Forms.Label labelWarShip;
        private System.Windows.Forms.GroupBox groupBoxConfig;
        private System.Windows.Forms.CheckBox checkBoxHelicopter;
        private System.Windows.Forms.CheckBox checkBoxGuns;
        private System.Windows.Forms.Label labelWeight;
        private System.Windows.Forms.Label labelMaxSpeed;
        private System.Windows.Forms.NumericUpDown numericUpDownWeight;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxSpeed;
        private System.Windows.Forms.PictureBox pictureBoxShip;
        private System.Windows.Forms.Panel panelShip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelDopColor4;
        private System.Windows.Forms.Panel panelDopColor2;
        private System.Windows.Forms.Panel panelDopColor3;
        private System.Windows.Forms.Panel panelDopColor1;
        private System.Windows.Forms.Panel panelMainColor4;
        private System.Windows.Forms.Panel panelMainColor2;
        private System.Windows.Forms.Panel panelMainColor3;
        private System.Windows.Forms.Panel panelMainColor1;
        private System.Windows.Forms.Label labelDopColor;
        private System.Windows.Forms.Label labelMainColor;
        private System.Windows.Forms.Button buttonAddShip;
        private System.Windows.Forms.Button buttonCancel;
    }
}