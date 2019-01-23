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

    internal static class NotificationReplyActionArgBinder
    {
        private const string LogTag = "Tizen.Applications.NotificationEventListener";

        internal static void BindObject(NotificationEventArgs eventargs)
        {
            string text;
            int max;
            bool isExisted = false;
            SafeAppControlHandle appcontrol = null;
            Bundle bundle;
            NotificationEventArgs.ReplyActionArgs reply = new NotificationEventArgs.ReplyActionArgs();
            NotificationEventArgs.ButtonActionArgs button = new NotificationEventArgs.ButtonActionArgs();
            string replyKey = "__PARENT_INDEX__";

            Interop.NotificationEventListener.GetImage(eventargs.Handle, NotificationImage.TextInputButton, out text);
            if (string.IsNullOrEmpty(text) == false)
            {
                isExisted = true;
                button.ImagePath = text;
            }

            Interop.NotificationEventListener.GetText(eventargs.Handle, NotificationText.InputButton, out text);
            if (string.IsNullOrEmpty(text) == false)
            {
                isExisted = true;
                button.Text = text;
            }

            Interop.NotificationEventListener.GetEventHandler(eventargs.Handle, (int)ClickEventType.InputButton, out appcontrol);

            if (appcontrol != null && appcontrol.IsInvalid == false)
            {
                button.Action = new AppControl(appcontrol);
                isExisted = true;
            }

            reply.Button = button;

            Interop.NotificationEventListener.GetText(eventargs.Handle, NotificationText.PlaceHolder, out text);

            if (string.IsNullOrEmpty(text) == false)
            {
                isExisted = true;
                reply.PlaceHolderText = text;
            }

            Interop.NotificationEventListener.GetPlaceHolderLength(eventargs.Handle, out max);
            reply.ReplyMax = max;
            if (max > 0)
            {
                isExisted = true;
            }

            if (eventargs.ExtraData.TryGetValue(replyKey, out bundle))
            {
                if (bundle.Contains(replyKey))
                {
                    string parentIndex;
                    if (bundle.TryGetItem(replyKey, out parentIndex))
                    {
                        try
                        {
                            reply.ParentIndex = (ButtonIndex)int.Parse(parentIndex);
                            isExisted = true;
                        }
                        catch (Exception ex)
                        {
                            Log.Error(LogTag, "unable to get ParentIndex " + ex.Message);
                        }
                    }
                }
            }

            if (isExisted)
            {
                NotificationEventArgs.ActiveStyleArgs activeStyle = eventargs.Style["Active"] as NotificationEventArgs.ActiveStyleArgs;
                if (activeStyle != null)
                {
                    activeStyle.Reply = reply;
                }
            }
        }
    }
}