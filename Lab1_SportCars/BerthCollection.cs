using System;
using System.Collections.Generic;
using System.IO;
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
		/// Разделитель для записи информации по объекту в файл
		/// </summary>
		protected readonly char separator = ':';

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
		public bool SaveData(string filename)
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

				//writer.Write(cextBoxl.Text);
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
		public bool LoadData(string filename)
		{
			if (!File.Exists(filename))
			{
				return false;
			}
			// открываем файл для записи и ассоциируем с ним поток
			FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);

			// если файл открыт
			if (stream == null)
			{
				return false;
			}

/*			using (StreamReader reader = new StreamReader(stream)) 
			{
				if (!reader.ReadLine().Contains("BerthCollection"))
				{
					//если нет такой записи, то это не те данные
					return false;
				}

				string line;

				while ((line = reader.ReadLine()) != null)
				{
					//очищаем записи
					_berthStages.Clear();
					Vehicle ship = null;
					string key = string.Empty;

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

				stream.Close();
				return true;
			}*/

			StreamReader reader = new StreamReader(stream);
			string line = reader.ReadLine();
			if (line == null)
			{
				return false;
			}
			if (!line.Contains("BerthCollection"))
			{
				//если нет такой записи, то это не те данные
				return false;
			}

			//очищаем записи
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

			stream.Close();
			reader.Close();
			return true;
		}
	}
}
