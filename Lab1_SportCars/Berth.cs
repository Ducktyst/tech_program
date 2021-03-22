using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
        private readonly List<T> _places;

        /// <summary>
        /// Максимальное количество мест на пристани
        /// </summary>
        private readonly int _maxCount;

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
        /// <param name="picWidth">Рамзер причала - ширина</param>
        /// <param name="picHeight">Рамзер причала - высота</param>
        public Berth(int picWidth, int picHeight)
        {
            int width = picWidth / _placeSizeWidth;
            int height = picHeight / _placeSizeHeight;
            _maxCount = width * height;
            _places = new List<T>();
            _pictureWidth = picWidth;
            _pictureHeight = picHeight;
            //lastPlaceIndex = _maxCount -1;
        }

        /// <summary>
        /// Перегрузка оператора сложения
        /// Логика действия: на причал добавляется корабль
        /// </summary>
        /// <param name="p">Причал</param>
        /// <param name="vehicle">Добавляемый корабль</param>
        /// <returns></returns>
        public static bool operator +(Berth<T> p, T vehicle)
        {
            if (p._places.Count >= p._maxCount)
            {
                return false;
            }

            p._places.Add(vehicle);
            return true;
        }

        /// <summary>
        /// Перегрузка оператора вычитания
        /// Логика действия: с причала забираем корабль
        /// </summary>
        /// <param name="p">Парковка</param>
        /// <param name="index">Индекс места, с которого пытаемся извлечь объект</param>
        /// <returns></returns>
        public static T operator -(Berth<T> p, int index)
        {
            if (index < 0 || index >= p._places.Count)
            {
                return null;
            }

            T ship = p._places[index];
            p._places.RemoveAt(index);
            return ship;
        }

        /// <summary>
        /// Метод отрисовки причала
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            DrawBerth(g);
            for (int i = 0; i < _places.Count; i++)
            {
                if (_places[i] == null)
                {
                    continue;
                }
                int colsCount = _pictureWidth / _placeSizeWidth;
                int colHeight = _pictureHeight / _placeSizeHeight; // кол-во мест в столбце
                int vehicleX = 15 + i / colHeight * _placeSizeWidth;
                int vehicleY = 10 + i % colHeight * _placeSizeHeight;
                if (vehicleX < 0 || vehicleY < 0 || vehicleX + _placeSizeWidth > _pictureWidth || vehicleY + _placeSizeHeight > _pictureHeight)
                {
                    throw new Exception("Элемент выходит за границы окна");
                }

                _places[i].SetPosition(vehicleX, vehicleY, _pictureWidth, _pictureHeight);
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
                        j * _placeSizeHeight);
                }

                // вертикальная полоса
                g.DrawLine(
                    pen,
                    i * _placeSizeWidth,
                    0,
                    i * _placeSizeWidth,
                    (_pictureHeight / _placeSizeHeight) * _placeSizeHeight);
            }
        }

        /// <summary>
        /// Функция получения элементов из списка
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetNext()
        {
            foreach (var elem in _places)
            {
                yield return elem;
            }
        }
    }
}

