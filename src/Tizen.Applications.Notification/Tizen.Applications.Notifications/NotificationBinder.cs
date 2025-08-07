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

namespace Tizen.Applications.Notifications
{
    using System;

    internal static class NotificationBinder
    {
        private static readonly int DoNotShowTimeStamp = -1;

        internal static void BindObject(Notification notification)
        {
            BindNotificationSafeHandle(notification);
            BindNotificationText(notification);
            BindNotificationTime(notification);

            Interop.Notification.SetID(notification.Handle, notification.PrivID);

            if (notification.IsVisible)
            {
                Interop.Notification.SetApplist(notification.Handle, (int)NotificationDisplayApplist.Tray);
            }
            else
            {
                Interop.Notification.SetApplist(notification.Handle, 0);
            }

            if (notification.IsOngoing == true)
            {
                Log.Info(Notification.LogTag, "Start to set IsOngoing to SafeHandle");
                Interop.Notification.SetLayout(notification.Handle, NotificationLayout.Ongoing);
                Interop.Notification.SetOngoingFlag(notification.Handle, true);
            }

            if (string.IsNullOrEmpty(notification.Tag) != true)
            {
                Interop.Notification.SetTag(notification.Handle, notification.Tag);
            }

            if (notification.Action != null && notification.Action.SafeAppControlHandle.IsInvalid == false)
            {
                Interop.Notification.SetAppControl(notification.Handle, LaunchOption.AppControl, notification.Action.SafeAppControlHandle);
            }

            Interop.Notification.SetProperties(notification.Handle, (int)notification.Property);

            if (notification.CheckBox == true)
            {
                Interop.Notification.SetCheckBox(notification.Handle, notification.CheckBox, notification.CheckedValue);
            }

            if (notification.PairingType == true)
            {
                Interop.Notification.SetPairingType(notification.Handle, notification.PairingType);
            }
        }

        internal static void BindSafeHandle(Notification notification)
        {
            int privID, groupID;
            Interop.Notification.GetID(notification.Handle, out groupID, out privID);
            notification.PrivID = privID;

            NotificationLayout layout;
            Interop.Notification.GetLayout(notification.Handle, out layout);
            NotificationType type;
            Interop.Notification.GetType(notification.Handle, out type);
            if (layout == NotificationLayout.Ongoing && type == NotificationType.Ongoing)
            {
                notification.IsOngoing = true;
            }

            int appList;
            Interop.Notification.GetApplist(notification.Handle, out appList);
            if ((appList & (int)NotificationDisplayApplist.Tray) == 0)
            {
                notification.IsVisible = false;
            }

            BindSafeHandleText(notification);
            BindSafeHandleTime(notification);
            BindSafeHandleTag(notification);
            BindSafeHandleAction(notification);
            BindSafeHandleCheckBox(notification);
            BindSafeHandlePairingType(notification);
        }

        private static void BindNotificationSafeHandle(Notification notification)
        {
            IntPtr ptr;
            NotificationError ret;

            if (notification.Handle != null && notification.Handle.IsInvalid == false)
            {
                notification.Handle.Dispose();
            }

            if (notification.IsOngoing == true || notification.Progress != null)
            {
                ptr = Interop.Notification.Create(NotificationType.Ongoing);
            }
            else
            {
                ptr = Interop.Notification.Create(NotificationType.Basic);
            }

            if (ptr == IntPtr.Zero)
            {
                ret = (NotificationError)Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                throw NotificationErrorFactory.GetException(ret, "Unable to create IntPtr Notification");
            }

            notification.Handle = new NotificationSafeHandle(ptr, true);
        }

        private static void BindNotificationText(Notification notification)
        {
            Interop.Notification.SetText(notification.Handle, NotificationText.Title, notification.Title, null, -1);
            Interop.Notification.SetText(notification.Handle, NotificationText.Content, notification.Content, null, -1);
            Interop.Notification.SetImage(notification.Handle, NotificationImage.Icon, notification.Icon);
            Interop.Notification.SetImage(notification.Handle, NotificationImage.SubIcon, notification.SubIcon);
            Interop.Notification.SetText(notification.Handle, NotificationText.EventCount, notification.Count.ToString(), null, -1);

            if (string.IsNullOrEmpty(notification.GroupTitle) == false) {
                Interop.Notification.SetText(notification.Handle, NotificationText.GroupTitle, notification.GroupTitle, null, -1);
            }

            if (string.IsNullOrEmpty(notification.GroupContent) == false) {
                Interop.Notification.SetText(notification.Handle, NotificationText.GroupContent, notification.GroupContent, null, -1);
            }
        }

