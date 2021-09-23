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
    }
}