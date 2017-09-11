using System;
using System.Runtime.InteropServices;
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class StreamRecorder
    {
        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_filename")]
        internal static extern StreamRecorderErrorCode SetFileName(StreamRecorderHandle handle, string path);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_filename")]
        internal static extern int GetFileName(StreamRecorderHandle handle, out IntPtr path);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_file_format")]
        internal static extern StreamRecorderErrorCode SetFileFormat(StreamRecorderHandle handle,
            StreamRecorderFileFormat format);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_file_format")]
        internal static extern int GetFileFormat(StreamRecorderHandle handle, out int format);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_audio_encoder")]
        internal static extern StreamRecorderErrorCode SetAudioEncoder(StreamRecorderHandle handle,
            StreamRecorderAudioCodec codec);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_audio_encoder")]
        internal static extern int GetAudioEncoder(StreamRecorderHandle handle, out int codec);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_video_encoder")]
        internal static extern StreamRecorderErrorCode SetVideoEncoder(StreamRecorderHandle handle,
            StreamRecorderVideoCodec codec);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_video_encoder")]
        internal static extern int GetVideoEncoder(StreamRecorderHandle handle, out int codec);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_video_resolution")]
        internal static extern StreamRecorderErrorCode SetVideoResolution(StreamRecorderHandle handle,
            int width, int height);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_video_resolution")]
        internal static extern StreamRecorderErrorCode GetVideoResolution(StreamRecorderHandle handle,
            out int width, out int height);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_video_framerate")]
        internal static extern StreamRecorderErrorCode SetVideoFrameRate(StreamRecorderHandle handle, int framerate);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_video_framerate")]
        internal static extern int GetVideoFramerate(StreamRecorderHandle handle, out int framerate);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_video_source_format")]
        internal static extern StreamRecorderErrorCode SetVideoSourceFormat(StreamRecorderHandle handle,
            StreamRecorderVideoFormat format);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_video_source_format")]
        internal static extern int GetVideoSourceFormat(StreamRecorderHandle handle, out int format);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_recording_limit")]
        internal static extern StreamRecorderErrorCode SetRecordingLimit(StreamRecorderHandle handle,
            RecordingLimitType type, int limit);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_recording_limit")]
        internal static extern int GetRecordingLimit(StreamRecorderHandle handle, int type, out int format);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_audio_samplerate")]
        internal static extern StreamRecorderErrorCode SetAudioSampleRate(StreamRecorderHandle handle, int samplerate);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_audio_samplerate")]
        internal static extern int GetAudioSampleRate(StreamRecorderHandle handle, out int samplerate);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_audio_encoder_bitrate")]
        internal static extern StreamRecorderErrorCode SetAudioEncoderBitrate(StreamRecorderHandle handle, int bitrate);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_audio_encoder_bitrate")]
        internal static extern int GetAudioEncoderBitrate(StreamRecorderHandle handle, out int bitrate);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_video_encoder_bitrate")]
        internal static extern StreamRecorderErrorCode SetVideoEncoderBitRate(StreamRecorderHandle handle, int bitrate);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_video_encoder_bitrate")]
        internal static extern int GetVideoEncoderBitrate(StreamRecorderHandle handle, out int bitrate);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_audio_channel")]
        internal static extern StreamRecorderErrorCode SetAudioChannel(StreamRecorderHandle handle, int channel);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_audio_channel")]
        internal static extern int GetAudioChannel(StreamRecorderHandle handle, out int channel);
    }
}
