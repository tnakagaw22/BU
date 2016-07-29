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
            SP500 sp5001 = new SP500() { CompanyName = "3M Company", TickerSymbol = "MMM" };
            SP500 sp5002 = new SP500() { CompanyName = "Abbott Laboratories", TickerSymbol = "ABT" };
            SP500 sp5003 = new SP500() { CompanyName = "AbbVie", TickerSymbol = "ABBV" };

            context.SP500s.Add(sp5001);
            context.SP500s.Add(sp5002);
            context.SP500s.Add(sp5003);

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        //Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }
    }
}
