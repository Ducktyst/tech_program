using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTransport.DB.Models
{
    public class Berth
    {
        public int? Id { get; set; }

        /// <summary>
        /// Название причала
        /// </summary>
        [Required]
        public string Name{ get; set; }

        /// <summary>
        /// Количество мест
        /// </summary>
        [Required]
        public int MaxPlaces { get; set; }

        public List<Cruiser> Cruisers;

    }
}
