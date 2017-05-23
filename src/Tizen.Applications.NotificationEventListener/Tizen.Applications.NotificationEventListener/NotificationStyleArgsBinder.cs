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
    internal static class NotificationStyleArgBinder
    {
        internal static void BindObject(NotificationEventArgs eventargs)
        {
            bool autoRemove;
            string path;
            int styleList;
            int timeout;

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

                Interop.NotificationEventListener.GetHideTimeout(eventargs.Handle, out timeout);
                activeStyle.HideTimeout = timeout;

                Interop.NotificationEventListener.GetDeleteTimeout(eventargs.Handle, out timeout);
                activeStyle.DeleteTimeout = timeout;

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
       }
    }
}
