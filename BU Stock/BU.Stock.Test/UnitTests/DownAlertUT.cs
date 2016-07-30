using BU.Stock.Core.Interfaces;
using BU.Stock.Core.Models;
using BU.Stock.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Test.UnitTests
{
    [TestClass]
    public class DownAlertUT
    {
        private Mock<IRepository<DownAlert>> _repoDownAlert;
        private Mock<IStockService> _stockService;

        [TestInitialize()]
        public void Setup()
        {
            _repoDownAlert = new Mock<IRepository<DownAlert>>();
            _stockService = new Mock<IStockService>();
        }

        [TestCategory("Unit")]
        [TestMethod]
        public void GetCurrentPrice_WhenStockServiceReturnsCurrentPrice_ReturnCurrentPrice()
        {
            string tickerSymbol = "MSFT";
            decimal currentPrice = 44m;
            _stockService.Setup(p => p.GetCurrentPrice(tickerSymbol)).Returns(currentPrice);
            var stockService = new DownAlertService(_repoDownAlert.Object, _stockService.Object);

            var result = stockService.GetCurrentPrice(tickerSymbol);

            Assert.IsTrue(result > 0);
        }

        [TestCategory("Unit")]
        [TestMethod]
        public void GetCurrentPrice_WhenStockServiceThrowsError_Return0()
        {
            string tickerSymbol = "MSFT";
            _stockService.Setup(p => p.GetCurrentPrice(It.IsAny<string>())).Throws(new Exception("test exception"));
            var stockService = new DownAlertService(_repoDownAlert.Object, _stockService.Object);

            var result = stockService.GetCurrentPrice(tickerSymbol);

            Assert.IsTrue(result == 0);
        }
    }
}
