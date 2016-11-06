using BU.Stock.Core.Interfaces;
using BU.Stock.Service;
using BU.Stock.Service.Configuration;
using Nito.AsyncEx;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {            
            IConfigurationFactory configurationFactory = new ConfigurationFactory();
            IStockService stockService = configurationFactory.GetStockService();

            Console.WriteLine(stockService.ApiUrl);
            Console.ReadLine();

            ////stockService = new YahooStockService();
            //ISp500TickerService sp500TickerServicee = new Sp500TickerService();

            //AsyncContext.Run(() =>
            //{

            //    var tickerSymbols = sp500TickerServicee.GetSp500Tickers();
            //    foreach (var tickerSymbol in tickerSymbols)
            //    {
            //        MainAsync(args, tickerSymbol, stockService);
            //    }
            //});
        }

        static async void MainAsync(string[] args, string tickerSymbol, IStockService stockService)
        {
            Logger logger = LogManager.GetLogger("foo");
            logger.Info($"Main started for {tickerSymbol}");

            var alertSent = false;
            AwsSnsService snsService = new AwsSnsService();

            var changeInPercentage = await stockService.GetChangePercentageFromDaysHigh(tickerSymbol);
            logger.Info($"Change % is {changeInPercentage} for {tickerSymbol}.");

            decimal changeTrigger = 10m;
            if (changeInPercentage > changeTrigger)
                alertSent = snsService.PublishMessage($"Down Alert {changeTrigger}",
                                           $"{tickerSymbol} is down {changeInPercentage} % from today's high.",
                                            "arn:aws:sns:us-west-2:767567474540:StockAlert");

            logger.Info($"Alert for {tickerSymbol} is sent : {alertSent}.");

        }
    }
}
