using System;
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
    internal static partial class Interop
    {
        internal static partial class RecorderSettings
        {
            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_channel")]
            internal static extern int GetAudioChannel(IntPtr handle, out int channelCount);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_channel")]
            internal static extern int SetAudioChannel(IntPtr handle, int channelCount);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_device")]
            internal static extern int GetAudioDevice(IntPtr handle, out RecorderAudioDevice device);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_device")]
            internal static extern int SetAudioDevice(IntPtr handle, RecorderAudioDevice device);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_audio_level")]
            internal static extern int GetAudioLevel(IntPtr handle, out double dB);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_samplerate")]
            internal static extern int GetAudioSampleRate(IntPtr handle, out int sampleRate);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_samplerate")]
            internal static extern int SetAudioSampleRate(IntPtr handle, int sampleRate);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_encoder_bitrate")]
            internal static extern int GetAudioEncoderBitrate(IntPtr handle, out int bitRate);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_encoder_bitrate")]
            internal static extern int SetAudioEncoderBitrate(IntPtr handle, int bitRate);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_video_encoder_bitrate")]
            internal static extern int GetVideoEncoderBitrate(IntPtr handle, out int bitRate);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_video_encoder_bitrate")]
            internal static extern int SetVideoEncoderBitrate(IntPtr handle, int bitRate);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_audio_encoder")]
            internal static extern int GetAudioEncoder(IntPtr handle, out RecorderAudioCodec codec);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_audio_encoder")]
            internal static extern int SetAudioEncoder(IntPtr handle, RecorderAudioCodec codec);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_video_encoder")]
            internal static extern int GetVideoEncoder(IntPtr handle, out RecorderVideoCodec codec);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_video_encoder")]
            internal static extern int SetVideoEncoder(IntPtr handle, RecorderVideoCodec codec);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_file_format")]
            internal static extern int GetFileFormat(IntPtr handle, out RecorderFileFormat format);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_file_format")]
            internal static extern int SetFileFormat(IntPtr handle, RecorderFileFormat format);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_filename")]
            internal static extern int GetFileName(IntPtr handle, out IntPtr path);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_filename")]
            internal static extern int SetFileName(IntPtr handle, string path);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_size_limit")]
            internal static extern int GetSizeLimit(IntPtr handle, out int kbyte);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_size_limit")]
            internal static extern int SetSizeLimit(IntPtr handle, int kbyte);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_time_limit")]
            internal static extern int GetTimeLimit(IntPtr handle, out int second);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_time_limit")]
            internal static extern int SetTimeLimit(IntPtr handle, int second);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_is_muted")]
            [return: MarshalAs(UnmanagedType.I1)]
            internal static extern bool GetMute(IntPtr handle);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_mute")]
            internal static extern int SetMute(IntPtr handle, bool enable);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_recording_motion_rate")]
            internal static extern int GetMotionRate(IntPtr handle, out double motionRate);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_recording_motion_rate")]
            internal static extern int SetMotionRate(IntPtr handle, double motionRate);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_orientation_tag")]
            internal static extern int GetOrientationTag(IntPtr handle, out RecorderOrientation orientation);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_orientation_tag")]
            internal static extern int SetOrientationTag(IntPtr handle, RecorderOrientation orientation);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_video_resolution")]
            internal static extern int GetVideoResolution(IntPtr handle, out int width, out int height);

            [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_video_resolution")]
            internal static extern int SetVideoResolution(IntPtr handle, int width, int height);
        }
    }
}