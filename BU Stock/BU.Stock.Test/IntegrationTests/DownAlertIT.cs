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

                IStockService stockService = new YahooStockService();
                IRepository<DownAlert> downAlertRepository = new Repository<DownAlert>(dbContext);
                IDownAlertService downAlertService = new DownAlertService(downAlertRepository, stockService);

                DownAlert downAlertModel = new DownAlert()
                {
                    TickerSymbol = "MSFT",
                    HighestPrice = 56.21m,
                    HighestPriceDate = DateTime.Now
                };
                downAlertService.SaveHighestPrice(downAlertModel);
            }
        }

        [TestCategory("Performance")]
        [TestCategory("Integration")]
        [TestMethod]
        public async Task SaveDownAlertList_Save10000RecordsAsynchronously()
        {
            List<DownAlert> downAlertList = new List<DownAlert>();
            for (int i = 0; i < 10000; i++)
            {
                downAlertList.Add(new DownAlert()
                {
                    TickerSymbol = "MSFT",
                    HighestPrice = 56.21m,
                    HighestPriceDate = DateTime.Now
                });
            }

            DownAlertProcesser downAlertProcesser = new DownAlertProcesser();
            List<Task<int>> taskList = new List<Task<int>>();
            foreach (var item in downAlertList)
            {
                taskList.Add(downAlertProcesser.Run(item));
            }
            await Task.WhenAll(taskList);

            //await downAlertProcesser.Run(downAlertList);
        }

    }
}
