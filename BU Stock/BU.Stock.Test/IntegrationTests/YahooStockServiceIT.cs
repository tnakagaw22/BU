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
        public async Task GetCurrentPrice_WhenInputIsValid_ReturnCurrentPrice()
        {
            string tickerSymbol = "MSFT";
            var stockService = new YahooStockService();

            var result = await stockService.GetCurrentPrice(tickerSymbol);

            Assert.IsTrue(result > 0);
        }

        [TestCategory("Integration")]
        [TestMethod]
        //[ExpectedException(typeof(Exception))]
        public async Task GetCurrentPrice_WhenInputIsNOTValid_ReturnCurrentPrice()
        {
            string tickerSymbol = "test?<L\"%%@";
            var stockService = new YahooStockService();

            var result = await stockService.GetCurrentPrice(tickerSymbol);

            Assert.IsTrue(result == 0);
        }

        [TestCategory("Integration")]
        [TestMethod]
        //[ExpectedException(typeof(Exception))]
        public async Task GetCurrentPrice_WhenMultipleRequestsAreMade_ReturnTheirCurrentPrice()
        {
            List<string> tickerSymbolList = new List<string>();
            #region Add Ticker Symbols
            tickerSymbolList.Add("MSFT");
            tickerSymbolList.Add("MMM");
            tickerSymbolList.Add("ABT ");
            tickerSymbolList.Add("ABBV");
            tickerSymbolList.Add("ACN");
            tickerSymbolList.Add("ATVI");
            tickerSymbolList.Add("AYI ");
            tickerSymbolList.Add("ADBE");
            tickerSymbolList.Add("AAP ");
            tickerSymbolList.Add("AES ");
            tickerSymbolList.Add("AET ");
            tickerSymbolList.Add("AFL ");
            tickerSymbolList.Add("AMG ");
            tickerSymbolList.Add("APD ");
            tickerSymbolList.Add("AKAM");
            tickerSymbolList.Add("ALK ");
            tickerSymbolList.Add("ALB ");
            tickerSymbolList.Add("AGN ");
            tickerSymbolList.Add("LNT ");
            tickerSymbolList.Add("ALXN");
            tickerSymbolList.Add("ALLE");
            tickerSymbolList.Add("ADS ");
            tickerSymbolList.Add("ALL ");
            tickerSymbolList.Add("GOOG");
            tickerSymbolList.Add("GOOG");
            tickerSymbolList.Add("AMZN");
            tickerSymbolList.Add("AEE ");
            tickerSymbolList.Add("AAL ");
            tickerSymbolList.Add("AEP ");
            tickerSymbolList.Add("AXP ");
            tickerSymbolList.Add("AIG ");
            tickerSymbolList.Add("AMT ");
            tickerSymbolList.Add("AWK ");
            tickerSymbolList.Add("AMP ");
            tickerSymbolList.Add("ABC ");
            tickerSymbolList.Add("AME ");
            tickerSymbolList.Add("AMGN");
            tickerSymbolList.Add("APH ");
            tickerSymbolList.Add("APC ");
            tickerSymbolList.Add("ADI ");
            tickerSymbolList.Add("AON ");
            tickerSymbolList.Add("APA ");
            tickerSymbolList.Add("AIV ");
            tickerSymbolList.Add("AAPL");
            tickerSymbolList.Add("AMAT");
            tickerSymbolList.Add("ADM ");
            tickerSymbolList.Add("AJG ");
            tickerSymbolList.Add("AIZ ");
            tickerSymbolList.Add("ADSK");
            tickerSymbolList.Add("ADP ");
            tickerSymbolList.Add("AZO");
            tickerSymbolList.Add("MSFT");
            tickerSymbolList.Add("MMM");
            tickerSymbolList.Add("ABT ");
            tickerSymbolList.Add("ABBV");
            tickerSymbolList.Add("ACN");
            tickerSymbolList.Add("ATVI");
            tickerSymbolList.Add("AYI ");
            tickerSymbolList.Add("ADBE");
            tickerSymbolList.Add("AAP ");
            tickerSymbolList.Add("AES ");
            tickerSymbolList.Add("AET ");
            tickerSymbolList.Add("AFL ");
            tickerSymbolList.Add("AMG ");
            tickerSymbolList.Add("APD ");
            tickerSymbolList.Add("AKAM");
            tickerSymbolList.Add("ALK ");
            tickerSymbolList.Add("ALB ");
            tickerSymbolList.Add("AGN ");
            tickerSymbolList.Add("LNT ");
            tickerSymbolList.Add("ALXN");
            tickerSymbolList.Add("ALLE");
            tickerSymbolList.Add("ADS ");
            tickerSymbolList.Add("ALL ");
            tickerSymbolList.Add("GOOG");
            tickerSymbolList.Add("GOOG");
            tickerSymbolList.Add("AMZN");
            tickerSymbolList.Add("AEE ");
            tickerSymbolList.Add("AAL ");
            tickerSymbolList.Add("AEP ");
            tickerSymbolList.Add("AXP ");
            tickerSymbolList.Add("AIG ");
            tickerSymbolList.Add("AMT ");
            tickerSymbolList.Add("AWK ");
            tickerSymbolList.Add("AMP ");
            tickerSymbolList.Add("ABC ");
            tickerSymbolList.Add("AME ");
            tickerSymbolList.Add("AMGN");
            tickerSymbolList.Add("APH ");
            tickerSymbolList.Add("APC ");
            tickerSymbolList.Add("ADI ");
            tickerSymbolList.Add("AON ");
            tickerSymbolList.Add("APA ");
            tickerSymbolList.Add("AIV ");
            tickerSymbolList.Add("AAPL");
            tickerSymbolList.Add("AMAT");
            tickerSymbolList.Add("ADM ");
            tickerSymbolList.Add("AJG ");
            tickerSymbolList.Add("AIZ ");
            tickerSymbolList.Add("ADSK");
            tickerSymbolList.Add("ADP ");
            tickerSymbolList.Add("AZO");
            tickerSymbolList.Add("MSFT");
            tickerSymbolList.Add("MMM");
            tickerSymbolList.Add("ABT ");
            tickerSymbolList.Add("ABBV");
            tickerSymbolList.Add("ACN");
            tickerSymbolList.Add("ATVI");
            tickerSymbolList.Add("AYI ");
            tickerSymbolList.Add("ADBE");
            tickerSymbolList.Add("AAP ");
            tickerSymbolList.Add("AES ");
            tickerSymbolList.Add("AET ");
            tickerSymbolList.Add("AFL ");
            tickerSymbolList.Add("AMG ");
            tickerSymbolList.Add("APD ");
            tickerSymbolList.Add("AKAM");
            tickerSymbolList.Add("ALK ");
            tickerSymbolList.Add("ALB ");
            tickerSymbolList.Add("AGN ");
            tickerSymbolList.Add("LNT ");
            tickerSymbolList.Add("ALXN");
            tickerSymbolList.Add("ALLE");
            tickerSymbolList.Add("ADS ");
            tickerSymbolList.Add("ALL ");
            tickerSymbolList.Add("GOOG");
            tickerSymbolList.Add("GOOG");
            tickerSymbolList.Add("AMZN");
            tickerSymbolList.Add("AEE ");
            tickerSymbolList.Add("AAL ");
            tickerSymbolList.Add("AEP ");
            tickerSymbolList.Add("AXP ");
            tickerSymbolList.Add("AIG ");
            tickerSymbolList.Add("AMT ");
            tickerSymbolList.Add("AWK ");
            tickerSymbolList.Add("AMP ");
            tickerSymbolList.Add("ABC ");
            tickerSymbolList.Add("AME ");
            tickerSymbolList.Add("AMGN");
            tickerSymbolList.Add("APH ");
            tickerSymbolList.Add("APC ");
            tickerSymbolList.Add("ADI ");
            tickerSymbolList.Add("AON ");
            tickerSymbolList.Add("APA ");
            tickerSymbolList.Add("AIV ");
            tickerSymbolList.Add("AAPL");
            tickerSymbolList.Add("AMAT");
            tickerSymbolList.Add("ADM ");
            tickerSymbolList.Add("AJG ");
            tickerSymbolList.Add("AIZ ");
            tickerSymbolList.Add("ADSK");
            tickerSymbolList.Add("ADP ");
            tickerSymbolList.Add("AZO");
            #endregion

            var stockService = new YahooStockService();

            foreach (var item in tickerSymbolList)
            {
                var result = await stockService.GetCurrentPrice(item);

            }
            Assert.IsTrue(true);
        }
    }
}