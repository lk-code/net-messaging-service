using System;
using System.Collections.Generic;

namespace MessagingService
{
    public class MessagingService : IMessagingService
    {
        #region # events #

        #endregion

        #region # dependencies #

        #endregion

        #region # private properties #

        private Dictionary<string, List<Action<IMessageArgument>>> _eventHandlers = null;

        #endregion

        #region # public properties #

        #endregion

        #region # constructors #

        public MessagingService()
        {
            this._eventHandlers = new Dictionary<string, List<Action<IMessageArgument>>>();
        }

        #endregion

        #region # public methods #

        public void Trigger(string key, IMessageArgument eventArgument)
        {
            List<Action<IMessageArgument>> eventActions = new List<Action<IMessageArgument>>();

            if (this._eventHandlers.ContainsKey(key))
            {
                eventActions = this._eventHandlers[key];
            }

            if (eventActions.Count > 0)
            {
                foreach (Action<IMessageArgument> eventAction in eventActions)
                {
                    eventAction(eventArgument);
                }
            }
        }

        public void Trigger(string key)
        {
            this.Trigger(key, null);
        }

        public void Subscribe(string key, Action<IMessageArgument> eventAction)
        {
            List<Action<IMessageArgument>> eventActions = new List<Action<IMessageArgument>>();

            if (this._eventHandlers.ContainsKey(key))
            {
                eventActions = this._eventHandlers[key];
            }

            eventActions.Add(eventAction);

            this._eventHandlers[key] = eventActions;
        }

        #endregion

        #region # private logic #

        #endregion
    }
}