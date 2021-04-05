using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTransport.DB.Models
{
    public class Ship
    {
        public int? Id { get; set; }

        public int berthID { get; set; }

        public string ShipType { get; set; }

        public string StringValue{ get; set; }

    }
}
