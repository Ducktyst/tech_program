using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTransport
{
    public partial class FormShipConfig : Form
    {
        /// <summary>
        /// Переменная-выбранный корабль
        /// </summary>
        Vehicle _ship = null;
        public FormShipConfig()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Отрисовать корабль
        /// </summary>
        private void DrawShip()
        {
            if (_ship != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxShip.Width, pictureBoxShip.Height);
                Graphics gr = Graphics.FromImage(bmp);
                _ship.SetPosition(5, 5, pictureBoxShip.Width, pictureBoxShip.Height);
                _ship.DrawTransport(gr);
                pictureBoxShip.Image = bmp;
            }
        }
        /// <summary>
        /// Передаем информацию при нажатии на Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelObject_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Label).DoDragDrop((sender as Label).Name,
            DragDropEffects.Move | DragDropEffects.Copy);
        }

        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelShip_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Действия при приеме перетаскиваемой информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelShip_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "labelWarShip":
                    _ship = new WarShip((int)numericUpDownMaxSpeed.Value,
                    (int)numericUpDownWeight.Value, Color.White);
                    break;
                case "labelCruiser":
                    _ship = new Cruiser((int)numericUpDownMaxSpeed.Value, (int)numericUpDownWeight.Value, Color.White,
                    Color.Black,
                    checkBoxGuns.Checked,
                    checkBoxHelicopter.Checked);
                    break;
            }
            DrawShip();
        }
    }
}
