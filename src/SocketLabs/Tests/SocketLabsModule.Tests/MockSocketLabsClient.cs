using SocketLabs.InjectionApi;
using SocketLabs.InjectionApi.Message;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocketLabsModule.Tests
{
    public sealed class MockSocketLabsClient : ISocketLabsClient
    {
        public SendResponse Send(IBasicMessage message)
        {
            return new SendResponse() { Result = SendResult.Success };
        }

        public SendResponse Send(IBulkMessage message)
        {
            return new SendResponse() { Result = SendResult.Success };
        }

        public Task<SendResponse> SendAsync(IBasicMessage message)
        {
            return Task.Run(() => new SendResponse() { Result = SendResult.Success });
        }

        public Task<SendResponse> SendAsync(IBulkMessage message)
        {
            return Task.Run(() => new SendResponse() { Result = SendResult.Success });
        }
    }
}
