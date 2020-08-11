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
        "DkimEntry",
        SupportsShouldProcess = true,
        DefaultParameterSetName = "Default",
        HelpUri = "https://github.com/socketlabs/socketlabs-powershell/blob/master/README.md"
        )]
    public class NewDkimEntry : ManagementApiCommandBase
    {
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Default")]
        public int ServerId { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "Default")]
        public string Domain { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = "Default")]
        public string Selector { get; set; }

        [Parameter(Mandatory = true, Position = 3, ParameterSetName = "Default")]
        public string PrivateKey { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = "Pipeline", DontShow = true)]
        public DkimKeyGeneratedResult[] DkimKeys { get; set; }


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
            if (DkimKeys == null)
            {
                string url = $"{BASE_URL}/{ServerId}/dkim";

                if (ShouldProcess(url, "New-DkimEntry"))
                {
                    IRestProvider rest = new RestProvider(ApiKey);
                    try
                    {
                        var dkimRequest = new DkimKeyRequest()
                        {
                            Domain = Domain,
                            Selector = Selector,
                            PrivateKey = PrivateKey
                        };
                        var result = rest.PostAsync<DkimKeyResult>(url, dkimRequest).Result;
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
            else
            {
                foreach (var item in DkimKeys)
                {
                    string url = $"{BASE_URL}/{item.ServerId}/dkim";

                    if (ShouldProcess(url, "New-DkimEntry"))
                    {

                        IRestProvider rest = new RestProvider(ApiKey);
                        try
                        {
                            var dkimRequest = new DkimKeyRequest(item);
                            var result = rest.PostAsync<DkimKeyResult>(url, dkimRequest).Result;
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
            }
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
        }
    }
}
