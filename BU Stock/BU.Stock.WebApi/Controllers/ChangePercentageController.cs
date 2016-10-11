using BU.Stock.Core.Interfaces;
using BU.Stock.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BU.Stock.WebApi.Controllers
{
    public class ChangePercentageController : ApiController
    {
        private readonly IStockService _stockService;
        private readonly ISp500TickerService _sp500TickerServicee;
        private readonly AwsSnsService _snsService;

        public ChangePercentageController(IStockService stockService, ISp500TickerService sp500TickerServicee)
        {
            _stockService = stockService;
            _sp500TickerServicee = sp500TickerServicee;
            _snsService = new AwsSnsService();
        }

        // GET api/ChangePercentage/MSFT
        [HttpPost]
        public async Task<bool> SendNotification()
        {
            System.Diagnostics.Trace.TraceError("SendNotification is called.");
            var alertSent = false;
            var tickerSymbols = _sp500TickerServicee.GetSp500Tickers();

            foreach (var tickerSymbol in tickerSymbols)
            {
                var changeInPercentage = await _stockService.GetChangePercentageFromDaysHigh(tickerSymbol);
                System.Diagnostics.Trace.TraceError($"Change % is {changeInPercentage} for {tickerSymbol}.");

                decimal changeTrigger = 10m;
                if (changeInPercentage > changeTrigger)
                    alertSent = _snsService.PublishMessage($"Down Alert {changeTrigger}",
                                               $"{tickerSymbol} is down {changeTrigger} % from today's high.",
                                                "arn:aws:sns:us-west-2:767567474540:StockAlert");
            }
            System.Diagnostics.Trace.TraceError("SendNotification finishes.");

            return alertSent;
        }
    }
}
