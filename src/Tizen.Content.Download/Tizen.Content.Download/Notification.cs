// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using Tizen.Applications;

namespace Tizen.Content.Download
{
    /// <summary>
    /// The Notification class consists of all the properties required to set notifications for download operation.
    /// </summary>
    public class Notification
    {
        private int _downloadId;

        public Notification(int requestId)
        {
            _downloadId = requestId;
        }

        /// <summary>
        /// Title of the notification.
        /// If user tries to get before setting, empty string is returned.
        /// </summary>
        public string Title
        {
            get
            {
                string title;
                int ret = Interop.Download.GetNotificationTitle(_downloadId, out title);
                if (ret != (int)DownloadError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get Notification Title, " + (DownloadError)ret);
                    return String.Empty;
                }
                return title;
            }
            set
            {
                int ret = Interop.Download.SetNotificationTitle(_downloadId, value.ToString());
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to set Notification Title");
                }
            }
        }

        /// <summary>
        /// Description of the notification.
        /// If user tries to get before setting, empty string is returned.
        /// </summary>
        public string Description
        {
            get
            {
                string description;
                int ret = Interop.Download.GetNotificationDescription(_downloadId, out description);
                if (ret != (int)DownloadError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get Notification Description, " + (DownloadError)ret);
                    return String.Empty;
                }
                return description;
            }
            set
            {
                int ret = Interop.Download.SetNotificationDescription(_downloadId, value.ToString());
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to set Notification Description");
                }
            }
        }

        /// <summary>
        /// Type of Notification.
        /// If user tries to get before setting, default NotificationType None is returned.
        /// </summary>
        public NotificationType Type
        {
            get
            {
                int type;
                int ret = Interop.Download.GetNotificationType(_downloadId, out type);
                if (ret != (int)DownloadError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get NotificationType, " + (DownloadError)ret);
                    return 0;
                }
                return (NotificationType)type;
            }
            set
            {
                int ret = Interop.Download.SetNotificationType(_downloadId, (int)value);
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to set NotificationType");
                }
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
                SafeAppControlHandle handle;
                int ret = Interop.Download.GetNotificationAppControl(_downloadId, (int)NotificationAppControlType.Downloading, out handle);
                if (ret != (int)DownloadError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get Ongoing type NotificationAppControl, " + (DownloadError)ret);
                    return null;
                }
                return new AppControl(handle);
            }
            set
            {
                int ret = Interop.Download.SetNotificationAppControl(_downloadId, (int)NotificationAppControlType.Downloading, value.SafeAppControlHandle);
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to set Ongoing type NotificationAppControl");
                }
            }
        }

        /// <summary>
        /// AppControl for a completed download notification.
        /// If user tries to get before setting, null is returned.
        /// </summary>
        /// <remarks>
        /// When the notification message is clicked, the action is decided by the app control
        /// </remarks>
        public AppControl AppControlCompleted
        {
            get
            {
                SafeAppControlHandle handle;
                int ret = Interop.Download.GetNotificationAppControl(_downloadId, (int)NotificationAppControlType.Completed, out handle);
                if (ret != (int)DownloadError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get Complete type NotificationAppControl, " + (DownloadError)ret);
                    return null;
                }
                return new AppControl(handle);
            }
            set
            {
                int ret = Interop.Download.SetNotificationAppControl(_downloadId, (int)NotificationAppControlType.Completed, value.SafeAppControlHandle);
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to set Complete type NotificationAppControl");
                }
            }
        }

        /// <summary>
        /// AppControl for a failed download notification.
        /// If user tries to get before setting, null is returned.
        /// </summary>
        /// <remarks>
        /// When the notification message is clicked, the action is decided by the app control
        /// </remarks>
        public AppControl AppControlFailed
        {
            get
            {
                SafeAppControlHandle handle;
                int ret = Interop.Download.GetNotificationAppControl(_downloadId, (int)NotificationAppControlType.Failed, out handle);
                if (ret != (int)DownloadError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get Fail type NotificationAppControl, " + (DownloadError)ret);
                    return null;
                }
                return new AppControl(handle);
            }
            set
            {
                int ret = Interop.Download.SetNotificationAppControl(_downloadId, (int)NotificationAppControlType.Failed, value.SafeAppControlHandle);
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to set Fail type NotificationAppControl");
                }
            }
        }
    }
}