        private static void BindNotificationTime(Notification notification)
        {
            if (notification.IsTimeStampVisible == true)
            {
                if (notification.TimeStamp != DateTime.MinValue)
                {
                    TimeSpan datatime = notification.TimeStamp.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    Interop.Notification.SetTime(notification.Handle, (int)datatime.TotalSeconds);
                }
            }
            else
            {
                Interop.Notification.SetTime(notification.Handle, DoNotShowTimeStamp);
            }
        }

        private static void BindSafeHandleText(Notification notification)
        {
            string text;
            Interop.Notification.GetText(notification.Handle, NotificationText.Title, out text);
            if (string.IsNullOrEmpty(text) == false)
            {
                notification.Title = text;
            }

            Interop.Notification.GetText(notification.Handle, NotificationText.Content, out text);
            if (string.IsNullOrEmpty(text) == false)
            {
                notification.Content = text;
            }

            string path;
            Interop.Notification.GetImage(notification.Handle, NotificationImage.Icon, out path);
            if (string.IsNullOrEmpty(path) == false)
            {
                notification.Icon = path;
            }

            Interop.Notification.GetImage(notification.Handle, NotificationImage.SubIcon, out path);
            if (string.IsNullOrEmpty(path) == false)
            {
                notification.SubIcon = path;
            }

            Interop.Notification.GetText(notification.Handle, NotificationText.EventCount, out text);
            if (string.IsNullOrEmpty(text) == false)
            {
                try
                {
                    notification.Count = int.Parse(text);
                }
                catch (Exception ex)
                {
                    Log.Error(Notification.LogTag, ex.ToString());
                }
            }
        }

        private static void BindSafeHandleTime(Notification notification)
        {
            int time;

            Interop.Notification.GetTime(notification.Handle, out time);

            if (time == DoNotShowTimeStamp)
            {
                notification.IsTimeStampVisible = false;
            }
            else
            {
                notification.IsTimeStampVisible = true;

                if (time != 0)
                {
                    notification.TimeStamp = (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(time).ToLocalTime();
                }
            }
        }

        private static void BindSafeHandleTag(Notification notification)
        {
            string text;
            Interop.Notification.GetTag(notification.Handle, out text);
            if (string.IsNullOrEmpty(text) != true)
            {
                notification.Tag = text;
            }
        }

        private static void BindSafeHandleProperty(Notification notification)
        {
            int property;
            Interop.Notification.GetProperties(notification.Handle, out property);
            notification.Property = (NotificationProperty)property;
        }

        private static void BindSafeHandleAction(Notification notification)
        {
            SafeAppControlHandle appcontrol = null;
            Interop.Notification.GetAppControl(notification.Handle, LaunchOption.AppControl, out appcontrol);
            if (appcontrol != null && appcontrol.IsInvalid == false)
            {
                notification.Action = new AppControl(appcontrol);
            }
        }

        private static void BindSafeHandleCheckBox(Notification notification)
        {
            NotificationError ret;
            bool checkbox = false;
            bool checkedValue = false;

            ret = Interop.Notification.GetCheckBox(notification.Handle, out checkbox, out checkedValue);
            if (ret != NotificationError.None) {
                Log.Error(Notification.LogTag, "Failed to get check box info");
            }

            notification.CheckBox = checkbox;
            notification.CheckedValue = checkedValue;
        }

        private static void BindSafeHandlePairingType(Notification notification)
        {
            NotificationError ret;
            bool pairingType= false;

            ret = Interop.Notification.GetPairingType(notification.Handle, out pairingType);
            if (ret != NotificationError.None) {
                Log.Error(Notification.LogTag, "Failed to get paring type info");
            }

            notification.PairingType = pairingType;
        }
    }
}
