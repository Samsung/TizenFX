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

using System;
using System.Runtime.InteropServices;
using Tizen.Applications;
using Tizen.Applications.Notifications;

internal static partial class Interop
{
    internal static class Notification
    {
        internal delegate void ResponseEventCallback(IntPtr ptr, int type, IntPtr userData);

        [DllImport(Libraries.Notification, EntryPoint = "notification_create")]
        internal static extern IntPtr Create(NotificationType type);

        [DllImport(Libraries.Notification, EntryPoint = "notification_free")]
        internal static extern NotificationError Destroy(IntPtr handle);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_text")]
        internal static extern NotificationError GetTextReferenceType(NotificationSafeHandle handle, NotificationText type, out IntPtr text);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_text")]
        internal static extern NotificationError SetText(NotificationSafeHandle handle, NotificationText type, string text, string key, int args);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_image")]
        internal static extern NotificationError GetImageReferenceType(NotificationSafeHandle handle, NotificationImage type, out IntPtr path);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_image")]
        internal static extern NotificationError SetImage(NotificationSafeHandle handle, NotificationImage type, string path);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_time")]
        internal static extern NotificationError GetTime(NotificationSafeHandle handle, out int time);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_time")]
        internal static extern NotificationError SetTime(NotificationSafeHandle handle, int time);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_insert_time")]
        internal static extern NotificationError GetInsertTime(NotificationSafeHandle handle, out long time);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_sound")]
        internal static extern NotificationError GetSoundReferenceType(NotificationSafeHandle handle, out AccessoryOption type, out IntPtr path);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_sound")]
        internal static extern NotificationError SetSound(NotificationSafeHandle handle, AccessoryOption type, string path);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_vibration")]
        internal static extern NotificationError GetVibrationReferenceType(NotificationSafeHandle handle, out AccessoryOption type, out IntPtr path);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_vibration")]
        internal static extern NotificationError SetVibration(NotificationSafeHandle handle, AccessoryOption type, string path);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_led")]
        internal static extern NotificationError GetLed(NotificationSafeHandle handle, out AccessoryOption type, out int color);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_led")]
        internal static extern NotificationError SetLed(NotificationSafeHandle handle, AccessoryOption type, int color);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_led_time_period")]
        internal static extern NotificationError GetLedTimePeriod(NotificationSafeHandle handle, out int onMillisecond, out int offMillisecond);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_led_time_period")]
        internal static extern NotificationError SetLedTimePeriod(NotificationSafeHandle handle, int onMillisecond, int offMillisecond);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_launch_option")]
        internal static extern NotificationError GetAppControl(NotificationSafeHandle handle, LaunchOption type, out SafeAppControlHandle apphandle);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_launch_option")]
        internal static extern NotificationError SetAppControl(NotificationSafeHandle handle, LaunchOption type, SafeAppControlHandle appHandle);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_event_handler")]
        internal static extern NotificationError GetEventHandler(NotificationSafeHandle handle, int type, out SafeAppControlHandle appHandle);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_event_handler")]
        internal static extern NotificationError SetEventHandler(NotificationSafeHandle handle, int type, SafeAppControlHandle appHandle);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_property")]
        internal static extern NotificationError GetProperties(NotificationSafeHandle handle, out int flags);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_property")]
        internal static extern NotificationError SetProperties(NotificationSafeHandle handle, int flags);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_display_applist")]
        internal static extern NotificationError GetApplist(NotificationSafeHandle handle, out int flags);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_display_applist")]
        internal static extern NotificationError SetApplist(NotificationSafeHandle handle, int flags);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_size")]
        internal static extern NotificationError GetProgressSize(NotificationSafeHandle handle, out double size);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_size")]
        internal static extern NotificationError SetProgressSize(NotificationSafeHandle handle, double size);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_progress")]
        internal static extern NotificationError GetProgress(NotificationSafeHandle handle, out double progress);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_progress")]
        internal static extern NotificationError SetProgress(NotificationSafeHandle handle, double progress);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_layout")]
        internal static extern NotificationError GetLayout(NotificationSafeHandle handle, out NotificationLayout layout);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_layout")]
        internal static extern NotificationError SetLayout(NotificationSafeHandle handle, NotificationLayout layout);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_type")]
        internal static extern NotificationError GetType(NotificationSafeHandle handle, out NotificationType type);

