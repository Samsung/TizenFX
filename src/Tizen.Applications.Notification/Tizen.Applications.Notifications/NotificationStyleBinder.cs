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

    internal static class IndicatorBinder
    {
        internal static void BindObject(Notification notification)
        {
            int flag;
            NotificationError ret = NotificationError.None;
            Notification.IndicatorStyle style = (Notification.IndicatorStyle)notification.GetStyle("Indicator");
            Interop.Notification.GetApplist(notification.Handle, out flag);

            if (string.IsNullOrEmpty(style.SubText) == false)
            {
                ret = Interop.Notification.SetText(notification.Handle, NotificationText.FirstMainText, style.SubText, null, -1);
                if (ret != NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException(ret, "unable to set indicator text");
                }
                flag |= (int)NotificationDisplayApplist.Ticker;
            }

            if (string.IsNullOrEmpty(style.IconPath) == false)
            {
                ret = Interop.Notification.SetImage(notification.Handle, NotificationImage.IconForIndicator, style.IconPath);
                if (ret != NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException(ret, "unable to set indicator image");
                }
                flag |= (int)NotificationDisplayApplist.Indicator;
            }
            Interop.Notification.SetApplist(notification.Handle, flag);
        }

        internal static void BindSafeHandle(Notification notification)
        {
            int appList;
            Interop.Notification.GetApplist(notification.Handle, out appList);
            if ((appList & (int)NotificationDisplayApplist.Ticker) != 0 || (appList & (int)NotificationDisplayApplist.Indicator) != 0)
            {
                string path, text;
                Notification.IndicatorStyle indicator = new Notification.IndicatorStyle();
                Interop.Notification.GetImage(notification.Handle, NotificationImage.IconForIndicator, out path);
                indicator.IconPath = path;
                Interop.Notification.GetText(notification.Handle, NotificationText.FirstMainText, out text);
                indicator.SubText = text;

                notification.AddStyle(indicator);
            }
        }
    }

    internal static class ActiveBinder
    {
        internal static void BindObject(Notification notification)
        {
            int flag;
            int hidetime = 0;
            int deletetime = 0;
            NotificationError ret = NotificationError.None;
            Notification.ActiveStyle style = (Notification.ActiveStyle)notification.GetStyle("Active");

            Interop.Notification.SetAutoRemove(notification.Handle, style.IsAutoRemove);

            style.GetRemoveTime(out hidetime, out deletetime);

            if (hidetime > 0)
            {
                Interop.Notification.SetHideTime(notification.Handle, hidetime);
            }

            if (deletetime > 0)
            {
                try
                {
                    Interop.Notification.SetDeleteTime(notification.Handle, deletetime);
                }
                catch (TypeLoadException)
                {
                    // To support in API version 3.0
                    style.SetRemoveTime(hidetime, 60);
                }
            }

            ret = Interop.Notification.SetImage(notification.Handle, NotificationImage.Background, style.BackgroundImage);
            if (ret != NotificationError.None)
            {
                throw NotificationErrorFactory.GetException(ret, "unable to set background Image");
            }

            if (style.DefaultButton != ButtonIndex.None)
            {
                Interop.Notification.SetDefaultButton(notification.Handle, (int)style.DefaultButton + 1);
            }

            Interop.Notification.GetApplist(notification.Handle, out flag);
            Interop.Notification.SetApplist(notification.Handle, flag | (int)NotificationDisplayApplist.Active);

            foreach (Notification.ButtonAction button in style.GetButtonAction())
            {
                button.Make(notification);
            }

            if (style.ReplyAction != null)
            {
                style.ReplyAction.Make(notification);
            }

            if (style.HiddenByUserAction != null)
            {
                Interop.Notification.SetExtensionAction(notification.Handle, NotificationEventType.HiddenByUser, style.HiddenByUserAction.SafeAppControlHandle);
            }

            if (style.HiddenByTimeoutAction != null)
            {
                Interop.Notification.SetExtensionAction(notification.Handle, NotificationEventType.HiddenByTimeout, style.HiddenByTimeoutAction.SafeAppControlHandle);
            }

            if (style.HiddenByExternalAction != null)
            {
                Interop.Notification.SetExtensionAction(notification.Handle, NotificationEventType.HiddenByExternal, style.HiddenByExternalAction.SafeAppControlHandle);
            }
        }

        internal static void BindSafeHandle(Notification notification)
        {
            int appList;
            Interop.Notification.GetApplist(notification.Handle, out appList);

            if ((appList & (int)NotificationDisplayApplist.Active) != 0)
            {
                Notification.ActiveStyle active = new Notification.ActiveStyle();
                bool autoRemove;
                string path, text;
                SafeAppControlHandle appcontrol = null;
                string replyKey = "__PARENT_INDEX__";

                for (int i = (int)ButtonIndex.First; i <= (int)ButtonIndex.Third; i++)
                {
                    appcontrol = null;

                    Interop.Notification.GetImage(notification.Handle, NotificationImage.FirstButton + i, out path);
                    Interop.Notification.GetText(notification.Handle, NotificationText.FirstButton + i, out text);
                    Interop.Notification.GetEventHandler(notification.Handle, i, out appcontrol);

                    if (string.IsNullOrEmpty(path) == false || string.IsNullOrEmpty(text) == false
                        || (appcontrol != null && appcontrol.IsInvalid == false))
                    {
                        Notification.ButtonAction button = new Notification.ButtonAction();
                        if (appcontrol != null && appcontrol.IsInvalid == false)
                        {
                            button.Action = new AppControl(appcontrol);
                        }

                        button.ImagePath = path;
                        button.Text = text;
                        button.Index = (ButtonIndex)i;
                        active.AddButtonAction(button);
                    }
                }

                appcontrol = null;
                Interop.Notification.GetExtensionAction(notification.Handle, NotificationEventType.HiddenByUser, out appcontrol);
                if (appcontrol != null && appcontrol.IsInvalid == false)
                {
                    active.HiddenByUserAction = new AppControl(appcontrol);
                }

                appcontrol = null;
                Interop.Notification.GetExtensionAction(notification.Handle, NotificationEventType.HiddenByTimeout, out appcontrol);
                if (appcontrol != null && appcontrol.IsInvalid == false)
                {
                    active.HiddenByTimeoutAction = new AppControl(appcontrol);
                }

                appcontrol = null;
                Interop.Notification.GetExtensionAction(notification.Handle, NotificationEventType.HiddenByExternal, out appcontrol);
                if (appcontrol != null && appcontrol.IsInvalid == false)
                {
                    active.HiddenByExternalAction = new AppControl(appcontrol);
                }

                Interop.Notification.GetAutoRemove(notification.Handle, out autoRemove);
                active.IsAutoRemove = autoRemove;
                if (autoRemove)
                {
                    int hidetime, deletetime;
                    Interop.Notification.GetHideTime(notification.Handle, out hidetime);
                    try
                    {
                        Interop.Notification.GetDeleteTime(notification.Handle, out deletetime);
                    }
                    catch (TypeLoadException)
                    {
                        // To support in API version 3.0
                        deletetime = 60;
                    }

                    active.SetRemoveTime(hidetime, deletetime);
                }

                Interop.Notification.GetImage(notification.Handle, NotificationImage.Background, out path);
                if (string.IsNullOrEmpty(path) == false)
                {
                    active.BackgroundImage = path;
                }

                int defaultIndex;
                Interop.Notification.GetDefaultButton(notification.Handle, out defaultIndex);
                active.DefaultButton = (ButtonIndex)(defaultIndex - 1);

                appcontrol = null;
                Interop.Notification.GetImage(notification.Handle, NotificationImage.TextInputButton, out path);
                Interop.Notification.GetText(notification.Handle, NotificationText.InputButton, out text);
                Interop.Notification.GetEventHandler(notification.Handle, (int)NotificationEventType.ClickOnTextInputButton, out appcontrol);

                if (string.IsNullOrEmpty(path) == false || string.IsNullOrEmpty(text) == false
                    || (appcontrol != null && appcontrol.IsInvalid == false))
                {
                    Notification.ReplyAction reply = new Notification.ReplyAction();
                    Notification.ButtonAction button = new Notification.ButtonAction();
                    if (appcontrol != null && appcontrol.IsInvalid == false)
                    {
                        button.Action = new AppControl(appcontrol);
                    }

                    button.ImagePath = path;
                    button.Text = text;
                    reply.Button = button;

                    Interop.Notification.GetText(notification.Handle, NotificationText.PlaceHolder, out text);
                    reply.PlaceHolderText = text;

                    int holderLength;
                    Interop.Notification.GetPlaceHolderLength(notification.Handle, out holderLength);
                    reply.ReplyMax = holderLength;

                    try
                    {
                        SafeBundleHandle bundleHandle;
                        Interop.Notification.GetExtensionData(notification.Handle, replyKey, out bundleHandle);
                        Bundle bundle = new Bundle(bundleHandle);
                        reply.ParentIndex = (ButtonIndex)int.Parse(bundle.GetItem(replyKey).ToString());
                        bundle.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Log.Error(Notification.LogTag, ex.ToString());
                    }

                    active.ReplyAction = reply;
                }

                notification.AddStyle(active);
            }
        }
    }

    internal static class LockBinder
    {
        internal static void BindObject(Notification notification)
        {
            int flag;
            NotificationError ret = NotificationError.None;
            Notification.LockStyle style = (Notification.LockStyle)notification.GetStyle("Lock");

            ret = Interop.Notification.SetImage(notification.Handle, NotificationImage.IconForLock, style.IconPath);
            if (ret != NotificationError.None)
            {
                throw NotificationErrorFactory.GetException(ret, "unable to set lock icon");
            }

            ret = Interop.Notification.SetImage(notification.Handle, NotificationImage.ThumbnailForLock, style.ThumbnailPath);
            if (ret != NotificationError.None)
            {
                throw NotificationErrorFactory.GetException(ret, "unable to set lock thumbnail");
            }

            Interop.Notification.GetApplist(notification.Handle, out flag);
            Interop.Notification.SetApplist(notification.Handle, flag | (int)NotificationDisplayApplist.Lock);
        }

        internal static void BindSafehandle(Notification notification)
        {
            int applist;
            Interop.Notification.GetApplist(notification.Handle, out applist);

            if ((applist & (int)NotificationDisplayApplist.Lock) != 0)
            {
                string path;
                Notification.LockStyle lockStyle = new Notification.LockStyle();

                Interop.Notification.GetImage(notification.Handle, NotificationImage.IconForLock, out path);
                lockStyle.IconPath = path;

                Interop.Notification.GetImage(notification.Handle, NotificationImage.ThumbnailForLock, out path);
                lockStyle.ThumbnailPath = path;

                notification.AddStyle(lockStyle);
            }
        }
    }
}
