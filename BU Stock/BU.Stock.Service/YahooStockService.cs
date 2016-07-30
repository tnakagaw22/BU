using BU.Stock.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Service
{
    // https://ilmusaham.wordpress.com/tag/stock-yahoo-data/
    // http://finance.yahoo.com/d/quotes.csv?s=msft&f=price

    public class YahooStockService : IStockService
    {
        private readonly string yahooStockQuoteUrl = "http://finance.yahoo.com/d/quotes.csv";

        public async Task<decimal> GetCurrentPrice(string symbol)
        {
            Uri stockUri = new Uri($"{yahooStockQuoteUrl}?s={symbol}&f=price");
            decimal currentPrice = 0m;

            using (var client = new HttpClient())
            {
                string content = await client.GetStringAsync(stockUri);
                var values = content.Split(',');

                decimal.TryParse(values[0], out currentPrice);

                return currentPrice;
            }

        }
    }
}
