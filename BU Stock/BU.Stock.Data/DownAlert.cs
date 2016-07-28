using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Data
{
    public class DownAlert
    {
        public string Symbol { get; set; }
        public decimal HighestPrice { get; set; }
        public DateTime HighestPriceDate { get; set; }
    }
}
