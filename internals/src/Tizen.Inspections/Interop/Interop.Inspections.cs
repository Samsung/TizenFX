/*
* Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Internals;

internal static partial class Interop
{
    internal static partial class Inspections
    {
        internal static string LogTag = "Tizen.Inspections";

        internal enum InspectionError
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            ResourceBusy = Tizen.Internals.Errors.ErrorCode.ResourceBusy,
            TimedOut = Tizen.Internals.Errors.ErrorCode.TimedOut,
            NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
            TryAgain = Tizen.Internals.Errors.ErrorCode.TryAgain,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied
        };

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void NotificationCallback(IntPtr ctx, IntPtr data);

        [DllImport(Libraries.Diagnostics, EntryPoint = "diagnostics_set_notification_cb")]
        internal static extern InspectionError SetNotificationCb(NotificationCallback callback, IntPtr data);

        [DllImport(Libraries.Diagnostics, EntryPoint = "diagnostics_unset_notification_cb")]
        internal static extern InspectionError UnsetNotificationCb();

        [DllImport(Libraries.Diagnostics, EntryPoint = "diagnostics_request_client_data")]
        internal static extern InspectionError RequestClientData(string client_id, string[] parameters, int params_size, out IntPtr data);

        [DllImport(Libraries.Diagnostics, EntryPoint = "diagnostics_data_read")]
        internal static extern InspectionError DataRead(IntPtr data, IntPtr buf, uint count, int timeout_ms, out uint bytes_read);

        [DllImport(Libraries.Diagnostics, EntryPoint = "diagnostics_data_destroy")]
        internal static extern void DataDestroy(IntPtr data);

        [DllImport(Libraries.Diagnostics, EntryPoint = "diagnostics_get_client_id")]
        internal static extern InspectionError GetClientID(IntPtr ctx, out string client_id);

        [DllImport(Libraries.Diagnostics, EntryPoint = "diagnostics_get_data")]
        internal static extern InspectionError GetData(IntPtr ctx, string[] parameters, int params_size, out IntPtr data);

        [DllImport(Libraries.Diagnostics, EntryPoint = "diagnostics_destroy")]
        internal static extern void Destroy(IntPtr data);
    }
}
