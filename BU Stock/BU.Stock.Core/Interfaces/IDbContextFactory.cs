using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Core.Interfaces
{
    public interface IDbContextFactory : IDisposable
    {
        DbContext GetContext();
    }
}
