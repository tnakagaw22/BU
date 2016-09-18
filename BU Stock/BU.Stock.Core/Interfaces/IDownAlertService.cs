using BU.Stock.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Core.Interfaces
{
    public interface IDownAlertService
    {
        Task<decimal> GetCurrentPrice(string symbol);
        bool IsHighestPrice(string symbol, decimal currentPrice);
        Task UpdateHighestPrice(decimal currentPrice);
        bool NeedToSendAlert(decimal currentPrice, decimal highestPrice);
        bool SaveHighestPrice(DownAlert downAlertModel);
        bool SendAlert();
    }
}
