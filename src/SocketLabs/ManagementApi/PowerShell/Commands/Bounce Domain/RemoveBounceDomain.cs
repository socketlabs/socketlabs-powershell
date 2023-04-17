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
    /// Implementation for the Remove-BounceDomain command.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        "BounceDomain",
        SupportsShouldProcess = true,
        DefaultParameterSetName = "Default",
        HelpUri = "https://github.com/socketlabs/socketlabs-powershell/blob/master/README.md"
        )]
    public class RemoveBounceDomain : ManagementApiCommandBase
    {
        [Parameter(ValueFromPipeline = true, ParameterSetName = "Pipeline", DontShow = true)]
        public BounceDomain[] BounceDomains { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Default")]
        public int ServerId { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "Default")]
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

            if (BounceDomains == null)
            {
                string url = $"{BASE_URL}/{ServerId}/bounce/{Domain}";

                if (ShouldProcess(url, "Remove-BounceDomain"))
                {
                    IRestProvider rest = new RestProvider(ApiKey);
                    try
                    {
                        var result = rest.DeleteAsync<string>(url).Result;

                        if (String.IsNullOrEmpty(result))
                        {
                            result = $"Domain: {Domain} has been removed.";
                        }

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
                foreach (var item in BounceDomains)
                {
                    string url = $"{BASE_URL}/{item.ServerId}/bounce/{item.Domain}";

                    if (ShouldProcess(url, "Remove-BounceDomain"))
                    {

                        IRestProvider rest = new RestProvider(ApiKey);
                        try
                        {
                            var result = rest.DeleteAsync<string>(url).Result;

                            if (String.IsNullOrEmpty(result))
                            {
                                result = $"Domain: {item.Domain} has been removed.";
                            }

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
