using System.Management.Automation;

namespace SocketLabsModule.Common
{
    public class PipelineCommandBase : PSCmdlet
    {
        [Parameter(ValueFromPipeline = true)]
        public PSObject InputObject { get; set; }
    }
}
