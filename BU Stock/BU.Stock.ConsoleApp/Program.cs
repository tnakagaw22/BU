using BU.Stock.Service;
using Nito.AsyncEx;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = LogManager.GetLogger("foo");
            logger.Info("Program started");
            AsyncContext.Run(() => MainAsync(args));
        }

        static async void MainAsync(string[] args)
        {
            var yahooService = new YahooStockService();
            await yahooService.GetCurrentPrice("MSFT");
        }
    }
}
