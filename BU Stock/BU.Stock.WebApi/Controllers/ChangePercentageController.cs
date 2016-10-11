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
        private readonly AwsSnsService _snsService;

        public ChangePercentageController(IStockService stockService)
        {
            _stockService = stockService;
            _snsService = new AwsSnsService();
        }

        // GET api/ChangePercentage/MSFT
        [HttpGet]
        public async Task<bool> Get()
        {
            var alertSent = false;
            var tickerSymbols = GetSp500TickerSymbols();

            foreach (var tickerSymbol in tickerSymbols)
            {
                var changeInPercentage = await _stockService.GetChangePercentageFromDaysHigh(tickerSymbol);
                decimal changeTrigger = 10m;
                if (changeInPercentage > changeTrigger)
                    alertSent = _snsService.PublishMessage($"Down Alert {changeTrigger}",
                                               $"{tickerSymbol} is down {changeTrigger} % from today's high.",
                                                "arn:aws:sns:us-west-2:767567474540:StockAlert");
            }
            return alertSent;
        }

        private List<string> GetSp500TickerSymbols()
        {
            List<string> tickerSymbols = new List<string>();
            tickerSymbols.Add("MSFT");

            return tickerSymbols;
        }
    }
}
