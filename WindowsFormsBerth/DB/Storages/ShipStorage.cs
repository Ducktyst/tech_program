using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsTransport;
using WindowsFormsTransport.DB.Models;
using WindowsFormsTransport.DB.BindingModels;
using WindowsFormsTransport.DB.ViewModels;



namespace WindowsFormsTransport.DB
{
    public class ShipStorage
    {
        static public List<Ship> GetFullList()
        {
            using (var context = new TransportDatabase())
            {
                return context.Ships
                .Select(rec => new Ship
                {
                    Id = rec.Id,
                    berthID = rec.berthID,
                    ShipType = rec.ShipType,
                    StringValue = rec.StringValue,
                })
                .ToList();
            }
        }
        public List<Berth> GetFilteredList(Berth model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TransportDatabase())
            {
                return context.Berths
                .Where(rec => rec.Name.Contains(model.Name))
                .Select(rec => new Berth
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    MaxPlaces = rec.MaxPlaces
                })
                .ToList();
            }
        }
        public BerthViewModel GetElement(BerthBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TransportDatabase())
            {
                var berth = context.Berths.FirstOrDefault(
                    rec => rec.Name == model.Name || rec.Id == model.Id);

                return berth != null ?
                new BerthViewModel
                {
                    Id = berth.Id,
                    Name = berth.Name,
                    MaxPlaces = berth.MaxPlaces
                } :
                null;
            }
        }
        public static BerthViewModel GetElement(string berthName)
        {
            if (berthName == "")
            {
                return null;
            }

            using (var context = new TransportDatabase())
            {
                var berth = context.Berths.FirstOrDefault(
                    rec => rec.Name == berthName);

                return berth != null ?
                new BerthViewModel
                {
                    Id = berth.Id,
                    Name = berth.Name,
                    MaxPlaces = berth.MaxPlaces
                } :
                null;
            }
        }
        public void Insert(BerthBindingModel model)
        {
            using (var context = new TransportDatabase())
            {
                context.Berths.Add(CreateModel(model, new Berth()));
                context.SaveChanges();
            }
        }
        public void Update(BerthBindingModel model)
        {
            using (var context = new TransportDatabase())
            {
                var element = context.Berths.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
            {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(BerthBindingModel model)
        {
            using (var context = new TransportDatabase())
            {
                Berth element = context.Berths.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element != null)
                {
                    context.Berths.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Berth CreateModel(BerthBindingModel model, Berth berth)
        {
            berth.Id = model.Id;
            berth.Name = model.Name;
            berth.MaxPlaces = model.MaxPlaces;
            return berth;
        }
    }
}
