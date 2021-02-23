using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1_SportCars
{
    public partial class CruiserForm : Form
    {
        private Cruiser _cruiser;
       
        public CruiserForm()
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
            _cruiser?.DrawTransport(gr);
            pictureBox.Image = bmp;
        }

        /// <summary>
        /// Создание нового крейсера 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonСreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            _cruiser = new Cruiser();

            _cruiser.Init(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue, Color.Yellow, true, true);
            _cruiser.SetPosition(rnd.Next(10, 100), rnd.Next(100, 200), pictureBox.Width, pictureBox.Height);
            Draw();
        }

        /// <summary>
        /// Перемещение крейсера в заданном направлении
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
                    _cruiser?.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    _cruiser?.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    _cruiser?.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    _cruiser?.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
