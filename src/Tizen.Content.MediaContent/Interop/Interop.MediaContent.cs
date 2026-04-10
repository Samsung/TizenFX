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
using Tizen.Content.MediaContent;

internal static partial class Interop
{
    internal static partial class Content
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_content_connect")]
        internal static extern MediaContentError Connect();

        [DllImport(Libraries.MediaContent, EntryPoint = "media_content_disconnect")]
        internal static extern MediaContentError Disconnect();

        [DllImport(Libraries.MediaContent, EntryPoint = "media_content_scan_file")]
        internal static extern MediaContentError ScanFile(string filePath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_content_cancel_scan_folder")]
        internal static extern MediaContentError CancelScanFolder(string folderPath);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MediaScanCompletedCallback(MediaContentError error, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MediaContentDBUpdatedCallback(MediaContentError error, int pid, ItemType updateItem,
            OperationType updateType, MediaType mediaType, string uuid, string filePath, string mimeType, IntPtr data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_content_scan_folder")]
        internal static extern MediaContentError ScanFolder(string folderPath,
            bool recursive, MediaScanCompletedCallback scanCompletedCallback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaContent, EntryPoint = "media_content_add_db_updated_cb")]
        internal static extern MediaContentError AddDbUpdatedCb(MediaContentDBUpdatedCallback mediaContentDBUpdatedCallback,
            IntPtr userData, out IntPtr notiHandle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_content_remove_db_updated_cb")]
        internal static extern MediaContentError RemoveDbUpdatedCb(IntPtr notiHandle);
    }
}
