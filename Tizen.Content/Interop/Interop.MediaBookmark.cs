using System;
using System.Runtime.InteropServices;

internal partial class Interop
{
    internal static partial class MediaBookmark
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_insert_to_db")]
        internal static extern int InsertToDb(string media_id, uint time, string thumbnail_path);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_delete_from_db")]
        internal static extern int DeleteFromDb(int bookmark_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_get_bookmark_count_from_db")]
        internal static extern int GetBookmarkCountFromDb(IntPtr filter, out int bookmark_count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_clone")]
        internal static extern int Clone(out IntPtr dst, IntPtr src);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_destroy")]
        internal static extern int Destroy(IntPtr bookmark);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_get_bookmark_id")]
        internal static extern int GetBookmarkId(IntPtr bookmark, out int bookmark_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_get_marked_time")]
        internal static extern int GetMarkedTime(IntPtr bookmark, out uint marked_time);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_bookmark_get_thumbnail_path")]
        internal static extern int GetThumbnailPath(IntPtr bookmark, out string path);
    }
}
