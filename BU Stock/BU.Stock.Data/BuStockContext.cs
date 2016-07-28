using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Data
{
    public class BuStockContext : DbContext
    {
        public DbSet<DownAlert> DownAlerts { get; set; }
    }
}
