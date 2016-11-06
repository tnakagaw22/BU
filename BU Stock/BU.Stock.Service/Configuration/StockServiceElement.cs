using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Service.Configuration
{
    public class StockServiceElement : ProviderTypeElement
    {
        [ConfigurationProperty("apiUrl", IsRequired = true)]
        public string ApiUrl
        {
            get { return (string)base["apiUrl"]; }
            set { base["apiUrl"] = value; }
        }

    }
}
