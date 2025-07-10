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
        internal static extern ErrorCode GetID(NotificationSafeHandle handle, out int groupId, out int privateId);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_pkgname")]
        internal static extern ErrorCode GetAppIdReferenceType(NotificationSafeHandle handle, out IntPtr appid);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_text")]
        internal static extern ErrorCode GetTextReferenceType(NotificationSafeHandle handle, NotificationText type, out IntPtr text);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_image")]
        internal static extern ErrorCode GetImageReferenceType(NotificationSafeHandle handle, NotificationImage type, out IntPtr text);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_insert_time")]
        internal static extern ErrorCode GetInsertTime(NotificationSafeHandle handle, out int time);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_time")]
        internal static extern ErrorCode GetTime(NotificationSafeHandle handle, out int time);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_sound")]
        internal static extern ErrorCode GetSoundReferenceType(NotificationSafeHandle handle, out AccessoryOption type, out IntPtr path);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_vibration")]
        internal static extern ErrorCode GetVibrationReferenceType(NotificationSafeHandle handle, out AccessoryOption type, out IntPtr path);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_led")]
        internal static extern ErrorCode GetLed(NotificationSafeHandle handle, out AccessoryOption type, out int color);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_led_time_period")]
        internal static extern ErrorCode GetLedTime(NotificationSafeHandle handle, out int onMilliSeconds, out int offMilliSeconds);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_tag")]
        internal static extern ErrorCode GetTagReferenceType(NotificationSafeHandle handle, out IntPtr tag);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_display_applist")]
        internal static extern ErrorCode GetStyleList(NotificationSafeHandle handle, out int styleList);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_auto_remove")]
        internal static extern ErrorCode GetAutoRemove(NotificationSafeHandle handle, out bool autoRemove);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_text_input_max_length")]
        internal static extern ErrorCode GetPlaceHolderLength(NotificationSafeHandle handle, out int max);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_launch_option")]
        internal static extern ErrorCode GetAppControl(NotificationSafeHandle handle, LaunchOption type, out SafeAppControlHandle appControlHandle);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_event_handler")]
        internal static extern ErrorCode GetEventHandler(NotificationSafeHandle handle, int type, out SafeAppControlHandle appControlHandle);

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
        internal static extern ErrorCode GetLayout(NotificationSafeHandle handle, out NotificationLayout type);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_type")]
        internal static extern ErrorCode GetType(NotificationSafeHandle handle, out NotificationType type);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_ongoing_value_type")]
        internal static extern ErrorCode GetOngoingType(NotificationSafeHandle handle, out ProgressCategory category);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_size")]
        internal static extern ErrorCode GetProgressSize(NotificationSafeHandle handle, out double value);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_progress")]
        internal static extern ErrorCode GetProgress(NotificationSafeHandle handle, out double value);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_property")]
        internal static extern ErrorCode GetProperties(NotificationSafeHandle handle, out int flags);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_extension_data")]
        internal static extern ErrorCode GetExtender(NotificationSafeHandle handle, string key, out SafeBundleHandle value);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_clone")]
        internal static extern ErrorCode GetClone(IntPtr handle, out IntPtr value);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_free_list")]
        internal static extern ErrorCode NotificationListFree(IntPtr list);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_args")]
        internal static extern ErrorCode GetExtensionBundle(NotificationSafeHandle handle, out IntPtr args, out IntPtr groupArgs);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_hide_timeout")]
        internal static extern ErrorCode GetHideTimeout(NotificationSafeHandle handle, out int timeout);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_delete_timeout")]
        internal static extern ErrorCode GetDeleteTimeout(NotificationSafeHandle handle, out int timeout);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_event_flag")]
        internal static extern ErrorCode GetEventFlag(NotificationSafeHandle handle, out bool eventFlag);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_default_button")]
        internal static extern ErrorCode GetDefaultButton(NotificationSafeHandle handle, out int index);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_extension_event_handler")]
        internal static extern ErrorCode GetExtensionAction(NotificationSafeHandle handle, UserEventType type, out SafeAppControlHandle appcontrol);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_load")]
        internal static extern IntPtr LoadNotification(string appID, int uniqueID);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_all_count")]
        internal static extern ErrorCode GetAllCount(NotificationType type, out int count);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_set_check_box_checked")]
        internal static extern ErrorCode SetCheckedValue(NotificationSafeHandle handle, bool checkedValue);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_check_box")]
        internal static extern ErrorCode GetCheckBox(NotificationSafeHandle handle, out bool flag, out bool checkedValue);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_send_event")]
        internal static extern ErrorCode SendEventWithNotification(NotificationSafeHandle handle, int evnetType);

        [DllImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_extension_image_size")]
        internal static extern ErrorCode GetExtensionImageSize(NotificationSafeHandle handle, out int height);

        internal static ErrorCode GetAppId(NotificationSafeHandle handle, out string appid)
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

        internal static ErrorCode GetText(NotificationSafeHandle handle, NotificationText type, out string text)
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

        internal static ErrorCode GetImage(NotificationSafeHandle handle, NotificationImage type, out string text)
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

        internal static ErrorCode GetSound(NotificationSafeHandle handle, out AccessoryOption type, out string path)
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

        internal static ErrorCode GetVibration(NotificationSafeHandle handle, out AccessoryOption type, out string path)
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

        internal static ErrorCode GetTag(NotificationSafeHandle handle, out string tag)
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

        internal sealed class NotificationSafeHandle : SafeHandle
        {
            public NotificationSafeHandle()
                : base(IntPtr.Zero, true)
            {
            }

            internal NotificationSafeHandle(IntPtr existingHandle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
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
