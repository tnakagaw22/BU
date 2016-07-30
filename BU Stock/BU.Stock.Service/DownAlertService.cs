﻿using AutoMapper;
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
    public class DownAlertService : IDownAlertService
    {
        private IRepository<DownAlert> _downAlertRepository;
        private IStockService _stockService;

        public DownAlertService(IRepository<DownAlert> downAlertRepository, IStockService stockService)
        {
            _downAlertRepository = downAlertRepository;
            _stockService = stockService;
        }

        public async Task<decimal> GetCurrentPrice(string symbol)
        {
            decimal result = 0m;

            try
            {
                result =  await _stockService.GetCurrentPrice(symbol);
            }
            catch (Exception ex)
            {
                // TODO log exception
                result = 0;
            }

            return result;
        }

        public bool IsHighestPrice(decimal currentPrice)
        {
            throw new NotImplementedException();
        }

        public bool SaveHighestPrice(DownAlert downAlert)
        {
            bool result = false;

            try
            {
                _downAlertRepository.Insert(downAlert);
                _downAlertRepository.Save();

                result = true;
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public bool SendAlert()
        {
            throw new NotImplementedException();
        }
    }
}
