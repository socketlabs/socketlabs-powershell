using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApi.Models
{
    public class BounceDomainResult : BounceDomain
    {
        public string ValidationResult { get; set; }
    }
}
