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
using System.Runtime.InteropServices.Marshalling;

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
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_create", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode Create(out IntPtr handle);

            //int rpc_port_parcel_create_from_port(rpc_port_parcel_h *h, rpc_port_h port);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_create_from_port", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode CreateFromPort(out IntPtr parcelHandle, IntPtr portHandle);

            //int rpc_port_parcel_send(rpc_port_parcel_h h, rpc_port_h port);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_send", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode Send(IntPtr parcelHandle, IntPtr portHandle);

            //int rpc_port_parcel_destroy(rpc_port_parcel_h h);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_destroy", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode Destroy(IntPtr handle);

            //int rpc_port_parcel_write_byte(rpc_port_parcel_h h, char b);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_byte", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode WriteByte(IntPtr parcelHandle, byte b);

            //int rpc_port_parcel_write_int16(rpc_port_parcel_h h, short i);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_int16", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode WriteInt16(IntPtr parcelHandle, short i);

            //int rpc_port_parcel_write_int32(rpc_port_parcel_h h, int i);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_int32", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode WriteInt32(IntPtr parcelHandle, int i);

            //int rpc_port_parcel_write_int64(rpc_port_parcel_h h, int i);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_int64", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode WriteInt64(IntPtr parcelHandle, long i);

            //int rpc_port_parcel_write_float(rpc_port_parcel_h h, float f);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_float", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode WriteFloat(IntPtr parcelHandle, float f);

            //int rpc_port_parcel_write_double(rpc_port_parcel_h h, double d);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_double", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode WriteDouble(IntPtr parcelHandle, double d);

            //int rpc_port_parcel_write_string(rpc_port_parcel_h h, const char* str);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_string", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode WriteString(IntPtr parcelHandle, string str);

            //int rpc_port_parcel_write_bool(rpc_port_parcel_h h, [MarshalAs(UnmanagedType.U1)] bool b);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_bool", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode WriteBool(IntPtr parcelHandle, [MarshalAs(UnmanagedType.U1)] bool b);

            //int rpc_port_parcel_write_bundle(rpc_port_parcel_h h, bundle* b);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_bundle", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode WriteBundle(IntPtr parcelHandle, IntPtr b);

            //int rpc_port_parcel_write_array_count(rpc_port_parcel_h h, int count);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_write_array_count", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode WriteArrayCount(IntPtr parcelHandle, int count);

            //int rpc_port_parcel_read_byte(rpc_port_parcel_h h, char* b);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_byte", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode ReadByte(IntPtr parcelHandle, out byte b);

            //int rpc_port_parcel_read_int16(rpc_port_parcel_h h, short *i);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_int16", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode ReadInt16(IntPtr parcelHandle, out short i);

            //int rpc_port_parcel_read_int32(rpc_port_parcel_h h, int* i);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_int32", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode ReadInt32(IntPtr parcelHandle, out int i);

            //int rpc_port_parcel_read_int64(rpc_port_parcel_h h, long long* i);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_int64", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode ReadInt64(IntPtr parcelHandle, out long i);

            //int rpc_port_parcel_read_float(rpc_port_parcel_h h, float *f);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_float", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode ReadFloat(IntPtr parcelHandle, out float f);

            //int rpc_port_parcel_read_double(rpc_port_parcel_h h, double *d);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_double", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode ReadDouble(IntPtr parcelHandle, out double f);

            //int rpc_port_parcel_read_string(rpc_port_parcel_h h, char** str);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_string", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode ReadString(IntPtr parcelHandle, out string str);

            //int rpc_port_parcel_read_bool(rpc_port_parcel_h h, [MarshalAs(UnmanagedType.U1)] bool *b);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_bool", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode ReadBool(IntPtr parcelHandle, [MarshalAs(UnmanagedType.U1)] out bool b);

            //int rpc_port_parcel_read_bundle(rpc_port_parcel_h h, bundle** b);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_bundle", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode ReadBundle(IntPtr parcelHandle, out IntPtr b);

            //int rpc_port_parcel_read_array_count(rpc_port_parcel_h h, int *count);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_read_array_count", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode ReadArrayCount(IntPtr parcelHandle, out int count);

            //int rpc_port_parcel_burst_read(rpc_port_parcel_h h, unsigned char *buf, unsigned int size);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_burst_read", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode Read(IntPtr parcelHandle, [In, Out] byte[] buf, int size);

            //int rpc_port_parcel_burst_write(rpc_port_parcel_h h, const unsigned char *buf, unsigned int size);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_burst_write", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode Write(IntPtr parcelHandle, byte[] buf, int size);

            //int rpc_port_parcel_get_header(rpc_port_parcel_h h, rpc_port_parcel_header_h *header);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_get_header", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode GetHeader(IntPtr parcelHandle, out IntPtr ParcelHeaderHandle);

            //int rpc_port_parcel_header_set_tag(rpc_port_parcel_header_h header, const char *tag);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_header_set_tag", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode SetTag(IntPtr parcelHeaderHandle, string tag);

            //int rpc_port_parcel_header_get_tag(rpc_port_parcel_header_h header, char **tag);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_header_get_tag", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode GetTag(IntPtr parcelHeaderHandle, out string tag);

            //int rpc_port_parcel_header_set_tag_ex(rpc_port_parcel_header_h header,
            //    unsigned char tidlc_version_major, unsigned char tidlc_version_minor,
            //    unsigned char tidlc_version_patch, unsigned char tidl_protocol_ver, unsigned char flags);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_header_set_tag_ex", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode SetTagEx(IntPtr parcelHeaderHandle, byte major, byte minor, byte patch, byte protocol, byte flags);

            //int rpc_port_parcel_header_set_seq_num(rpc_port_parcel_header_h header, int seq_num);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_header_set_seq_num", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode SetSeqNum(IntPtr parcelHeaderHandle, int seq_num);

            //int rpc_port_parcel_header_get_seq_num(rpc_port_parcel_header_h header, int *seq_num);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_header_get_seq_num", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode GetSeqNum(IntPtr parcelHeaderHandle, out int seq_num);

            //int rpc_port_parcel_header_get_timestamp(rpc_port_parcel_header_h header, struct timespec *timestamp);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_header_get_timestamp", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode GetTimeStamp(IntPtr parcelHeaderHandle, ref Libc.TimeStamp time);

            //int rpc_port_parcel_get_raw(rpc_port_parcel_h h, void **raw, unsigned int *size);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_get_raw", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode GetRaw(IntPtr parcelHandle, out IntPtr raw, out uint size);

            //int rpc_port_parcel_create_from_raw(rpc_port_parcel_h *h, const void *raw, unsigned int size);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_create_from_raw", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode CreateFromRaw(out IntPtr parcelHandle, byte[] raw, uint size);

            //int rpc_port_parcel_create_without_header(rpc_port_parcel_h *h);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_create_without_header", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode CreateWithoutHeader(out IntPtr parcelHandle);

            //int rpc_port_parcel_reserve(rpc_port_parcel_h h, unsigned int size);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_reserve", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode Reserve(IntPtr parcelHandle, uint size);

            //int rpc_port_parcel_set_data_size(rpc_port_parcel_h h, unsigned int size);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_set_data_size", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode SetDataSize(IntPtr parcelHandle, uint size);

            //int rpc_port_parcel_get_data_size(rpc_port_parcel_h h, unsigned int* size);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_get_data_size", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode GetDataSize(IntPtr parcelHandle, out uint size);

            //int rpc_port_parcel_pin(rpc_port_parcel_h h);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_pin", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode Pin(IntPtr parcelHandle);

            //int rpc_port_parcel_get_reader(rpc_port_parcel_h h, unsigned int* reader_pos);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_get_reader", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode GetReader(IntPtr parcelHandle, out uint readerPos);

            //int rpc_port_parcel_set_reader(rpc_port_parcel_h h, unsigned int reader_pos);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_set_reader", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode SetReader(IntPtr parcelHandle, uint readerPos);

            //int rpc_port_parcel_create_from_parcel(rpc_port_parcel_h* h, rpc_port_parcel_h origin_parcel, unsigned int start_pos, unsigned int size);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_parcel_create_from_parcel", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode CreateFromParcel(out IntPtr parcelHandle, IntPtr originParcel, uint startPos, uint size);
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
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_proxy_create", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode Create(out IntPtr handle);

            //int rpc_port_proxy_destroy(rpc_port_proxy_h h);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_proxy_destroy", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode Destroy(IntPtr handle);

            //int rpc_port_proxy_connect(rpc_port_proxy_h h, const char *appid, const char* port);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_proxy_connect", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode Connect(IntPtr handle, string appId, string port);

            //int rpc_port_proxy_add_connected_event_cb(rpc_port_proxy_h h, rpc_port_proxy_connected_event_cb cb, void* data);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_proxy_add_connected_event_cb", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode AddConnectedEventCb(IntPtr handle, ConnectedEventCallback cb, IntPtr data);

            //int rpc_port_proxy_add_disconnected_event_cb(rpc_port_proxy_h h, rpc_port_proxy_disconnected_event_cb cb, void* data);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_proxy_add_disconnected_event_cb", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode AddDisconnectedEventCb(IntPtr handle, DisconnectedEventCallback cb, IntPtr data);

            //int rpc_port_proxy_add_rejected_event_cb(rpc_port_proxy_h h, rpc_port_proxy_rejected_event_cb cb, void* data);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_proxy_add_rejected_event_cb", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode AddRejectedEventCb(IntPtr handle, RejectedEventCallback cb, IntPtr data);

            //int rpc_port_proxy_add_received_event_cb(rpc_port_proxy_h h, rpc_port_proxy_received_event_cb cb, void* data);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_proxy_add_received_event_cb", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode AddReceivedEventCb(IntPtr handle, ReceivedEventCallback cb, IntPtr data);

            //int rpc_port_proxy_get_port(rpc_port_proxy_h h, rpc_port_port_type_e type, rpc_port_h* port);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_proxy_get_port", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode GetPort(IntPtr handle, PortType t, out IntPtr port);

            //int rpc_port_proxy_connect_sync(rpc_port_proxy_h h, const char* appid, const char* port);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_proxy_connect_sync", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode ConnectSync(IntPtr handle, string appId, string port);
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
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_stub_create", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode Create(out IntPtr handle, string portName);

            //int rpc_port_stub_destroy(rpc_port_stub_h h);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_stub_destroy", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode Destroy(IntPtr handle);

            //int rpc_port_stub_listen(rpc_port_stub_h h);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_stub_listen", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode Listen(IntPtr handle);

            //int rpc_port_stub_add_connected_event_cb(rpc_port_stub_h h, rpc_port_stub_connected_event_cb cb, void* data);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_stub_add_connected_event_cb", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode AddConnectedEventCb(IntPtr handle, ConnectedEventCallback cb, IntPtr data);

            //int rpc_port_stub_add_disconnected_event_cb(rpc_port_stub_h h, rpc_port_stub_disconnected_event_cb cb, void* data);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_stub_add_disconnected_event_cb", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode AddDisconnectedEventCb(IntPtr handle, DisconnectedEventCallback cb, IntPtr data);

            //int rpc_port_stub_add_received_event_cb(rpc_port_stub_h h, rpc_port_stub_received_event_cb cb, void* data);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_stub_add_received_event_cb", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode AddReceivedEventCb(IntPtr handle, ReceivedEventCallback cb, IntPtr data);

            //int rpc_port_stub_add_privilege(rpc_port_stub_h h, const char *privilege);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_stub_add_privilege", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode AddPrivilege(IntPtr handle, string privilege);

            //int rpc_port_stub_set_trusted(rpc_port_stub_h h, const [MarshalAs(UnmanagedType.U1)] bool trusted);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_stub_set_trusted", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode SetTrusted(IntPtr handle, [MarshalAs(UnmanagedType.U1)] bool trusted);

            //int rpc_port_stub_get_port(rpc_port_stub_h h, rpc_port_port_type_e type, const char* instance, rpc_port_h *port);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_stub_get_port", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode GetPort(IntPtr handle, PortType t, string instance, out IntPtr port);
        }

        internal static partial class Port
        {
            //int rpc_port_set_private_sharing_array(rpc_port_h port, const char* paths[], unsigned int size);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_set_private_sharing_array", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode SetPrivateSharingArray(IntPtr handle, string[] paths, uint size);

            //int rpc_port_set_private_sharing(rpc_port_h port, const char* path);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_set_private_sharing", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode SetPrivateSharing(IntPtr handle, string path);

            //int rpc_port_unset_private_sharing(rpc_port_h port);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_unset_private_sharing", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode UnsetPrivateSharing(IntPtr handle);

            //int rpc_port_disconnect(rpc_port_h h);
            [LibraryImport(Libraries.RpcPort, EntryPoint = "rpc_port_disconnect", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ErrorCode Disconnect(IntPtr handle);
        }
    }
}




