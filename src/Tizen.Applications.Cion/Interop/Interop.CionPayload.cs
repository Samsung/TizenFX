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
    internal static partial class CionPayload
    {
        internal enum PayloadType : int
        {
            Data,
            File,
        }

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_payload_create", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionPayloadCreate(out PayloadSafeHandle payload, PayloadType type);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_payload_destroy", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionPayloadDestroy(IntPtr payload);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_payload_get_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionPayloadGetType(IntPtr payload, out PayloadType type);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_payload_get_data", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionPayloadGetData(PayloadSafeHandle payload, out IntPtr data, out int dataSize);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_payload_set_data", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionPayloadSetData(PayloadSafeHandle payload, byte[] data, int dataSize);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_payload_save_as_file", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionPayloadSaveAsFile(PayloadSafeHandle payload, string path);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_payload_get_received_file_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionPayloadGetReceivedFileName(PayloadSafeHandle payload, out string path);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_payload_get_received_bytes", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionPayloadGetReceivedBytes(PayloadSafeHandle payload, out UInt64 bytes);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_payload_get_total_bytes", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionPayloadGetTotalBytes(PayloadSafeHandle payload, out UInt64 bytes);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_payload_set_file_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionPayloadSetFilePath(PayloadSafeHandle payload, string path);

        [LibraryImport(Libraries.Cion, EntryPoint = "cion_payload_get_payload_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode CionPayloadGetPayloadID(PayloadSafeHandle payload, out string id);
    }
}



