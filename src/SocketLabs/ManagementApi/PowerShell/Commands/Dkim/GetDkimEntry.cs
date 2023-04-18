using ManagementApi.Models;
using SocketLabsModule.Common.Services;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using static SocketLabsModule.Common.UrlHelper;

namespace ManagementApi.PowerShell.Commands
{
    /// <summary>
    /// Implementation for the Out-SocketLabs command.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        "DkimEntry",
        SupportsShouldProcess = true,
        DefaultParameterSetName = "Default",
        HelpUri = "https://github.com/socketlabs/socketlabs-powershell/blob/master/README.md"
        )]
    public class GetDkimEntry : ManagementApiCommandBase
    {
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Default")]
        public int ServerId { get; set; }

        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "Default")]
        public string Domain { get; set; }

        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "Default")]
        public string Selector { get; set; }

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
            string url = $"{BASE_URL}/{ServerId}/dkim";
            var qsp = new Dictionary<string, string>()
            {
                { "domain", Domain },
                { "selector", Selector }
            };
            url = AddQueryStrings(url, qsp);

            if (ShouldProcess(url, "Get-DkimEntries"))
            {
                IRestProvider rest = new RestProvider(ApiKey);
                try
                {

                    var result = rest.GetAsync<IEnumerable<DkimKeyResult>>(url).Result;
                    foreach (var item in result)
                    {
                        item.ServerId = ServerId;
                        base.WriteObject(item);
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
