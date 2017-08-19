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

internal partial class Interop
{
    internal static partial class Bookmark
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_create")]
        internal static extern MediaContentError Create(string mediaId, int time, out IntPtr handle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_insert_to_db_v2")]
        internal static extern MediaContentError Insert(IntPtr handle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_delete_from_db")]
        internal static extern MediaContentError Delete(int id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_get_bookmark_count_from_db")]
        internal static extern MediaContentError GetCount(FilterHandle filter, out int count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_destroy")]
        internal static extern MediaContentError Destroy(IntPtr bookmark);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_get_bookmark_id")]
        internal static extern MediaContentError GetId(IntPtr bookmark, out int id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_get_marked_time")]
        internal static extern MediaContentError GetMarkedTime(IntPtr bookmark, out int time);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_get_thumbnail_path")]
        internal static extern MediaContentError GetThumbnailPath(IntPtr bookmark, out IntPtr filePath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_set_thumbnail_path")]
        internal static extern MediaContentError SetThumbnailPath(IntPtr bookmark, string filePath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_get_name")]
        internal static extern MediaContentError GetName(IntPtr bookmark, out IntPtr name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_set_name")]
        internal static extern MediaContentError SetName(IntPtr bookmark, string name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_foreach_bookmark_from_db")]
        internal static extern MediaContentError ForeachFromDb(FilterHandle filter,
            Common.ItemCallback callback, IntPtr userData = default(IntPtr));
    }
}
