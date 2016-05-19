using System;
using System.Runtime.InteropServices;
using Tizen.Multimedia;

internal static partial class Interop
{
	internal static partial class RecorderCapablity
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate bool VideoResolutionCallback(int width, int height, IntPtr userData);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate bool FileFormatCallback(RecorderFileFormat format, IntPtr userData);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate bool AudioEncoderCallback(RecorderAudioCodec codec, IntPtr userData);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate bool VideoEncoderCallback(RecorderVideoCodec codec, IntPtr userData);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_foreach_supported_file_format")]
		internal static extern int FileFormats(IntPtr handle, FileFormatCallback callback, IntPtr userData);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_foreach_supported_audio_encoder")]
		internal static extern int AudioEncoders(IntPtr handle, AudioEncoderCallback callback, IntPtr userData);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_foreach_supported_video_encoder")]
		internal static extern int VideoEncoders(IntPtr handle, VideoEncoderCallback callback, IntPtr userData);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_foreach_supported_video_resolution")]
		internal static extern int VideoResolution(IntPtr handle, VideoResolutionCallback callback, IntPtr userData);
	}
}
