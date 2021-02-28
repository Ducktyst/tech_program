using System;
using System.Drawing;


namespace WindowsFormsTransport

{
    public class WarShip : Vehicle
    {
        /// <summary>
        /// Ширина отрисовки 
        /// </summary>
        protected readonly int _shipWidth = 90;
        /// <summary>
        /// Высота отрисовки 
        /// </summary>
        protected readonly int _shipHeight = 50;

        /// <summary>
        /// Длина границы корабля
        /// </summary>
        protected float sideLength;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес</param>
        /// <param name="mainColor">Основной цвет</param>
        public WarShip(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }


        /// <summary>
        /// Конструктор с изменением размеров
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="shipWidth">Ширина отрисовки автомобиля</param>
        /// <param name="shipHeight">Высота отрисовки автомобиля</param>
        protected WarShip(int maxSpeed, float weight, Color mainColor, int shipWidth, int shipHeight)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            _shipWidth = shipWidth;
            _shipHeight = shipHeight;
        }
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
        public override void DrawTransport(Graphics g)
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
            sideLength = _shipWidth * 2 / 3;
            Point leftUpper = new Point(Convert.ToInt32(_startPosX.Value), Convert.ToInt32(_startPosY.Value));
            Point leftBottom = new Point(Convert.ToInt32(_startPosX.Value), Convert.ToInt32(_startPosY.Value + _shipHeight));
            Point upperSideEnd = new Point(Convert.ToInt32(_startPosX.Value + sideLength), Convert.ToInt32(_startPosY.Value));
            Point bottomSideEnd = new Point(Convert.ToInt32(_startPosX.Value + sideLength), Convert.ToInt32(_startPosY.Value + _shipHeight));
            g.DrawLine(pen, leftUpper, leftBottom);
            g.DrawLine(pen, leftUpper, upperSideEnd);
            g.DrawLine(pen, leftBottom, bottomSideEnd);

            // нос корабля
            float bowX = _startPosX.Value + _shipWidth;
            float bowY = _startPosY.Value + _shipHeight / 2;
            Point bow = new Point(Convert.ToInt32(_startPosX.Value + _shipWidth), Convert.ToInt32(_startPosY.Value + _shipHeight / 2));
            g.DrawLine(pen, upperSideEnd, bow);
            g.DrawLine(pen, bottomSideEnd, bow);

            // Заливка корпуса корабля
            Point[] cruiserPoints = new Point[] { leftUpper, upperSideEnd, bow, bottomSideEnd, leftBottom };
            g.FillPolygon(mainBrush, cruiserPoints);

            // люк
            float lukeDiametr = _shipHeight / 3;
            float lukeX = _startPosX.Value + sideLength - lukeDiametr;
            float lukeY = _startPosY.Value + _shipHeight / 2 - lukeDiametr / 2;
            g.DrawEllipse(pen, lukeX, lukeY, lukeDiametr, lukeDiametr);
            g.FillEllipse(secondBrush, lukeX, lukeY, lukeDiametr, lukeDiametr);

            // кабина
            // передняя часть кабины
            float chartRoomWidth = sideLength / 8;
            float chartRoomHeight = lukeDiametr * Convert.ToSingle(1.5);
            float chartRoomX = lukeX - chartRoomWidth - lukeDiametr / 4;
            float chartRoomY = _startPosY.Value + _shipHeight / 2 - chartRoomHeight / 2;
            g.FillRectangle(secondBrush, chartRoomX, chartRoomY, chartRoomWidth, chartRoomHeight);
            g.DrawRectangle(pen, chartRoomX, chartRoomY, chartRoomWidth, chartRoomHeight);

            // задняя часть кабины
            float koebrugWidth = chartRoomWidth * Convert.ToSingle(2.5);
            float koebrugHeight = chartRoomHeight * 1 / 2;
            float koebrugX = chartRoomX - koebrugWidth;
            float koebrugY = _startPosY.Value + _shipHeight / 2 - koebrugHeight / 2;
            g.FillRectangle(secondBrush, koebrugX, koebrugY, koebrugWidth, koebrugHeight);
            g.DrawRectangle(pen, koebrugX, koebrugY, koebrugWidth, koebrugHeight);

            // руль корабля - верхний
            float upperRudderWidth = 5;
            float upperRudderHeight = 7;

            float upperRudderX = _startPosX.Value - upperRudderWidth;
            float upperRudderY = _startPosY.Value + _shipHeight / 2 - 3 - upperRudderHeight;
            g.FillRectangle(blackBrush, upperRudderX, upperRudderY, upperRudderWidth, upperRudderHeight);
            // руль корабля - нижний
            float lowerRudderX = _startPosX.Value - upperRudderWidth;
            float lowerRudderY = _startPosY.Value + _shipHeight / 2 + 3;
            g.FillRectangle(blackBrush, lowerRudderX, lowerRudderY, upperRudderWidth, upperRudderHeight);
        }
    }
}