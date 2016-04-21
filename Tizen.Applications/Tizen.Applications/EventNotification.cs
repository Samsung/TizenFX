// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

namespace Tizen.Applications.Notifications
{
    /// <summary>
    /// Class for creating either SingleEvent notifications or MultiEvent notifications
    /// </summary>
    public class EventNotification : Notification
    {
        /// <summary>
        /// Class contructor
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

                count = Marshal.PtrToStringAuto(countPtr);
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
        /// Method to add a button
        /// </summary>
        /// <param name="index">Index of the Button to be added to notification</param>
        /// <param name="imagePath">Path of Button image</param>
        /// <param name="text">Text of button</param>
        /// <param name="appControl">App control to be invoke on button click</param>
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
        /// Method to remove a button
        /// </summary>
        /// <param name="index">Index of button to be removed</param>
        public void RemoveButton(ButtonIndex index)
        {
            AppControl app = new AppControl();

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

            ret = Interop.Notification.SetEventHandler(_handle, (int)index, app.SafeAppControlHandle);
            if (ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to set button event handler");
            }
        }
    }
}
