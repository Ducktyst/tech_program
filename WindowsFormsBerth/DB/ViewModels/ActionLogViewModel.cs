using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTransport.DB.ViewModels
{
    class ActionLogViewModel
    {
        public int Id { get; set; }

        public int BerthId { get; set; }

        public string ActionType { get; set; } // TODO: Перенесети action в отдельную таблицу и ссылкаться через ForeignKey

        public string ActionDescription { get; set; }

        public DateTime ActionTime { get; set; }
    }
}
