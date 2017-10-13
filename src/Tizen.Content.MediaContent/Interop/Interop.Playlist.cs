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
    internal static partial class Playlist
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_create")]
        internal static extern MediaContentError Create(out IntPtr handle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_playlist_count_from_db")]
        internal static extern MediaContentError GetPlaylistCount(FilterHandle filter, out int count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_media_count_from_db")]
        internal static extern MediaContentError GetMediaCountFromDb(int playlistId,
            FilterHandle filter, out int count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_insert_to_db_v2")]
        internal static extern MediaContentError Insert(IntPtr playlist);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_delete_from_db")]
        internal static extern MediaContentError Delete(int id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_update_to_db_v2")]
        internal static extern MediaContentError Update(int id, IntPtr playlist);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_playlist_from_db")]
        internal static extern MediaContentError GetPlaylistFromDb(int id, out IntPtr playlist);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_destroy")]
        internal static extern MediaContentError Destroy(IntPtr playlist);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_playlist_id")]
        internal static extern MediaContentError GetId(IntPtr playlist, out int id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_name")]
        internal static extern MediaContentError GetName(IntPtr playlist, out IntPtr name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_set_name")]
        internal static extern MediaContentError SetName(IntPtr playlist, string name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_thumbnail_path")]
        internal static extern MediaContentError GetThumbnailPath(IntPtr playlist, out IntPtr filePath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_set_thumbnail_path")]
        internal static extern MediaContentError SetThumbnailPath(IntPtr playlist, string filePath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_set_play_order")]
        internal static extern MediaContentError SetPlayOrder(IntPtr playlist, int memberId, int order);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_add_media")]
        internal static extern MediaContentError AddMedia(IntPtr playlist, string mediaId);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_remove_media")]
        internal static extern MediaContentError RemoveMedia(IntPtr playlist, int memberId);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_play_order_v2")]
        internal static extern MediaContentError GetPlayOrder(int playlistId, int memberId, out int order);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_import_from_file")]
        internal static extern MediaContentError ImportFromFile(string path, string name, out IntPtr playlist);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_export_to_file")]
        internal static extern MediaContentError ExportToFile(IntPtr playlist, string filePath);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PlaylistMemberCallback(int memberId, IntPtr mediaInfo, IntPtr data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_foreach_playlist_from_db")]
        internal static extern MediaContentError ForeachPlaylistFromDb(FilterHandle filter,
            Common.ItemCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_foreach_media_from_db")]
        internal static extern MediaContentError ForeachMediaFromDb(int playlistId, FilterHandle filter,
            PlaylistMemberCallback callback, IntPtr userData = default(IntPtr));
    }
}
