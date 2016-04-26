using System;
using System.Runtime.InteropServices;
using Tizen.Content.MediaContent;

internal static partial class Interop
{
    internal static partial class Tag
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_insert_to_db")]
        internal static extern int InsertToDb(string tag_name, out IntPtr tag);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_delete_from_db")]
        internal static extern int DeleteFromDb(int tag_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_get_tag_count_from_db")]
        internal static extern int GetTagCountFromDb(IntPtr filter, out int tag_count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_get_media_count_from_db")]
        internal static extern int GetMediaCountFromDb(int tag_id, IntPtr filter, out int media_count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_clone")]
        internal static extern int Clone(out IntPtr dst, IntPtr src);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_destroy")]
        internal static extern int Destroy(IntPtr tag);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_get_tag_id")]
        internal static extern int GetTagId(IntPtr tag, out int tag_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_get_name")]
        internal static extern int GetName(IntPtr tag, out string tag_name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_get_tag_from_db")]
        internal static extern int GetTagFromDb(int tag_id, out IntPtr tag);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_add_media")]
        internal static extern int AddMedia(IntPtr tag, string media_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_remove_media")]
        internal static extern int RemoveMedia(IntPtr tag, string media_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_set_name")]
        internal static extern int SetName(IntPtr tag, string tag_name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_update_to_db")]
        internal static extern int UpdateToDb(IntPtr tag);

        //Callbacks
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MediaInfoCallback(IntPtr mediaInformation, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MediaTagCallback(IntPtr tag, IntPtr data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_foreach_tag_from_db")]
        internal static extern int ForeachTagFromDb(IntPtr filter, MediaTagCallback callback, IntPtr user_data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_foreach_media_from_db")]
        internal static extern int ForeachMediaFromDb(int tag_id, IntPtr filter, MediaInfoCallback callback, IntPtr user_data);
    }
}