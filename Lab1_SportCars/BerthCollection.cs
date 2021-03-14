using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTransport
{
    /// <summary>
    /// Класс-коллекция причалов
    /// </summary>
    public class BerthCollection
    {
        /// <summary>
        /// Словарь (хранилище) с причалами
        /// </summary>
        readonly Dictionary<string, Berth<Vehicle>> _berthStages;

        /// <summary>
        /// Возвращение списка названий парковок
        /// </summary>
        public List<string> Keys => _berthStages.Keys.ToList();

        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int _pictureWidth;

        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int _pictureHeight;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pictureWidth"></param>
        /// <param name="pictureHeight"></param>
        public BerthCollection(int pictureWidth, int pictureHeight)
        {
            _berthStages = new Dictionary<string, Berth<Vehicle>>();
            _pictureWidth = pictureWidth;
            _pictureHeight = pictureHeight;
        }

        /// <summary>
        /// Добавление причала
        /// </summary>
        /// <param name="name">Название причала</param>
        public void AddBerth(string name)
        {
            if (_berthStages.ContainsKey(name))
            {
                MessageBox.Show("Причал с таким именем уже существует");
            }
            _berthStages[name] = new Berth<Vehicle>(_pictureWidth, _pictureHeight);
        }

        /// <summary>
        /// Удаление причала
        /// </summary>
        /// <param name="name">Название причала</param>
        public void DelBerth(string name)
        {
            _berthStages.Remove(name);
        }

        /// <summary>
        /// Доступ к причалу
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        public Berth<Vehicle> this[string ind]
        {
            set { _berthStages[ind] = value; }
            get { return _berthStages[ind]; }
        }
    }
}
