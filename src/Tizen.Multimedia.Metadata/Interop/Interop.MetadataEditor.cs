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
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class MetadataEditor
    {
        [DllImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_create")]
        internal static extern MetadataEditorError Create(out IntPtr handle);

        [DllImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_set_path")]
        internal static extern MetadataEditorError SetPath(IntPtr handle, string path);

        [DllImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_destroy")]
        internal static extern MetadataEditorError Destroy(IntPtr handle);

        [DllImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_get_metadata")]
        internal static extern MetadataEditorError GetMetadata(IntPtr handle, MetadataEditorAttr attribute, out IntPtr value);

        [DllImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_set_metadata")]
        internal static extern MetadataEditorError SetMetadata(IntPtr handle, MetadataEditorAttr attribute, string value);

        [DllImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_update_metadata")]
        internal static extern MetadataEditorError UpdateMetadata(IntPtr handle);

        [DllImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_get_picture")]
        internal static extern MetadataEditorError GetPicture(IntPtr handle, int index, out IntPtr picture, out int size, out IntPtr mimeType);

        [DllImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_append_picture")]
        internal static extern MetadataEditorError AddPicture(IntPtr handle, string path);

        [DllImport(Libraries.MetadataEditor, EntryPoint = "metadata_editor_remove_picture")]
        internal static extern MetadataEditorError RemovePicture(IntPtr handle, int index);
    }
}
