using InjectionApi.Utilities;
using SocketLabs.InjectionApi;
using SocketLabs.InjectionApi.Message;
using System;
using System.Collections.ObjectModel;
using System.Management.Automation;

namespace InjectionApi.PowerShell.Commands
{
    /// <summary>
    /// Implementation for the Out-SocketLabs command.
    /// </summary>
    [Cmdlet(VerbsData.Out, "SocketLabs", SupportsShouldProcess = true, DefaultParameterSetName = "Default", HelpUri = "https://github.com/socketlabs/socketlabs-powershell/blob/master/README.md")]
    public class OutSocketLabsCommand : SocketLabsCommandBase
    {
        /// <summary>
        /// The sender email addresses to send the command output from.
        /// </summary>
        [Alias("From")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Default")]
        public string Sender { get; set; }

        /// <summary>
        /// The recipient email addresses to receive the command output.
        /// </summary>
        [Alias("To")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "Default")]
        public string[] Recipients { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = "Default")]
        public string Subject { get; set; }

        [Parameter(Position = 3, ParameterSetName = "Default")]
        public string InjectionApiKey { get; set; }

        [Parameter(Position = 4, ParameterSetName = "Default")]
        public int ServerId { get; set; }

        [Parameter(Position = 5, ParameterSetName = "Default")]
        public SwitchParameter PassThru { get; set; }

        private readonly Collection<PSObject> _psObjects;
        private string _body;

        public OutSocketLabsCommand()
        {
            _psObjects = new Collection<PSObject>();
        }

        protected override void BeginProcessing()
        {
            this.InjectionApiKey = this.InjectionApiKey ?? Environment.GetEnvironmentVariable("SL_API_KEY");

            if (String.IsNullOrEmpty(this.InjectionApiKey))
                throw new PSArgumentNullException(nameof(this.InjectionApiKey));

            if (this.ServerId == 0)
            {
                if (int.TryParse(Environment.GetEnvironmentVariable("SL_SERVER_ID"), out int serverId))
                {
                    ServerId = serverId;
                }
                else
                {
                    throw new PSArgumentException("Invalid value for ServerId", nameof(this.ServerId));
                }
            }

            base.BeginProcessing();
        }

        protected override void EndProcessing()
        {
            if (ShouldProcess(nameof(EndProcessing)))
            {
                ProcessObjects(_psObjects);
                var response = InjectMessage();

                if (response.Result != SendResult.Success)
                    throw new Exception($"Error sending message: {response.ResponseMessage}");

                base.EndProcessing();
            }
        }

        protected override void ProcessRecord()
        {
            if (ShouldProcess(nameof(ProcessRecord)))
            {
                // Pass the object through the pipeline.
                if (PassThru)
                    this.WriteObject(this.InputObject);

                _psObjects.Add(this.InputObject);
            }
        }

        public void ProcessObjects(object obj)
        {
            using (var ps = System.Management.Automation.PowerShell.Create())
            {
                ps.AddCommand("Format-Table");
                ps.AddParameter("InputObject", obj);
                var result = ps.Invoke();

                ps.AddCommand("Out-String");
                ps.AddParameter("InputObject", result);
                result = ps.Invoke();

                _body = result?[0].BaseObject as string;
            }
        }

        public SendResponse InjectMessage()
        {
            var html = MessageTemplate.BuildHtmlMessage(_body);
            using (var client = new SocketLabsClient(this.ServerId, this.InjectionApiKey))
            {
                var message = new BasicMessage();
                message.Subject = this.Subject;
                message.HtmlBody = html;
                message.PlainTextBody = _body;
                message.From.Email = this.Sender;

                foreach (var recipient in this.Recipients)
                {
                    message.To.Add(recipient);
                }

                return client.Send(message);
            }
        }
    }
}
