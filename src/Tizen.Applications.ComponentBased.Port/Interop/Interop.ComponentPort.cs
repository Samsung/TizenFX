/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.InteropServices;
using Tizen.Applications;
using Tizen.Applications.ComponentBased;

internal static partial class Interop
{
    internal static partial class ComponentPort
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ComponentPortRequestCallback(string sender, IntPtr request, IntPtr userData);
        // typedef void (*component_port_request_cb)(const char *sender, parcel_h request, IntPtr user_data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ComponentPortSyncRequestCallback(string sender, IntPtr request, IntPtr response, IntPtr userData);
        // typedef void (*component_port_request_cb)(const char *sender, parcel_h request, parcel_h response IntPtr user_data);

        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            IOError = Tizen.Internals.Errors.ErrorCode.IoError,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
        }

        [DllImport(Libraries.ComponentPort, EntryPoint = "component_port_create")]
        internal static extern ErrorCode Create(string portName, out SafePortHandle handle);
        // int component_port_create(const char *port_name, component_port_h *port);

        [DllImport(Libraries.ComponentPort, EntryPoint = "component_port_destroy")]
        internal static extern ErrorCode DangerousDestroy(IntPtr handle);
        // int component_port_destroy(component_port_h port);

        [DllImport(Libraries.ComponentPort, EntryPoint = "component_port_set_request_cb")]
        internal static extern ErrorCode SetRequestCb(SafePortHandle handle, ComponentPortRequestCallback callback, IntPtr userData);
        // int component_port_set_request_cb(component_port_h port, component_port_request_cb callback, void *user_data);

        [DllImport(Libraries.ComponentPort, EntryPoint = "component_port_set_sync_request_cb")]
        internal static extern ErrorCode SetSyncRequestCb(SafePortHandle handle, ComponentPortSyncRequestCallback callback, IntPtr userData);
        // int component_port_set_sync_request_cb(component_port_h port, component_port_sync_request_cb callback, void *user_data);

        [DllImport(Libraries.ComponentPort, EntryPoint = "component_port_add_privilege")]
        internal static extern ErrorCode AddPrivilege(SafePortHandle handle, string privilege);
        // int component_port_add_privilege(component_port_h port, const char *privilege);

        [DllImport(Libraries.ComponentPort, EntryPoint = "component_port_wait_for_event")]
        internal static extern void WaitForEvent(SafePortHandle handle);
        // void component_port_wait_for_event(component_port_h port);

        [DllImport(Libraries.ComponentPort, EntryPoint = "component_port_cancel")]
        internal static extern void Cancel(SafePortHandle handle);
        // void component_port_cancel(component_port_h port);

        [DllImport(Libraries.ComponentPort, EntryPoint = "component_port_send")]
        internal static extern ErrorCode Send(SafePortHandle handle, string endpoint, Int32 timeout, SafeParcelHandle request);
        // int component_port_send(component_port_h port, const char *endpoint, int timeout, parcel_h request);

        [DllImport(Libraries.ComponentPort, EntryPoint = "component_port_send_sync")]
        internal static extern ErrorCode SendSync(SafePortHandle handle, string endpoint, Int32 timeout, SafeParcelHandle request, out SafeParcelHandle response);
        // int component_port_send(component_port_h port, const char *endpoint, int timeout, parcel_h request, parcel_h *response);
    }
}