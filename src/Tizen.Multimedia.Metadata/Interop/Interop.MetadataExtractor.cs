/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class MetadataExtractor
    {
        [LibraryImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_create")]
        internal static partial MetadataExtractorError Create(out IntPtr handle);

        [LibraryImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_set_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial MetadataExtractorError SetPath(IntPtr handle, string path);

        [LibraryImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_set_buffer")]
        internal static partial MetadataExtractorError SetBuffer(IntPtr handle, IntPtr buffer, int size);

        [LibraryImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_destroy")]
        internal static partial MetadataExtractorError Destroy(IntPtr handle);

        [LibraryImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_get_metadata")]
        internal static partial MetadataExtractorError GetMetadata(IntPtr handle, MetadataExtractorAttr attribute, out IntPtr value);

        [LibraryImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_get_artwork", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial MetadataExtractorError GetArtwork(IntPtr handle, out IntPtr artwork,
            out int size, out IntPtr mimeType);

        [LibraryImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_get_frame")]
        internal static partial MetadataExtractorError GetFrame(IntPtr handle, out IntPtr frame, out int size);

        [LibraryImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_get_synclyrics", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial MetadataExtractorError GetSynclyrics(IntPtr handle, int index,
            out uint timeStamp, out IntPtr lyrics);

        [LibraryImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_get_frame_at_time", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial MetadataExtractorError GetFrameAtTime(IntPtr handle, uint timeStamp,
            [MarshalAs(UnmanagedType.U1)] bool isAccurate, out IntPtr frame, out int size);
    }
}
