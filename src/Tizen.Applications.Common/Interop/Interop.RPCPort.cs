/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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

using Tizen.Internals.Errors;
using Tizen.Applications;
using System.Reflection;

internal static partial class Interop
{
    internal static partial class LibRPCPort
    {
        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,
        }

        internal enum PortType
        {
            Main,
            Callback
        }

        internal static partial class Parcel
        {
            //int rpc_port_parcel_create(rpc_port_parcel_h *h);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_create")]
            internal static extern ErrorCode Create(out IntPtr handle);

            //int rpc_port_parcel_create_from_port(rpc_port_parcel_h *h, rpc_port_h port);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_create_from_port")]
            internal static extern ErrorCode CreateFromPort(out IntPtr parcelHandle, IntPtr portHandle);

            //int rpc_port_parcel_send(rpc_port_parcel_h h, rpc_port_h port);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_send")]
            internal static extern ErrorCode Send(IntPtr parcelHandle, IntPtr portHandle);

            //int rpc_port_parcel_destroy(rpc_port_parcel_h h);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_destroy")]
            internal static extern ErrorCode Destroy(IntPtr handle);

            //int rpc_port_parcel_write_byte(rpc_port_parcel_h h, char b);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_byte")]
            internal static extern ErrorCode WriteByte(IntPtr parcelHandle, byte b);

            //int rpc_port_parcel_write_int16(rpc_port_parcel_h h, short i);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_int16")]
            internal static extern ErrorCode WriteInt16(IntPtr parcelHandle, short i);

            //int rpc_port_parcel_write_int32(rpc_port_parcel_h h, int i);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_int32")]
            internal static extern ErrorCode WriteInt32(IntPtr parcelHandle, int i);

            //int rpc_port_parcel_write_int64(rpc_port_parcel_h h, int i);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_int64")]
            internal static extern ErrorCode WriteInt64(IntPtr parcelHandle, long i);

            //int rpc_port_parcel_write_float(rpc_port_parcel_h h, float f);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_float")]
            internal static extern ErrorCode WriteFloat(IntPtr parcelHandle, float f);

            //int rpc_port_parcel_write_double(rpc_port_parcel_h h, double d);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_double")]
            internal static extern ErrorCode WriteDouble(IntPtr parcelHandle, double d);

            //int rpc_port_parcel_write_string(rpc_port_parcel_h h, const char* str);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_string")]
            internal static extern ErrorCode WriteString(IntPtr parcelHandle, string str);

            //int rpc_port_parcel_write_bool(rpc_port_parcel_h h, bool b);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_bool")]
            internal static extern ErrorCode WriteBool(IntPtr parcelHandle, bool b);

            //int rpc_port_parcel_write_bundle(rpc_port_parcel_h h, bundle* b);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_bundle")]
            internal static extern ErrorCode WriteBundle(IntPtr parcelHandle, IntPtr b);

            //int rpc_port_parcel_write_array_count(rpc_port_parcel_h h, int count);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_array_count")]
            internal static extern ErrorCode WriteArrayCount(IntPtr parcelHandle, int count);

            //int rpc_port_parcel_read_byte(rpc_port_parcel_h h, char* b);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_byte")]
            internal static extern ErrorCode ReadByte(IntPtr parcelHandle, out byte b);

            //int rpc_port_parcel_read_int16(rpc_port_parcel_h h, short *i);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_int16")]
            internal static extern ErrorCode ReadInt16(IntPtr parcelHandle, out short i);

            //int rpc_port_parcel_read_int32(rpc_port_parcel_h h, int* i);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_int32")]
            internal static extern ErrorCode ReadInt32(IntPtr parcelHandle, out int i);

            //int rpc_port_parcel_read_int64(rpc_port_parcel_h h, long long* i);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_int64")]
            internal static extern ErrorCode ReadInt64(IntPtr parcelHandle, out long i);

            //int rpc_port_parcel_read_float(rpc_port_parcel_h h, float *f);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_float")]
            internal static extern ErrorCode ReadFloat(IntPtr parcelHandle, out float f);

