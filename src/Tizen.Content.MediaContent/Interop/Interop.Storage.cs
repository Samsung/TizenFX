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
    [Obsolete("Please do not use! The public API related all these API will be deprecated in level 6")]
    internal static class Storage
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_storage_info_from_db")]
        internal static extern MediaContentError GetStorageInfoFromDb(string id, out IntPtr storage);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_storage_count_from_db")]
        internal static extern MediaContentError GetStorageCountFromDb(FilterHandle filter, out int count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_media_count_from_db")]
        internal static extern MediaContentError GetMediaCountFromDb(string id, FilterHandle filter, out int count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_destroy")]
        internal static extern MediaContentError Destroy(IntPtr storage);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_id")]
        internal static extern MediaContentError GetId(IntPtr storage, out IntPtr id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_path")]
        internal static extern MediaContentError GetPath(IntPtr storage, out IntPtr path);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_type")]
        internal static extern MediaContentError GetType(IntPtr storage, out StorageType type);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_foreach_storage_from_db")]
        internal static extern MediaContentError ForeachStorageFromDb(FilterHandle filter, Common.ItemCallback callback,
            IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_foreach_media_from_db")]
        internal static extern MediaContentError ForeachMediaFromDb(string id, FilterHandle filter,
            Common.ItemCallback callback, IntPtr userData = default(IntPtr));
    }
}
