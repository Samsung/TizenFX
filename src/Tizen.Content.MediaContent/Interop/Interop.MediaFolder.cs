using System;
using System.Runtime.InteropServices;
using Tizen.Content.MediaContent;

internal static partial class Interop
{
    internal static partial class Folder
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_get_folder_count_from_db")]
        internal static extern MediaContentError GetFolderCountFromDb(IntPtr filter, out int folder_count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_get_media_count_from_db")]
        internal static extern MediaContentError GetMediaCountFromDb(string folder_id, IntPtr filter, out int media_count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_clone")]
        internal static extern MediaContentError Clone(out IntPtr dst, IntPtr src);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_destroy")]
        internal static extern MediaContentError Destroy(IntPtr folder);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_get_folder_id")]
        internal static extern MediaContentError GetFolderId(IntPtr folder, out string folder_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_get_parent_folder_id")]
        internal static extern MediaContentError GetParentFolderId(IntPtr folder, out string parent_folder_id);


        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_get_path")]
        internal static extern MediaContentError GetPath(IntPtr folder, out string folderPath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_get_name")]
        internal static extern MediaContentError GetName(IntPtr folder, out string folder_name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_get_modified_time")]
        internal static extern MediaContentError GetModifiedTime(IntPtr folder, out DateTime date);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_get_storage_type")]
        internal static extern MediaContentError GetStorageType(IntPtr folder, out int storage_type);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_get_storage_id")]
        internal static extern MediaContentError GetStorageId(IntPtr folder, out string storage_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_get_order")]
        internal static extern MediaContentError GetOrder(IntPtr folder, out int order);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_get_folder_from_db")]
        internal static extern MediaContentError GetFolderFromDb(string folder_id, out IntPtr folder);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_set_name")]
        internal static extern MediaContentError SetName(IntPtr folder, string name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_set_order")]
        internal static extern MediaContentError SetOrder(IntPtr folder, int order);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_update_to_db")]
        internal static extern MediaContentError UpdateToDb(IntPtr folder);

        //Callbacks
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MediaFolderCallback(IntPtr folderHandle, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MediaInfoCallback(IntPtr handle, IntPtr data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_foreach_folder_from_db")]
        internal static extern MediaContentError ForeachFolderFromDb(IntPtr filter, MediaFolderCallback callback, IntPtr user_data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_folder_foreach_media_from_db")]
        internal static extern MediaContentError ForeachMediaFromDb(string folder_id, IntPtr filter, MediaInfoCallback callback, IntPtr user_data);
    }
}
