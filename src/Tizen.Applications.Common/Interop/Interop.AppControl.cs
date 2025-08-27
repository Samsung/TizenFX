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

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_create")]
        internal static extern ErrorCode Create(out SafeAppControlHandle handle);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_clone")]
        internal static extern ErrorCode DangerousClone(out SafeAppControlHandle clone, IntPtr handle);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_get_app_id")]
        internal static extern ErrorCode GetAppId(IntPtr app_control, out IntPtr app_id);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_get_operation")]
        internal static extern ErrorCode GetOperation(SafeAppControlHandle handle, out string operation);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_set_operation")]
        internal static extern ErrorCode SetOperation(SafeAppControlHandle handle, string operation);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_get_uri")]
        internal static extern ErrorCode GetUri(SafeAppControlHandle handle, out string uri);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_set_uri")]
        internal static extern ErrorCode SetUri(SafeAppControlHandle handle, string uri);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_get_mime")]
        internal static extern ErrorCode GetMime(SafeAppControlHandle handle, out string mime);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_set_mime")]
        internal static extern ErrorCode SetMime(SafeAppControlHandle handle, string mime);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_get_category")]
        internal static extern ErrorCode GetCategory(SafeAppControlHandle handle, out string category);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_set_category")]
        internal static extern ErrorCode SetCategory(SafeAppControlHandle handle, string category);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_get_app_id")]
        internal static extern ErrorCode GetAppId(SafeAppControlHandle handle, out string appId);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_set_app_id")]
        internal static extern ErrorCode SetAppId(SafeAppControlHandle handle, string appId);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_set_launch_mode")]
        internal static extern ErrorCode SetLaunchMode(SafeAppControlHandle handle, int mode);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_get_launch_mode")]
        internal static extern ErrorCode GetLaunchMode(SafeAppControlHandle handle, out int mode);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_get_caller")]
        internal static extern ErrorCode GetCaller(SafeAppControlHandle handle, out string caller);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_is_reply_requested")]
        internal static extern ErrorCode IsReplyRequested(SafeAppControlHandle handle, out bool requested);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_add_extra_data")]
        internal static extern ErrorCode AddExtraData(SafeAppControlHandle handle, string key, string value);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_remove_extra_data")]
        internal static extern ErrorCode RemoveExtraData(SafeAppControlHandle handle, string key);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_get_extra_data")]
        internal static extern ErrorCode GetExtraData(SafeAppControlHandle handle, string key, out string value);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_add_extra_data_array")]
        internal static extern ErrorCode AddExtraDataArray(SafeAppControlHandle handle, string key, string[] value, int length);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_get_extra_data_array")]
        internal static extern ErrorCode GetExtraDataArray(SafeAppControlHandle handle, string key, out IntPtr value, out int length);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_is_extra_data_array")]
        internal static extern ErrorCode IsExtraDataArray(SafeAppControlHandle handle, string key, out bool array);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_destroy")]
        internal static extern ErrorCode DangerousDestroy(IntPtr handle);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_foreach_extra_data")]
        internal static extern ErrorCode ForeachExtraData(SafeAppControlHandle handle, ExtraDataCallback callback, IntPtr userData);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_foreach_app_matched")]
        internal static extern ErrorCode ForeachAppMatched(SafeAppControlHandle handle, AppMatchedCallback callback, IntPtr userData);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_send_launch_request")]
        internal static extern ErrorCode SendLaunchRequest(SafeAppControlHandle handle, ReplyCallback callback, IntPtr userData);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_send_terminate_request")]
        internal static extern ErrorCode SendTerminateRequest(SafeAppControlHandle handle);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_reply_to_launch_request")]
        internal static extern ErrorCode ReplyToLaunchRequest(SafeAppControlHandle reply, SafeAppControlHandle request, int result);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_enable_app_started_result_event")]
        internal static extern ErrorCode EnableAppStartedResultEvent(SafeAppControlHandle handle);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_send_launch_request_async")]
        internal static extern ErrorCode SendLaunchRequestAsync(SafeAppControlHandle handle, ResultCallback resultCallback, ReplyCallback replyCallback, IntPtr userData);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_set_component_id")]
        internal static extern ErrorCode SetComponentId(SafeAppControlHandle handle, string componentId);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_get_component_id")]
        internal static extern ErrorCode GetComponentId(SafeAppControlHandle handle, out string componentId);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_set_auto_restart")]
        internal static extern ErrorCode SetAutoRestart(SafeAppControlHandle handle);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_send_launch_request_with_timeout")]
        internal static extern ErrorCode SendLaunchRequestWithTimeout(SafeAppControlHandle handle, uint timeout, ReplyCallback callback, IntPtr userData);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_foreach_default_application")]
        internal static extern ErrorCode ForeachDefaultApplication(DefaultApplicationCallback callback, IntPtr userData);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_set_window_position")]
        internal static extern ErrorCode SetWindowPosition(SafeAppControlHandle handle, int x, int y, int w, int h);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_get_window_position")]
        internal static extern ErrorCode GetWindowPosition(SafeAppControlHandle handle, out int x, out int y, out int w, out int h);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_unset_auto_restart")]
        internal static extern ErrorCode UnsetAutoRestart();

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_set_screen_name")]
        internal static extern ErrorCode SetScreenName(SafeAppControlHandle handle, string screen_name);

        [DllImport(Libraries.AppControl, EntryPoint = "app_control_get_screen_name")]
        internal static extern ErrorCode GetScreenName(SafeAppControlHandle handle, out string screen_name);
    }
}
