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
    internal static partial class Album
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_get_album_count_from_db")]
        internal static extern MediaContentError GetAlbumCountFromDb(FilterHandle filter, out int count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_get_media_count_from_db")]
        internal static extern MediaContentError GetMediaCountFromDb(int albumId, FilterHandle filter, out int count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_destroy")]
        internal static extern MediaContentError Destroy(IntPtr album);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_get_album_id")]
        internal static extern MediaContentError GetId(IntPtr album, out int albumId);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_get_name")]
        internal static extern MediaContentError GetName(IntPtr album, out IntPtr value);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_get_artist")]
        internal static extern MediaContentError GetArtist(IntPtr album, out IntPtr value);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_get_album_art")]
        internal static extern MediaContentError GetAlbumArt(IntPtr album, out IntPtr value);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_get_album_from_db")]
        internal static extern MediaContentError GetAlbumFromDb(int albumId, out IntPtr album);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_foreach_album_from_db")]
        internal static extern MediaContentError ForeachAlbumFromDb(FilterHandle filter,
            Common.ItemCallback cb, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_foreach_media_from_db")]
        internal static extern MediaContentError ForeachMediaFromDb(int albumId, FilterHandle filter,
            Common.ItemCallback callback, IntPtr userData = default(IntPtr));
    }
}
