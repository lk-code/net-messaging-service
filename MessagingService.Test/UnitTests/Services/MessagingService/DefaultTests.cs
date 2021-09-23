using MessagingService.Test.TestComponents.MessagingService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MessagingService.Test.UnitTests.Services.MessagingService
{
    [TestClass]
    public class DefaultTests
    {
        [TestMethod]
        public void TestDefaultSubscribeAndTrigger()
        {
            bool subscriptionReceived = false;
            IMessagingService messagingService = Startup.ServiceProvider.GetService<IMessagingService>();

            messagingService.Subscribe("demo-message", (IMessageArgument eventArgument) =>
            {
                subscriptionReceived = true;
            });

            messagingService.Trigger("demo-message", null);

            Assert.IsTrue(subscriptionReceived);
        }

        [TestMethod]
        public void TestDefaultSubscribeAndTriggerWithArgument()
        {
            bool testValue = false;
            bool expectedValue = true;
            IMessagingService messagingService = Startup.ServiceProvider.GetService<IMessagingService>();

            messagingService.Subscribe("demo-message-argument", (IMessageArgument eventArgument) =>
            {
                testValue = (eventArgument as TestArgument01).Success;
            });

            messagingService.Trigger("demo-message-argument", new TestArgument01 { Success = expectedValue });

            Assert.AreEqual(expectedValue, testValue);
        }
    }
}