using ManagementApi.Models;
using SocketLabsModule.Common.Services;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace ManagementApi.PowerShell.Commands
{
    /// <summary>
    /// Implementation for the Out-SocketLabs command.
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        "DkimKey",
        SupportsShouldProcess = true,
        DefaultParameterSetName = "Default",
        HelpUri = "https://github.com/socketlabs/socketlabs-powershell/blob/master/README.md"
        )]
    public class NewDkimKey : ManagementApiCommandBase
    {
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Default")]
        public int ServerId { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "Default")]
        public string Domain { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = "Default")]
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
            string url = $"{BASE_URL}/{ServerId}/dkim/generate?domain={Domain}&selector={Selector}";


            if (ShouldProcess(url, "New-DkimKey"))
            {
                IRestProvider rest = new RestProvider(ApiKey);
                try
                {

                    var result = rest.GetAsync<DkimKeyGeneratedResult>(url).Result;
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
