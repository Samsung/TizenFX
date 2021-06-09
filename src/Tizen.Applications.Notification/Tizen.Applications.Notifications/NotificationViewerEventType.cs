
using System.ComponentModel;

namespace Tizen.Applications.Notifications
{
    /// <summary>
    /// Enumeration for event type on notification.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum NotificationViewerEventType
    {
        /// <summary>
        /// Event type : Click on button 1.
        /// </summary>
        ClickOnButton1 = 0,

        /// <summary>
        /// Event type : Click on button 2.
        /// </summary>
        ClickOnButton2,

        /// <summary>
        /// Event type : Click on button 3.
        /// </summary>
        ClickOnButton3,

        /// <summary>
        /// Event type : Click on text_input button.
        /// </summary>
        ClickOnReplyButton = 8,

        /// <summary>
        /// Event type : Hidden by user.
        /// </summary>
        HiddenByUser = 100,

        /// <summary>
        /// Event type : Deleted by timer.
        /// </summary>
        HiddenByTimeout = 101,

        /// <summary>
        /// Event type : Deleted by timer.
        /// </summary>
        HiddenByExternal = 102,

        /// <summary>
        /// Event type : Clicked by user.
        /// </summary>
        ClickOnNotification = 200,

        /// <summary>
        /// Event type : Deleted by user.
        /// </summary>
        DeleteNotification = 201,
    }
}
