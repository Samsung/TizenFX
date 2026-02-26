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
    internal static partial class MetadataEditor
    {
        [LibraryImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_create", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial MetadataEditorError Create(out IntPtr handle);

        [LibraryImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_set_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial MetadataEditorError SetPath(IntPtr handle, string path);

        [LibraryImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_destroy", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial MetadataEditorError Destroy(IntPtr handle);

        [LibraryImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_get_metadata", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial MetadataEditorError GetMetadata(IntPtr handle, MetadataEditorAttr attribute, out IntPtr value);

        [LibraryImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_set_metadata", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial MetadataEditorError SetMetadata(IntPtr handle, MetadataEditorAttr attribute, string value);

        [LibraryImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_update_metadata", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial MetadataEditorError UpdateMetadata(IntPtr handle);

        [LibraryImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_get_picture", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial MetadataEditorError GetPicture(IntPtr handle, int index, out IntPtr picture, out int size, out IntPtr mimeType);

        [LibraryImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_append_picture", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial MetadataEditorError AddPicture(IntPtr handle, string path);

        [LibraryImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_remove_picture", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial MetadataEditorError RemovePicture(IntPtr handle, int index);
    }
}
