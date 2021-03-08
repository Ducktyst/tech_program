using System;
using System.Drawing;

namespace WindowsFormsTransport
{
    /// <summary>
    /// Параметризованный класс для хранения набора объектов от интерфейса ITransport
    /// </summary>
    public class Berth<T> where T : class, ITransport
    {
        /// <summary>
        /// Места для кораблей
        /// </summary>
        private readonly T[] _places;

        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int _pictureWidth;

        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int _pictureHeight;

        /// <summary>
        /// Размер парковочного места (ширина)
        /// </summary>
        private readonly int _placeSizeWidth = 210;

        /// <summary>
        /// Размер парковочного места (высота)
        /// </summary>
        private readonly int _placeSizeHeight = 80;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="picWidth"></param>
        /// <param name="picHeight"></param>
        public Berth(int picWidth, int picHeight)
        {
            int width = picWidth / _placeSizeWidth;
            int height = picWidth / _placeSizeHeight;
            _places = new T[width * height];
            _pictureWidth = picWidth;
            _pictureHeight = picHeight;
        }

        /// <summary>
        /// Перегрузка оператора сложения
        /// Логика действия: на парковку добавляется автомобиль
        /// </summary>
        /// <param name="p"></param>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public static bool operator +(Berth<T> p, T vehicle)
        {
            bool shipParked = false;
            for (int i = 0; i < p._places.Length; i++)
            {
                Console.WriteLine(i);
                if (p._places[i] == null)
                {
                    // количество мест в вертикальном ряду
                    int colHeight = p._pictureHeight / p._placeSizeHeight;
                    // количество рядов
                    int rowsCount = p._pictureWidth / p._placeSizeWidth;
                    // номер строки (ряда) с транспортом
                    int rowNo = i / colHeight;
                    // номер столбца (ряда) с транспортом
                    int colNo = i - (rowNo * rowsCount);

                    int positionX = colNo * p._placeSizeWidth + p._placeSizeWidth / 5;
                    int positionY = rowNo * p._placeSizeHeight + p._placeSizeHeight / 5;

                    vehicle.SetPosition(positionX, positionY, p._placeSizeWidth, p._placeSizeHeight);
                    p._places[i] = vehicle;
                    shipParked = true;
                    break;
                }
            }
            return shipParked;
        }

        /// <summary>
        /// Перегрузка оператора вычитания
        /// Логика действия: с парковки забираем автомобиль
        /// </summary>
        /// <param name="p">Парковка</param>
        /// <param name="index">Индекс места, с которого пытаемся извлечь объект</param>
        /// <returns></returns>
        public static T operator -(Berth<T> p, int index)
        {
            // Прописать логику для вычитания
            T ship = p._places[index];
            p._places[index] = null;
            return ship;
        }

        /// <summary>
        /// Метод отрисовки причала
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            DrawBerth(g);
            for (int i = 0; i < _places.Length; i++)
            {
                _places[i]?.DrawTransport(g);
            }
        }
        /// <summary>
        /// Метод отрисовки разметки швартовочных мест
        /// </summary>
        /// <param name="g"></param>
        private void DrawBerth(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            
            for (int i = 0; i < _pictureWidth / _placeSizeWidth; i++)
                {
                    for (int j = 0; j < _pictureHeight / _placeSizeHeight + 1; ++j)
                    {
                        //линия рамзетки места
                        g.DrawLine(
                            pen, 
                            i * _placeSizeWidth,
                            j * _placeSizeHeight, 
                            i * _placeSizeWidth + _placeSizeWidth / 2, 
                            j * _placeSizeHeight
                            );
                    }
                    
                    pen.Color = Color.Red;
                    // вертикальная полоса
                    g.DrawLine(
                        pen, 
                        i * _placeSizeWidth,
                        0, 
                        i * _placeSizeWidth, 
                        (_pictureHeight / _placeSizeHeight) * _placeSizeHeight
                        );
                }
            }
    }
}

