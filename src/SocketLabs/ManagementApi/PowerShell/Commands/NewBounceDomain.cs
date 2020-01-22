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
        VerbsCommon.New,
        "BounceDomain",
        SupportsShouldProcess = true,
        DefaultParameterSetName = "Default",
        HelpUri = "https://github.com/socketlabs/socketlabs-powershell/blob/master/README.md"
        )]
    public class NewBounceDomain : ManagementApiCommandBase
    {
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Default")]
        public int ServerId { get; set; }

        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "Default")]
        public string[] Domains { get; set; }

        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "Default")]
        public SwitchParameter IsDefault { get; set; }

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

            if (ShouldProcess(url, "New-BounceDomain"))
            {
                for (int i = 0; i < Domains.Length; i++)
                {
                    string domain = Domains[i];
                    var bounceDomain = new BounceDomain()
                    {
                        Domain = domain,
                        IsDefault = i == 0 && IsDefault.ToBool()
                    };

                    IRestProvider rest = new RestProvider(ApiKey);
                    try
                    {
                        var result = rest.PostAsync<BounceDomainResult>(url, bounceDomain).Result;

                        base.WriteObject(result);
                    }
                    catch (AggregateException ex)
                    {
                        HandleException(ex);
                    }
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
