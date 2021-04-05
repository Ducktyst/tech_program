using System;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WindowsFormsTransport
{
    public abstract class Vehicle : ITransport
    {
        /// <summary>
        /// Левая координата отрисовки 
        /// </summary>
        protected float? _startPosX = null;
        
        /// <summary>
        /// Правая кооридната отрисовки 
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


        public int Id { get; set; }

        /// <summary>
        /// Максимальная скорость
        /// </summary>
        [Required]

        public int MaxSpeed { set; get; }
        
        /// <summary>
        /// Вес
        /// </summary>
        [Required]
        public float Weight { set; get; }

        /// <summary>
        /// Основной цвет кузова
        /// </summary>
        [Required]
        public Color MainColor { protected set; get; }

        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }
        public abstract void DrawTransport(Graphics g);
        public abstract void MoveTransport(Direction direction);

        public void SetMainColor(Color color) => MainColor = color;

        public void SetMaxSpeed(int maxSpeed) => MaxSpeed = maxSpeed;

        public void SetWeight(int weight) => Weight = weight;

        virtual public void SetDopColor(Color color) {}
    }
}
