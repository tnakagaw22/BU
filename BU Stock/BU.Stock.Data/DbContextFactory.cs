using BU.Stock.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Data
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext _dbContext;

        public DbContextFactory()
        {
            _dbContext = new BuStockContext();
        }

        public DbContext GetContext()
        {
            return _dbContext;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
