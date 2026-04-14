/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Applications.Cion;

using ErrorCode = Interop.Cion.ErrorCode;

internal static partial class Interop
{
    internal static partial class CionClient
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CionClientServerDiscoveredCb(string serviceName, IntPtr peerInfo, IntPtr userData);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CionClientConnectionResultCb(string serviceName, IntPtr peerInfo, IntPtr result, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CionClientPayloadReceivedCb(string serviceName, IntPtr peerInfo, IntPtr payload, int status, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CionClientDisconnectedCb(string serviceName, IntPtr peerInfo, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CionClientPayloadAsyncResultCb(IntPtr result, IntPtr userData);        

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_client_create", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionClientCreate(out ClientSafeHandle client, string serviceName, IntPtr security);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_client_destroy")]
        internal static partial ErrorCode CionClientDestroy(IntPtr client);
        
        [LibraryImport(Libraries.Cion, EntryPoint = "cion_client_try_discovery")]
        internal static partial ErrorCode CionClientTryDiscovery(ClientSafeHandle client, CionClientServerDiscoveredCb cb, IntPtr userData);
        
        [LibraryImport(Libraries.Cion, EntryPoint = "cion_client_stop_discovery")]
        internal static partial ErrorCode CionClientStopDiscovery(ClientSafeHandle client);
        
        [LibraryImport(Libraries.Cion, EntryPoint = "cion_client_connect")]
        internal static partial ErrorCode CionClientConnect(ClientSafeHandle client, PeerInfoSafeHandle peerInfo);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_client_disconnect")]
        internal static partial ErrorCode CionClientDisconnect(ClientSafeHandle client);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_client_send_data")]
        internal static partial ErrorCode CionClientSendData(ClientSafeHandle client, byte[] data, int dataSize, int timeout, out IntPtr returnData, out int returnDataSize);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_client_send_payload_async")]
        internal static partial ErrorCode CionClientSendPayloadAsync(ClientSafeHandle client, PayloadSafeHandle payload, CionClientPayloadAsyncResultCb cb, IntPtr userData);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_client_add_connection_result_cb")]
        internal static partial ErrorCode CionClientAddConnectionResultCb(ClientSafeHandle client, CionClientConnectionResultCb cb, IntPtr userData);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_client_remove_connection_result_cb")]
        internal static partial ErrorCode CionClientRemoveConnectionResultCb(ClientSafeHandle client, CionClientConnectionResultCb cb);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_client_add_payload_received_cb")]
        internal static partial ErrorCode CionClientAddPayloadReceivedCb(ClientSafeHandle client, CionClientPayloadReceivedCb cb, IntPtr userData);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_client_remove_payload_received_cb")]
        internal static partial ErrorCode CionClientRemovePayloadReceivedCb(ClientSafeHandle client, CionClientPayloadReceivedCb cb);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_client_add_disconnected_cb")]
        internal static partial ErrorCode CionClientAddDisconnectedCb(ClientSafeHandle client, CionClientDisconnectedCb cb, IntPtr userData);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_client_remove_disconnected_cb")]
        internal static partial ErrorCode CionClientRemoveDisconnectedCb(ClientSafeHandle client, CionClientDisconnectedCb cb);
    }
}



