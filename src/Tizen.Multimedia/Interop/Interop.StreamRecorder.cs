using System;
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
    internal static partial class Interop
    {
        internal static partial class StreamRecorder
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void RecordingLimitReachedCallback(StreamRecordingLimitType type, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void RecordingStatusCallback(ulong elapsedTime, ulong fileSize, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void NotifiedCallback(StreamRecorderState previous, StreamRecorderState current, StreamRecorderNotify notfication, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void RecorderErrorCallback(StreamRecorderErrorCode error, StreamRecorderState current, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void BufferConsumedCallback(IntPtr buffer, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate bool VideoResolutionCallback(int width, int height, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate bool FileFormatCallback(StreamRecorderFileFormat format, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate bool AudioEncoderCallback(StreamRecorderAudioCodec codec, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate bool VideoEncoderCallback(StreamRecorderVideoCodec codec, IntPtr userData);

            /* begin of method */
            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_create")]
            internal static extern int Create(out IntPtr handle);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_destroy")]
            internal static extern int Destroy(IntPtr handle);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_prepare")]
            internal static extern int Prepare(IntPtr handle);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_unprepare")]
            internal static extern int Unprepare(IntPtr handle);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_start")]
            internal static extern int Start(IntPtr handle);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_pause")]
            internal static extern int Pause(IntPtr handle);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_commit")]
            internal static extern int Commit(IntPtr handle);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_cancel")]
            internal static extern int Cancel(IntPtr handle);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_push_stream_buffer")]
            internal static extern int PushStreamBuffer(IntPtr handle, IntPtr/*  media_packet_h */ inbuf);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_enable_source_buffer")]
            internal static extern int EnableSourceBuffer(IntPtr handle, int type);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_state")]
            internal static extern int GetState(IntPtr handle, out int state);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_filename")]
            internal static extern int SetFileName(IntPtr handle, string path);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_filename")]
            internal static extern int GetFileName(IntPtr handle, out IntPtr path);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_file_format")]
            internal static extern int SetFileFormat(IntPtr handle, int format);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_file_format")]
            internal static extern int GetFileFormat(IntPtr handle, out int format);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_audio_encoder")]
            internal static extern int SetAudioEncoder(IntPtr handle, int codec);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_audio_encoder")]
            internal static extern int GetAudioEncoder(IntPtr handle, out int codec);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_video_encoder")]
            internal static extern int SetVideoEncoder(IntPtr handle, int codec);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_video_encoder")]
            internal static extern int GetVideoEncoder(IntPtr handle, out int codec);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_video_resolution")]
            internal static extern int SetVideoResolution(IntPtr handle, int width, int height);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_video_resolution")]
            internal static extern int GetVideoResolution(IntPtr handle, out int width, out int height);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_video_framerate")]
            internal static extern int SetVideoFramerate(IntPtr handle, int framerate);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_video_framerate")]
            internal static extern int GetVideoFramerate(IntPtr handle, out int framerate);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_video_source_format")]
            internal static extern int SetVideoSourceFormat(IntPtr handle, int format);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_video_source_format")]
            internal static extern int GetVideoSourceFormat(IntPtr handle, out int format);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_recording_limit")]
            internal static extern int SetRecordingLimit(IntPtr handle, int type, int limit);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_recording_limit")]
            internal static extern int GetRecordingLimit(IntPtr handle, int type, out int format);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_audio_samplerate")]
            internal static extern int SetAudioSampleRate(IntPtr handle, int samplerate);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_audio_samplerate")]
            internal static extern int GetAudioSampleRate(IntPtr handle, out int samplerate);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_audio_encoder_bitrate")]
            internal static extern int SetAudioEncoderBitrate(IntPtr handle, int bitrate);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_audio_encoder_bitrate")]
            internal static extern int GetAudioEncoderBitrate(IntPtr handle, out int bitrate);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_video_encoder_bitrate")]
            internal static extern int SetVideoEncoderBitrate(IntPtr handle, int bitrate);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_video_encoder_bitrate")]
            internal static extern int GetVideoEncoderBitrate(IntPtr handle, out int bitrate);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_audio_channel")]
            internal static extern int SetAudioChannel(IntPtr handle, int channel);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_audio_channel")]
            internal static extern int GetAudioChannel(IntPtr handle, out int channel);
            /* End of method */

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_foreach_supported_file_format")]
            internal static extern int FileFormats(IntPtr handle, FileFormatCallback callback, IntPtr userData);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_foreach_supported_audio_encoder")]
            internal static extern int AudioEncoders(IntPtr handle, AudioEncoderCallback callback, IntPtr userData);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_foreach_supported_video_encoder")]
            internal static extern int VideoEncoders(IntPtr handle, VideoEncoderCallback callback, IntPtr userData);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_foreach_supported_video_resolution")]
            internal static extern int VideoResolution(IntPtr handle, VideoResolutionCallback callback, IntPtr userData);
            /* End of foreach method */

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_notify_cb")]
            internal static extern int SetNotifiedCallback(IntPtr handle, NotifiedCallback callback, IntPtr userData);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_unset_notify_cb")]
            internal static extern int UnsetNotifiedCallback(IntPtr handle);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_recording_status_cb")]
            internal static extern int SetStatusChangedCallback(IntPtr handle, RecordingStatusCallback callback, IntPtr userData);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_unset_recording_status_cb")]
            internal static extern int UnsetStatusChangedCallback(IntPtr handle);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_recording_limit_reached_cb")]
            internal static extern int SetLimitReachedCallback(IntPtr handle, RecordingLimitReachedCallback callback, IntPtr userData);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_unset_recording_limit_reached_cb")]
            internal static extern int UnsetLimitReachedCallback(IntPtr handle);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_error_cb")]
            internal static extern int SetErrorCallback(IntPtr handle, RecorderErrorCallback callback, IntPtr userData);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_unset_error_cb")]
            internal static extern int UnsetErrorCallback(IntPtr handle);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_buffer_consume_completed_cb")]
            internal static extern int SetBufferConsumedCallback(IntPtr handle, BufferConsumedCallback callback, IntPtr userDat);

            [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_unset_buffer_consume_completed_cb")]
            internal static extern int UnsetBufferConsumedCallback(IntPtr handle);
        }
    }
}