        [DllImport(Libraries.Notification, EntryPoint = "notification_update")]
        internal static extern NotificationError Update(NotificationSafeHandle handle);

        [DllImport(Libraries.Notification, EntryPoint = "notification_delete")]
        internal static extern NotificationError Delete(NotificationSafeHandle handle);

        [DllImport(Libraries.Notification, EntryPoint = "notification_delete_all")]
        internal static extern NotificationError DeleteAll(int type);

        [DllImport(Libraries.Notification, EntryPoint = "notification_post")]
        internal static extern NotificationError Post(NotificationSafeHandle handle);

        [DllImport(Libraries.Notification, EntryPoint = "notification_post_with_event_cb")]
        internal static extern NotificationError PostWithEventCallback(NotificationSafeHandle handle, ResponseEventCallback cb, IntPtr userdata);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_pkgname")]
        internal static extern NotificationError GetPackageName(NotificationSafeHandle handle, out IntPtr name);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_event_handler")]
        internal static extern NotificationError AddButtonAction(NotificationSafeHandle handle, ButtonIndex type, SafeAppControlHandle appcontrol);

        [DllImport(Libraries.Notification, EntryPoint = "notification_remove_button")]
        internal static extern NotificationError RemoveButton(NotificationSafeHandle handle, ButtonIndex index);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_tag")]
        internal static extern NotificationError SetTag(NotificationSafeHandle handle, string tag);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_tag")]
        internal static extern NotificationError GetTagReferenceType(NotificationSafeHandle handle, out IntPtr tag);

        [DllImport(Libraries.Notification, EntryPoint = "notification_load_by_tag")]
        internal static extern IntPtr Load(string text);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_id")]
        internal static extern NotificationError GetID(NotificationSafeHandle handle, out int groupID, out int privID);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_priv_id")]
        internal static extern NotificationError SetID(NotificationSafeHandle handle, int privID);

        [DllImport(Libraries.Notification, EntryPoint = "notification_save_as_template")]
        internal static extern NotificationError SaveTemplate(NotificationSafeHandle handle, string name);

        [DllImport(Libraries.Notification, EntryPoint = "notification_create_from_template")]
        internal static extern IntPtr LoadTemplate(string name);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_noti_block_state")]
        internal static extern NotificationError GetBlockState(out NotificationBlockState status);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_auto_remove")]
        internal static extern NotificationError SetAutoRemove(NotificationSafeHandle handle, bool autoRemove);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_auto_remove")]
        internal static extern NotificationError GetAutoRemove(NotificationSafeHandle handle, out bool autoRemove);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_ongoing_value_type")]
        internal static extern NotificationError SetProgressType(NotificationSafeHandle handle, ProgressCategory category);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_ongoing_value_type")]
        internal static extern NotificationError GetProgressType(NotificationSafeHandle handle, out ProgressCategory category);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_ongoing_flag")]
        internal static extern NotificationError SetOngoingFlag(NotificationSafeHandle handle, bool flag);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_ongoing_flag")]
        internal static extern NotificationError GetProgressFlag(NotificationSafeHandle handle, bool flag);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_ongoing_flag")]
        internal static extern NotificationError GetProgressFlag(NotificationSafeHandle handle, out bool flag);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_text_input")]
        internal static extern NotificationError SetPlaceHolderLength(NotificationSafeHandle handle, int length);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_text_input_max_length")]
        internal static extern NotificationError GetPlaceHolderLength(NotificationSafeHandle handle, out int length);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_hide_timeout")]
        internal static extern NotificationError GetHideTime(NotificationSafeHandle handle, out int timeout);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_hide_timeout")]
        internal static extern NotificationError SetHideTime(NotificationSafeHandle handle, int timeout);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_delete_timeout")]
        internal static extern NotificationError GetDeleteTime(NotificationSafeHandle handle, out int timeout);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_delete_timeout")]
        internal static extern NotificationError SetDeleteTime(NotificationSafeHandle handle, int timeout);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_extension_data")]
        internal static extern NotificationError SetExtensionData(NotificationSafeHandle handle, string key, SafeBundleHandle bundleHandle);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_extension_data")]
        internal static extern NotificationError GetExtensionData(NotificationSafeHandle handle, string key, out SafeBundleHandle bundleHandle);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_args")]
        internal static extern NotificationError GetExtensionBundle(NotificationSafeHandle handle, out IntPtr args, out IntPtr group_args);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_default_button")]
        internal static extern NotificationError GetDefaultButton(NotificationSafeHandle handle, out int index);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_default_button")]
        internal static extern NotificationError SetDefaultButton(NotificationSafeHandle handle, int index);

