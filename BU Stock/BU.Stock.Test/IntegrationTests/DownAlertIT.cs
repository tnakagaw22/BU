using BU.Stock.Core.Interfaces;
using BU.Stock.Core.Models;
using BU.Stock.Data;
using BU.Stock.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Test.IntegrationTests
{
    [TestClass]
    public class DownAlertIT
    {
        [TestCategory("Integration")]
        [TestMethod]
        public void SaveToDownAlertTable()
        {
            using(IDbContextFactory dbContextFactory = new DbContextFactory())
            {
                var dbContext = dbContextFactory.GetContext();

                IRepository<DownAlert> downAlertRepository = new Repository<DownAlert>(dbContext);
                IDownAlertService downAlertService = new DownAlertService(downAlertRepository);

                DownAlertModel downAlertModel = new DownAlertModel();
                downAlertService.SaveHighestPrice(downAlertModel);
            }
        }
    }
}
