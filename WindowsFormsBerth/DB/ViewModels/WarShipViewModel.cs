using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTransport.DB.ViewModels
{
    class WarShipViewModel
    {
        public int Id { protected get; set; }

        /// <summary>
        /// Максимальная скорость
        /// </summary>
        [Required]
        public int MaxSpeed { protected set; get; }

        /// <summary>
        /// Вес 
        /// </summary>
        [Required]
        public float Weight { protected set; get; }

        /// <summary>
        /// Основной цвет кузова
        /// </summary>
        [Required]
        public string MainColor { protected set; get; }

/*        /// <summary>
        /// Принадлежность к причалу
        /// </summary>
        [Required]
        public bool? BerthId { protected set; get; }*/
    }
}
