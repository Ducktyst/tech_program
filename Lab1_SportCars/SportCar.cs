using Lab1_SportCars;
using System;
using System.Drawing;

namespace Lab1SportCars
{
    

    /// <summary>
    /// Класс отрисовки крейсера
    /// </summary>
    class SportCar
    {
        /// <summary>
        /// Левая координата отрисовки
        /// </summary>
        private float? _startPosX = null;
        /// <summary>
        /// Правая координата отрисовки
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
        /// Ширина отрисовки автомобиля
        /// </summary>
        private readonly int _carWidth = 100;
        /// <summary>
        /// Высота отрисоки автомобиля
        /// </summary>
        private readonly int _carHeight = 100;
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
        /// Признак наличия спойлера
        /// </summary>
        public bool FrontSpoiler { private set; get; }
        /// <summary>
        /// Признак наличия боковых спойлеров
        /// </summary>
        public bool SideSpoiler { private set; get; }
        /// <summary>
        /// Признак наличия заднего спойлера
        /// </summary>
        public bool BackSpoiler { private set; get; }
        /// <summary>
        /// Призна наличия гоночной линии
        /// </summary>
        public bool SportLine { private set; get; }

        public void Init(int maxSpeed, float weight, Color mainColor, Color dopColor,
            bool frontSpoiler, bool sideSpoiler, bool backSpoiler, bool sportLine)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            FrontSpoiler = frontSpoiler;
            SideSpoiler = sideSpoiler;
            BackSpoiler = backSpoiler;
            SportLine = sportLine;
        }

