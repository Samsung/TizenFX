using System;
using System.Runtime.InteropServices;
using Tizen.Content.MediaContent;

internal static partial class Interop
{
    internal static partial class Playlist
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_playlist_count_from_db")]
        internal static extern MediaContentError GetPlaylistCountFromDb(IntPtr filter, out int playlist_count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_media_count_from_db")]
        internal static extern MediaContentError GetMediaCountFromDb(int playlist_id, IntPtr filter, out int media_count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_insert_to_db")]
        internal static extern MediaContentError InsertToDb(string name, out IntPtr playlist);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_delete_from_db")]
        internal static extern MediaContentError DeleteFromDb(int playlist_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_playlist_from_db")]
        internal static extern MediaContentError GetPlaylistFromDb(int playlist_id, out IntPtr playlist);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_destroy")]
        internal static extern MediaContentError Destroy(IntPtr playlist);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_clone")]
        internal static extern MediaContentError Clone(out IntPtr dst, IntPtr src);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_playlist_id")]
        internal static extern MediaContentError GetPlaylistId(IntPtr playlist, out int playlist_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_name")]
        internal static extern MediaContentError GetName(IntPtr playlist, out string playlist_name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_set_name")]
        internal static extern MediaContentError SetName(IntPtr playlist, string playlist_name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_thumbnail_path")]
        internal static extern MediaContentError GetThumbnailPath(IntPtr playlist, out string filePath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_set_thumbnail_path")]
        internal static extern MediaContentError SetThumbnailPath(IntPtr playlist, string filePath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_set_play_order")]
        internal static extern MediaContentError SetPlayOrder(IntPtr playlist, int playlist_member_id, int play_order);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_add_media")]
        internal static extern MediaContentError AddMedia(IntPtr playlist, string media_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_remove_media")]
        internal static extern MediaContentError RemoveMedia(IntPtr playlist, int playlist_member_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_play_order")]
        internal static extern MediaContentError GetPlayOrder(IntPtr playlist, int playlist_member_id, out int play_order);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_update_to_db")]
        internal static extern MediaContentError UpdateToDb(IntPtr playlist);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_import_from_file")]
        internal static extern MediaContentError ImportFromFile(string playlist_name, string filePath, out IntPtr playlist);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_export_to_file")]
        internal static extern MediaContentError ExportToFile(IntPtr playlist, string filePath);

        //Callbacks
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MediaPlaylistCallback(IntPtr playListHandle, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PlaylistMemberCallback(int playListMemberId, IntPtr mediaInformation, IntPtr data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_foreach_playlist_from_db")]
        internal static extern MediaContentError ForeachPlaylistFromDb(IntPtr filter, MediaPlaylistCallback callback, IntPtr user_data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_foreach_media_from_db")]
        internal static extern MediaContentError ForeachMediaFromDb(int playlist_id, IntPtr filter, PlaylistMemberCallback callback, IntPtr user_data);
    }
}
