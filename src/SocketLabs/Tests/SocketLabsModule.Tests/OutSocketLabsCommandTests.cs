using InjectionApi.PowerShell.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocketLabs.InjectionApi;
using System;
using System.Management.Automation;


namespace SocketLabsModule.Tests
{
    [TestClass]
    public class OutSocketLabsCommandTests : OutSocketLabsCommand
    {
        private const string SL_API_KEY = "XXXXXXXXXXXXXX";
        private const string SL_SERVER_ID = "1000";
        private const int SL_SERVER_ID_INT = 1000;

        public OutSocketLabsCommandTests()
            : base(new MockSocketLabsClient())
        {
            Environment.SetEnvironmentVariable("SL_API_KEY", SL_API_KEY);
            Environment.SetEnvironmentVariable("SL_SERVER_ID", SL_SERVER_ID);
        }

        [TestInitialize]
        public void Initilialize()
        {
            base.BeginProcessing();
            base.InputObject = new PSObject(nameof(OutSocketLabsCommandTests));
            base.Recipients = new string[] { "test@example.com", "test2@example.com" };
            base.Sender = "sender@example.com";
            base.Subject = "Test subject";
        }

        [TestMethod]
        public void InjectionApiKeyShouldBeSet()
        {
            Assert.AreEqual(base.InjectionApiKey, SL_API_KEY);
        }

        [TestMethod]
        public void ServerIdShouldBeSet()
        {
            Assert.AreEqual(base.ServerId, SL_SERVER_ID_INT);
        }

        [TestMethod]
        public void MessageShouldSend()
        {
            var response = base.InjectMessage();
            
            Assert.AreEqual(response.Result, SendResult.Success);
        }
    }
}
