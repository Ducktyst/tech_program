using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsBerth.DB.ViewModels;
using WindowsFormsTransport.DB.Models;

namespace WindowsFormsTransport.DB
{
    class MyDatalnitializer : DropCreateDatabaseIfModelChanges<TransportDatabase>
    {

        protected override void Seed(TransportDatabase context)
        {
            base.Seed(context);

            var berths = new List<Berth>
            {
                new Berth{Id = null, Name = "Причал 1", MaxPlaces = 15 },
                new Berth{Id = null, Name = "Причал 2", MaxPlaces = 15 },
                new Berth{Id = null, Name = "Причал 3", MaxPlaces = 15 },
                new Berth{Id = null, Name = "Причал 4", MaxPlaces = 15 },
                new Berth{Id = null, Name = "Причал 5", MaxPlaces = 15 },
            };

            berths.ForEach( x => context.Berths.Add( new Berth { Name = x.Name, MaxPlaces = x.MaxPlaces }));

            var cruisers = new List<Cruiser>
            {
                new Cruiser(600, 100, Color.White, Color.Yellow, true, true),
                new Cruiser(660, 100, Color.Green, Color.Yellow, true, true),
                new Cruiser(770, 100, Color.Blue, Color.Yellow, true, true),
                new Cruiser(400, 100, Color.Orange, Color.Yellow, true, true),
            };

            var warShips = new List<WarShip>
            {
                new WarShip (120, 100, Color.Red),
                new WarShip (220, 100, Color.Red),
                new WarShip (450, 100, Color.Red),
                new WarShip (670, 100, Color.Red),
            };

            cruisers.ForEach(
                x => context.Ships.Add(new Ship{ ShipType = "Cruiser", StringValue = x.ToString(), } )
            );

            warShips.ForEach(
                x => context.Ships.Add(new Ship { ShipType = "WarShip", StringValue = x.ToString(), })
            );

            /*
             Сделать:

            Скриншоты для очтета

            1. Add-Migration InitialCreate

            */
        }
    }
}
