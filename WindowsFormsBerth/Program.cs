using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsTransport;
using WindowsFormsTransport.DB;
using WindowsFormsTransport.DB.Models;

namespace WindowsFormsBerth
{
    public static class Program
    {
        public delegate void ShipDelegate(Vehicle ship);
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {

            using (var db = new TransportDatabase())
            {
                db.Berths.Add(new Berth { Name = "Причал 1" });
                db.Berths.Add(new Berth { Name = "Причал 2" });
                db.Berths.Add(new Berth { Name = "Причал 3" });
                db.Berths.Add(new Berth { Name = "Причал 4" });
                db.Berths.Add(new Berth { Name = "Причал 5" });

                db.SaveChanges();

                foreach (var b in db.Berths)
                {
                    Console.WriteLine(b.Name);
                }
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormBerth());
        }
    }
}
