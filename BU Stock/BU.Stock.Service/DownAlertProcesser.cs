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
                downAlertService.SaveHighestPrice(downAlertModel);
                result = await unitOfWork.SaveAsync();
            }

            return result;
        }
    }
}
