using System;
using System.Runtime.InteropServices;
using Tizen.Content.MediaContent;

internal static partial class Interop
{
    internal static partial class Storage
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_storage_info_from_db")]
        internal static extern int GetStorageInfoFromDb(string storage_id, out IntPtr storage);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_storage_count_from_db")]
        internal static extern int GetStorageCountFromDb(IntPtr filter, out int storage_count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_media_count_from_db")]
        internal static extern int GetMediaCountFromDb(string storage_id, IntPtr filter, out int media_count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_destroy")]
        internal static extern int Destroy(IntPtr storage);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_clone")]
        internal static extern int Clone(out IntPtr dst, IntPtr src);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_id")]
        internal static extern int GetId(IntPtr storage, out string storage_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_name")]
        internal static extern int GetName(IntPtr storage, out string storage_name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_path")]
        internal static extern int GetPath(IntPtr storage, out string storage_path);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_get_type")]
        internal static extern int GetType(IntPtr storage, out int storage_type);

        //Callbacks
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MediaStorageCallback(IntPtr mediaStorageHandle, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MediaInfoCallback(Interop.MediaInformation.SafeMediaInformationHandle mediaInformation, IntPtr data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_foreach_storage_from_db")]
        internal static extern int ForeachStorageFromDb(IntPtr? filter, MediaStorageCallback callback, IntPtr user_data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_storage_foreach_media_from_db")]
        internal static extern int ForeachMediaFromDb(string storage_id, IntPtr filter, MediaInfoCallback callback, IntPtr user_data);
    }
}