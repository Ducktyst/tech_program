using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsTransport.DB.Models;

namespace WindowsFormsTransport.DB
{
    class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<ActionLog> ActionLog { get; set; }

        private DataListSingleton()
        {
            ActionLog = new List<ActionLog>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
