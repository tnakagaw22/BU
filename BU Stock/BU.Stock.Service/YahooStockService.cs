using BU.Stock.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Service
{
    // https://ilmusaham.wordpress.com/tag/stock-yahoo-data/
    // http://finance.yahoo.com/d/quotes.csv?s=msft&f=price

    public class YahooStockService : IStockService
    {
        private readonly string yahooStockQuoteUrl = "http://finance.yahoo.com/d/quotes.csv";

        public decimal GetCurrentPrice(string symbol)
        {
            string targetUrl = $"{yahooStockQuoteUrl}?s={symbol}&f=price";
            decimal currentPrice = 0m;

            try
            {
                using (var client = new WebClient())
                {
                    var content = client.DownloadString(targetUrl);
                    var values = content.Split(',');

                    decimal.TryParse(values[0], out currentPrice);

                    return currentPrice;
                }
            }
            catch (Exception ex)
            {
                // TODO error handling
                throw;
            }
        }
    }
}
