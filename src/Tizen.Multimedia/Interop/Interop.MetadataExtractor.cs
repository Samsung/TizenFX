using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
	internal static partial class MetadataExtractor
	{
		[DllImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_create")]
		internal static extern int Create(out IntPtr handle);

		[DllImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_set_path")]
		internal static extern int SetPath(IntPtr handle, string path);

		[DllImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_set_buffer")]
		internal static extern int SetBuffer(IntPtr handle, IntPtr buffer, int size);

		[DllImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_destroy")]
		internal static extern int Destroy(IntPtr handle);

		[DllImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_get_metadata")]
		internal static extern int GetMetadata(IntPtr handle, int attribute, out string value);

		[DllImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_get_artwork")]
		internal static extern int GetArtwork(IntPtr handle, out IntPtr artwork, out int size, out string mimeType);

		[DllImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_get_frame")]
		internal static extern int GetFrame(IntPtr handle, out IntPtr frame, out int size);

		[DllImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_get_synclyrics")]
		internal static extern int GetSynclyrics(IntPtr handle, int index, out uint timeStamp, out string lyrics);

		[DllImport(Libraries.MetadataExtractor, EntryPoint = "metadata_extractor_get_frame_at_time")]
		internal static extern int GetFrameAtTime(IntPtr handle, uint timeStamp, bool isAccurate, out IntPtr frame, out int size);
	}
}
