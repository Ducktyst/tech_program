using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTransport
{
    public class Cruiser : WarShip
    {
        public Color DopColor { private set; get; }
        /// <summary>
        /// Признак наличия заднего спойлера
        /// </summary>
        public bool BackSpoiler { private set; get; }
        /// <summary>
        /// Признак наличия гоночной линии
        /// </summary>
        public bool SportLine { private set; get; }
        /// <summary>
        /// Признак наличия пушки
        /// </summary>
        public bool IsWithGuns { private set; get; }
        /// <summary>
        /// Признак наличия вертолетной площадки
        /// </summary>
        public bool IsWithHelicopter { private set; get; }


        public Cruiser(int maxSpeed, float weight, Color mainColor, Color dopColor, bool isWithGuns, bool isWithHrlicopter) : base(maxSpeed, weight, mainColor, 100, 60)
        {

            // Для крейсера добавить вертолетную прощадку и пушки
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            IsWithGuns = isWithGuns;
            IsWithHelicopter = isWithHrlicopter;
        }

        /// <summary>
        /// Конструктор с изменением размеров
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес корабля</param>
        /// <param name="mainColor">Основной цвет</param>
        /// <param name="shipWidth">Ширина отрисовки корабля</param>
        /// <param name="shipHeight">Высота отрисовки корабля</param>
        protected Cruiser(int maxSpeed, float weight, Color mainColor, int shipWidth, int shipHeight) : 
            base (maxSpeed, weight, mainColor, shipWidth, shipHeight)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
         }

        /// <summary>
        /// Изменение направления пермещения
        /// </summary>
        /// <param name="direction">Направление</param>
        public override void MoveTransport(Direction direction)
        {
            if (!_pictureWidth.HasValue || !_pictureHeight.HasValue)
            {
                return;
            }
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + _shipWidth + step < _pictureWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + _shipHeight + step < _pictureHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }

        /// <summary>
        /// Отрисовка крейсера
        /// </summary>
        /// <param name="g"></param>
        public override void DrawTransport(Graphics g)
        {
            base.DrawTransport(g);
            Pen pen = new Pen(Color.Black);


            // Орудия
            if (IsWithGuns)
            {
                Brush dopBrush = new SolidBrush(DopColor);
                int gunLength = 20;
                int gunHeight = 4;
                int gunX = Convert.ToInt32(_startPosX) + Convert.ToInt32(_shipWidth / 2);
                int gunY = Convert.ToInt32(_startPosY) + Convert.ToInt32(_shipHeight / 2) - gunHeight/2;

                g.FillRectangle(dopBrush, gunX, gunY, gunLength, gunHeight);
                g.DrawRectangle(pen, gunX, gunY, gunLength, gunHeight);
            }

            if (IsWithHelicopter)
            {
                Brush dopBrush = new SolidBrush(DopColor);
                int helicopterDiameter = 30;

                float helicopterX = Convert.ToInt32(_startPosX) + 10;
                float helicopterY = Convert.ToInt32(_startPosY) + _shipHeight / 2 - helicopterDiameter / 2;
                g.FillEllipse(dopBrush, helicopterX, helicopterY, helicopterDiameter, helicopterDiameter);
                g.DrawRectangle(pen, helicopterX, helicopterY, helicopterDiameter, helicopterDiameter);

                Brush blackBrush = new SolidBrush(Color.Black);
                g.DrawString("H", new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Bold), blackBrush, helicopterX, helicopterY);
            }

        }
    }
}
