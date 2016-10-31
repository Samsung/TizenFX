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

namespace Tizen.Applications.Notifications
{
    /// <summary>
    /// Class for creating progress notifications
    /// </summary>
    public class ProgressNotification : Notification
    {
        /// <summary>
        /// Intializes instance of ProgressNotification class
        /// </summary>
        public ProgressNotification()
        {
            int ret;

            _handle = Interop.Notification.Create(NotificationType.Progress);
            if (_handle.IsInvalid)
            {
                ret = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to create Progress Notification");
            }

            ret = Interop.Notification.SetLayout(_handle, NotiLayout.Progress);
            if(ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set progress layout");
            }

            ret = Interop.Notification.SetProgressSize(_handle, 100.0);
            if(ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set default progress size");
            }

            NotificationType = NotificationType.Progress;
        }

        internal ProgressNotification(Interop.Notification.SafeNotificationHandle handle)
        {
            _handle = handle;

            NotificationType = NotificationType.Progress;
        }

        /// <summary>
        /// Gets and sets maximum value for progress ticker. Defaults to 100.
        /// </summary>
        /// <value>
        /// Maximum should not be less than 0.
        /// </value>
        /// <example>
        /// <code>
        /// ProgressNotification noti = new ProgressNotification();
        /// noti.Maximum = 200;
        /// Log.Debug(LogTag, "Maximum: " + noti.Maximum);
        /// </code>
        /// </example>
        /// <exception cref="ArgumentException">Thrown when value of Maximum being set is less than 0</exception>
        public double Maximum
        {
            get
            {
                double size;
                int ret = Interop.Notification.GetProgressSize(_handle, out size);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "get progress size failed");
                    return 100.0;
                }

                return size;
            }
            set
            {
                if(value < 0)
                {
                    throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "wrong value for progress size");
                }

                int ret = Interop.Notification.SetProgressSize(_handle, value);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "set progress size failed");
                }
            }
        }

        /// <summary>
        /// gets and sets current progress value for ticker. Defaults to 0.
        /// </summary>
        /// <value>
        /// ProgressValue should not be less than 0 or greater than Maximum.
        /// </value>
        /// <example>
        /// <code>
        /// ProgressNotification noti = new ProgressNotification();
        /// noti.Maximum = 200;
        /// noti.ProgressValue = 100;
        /// Log.Debug(LogTag, "Progress Value: " + noti.ProgressValue);
        /// </code>
        /// </example>
        /// <exception cref="ArgumentException">Thrown when value of ProgressValue being set is less than 0 or greater than value of Maximum</exception>
        public double ProgressValue
        {
            get
            {
                double size;
                int ret = Interop.Notification.GetProgress(_handle, out size);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "get progress failed");
                    return 0;
                }

                return size;
            }
            set
            {
                if(value < 0 || value > Maximum)
                {
                    throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "wrong value for progress value");
                }

                int ret = Interop.Notification.SetProgress(_handle, value);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "set progress failed");
                }
            }
        }
    }
}
