using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tizen.Applications;

namespace Tizen.Content.Download
{
    /// <summary>
    /// The Notification class consists of all the properties required to set notification for download operation.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Title of the notification.
        /// If user tries to get before setting, null is returned.
        /// </summary>
        public string Title
        {
            get
            {
            }
            set
            {
            }
        }

        /// <summary>
        /// Description of the notification.
        /// If user tries to get before setting, null is returned.
        /// </summary>
        public string Description
        {
            get
            {
            }
            set
            {
            }
        }

        /// <summary>
        /// Type of Notification.
        /// If user tries to get before setting, defaule NotificationType None is returned.
        /// </summary>
        public NotificationType Type
        {
            get
            {
            }
            set
            {
            }
        }

        /// <summary>
        /// AppControl for an ongoing download notification.
        /// If user tries to get before setting, null is returned.
        /// </summary>
        /// <remarks>
        /// When the notification message is clicked, the action is decided by the app control.
        /// </remarks>
        public AppControl AppControlOngoing
        {
            get
            {
            }
            set
            {
            }
        }

        /// <summary>
        /// AppControl for a completed download notification.
        /// If user tries to get before setting, null is returned.
        /// </summary>
        /// <remarks>
        /// When the notification message is clicked, the action is decided by the app control
        /// </remarks>
        public AppControl AppControlComplete
        {
            get
            {
            }
            set
            {
            }
        }

        /// <summary>
        /// AppControl for a failed download notification.
        /// If user tries to get before setting, null is returned.
        /// </summary>
        /// <remarks>
        /// When the notification message is clicked, the action is decided by the app control
        /// </remarks>
        public AppControl AppControlFail
        {
            get
            {
            }
            set
            {
            }
        }
    }
}

