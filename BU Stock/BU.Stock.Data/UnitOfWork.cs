using BU.Stock.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BU.Stock.Data
{
    public class UnitOfWork : IDisposable
    {
        private DbContext _context = new BuStockDbContext();
        private Repository<DownAlert> _downAlertRepository;

        public Repository<DownAlert> DownAlertRepository
        {
            get
            {

                if (_downAlertRepository == null)
                {
                    _downAlertRepository = new Repository<DownAlert>(_context);
                }
                return _downAlertRepository;
            }
        }

        public async Task<int> SaveAsync()
        {
            //await Task.Delay(10000);

            return await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
