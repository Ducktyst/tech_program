using Lab1SportCars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_SportCars
{
    public partial class FormCar : Form
    {

        private SportCar _car;
        public FormCar()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод отрисовки т/с
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxCars.Width, pictureBoxCars.Height);
            Graphics gr = Graphics.FromImage(bmp);
            _car?.DrawTransport(gr);
            pictureBoxCars.Image = bmp;
        }


        /// <summary>
        /// Обработка нажатия кнопки "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            _car = new SportCar();
            bool sportLine = false;
            if (rnd.Next(2) % 2 == 0) {
                sportLine = true;
            }
            _car.Init(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue, Color.Yellow, sportLine, true, true, true);
            _car.SetPosition(rnd.Next(10, 100), rnd.Next(100, 200), pictureBoxCars.Width, pictureBoxCars.Height);
            Draw();
        }

        /// <summary>
        /// Обработка нажатия кнопок управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    _car?.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    _car?.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    _car?.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    _car?.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
