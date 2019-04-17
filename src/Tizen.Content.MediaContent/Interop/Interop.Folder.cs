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
    internal static partial class Folder
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_get_folder_count_from_db")]
        internal static extern MediaContentError GetFolderCountFromDb(FilterHandle filter, out int count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_get_media_count_from_db")]
        internal static extern MediaContentError GetMediaCountFromDb(string folder_id, FilterHandle filter, out int count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_destroy")]
        internal static extern MediaContentError Destroy(IntPtr folder);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_get_folder_id")]
        internal static extern MediaContentError GetFolderId(IntPtr folder, out IntPtr folder_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_get_path")]
        internal static extern MediaContentError GetPath(IntPtr folder, out IntPtr folderPath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_get_name")]
        internal static extern MediaContentError GetName(IntPtr folder, out IntPtr folder_name);

        // Please do not use! The public API related this will be deprecated in level 6
        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_get_storage_type")]
        internal static extern MediaContentError GetStorageType(IntPtr folder, out StorageType storage_type);

        // Please do not use! The public API related this will be deprecated in level 6
        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_get_storage_id")]
        internal static extern MediaContentError GetStorageId(IntPtr folder, out IntPtr storage_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_get_folder_from_db")]
        internal static extern MediaContentError GetFolderFromDb(string id, out IntPtr folder);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_foreach_folder_from_db")]
        internal static extern MediaContentError ForeachFolderFromDb(FilterHandle filter,
            Common.ItemCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_foreach_media_from_db")]
        internal static extern MediaContentError ForeachMediaFromDb(string id, FilterHandle filter,
            Common.ItemCallback callback, IntPtr user_data);
    }
}
