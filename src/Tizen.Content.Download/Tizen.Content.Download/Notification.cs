/*
* Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
*
* Licensed under the Apache License, Version 2.0 (the License);
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an AS IS BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using Tizen.Applications;

namespace Tizen.Content.Download
{
    /// <summary>
    /// The Notification class consists of all the properties required to set notifications for the download operation.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Notification
    {
        private int _downloadId;

        internal Notification(int requestId)
        {
            _downloadId = requestId;
        }

        /// <summary>
        /// Title of the notification.
        /// If a user tries to get before the setting, an empty string is returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <feature>http://tizen.org/feature/download</feature>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported.</exception>
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
                int ret = Interop.Download.SetNotificationTitle(_downloadId, value);
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to set Notification Title");
                }
            }
        }

        /// <summary>
        /// Description of the notification.
        /// If a user tries to get before the setting, an empty string is returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <feature>http://tizen.org/feature/download</feature>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported.</exception>
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
                int ret = Interop.Download.SetNotificationDescription(_downloadId, value);
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to set Notification Description");
                }
            }
        }

        /// <summary>
        /// Type of the notification.
        /// If a user tries to get before the setting, the default NotificationType none is returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <feature>http://tizen.org/feature/download</feature>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported.</exception>
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
        /// If a user tries to get before the setting, null is returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <feature>http://tizen.org/feature/download</feature>
        /// <remarks>
        /// When the notification message is clicked, the action is decided by the application control.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported.</exception>
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
        /// If a user tries to get before the setting, null is returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <feature>http://tizen.org/feature/download</feature>
        /// <remarks>
        /// When the notification message is clicked, the action is decided by the application control.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported.</exception>
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
        /// If a user tries to get before the setting, null is returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <feature>http://tizen.org/feature/download</feature>
        /// <remarks>
        /// When the notification message is clicked, the action is decided by the application control.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when it is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when feature is not supported.</exception>
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

