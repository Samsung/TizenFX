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
    using Tizen.Common;

    internal static class AccessorySetBinder
    {
        internal static void BindObject(Notification notification)
        {
            BindLedToHandle(notification);
            BindSoundToHandle(notification);
            BindVibrationToHandle(notification);
        }

        internal static void BindSafeHandle(Notification notification)
        {
            Notification.AccessorySet accessory = new Notification.AccessorySet();
            BindHandleToLed(notification, accessory);
            BindHandleToSound(notification, accessory);
            BindHandleToVibration(notification, accessory);
            notification.Accessory = accessory;
        }

        private static void BindLedToHandle(Notification notification)
        {
            NotificationError ret = NotificationError.None;
            Notification.AccessorySet accessory = notification.Accessory;

            ret = Interop.Notification.SetLed(notification.Handle, accessory.LedOption, 0);
            if (ret != NotificationError.None)
            {
                throw NotificationErrorFactory.GetException(ret, "unable to set led");
            }

            ret = Interop.Notification.SetLedTimePeriod(notification.Handle, accessory.LedOnMillisecond, accessory.LedOffMillisecond);
            if (ret != NotificationError.None)
            {
                throw NotificationErrorFactory.GetException(ret, "unable to set led period");
            }

            if (notification.Accessory.LedOption == AccessoryOption.Custom)
            {
                Color color = accessory.LedColor;
                ret = Interop.Notification.SetLed(notification.Handle, AccessoryOption.Custom, color.GetArgb());
                if (ret != NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException(ret, "unable to set led color");
                }
            }
        }

        private static void BindVibrationToHandle(Notification notification)
        {
            Notification.AccessorySet accessory = notification.Accessory;
            if (accessory.CanVibrate == false)
            {
                Interop.Notification.SetVibration(notification.Handle, AccessoryOption.Off, null);
            }
            else
            {
                Interop.Notification.SetVibration(notification.Handle, AccessoryOption.On, null);
            }
        }

        private static void BindSoundToHandle(Notification notification)
        {
            Notification.AccessorySet accessory = notification.Accessory;

            if (accessory.SoundOption == AccessoryOption.Custom && string.IsNullOrEmpty(accessory.SoundPath))
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "If the option is set to Custom, the path must also be set.");
            }

            NotificationError ret = Interop.Notification.SetSound(notification.Handle, accessory.SoundOption, accessory.SoundPath);
            if (ret != NotificationError.None)
            {
                throw NotificationErrorFactory.GetException(ret, "unable to set sound");
            }
        }

        private static void BindHandleToLed(Notification notification, Notification.AccessorySet accessory)
        {
            AccessoryOption type;
            int argb;
            Interop.Notification.GetLed(notification.Handle, out type, out argb);

            accessory.LedOption = type;
            if (type == AccessoryOption.Custom)
            {
                accessory.LedColor = new Color(argb >> 16 & 255, argb >> 8 & 255, argb >> 0 & 255, argb >> 24 & 255);
            }

            int onMillisecond, offMillisecond;
            Interop.Notification.GetLedTimePeriod(notification.Handle, out onMillisecond, out offMillisecond);
            accessory.LedOnMillisecond = onMillisecond;
            accessory.LedOffMillisecond = offMillisecond;
        }

        private static void BindHandleToSound(Notification notification, Notification.AccessorySet accessory)
        {
            AccessoryOption type;
            string path;

            Interop.Notification.GetSound(notification.Handle, out type, out path);

            accessory.SoundOption = type;
            if (type == AccessoryOption.Custom)
            {
                accessory.SoundPath = path;
            }
        }

        private static void BindHandleToVibration(Notification notification, Notification.AccessorySet accessory)
        {
            AccessoryOption type;
            string path;

            Interop.Notification.GetVibration(notification.Handle, out type, out path);
            if (type == AccessoryOption.Off)
            {
                accessory.CanVibrate = false;
            }
            else
            {
                accessory.CanVibrate = true;
            }
        }
    }
}