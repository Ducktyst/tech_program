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
        /// Объект от класса-коллекции причалов
        /// </summary>
        private readonly BerthCollection _BerthCollection;

        public FormBerth()
        {
            InitializeComponent();
            _BerthCollection = new BerthCollection(pictureBoxBerth.Width, pictureBoxBerth.Height);
            Draw();
        }

        /// <summary>
        /// Заполнение listBoxLevels
        /// </summary>
        private void ReloadLevels()
        {
            int index = listBoxBerths.SelectedIndex;
            listBoxBerths.Items.Clear();
            for (int i = 0; i < _BerthCollection.Keys.Count; i++)
            {
                listBoxBerths.Items.Add(_BerthCollection.Keys[i]);
            }
            if (listBoxBerths.Items.Count > 0 && (index == -1 || index >= listBoxBerths.Items.Count))
            {
                listBoxBerths.SelectedIndex = 0;
            }
            else if (listBoxBerths.Items.Count > 0 && index > -1 && index < listBoxBerths.Items.Count)
            {
                listBoxBerths.SelectedIndex = index;
            }
        }
        /// <summary>
        /// Метод отрисовки причала
        /// </summary>
        private void Draw()
        {
            if (listBoxBerths.SelectedIndex > -1)
            {//если выбран один из пуктов в listBox (при старте программы ни
                //один пункт не будет выбран и может возникнуть ошибка, если мы попытаемся обратиться к
                // элементу listBox)
                Bitmap bmp = new Bitmap(pictureBoxBerth.Width, pictureBoxBerth.Height);
                Graphics gr = Graphics.FromImage(bmp);
                _BerthCollection[listBoxBerths.SelectedItem.ToString()].Draw(gr);
                pictureBoxBerth.Image = bmp;
            }
        }
        /// <summary>
        /// Обработка нажатия кнопки "Добавить причал"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddBerth_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNewLevelName.Text))
            {
                MessageBox.Show("Введите название причала", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _BerthCollection.AddBerth(textBoxNewLevelName.Text);
            ReloadLevels();
        }

        /// <summary>
        /// Обработка нажатия кнопки "Удалить причал"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelBerth_Click(object sender, EventArgs e)
        {
            if (listBoxBerths.SelectedIndex > -1)
            {
                if (MessageBox.Show($"Удалить причал {listBoxBerths.SelectedItem}?", "Удаление", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _BerthCollection.DelBerth(listBoxBerths.SelectedItem.ToString());
                    ReloadLevels();
                }
            }
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
            if (maskedTextBoxPlace.Text != "")
            {
                var ship = _BerthCollection[listBoxBerths.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBoxPlace.Text);
                if (ship != null)
                {
                    FormShip form = new FormShip();
                    form.SetShip(ship);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Нет места с таким номером.");
                }
                Draw();
            }
        }

        /// <summary>
        /// Метод обработки выбора элемента на listBoxLevels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBoxBerhs_SelectedIndexChanged(object sender, EventArgs e) => Draw();

        /// <summary>
        /// Добавление объекта в класс-хранилище
        /// </summary>
        /// <param name="vehicle"></param>
        private void AddToBerth(Vehicle vehicle)
        {
            if (listBoxBerths.SelectedIndex > -1)
            {
                if (_BerthCollection[listBoxBerths.SelectedItem.ToString()] + vehicle)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Причал переполнен");
                }
            }
        }

        private void buttonAddVehicle_Click(object sender, EventArgs e)
        {

        }
    }
}
