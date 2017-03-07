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
        internal static extern MediaContentError GetThumbnailPath(IntPtr bookmark, out string filePath);
    }
}
