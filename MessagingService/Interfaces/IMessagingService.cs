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

using System;

namespace MessagingService
{
    public interface IMessagingService
    {
        /// <summary>
        /// sends a message with the passed key and an empty argument (null)
        /// </summary>
        /// <param name="key">the message key to find the registered handlers</param>
        void Trigger(string key);
        /// <summary>
        /// sends a message with the passed key and argument (based on IMessageArgument)
        /// </summary>
        /// <param name="key">the message key to find the registered handlers</param>
        /// <param name="eventArgument">an argument for the message based on the IMessageArgument interface</param>
        void Trigger(string key, IMessageArgument eventArgument);
        /// <summary>
        /// subscribes a handler to a key
        /// </summary>
        /// <param name="key">the message key to find the registered handlers</param>
        /// <param name="eventAction">the action behind the handler</param>
        void Subscribe(string key, Action<IMessageArgument> eventAction);
    }
}
