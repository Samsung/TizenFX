using System;

namespace Tizen.Applications.Notifications
{
    /// <summary>
    /// The EventArgs for the notification response
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class NotificationResponseEventArgs : EventArgs
    {
        /// <summary>
        /// The type of response
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public NotificationResponseEventType EventType { get; internal set; }

        /// <summary>
        /// The response's target notification
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Notification Notification { get; internal set; }
    }
}