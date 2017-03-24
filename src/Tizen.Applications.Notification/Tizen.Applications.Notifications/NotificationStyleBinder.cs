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

            ret = Interop.Notification.SetText(notification.Handle, NotificationText.FirstMainText, style.SubText, null, -1);
            if (ret != NotificationError.None)
            {
                throw NotificationErrorFactory.GetException(ret, "unable to set indicator text");
            }

            ret = Interop.Notification.SetImage(notification.Handle, NotificationImage.IconForIndicator, style.IconPath);
            if (ret != NotificationError.None)
            {
                throw NotificationErrorFactory.GetException(ret, "unable to set indicator image");
            }

            Interop.Notification.GetApplist(notification.Handle, out flag);
            Interop.Notification.SetApplist(notification.Handle, flag | (int)NotificationDisplayApplist.Indicator | (int)NotificationDisplayApplist.Ticker);
        }

        internal static void BindSafeHandle(Notification notification)
        {
            int appList;
            Interop.Notification.GetApplist(notification.Handle, out appList);
            if ((appList & ((int)NotificationDisplayApplist.Ticker | (int)NotificationDisplayApplist.Indicator)) != 0)
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
            NotificationError ret = NotificationError.None;
            Notification.ActiveStyle style = (Notification.ActiveStyle)notification.GetStyle("Active");

            Interop.Notification.SetAutoRemove(notification.Handle, style.IsAutoRemove);
            if (style.IsAutoRemove == true)
            {
                int hidetime;
                int deletetime;
                style.GetRemoveTime(out hidetime, out deletetime);

                Interop.Notification.SetHideTime(notification.Handle, hidetime);
                Interop.Notification.SetDeleteTime(notification.Handle, deletetime);
            }

            ret = Interop.Notification.SetImage(notification.Handle, NotificationImage.Background, style?.BackgroundImage);
            if (ret != NotificationError.None)
            {
                throw NotificationErrorFactory.GetException(ret, "unable to set background Image");
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
        }

        internal static void BindSafeHandle(Notification notification)
        {
            int appList;
            Interop.Notification.GetApplist(notification.Handle, out appList);

            if ((appList & (int)NotificationDisplayApplist.Active) != 0)
            {
                Notification.ActiveStyle active = new Notification.ActiveStyle();
                bool isExisted = false;
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
                        isExisted = true;
                    }
                }

                Interop.Notification.GetAutoRemove(notification.Handle, out autoRemove);
                active.IsAutoRemove = autoRemove;
                if (autoRemove)
                {
                    int hidetime, deletetime;
                    Interop.Notification.GetHideTime(notification.Handle, out hidetime);
                    Interop.Notification.GetDeleteTime(notification.Handle, out deletetime);
                    active.SetRemoveTime(hidetime, deletetime);
                }

                Interop.Notification.GetImage(notification.Handle, NotificationImage.Background, out path);
                if (string.IsNullOrEmpty(path) == false)
                {
                    isExisted = true;
                    active.BackgroundImage = path;
                }

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

                    isExisted = true;

                    try
                    {
                        SafeBundleHandle bundleHandle;
                        Interop.Notification.GetExtentionData(notification.Handle, replyKey, out bundleHandle);
                        Bundle bundle = new Bundle(bundleHandle);
                        reply.ParentIndex = (ButtonIndex)int.Parse(bundle.GetItem(replyKey).ToString());
                    }
                    catch (Exception ex)
                    {
                        Log.Error(Notification.LogTag, ex.ToString());
                    }

                    active.ReplyAction = reply;
                }

                if (isExisted)
                {
                    notification.AddStyle(active);
                }
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

    internal static class BigPictureBinder
    {
        internal static void BindObject(Notification notification)
        {
            Notification.BigPictureStyle style = (Notification.BigPictureStyle)notification.GetStyle("BigPicture");

            Interop.Notification.SetImage(notification.Handle, NotificationImage.BigPicture, style.ImagePath);
            Interop.Notification.SetBigPictureSize(notification.Handle, style.ImageSize);
            Interop.Notification.SetText(notification.Handle, NotificationText.BigPicture, style.Content, null, -1);
            Interop.Notification.SetLayout(notification.Handle, NotificationLayout.Extension);
        }

        internal static void BindSafeHandle(Notification notification)
        {
            NotificationLayout layout;

            Interop.Notification.GetLayout(notification.Handle, out layout);
            if (layout == NotificationLayout.Extension)
            {
                Notification.BigPictureStyle style = new Notification.BigPictureStyle();

                string text;
                Interop.Notification.GetImage(notification.Handle, NotificationImage.BigPicture, out text);
                style.ImagePath = text;

                int size;
                Interop.Notification.GetBigPictureSize(notification.Handle, out size);
                style.ImageSize = size;

                Interop.Notification.GetText(notification.Handle, NotificationText.BigPicture, out text);
                style.Content = text;

                notification.AddStyle(style);
            }
        }
    }
}
