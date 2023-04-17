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
        VerbsCommon.Remove,
        "DkimEntries",
        SupportsShouldProcess = true,
        DefaultParameterSetName = "Default",
        HelpUri = "https://github.com/socketlabs/socketlabs-powershell/blob/master/README.md"
        )]
    public class RemoveDkimEntries : ManagementApiCommandBase
    {
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Default")]
        public int ServerId { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "Default")]
        public string Domain { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = "Default")]
        public string Selector { get; set; }

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
                string url = $"{BASE_URL}/{ServerId}/dkim/{Domain}";
                var qsp = new Dictionary<string, string>()
                {
                    { "selector", Selector }
                };
                url = AddQueryStrings(url, qsp);

                if (ShouldProcess(url, "Remove-DkimEntry"))
                {
                    IRestProvider rest = new RestProvider(ApiKey);
                    try
                    {
                        var result = rest.DeleteAsync<string>(url).Result;

                        if (String.IsNullOrEmpty(result))
                        {
                            result = $"Domain: {Domain} DKIM key has been removed.";
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
                foreach (var item in DkimKeys)
                {
                    string url = $"{BASE_URL}/{item.ServerId}/bounce/{item.Domain}";

                    if (ShouldProcess(url, "Remove-DkimEntry"))
                    {

                        IRestProvider rest = new RestProvider(ApiKey);
                        try
                        {
                            var result = rest.DeleteAsync<string>(url).Result;

                            if (String.IsNullOrEmpty(result))
                            {
                                result = $"Domain: {Domain} DKIM key has been removed.";
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
