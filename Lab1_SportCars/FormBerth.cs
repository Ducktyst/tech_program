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
    public partial class FormBerth : Form
    {

        /// <summary>
        /// Объект от класса причала
        /// </summary>
        private readonly Berth<Vehicle> berth;

        public FormBerth()
        {
            InitializeComponent();
            berth = new Berth<Vehicle>(pictureBoxBerth.Width, pictureBoxBerth.Height);
            Draw();
        }

        /// <summary>
        /// Метод отрисовки причала
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxBerth.Width, pictureBoxBerth.Height);
            Graphics gr = Graphics.FromImage(bmp);
            berth.Draw(gr);
            pictureBoxBerth.Image = bmp;
        }

        /// <summary>
        /// Обработка нажатия кнопки "Пришвартовать корабль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSetShip_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                AddToBerth(new WarShip(100, 1000, dialog.Color));
            }
        }


        /// <summary>
        /// Обработка нажатия кнопки "Пришвартовать крейсер"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSetCruiser_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                AddToBerth(new Cruiser(100, 1000, dialog.Color, dialogDop.Color, true, true));
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Забрать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTakeShip_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "")
            {
                var ship = berth - Convert.ToInt32(maskedTextBox1.Text);
                if (ship != null)
                {
                    FormShip form = new FormShip();
                    form.SetShip(ship);
                    form.ShowDialog();
                } else {
                    MessageBox.Show("Нет места с таким номером. Допустимый диапазон от " + 0 + " до " + berth.lastPlaceIndex);
                }
                Draw();
            }
        }
        /// <summary>
        /// Добавление объекта в класс-хранилище
        /// </summary>
        /// <param name="vehicle"></param>
        private void AddToBerth(Vehicle vehicle)
        {
            if (berth + vehicle)
            {
                Draw();
            }
            else
            {
                MessageBox.Show("Причал переполнен");
            }
        }
    }
}
