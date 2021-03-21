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
            (sender as Label).DoDragDrop((sender as Label).Name, DragDropEffects.Move | DragDropEffects.Copy);
        }

        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelShip_DragEnter(object sender, DragEventArgs e)
        {
            Console.WriteLine("PanelShip_DragEnter", e.Data.GetDataPresent(DataFormats.Text));

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
            (sender as Panel).DoDragDrop((sender as Panel).BackColor, DragDropEffects.Move | DragDropEffects.Copy);
         }
        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelColor_DragEnter(object sender, DragEventArgs e)
        {
                Color color = (Color)e.Data.GetData(e.Data.GetFormats()[0]);

            if (color != null)
            {
                Console.WriteLine(color != null);
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// Принимаем основной цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelBaseColor_DragDrop(object sender, DragEventArgs e)
        {
            Color color = (Color)e.Data.GetData(typeof(Color));

            if (color != null)
            {
                _ship.SetMainColor(color);
                DrawShip();
            }
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
            if (_ship.GetType() != typeof(Cruiser))
            {
                return;
            }

            Color color = (Color)e.Data.GetData(typeof(Color));
            if (color != null)
            {
                _ship.SetDopColor(color);
                DrawShip();
            }
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
}
