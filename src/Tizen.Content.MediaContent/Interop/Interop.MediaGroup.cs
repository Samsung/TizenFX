using System;
using System.Runtime.InteropServices;
using Tizen.Content.MediaContent;

internal static partial class Interop
{
    internal static partial class Group
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_get_album_count_from_db")]
        internal static extern MediaContentError MediaAlbumGetAlbumCountFromDb(IntPtr filter, out int album_count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_get_media_count_from_db")]
        internal static extern MediaContentError MediaAlbumGetMediaCountFromDb(int album_id, IntPtr filter, out int media_count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_destroy")]
        internal static extern MediaContentError MediaAlbumDestroy(IntPtr album);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_clone")]
        internal static extern MediaContentError MediaAlbumClone(out IntPtr dst, IntPtr src);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_get_album_id")]
        internal static extern MediaContentError MediaAlbumGetAlbumId(IntPtr album, out int album_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_get_name")]
        internal static extern MediaContentError MediaAlbumGetName(IntPtr album, out IntPtr album_name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_get_artist")]
        internal static extern MediaContentError MediaAlbumGetArtist(IntPtr album, out IntPtr artist);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_get_album_art")]
        internal static extern MediaContentError MediaAlbumGetAlbumArt(IntPtr album, out IntPtr album_art);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_get_album_from_db")]
        internal static extern MediaContentError MediaAlbumGetAlbumFromDb(int album_id, out IntPtr album);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_group_get_group_count_from_db")]
        internal static extern MediaContentError GetGroupCountFromDb(IntPtr filter, MediaGroupType group, out int group_count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_group_get_media_count_from_db")]
        internal static extern MediaContentError GetMediaCountFromDb(string group_name, MediaGroupType group, IntPtr filter, out int media_count);

        //Callbacks
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MediaInfoCallback(IntPtr mediaInformation, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MediaGroupCallback(string groupName, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MediaAlbumCallback(IntPtr albumHandle, IntPtr data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_foreach_album_from_db")]
        internal static extern MediaContentError MediaAlbumForeachAlbumFromDb(IntPtr filter, MediaAlbumCallback callback, IntPtr user_data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_album_foreach_media_from_db")]
        internal static extern MediaContentError MediaAlbumForeachMediaFromDb(int albumId, IntPtr filter, MediaInfoCallback callback, IntPtr user_data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_group_foreach_group_from_db")]
        internal static extern MediaContentError ForeachGroupFromDb(IntPtr filter, MediaGroupType group, MediaGroupCallback callback, IntPtr user_data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_group_foreach_media_from_db")]
        internal static extern MediaContentError ForeachMediaFromDb(string groupName, MediaGroupType group, IntPtr filter, MediaInfoCallback callback, IntPtr user_data);
    }
}
