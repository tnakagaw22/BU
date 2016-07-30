using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Core.Models
{
    public class DownAlert : Entity
    {
        public string TickerSymbol { get; set; }
        public decimal HighestPrice { get; set; }
        public DateTime HighestPriceDate { get; set; }
    }
}