            //int rpc_port_parcel_read_double(rpc_port_parcel_h h, double *d);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_double")]
            internal static extern ErrorCode ReadDouble(IntPtr parcelHandle, out double f);

            //int rpc_port_parcel_read_string(rpc_port_parcel_h h, char** str);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_string")]
            internal static extern ErrorCode ReadString(IntPtr parcelHandle, out string str);

            //int rpc_port_parcel_read_bool(rpc_port_parcel_h h, bool *b);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_bool")]
            internal static extern ErrorCode ReadBool(IntPtr parcelHandle, out bool b);

            //int rpc_port_parcel_read_bundle(rpc_port_parcel_h h, bundle** b);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_bundle")]
            internal static extern ErrorCode ReadBundle(IntPtr parcelHandle, out IntPtr b);

            //int rpc_port_parcel_read_array_count(rpc_port_parcel_h h, int *count);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_array_count")]
            internal static extern ErrorCode ReadArrayCount(IntPtr parcelHandle, out int count);

            //int rpc_port_parcel_burst_read(rpc_port_parcel_h h, unsigned char *buf, unsigned int size);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_burst_read")]
            internal static extern ErrorCode Read(IntPtr parcelHandle, [In, Out] byte[] buf, int size);

            //int rpc_port_parcel_burst_write(rpc_port_parcel_h h, const unsigned char *buf, unsigned int size);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_burst_write")]
            internal static extern ErrorCode Write(IntPtr parcelHandle, byte[] buf, int size);
        }

        internal static partial class Proxy
        {
            //typedef void (*rpc_port_proxy_connected_event_cb)(const char *ep, const char* port_name, rpc_port_h port, void* data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void ConnectedEventCallback(string endPoint, string port_name, IntPtr port, IntPtr data);

            //typedef void (*rpc_port_proxy_disconnected_event_cb)(const char *ep, const char* port_name, void* data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void DisconnectedEventCallback(string endPoint, string port_name, IntPtr data);

            //typedef void (*rpc_port_proxy_rejected_event_cb) (const char* ep, const char* port_name, void* data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void RejectedEventCallback(string endPoint, string port_name, IntPtr data);

            //typedef void (*rpc_port_proxy_received_event_cb) (const char* ep, const char* port_name, void* data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void ReceivedEventCallback(string endPoint, string port_name, IntPtr data);

            //int rpc_port_proxy_create(rpc_port_proxy_h *h);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_proxy_create")]
            internal static extern ErrorCode Create(out IntPtr handle);

            //int rpc_port_proxy_destroy(rpc_port_proxy_h h);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_proxy_destroy")]
            internal static extern ErrorCode Destroy(IntPtr handle);

            //int rpc_port_proxy_connect(rpc_port_proxy_h h, const char *appid, const char* port);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_proxy_connect")]
            internal static extern ErrorCode Connect(IntPtr handle, string appId, string port);

            //int rpc_port_proxy_add_connected_event_cb(rpc_port_proxy_h h, rpc_port_proxy_connected_event_cb cb, void* data);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_proxy_add_connected_event_cb")]
            internal static extern ErrorCode AddConnectedEventCb(IntPtr handle, ConnectedEventCallback cb, IntPtr data);

            //int rpc_port_proxy_add_disconnected_event_cb(rpc_port_proxy_h h, rpc_port_proxy_disconnected_event_cb cb, void* data);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_proxy_add_disconnected_event_cb")]
            internal static extern ErrorCode AddDisconnectedEventCb(IntPtr handle, DisconnectedEventCallback cb, IntPtr data);

            //int rpc_port_proxy_add_rejected_event_cb(rpc_port_proxy_h h, rpc_port_proxy_rejected_event_cb cb, void* data);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_proxy_add_rejected_event_cb")]
            internal static extern ErrorCode AddRejectedEventCb(IntPtr handle, RejectedEventCallback cb, IntPtr data);

            //int rpc_port_proxy_add_received_event_cb(rpc_port_proxy_h h, rpc_port_proxy_received_event_cb cb, void* data);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_proxy_add_received_event_cb")]
            internal static extern ErrorCode AddReceivedEventCb(IntPtr handle, ReceivedEventCallback cb, IntPtr data);

