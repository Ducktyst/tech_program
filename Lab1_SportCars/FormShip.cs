using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsTransport
{
    public partial class FormShip : Form
    {

        private ITransport _ship;
        public FormShip()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод отрисовки т/с
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics gr = Graphics.FromImage(bmp);
            _ship?.DrawTransport(gr);
            pictureBox.Image = bmp;
        }

        /// <summary>
        /// Создание объекта
        /// </summary>
        /// <param name="isBase">true - создаем объект базового класса, false - дочернего</param>
        private void CreateShip(bool isBase)
        {
            Random rnd = new Random();
            _ship = isBase ? new WarShip(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue) 
                : new Cruiser(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue, Color.Yellow, true, true);
            _ship.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBox.Width, pictureBox.Height);
            Draw();
        }

        /// <summary>
        /// Обработка нажатия кнопки "Создать корабль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateBaseCruiser_Click(object sender, EventArgs e) => CreateShip(true);


        /// <summary>
        /// Обработка нажатия кнопки "Создать крейсер"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateCruiser_Click(object sender, EventArgs e) => CreateShip(false);

        /// <summary>
        /// Обработка нажатия кнопок управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMove_Click(object sender, EventArgs e)
        {
            // получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    _ship?.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    _ship?.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    _ship?.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    _ship?.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
