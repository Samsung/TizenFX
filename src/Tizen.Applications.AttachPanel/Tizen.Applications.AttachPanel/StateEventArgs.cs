using System;

namespace Tizen.Applications.AttachPanel
{
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

        public IntPtr AttachPanel { get { return _attachPanel;  } }

        public EventType EventType { get { return _eventType;  } }

        public IntPtr EventInfo {  get { return _eventInfo;  } }

        public IntPtr UserData { get { return _userData; } }
    }
}
