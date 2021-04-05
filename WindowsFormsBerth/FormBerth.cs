using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsBerth.DB.Models;
using WindowsFormsTransport.DB.Storages;

namespace WindowsFormsTransport
{
    public partial class FormBerth : Form
    {
        /// <summary>
        /// Объект от класса-коллекции причалов
        /// </summary>
        private readonly BerthCollection _berthCollection;

        /// <summary>
        /// Логгер
        /// </summary>
        private readonly Logger logger;

        public FormBerth()
        {
            InitializeComponent();
            _berthCollection = new BerthCollection(pictureBoxBerth.Width, pictureBoxBerth.Height);
            Draw();
            logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Заполнение listBoxLevels
        /// </summary>
        private void ReloadLevels()
        {
            int index = listBoxBerths.SelectedIndex;

            listBoxBerths.Items.Clear();
            for (int i = 0; i < _berthCollection._keys.Count; i++)
            {
                listBoxBerths.Items.Add(_berthCollection._keys[i]);
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

            string logMessage = $"Добавлен причал \"{textBoxNewLevelName.Text}\"";
            //ActionLogStorage.InsertNewAction(null, logMessage, (int)ActionTypeEnum.AddBerth);
            logger.Info(logMessage);

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

                    string logMessage = $"Удалили причал \"{listBoxBerths.SelectedItem}\"";
                    //ActionLogStorage.InsertNewAction(null, logMessage, (int)ActionTypeEnum.RemoveBerth);
                    logger.Info(logMessage);
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
            if (listBoxBerths.SelectedIndex > -1 && maskedTextBoxPlace.Text != "")
            {
                try
                {
                    var ship = _berthCollection[listBoxBerths.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBoxPlace.Text);
                    if (ship == null)
                    {
                        var ex = new Exception("Корабль не найден");
                        logger.WarnException("Ошибка при изъятии корабля", ex);
                        throw ex;
                    }

                    FormShip form = new FormShip();
                    form.SetShip(ship);
                    form.ShowDialog();

                    string logMessage = $"Изъят корабль {ship} с места {maskedTextBoxPlace.Text}";
                    ActionLogStorage.InsertNewAction(-1, logMessage, (int)ActionTypeEnum.RemoveShip);
                    logger.Info(logMessage);
                    Draw();
                }
                catch (IndexOutOfRangeException ex)
                {
                    logger.WarnException("Ошибка при изъятии корабляа", ex);
                    MessageBox.Show(ex.Message, "Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.WarnException("Ошибка при изъятии корабля", ex);
                    MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Метод обработки выбора элемента на listBoxLevels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBoxBerhs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
            logger.Info($"Перешли на причал {listBoxBerths.SelectedItem}");
        }

        /// <summary>
        /// Добавление объекта в класс-хранилище
        /// </summary>
        /// <param name="vehicle"></param>
        private void AddToBerth(Vehicle vehicle)
        {
            if (vehicle != null && listBoxBerths.SelectedIndex > -1)
            {
                try
                {
                    if (_berthCollection[listBoxBerths.SelectedItem.ToString()] + vehicle)
                    {
                        Draw();

                        string logMessage = $"Добавлен корабль {vehicle}";
                        ActionLogStorage.InsertNewAction(-1, logMessage, (int)ActionTypeEnum.AddShip);
                        logger.Info(logMessage);
                    }
                    else
                    {
                        MessageBox.Show("Корабль не удалось поставить");
                    }
                }
                catch (OverflowException ex)
                {
                    logger.WarnException("Ошибка при попытке поставить корабль", ex);
                    MessageBox.Show(ex.Message, "Переполнение",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (BerthAlreadyHaveException ex)
                {
                    logger.WarnException("Ошибка при попытке поставить корабль", ex);
                    MessageBox.Show(ex.Message, "Корабль с такими характеристиками уже пришвартован",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.WarnException("Ошибка при попытке поставить корабль", ex);
                    MessageBox.Show(ex.Message, "Неизвестная ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Добавить корабль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddVehicle_Click(object sender, EventArgs e)
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
                try
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
                catch (BerthAlreadyHaveException ex)
                {
                    logger.WarnException("Ошибка при попытке поставить корабль", ex);
                    MessageBox.Show(ex.Message, "Корабль с такими характеристиками уже пришвартован",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                try
                {
                    _berthCollection.SaveDataToFile(saveFileDialog.FileName);
                    MessageBox.Show("Сохранение прошло успешно",
                    "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл " + saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    logger.WarnException("Ошибка при сохранении файла", ex);

                    MessageBox.Show(ex.Message, ex.GetType().Name,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                try
                {
                    _berthCollection.LoadDataFromFile(openFileDialog.FileName);
                    MessageBox.Show("Загрузили", "Результат",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Загружено из файла " + openFileDialog.FileName);
                    ReloadLevels();
                    Draw();
                }
                catch (BerthAlreadyHaveException ex) // TODO: убрать
                {
                    logger.WarnException("Ошибка при загрузке файла", ex);

                    MessageBox.Show("В файле содержатся одинаковые корабли", ex.GetType().Name,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Не загрузили", "Результат",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.WarnException("Ошибка при загрузке файла", ex);

                    MessageBox.Show(ex.Message, ex.GetType().Name,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Не загрузили", "Результат",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Сортировка"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (listBoxBerths.SelectedIndex > -1)
            {
                _berthCollection[listBoxBerths.SelectedItem.ToString()].Sort();
                Draw();
                logger.Info("Сортировка уровней");
            }
        }

        private void показатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReport = new FormReport();
            formReport.Show();
        }

        private void FormBerth_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}