using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BU.Stock.WebApi;
using BU.Stock.WebApi.Controllers;
using BU.Stock.Core.Interfaces;
using BU.Stock.Service;

namespace BU.Stock.WebApi.Tests.Controllers
{
    [TestClass]
    public class ChangePercentageControllerTest
    {
        [TestMethod]
        public void SendNotification()
        {
            // Arrange
            IStockService stockService = new YahooStockService();
            ISp500TickerService sp500TickerServicee = new Sp500TickerService();
            ChangePercentageController controller = new ChangePercentageController(stockService, sp500TickerServicee);

            // Act
            var result = controller.SendNotification();

            // Assert
            Assert.IsTrue(result.Result);
        }

    }
}
