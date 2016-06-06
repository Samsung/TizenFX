using System;
using System.Runtime.InteropServices;
using Tizen.Content.MediaContent;

internal static partial class Interop
{
    internal static partial class Playlist
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_playlist_count_from_db")]
        internal static extern int GetPlaylistCountFromDb(IntPtr filter, out int playlist_count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_media_count_from_db")]
        internal static extern int GetMediaCountFromDb(int playlist_id, IntPtr filter, out int media_count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_insert_to_db")]
        internal static extern int InsertToDb(string name, out IntPtr playlist);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_delete_from_db")]
        internal static extern int DeleteFromDb(int playlist_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_playlist_from_db")]
        internal static extern int GetPlaylistFromDb(int playlist_id, out IntPtr playlist);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_destroy")]
        internal static extern int Destroy(IntPtr playlist);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_clone")]
        internal static extern int Clone(out IntPtr dst, IntPtr src);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_playlist_id")]
        internal static extern int GetPlaylistId(IntPtr playlist, out int playlist_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_name")]
        internal static extern int GetName(IntPtr playlist, out string playlist_name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_set_name")]
        internal static extern int SetName(IntPtr playlist, string playlist_name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_thumbnail_path")]
        internal static extern int GetThumbnailPath(IntPtr playlist, out string filePath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_set_thumbnail_path")]
        internal static extern int SetThumbnailPath(IntPtr playlist, string filePath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_set_play_order")]
        internal static extern int SetPlayOrder(IntPtr playlist, int playlist_member_id, int play_order);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_add_media")]
        internal static extern int AddMedia(IntPtr playlist, string media_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_remove_media")]
        internal static extern int RemoveMedia(IntPtr playlist, int playlist_member_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_get_play_order")]
        internal static extern int GetPlayOrder(IntPtr playlist, int playlist_member_id, out int play_order);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_update_to_db")]
        internal static extern int UpdateToDb(IntPtr playlist);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_import_from_file")]
        internal static extern int ImportFromFile(string playlist_name, string filePath, out IntPtr playlist);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_export_to_file")]
        internal static extern int ExportToFile(IntPtr playlist, string filePath);

        //Callbacks
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MediaPlaylistCallback(IntPtr playListHandle, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PlaylistMemberCallback(int playListMemberId, IntPtr mediaInformation, IntPtr data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_foreach_playlist_from_db")]
        internal static extern int ForeachPlaylistFromDb(IntPtr filter, MediaPlaylistCallback callback, IntPtr user_data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_playlist_foreach_media_from_db")]
        internal static extern int ForeachMediaFromDb(int playlist_id, IntPtr filter, PlaylistMemberCallback callback, IntPtr user_data);
    }
}
