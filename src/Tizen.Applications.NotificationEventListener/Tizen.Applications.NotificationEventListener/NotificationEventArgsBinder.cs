/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.NotificationEventListener
{
    using System;

    internal static class NotificationEventArgsBinder
    {
        private const string LogTag = "Tizen.Applications.NotificationEventListener";

        internal static NotificationEventArgs BindObject(IntPtr notification, bool data)
        {
            Interop.NotificationEventListener.ErrorCode err;
            int time;
            int uniqueNumber = -1;
            int groupNumber = -1;
            int property;
            int doNotShowTimeStamp = -1;
            int displayList;
            bool eventFlag = false;
            NotificationLayout layout;
            NotificationType type;
            string text;
            IntPtr extension = IntPtr.Zero;
            IntPtr dummy = IntPtr.Zero;
            SafeAppControlHandle appcontrol = null;

            bool checkBoxFlag = false;
            bool checkedValue = false;

            NotificationEventArgs eventargs = new NotificationEventArgs();

            eventargs.Handle = new Interop.NotificationEventListener.NotificationSafeHandle(notification, data);

            err = Interop.NotificationEventListener.GetID(eventargs.Handle, out groupNumber, out uniqueNumber);
            if (err != Interop.NotificationEventListener.ErrorCode.None)
            {
                Log.Error(LogTag, "unable to get UniqueNumber");
            }

            eventargs.UniqueNumber = uniqueNumber;

            Interop.NotificationEventListener.GetAppId(eventargs.Handle, out text);
            if (string.IsNullOrEmpty(text) == false)
            {
                eventargs.AppID = text;
            }

            Interop.NotificationEventListener.GetText(eventargs.Handle, NotificationText.Title, out text);
            if (string.IsNullOrEmpty(text) == false)
            {
                eventargs.Title = text;
            }

            Interop.NotificationEventListener.GetText(eventargs.Handle, NotificationText.Content, out text);
            if (string.IsNullOrEmpty(text) == false)
            {
                eventargs.Content = text;
            }

            Interop.NotificationEventListener.GetImage(eventargs.Handle, NotificationImage.Icon, out text);
            if (string.IsNullOrEmpty(text) == false)
            {
                eventargs.Icon = text;
            }

            Interop.NotificationEventListener.GetImage(eventargs.Handle, NotificationImage.SubIcon, out text);
            if (string.IsNullOrEmpty(text) == false)
            {
                eventargs.SubIcon = text;
            }

            Interop.NotificationEventListener.GetText(eventargs.Handle, NotificationText.GroupTitle, out text);
            if (string.IsNullOrEmpty(text) == false)
            {
                eventargs.GroupTitle = text;
            }

            Interop.NotificationEventListener.GetText(eventargs.Handle, NotificationText.GroupContent, out text);
            if (string.IsNullOrEmpty(text) == false)
            {
                eventargs.GroupContent = text;
            }

            err = Interop.NotificationEventListener.GetTime(eventargs.Handle, out time);
            if (err != Interop.NotificationEventListener.ErrorCode.None)
            {
                Log.Info(LogTag, "unable to get TimeStamp");
            }

            if (time == doNotShowTimeStamp)
            {
                eventargs.IsTimeStampVisible = false;
            }
            else
            {
                eventargs.IsTimeStampVisible = true;

                if (time == 0)
                {
                    err = Interop.NotificationEventListener.GetInsertTime(eventargs.Handle, out time);
                    if (err != Interop.NotificationEventListener.ErrorCode.None)
                    {
                        Log.Info(LogTag, "unable to get InsertTime");
                    }
                }

                eventargs.TimeStamp = (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(time).ToLocalTime();
            }

            err = Interop.NotificationEventListener.GetText(eventargs.Handle, NotificationText.EventCount, out text);
            if (err != Interop.NotificationEventListener.ErrorCode.None)
            {
                Log.Info(LogTag, "unable to get Event Count");
            }

            if (string.IsNullOrEmpty(text) == false)
            {
                try
                {
                    eventargs.Count = int.Parse(text);
                }
                catch (Exception ex)
                {
                    Log.Error(LogTag, ex.ToString());
                }
            }

            err = Interop.NotificationEventListener.GetAppControl(eventargs.Handle, LaunchOption.AppControl, out appcontrol);
            if (err != Interop.NotificationEventListener.ErrorCode.None)
            {
                Log.Info(LogTag, "unable to get Action");
            }

            if (appcontrol != null && appcontrol.IsInvalid == false)
            {
                eventargs.Action = new AppControl(appcontrol);
            }

            Interop.NotificationEventListener.GetTag(eventargs.Handle, out text);
            if (string.IsNullOrEmpty(text) == false)
            {
                eventargs.Tag = text;
            }

            err = Interop.NotificationEventListener.GetProperties(eventargs.Handle, out property);
            if (err != Interop.NotificationEventListener.ErrorCode.None)
            {
                Log.Info(LogTag, "unable to get Property");
            }
            else
            {
                eventargs.Property = (NotificationProperty)property;
            }

            Interop.NotificationEventListener.GetStyleList(eventargs.Handle, out displayList);
            if ((displayList & (int)NotificationDisplayApplist.Tray) == 0)
            {
                eventargs.IsVisible = false;
            }

            err = Interop.NotificationEventListener.GetExtensionBundle(eventargs.Handle, out extension, out dummy);
            if (err != Interop.NotificationEventListener.ErrorCode.None)
            {
                Log.Info(LogTag, "unable to get Extender");
            }

            if (extension != IntPtr.Zero)
            {
                Bundle bundle = new Bundle(new SafeBundleHandle(extension, false));
                foreach (string key in bundle.Keys)
                {
                    if (key.StartsWith("_NOTIFICATION_EXTENSION_EVENT_") || key.StartsWith("_NOTIFICATION_TYPE_PAIRING_"))
                        continue;

                    SafeBundleHandle sbh;
                    Interop.NotificationEventListener.GetExtender(eventargs.Handle, key, out sbh);
                    eventargs.ExtraData.Add(key, new Bundle(sbh));
                }
            }

            err = Interop.NotificationEventListener.GetLayout(eventargs.Handle, out layout);
            if (err != Interop.NotificationEventListener.ErrorCode.None)
            {
                Log.Info(LogTag, "unable to get layout");
            }

            err = Interop.NotificationEventListener.GetType(eventargs.Handle, out type);
            if (err != Interop.NotificationEventListener.ErrorCode.None)
            {
                Log.Info(LogTag, "unable to get type");
            }

            if (layout == NotificationLayout.OngoingEvent && type == NotificationType.Ongoing)
            {
                eventargs.IsOngoing = true;
            }

            err = Interop.NotificationEventListener.GetEventFlag(eventargs.Handle, out eventFlag);
            if (err != Interop.NotificationEventListener.ErrorCode.None)
            {
                Log.Info(LogTag, "unable to get event flag");
            }

            eventargs.HasEventFlag = eventFlag;

            err = Interop.NotificationEventListener.GetCheckBox(eventargs.Handle, out checkBoxFlag, out checkedValue);
            if (err != Interop.NotificationEventListener.ErrorCode.None)
            {
                Log.Error(LogTag, "unable to get checkbox flag");
            }

            eventargs.CheckBox = checkBoxFlag;
            eventargs.CheckedValue = checkedValue;

            NotificationAccessoryAgsBinder.BindObject(eventargs);
            NotificationStyleArgBinder.BindObject(eventargs);
            NotificationProgressArgBinder.BindObject(eventargs);

            return eventargs;
        }
    }
}
