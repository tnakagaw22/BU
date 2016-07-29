using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Core.Models
{
    public class SP500 : Entity
    {
        public string CompanyName { get; set; }
        public string TickerSymbol { get; set; }
    }
}
