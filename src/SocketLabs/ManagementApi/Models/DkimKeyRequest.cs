using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApi.Models
{
    public class DkimKeyRequest
    {
        public string Domain { get; set; }
        public string Selector { get; set; }
        public string PrivateKey { get; set; }

        public DkimKeyRequest() { }

        public DkimKeyRequest(DkimKeyGeneratedResult dkim)
        {
            Domain = dkim.Domain;
            Selector = dkim.Selector;
            PrivateKey = dkim.PrivateKey;
        }
    }
}