            //int rpc_port_proxy_get_port(rpc_port_proxy_h h, rpc_port_port_type_e type, rpc_port_h* port);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_proxy_get_port")]
            internal static extern ErrorCode GetPort(IntPtr handle, PortType t, out IntPtr port);

            //int rpc_port_proxy_connect_sync(rpc_port_proxy_h h, const char* appid, const char* port);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_proxy_connect_sync")]
            internal static extern ErrorCode ConnectSync(IntPtr handle, string appId, string port);
        }

        internal static partial class Stub
        {
            //typedef void (*rpc_port_stub_connected_event_cb)(const char *sender, const char *instance, void* data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void ConnectedEventCallback(string sender, string instance, IntPtr data);

            //typedef void (* rpc_port_stub_disconnected_event_cb) (const char* sender, const char *instance, void* data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void DisconnectedEventCallback(string sender, string instance, IntPtr data);

            //typedef void (* rpc_port_stub_received_event_cb) (const char* sender, const char *instance, rpc_port_h port, void* data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate int ReceivedEventCallback(string sender, string instance, IntPtr port, IntPtr data);

            //int rpc_port_stub_create(rpc_port_stub_h* h, const char* port_name);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_stub_create")]
            internal static extern ErrorCode Create(out IntPtr handle, string portName);

            //int rpc_port_stub_destroy(rpc_port_stub_h h);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_stub_destroy")]
            internal static extern ErrorCode Destroy(IntPtr handle);

            //int rpc_port_stub_listen(rpc_port_stub_h h);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_stub_listen")]
            internal static extern ErrorCode Listen(IntPtr handle);

            //int rpc_port_stub_add_connected_event_cb(rpc_port_stub_h h, rpc_port_stub_connected_event_cb cb, void* data);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_stub_add_connected_event_cb")]
            internal static extern ErrorCode AddConnectedEventCb(IntPtr handle, ConnectedEventCallback cb, IntPtr data);

            //int rpc_port_stub_add_disconnected_event_cb(rpc_port_stub_h h, rpc_port_stub_disconnected_event_cb cb, void* data);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_stub_add_disconnected_event_cb")]
            internal static extern ErrorCode AddDisconnectedEventCb(IntPtr handle, DisconnectedEventCallback cb, IntPtr data);

            //int rpc_port_stub_add_received_event_cb(rpc_port_stub_h h, rpc_port_stub_received_event_cb cb, void* data);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_stub_add_received_event_cb")]
            internal static extern ErrorCode AddReceivedEventCb(IntPtr handle, ReceivedEventCallback cb, IntPtr data);

            //int rpc_port_stub_add_privilege(rpc_port_stub_h h, const char *privilege);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_stub_add_privilege")]
            internal static extern ErrorCode AddPrivilege(IntPtr handle, string privilege);

            //int rpc_port_stub_set_trusted(rpc_port_stub_h h, const bool trusted);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_stub_set_trusted")]
            internal static extern ErrorCode SetTrusted(IntPtr handle, bool trusted);

            //int rpc_port_stub_get_port(rpc_port_stub_h h, rpc_port_port_type_e type, const char* instance, rpc_port_h *port);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_stub_get_port")]
            internal static extern ErrorCode GetPort(IntPtr handle, PortType t, string instance, out IntPtr port);
        }

        internal static partial class Port
        {
            //int rpc_port_set_private_sharing_array(rpc_port_h port, const char* paths[], unsigned int size);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_set_private_sharing_array")]
            internal static extern ErrorCode SetPrivateSharingArray(IntPtr handle, string[] paths, uint size);

            //int rpc_port_set_private_sharing(rpc_port_h port, const char* path);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_set_private_sharing")]
            internal static extern ErrorCode SetPrivateSharing(IntPtr handle, string path);

            //int rpc_port_unset_private_sharing(rpc_port_h port);
            [DllImport(Libraries.RpcPort, EntryPoint = "rpc_port_unset_private_sharing")]
            internal static extern ErrorCode UnsetPrivateSharing(IntPtr handle);
        }
    }
}
