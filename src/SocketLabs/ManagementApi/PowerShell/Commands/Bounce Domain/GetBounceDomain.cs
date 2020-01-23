using ManagementApi.Models;
using SocketLabsModule.Common;
using SocketLabsModule.Common.Services;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;
using System.Text;

namespace ManagementApi.PowerShell.Commands
{
    /// <summary>
    /// Implementation for the Out-SocketLabs command.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        "BounceDomain",
        SupportsShouldProcess = true,
        DefaultParameterSetName = "Default",
        HelpUri = "https://github.com/socketlabs/socketlabs-powershell/blob/master/README.md"
        )]
    public class GetBounceDomain : ManagementApiCommandBase
    {
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Default")]
        public int ServerId { get; set; }

        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "Default")]
        public string Domain { get; set; }


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }

        protected override void ProcessRecord()
        {
            string url = $"{BASE_URL}/{ServerId}/bounce";
            bool hasDomainParameter = !String.IsNullOrEmpty(Domain);

            if (hasDomainParameter)
            {
                url += $"/{Domain}";
            }

            if (ShouldProcess(url, "Get-BounceDomain"))
            {
                IRestProvider rest = new RestProvider(ApiKey);
                try
                {
                    if (hasDomainParameter)
                    {
                        var result = rest.GetAsync<BounceDomain>(url).Result;
                        result.ServerId = ServerId;
                        base.WriteObject(result);
                    }
                    else
                    {
                        var results = rest.GetAsync<IEnumerable<BounceDomain>>(url).Result;

                        foreach (var item in results)
                        {
                            item.ServerId = ServerId;
                            base.WriteObject(item);
                        }
                    }
                }
                catch (AggregateException ex)
                {
                    HandleException(ex);
                }

                base.ProcessRecord();
            }
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
        }
    }
}
