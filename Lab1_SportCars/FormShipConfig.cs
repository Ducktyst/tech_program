using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsTransport
{
    public partial class FormShipConfig : Form
    {
        /// <summary>
        /// Переменная-выбранный корабль
        /// </summary>
        Vehicle _ship = null;

        /// <summary>
        /// Событие
        /// </summary>
        private event ShipDelegate EventAddShip;
        public FormShipConfig()
        {
            InitializeComponent();
            // Привязать PanelColor_MouseDown к панелям с цветами
            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
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
        /// Добавление события
        /// </summary>
        /// <param name="ev"></param>
        public void AddEvent(ShipDelegate ev)
        {
            if (EventAddShip == null)
            {
                EventAddShip = new ShipDelegate(ev);
            }
            else
            {
                EventAddShip += ev;
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

        /// <summary>
        /// Отправляем цвет с панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelColor_MouseDown(object sender, MouseEventArgs e)
        {
            // Прописать логику вызова dragDrop для панелей, используя sender
        }
        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelBaseColor_DragEnter(object sender, DragEventArgs e)
        {
            // Прописать логику проверки приходящего значения на тип Color
        }
        /// <summary>
        /// Принимаем основной цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelBaseColor_DragDrop(object sender, DragEventArgs e)
        {
            // Прописать логику смены базового цвета
        }
        /// <summary>
        /// Принимаем дополнительный цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelDopColor_DragDrop(object sender, DragEventArgs e)
        {
            // Прописать логику смены дополнительного цвета, если объект
            // является объектом дочернего класса
        }

        /// <summary>
        /// Добавление корабля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOk_Click(object sender, EventArgs e)
        {
            EventAddShip?.Invoke(_ship);
            Close();
        }
    }

    /*
     * Остановился на 92 странице
     * 
     * Пропустил чтение текста про LabelBaseColor_DragEnter и другие методы
     */
}