        [DllImport(Libraries.Notification, EntryPoint = "notification_set_extension_event_handler")]
        internal static extern NotificationError SetExtensionAction(NotificationSafeHandle handle, NotificationEventType type, SafeAppControlHandle appcontrol);

        [DllImport(Libraries.Notification, EntryPoint = "notification_get_extension_event_handler")]
        internal static extern NotificationError GetExtensionAction(NotificationSafeHandle handle, NotificationEventType type, out SafeAppControlHandle appcontrol);

        [DllImport(Libraries.Notification, EntryPoint = "notification_clone")]
        internal static extern NotificationError Clone(IntPtr handle, out IntPtr cloned);

        internal static NotificationError GetText(NotificationSafeHandle handle, NotificationText type, out string text)
        {
            NotificationError ret;
            IntPtr ptr;
            ret = GetTextReferenceType(handle, type, out ptr);

            if (ptr == IntPtr.Zero)
            {
                text = null;
            }
            else
            {
                text = Marshal.PtrToStringAnsi(ptr);
            }

            return ret;
        }

        internal static NotificationError GetImage(NotificationSafeHandle handle, NotificationImage type, out string path)
        {
            NotificationError ret;
            IntPtr ptr;
            ret = GetImageReferenceType(handle, type, out ptr);

            if (ptr == IntPtr.Zero)
            {
                path = null;
            }
            else
            {
                path = Marshal.PtrToStringAnsi(ptr);
            }

            return ret;
        }

        internal static NotificationError GetSound(NotificationSafeHandle handle, out AccessoryOption type, out string path)
        {
            NotificationError ret;
            IntPtr ptr;
            ret = GetSoundReferenceType(handle, out type, out ptr);

            if (ptr == IntPtr.Zero)
            {
                path = null;
            }
            else
            {
                path = Marshal.PtrToStringAnsi(ptr);
            }

            return ret;
        }

        internal static NotificationError GetVibration(NotificationSafeHandle handle, out AccessoryOption type, out string path)
        {
            NotificationError ret;
            IntPtr ptr;
            ret = GetVibrationReferenceType(handle, out type, out ptr);

            if (ptr == IntPtr.Zero)
            {
                path = null;
            }
            else
            {
                path = Marshal.PtrToStringAnsi(ptr);
            }

            return ret;
        }

        internal static NotificationError GetTag(NotificationSafeHandle handle, out string tag)
        {
            NotificationError ret;
            IntPtr ptr;
            ret = GetTagReferenceType(handle, out ptr);

            if (ptr == IntPtr.Zero)
            {
                tag = null;
            }
            else
            {
                tag = Marshal.PtrToStringAnsi(ptr);
            }

            return ret;
        }
    }
}
