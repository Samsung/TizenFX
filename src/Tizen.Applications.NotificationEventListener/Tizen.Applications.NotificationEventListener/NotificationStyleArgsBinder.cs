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

    internal static class NotificationStyleArgBinder
    {
        internal static void BindObject(NotificationEventArgs eventargs)
        {
            bool autoRemove;
            string path;
            int styleList;
            int timeout;
            SafeAppControlHandle appcontrol = null;

            Interop.NotificationEventListener.GetStyleList(eventargs.Handle, out styleList);

            if ((styleList & (int)NotificationDisplayApplist.Active) != 0)
            {
                NotificationEventArgs.ActiveStyleArgs activeStyle = new NotificationEventArgs.ActiveStyleArgs();
                eventargs.Style.Add(activeStyle.Key, activeStyle);

                for (int i = (int)ClickEventType.FirstButton; i <= (int)ClickEventType.ThirdButton; i++)
                {
                    NotificationButtonActionArgBinder.BindObject(eventargs, i);
                }

                Interop.NotificationEventListener.GetAutoRemove(eventargs.Handle, out autoRemove);
                activeStyle.IsAutoRemove = autoRemove;

                Interop.NotificationEventListener.GetImage(eventargs.Handle, NotificationImage.Background, out path);
                activeStyle.BackgroundImage = path;

                int index;
                Interop.NotificationEventListener.GetDefaultButton(eventargs.Handle, out index);
                activeStyle.DefaultButton = (ButtonIndex)(index - 1);

                Interop.NotificationEventListener.GetHideTimeout(eventargs.Handle, out timeout);
                activeStyle.HideTimeout = timeout;

                try
                {
                    Interop.NotificationEventListener.GetDeleteTimeout(eventargs.Handle, out timeout);
                }
                catch (TypeLoadException)
                {
                    //To support in API version 3.0
                    timeout = 60;
                }
                activeStyle.DeleteTimeout = timeout;

                appcontrol = null;
                Interop.NotificationEventListener.GetExtensionAction(eventargs.Handle, UserEventType.HiddenByUser, out appcontrol);
                if (appcontrol != null && appcontrol.IsInvalid == false)
                {
                    activeStyle.HiddenByUserAction = new AppControl(appcontrol);
                }

                appcontrol = null;
                Interop.NotificationEventListener.GetExtensionAction(eventargs.Handle, UserEventType.HiddenByTimeout, out appcontrol);
                if (appcontrol != null && appcontrol.IsInvalid == false)
                {
                    activeStyle.HiddenByTimeoutAction = new AppControl(appcontrol);
                }

                appcontrol = null;
                Interop.NotificationEventListener.GetExtensionAction(eventargs.Handle, UserEventType.HiddenByExternal, out appcontrol);
                if (appcontrol != null && appcontrol.IsInvalid == false)
                {
                    activeStyle.HiddenByExternalAction = new AppControl(appcontrol);
                }

                NotificationReplyActionArgBinder.BindObject(eventargs);
            }

            if ((styleList & (int)NotificationDisplayApplist.Lock) != 0)
            {
                NotificationEventArgs.LockStyleArgs lockStyle = new NotificationEventArgs.LockStyleArgs();
                eventargs.Style.Add(lockStyle.Key, lockStyle);

                Interop.NotificationEventListener.GetImage(eventargs.Handle, NotificationImage.Lockscreen, out path);
                lockStyle.IconPath = path;

                Interop.NotificationEventListener.GetImage(eventargs.Handle, NotificationImage.ThumbnailLockscreen, out path);
                lockStyle.Thumbnail = path;
            }

            if ((styleList & (int)NotificationDisplayApplist.Ticker) != 0 || (styleList & (int)NotificationDisplayApplist.Indicator) != 0)
            {
                NotificationEventArgs.IndicatorStyleArgs indicatorStyle = new NotificationEventArgs.IndicatorStyleArgs();
                eventargs.Style.Add(indicatorStyle.Key, indicatorStyle);

                Interop.NotificationEventListener.GetImage(eventargs.Handle, NotificationImage.Indicator, out path);
                indicatorStyle.IconPath = path;

                Interop.NotificationEventListener.GetText(eventargs.Handle, NotificationText.FirstMainText, out path);
                indicatorStyle.SubText = path;
            }

            /* for extension */
            bool isExisted = false;
            int size = 0;
            NotificationLayout layout;
            NotificationEventArgs.ExtensionStyleArgs extensionStyle = new NotificationEventArgs.ExtensionStyleArgs();

            Interop.NotificationEventListener.GetLayout(eventargs.Handle, out layout);
            if (layout == NotificationLayout.Thumbnail)
            {
                appcontrol = null;
                Interop.NotificationEventListener.GetEventHandler(eventargs.Handle, (int)ClickEventType.Thumbnail, out appcontrol);
                if (appcontrol != null && appcontrol.IsInvalid == false)
                {
                    extensionStyle.ThumbnailAction = new AppControl(appcontrol);
                }

                Interop.NotificationEventListener.GetImage(eventargs.Handle, NotificationImage.Thumbnail, out path);
                if (string.IsNullOrEmpty(path) == false)
                {
                    extensionStyle.ThumbnailImagePath = path;
                }

                extensionStyle.IsThumbnail = true;

                if ((styleList & (int)NotificationDisplayApplist.Active) != 0)
                {
                    extensionStyle.IsActive = true;
                }

                isExisted = true;
            }
            else if (layout == NotificationLayout.Extension)
            {
                Interop.NotificationEventListener.GetImage(eventargs.Handle, NotificationImage.Extension, out path);
                if (string.IsNullOrEmpty(path) == false)
                {
                    extensionStyle.ExtensionImagePath = path;
                }

                Interop.NotificationEventListener.GetExtensionImageSize(eventargs.Handle, out size);
                extensionStyle.ExtensionImageSize = size;
                extensionStyle.IsThumbnail = false;

                if ((styleList & (int)NotificationDisplayApplist.Active) != 0)
                {
                    extensionStyle.IsActive = true;
                }

                isExisted = true;
            }

            if (isExisted)
            {
                eventargs.Style.Add(extensionStyle.Key, extensionStyle);
            }
            /* for extension end */
        }
    }
}
