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
    internal static class NotificationButtonActionArgBinder
    {
        internal static void BindObject(NotificationEventArgs eventargs, int index)
        {
            string text;
            bool isExisted = false;
            SafeAppControlHandle appcontrol = null;
            NotificationEventArgs.ButtonActionArgs button = new NotificationEventArgs.ButtonActionArgs();

            button.Index = (ButtonIndex)index;

            Interop.NotificationEventListener.GetImage(eventargs.Handle, NotificationImage.Button_1 + index, out text);
            if (string.IsNullOrEmpty(text) == false)
            {
                isExisted = true;
                button.ImagePath = text;
            }

            Interop.NotificationEventListener.GetText(eventargs.Handle, NotificationText.FirstButton + index, out text);
            if (string.IsNullOrEmpty(text) == false)
            {
                isExisted = true;
                button.Text = text;
            }

            Interop.NotificationEventListener.GetEventHandler(eventargs.Handle, index, out appcontrol);

            if (appcontrol != null && appcontrol.IsInvalid == false)
            {
                button.Action = new AppControl(appcontrol);
                isExisted = true;
            }

            if (isExisted)
            {
                NotificationEventArgs.ActiveStyleArgs activeStyle = eventargs.Style["Active"] as NotificationEventArgs.ActiveStyleArgs;
                if (activeStyle != null)
                {
                    activeStyle.Button.Add(button);
                }
            }
        }
    }
}
