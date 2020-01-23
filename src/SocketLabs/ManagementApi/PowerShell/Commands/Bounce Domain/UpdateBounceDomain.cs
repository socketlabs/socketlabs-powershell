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
        VerbsData.Update,
        "BounceDomain",
        SupportsShouldProcess = true,
        DefaultParameterSetName = "Default",
        HelpUri = "https://github.com/socketlabs/socketlabs-powershell/blob/master/README.md"
        )]
    public class UpdateBounceDomain : ManagementApiCommandBase
    {

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Default")]
        public int ServerId { get; set; }

        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "Default")]
        public string Domain { get; set; }

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
            string url = $"{BASE_URL}/{ServerId}/bounce/{Domain}";

            if (ShouldProcess(url, "Update-BounceDomain"))
            {
                IRestProvider rest = new RestProvider(ApiKey);
                try
                {
                    var body = new { isDefault = IsDefault.ToBool() };
                    var result = rest.SendAsync<BounceDomainResult>(url, HttpMethod.Put, body).Result;
                    result.ServerId = ServerId;
                    base.WriteObject(result);
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
