using SocketLabsModule.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApi.PowerShell.Commands
{
    public class ManagementApiCommandBase : CommandBase
    {
        protected const string BASE_URL = "https://api.socketlabs.com/v1/servers";

        [Parameter(Mandatory = false, Position = 10)]
        public string ApiKey { get; set; }

        protected override void BeginProcessing()
        {
            this.ApiKey = this.ApiKey ?? Environment.GetEnvironmentVariable("SL_MGMT_API");
            base.BeginProcessing();
        }


        protected void HandleException(AggregateException ex)
        {
            foreach (var inner in ex.InnerExceptions)
            {
                var apiExceptions = inner as ManagementApiException;
                if (apiExceptions != null)
                {
                    foreach (var apiEx in apiExceptions.InnerExceptions)
                    {
                        base.WriteError(new ErrorRecord(apiEx, String.Empty, ErrorCategory.WriteError, null));
                    }
                }
                else
                {
                    base.WriteError(new ErrorRecord(inner, String.Empty, ErrorCategory.WriteError, null));
                }
            }
        }
    }
}
