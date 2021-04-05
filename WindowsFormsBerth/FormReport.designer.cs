
namespace WindowsFormsTransport
{
    partial class FormReport
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
			this.groupBoxReportFilter = new System.Windows.Forms.GroupBox();
			this.buttonSaveToPDF = new System.Windows.Forms.Button();
			this.buttonSaveToExcel = new System.Windows.Forms.Button();
			this.listBoxBerths = new System.Windows.Forms.ListBox();
			this.labelBerth = new System.Windows.Forms.Label();
			this.labelActionTo = new System.Windows.Forms.Label();
			this.labelActionFrom = new System.Windows.Forms.Label();
			this.dateTimeActionTo = new System.Windows.Forms.DateTimePicker();
			this.dateTimeActionFrom = new System.Windows.Forms.DateTimePicker();
			this.buttonLoadReport = new System.Windows.Forms.Button();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BerthName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.shipType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ActionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBoxReportFilter.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBoxReportFilter
			// 
			this.groupBoxReportFilter.Controls.Add(this.buttonSaveToPDF);
			this.groupBoxReportFilter.Controls.Add(this.buttonSaveToExcel);
			this.groupBoxReportFilter.Controls.Add(this.listBoxBerths);
			this.groupBoxReportFilter.Controls.Add(this.labelBerth);
			this.groupBoxReportFilter.Controls.Add(this.labelActionTo);
			this.groupBoxReportFilter.Controls.Add(this.labelActionFrom);
			this.groupBoxReportFilter.Controls.Add(this.dateTimeActionTo);
			this.groupBoxReportFilter.Controls.Add(this.dateTimeActionFrom);
			this.groupBoxReportFilter.Controls.Add(this.buttonLoadReport);
			this.groupBoxReportFilter.Location = new System.Drawing.Point(588, 47);
			this.groupBoxReportFilter.Name = "groupBoxReportFilter";
			this.groupBoxReportFilter.Size = new System.Drawing.Size(200, 391);
			this.groupBoxReportFilter.TabIndex = 0;
			this.groupBoxReportFilter.TabStop = false;
			this.groupBoxReportFilter.Text = "Получить отчет";
			// 
			// buttonSaveToPDF
			// 
			this.buttonSaveToPDF.Location = new System.Drawing.Point(21, 334);
			this.buttonSaveToPDF.Name = "buttonSaveToPDF";
			this.buttonSaveToPDF.Size = new System.Drawing.Size(151, 23);
			this.buttonSaveToPDF.TabIndex = 9;
			this.buttonSaveToPDF.Text = "Выгрузить в PDF";
			this.buttonSaveToPDF.UseVisualStyleBackColor = true;
			this.buttonSaveToPDF.Click += new System.EventHandler(this.buttonSaveToPDF_Click);
			// 
			// buttonSaveToExcel
			// 
			this.buttonSaveToExcel.Location = new System.Drawing.Point(21, 278);
			this.buttonSaveToExcel.Name = "buttonSaveToExcel";
			this.buttonSaveToExcel.Size = new System.Drawing.Size(151, 23);
			this.buttonSaveToExcel.TabIndex = 8;
			this.buttonSaveToExcel.Text = "Выгрузить в Excel";
			this.buttonSaveToExcel.UseVisualStyleBackColor = true;
			this.buttonSaveToExcel.Click += new System.EventHandler(this.buttonSaveToExcel_Click);
			// 
			// listBoxBerths
			// 
			this.listBoxBerths.FormattingEnabled = true;
			this.listBoxBerths.Location = new System.Drawing.Point(6, 42);
			this.listBoxBerths.Name = "listBoxBerths";
			this.listBoxBerths.Size = new System.Drawing.Size(188, 69);
			this.listBoxBerths.TabIndex = 7;
			// 
			// labelBerth
			// 
			this.labelBerth.AutoSize = true;
			this.labelBerth.Location = new System.Drawing.Point(6, 26);
			this.labelBerth.Name = "labelBerth";
			this.labelBerth.Size = new System.Drawing.Size(44, 13);
			this.labelBerth.TabIndex = 5;
			this.labelBerth.Text = "Причал";
			// 
			// labelActionTo
			// 
			this.labelActionTo.AutoSize = true;
			this.labelActionTo.Location = new System.Drawing.Point(6, 173);
			this.labelActionTo.Name = "labelActionTo";
			this.labelActionTo.Size = new System.Drawing.Size(60, 13);
			this.labelActionTo.TabIndex = 4;
			this.labelActionTo.Text = "Период до";
			// 
			// labelActionFrom
			// 
			this.labelActionFrom.AutoSize = true;
			this.labelActionFrom.Location = new System.Drawing.Point(6, 119);
			this.labelActionFrom.Name = "labelActionFrom";
			this.labelActionFrom.Size = new System.Drawing.Size(54, 13);
			this.labelActionFrom.TabIndex = 3;
			this.labelActionFrom.Text = "Период с";
			// 
			// dateTimeActionTo
			// 
			this.dateTimeActionTo.Location = new System.Drawing.Point(9, 189);
			this.dateTimeActionTo.Name = "dateTimeActionTo";
			this.dateTimeActionTo.Size = new System.Drawing.Size(196, 20);
			this.dateTimeActionTo.TabIndex = 2;
			// 
			// dateTimeActionFrom
			// 
			this.dateTimeActionFrom.Location = new System.Drawing.Point(9, 135);
			this.dateTimeActionFrom.Name = "dateTimeActionFrom";
			this.dateTimeActionFrom.Size = new System.Drawing.Size(196, 20);
			this.dateTimeActionFrom.TabIndex = 1;
			// 
			// buttonLoadReport
			// 
			this.buttonLoadReport.Location = new System.Drawing.Point(21, 235);
			this.buttonLoadReport.Name = "buttonLoadReport";
			this.buttonLoadReport.Size = new System.Drawing.Size(151, 23);
			this.buttonLoadReport.TabIndex = 0;
			this.buttonLoadReport.Text = "Обновить";
			this.buttonLoadReport.UseVisualStyleBackColor = true;
			this.buttonLoadReport.Click += new System.EventHandler(this.buttonLoadReport_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.BerthName,
            this.shipType,
            this.ActionName});
			this.dataGridView.Location = new System.Drawing.Point(13, 47);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.Size = new System.Drawing.Size(559, 391);
			this.dataGridView.TabIndex = 1;
			// 
			// Id
			// 
			this.Id.HeaderText = "Id";
			this.Id.Name = "Id";
			this.Id.ReadOnly = true;
			// 
			// BerthName
			// 
			this.BerthName.HeaderText = "Причал";
			this.BerthName.Name = "BerthName";
			this.BerthName.ReadOnly = true;
			// 
			// shipType
			// 
			this.shipType.HeaderText = "Тип корабля";
			this.shipType.Name = "shipType";
			// 
			// ActionName
			// 
			this.ActionName.HeaderText = "Действие";
			this.ActionName.Name = "ActionName";
			// 
			// FormReport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.groupBoxReportFilter);
			this.Name = "FormReport";
			this.Text = "ReportForm";
			this.groupBoxReportFilter.ResumeLayout(false);
			this.groupBoxReportFilter.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxReportFilter;
        private System.Windows.Forms.Label labelBerth;
        private System.Windows.Forms.Label labelActionTo;
        private System.Windows.Forms.Label labelActionFrom;
        private System.Windows.Forms.DateTimePicker dateTimeActionTo;
        private System.Windows.Forms.DateTimePicker dateTimeActionFrom;
        private System.Windows.Forms.Button buttonLoadReport;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ListBox listBoxBerths;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn BerthName;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionName;
        private System.Windows.Forms.Button buttonSaveToPDF;
        private System.Windows.Forms.Button buttonSaveToExcel;
    }
}