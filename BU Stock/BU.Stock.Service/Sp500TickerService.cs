using BU.Stock.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Service
{
    public class Sp500TickerService : ISp500TickerService
    {
        public IEnumerable<string> GetSp500Tickers()
        {
            string tickerListString;
            using (var client = new WebClient())
            {
                tickerListString = client.DownloadString("https://raw.githubusercontent.com/datasets/s-and-p-500-companies/master/data/constituents.csv");
            }

            List<string> tickerList = new List<string>();
            string[] tickerLines = tickerListString.Split('\n');
            foreach (var tickerLine in tickerLines)
            {
                string[] values = tickerLine.Split(',');
                string tickerSymbol = values[0];
                if (tickerSymbol != "Symbol" && !String.IsNullOrEmpty(tickerSymbol))
                    tickerList.Add(values[0]);
            }

            return tickerList;
        }
    }
}
