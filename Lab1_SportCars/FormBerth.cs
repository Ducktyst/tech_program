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
        private readonly BerthCollection _berthCollection;

        public FormBerth()
        {
            InitializeComponent();
            _berthCollection = new BerthCollection(pictureBoxBerth.Width, pictureBoxBerth.Height);
            Draw();
        }

        /// <summary>
        /// Заполнение listBoxLevels
        /// </summary>
        private void ReloadLevels()
        {
            int index = listBoxBerths.SelectedIndex;
            listBoxBerths.Items.Clear();
            for (int i = 0; i < _berthCollection.Keys.Count; i++)
            {
                listBoxBerths.Items.Add(_berthCollection.Keys[i]);
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
                _berthCollection[listBoxBerths.SelectedItem.ToString()].Draw(gr);
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
            _berthCollection.AddBerth(textBoxNewLevelName.Text);
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
                if (MessageBox.Show($"Удалить причал {listBoxBerths.SelectedItem}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _berthCollection.DelBerth(listBoxBerths.SelectedItem.ToString());
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
                var ship = _berthCollection[listBoxBerths.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBoxPlace.Text);
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
                if (_berthCollection[listBoxBerths.SelectedItem.ToString()] + vehicle)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Причал переполнен");
                }
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Добавить корабль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddVehicle_Click(object sender, EventArgs e)
        {
            // TODO: Проверка наличия причала со свободным местом
            var formShipConfig = new FormShipConfig();
            formShipConfig.AddEvent(AddShip);
            formShipConfig.Show();
        }

        /// <summary>
        /// Метод добавления корабля
        /// </summary>
        /// <param name="ship"></param>
        private void AddShip(Vehicle ship)
        {
            if (ship != null && listBoxBerths.SelectedIndex > -1)
            {
                if ((_berthCollection[listBoxBerths.SelectedItem.ToString()]) + ship)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Корабль не удалось добавить");
                }
            }
        }

        /// <summary>
        /// Обработка нажатия пункта меню "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void СохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (_berthCollection.SaveData(saveFileDialog.FileName))
                {
                    MessageBox.Show("Сохранение прошло успешно",
                    "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не сохранилось", "Результат",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Обработка нажатия пункта меню "Загрузить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ЗагрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (_berthCollection.LoadData(openFileDialog.FileName))
                {
                    MessageBox.Show("Загрузили", "Результат",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReloadLevels();
                    Draw();
                }
                else
                {
                    MessageBox.Show("Не загрузили", "Результат",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}