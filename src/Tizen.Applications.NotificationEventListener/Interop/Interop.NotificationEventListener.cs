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
using System.Runtime.InteropServices.Marshalling;

using Tizen.Applications;
using Tizen.Applications.NotificationEventListener;

internal static partial class Interop
{
    internal static partial class NotificationEventListener
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

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_free")]
        internal static partial ErrorCode Destroy(IntPtr handle);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_id")]
        internal static partial ErrorCode GetID(NotificationSafeHandle handle, out int groupId, out int privateId);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_pkgname")]
        internal static partial ErrorCode GetAppIdReferenceType(NotificationSafeHandle handle, out IntPtr appid);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_text")]
        internal static partial ErrorCode GetTextReferenceType(NotificationSafeHandle handle, NotificationText type, out IntPtr text);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_image")]
        internal static partial ErrorCode GetImageReferenceType(NotificationSafeHandle handle, NotificationImage type, out IntPtr text);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_insert_time")]
        internal static partial ErrorCode GetInsertTime(NotificationSafeHandle handle, out int time);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_time")]
        internal static partial ErrorCode GetTime(NotificationSafeHandle handle, out int time);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_sound")]
        internal static partial ErrorCode GetSoundReferenceType(NotificationSafeHandle handle, out AccessoryOption type, out IntPtr path);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_vibration")]
        internal static partial ErrorCode GetVibrationReferenceType(NotificationSafeHandle handle, out AccessoryOption type, out IntPtr path);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_led")]
        internal static partial ErrorCode GetLed(NotificationSafeHandle handle, out AccessoryOption type, out int color);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_led_time_period")]
        internal static partial ErrorCode GetLedTime(NotificationSafeHandle handle, out int onMilliSeconds, out int offMilliSeconds);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_tag")]
        internal static partial ErrorCode GetTagReferenceType(NotificationSafeHandle handle, out IntPtr tag);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_display_applist")]
        internal static partial ErrorCode GetStyleList(NotificationSafeHandle handle, out int styleList);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_auto_remove")]
        internal static partial ErrorCode GetAutoRemove(NotificationSafeHandle handle, [MarshalAs(UnmanagedType.U1)] out bool autoRemove);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_text_input_max_length")]
        internal static partial ErrorCode GetPlaceHolderLength(NotificationSafeHandle handle, out int max);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_launch_option")]
        internal static partial ErrorCode GetAppControl(NotificationSafeHandle handle, LaunchOption type, out SafeAppControlHandle appControlHandle);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_event_handler")]
        internal static partial ErrorCode GetEventHandler(NotificationSafeHandle handle, int type, out SafeAppControlHandle appControlHandle);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_register_detailed_changed_cb")]
        internal static partial ErrorCode SetChangedCallback(ChangedCallback callback, IntPtr userData);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_unregister_detailed_changed_cb")]
        internal static partial ErrorCode UnsetChangedCallback(ChangedCallback callback);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_op_get_data")]
        internal static partial ErrorCode GetOperationData(IntPtr operationList, NotificationOperationDataType type, out IntPtr userData);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_list_get_data")]
        internal static partial IntPtr GetData(IntPtr notificationList);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_list_get_next")]
        internal static partial IntPtr GetNext(IntPtr notificationList);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_delete_by_priv_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode Delete(string appId, NotificationType type, int uniqueNumber);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_clear")]
        internal static partial ErrorCode DeleteAll(int type);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_list")]
        internal static partial ErrorCode GetList(NotificationType type, int count, out IntPtr notification);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_send_event_by_priv_id")]
        internal static partial ErrorCode SendEvent(int uniqueNumber, int evnetType);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_layout")]
        internal static partial ErrorCode GetLayout(NotificationSafeHandle handle, out NotificationLayout type);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_type")]
        internal static partial ErrorCode GetType(NotificationSafeHandle handle, out NotificationType type);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_ongoing_value_type")]
        internal static partial ErrorCode GetOngoingType(NotificationSafeHandle handle, out ProgressCategory category);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_size")]
        internal static partial ErrorCode GetProgressSize(NotificationSafeHandle handle, out double value);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_progress")]
        internal static partial ErrorCode GetProgress(NotificationSafeHandle handle, out double value);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_property")]
        internal static partial ErrorCode GetProperties(NotificationSafeHandle handle, out int flags);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_extension_data", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetExtender(NotificationSafeHandle handle, string key, out SafeBundleHandle value);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_clone")]
        internal static partial ErrorCode GetClone(IntPtr handle, out IntPtr value);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_free_list")]
        internal static partial ErrorCode NotificationListFree(IntPtr list);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_args")]
        internal static partial ErrorCode GetExtensionBundle(NotificationSafeHandle handle, out IntPtr args, out IntPtr groupArgs);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_hide_timeout")]
        internal static partial ErrorCode GetHideTimeout(NotificationSafeHandle handle, out int timeout);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_delete_timeout")]
        internal static partial ErrorCode GetDeleteTimeout(NotificationSafeHandle handle, out int timeout);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_event_flag")]
        internal static partial ErrorCode GetEventFlag(NotificationSafeHandle handle, [MarshalAs(UnmanagedType.U1)] out bool eventFlag);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_default_button")]
        internal static partial ErrorCode GetDefaultButton(NotificationSafeHandle handle, out int index);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_extension_event_handler")]
        internal static partial ErrorCode GetExtensionAction(NotificationSafeHandle handle, UserEventType type, out SafeAppControlHandle appcontrol);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_load", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial IntPtr LoadNotification(string appID, int uniqueID);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_all_count")]
        internal static partial ErrorCode GetAllCount(NotificationType type, out int count);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_set_check_box_checked")]
        internal static partial ErrorCode SetCheckedValue(NotificationSafeHandle handle, [MarshalAs(UnmanagedType.U1)] bool checkedValue);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_check_box")]
        internal static partial ErrorCode GetCheckBox(NotificationSafeHandle handle, [MarshalAs(UnmanagedType.U1)] out bool flag, [MarshalAs(UnmanagedType.U1)] out bool checkedValue);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_send_event")]
        internal static partial ErrorCode SendEventWithNotification(NotificationSafeHandle handle, int evnetType);

        [LibraryImport(Libraries.NotificationEventListener, EntryPoint = "notification_get_extension_image_size")]
        internal static partial ErrorCode GetExtensionImageSize(NotificationSafeHandle handle, out int height);

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

            internal NotificationSafeHandle(IntPtr existingHandle, [MarshalAs(UnmanagedType.U1)] bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
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






