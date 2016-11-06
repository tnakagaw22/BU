using BU.Stock.Core.Interfaces;
using BU.Stock.Service.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Service
{
    public class ConfigurationFactory : IConfigurationFactory
    {
        IStockService _stockService;

        public ConfigurationFactory()
        {
            BuStockServiceConfigurationSection config = ConfigurationManager.GetSection("buStock") as BuStockServiceConfigurationSection;

            if (config != null)
            {
                _stockService = Activator.CreateInstance(Type.GetType(config.StockService.Type)) as IStockService;
                _stockService.ApiUrl = config.StockService.ApiUrl;
            }

        }

        public IStockService GetStockService()
        {
            return _stockService;
        }
    }
}
