/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
    internal static partial class AppEvent
    {
        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,
            TimeOut = Tizen.Internals.Errors.ErrorCode.TimedOut,
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void EventCallback(string eventName, IntPtr eventData, IntPtr userData);

        [DllImport(Libraries.AppEvent, EntryPoint = "event_add_event_handler")]
        internal static extern ErrorCode EventAddHandler(string eventName, EventCallback cb, IntPtr userData, out IntPtr handle);

        [DllImport(Libraries.AppEvent, EntryPoint = "event_remove_event_handler")]
        internal static extern ErrorCode EventRemoveHandler(IntPtr handle);

        [DllImport(Libraries.AppEvent, EntryPoint = "event_publish_app_event")]
        internal static extern ErrorCode EventPublishAppEvent(string eventName, SafeBundleHandle eventData);

        [DllImport(Libraries.AppEvent, EntryPoint = "event_publish_trusted_app_event")]
        internal static extern ErrorCode EventPublishTrustedAppEvent(string eventName, SafeBundleHandle eventData);

        [DllImport(Libraries.AppEvent, EntryPoint = "event_keep_last_event_data")]
        internal static extern ErrorCode EventKeepLastEventData(string eventName);
    }
}
