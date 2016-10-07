using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Core.Models
{
    public class AwsCredentialModel
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string RegionEndPoint { get; set; }
    }
}
