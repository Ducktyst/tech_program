using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTransport
{
    class ShipComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException("Один из объектов null");
            }
            if (x.GetType() != y.GetType())
            {
                // Военный корабль меньше чем крейсер
                if (x.GetType() == typeof(WarShip) && y.GetType() == typeof(Cruiser))
                {
                    return -1;
                } else if (x.GetType() == typeof(Cruiser) && y.GetType() == typeof(WarShip)) {
                    return 1;
                } else
                {
                    return 0;
                }
            }

            if (x.GetType() == typeof(Cruiser))
            {
                return CompareCruiser((Cruiser)x, (Cruiser)y);
            }
            else if (x.GetType() == typeof(WarShip))
            {
                return ComparerWarShip((WarShip)x, (WarShip)y);
            }
            throw new Exception("Неизвестная ошибка");
        }
        private int ComparerWarShip(WarShip x, WarShip y)
        {
            var xPower = x.MaxSpeed / x.Weight;
            var yPower = y.MaxSpeed / y.Weight;
            if (xPower < yPower)
            {
                return -1;
            } else if (xPower > yPower)
            {
                return 1;
            } else
            {
                return 0;
            }
        }
        private int CompareCruiser(Cruiser x, Cruiser y)
        {
            // логика сравнения WarShip
            var xPower = x.MaxSpeed / x.Weight;
            var yPower = y.MaxSpeed / y.Weight;
            if (xPower < yPower)
            {
                return -1;
            }
            else if (xPower > yPower)
            {
                return 1;
            }

            // логика сравнения Cruiser
            if (x.IsWithGuns && !y.IsWithGuns)
            {
                return 1;
            } else if (!x.IsWithGuns && y.IsWithGuns)
            {
                return -1;
            }

            if (x.IsWithHelicopter && !y.IsWithHelicopter)
            {
                return 1;
            } else if (!x.IsWithHelicopter && y.IsWithHelicopter)
            {
                return 1;
            } else
            {
                return 0;
            }
        }
    }
}
