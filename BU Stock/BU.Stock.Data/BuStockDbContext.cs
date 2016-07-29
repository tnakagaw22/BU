using BU.Stock.Core.Models;
using BU.Stock.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Data
{
    public class BuStockDbContext : DbContext
    {
        public BuStockDbContext()
                : base("name=BuStock")
        {
            //Database.SetInitializer<BuStockDbContext>(null); // <- does not drop database
            Database.SetInitializer(new BuStockEntityInitializer());
        }
        public DbSet<DownAlert> DownAlerts { get; set; }
        public DbSet<SP500> SP500s { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new DownAlertMap());
            //modelBuilder.Entity<Course>().
            //  Property(c => c.Title).
            //  IsRequired().
            //  HasColumnName("Name");
        }
    }
}
