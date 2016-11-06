using BU.Stock.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Core.Consumers
{
    public class DownAlertConsumer : IDownAlertConsumer, IDisposable
    {
        private IStockService _stockService;
        private HttpClient _httpClient;

        public DownAlertConsumer(IConfigurationFactory configurationFactory)
        {
            _httpClient = new HttpClient();
            _stockService = configurationFactory.GetStockService();
        }

        public bool SendAlert()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
