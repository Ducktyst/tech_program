using System;
using System.Drawing;

namespace Lab1_SportCars
{
    class Cruiser
    {
        /// <summary>
        /// Левая координата отрисовки
        /// </summary>
        private float? _startPosX = null;
        /// <summary>
        /// Верхняя координата отрисовки
        /// </summary>
        private float? _startPosY = null;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int? _pictureWidth = null;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int? _pictureHeight = null;
        /// <summary>
        /// Ширина крейсера
        /// </summary>
        private readonly int cruiserWidth = 100;
        /// <summary>
        /// Высота крейсера
        /// </summary>
        private readonly int cruiserHeight = 50;
        /// <summary>
        /// Максимальная скорость
        /// </summary>
        public int MaxSpeed { private set; get; }
        /// <summary>
        /// Вес
        /// </summary>
        public float Weight { private set; get; }
        /// <summary>
        /// Основной цвет
        /// </summary>
        public Color MainColor { private set; get; }
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }
        /// <summary>
        /// Признак наличия заднего спойлера
        /// </summary>
        public bool BackSpoiler { private set; get; }
        /// <summary>
        /// Призна наличия гоночной линии
        /// </summary>
        public bool SportLine { private set; get; }

        public void Init(int maxSpeed, float weight, Color mainColor, Color dopColor, 
            bool backSpoiler, bool sportLine)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            BackSpoiler = backSpoiler;
            SportLine = sportLine;
        }

        public void SetPosition(int x, int y, int width, int height) 
        {
            if (x < 0 || y < 0 || x + cruiserWidth > width || y + cruiserHeight > height)
            {
                throw new Exception("Элемент выходит за границы окна");
            }

            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }

        /// <summary>
        /// Изменение направления пермещения
        /// </summary>
        /// <param name="direction">Направление</param>
        public void MoveTransport(Direction direction)
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
                    if (_startPosX + cruiserWidth + step < _pictureWidth)
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
                    if (_startPosY + cruiserHeight + step < _pictureHeight)
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
        public void DrawTransport(Graphics g)
        {
            if (!_startPosX.HasValue || !_startPosY.HasValue)
            {
                return;
            }
            Pen pen = new Pen(Color.Black);
            Brush mainBrush = new SolidBrush(MainColor);
            Brush secondBrush = new SolidBrush(Color.Gray);
            Brush blackBrush = new SolidBrush(Color.Black);

            // границы крейсера
            float sideLength = cruiserWidth * 2 / 3;
            Point leftUpper = new Point(Convert.ToInt32(_startPosX.Value), Convert.ToInt32(_startPosY.Value));
            Point leftBottom = new Point(Convert.ToInt32(_startPosX.Value), Convert.ToInt32(_startPosY.Value + cruiserHeight));
            Point upperSideEnd = new Point(Convert.ToInt32(_startPosX.Value + sideLength), Convert.ToInt32(_startPosY.Value));
            Point bottomSideEnd = new Point(Convert.ToInt32(_startPosX.Value + sideLength), Convert.ToInt32(_startPosY.Value + cruiserHeight));         
            g.DrawLine(pen, leftUpper, leftBottom);
            g.DrawLine(pen, leftUpper, upperSideEnd);
            g.DrawLine(pen, leftBottom, bottomSideEnd);

            // нос корабля
            float bowX = _startPosX.Value + cruiserWidth;
            float bowY = _startPosY.Value + cruiserHeight / 2;
            Point bow = new Point(Convert.ToInt32(_startPosX.Value + cruiserWidth), Convert.ToInt32(_startPosY.Value + cruiserHeight / 2));
            g.DrawLine(pen, upperSideEnd, bow);
            g.DrawLine(pen, bottomSideEnd, bow);

            // Заливка корпуса корабля
            Point[] cruiserPoints = new Point[] {leftUpper, upperSideEnd, bow, bottomSideEnd, leftBottom};
            g.FillPolygon(mainBrush, cruiserPoints);

            // люк
            float lukeDiametr = cruiserHeight / 3;
            float lukeX = _startPosX.Value + sideLength - lukeDiametr;
            float lukeY = _startPosY.Value + cruiserHeight / 2 - lukeDiametr / 2;
            g.DrawEllipse(pen, lukeX, lukeY, lukeDiametr, lukeDiametr);
            g.FillEllipse(secondBrush, lukeX, lukeY, lukeDiametr, lukeDiametr);

            // кабина
            // передняя часть кабины
            float chartRoomWidth = sideLength / 8;
            float chartRoomHeight = lukeDiametr * Convert.ToSingle(1.5);
            float chartRoomX = lukeX - chartRoomWidth - lukeDiametr / 4;
            float chartRoomY = _startPosY.Value + cruiserHeight / 2 - chartRoomHeight / 2;
            g.FillRectangle(secondBrush, chartRoomX, chartRoomY, chartRoomWidth, chartRoomHeight);
            g.DrawRectangle(pen, chartRoomX, chartRoomY, chartRoomWidth, chartRoomHeight);
            
            // задняя часть кабины
            float koebrugWidth = chartRoomWidth * Convert.ToSingle(2.5);
            float koebrugHeight = chartRoomHeight * 1 / 2;
            float koebrugX = chartRoomX - koebrugWidth;
            float koebrugY = _startPosY.Value + cruiserHeight / 2 - koebrugHeight / 2;
            g.FillRectangle(secondBrush, koebrugX, koebrugY, koebrugWidth, koebrugHeight);
            g.DrawRectangle(pen, koebrugX, koebrugY, koebrugWidth, koebrugHeight);

            // руль корабля - верхний
            float upperRudderWidth = 5;
            float upperRudderHeight = 7;

            float upperRudderX = _startPosX.Value - upperRudderWidth;
            float upperRudderY = _startPosY.Value + cruiserHeight / 2 - 3 - upperRudderHeight;
            g.FillRectangle(blackBrush, upperRudderX, upperRudderY, upperRudderWidth, upperRudderHeight);
            // руль корабля - нижний
            float lowerRudderX = _startPosX.Value - upperRudderWidth;
            float lowerRudderY = _startPosY.Value + cruiserHeight / 2 + 3;
            g.FillRectangle(blackBrush, lowerRudderX, lowerRudderY, upperRudderWidth, upperRudderHeight);

            // Задний спойлер
            if (BackSpoiler)
            {
                Brush dopBrush = new SolidBrush(DopColor);
                int backSpoilerWidth = 10;
                int backspoilerHeight = cruiserHeight - 10;
                int backSpoilerX = Convert.ToInt32(_startPosX.Value);
                int backSpoilerY = Convert.ToInt32(_startPosY.Value + cruiserHeight/2 - backspoilerHeight/2);
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
                int lowerSportLineY = Convert.ToInt32(_startPosY + cruiserHeight - sportLineHeight);

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
