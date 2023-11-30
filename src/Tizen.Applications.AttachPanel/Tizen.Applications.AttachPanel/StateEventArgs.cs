using System;

namespace Tizen.Applications.AttachPanel
{
    /// <summary>
    /// A class for the event arguments of the state event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API Level 12. Will be removed in API Level 14.")]
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
        [Obsolete("Deprecated since API Level 12. Will be removed in API Level 14.")]
        public EventType EventType
        {
            get
            {
                return _eventType;
            }
        }
    }
}
