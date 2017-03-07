using System;
using System.Runtime.InteropServices;
using Tizen.Content.MediaContent;


internal static partial class Interop
{
    internal static partial class Content
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_content_connect")]
        internal static extern MediaContentError Connect();

        [DllImport(Libraries.MediaContent, EntryPoint = "media_content_disconnect")]
        internal static extern MediaContentError Disconnect();

        [DllImport(Libraries.MediaContent, EntryPoint = "media_content_scan_file")]
        internal static extern MediaContentError ScanFile(string filePath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_content_cancel_scan_folder")]
        internal static extern MediaContentError CancelScanFolder(string folderPath);

        // Callback
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MediaScanCompletedCallback(MediaContentError error, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MediaContentDBUpdatedCallback(MediaContentError error, int pid, MediaContentUpdateItemType updateItem, MediaContentDBUpdateType updateType, MediaContentType mediaType, string uuid, string filePath, string mimeType, IntPtr data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_content_scan_folder")]
        internal static extern MediaContentError ScanFolder(string folderPath, bool is_recursive, MediaScanCompletedCallback scanCompletedCallback, IntPtr userData);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_content_set_db_updated_cb")]
        internal static extern MediaContentError SetDbUpdatedCb(MediaContentDBUpdatedCallback mediaContentDBUpdatedCallback, IntPtr userData);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_content_unset_db_updated_cb")]
        internal static extern MediaContentError UnsetDbUpdatedCb();

        [DllImport(Libraries.MediaContent, EntryPoint = "media_content_add_db_updated_cb")]
        internal static extern MediaContentError AddDbUpdatedCb(MediaContentDBUpdatedCallback mediaContentDBUpdatedCallback, IntPtr userData, out IntPtr noti_handle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_content_remove_db_updated_cb")]
        internal static extern MediaContentError RemoveDbUpdatedCb(IntPtr noti_handle);
    }
}
