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
    public class Sp500TickerServiceIT
    {
        [TestCategory("Integration")]
        [TestMethod]
        public void GetSp500Tickers()
        {
            var sp500TickerService = new Sp500TickerService();
            var list = sp500TickerService.GetSp500Tickers();

            Assert.IsTrue(list.Any());
        }
    }
}
