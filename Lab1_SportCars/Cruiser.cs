using System;
using System.Drawing;

namespace WindowsFormsTransport
{
    public class Cruiser : WarShip
    {
        public Color DopColor { private set; get; }

        public bool IsWithGuns { private set; get; }
        /// <summary>
        /// Признак наличия вертолетной площадки
        /// </summary>
        public bool IsWithHelicopter { private set; get; }


        public Cruiser(int maxSpeed, float weight, Color mainColor, Color dopColor, bool isWithGuns, bool isWithHrlicopter) : base(maxSpeed, weight, mainColor, 100, 60)
        {
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
            base(maxSpeed, weight, mainColor, shipWidth, shipHeight)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }

        /// <summary>
        /// Конструктор для загрузки с файла
        /// </summary>
        /// <param name="info"></param>
        public Cruiser(string info) : base(info)
        {
            string[] strs = info.Split(_separator);
            if (strs.Length == 6)
            {
                DopColor = Color.FromName(strs[3]);
                IsWithGuns = Convert.ToBoolean(strs[4]);
                IsWithHelicopter = Convert.ToBoolean(strs[5]);
            } else
            {
                // throw new Exception("Неверное количество записей для создания Cruiser");
            }
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
                int gunY = Convert.ToInt32(_startPosY) + Convert.ToInt32(_shipHeight / 2) - gunHeight / 2;

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
                float fontSize = 14.0F;
                float textX = helicopterX + (helicopterDiameter - fontSize) / 3;
                float textY = helicopterX + (helicopterDiameter - fontSize) / 2;
                g.DrawString("H", new Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Bold), blackBrush, textX, textY);
            }

        }

        /// <summary>
        /// Смена дополнительного цвета
        /// </summary>
        /// <param name="color"></param>
        override public void SetDopColor(Color color) => DopColor = color;

        public override string ToString() => $"{base.ToString()}{_separator}{DopColor.Name}{_separator}{IsWithGuns}{_separator}{IsWithHelicopter}";
    }
}
