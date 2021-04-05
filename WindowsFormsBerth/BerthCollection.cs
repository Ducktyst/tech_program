using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsTransport.DB;
using WindowsFormsTransport.DB.BindingModels;
using WindowsFormsTransport.DB.Models;
using WindowsFormsTransport.DB.ViewModels;

namespace WindowsFormsTransport
{
    /// <summary>
    /// Класс-коллекция причалов
    /// </summary>
    public class BerthCollection : IEnumerator<string>, IEnumerable<string>
    {
        /// <summary>
        /// Словарь (хранилище) с причалами
        /// </summary>
        readonly Dictionary<string, Berth<Vehicle>> _berthStages;

        /// <summary>
        /// Возвращение списка названий парковок
        /// </summary>
        public List<string> _keys => _berthStages.Keys.ToList();

        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int _pictureWidth;

        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int _pictureHeight;

        /// <summary>
        /// Разделитель для записи информации по объекту в файл
        /// </summary>
        protected readonly char separator = ':';

        /// <summary>
        /// Текущий элемент для вывода через IEnumerator (будет обращаться по
        /// своему индексу к ключу словаря, по которму будет возвращаться запись)
        /// </summary>
        private int _currentIndex = -1;

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

        /// <summary>
        /// Сохранение информации по кораблям на пристани в файл
        /// </summary>
        /// <param name="filename">Путь и имя файла</param>
        /// <returns></returns>
        public bool SaveDataToFile(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            // открываем файл для записи и ассоциируем с ним поток
            FileStream stream = File.Open(filename, FileMode.Create, FileAccess.Write);

            // если файл открыт
            if (stream != null)
            {
                // создаем объект StreamWriter и ассоциируем
                // его с открытым потоком
                StreamWriter writer = new StreamWriter(stream);
                
                // записываем данные в поток
                writer.Write($"BerthCollection{Environment.NewLine}");
                foreach (var level in _berthStages)
                {
                    //Начинаем парковку
                    writer.Write($"Berth{separator}{level.Key}{Environment.NewLine}");
                    foreach (var ship in level.Value.GetNext())
                    {
                        //если место не пустое
                        if (ship != null)
                        {
                            writer.Write($"{ship.GetType().Name}{ separator}{ship}{ Environment.NewLine}");
                        }
                    }
                }

                // переносим данные из потока в файл
                writer.Flush();
                // закрываем файл
                writer.Close();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Загрузка информации по кораблям на пристани из файла
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool LoadDataFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException("Файл не найден");
            }

            using (StreamReader reader = new StreamReader(filename))
            {
                string line = reader.ReadLine();
                if (line == null || !line.Contains("BerthCollection"))
                {
                    //если нет такой записи, то это не те данные
                    throw new InvalidDataException("Неверный формат файла");
                }

                // очищаем записи
                _berthStages.Clear();
                Vehicle ship = null;
                string key = string.Empty;


                while ((line = reader.ReadLine()) != null)
                {
                    //идем по считанным записям
                    if (line.Contains("Berth"))
                    {
                        //начинаем новую парковку
                        key = line.Split(separator)[1];
                        _berthStages.Add(key, new Berth<Vehicle>(_pictureWidth, _pictureHeight));
                        continue;
                    }

                    if (line.Split(separator)[0] == "WarShip")
                    {
                        ship = new WarShip(line.Split(separator)[1]);
                    }
                    else if (line.Split(separator)[0] == "Cruiser")
                    {
                        ship = new Cruiser(line.Split(separator)[1]);
                    }

                    var result = _berthStages[key] + ship;
                    if (!result)
                    {
                        return false;
                    }

                }

                return true;
            }
        }

        /// <summary>
        /// Сохранение информации по кораблям на пристани в БД
        /// </summary>
        /// <returns></returns>
        public bool SaveDataToDb()
        {
            return false;
        }

        /// <summary>
        /// Загрузка информации по кораблям на пристани из БД
        /// </summary>
        /// <returns></returns>
        public bool LoadDataFromDb()
        {
  /*          using (TransportDatabase context = new TransportDatabase())
            {*/


                // очищаем записи
                _berthStages.Clear();

                List<Ship> ships = ShipStorage.GetFullList();

                string line = "";
                Vehicle ship = null;

                int prevBerthId = -1;

            foreach (Ship s in ships)
            {

                BerthViewModel berth = BerthStorage.GetElement(new BerthBindingModel { Id = s.berthID });
                if (berth.Id != prevBerthId || prevBerthId == -1)
                {
                    prevBerthId = berth.Id.Value;
                    _berthStages.Add(berth.Name, new Berth<Vehicle>(_pictureWidth, _pictureHeight));

                }

                line = s.StringValue;

                if (line.Split(separator)[0] == "WarShip")
                {
                    ship = new WarShip(line.Split(separator)[1]);
                }
                else if (line.Split(separator)[0] == "Cruiser")
                {
                    ship = new Cruiser(line.Split(separator)[1]);
                }

                var result = _berthStages[berth.Name] + ship;

                if (!result)
                {
                    return false;
                }


            }
            return true;
        }

        /// <summary>
        /// Возвращение текущего элемента для IEnumerator
        /// </summary>
        public string Current => _keys[_currentIndex];

        /// <summary>
        /// Возвращение текущего элемента для IEnumerator
        /// </summary>
        object IEnumerator.Current => _keys[_currentIndex];

        /// <summary>
        /// Метод от IDisposable (унаследован в IEnumerator). В данном случае,
        /// логики в нем не требуется
        /// </summary>
        public void Dispose() { }

        /// <summary>
        /// Переход к следующему элементу
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            int nextIndex = _currentIndex + 1;
            if (nextIndex < 0 || nextIndex >= _berthStages.Count)
            {
                return false;

                //     throw new IndexOutOfRangeException("Не найден корабль по месту");
            }

            _currentIndex = nextIndex;
            return true;
        }

        /// <summary>
        /// Сброс при достижении конца
        /// </summary>
        public void Reset() => _currentIndex = -1;

        /// <summary>
        /// Получение ссылки на объект от класса, реализующего IEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<string> GetEnumerator() => this;

        /// <summary>
        /// Получение ссылки на объект от класса, реализующего IEnumerator
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() => this;
    }
}
