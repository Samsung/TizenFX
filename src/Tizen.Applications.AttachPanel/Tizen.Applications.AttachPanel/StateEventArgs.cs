using System;

namespace Tizen.Applications.AttachPanel
{
    /// <summary>
    /// A class for the event arguments of the state event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class StateEventArgs : EventArgs
    {
        private readonly EventType _eventType;

        internal StateEventArgs(EventType eventType)
        {
            _eventType = eventType;
        }

        /// <summary>
        /// Property for the event type.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public EventType EventType
        {
            get
            {
                return _eventType;
            }
        }
    }
}
