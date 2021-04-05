using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTransport
{
    /// <summary>
    /// Класс-ошибка "Если на пристани уже есть корабль с такими же характеристиками"
    /// </summary>
    class BerthAlreadyHaveException : Exception
    {
        public BerthAlreadyHaveException() : base("На пристани уже есть такой корабль") { }
    }
}
