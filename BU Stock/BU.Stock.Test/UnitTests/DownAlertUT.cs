using BU.Stock.Core.Interfaces;
using BU.Stock.Core.Models;
using BU.Stock.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Test.UnitTests
{
    [TestClass]
    public class DownAlertUT
    {
        public TestContext TestContext { get; set; }

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
        public async Task GetCurrentPrice_WhenStockServiceReturnsCurrentPrice_ReturnCurrentPrice()
        {
            TestContext.WriteLine("dfdfdfdfdf");

            string tickerSymbol = "MSFT";
            //Task<decimal> currentPrice = 44m;
            _stockService.Setup(p => p.GetCurrentPrice(tickerSymbol)).Returns(Task.FromResult(44m));
            var downAlertService = new DownAlertService(_repoDownAlert.Object, _stockService.Object);

            var result = await downAlertService.GetCurrentPrice(tickerSymbol);

            Assert.IsTrue(result > 0);
        }

        [TestCategory("Unit")]
        [TestMethod]
        public async Task GetCurrentPrice_WhenStockServiceThrowsError_Return0()
        {
            string tickerSymbol = "MSFT";
            _stockService.Setup(p => p.GetCurrentPrice(It.IsAny<string>())).Throws(new Exception("test exception"));
            var stockService = new DownAlertService(_repoDownAlert.Object, _stockService.Object);

            var result = await stockService.GetCurrentPrice(tickerSymbol);

            Assert.IsTrue(result == 0);
        }

        [TestCategory("Unit")]
        [TestMethod]
        public void IsHighestPrice_WhenPriceIsNotFoundInDb_ReturnTrue()
        {
            string tickerSymbol = "MSFT";
            decimal currentPrice = 10m;
            _repoDownAlert.Setup(m => m.Get(It.IsAny<Expression<Func<DownAlert, bool>>>(), null, "")).Returns(new List<DownAlert>());
            var downAlertService = new DownAlertService(_repoDownAlert.Object, _stockService.Object);

            var result = downAlertService.IsHighestPrice(tickerSymbol, currentPrice);

            Assert.IsTrue(result);
        }

        [TestCategory("Unit")]
        [TestMethod]
        public void IsHighestPrice_WhenDownAlertIsFoundInDbAndCurrentPriceIsNotBiggerThanPriceInDb_ReturnFalse()
        {
            string tickerSymbol = "MSFT";
            decimal currentPrice = 10m;
            List<DownAlert> downAlerts = new List<DownAlert>();
            downAlerts.Add(new DownAlert() { TickerSymbol = tickerSymbol, HighestPrice = currentPrice + 2m });

            _repoDownAlert.Setup(m => m.Get(It.IsAny<Expression<Func<DownAlert, bool>>>(), null, "")).Returns(downAlerts);
            var downAlertService = new DownAlertService(_repoDownAlert.Object, _stockService.Object);

            var result = downAlertService.IsHighestPrice(tickerSymbol, currentPrice);

            Assert.IsFalse(result);
        }

        [TestCategory("Unit")]
        [TestMethod]
        public void IsHighestPrice_WhenDownAlertIsFoundInDbAndCurrentPriceIsBiggerThanPriceInDb_ReturnTrue()
        {
            string tickerSymbol = "MSFT";
            decimal currentPrice = 10m;
            List<DownAlert> downAlerts = new List<DownAlert>();
            downAlerts.Add(new DownAlert() { TickerSymbol = tickerSymbol, HighestPrice = currentPrice - 2m });

            _repoDownAlert.Setup(m => m.Get(It.IsAny<Expression<Func<DownAlert, bool>>>(), null, "")).Returns(downAlerts);
            var downAlertService = new DownAlertService(_repoDownAlert.Object, _stockService.Object);

            var result = downAlertService.IsHighestPrice(tickerSymbol, currentPrice);

            Assert.IsTrue(result);
        }
    }
}
