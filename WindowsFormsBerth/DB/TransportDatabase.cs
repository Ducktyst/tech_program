using System;
using System.Collections.Generic;
using System.Data.Entity;
using WindowsFormsTransport.DB.Models;
// За титульником написать в дискорд


namespace WindowsFormsTransport.DB
{

    class TransportDatabase : DbContext
    {
        public TransportDatabase() : base()
        {

        }

  /*      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=PC\SQLEXPRESS;Initial Catalog=berth_db;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }*/
        public virtual DbSet<Berth> Berths { set; get; }
        public virtual DbSet<Cruiser> Cruisers { set; get; }

        public virtual DbSet<WarShip> WarShips { set; get; }

        public virtual DbSet<ActionLog> ActionLogs { set; get; }

        public virtual DbSet<Ship> Ships { set; get; }
        protected override void Dispose(bool disposing)
        {

        }
    }
}