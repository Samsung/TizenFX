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
using Tizen.Applications.Cion;

using ErrorCode = Interop.Cion.ErrorCode;

internal static partial class Interop
{
    internal static partial class CionPayload
    {
        internal enum PayloadType : int
        {
            Data,
            File,
        }

        [DllImport(Libraries.Cion, EntryPoint = "cion_payload_create")]
        internal static extern ErrorCode CionPayloadCreate(out PayloadSafeHandle payload, PayloadType type);

        [DllImport(Libraries.Cion, EntryPoint = "cion_payload_destroy")]
        internal static extern ErrorCode CionPayloadDestroy(IntPtr payload);

        [DllImport(Libraries.Cion, EntryPoint = "cion_payload_get_type")]
        internal static extern ErrorCode CionPayloadGetType(IntPtr payload, out PayloadType type);

        [DllImport(Libraries.Cion, EntryPoint = "cion_payload_get_data")]
        internal static extern ErrorCode CionPayloadGetData(PayloadSafeHandle payload, out IntPtr data, out int dataSize);

        [DllImport(Libraries.Cion, EntryPoint = "cion_payload_set_data")]
        internal static extern ErrorCode CionPayloadSetData(PayloadSafeHandle payload, byte[] data, int dataSize);

        [DllImport(Libraries.Cion, EntryPoint = "cion_payload_save_as_file")]
        internal static extern ErrorCode CionPayloadSaveAsFile(PayloadSafeHandle payload, string path);

        [DllImport(Libraries.Cion, EntryPoint = "cion_payload_get_received_file_name")]
        internal static extern ErrorCode CionPayloadGetReceivedFileName(PayloadSafeHandle payload, out string path);

        [DllImport(Libraries.Cion, EntryPoint = "cion_payload_get_received_bytes")]
        internal static extern ErrorCode CionPayloadGetReceivedBytes(PayloadSafeHandle payload, out UInt64 bytes);

        [DllImport(Libraries.Cion, EntryPoint = "cion_payload_get_total_bytes")]
        internal static extern ErrorCode CionPayloadGetTotalBytes(PayloadSafeHandle payload, out UInt64 bytes);

        [DllImport(Libraries.Cion, EntryPoint = "cion_payload_set_file_path")]
        internal static extern ErrorCode CionPayloadSetFilePath(PayloadSafeHandle payload, string path);

        [DllImport(Libraries.Cion, EntryPoint = "cion_payload_get_payload_id")]
        internal static extern ErrorCode CionPayloadGetPayloadID(PayloadSafeHandle payload, out string id);
    }
}
