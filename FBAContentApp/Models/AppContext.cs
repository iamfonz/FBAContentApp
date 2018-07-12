using FBAContentApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.Models
{
    /// <summary>
    /// Class that creates the Entity Framework DbContext
    /// </summary>
    class AppContext : DbContext
    {
        public DbSet<AmazonWarehouse> AmazonWarehouses { get; set; }

        public DbSet<CompanyAddress> CompanyAddresses { get; set; }

        public DbSet<Shipment> Shipments { get; set; }

        public DbSet<ShipmentBox> Boxes { get; set; }

        public DbSet<State> States { get; set; }


    }
}
