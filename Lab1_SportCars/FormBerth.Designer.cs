
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
            this.pictureBoxBerth = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBoxPlace = new System.Windows.Forms.MaskedTextBox();
            this.listBoxBerths = new System.Windows.Forms.ListBox();
            this.addBerthButton = new System.Windows.Forms.Button();
            this.takeBerthButton = new System.Windows.Forms.Button();
            this.textBoxNewLevelName = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBerth)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxBerth
            // 
            this.pictureBoxBerth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxBerth.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.pictureBoxBerth.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBerth.Name = "pictureBoxBerth";
            this.pictureBoxBerth.Size = new System.Drawing.Size(660, 450);
            this.pictureBoxBerth.TabIndex = 0;
            this.pictureBoxBerth.TabStop = false;
            this.pictureBoxBerth.UseWaitCursor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(686, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Пришвартовать корабль";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonSetShip_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(686, 284);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 42);
            this.button2.TabIndex = 2;
            this.button2.Text = "Пришвартовать крейсер";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonSetCruiser_Click);
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
            this.listBoxBerths.Location = new System.Drawing.Point(686, 92);
            this.listBoxBerths.Name = "listBoxBerths";
            this.listBoxBerths.Size = new System.Drawing.Size(148, 95);
            this.listBoxBerths.TabIndex = 4;
            this.listBoxBerths.Click += new System.EventHandler(this.ListBoxBerhs_SelectedIndexChanged);
            // 
            // addBerthButton
            // 
            this.addBerthButton.Location = new System.Drawing.Point(686, 63);
            this.addBerthButton.Name = "addBerthButton";
            this.addBerthButton.Size = new System.Drawing.Size(148, 23);
            this.addBerthButton.TabIndex = 5;
            this.addBerthButton.Text = "Добавить причал";
            this.addBerthButton.UseVisualStyleBackColor = true;
            this.addBerthButton.Click += new System.EventHandler(this.ButtonAddBerth_Click);
            // 
            // takeBerthButton
            // 
            this.takeBerthButton.Location = new System.Drawing.Point(686, 193);
            this.takeBerthButton.Name = "takeBerthButton";
            this.takeBerthButton.Size = new System.Drawing.Size(148, 23);
            this.takeBerthButton.TabIndex = 6;
            this.takeBerthButton.Text = "Удалить причал";
            this.takeBerthButton.UseVisualStyleBackColor = true;
            this.takeBerthButton.Click += new System.EventHandler(this.ButtonDelBerth_Click);
            // 
            // textBoxNewLevelName
            // 
            this.textBoxNewLevelName.Location = new System.Drawing.Point(686, 37);
            this.textBoxNewLevelName.Name = "textBoxNewLevelName";
            this.textBoxNewLevelName.Size = new System.Drawing.Size(148, 20);
            this.textBoxNewLevelName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(731, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Причалы";
            // 
            // FormBerth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNewLevelName);
            this.Controls.Add(this.takeBerthButton);
            this.Controls.Add(this.addBerthButton);
            this.Controls.Add(this.listBoxBerths);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBoxBerth);
            this.Name = "FormBerth";
            this.Text = "Пристань";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBerth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBerth;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPlace;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBoxBerths;
        private System.Windows.Forms.Button addBerthButton;
        private System.Windows.Forms.Button takeBerthButton;
        private System.Windows.Forms.MaskedTextBox textBoxNewLevelName;
        private System.Windows.Forms.Label label2;
    }
}