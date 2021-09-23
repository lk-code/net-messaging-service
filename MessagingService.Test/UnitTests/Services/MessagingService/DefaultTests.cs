/**
 * MIT License
 * 
 * Copyright (c) 2021 lk-code
 * see more at https://github.com/lk-code/net-messaging-service
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using MessagingService.Test.TestComponents.MessagingService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MessagingService.Test.UnitTests.Services.MessagingService
{
    [TestClass]
    public class DefaultTests
    {
        /// <summary>
        /// tests the messaging service without an argument
        /// </summary>
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

        /// <summary>
        /// tests the messaging service with an argument
        /// </summary>
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