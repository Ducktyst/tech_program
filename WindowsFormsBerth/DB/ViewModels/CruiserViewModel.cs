using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTransport.DB.ViewModels
{
    class CruiserViewModel
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

        [Required]
        public string DopColor { protected set; get; }

        [Required]
        public bool IsWithGuns { protected set; get; }
        
        /// <summary>
        /// Признак наличия вертолетной площадки
        /// </summary>
        [Required]
        public bool IsWithHelicopter { protected set; get; }

        /*/// <summary>
        /// Принадлежность к причалу
        /// </summary>
        [Required]
        public bool? BerthId { protected set; get; }*/

    }
}
