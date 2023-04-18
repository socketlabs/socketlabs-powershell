using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApi.Models
{
    public class BounceDomain
    {
        public int ServerId { get; set; }
        public string Domain { get; set; }
        public bool IsDefault { get; set; }
    }

}
