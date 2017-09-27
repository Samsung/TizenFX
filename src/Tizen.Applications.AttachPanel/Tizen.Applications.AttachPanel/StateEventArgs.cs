using System;

namespace Tizen.Applications.AttachPanel
{
    /// <summary>
    /// Class for event arguments of the state event
    /// </summary>
    public class StateEventArgs : EventArgs
    {
        private readonly EventType _eventType;

        internal StateEventArgs(EventType eventType)
        {
            _eventType = eventType;
        }

        /// <summary>
        /// Property for event type.
        /// </summary>
        public EventType EventType
        {
            get
            {
                return _eventType;
            }
        }
    }
}
