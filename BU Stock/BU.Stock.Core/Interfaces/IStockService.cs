using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Core.Interfaces
{
    public interface IStockService
    {
        Task<decimal> GetCurrentPrice(string symbol);
    }
}
