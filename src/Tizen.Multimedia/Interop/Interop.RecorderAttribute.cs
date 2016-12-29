using System;
using System.Runtime.InteropServices;
using Tizen.Multimedia;

internal static partial class Interop
{
	internal static partial class RecorderAttribute
	{
		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_size_limit")]
		internal static extern int SetSizeLimit(IntPtr handle, int kbyte);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_size_limit")]
		internal static extern int GetSizeLimit(IntPtr handle, out int kbyte);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_time_limit")]
		internal static extern int SetTimeLimit(IntPtr handle, int second);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_time_limit")]
		internal static extern int GetTimeLimit(IntPtr handle, out int second);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_device")]
		internal static extern int SetAudioDevice(IntPtr handle, int device);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_device")]
		internal static extern int GetAudioDevice(IntPtr handle, out int device);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_samplerate")]
		internal static extern int SetAudioSampleRate(IntPtr handle, int sampleRate);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_samplerate")]
		internal static extern int GetAudioSampleRate(IntPtr handle, out int sampleRate);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_encoder_bitrate")]
		internal static extern int SetAudioEncoderBitrate(IntPtr handle, int bitRate);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_encoder_bitrate")]
		internal static extern int GetAudioEncoderBitrate(IntPtr handle, out int bitRate);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_video_encoder_bitrate")]
		internal static extern int SetVideoEncoderBitrate(IntPtr handle, int bitRate);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_video_encoder_bitrate")]
		internal static extern int GetVideoEncoderBitrate(IntPtr handle, out int bitRate);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_mute")]
		internal static extern int SetMute(IntPtr handle, bool enable);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_is_muted")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool GetMute(IntPtr handle);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_recording_motion_rate")]
		internal static extern int SetMotionRate(IntPtr handle, double motionRate);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_recording_motion_rate")]
		internal static extern int GetMotionRate(IntPtr handle, out double motionRate);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_channel")]
		internal static extern int SetAudioChannel(IntPtr handle, int channelCount);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_channel")]
		internal static extern int GetAudioChannel(IntPtr handle, out int channelCount);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_orientation_tag")]
		internal static extern int SetOrientationTag(IntPtr handle, int orientation);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_orientation_tag")]
		internal static extern int GetOrientationTag(IntPtr handle, out int orientation);
	}
}
