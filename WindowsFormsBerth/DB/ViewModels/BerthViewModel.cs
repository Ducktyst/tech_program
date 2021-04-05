using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTransport.DB.ViewModels
{
    public class BerthViewModel
    {
        public int? Id { get; set; }

        /// <summary>
        /// Название причала
        /// </summary>
        [Required]
        public string Name{ set; get; }

        /// <summary>
        /// Количество мест
        /// </summary>
        [Required]
        public int MaxPlaces { set; get; }

    }
}
