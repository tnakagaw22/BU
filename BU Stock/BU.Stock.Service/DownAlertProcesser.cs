using BU.Stock.Core.Interfaces;
using BU.Stock.Core.Models;
using BU.Stock.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Service
{
    public class DownAlertProcesser
    {
        public async Task<int> Run(DownAlert downAlertModel)
        {
            int result;

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                IStockService stockService = new YahooStockService();
                IDownAlertService downAlertService = new DownAlertService(unitOfWork.DownAlertRepository, stockService);

                string symbol = "MSFT";
                // GetCurrentPrice from yahoo API
                var currentPrice = downAlertService.GetCurrentPrice(symbol);

                await Task.WhenAll(currentPrice);
                // Current 20% less than Highest -> send alert

                if (downAlertService.IsHighestPrice(symbol, currentPrice.Result))
                {
                    // Highest == null -> Insert
                    var downAlert = new DownAlert()
                    {
                        HighestPrice = currentPrice.Result,
                        HighestPriceDate = DateTime.Now,
                        TickerSymbol = symbol
                    };
                    downAlertService.SaveHighestPrice(downAlert);
                }
                else
                {
                    // Current > Highest -> Update
                    var updateResult = downAlertService.UpdateHighestPrice(currentPrice.Result);

                    if (downAlertService.NeedToSendAlert(currentPrice.Result, 0m))
                        downAlertService.SendAlert();

                    await updateResult;
                }
                downAlertService.SaveHighestPrice(downAlertModel);
                result = await unitOfWork.SaveAsync();
            }

            return result;
        }
    }
}
