using BU.Stock.Core.Interfaces;
using NLog;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public async Task<decimal> GetCurrentPrice(string symbol)
        {
            logger.Info($"start downloading price {symbol}");

            Uri stockUri = new Uri($"{yahooStockQuoteUrl}?s={symbol}&f=price");
            decimal currentPrice = 0m;

            using (var client = new HttpClient())
            {
                string content = await client.GetStringAsync(stockUri);
                logger.Info($"completed downloading price {symbol}");

                var values = content.Split(',');

                decimal.TryParse(values[0], out currentPrice);

                return currentPrice;
            }

        }

        public async Task<decimal> GetChangePercentageFromDaysHigh(string symbol)
        {
            // b = Bid
            // h = Day’s High
            Uri stockUri = new Uri($"{yahooStockQuoteUrl}?s={symbol}&f=bh");

            using (var client = new HttpClient())
            {
                string content = await client.GetStringAsync(stockUri);
                logger.Info($"completed downloading price {symbol}");

                var values = content.Replace("\n", "").Split(',');

                decimal bid = 0m;
                decimal daysHigh = 0m;

                decimal.TryParse(values[0], out bid);
                decimal.TryParse(values[1], out daysHigh);

                return decimal.Round((daysHigh - bid) / daysHigh * 100, 2, MidpointRounding.AwayFromZero);
            }
        }
    }
}
