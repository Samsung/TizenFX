using System;

namespace Tizen.Applications.Notifications
{
    /// <summary>
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class NotificationViewerEventArgs : EventArgs
    {
        /// <summary>
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public NotificationViewerEventType EventType { get; internal set; }

        /// <summary>
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Notification Notification { get; internal set; }
    }
}