        /// <summary>
        /// Установка позиции автомобиля
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        public void SetPosition(int x, int y, int width, int height)
        {
            if (x < 0 || y < 0 || x + _carWidth > width || y + _carHeight > height)
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
                    if (_startPosX + step < _pictureWidth - _carWidth)
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
                    if (_startPosY + step < _pictureHeight - _carHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }

        /// <summary>
        /// Отрисовка автомобиля
        /// </summary>
        /// <param name="g"></param>
        public void DrawTransport(Graphics g)
        {
            if (!_startPosX.HasValue || !_startPosY.HasValue)
            {
                return;
            }
            Pen pen = new Pen(Color.Black);
            // отрисуем сперва передний спойлер автомобиля (чтобы потом
            //отрисовка автомобиля на него "легла")
            if (FrontSpoiler)
            {
                g.DrawEllipse(pen, _startPosX.Value + 80, _startPosY.Value
                - 6, 20, 20);
                g.DrawEllipse(pen, _startPosX.Value + 80, _startPosY.Value
                + 35, 20, 20);
                g.DrawEllipse(pen, _startPosX.Value - 5, _startPosY.Value -
                6, 20, 20);
                g.DrawEllipse(pen, _startPosX.Value - 5, _startPosY.Value +
                35, 20, 20);
                g.DrawRectangle(pen, _startPosX.Value + 80,
                _startPosY.Value - 6, 15, 15);
                g.DrawRectangle(pen, _startPosX.Value + 80,
                _startPosY.Value + 40, 15, 15);
                g.DrawRectangle(pen, _startPosX.Value, _startPosY.Value -
                6, 14, 15);
                g.DrawRectangle(pen, _startPosX.Value, _startPosY.Value +
                40, 14, 15);
                Brush spoiler = new SolidBrush(DopColor);
                g.FillEllipse(spoiler, _startPosX.Value + 80,
                _startPosY.Value - 5, 20, 20);
                g.FillEllipse(spoiler, _startPosX.Value + 80,
                _startPosY.Value + 35, 20, 20);
                g.FillRectangle(spoiler, _startPosX.Value + 75,
                _startPosY.Value, 25, 40);
                g.FillRectangle(spoiler, _startPosX.Value + 80,
                _startPosY.Value - 5, 15, 15);
                g.FillRectangle(spoiler, _startPosX.Value + 80,
                _startPosY.Value + 40, 15, 15);
                g.FillEllipse(spoiler, _startPosX.Value - 5,
                _startPosY.Value - 5, 20, 20);
                g.FillEllipse(spoiler, _startPosX.Value - 5,
                _startPosY.Value + 35, 20, 20);
                g.FillRectangle(spoiler, _startPosX.Value - 5,
                _startPosY.Value, 25, 40);

                g.FillRectangle(spoiler, _startPosX.Value, _startPosY.Value
    - 5, 15, 15);
                g.FillRectangle(spoiler, _startPosX.Value, _startPosY.Value
                + 40, 15, 15);
            }
            // и боковые
            if (SideSpoiler)
            {
                g.DrawRectangle(pen, _startPosX.Value + 25,
                _startPosY.Value - 6, 39, 10);
                g.DrawRectangle(pen, _startPosX.Value + 25,
                _startPosY.Value + 45, 39, 10);
                Brush spoiler = new SolidBrush(DopColor);
                g.FillRectangle(spoiler, _startPosX.Value + 25,
                _startPosY.Value - 5, 40, 10);
                g.FillRectangle(spoiler, _startPosX.Value + 25,
                _startPosY.Value + 45, 40, 10);
            }
            // теперь отрисуем основной кузов автомобиля
            //границы автомобиля
            g.DrawEllipse(pen, _startPosX.Value, _startPosY.Value, 20, 20);
            g.DrawEllipse(pen, _startPosX.Value, _startPosY.Value + 30, 20,
            20);
            g.DrawEllipse(pen, _startPosX.Value + 70, _startPosY.Value, 20,
            20);
            g.DrawEllipse(pen, _startPosX.Value + 70, _startPosY.Value + 30,
            20, 20);
            g.DrawRectangle(pen, _startPosX.Value - 1, _startPosY.Value + 10,
            10, 30);
            g.DrawRectangle(pen, _startPosX.Value + 80, _startPosY.Value + 10,
            10, 30);
            g.DrawRectangle(pen, _startPosX.Value + 10, _startPosY.Value - 1,
            70, 52);
            //задние фары
            Brush brRed = new SolidBrush(Color.Red);
            g.FillEllipse(brRed, _startPosX.Value, _startPosY.Value, 20, 20);
            g.FillEllipse(brRed, _startPosX.Value, _startPosY.Value + 30, 20,
            20);
            //передние фары
            Brush brYellow = new SolidBrush(Color.Yellow);
            g.FillEllipse(brYellow, _startPosX.Value + 70, _startPosY.Value,
            20, 20);
            g.FillEllipse(brYellow, _startPosX.Value + 70, _startPosY.Value +
            30, 20, 20);
            //кузов
            Brush br = new SolidBrush(MainColor);
            g.FillRectangle(br, _startPosX.Value, _startPosY.Value + 10, 10,
            30);
            g.FillRectangle(br, _startPosX.Value + 80, _startPosY.Value + 10,
            10, 30);
            g.FillRectangle(br, _startPosX.Value + 10, _startPosY.Value, 70,
            50);
            //стекла
            Brush brBlue = new SolidBrush(Color.LightBlue);
            g.FillRectangle(brBlue, _startPosX.Value + 60, _startPosY.Value +
            5, 5, 40);

            g.FillRectangle(brBlue, _startPosX.Value + 20, _startPosY.Value +
        5, 5, 40);
            g.FillRectangle(brBlue, _startPosX.Value + 25, _startPosY.Value +
            3, 35, 2);
            g.FillRectangle(brBlue, _startPosX.Value + 25, _startPosY.Value +
            46, 35, 2);
            //выделяем рамкой крышу
            g.DrawRectangle(pen, _startPosX.Value + 25, _startPosY.Value + 5,
            35, 40);
            g.DrawRectangle(pen, _startPosX.Value + 65, _startPosY.Value + 10,
            25, 30);
            g.DrawRectangle(pen, _startPosX.Value, _startPosY.Value + 10, 15,
            30);
            // рисуем гоночные полоски
            if (SportLine)
            {
                br = new SolidBrush(DopColor);
                g.FillRectangle(br, _startPosX.Value + 65, _startPosY.Value
                + 18, 25, 15);
                g.FillRectangle(br, _startPosX.Value + 25, _startPosY.Value
                + 18, 35, 15);
                g.FillRectangle(br, _startPosX.Value, _startPosY.Value +
                18, 20, 15);
            }
            // рисуем задний спойлер автомобиля
            if (BackSpoiler)
            {
                Brush spoiler = new SolidBrush(DopColor);
                g.FillRectangle(spoiler, _startPosX.Value - 5,
                _startPosY.Value, 10, 50);
                g.DrawRectangle(pen, _startPosX.Value - 5,
                _startPosY.Value, 10, 50);
            }
        }
    }
}
