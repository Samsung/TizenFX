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
    internal static class NotificationAccessoryAgsBinder
    {
        internal static void BindObject(NotificationEventArgs eventargs)
        {
            AccessoryOption type;
            int color;
            string path;

            NotificationEventArgs.AccessoryArgs accessory = new NotificationEventArgs.AccessoryArgs();

            Interop.NotificationEventListener.GetLed(eventargs.Handle, out type, out color);
            accessory.LedOption = type;
            if (type != AccessoryOption.Off)
            {
                int on, off;

                Interop.NotificationEventListener.GetLedTime(eventargs.Handle, out on, out off);
                accessory.LedOnMillisecond = on;
                accessory.LedOffMillisecond = off;

                if (type == AccessoryOption.Custom)
                {
                    accessory.LedColor = new Common.Color(color >> 16 & 255, color >> 8 & 255, color >> 0 & 255, color >> 24 & 255);
                }
            }

            Interop.NotificationEventListener.GetSound(eventargs.Handle, out type, out path);
            accessory.SoundOption = type;
            if (type == AccessoryOption.Custom)
            {
                accessory.SountPath = path;
            }

            Interop.NotificationEventListener.GetVibration(eventargs.Handle, out type, out path);
            if (type == AccessoryOption.Off)
            {
                accessory.CanVibrate = false;
            }
            else
            {
                accessory.CanVibrate = true;
            }

            eventargs.Accessory = accessory;
        }
    }
}