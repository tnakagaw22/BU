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
