using System;
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
    internal static partial class Interop
    {
        internal static partial class ThumbnailExtractor
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void ThumbnailExtractCallback(ThumbnailExtractorError error, string requestId, int thumbWidth, int thumbHeight, IntPtr thumbData, int thumbSize, IntPtr userData);

            [DllImport(Libraries.ThumbnailExtractor, EntryPoint = "thumbnail_util_create")]
            internal static extern ThumbnailExtractorError Create(out IntPtr handle);

            [DllImport(Libraries.ThumbnailExtractor, EntryPoint = "thumbnail_util_extract")]
            internal static extern ThumbnailExtractorError Extract(IntPtr handle, ThumbnailExtractCallback callback, IntPtr userData, out IntPtr requestId);

            [DllImport(Libraries.ThumbnailExtractor, EntryPoint = "thumbnail_util_set_path")]
            internal static extern ThumbnailExtractorError SetPath(IntPtr handle, string path);

            [DllImport(Libraries.ThumbnailExtractor, EntryPoint = "thumbnail_util_set_size")]
            internal static extern ThumbnailExtractorError SetSize(IntPtr handle, int width, int height);

            [DllImport(Libraries.ThumbnailExtractor, EntryPoint = "thumbnail_util_destroy")]
            internal static extern ThumbnailExtractorError Destroy(IntPtr handle);
        }
    }
}