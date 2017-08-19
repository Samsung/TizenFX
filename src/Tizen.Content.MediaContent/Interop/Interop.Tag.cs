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
    internal static partial class Tag
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_create")]
        internal static extern MediaContentError Create(out IntPtr handle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_insert_to_db")]
        internal static extern MediaContentError Insert(string name, out IntPtr handle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_delete_from_db")]
        internal static extern MediaContentError Delete(int tagId);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_update_to_db_v2")]
        internal static extern MediaContentError Update(int tagId, IntPtr tag);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_get_tag_from_db")]
        internal static extern MediaContentError GetTagFromDb(int tagId, out IntPtr tag);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_get_tag_count_from_db")]
        internal static extern MediaContentError GetTagCount(FilterHandle filter, out int count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_get_media_count_from_db")]
        internal static extern MediaContentError GetMediaCount(int tagId, FilterHandle filter, out int count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_destroy")]
        internal static extern MediaContentError Destroy(IntPtr tag);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_get_tag_id")]
        internal static extern MediaContentError GetId(IntPtr tag, out int value);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_get_name")]
        internal static extern MediaContentError GetName(IntPtr tag, out IntPtr value);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_set_name")]
        internal static extern MediaContentError SetName(IntPtr tag, string value);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_add_media")]
        internal static extern MediaContentError AddMedia(IntPtr tag, string mediaId);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_remove_media")]
        internal static extern MediaContentError RemoveMedia(IntPtr tag, string mediaId);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_foreach_tag_from_db")]
        internal static extern MediaContentError ForeachTagFromDb(FilterHandle filter,
            Common.ItemCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_foreach_media_from_db")]
        internal static extern MediaContentError ForeachMediaFromDb(int tagId, FilterHandle filter,
            Common.ItemCallback callback, IntPtr userData = default(IntPtr));
    }
}
