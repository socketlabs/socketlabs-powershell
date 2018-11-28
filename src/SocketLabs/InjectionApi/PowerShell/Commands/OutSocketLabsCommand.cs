using System;
using System.Text;
using System.Management.Automation;
using System.Management.Automation.Internal;
using System.Management.Automation.Host;
using System.IO;
using Microsoft.PowerShell.Commands.Internal.Format;

namespace InjectionApi.PowerShell.Commands
{
    /// <summary>
    /// Implementation for the Out-SocketLabs command.
    /// </summary>
    [Cmdlet(VerbsData.Out, "SocketLabs", SupportsShouldProcess = true, DefaultParameterSetName = "Addresses", HelpUri = "https://github.com/socketlabs/socketlabs-powershell/blob/master/README.md")]
    public class OutSocketLabsCommand : FrontEndCommandBase
    {
        /// <summary>
        /// The sender email addresses to send the command output from.
        /// </summary>
        [Alias("From")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Addresses")]
        public string Sender { get; set; }

        /// <summary>
        /// The recipient email addresses to receive the command output.
        /// </summary>
        [Alias("To")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "Addresses")]
        public string[] Recipients { get; set; }

        private string _body;

        public OutSocketLabsCommand()
        {           
        }

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
            base.ProcessRecord();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
