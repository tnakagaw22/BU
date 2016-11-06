using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Service.Configuration
{
    public class BuStockServiceConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("stockService", IsRequired = true, IsKey = true)]
        public StockServiceElement StockService
        {
            get { return (StockServiceElement)base["stockService"]; }
            set { base["stockService"] = value; }
        }
    }
}
