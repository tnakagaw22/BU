using BU.Stock.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Data.Mapping
{
    public class DownAlertMap : EntityTypeConfiguration<DownAlert>
    {
        public DownAlertMap()
        {
            HasKey(t => t.Id);

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.Symbol)
                .IsRequired()
                .HasMaxLength(10);

            Property(t => t.HighestPrice)
                .IsRequired();

            Property(t => t.HighestPriceDate)
                .IsRequired();

        }
    }
}
