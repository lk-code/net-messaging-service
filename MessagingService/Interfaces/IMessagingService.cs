using System;

namespace MessagingService
{
    public interface IMessagingService
    {
        void Trigger(string key);
        void Trigger(string key, IMessageArgument eventArgument);
        void Subscribe(string key, Action<IMessageArgument> eventAction);
    }
}
