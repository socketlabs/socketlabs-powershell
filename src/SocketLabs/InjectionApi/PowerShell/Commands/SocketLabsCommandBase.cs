using System.Management.Automation;

namespace InjectionApi.PowerShell.Commands
{
    public class SocketLabsCommandBase : PSCmdlet
    {
        [Parameter(ValueFromPipeline = true)]
        public PSObject InputObject { get; set; }
    }
}
