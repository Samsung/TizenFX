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
    internal static partial class MediaBookmark
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_insert_to_db")]
        internal static extern MediaContentError InsertToDb(string media_id, uint time, string thumbnail_path);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_delete_from_db")]
        internal static extern MediaContentError DeleteFromDb(int bookmark_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_get_bookmark_count_from_db")]
        internal static extern MediaContentError GetBookmarkCountFromDb(IntPtr filter, out int bookmark_count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_clone")]
        internal static extern MediaContentError Clone(out IntPtr dst, IntPtr src);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_destroy")]
        internal static extern MediaContentError Destroy(IntPtr bookmark);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_get_bookmark_id")]
        internal static extern MediaContentError GetBookmarkId(IntPtr bookmark, out int bookmark_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_get_marked_time")]
        internal static extern MediaContentError GetMarkedTime(IntPtr bookmark, out uint marked_time);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_get_thumbnail_path")]
        internal static extern MediaContentError GetThumbnailPath(IntPtr bookmark, out IntPtr filePath);
    }
}
