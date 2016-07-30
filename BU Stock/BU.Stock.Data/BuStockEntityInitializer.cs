using BU.Stock.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Data
{
    public class BuStockEntityInitializer : DropCreateDatabaseIfModelChanges<BuStockDbContext>
    {
        protected override void Seed(BuStockDbContext context)
        {
            //List<Role> roles = new List<Role>();
            //roles.Add(new Role() { Name = "Administrator" });
            //roles.Add(new Role() { Name = "Genral User" });

            //foreach (var item in roles)
            //    context.Roles.Add(item);

            //List<User> users = new List<User>();
        }
    }
}
