using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsTransport.DB;
using WindowsFormsTransport.DB.Storages;
using WindowsFormsTransport.DB.ViewModels;

namespace WindowsFormsTransport
{
    public partial class FormReport : Form
    {

        //private readonly BerthLogic logic;
        private readonly BerthStorage berthStorage;

        private readonly ActionLogStorage actionLogStorage;

        public FormReport()
        {
            InitializeComponent();
            this.berthStorage = new BerthStorage();
            this.actionLogStorage = new ActionLogStorage();
        }

        public FormReport(BerthStorage storage)
        {
            InitializeComponent();
            //this.logic = logic;
            this.berthStorage = storage;
        }

        private void buttonLoadReport_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                //var listBoxBerth = listViewActionBerths.SelectedItem.ToString();
                var berthName = listBoxBerths.SelectedItem.ToString();

                /*                var berths = berthStorage.GetFilteredList(new DB.Models.Berth { Name = berthName }));
                                if (berths.Count() == 0 )
                                {
                                    MessageBox.Show("Нет такого причала в базе данных");
                                    return;
                                }
                                var berthId = berths.First().Id;*/

                //var berthFilter = new DB.BindingModels.BerthBindingModel
                //{
                //    Name = berthName
                //};

                BerthViewModel berth = BerthStorage.GetElement(berthName);

                if (berth == null)
                {
                    MessageBox.Show("Причал с таким именем не найден в базе", "Результат",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime actionFrom = dateTimeActionFrom.Value;
                DateTime actionTo = dateTimeActionTo.Value;
                int berthId = berth.Id.Value;

                var actions = actionLogStorage.GetFilteredList(actionFrom, actionTo, berthId);
                if (actions != null)
                {
                    dataGridView.DataSource = actions;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

		private void buttonSaveToExcel_Click(object sender, EventArgs e)
		{

		}

		private void buttonSaveToPDF_Click(object sender, EventArgs e)
		{
            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(Application.StartupPath + @"\Document.pdf", FileMode.Create));
            doc.Open();
           // iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(Application.StartupPath + @"/images.jpg");
            //jpg.Alignment = Element.ALIGN_CENTER;
            //doc.Add(jpg);
            PdfPTable table = new PdfPTable(3);
            PdfPCell cell = new PdfPCell(new Phrase("Simple table",
              new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16,
              iTextSharp.text.Font.NORMAL, new BaseColor(Color.Orange))));
            cell.BackgroundColor = new BaseColor(Color.Wheat);
            cell.Padding = 5;
            cell.Colspan = 3;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            table.AddCell("Col 1 Row 1");
            table.AddCell("Col 2 Row 1");
            table.AddCell("Col 3 Row 1");
            table.AddCell("Col 1 Row 2");
            table.AddCell("Col 2 Row 2");
            table.AddCell("Col 3 Row 2");
           // jpg = iTextSharp.text.Image.GetInstance(Application.StartupPath + @"/left.jpg");
          //  cell = new PdfPCell(jpg);
            cell.Padding = 5;
            cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Col 2 Row 3"));
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            table.AddCell(cell);
            //jpg = iTextSharp.text.Image.GetInstance(Application.StartupPath + @"/right.jpg");
            //cell = new PdfPCell(jpg);
            cell.Padding = 5;
            cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            table.AddCell(cell);
            doc.Add(table);
            doc.Close();
        }
	}
}
