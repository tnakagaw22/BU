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
    public class YahooStockServiceIT
    {
        [TestCategory("Integration")]
        [TestMethod]
        public void GetCurrentPrice_WhenInputIsValid_ReturnCurrentPrice()
        {
            string tickerSymbol = "MSFT";
            var stockService = new YahooStockService();

            var result = stockService.GetCurrentPrice(tickerSymbol);

            Assert.IsTrue(result > 0);
        }

        [TestCategory("Integration")]
        [TestMethod]
        //[ExpectedException(typeof(Exception))]
        public void GetCurrentPrice_WhenInputIsNOTValid_ReturnCurrentPrice()
        {
            string tickerSymbol = "test?<L\"%%@";
            var stockService = new YahooStockService();

            var result = stockService.GetCurrentPrice(tickerSymbol);

            Assert.IsTrue(result == 0);
        }
    }
}
