using System;
using System.Drawing;

namespace WindowsFormsTransport
{
    public abstract class Vehicle : ITransport
    {
        /// <summary>
        /// Левая координата отрисовки автомобиля
        /// </summary>
        protected float? _startPosX = null;
        /// <summary>
        /// Правая кооридната отрисовки автомобиля
        /// </summary>
        protected float? _startPosY = null;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        protected int? _pictureWidth = null;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        protected int? _pictureHeight = null;
        /// <summary>
        /// Максимальная скорость
        /// </summary>
        public int MaxSpeed { protected set; get; }
        /// <summary>
        /// Вес автомобиля
        /// </summary>
        public float Weight { protected set; get; }
        /// <summary>
        /// Основной цвет кузова
        /// </summary>
        public Color MainColor { protected set; get; }
        public void SetPosition(int x, int y, int width, int height)
        {
            if (x < 0 || y < 0 || x + width > _pictureHeight || y + height > _pictureWidth)
            {
                throw new Exception("Элемент выходит за границы окна");
            }

            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }
        public abstract void DrawTransport(Graphics g);
        public abstract void MoveTransport(Direction direction);
    }
}
