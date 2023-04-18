using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApi.Models
{
    public class DkimKeyResult
    {
        public int ServerId { get; set; }
        public string Domain { get; set; }
        public string Selector { get; set; }
        public string TruncatedPrivateKey { get; set; }
        public string ValidationStatus { get; set; }
    }
}
