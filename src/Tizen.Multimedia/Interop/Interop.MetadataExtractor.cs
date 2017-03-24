using System;
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
    internal static partial class Interop
    {
        internal static partial class MetadataExtractor
        {
            [DllImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_create")]
            internal static extern MetadataExtractorError Create(out IntPtr handle);

            [DllImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_set_path")]
            internal static extern MetadataExtractorError SetPath(IntPtr handle, string path);

            [DllImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_set_buffer")]
            internal static extern MetadataExtractorError SetBuffer(IntPtr handle, IntPtr buffer, int size);

            [DllImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_destroy")]
            internal static extern MetadataExtractorError Destroy(IntPtr handle);

            [DllImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_get_metadata")]
            private static extern MetadataExtractorError GetMetadata(IntPtr handle, MetadataExtractorAttr attribute, out IntPtr value);

            internal static string GetMetadata(IntPtr handle, MetadataExtractorAttr attr)
            {
                IntPtr valuePtr = IntPtr.Zero;

                try
                {
                    var ret = GetMetadata(handle, attr, out valuePtr);
                    MetadataExtractorRetValidator.ThrowIfError(ret, "Failed to get value for " + attr);
                    return Marshal.PtrToStringAnsi(valuePtr);
                }
                finally
                {
                    Libc.Free(valuePtr);
                }
            }

            [DllImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_get_artwork")]
            internal static extern MetadataExtractorError GetArtwork(IntPtr handle, out IntPtr artwork,
                out int size, out IntPtr mimeType);

            [DllImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_get_frame")]
            internal static extern MetadataExtractorError GetFrame(IntPtr handle, out IntPtr frame, out int size);

            [DllImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_get_synclyrics")]
            internal static extern MetadataExtractorError GetSynclyrics(IntPtr handle, int index,
                out uint timeStamp, out IntPtr lyrics);

            [DllImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_get_frame_at_time")]
            internal static extern MetadataExtractorError GetFrameAtTime(IntPtr handle, uint timeStamp,
                bool isAccurate, out IntPtr frame, out int size);
        }
    }
}