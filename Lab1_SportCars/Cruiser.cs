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
        /// Призна наличия гоночной линии
        /// </summary>
        public bool SportLine { private set; get; }

        public Cruiser(int maxSpeed, float weight, Color mainColor, Color dopColor, bool backSpoiler, bool sportLine) : base(maxSpeed, weight, mainColor, 100, 60)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            BackSpoiler = backSpoiler;
            SportLine = sportLine;
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

            // Задний спойлер
            if (BackSpoiler)
            {
                Brush dopBrush = new SolidBrush(DopColor);
                int backSpoilerWidth = 10;
                int backspoilerHeight = _shipHeight - 10;
                int backSpoilerX = Convert.ToInt32(_startPosX.Value);
                int backSpoilerY = Convert.ToInt32(_startPosY.Value + _shipHeight / 2 - backspoilerHeight / 2);
                Point backSpoilerLeftUpper = new Point(backSpoilerX, backSpoilerY);
                Point backSpoilerRightBottom = new Point(backSpoilerX + backSpoilerWidth, backSpoilerY + backspoilerHeight);

                Rectangle backSpoiler = new Rectangle(backSpoilerX, backSpoilerY, backSpoilerWidth, backspoilerHeight);
                g.FillRectangle(dopBrush, backSpoiler);
                g.DrawRectangle(pen, backSpoiler);
            }

            // Спортивные полосы
            if (SportLine)
            {
                Brush dopBrush = new SolidBrush(DopColor);
                int sportLineWidth = Convert.ToInt32(sideLength - 20);
                int sportLineHeight = 6;

                int sportLineX = Convert.ToInt32(_startPosX + 15);

                int upperSportLineY = Convert.ToInt32(_startPosY);
                int lowerSportLineY = Convert.ToInt32(_startPosY + _shipHeight - sportLineHeight);

                Point upperSportLineStart = new Point(sportLineX, upperSportLineY);
                Point upperSportLineEnd = new Point(sportLineX + sportLineWidth, upperSportLineY + sportLineHeight);
                Rectangle upperSpoiler = new Rectangle(upperSportLineStart, new Size(sportLineWidth, sportLineHeight));

                Point lowerSportLineStart = new Point(sportLineX, lowerSportLineY);
                Point lowerSportLineEnd = new Point(sportLineX + sportLineWidth, lowerSportLineY + sportLineHeight);
                Rectangle lowerSpoiler = new Rectangle(lowerSportLineStart, new Size(sportLineWidth, sportLineHeight));

                g.FillRectangle(dopBrush, upperSpoiler);
                g.DrawRectangle(pen, upperSpoiler);

                g.FillRectangle(dopBrush, lowerSpoiler);
                g.DrawRectangle(pen, lowerSpoiler);
            }
        }
    }
}
