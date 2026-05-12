/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

internal static partial class Interop
{
    internal static partial class AppControl
    {
        internal const int AppStartedStatus = 1;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ExtraDataCallback(IntPtr handle, string key, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AppMatchedCallback(IntPtr handle, string applicationId, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ReplyCallback(IntPtr request, IntPtr reply, int result, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ResultCallback(IntPtr request, int result, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool DefaultApplicationCallback(string applicationId, IntPtr userData);

        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            AppNotFound = -0x01100000 | 0x21,
            KeyNotFound = Tizen.Internals.Errors.ErrorCode.KeyNotAvailable,
            KeyRejected = Tizen.Internals.Errors.ErrorCode.KeyRejected,
            InvalidDataType = -0x01100000 | 0x22,
            LaunchRejected = -0x01100000 | 0x23,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            LaunchFailed = -0x01100000 | 0x24,
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,
            TimedOut = Tizen.Internals.Errors.ErrorCode.TimedOut,
        }

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_create")]
        internal static partial ErrorCode Create(out SafeAppControlHandle handle);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_clone")]
        internal static partial ErrorCode DangerousClone(out SafeAppControlHandle clone, IntPtr handle);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_get_app_id")]
        internal static partial ErrorCode GetAppId(IntPtr app_control, out IntPtr app_id);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_get_operation", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetOperation(SafeAppControlHandle handle, out string operation);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_set_operation", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode SetOperation(SafeAppControlHandle handle, string operation);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_get_uri", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetUri(SafeAppControlHandle handle, out string uri);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_set_uri", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode SetUri(SafeAppControlHandle handle, string uri);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_get_mime", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetMime(SafeAppControlHandle handle, out string mime);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_set_mime", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode SetMime(SafeAppControlHandle handle, string mime);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_get_category", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetCategory(SafeAppControlHandle handle, out string category);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_set_category", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode SetCategory(SafeAppControlHandle handle, string category);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_get_app_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetAppId(SafeAppControlHandle handle, out string appId);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_set_app_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode SetAppId(SafeAppControlHandle handle, string appId);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_set_launch_mode")]
        internal static partial ErrorCode SetLaunchMode(SafeAppControlHandle handle, int mode);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_get_launch_mode")]
        internal static partial ErrorCode GetLaunchMode(SafeAppControlHandle handle, out int mode);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_get_caller", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetCaller(SafeAppControlHandle handle, out string caller);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_is_reply_requested")]
        internal static partial ErrorCode IsReplyRequested(SafeAppControlHandle handle, [MarshalAs(UnmanagedType.U1)] out bool requested);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_add_extra_data", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AddExtraData(SafeAppControlHandle handle, string key, string value);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_remove_extra_data", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode RemoveExtraData(SafeAppControlHandle handle, string key);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_get_extra_data", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetExtraData(SafeAppControlHandle handle, string key, out string value);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_add_extra_data_array", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AddExtraDataArray(SafeAppControlHandle handle, string key, string[] value, int length);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_get_extra_data_array", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetExtraDataArray(SafeAppControlHandle handle, string key, out IntPtr value, out int length);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_is_extra_data_array", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode IsExtraDataArray(SafeAppControlHandle handle, string key, [MarshalAs(UnmanagedType.U1)] out bool array);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_destroy")]
        internal static partial ErrorCode DangerousDestroy(IntPtr handle);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_foreach_extra_data")]
        internal static partial ErrorCode ForeachExtraData(SafeAppControlHandle handle, ExtraDataCallback callback, IntPtr userData);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_foreach_app_matched")]
        internal static partial ErrorCode ForeachAppMatched(SafeAppControlHandle handle, AppMatchedCallback callback, IntPtr userData);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_send_launch_request")]
        internal static partial ErrorCode SendLaunchRequest(SafeAppControlHandle handle, ReplyCallback callback, IntPtr userData);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_send_terminate_request")]
        internal static partial ErrorCode SendTerminateRequest(SafeAppControlHandle handle);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_reply_to_launch_request")]
        internal static partial ErrorCode ReplyToLaunchRequest(SafeAppControlHandle reply, SafeAppControlHandle request, int result);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_enable_app_started_result_event")]
        internal static partial ErrorCode EnableAppStartedResultEvent(SafeAppControlHandle handle);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_send_launch_request_async")]
        internal static partial ErrorCode SendLaunchRequestAsync(SafeAppControlHandle handle, ResultCallback resultCallback, ReplyCallback replyCallback, IntPtr userData);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_set_component_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode SetComponentId(SafeAppControlHandle handle, string componentId);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_get_component_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetComponentId(SafeAppControlHandle handle, out string componentId);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_set_auto_restart")]
        internal static partial ErrorCode SetAutoRestart(SafeAppControlHandle handle);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_send_launch_request_with_timeout")]
        internal static partial ErrorCode SendLaunchRequestWithTimeout(SafeAppControlHandle handle, uint timeout, ReplyCallback callback, IntPtr userData);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_foreach_default_application")]
        internal static partial ErrorCode ForeachDefaultApplication(DefaultApplicationCallback callback, IntPtr userData);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_set_window_position")]
        internal static partial ErrorCode SetWindowPosition(SafeAppControlHandle handle, int x, int y, int w, int h);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_get_window_position")]
        internal static partial ErrorCode GetWindowPosition(SafeAppControlHandle handle, out int x, out int y, out int w, out int h);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_unset_auto_restart")]
        internal static partial ErrorCode UnsetAutoRestart();

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_set_screen_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode SetScreenName(SafeAppControlHandle handle, string screen_name);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_get_screen_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode GetScreenName(SafeAppControlHandle handle, out string screen_name);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_set_defapp", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode SetDefaultApplication(SafeAppControlHandle handle, string appId);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_unset_defapp", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode UnsetDefaultApplication(string appId);

        [LibraryImport(Libraries.AppControl, EntryPoint = "app_control_export_as_bundle")]
        internal static partial ErrorCode ExportAsBundle(SafeAppControlHandle handle, out IntPtr bundle);
    }
}




