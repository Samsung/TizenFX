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
using Tizen.Applications;

using ErrorCode = Interop.Cion.ErrorCode;

internal static partial class Interop
{
    internal static partial class CionPayloadAsyncResult
    {
        [DllImport(Libraries.Cion, EntryPoint = "cion_payload_async_result_clone")]
        internal static extern ErrorCode CionPayloadAsyncResultClone(IntPtr result, out PayloadAsyncResultSafeHandle resultClone);

        [DllImport(Libraries.Cion, EntryPoint = "cion_payload_async_result_destroy")]
        internal static extern ErrorCode CionPayloadAsyncResultDestroy(IntPtr result);

        [DllImport(Libraries.Cion, EntryPoint = "cion_payload_async_result_get_result")]
        internal static extern ErrorCode CionPayloadAsyncResultGetResult(PayloadAsyncResultSafeHandle result, out int code);

        [DllImport(Libraries.Cion, EntryPoint = "cion_payload_async_result_get_peer_info")]
        internal static extern ErrorCode CionPayloadAsyncResultGetPeerInfo(PayloadAsyncResultSafeHandle result, out IntPtr peerInfo);

        [DllImport(Libraries.Cion, EntryPoint = "cion_payload_async_result_get_id")]
        internal static extern ErrorCode CionPayloadAsyncResultGetID(PayloadAsyncResultSafeHandle result, out int id);

        [DllImport(Libraries.Cion, EntryPoint = "cion_payload_async_result_get_payload_id")]
        internal static extern ErrorCode CionPayloadAsyncResultGetPayloadID(PayloadAsyncResultSafeHandle result, out string payloadID);
    }
}
