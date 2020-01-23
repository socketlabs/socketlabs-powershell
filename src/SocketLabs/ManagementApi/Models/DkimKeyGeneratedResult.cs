using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApi.Models
{
    public class DkimKeyGeneratedResult
    {
        public int ServerId { get; set; }
        public string DnsHostName { get; set; }
        public string Selector { get; set; }
        public string DnsRecord { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
    }
}
