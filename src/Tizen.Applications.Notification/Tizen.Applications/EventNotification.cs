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
using System.Runtime.InteropServices;

namespace Tizen.Applications.Notifications
{
    /// <summary>
    /// Class for creating a simple event notification
    /// </summary>
    /// <example>
    /// <code>
    /// public class EventNotificationExample
    /// {
    ///     /// ...
    ///     EventNotification noti = new EventNotification();
    ///     noti.EventCount = 2;
    ///     noti.Title = "Unread Messages";
    ///     NotificationManager.Post(noti);
    /// }
    /// </code>
    /// </example>
    public class EventNotification : Notification
    {
        /// <summary>
        /// Intializes instance of EventNotification class
        /// </summary>
        public EventNotification()
        {
            int ret;

            _handle = Interop.Notification.Create(NotificationType.Event);
            if (_handle.IsInvalid)
            {
                ret = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to create Event Notification");
            }

            ret = Interop.Notification.SetLayout(_handle, NotiLayout.SingleEvent);
            if(ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set event layout");
            }

            NotificationType = NotificationType.Event;
        }

        internal EventNotification(Interop.Notification.SafeNotificationHandle handle)
        {
            _handle = handle;

            NotificationType = NotificationType.Event;
        }

        /// <summary>
        /// Sets and gets the event count to be displayed on a Notification.
        /// </summary>
        /// <value>
        /// EventCount is a numeric value which is displayed on a notification.
        /// For example, to show unread message count on a messenger notification event count can be set.
        /// </value>
        /// <example>
        /// <code>
        /// EventNotification noti = new EventNotification();
        /// noti.EventCount = 2;
        /// Log.Debug(LogTag, "Event Count: " + noti.EventCount);
        /// </code>
        /// </example>
        public int EventCount
        {
            get
            {
                IntPtr countPtr;
                string count;
                int cnt;
                int ret = Interop.Notification.GetText(_handle, NotiText.EventCount, out countPtr);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "unable to get event count");
                    return 0;
                }

                if(countPtr == IntPtr.Zero)
                    return 0;

                count = Marshal.PtrToStringAnsi(countPtr);
                if(Int32.TryParse(count, out cnt))
                {
                    return cnt;
                }
                else
                {
                    Log.Warn(_logTag, "unable to parse string");
                    return 0;
                }
            }
            set
            {
                int ret;
                if(value <= 0)
                {
                    throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid value for event count");
                }

                ret = Interop.Notification.SetText(_handle, NotiText.EventCount, value.ToString(), null, -1);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set event count");
                }
            }
        }

        /// <summary>
        /// Gets and sets TimeStamp. Defaults to 0 ms UTC i.e 1 Jan 1970.
        /// </summary>
        /// <value>
        /// Timestamp can be used to display a timestamp on a notification.
        /// For example, in a message received notification, Timestamp can be used to display the time of message reception.
        /// </value>
        /// <example>
        /// <code>
        /// EventNotification noti = new EventNotification();
        /// noti.Timestamp = DateTime.Now;
        /// Log.Debug(LogTag, "Timestamp: " + noti.Timestamp);
        /// </code>
        /// </example>
        public DateTime Timestamp
        {
            get
            {
                int time;
                int ret = Interop.Notification.GetTime(_handle, out time);
                if(ret != (int)NotificationError.None)
                {
                    Log.Warn(_logTag, "unable to get timestamp");
                    return (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(0).ToLocalTime();
                }

                return (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(time).ToLocalTime();
            }
            set
            {
                int time = (int)value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                int ret = Interop.Notification.SetTime(_handle, time);
                if(ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set timestamp");
                }
            }
        }

        /// <summary>
        /// Method to add a button to an event notification
        /// </summary>
        /// <param name="index">Index of the Button to be added to notification</param>
        /// <param name="imagePath">Path of Button image</param>
        /// <param name="text">Text of button</param>
        /// <param name="appControl">App control to be invoke on button click</param>
        /// <remarks>
        /// AddButton method can be used to add 2 different types of buttons, one for positive response and one for negative.
        /// A button comprises of Image path for the button, Text for the button and an App control which is to be invoked on button click.
        /// </remarks>
        /// <example>
        /// <code>
        /// Application app = Application.Current;
        /// DirectoryInfo dir = app.DirectoryInfo;
        /// string imagePath = dir.Resource+"notification.png";
        /// string text = "Click";
        /// AppControl clickApp = new AppControl();
        /// clickApp.ApplicationId = "org.tizen.setting";        /// EventNotification noti = new EventNotification();
        /// noti.AddButton(ButtonIndex.Positive, imagePath, text, clickApp);
        /// </code>
        /// </example>
        public void AddButton(ButtonIndex index, string imagePath = "", string text = "", AppControl appControl = null)
        {
            int ret = Interop.Notification.SetImage(_handle, (NotiImage)((int)index + (int)NotiImage.PositiveButton), imagePath);
            if (ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "set button image path failed");
            }

            ret = Interop.Notification.SetText(_handle, (NotiText)((int)NotiText.PositiveButton + (int)index), text, null, -1);
            if (ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set button text");
            }

            if(appControl != null)
            {
                ret = Interop.Notification.SetEventHandler(_handle, (int)index, appControl.SafeAppControlHandle);
                if (ret != (int)NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set button event handler");
                }
            }

            ret = Interop.Notification.AddButton(_handle, (int)index + 1);
            if(ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to add button");
            }
        }

        /// <summary>
        /// Method to remove a button from an event notification
        /// </summary>
        /// <param name="index">Index of button to be removed</param>
        /// <remarks>
        /// RemoveButton method can be used to remove a button which has been added to the notification.
        /// RemoveButton should only be called after a button has been added.
        /// </remarks>
        /// <example>
        /// <code>
        /// EventNotification noti = new EventNotification();
        /// noti.AddButton(ButtonIndex.Positive);
        /// /// ...
        /// noti.RemoveButton(ButtonIndex.Negative);
        /// </code>
        /// </example>
        public void RemoveButton(ButtonIndex index)
        {
            int ret = Interop.Notification.RemoveButton(_handle, (int)index + 1);
            if(ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to remove button");
            }

            ret = Interop.Notification.SetImage(_handle, (NotiImage)((int)index + (int)NotiImage.PositiveButton), string.Empty);
            if (ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "set button image path failed");
            }

            ret = Interop.Notification.SetText(_handle, (NotiText)((int)NotiText.PositiveButton + (int)index), string.Empty, null, -1);
            if (ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set button text");
            }
        }
    }
}
