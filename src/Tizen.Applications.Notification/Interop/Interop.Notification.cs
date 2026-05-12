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
using System.Runtime.InteropServices.Marshalling;
using Tizen.Applications;
using Tizen.Applications.Notifications;

internal static partial class Interop
{
    internal static partial class Notification
    {
        internal delegate void ResponseEventCallback(IntPtr ptr, int type, IntPtr userData);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_create")]
        internal static partial IntPtr Create(NotificationType type);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_free")]
        internal static partial NotificationError Destroy(IntPtr handle);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_text")]
        internal static partial NotificationError GetTextReferenceType(NotificationSafeHandle handle, NotificationText type, out IntPtr text);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_text", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial NotificationError SetText(NotificationSafeHandle handle, NotificationText type, string text, string key, int args);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_image")]
        internal static partial NotificationError GetImageReferenceType(NotificationSafeHandle handle, NotificationImage type, out IntPtr path);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_image", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial NotificationError SetImage(NotificationSafeHandle handle, NotificationImage type, string path);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_time")]
        internal static partial NotificationError GetTime(NotificationSafeHandle handle, out int time);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_time")]
        internal static partial NotificationError SetTime(NotificationSafeHandle handle, int time);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_insert_time")]
        internal static partial NotificationError GetInsertTime(NotificationSafeHandle handle, out long time);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_sound")]
        internal static partial NotificationError GetSoundReferenceType(NotificationSafeHandle handle, out AccessoryOption type, out IntPtr path);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_sound", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial NotificationError SetSound(NotificationSafeHandle handle, AccessoryOption type, string path);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_vibration")]
        internal static partial NotificationError GetVibrationReferenceType(NotificationSafeHandle handle, out AccessoryOption type, out IntPtr path);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_vibration", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial NotificationError SetVibration(NotificationSafeHandle handle, AccessoryOption type, string path);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_led")]
        internal static partial NotificationError GetLed(NotificationSafeHandle handle, out AccessoryOption type, out int color);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_led")]
        internal static partial NotificationError SetLed(NotificationSafeHandle handle, AccessoryOption type, int color);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_led_time_period")]
        internal static partial NotificationError GetLedTimePeriod(NotificationSafeHandle handle, out int onMillisecond, out int offMillisecond);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_led_time_period")]
        internal static partial NotificationError SetLedTimePeriod(NotificationSafeHandle handle, int onMillisecond, int offMillisecond);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_launch_option")]
        internal static partial NotificationError GetAppControl(NotificationSafeHandle handle, LaunchOption type, out SafeAppControlHandle apphandle);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_launch_option")]
        internal static partial NotificationError SetAppControl(NotificationSafeHandle handle, LaunchOption type, SafeAppControlHandle appHandle);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_event_handler")]
        internal static partial NotificationError GetEventHandler(NotificationSafeHandle handle, int type, out SafeAppControlHandle appHandle);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_event_handler")]
        internal static partial NotificationError SetEventHandler(NotificationSafeHandle handle, int type, SafeAppControlHandle appHandle);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_property")]
        internal static partial NotificationError GetProperties(NotificationSafeHandle handle, out int flags);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_property")]
        internal static partial NotificationError SetProperties(NotificationSafeHandle handle, int flags);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_display_applist")]
        internal static partial NotificationError GetApplist(NotificationSafeHandle handle, out int flags);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_display_applist")]
        internal static partial NotificationError SetApplist(NotificationSafeHandle handle, int flags);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_size")]
        internal static partial NotificationError GetProgressSize(NotificationSafeHandle handle, out double size);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_size")]
        internal static partial NotificationError SetProgressSize(NotificationSafeHandle handle, double size);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_progress")]
        internal static partial NotificationError GetProgress(NotificationSafeHandle handle, out double progress);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_progress")]
        internal static partial NotificationError SetProgress(NotificationSafeHandle handle, double progress);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_layout")]
        internal static partial NotificationError GetLayout(NotificationSafeHandle handle, out NotificationLayout layout);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_layout")]
        internal static partial NotificationError SetLayout(NotificationSafeHandle handle, NotificationLayout layout);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_type")]
        internal static partial NotificationError GetType(NotificationSafeHandle handle, out NotificationType type);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_update")]
        internal static partial NotificationError Update(NotificationSafeHandle handle);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_delete")]
        internal static partial NotificationError Delete(NotificationSafeHandle handle);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_delete_all")]
        internal static partial NotificationError DeleteAll(int type);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_post")]
        internal static partial NotificationError Post(NotificationSafeHandle handle);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_post_with_event_cb")]
        internal static partial NotificationError PostWithEventCallback(NotificationSafeHandle handle, ResponseEventCallback cb, IntPtr userdata);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_pkgname")]
        internal static partial NotificationError GetPackageName(NotificationSafeHandle handle, out IntPtr name);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_event_handler")]
        internal static partial NotificationError AddButtonAction(NotificationSafeHandle handle, ButtonIndex type, SafeAppControlHandle appcontrol);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_remove_button")]
        internal static partial NotificationError RemoveButton(NotificationSafeHandle handle, ButtonIndex index);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_tag", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial NotificationError SetTag(NotificationSafeHandle handle, string tag);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_tag")]
        internal static partial NotificationError GetTagReferenceType(NotificationSafeHandle handle, out IntPtr tag);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_load_by_tag", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial IntPtr Load(string text);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_id")]
        internal static partial NotificationError GetID(NotificationSafeHandle handle, out int groupID, out int privID);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_priv_id")]
        internal static partial NotificationError SetID(NotificationSafeHandle handle, int privID);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_save_as_template", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial NotificationError SaveTemplate(NotificationSafeHandle handle, string name);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_create_from_template", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial IntPtr LoadTemplate(string name);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_noti_block_state")]
        internal static partial NotificationError GetBlockState(out NotificationBlockState status);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_auto_remove")]
        internal static partial NotificationError SetAutoRemove(NotificationSafeHandle handle, [MarshalAs(UnmanagedType.U1)] bool autoRemove);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_auto_remove")]
        internal static partial NotificationError GetAutoRemove(NotificationSafeHandle handle, [MarshalAs(UnmanagedType.U1)] out bool autoRemove);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_ongoing_value_type")]
        internal static partial NotificationError SetProgressType(NotificationSafeHandle handle, ProgressCategory category);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_ongoing_value_type")]
        internal static partial NotificationError GetProgressType(NotificationSafeHandle handle, out ProgressCategory category);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_ongoing_flag")]
        internal static partial NotificationError SetOngoingFlag(NotificationSafeHandle handle, [MarshalAs(UnmanagedType.U1)] bool flag);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_ongoing_flag")]
        internal static partial NotificationError GetProgressFlag(NotificationSafeHandle handle, [MarshalAs(UnmanagedType.U1)] bool flag);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_ongoing_flag")]
        internal static partial NotificationError GetProgressFlag(NotificationSafeHandle handle, [MarshalAs(UnmanagedType.U1)] out bool flag);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_text_input")]
        internal static partial NotificationError SetPlaceHolderLength(NotificationSafeHandle handle, int length);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_text_input_max_length")]
        internal static partial NotificationError GetPlaceHolderLength(NotificationSafeHandle handle, out int length);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_hide_timeout")]
        internal static partial NotificationError GetHideTime(NotificationSafeHandle handle, out int timeout);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_hide_timeout")]
        internal static partial NotificationError SetHideTime(NotificationSafeHandle handle, int timeout);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_delete_timeout")]
        internal static partial NotificationError GetDeleteTime(NotificationSafeHandle handle, out int timeout);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_delete_timeout")]
        internal static partial NotificationError SetDeleteTime(NotificationSafeHandle handle, int timeout);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_extension_data", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial NotificationError SetExtensionData(NotificationSafeHandle handle, string key, SafeBundleHandle bundleHandle);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_extension_data", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial NotificationError GetExtensionData(NotificationSafeHandle handle, string key, out SafeBundleHandle bundleHandle);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_args")]
        internal static partial NotificationError GetExtensionBundle(NotificationSafeHandle handle, out IntPtr args, out IntPtr group_args);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_default_button")]
        internal static partial NotificationError GetDefaultButton(NotificationSafeHandle handle, out int index);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_default_button")]
        internal static partial NotificationError SetDefaultButton(NotificationSafeHandle handle, int index);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_extension_event_handler")]
        internal static partial NotificationError SetExtensionAction(NotificationSafeHandle handle, NotificationEventType type, SafeAppControlHandle appcontrol);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_extension_event_handler")]
        internal static partial NotificationError GetExtensionAction(NotificationSafeHandle handle, NotificationEventType type, out SafeAppControlHandle appcontrol);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_clone")]
        internal static partial NotificationError Clone(IntPtr handle, out IntPtr cloned);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_check_box")]
        internal static partial NotificationError SetCheckBox(NotificationSafeHandle handle, [MarshalAs(UnmanagedType.U1)] bool flag, [MarshalAs(UnmanagedType.U1)] bool checkedValue);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_check_box")]
        internal static partial NotificationError GetCheckBox(NotificationSafeHandle handle, [MarshalAs(UnmanagedType.U1)] out bool flag, [MarshalAs(UnmanagedType.U1)] out bool checkedValue);

        /* apis for do not disturb app */
        internal delegate void DisturbCallback(IntPtr userData);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_register_do_not_disturb_app")]
        internal static partial NotificationError RegisterDndApp(DisturbCallback cb, IntPtr userData);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_unregister_do_not_disturb_app")]
        internal static partial NotificationError UnRegisterDndApp();

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_pairing_type")]
        internal static partial NotificationError SetPairingType(NotificationSafeHandle handle, [MarshalAs(UnmanagedType.U1)] bool pairing);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_pairing_type")]
        internal static partial NotificationError GetPairingType(NotificationSafeHandle handle, [MarshalAs(UnmanagedType.U1)] out bool pairing);


        [LibraryImport(Libraries.Notification, EntryPoint = "notification_set_extension_image_size")]
        internal static partial NotificationError SetExtensionImageSize(NotificationSafeHandle handle, int height);

        [LibraryImport(Libraries.Notification, EntryPoint = "notification_get_extension_image_size")]
        internal static partial NotificationError GetExtensionImageSize(NotificationSafeHandle handle, out int height);

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




