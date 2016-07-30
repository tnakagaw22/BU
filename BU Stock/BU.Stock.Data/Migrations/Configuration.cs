namespace BU.Stock.Data.Migrations
{
    using Core.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BU.Stock.Data.BuStockDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BU.Stock.Data.BuStockDbContext";
        }

        protected override void Seed(BU.Stock.Data.BuStockDbContext context)
        {
            SP500 sp5001 = new SP500() { CompanyName = "3M Company", TickerSymbol = "MMM" };
            SP500 sp5002 = new SP500() { CompanyName = "Abbott Laboratories", TickerSymbol = "ABT" };
            SP500 sp5003 = new SP500() { CompanyName = "AbbVie", TickerSymbol = "ABBV" };

            context.SP500s.AddOrUpdate(p => p.TickerSymbol, sp5001);
            context.SP500s.AddOrUpdate(p => p.TickerSymbol, sp5002);
            context.SP500s.AddOrUpdate(p => p.TickerSymbol, sp5003);

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
