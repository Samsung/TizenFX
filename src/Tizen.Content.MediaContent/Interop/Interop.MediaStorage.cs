using System;
using System.Runtime.InteropServices;
using Tizen.Content.MediaContent;

internal static partial class Interop
{
    internal static partial class Storage
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_storage_info_from_db")]
        internal static extern MediaContentError GetStorageInfoFromDb(string storage_id, out IntPtr storage);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_storage_count_from_db")]
        internal static extern MediaContentError GetStorageCountFromDb(IntPtr filter, out int storage_count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_media_count_from_db")]
        internal static extern MediaContentError GetMediaCountFromDb(string storage_id, IntPtr filter, out int media_count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_destroy")]
        internal static extern MediaContentError Destroy(IntPtr storage);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_clone")]
        internal static extern MediaContentError Clone(out IntPtr dst, IntPtr src);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_id")]
        internal static extern MediaContentError GetId(IntPtr storage, out IntPtr storage_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_name")]
        internal static extern MediaContentError GetName(IntPtr storage, out IntPtr storage_name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_path")]
        internal static extern MediaContentError GetPath(IntPtr storage, out IntPtr storage_path);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_type")]
        internal static extern MediaContentError GetType(IntPtr storage, out ContentStorageType storage_type);

        //Callbacks
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MediaStorageCallback(IntPtr mediaStorageHandle, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MediaInfoCallback(IntPtr mediaInformation, IntPtr data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_foreach_storage_from_db")]
        internal static extern MediaContentError ForeachStorageFromDb(IntPtr filter, MediaStorageCallback callback, IntPtr user_data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_foreach_media_from_db")]
        internal static extern MediaContentError ForeachMediaFromDb(string storage_id, IntPtr filter, MediaInfoCallback callback, IntPtr user_data);
    }
}
