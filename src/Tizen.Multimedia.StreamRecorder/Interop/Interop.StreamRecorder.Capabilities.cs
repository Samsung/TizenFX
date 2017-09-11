using System;
using System.Runtime.InteropServices;
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class StreamRecorder
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool VideoResolutionCallback(int width, int height, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool FileFormatCallback(StreamRecorderFileFormat format, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AudioEncoderCallback(StreamRecorderAudioCodec codec, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool VideoEncoderCallback(StreamRecorderVideoCodec codec, IntPtr userData);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_foreach_supported_file_format")]
        internal static extern StreamRecorderErrorCode FileFormats(StreamRecorderHandle handle,
            FileFormatCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_foreach_supported_audio_encoder")]
        internal static extern StreamRecorderErrorCode AudioEncoders(StreamRecorderHandle handle,
            AudioEncoderCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_foreach_supported_video_encoder")]
        internal static extern StreamRecorderErrorCode VideoEncoders(StreamRecorderHandle handle,
            VideoEncoderCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_foreach_supported_video_resolution")]
        internal static extern StreamRecorderErrorCode VideoResolution(StreamRecorderHandle handle,
            VideoResolutionCallback callback, IntPtr userData = default(IntPtr));
    }
}
