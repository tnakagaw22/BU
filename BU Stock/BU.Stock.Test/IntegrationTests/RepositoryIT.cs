using BU.Stock.Core.Interfaces;
using BU.Stock.Core.Models;
using BU.Stock.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Test.IntegrationTests
{
    [TestClass]
    public class RepositoryIT
    {
        [TestCategory("Integration")]
        [TestMethod]
        public void Get()
        {
            using (IDbContextFactory dbContextFactory = new DbContextFactory())
            {
                var dbContext = dbContextFactory.GetContext();
                Repository<DownAlert> repo = new Repository<DownAlert>(dbContext);
                repo.Insert(new DownAlert()
                {
                    TickerSymbol = "TEST",
                    HighestPrice = 123m,
                    HighestPriceDate = DateTime.Now
                });

                var downAlert = repo.Get(p => p.TickerSymbol == "a").FirstOrDefault();

            }
        }

    }
}
