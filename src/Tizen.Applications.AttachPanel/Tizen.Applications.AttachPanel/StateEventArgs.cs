using System;

namespace Tizen.Applications.AttachPanel
{
    /// <summary>
    /// Class for event arguments of the state event
    /// </summary>
    public class StateEventArgs : EventArgs
    {
        private readonly IntPtr _attachPanel;
        private readonly EventType _eventType;
        private readonly IntPtr _eventInfo;
        private readonly IntPtr _userData;

        internal StateEventArgs(IntPtr attachPanel, EventType eventType, IntPtr eventInfo, IntPtr userData)
        {
            _attachPanel = attachPanel;
            _eventType = eventType;
            _eventInfo = eventInfo;
            _userData = userData;
        }

        /// <summary>
        /// Property for attach panel object
        /// </summary>
        public IntPtr AttachPanel { get { return _attachPanel;  } }

        /// <summary>
        /// Property for event type.
        /// </summary>
        public EventType EventType { get { return _eventType;  } }

        /// <summary>
        /// Additional event information.
        /// This can be NULL if there are no necessary information.
        /// </summary>
        public IntPtr EventInfo {  get { return _eventInfo;  } }

        /// <summary>
        /// Property for user data.
        /// </summary>
        public IntPtr UserData { get { return _userData; } }
    }
}
