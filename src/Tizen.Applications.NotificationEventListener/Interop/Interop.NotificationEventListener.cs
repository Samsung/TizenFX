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
using System.Collections.Generic;
using System.Runtime.InteropServices;

using Tizen.Applications;
using Tizen.Applications.NotificationEventListener;

internal static partial class Interop
{
    internal static class NotificationEventListener
    {
        internal delegate void ChangedCallback(IntPtr userData, NotificationType type, IntPtr operationList, int num);

        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,
            DbError = -0x01140000 | 0x01,
            AlreadyExists = -0x01140000 | 0x02,
            DBusError = -0x01140000 | 0x03,
            DoesnotExist = -0x01140000 | 0x04,
            ServiceError = -0x01140000 | 0x05,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            InvalidOperation = Tizen.Internals.Errors.ErrorCode.InvalidOperation
        }

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_free")]
        internal static extern ErrorCode Destroy(IntPtr handle);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_id")]
        internal static extern ErrorCode GetID(SafeNotificationHandle handle, out int groupId, out int privateId);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_pkgname")]
        internal static extern ErrorCode GetAppIdReferenceType(SafeNotificationHandle handle, out IntPtr appid);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_text")]
        internal static extern ErrorCode GetTextReferenceType(SafeNotificationHandle handle, NotificationText type, out IntPtr text);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_image")]
        internal static extern ErrorCode GetImageReferenceType(SafeNotificationHandle handle, NotificationImage type, out IntPtr text);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_insert_time")]
        internal static extern ErrorCode GetInsertTime(SafeNotificationHandle handle, out int time);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_time")]
        internal static extern ErrorCode GetTime(SafeNotificationHandle handle, out int time);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_sound")]
        internal static extern ErrorCode GetSoundReferenceType(SafeNotificationHandle handle, out AccessoryOption type, out IntPtr path);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_vibration")]
        internal static extern ErrorCode GetVibrationReferenceType(SafeNotificationHandle handle, out AccessoryOption type, out IntPtr path);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_led")]
        internal static extern ErrorCode GetLed(SafeNotificationHandle handle, out AccessoryOption type, out int color);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_led_time_period")]
        internal static extern ErrorCode GetLedTime(SafeNotificationHandle handle, out int onMilliSeconds, out int offMilliSeconds);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_tag")]
        internal static extern ErrorCode GetTagReferenceType(SafeNotificationHandle handle, out IntPtr tag);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_display_applist")]
        internal static extern ErrorCode GetStyleList(SafeNotificationHandle handle, out int styleList);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_auto_remove")]
        internal static extern ErrorCode GetAutoRemove(SafeNotificationHandle handle, out bool autoRemove);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_text_input_max_length")]
        internal static extern ErrorCode GetPlaceHolderLength(SafeNotificationHandle handle, out int max);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_launch_option")]
        internal static extern ErrorCode GetAppControl(SafeNotificationHandle handle, LaunchOption type, out SafeAppControlHandle appControlHandle);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_event_handler")]
        internal static extern ErrorCode GetEventHandler(SafeNotificationHandle handle, int type, out SafeAppControlHandle appControlHandle);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_register_detailed_changed_cb")]
        internal static extern ErrorCode SetChangedCallback(ChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_unregister_detailed_changed_cb")]
        internal static extern ErrorCode UnsetChangedCallback(ChangedCallback callback);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_op_get_data")]
        internal static extern ErrorCode GetOperationData(IntPtr operationList, NotificationOperationDataType type, out IntPtr userData);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_list_get_data")]
        internal static extern IntPtr GetData(IntPtr notificationList);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_list_get_next")]
        internal static extern IntPtr GetNext(IntPtr notificationList);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_delete_by_priv_id")]
        internal static extern ErrorCode Delete(string appId, NotificationType type, int uniqueNumber);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_clear")]
        internal static extern ErrorCode DeleteAll(int type);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_list")]
        internal static extern ErrorCode GetList(NotificationType type, int count, out IntPtr notification);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_send_event_by_priv_id")]
        internal static extern ErrorCode SendEvent(int uniqueNumber, int evnetType);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_layout")]
        internal static extern ErrorCode GetLayout(SafeNotificationHandle handle, out NotificationLayout type);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_type")]
        internal static extern ErrorCode GetType(SafeNotificationHandle handle, out NotificationType type);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_ongoing_value_type")]
        internal static extern ErrorCode GetOngoingType(SafeNotificationHandle handle, out ProgressCategory category);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_size")]
        internal static extern ErrorCode GetProgressSize(SafeNotificationHandle handle, out double value);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_progress")]
        internal static extern ErrorCode GetProgress(SafeNotificationHandle handle, out double value);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_property")]
        internal static extern ErrorCode GetProperties(SafeNotificationHandle handle, out int flags);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_extention_data")]
        internal static extern ErrorCode GetExtender(SafeNotificationHandle handle, string key, out SafeBundleHandle value);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_clone")]
        internal static extern ErrorCode GetClone(IntPtr handle, out IntPtr value);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_free_list")]
        internal static extern ErrorCode NotificationListFree(IntPtr list);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_args")]
        internal static extern ErrorCode GetExtentionBundle(SafeNotificationHandle handle, out IntPtr args, out IntPtr groupArgs);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_hide_timeout")]
        internal static extern ErrorCode GetHideTimeout(SafeNotificationHandle handle, out int timeout);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_delete_timeout")]
        internal static extern ErrorCode GetDeleteTimeout(SafeNotificationHandle handle, out int timeout);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_event_flag")]
        internal static extern ErrorCode GetEventFlag(SafeNotificationHandle handle, out bool eventFlag);

        internal static ErrorCode GetAppId(SafeNotificationHandle handle, out string appid)
        {
            ErrorCode err;
            IntPtr ptr;
            err = GetAppIdReferenceType(handle, out ptr);

            if (ptr == IntPtr.Zero)
            {
                appid = null;
            }
            else
            {
                appid = Marshal.PtrToStringAnsi(ptr);
            }

            return err;
        }

        internal static ErrorCode GetText(SafeNotificationHandle handle, NotificationText type, out string text)
        {
            ErrorCode err;
            IntPtr ptr;
            err = GetTextReferenceType(handle, type, out ptr);

            if (ptr == IntPtr.Zero)
            {
                text = null;
            }
            else
            {
                text = Marshal.PtrToStringAnsi(ptr);
            }

            return err;
        }

        internal static ErrorCode GetImage(SafeNotificationHandle handle, NotificationImage type, out string text)
        {
            ErrorCode err;
            IntPtr ptr;
            err = GetImageReferenceType(handle, type, out ptr);

            if (ptr == IntPtr.Zero)
            {
                text = null;
            }
            else
            {
                text = Marshal.PtrToStringAnsi(ptr);
            }

            return err;
        }

        internal static ErrorCode GetSound(SafeNotificationHandle handle, out AccessoryOption type, out string path)
        {
            ErrorCode err;
            IntPtr ptr;
            err = GetSoundReferenceType(handle, out type, out ptr);

            if (ptr == IntPtr.Zero)
            {
                path = null;
            }
            else
            {
                path = Marshal.PtrToStringAnsi(ptr);
            }

            return err;
        }

        internal static ErrorCode GetVibration(SafeNotificationHandle handle, out AccessoryOption type, out string path)
        {
            ErrorCode err;
            IntPtr ptr;
            err = GetVibrationReferenceType(handle, out type, out ptr);

            if (ptr == IntPtr.Zero)
            {
                path = null;
            }
            else
            {
                path = Marshal.PtrToStringAnsi(ptr);
            }

            return err;
        }

        internal static ErrorCode GetTag(SafeNotificationHandle handle, out string tag)
        {
            ErrorCode err;
            IntPtr ptr;
            err = GetTagReferenceType(handle, out ptr);

            if (ptr == IntPtr.Zero)
            {
                tag = null;
            }
            else
            {
                tag = Marshal.PtrToStringAnsi(ptr);
            }

            return err;
        }

        internal sealed class SafeNotificationHandle : SafeHandle
        {
            public SafeNotificationHandle()
                : base(IntPtr.Zero, true)
            {
            }

            internal SafeNotificationHandle(IntPtr existingHandle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
            {
                SetHandle(existingHandle);
            }

            public override bool IsInvalid
            {
                get { return this.handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                NotificationEventListener.Destroy(this.handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }
    }
}
