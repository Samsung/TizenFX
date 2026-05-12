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
using System.Runtime.InteropServices.Marshalling;
using Tizen.Applications;
using Tizen.Applications.ComponentBased;

internal static partial class Interop
{
    internal static partial class ComponentPort
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ComponentPortRequestCallback(string sender, IntPtr request, IntPtr userData);
        // typedef void (*component_port_request_cb)(const char *sender, parcel_h request, void *user_data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ComponentPortSyncRequestCallback(string sender, IntPtr request, IntPtr response, IntPtr userData);
        // typedef void (*component_port_request_cb)(const char *sender, parcel_h request, parcel_h response, void *user_data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ComponentPortAppearedCallback(string endpoint, int owner, IntPtr userData);
        // typedef void (*component_port_appeared_cb)(const char *endpoint, int owner, owner user_data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ComponentPortVanishedCallback(string endpoint, IntPtr userData);
        // typedef void (*component_port_vanished_cb)(const char *endpoint, void *user_data);


        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            IOError = Tizen.Internals.Errors.ErrorCode.IoError,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
        }

        [LibraryImport(Libraries.ComponentPort, EntryPoint = "component_port_create", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode Create(string portName, out IntPtr handle);
        // int component_port_create(const char *port_name, component_port_h *port);

        [LibraryImport(Libraries.ComponentPort, EntryPoint = "component_port_destroy")]
        internal static partial ErrorCode Destroy(IntPtr handle);
        // int component_port_destroy(component_port_h port);

        [LibraryImport(Libraries.ComponentPort, EntryPoint = "component_port_set_request_cb")]
        internal static partial ErrorCode SetRequestCb(IntPtr handle, ComponentPortRequestCallback callback, IntPtr userData);
        // int component_port_set_request_cb(component_port_h port, component_port_request_cb callback, void *user_data);

        [LibraryImport(Libraries.ComponentPort, EntryPoint = "component_port_set_sync_request_cb")]
        internal static partial ErrorCode SetSyncRequestCb(IntPtr handle, ComponentPortSyncRequestCallback callback, IntPtr userData);
        // int component_port_set_sync_request_cb(component_port_h port, component_port_sync_request_cb callback, void *user_data);

        [LibraryImport(Libraries.ComponentPort, EntryPoint = "component_port_add_privilege", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AddPrivilege(IntPtr handle, string privilege);
        // int component_port_add_privilege(component_port_h port, const char *privilege);

        [LibraryImport(Libraries.ComponentPort, EntryPoint = "component_port_wait_for_event")]
        internal static partial void WaitForEvent(IntPtr handle);
        // void component_port_wait_for_event(component_port_h port);

        [LibraryImport(Libraries.ComponentPort, EntryPoint = "component_port_cancel")]
        internal static partial void Cancel(IntPtr handle);
        // void component_port_cancel(component_port_h port);

        [LibraryImport(Libraries.ComponentPort, EntryPoint = "component_port_send", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode Send(IntPtr handle, string endpoint, Int32 timeout, SafeParcelHandle request);
        // int component_port_send(component_port_h port, const char *endpoint, int timeout, parcel_h request);

        [LibraryImport(Libraries.ComponentPort, EntryPoint = "component_port_send_sync", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode SendSync(IntPtr handle, string endpoint, Int32 timeout, SafeParcelHandle request, out SafeParcelHandle response);
        // int component_port_send(component_port_h port, const char *endpoint, int timeout, parcel_h request, parcel_h *response);

        [LibraryImport(Libraries.ComponentPort, EntryPoint = "component_port_is_running", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode IsRunning(string endpoint, [MarshalAs(UnmanagedType.U1)] out bool isRunning);
        // int component_port_is_running(const char *endpoint, [MarshalAs(UnmanagedType.U1)] bool *is_running);

        [LibraryImport(Libraries.ComponentPort, EntryPoint = "component_port_watch", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode Watch(string endpoint, ComponentPortAppearedCallback appearedCallback, ComponentPortVanishedCallback vanishedCallback, IntPtr userData, out uint watcherId);
        // int component_port_watch(const char *endpoint, component_port_appeared_cb appeared_cb, component_port_vanished_cb vanished_cb, void *user_data, unsigned int *watcher_id);

        [LibraryImport(Libraries.ComponentPort, EntryPoint = "component_port_unwatch")]
        internal static partial ErrorCode Unwatch(uint watcherId);
        // int component_port_unwatch(unsigned int watcher_id);
    }
}



