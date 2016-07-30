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
        bool IsHighestPrice(decimal currentPrice);
        bool SaveHighestPrice(DownAlert downAlertModel);
        bool SendAlert();
    }
}
