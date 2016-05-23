using System;
using System.Runtime.InteropServices;
using Tizen.Multimedia;

internal static partial class Interop
{
	internal static partial class Libc
	{
		[DllImport(Libraries.Libc, EntryPoint = "free")]
		public static extern void Free(IntPtr userData);

	}
		
	internal static partial class Recorder
	{

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RecordingLimitReachedCallback(RecordingLimitType type, IntPtr userData);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RecordingStatusCallback(ulong elapsedTime, ulong fileSize, IntPtr userData);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void StatechangedCallback(RecorderState previous, RecorderState current, bool byPolicy, IntPtr userData);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void InterruptedCallback(RecorderPolicy policy, RecorderState previous, RecorderState current, IntPtr userData);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void AudioStreamCallback(IntPtr stream, int size, AudioSampleType type, int channel, uint timeStamp, IntPtr userData);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RecorderErrorCallback(RecorderErrorCode error, RecorderState current, IntPtr userData);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_create_videorecorder")]
		internal static extern int Create(Camera camera, out IntPtr handle);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_create_audiorecorder")]
		internal static extern int Create(out IntPtr handle);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_destroy")]
		internal static extern int Destroy(IntPtr handle);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_prepare")]
		internal static extern int Prepare(IntPtr handle);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_unprepare")]
		internal static extern int Unprepare(IntPtr handle);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_start")]
		internal static extern int Start(IntPtr handle);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_pause")]
		internal static extern int Pause(IntPtr handle);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_commit")]
		internal static extern int Commit(IntPtr handle);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_cancel")]
		internal static extern int Cancel(IntPtr handle);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_get_state")]
		internal static extern int GetState(IntPtr handle, out int state);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_get_audio_level")]
		internal static extern int GetAudioLevel(IntPtr handle, out double dB);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_set_filename")]
		internal static extern int SetFileName(IntPtr handle, String path);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_get_filename")]
		internal static extern int GetFileName(IntPtr handle, out IntPtr path);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_set_file_format")]
		internal static extern int SetFileFormat(IntPtr handle, int format);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_get_file_format")]
		internal static extern int GetFileFormat(IntPtr handle, out int format);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_set_audio_encoder")]
		internal static extern int SetAudioEncoder(IntPtr handle, int codec);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_get_audio_encoder")]
		internal static extern int GetAudioEncoder(IntPtr handle, out int codec);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_set_video_encoder")]
		internal static extern int SetVideoEncoder(IntPtr handle, int codec);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_get_video_encoder")]
		internal static extern int GetVideoEncoder(IntPtr handle, out int codec);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_set_video_resolution")]
		internal static extern int SetVideoResolution(IntPtr handle, int width, int height);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_get_video_resolution")]
		internal static extern int GetVideoResolution(IntPtr handle, out int width, out int height);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_set_state_changed_cb")]
		internal static extern int SetStateChangedCallback(IntPtr handle, StatechangedCallback callback, IntPtr userData);
		[DllImport(Libraries.Recorder, EntryPoint = "recorder_unset_state_changed_cb")]
		internal static extern int UnsetStateChangedCallback(IntPtr handle);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_set_recording_status_cb")]
		internal static extern int SetStatusChangedCallback(IntPtr handle, RecordingStatusCallback callback, IntPtr userData);
		[DllImport(Libraries.Recorder, EntryPoint = "recorder_unset_recording_status_cb")]
		internal static extern int UnsetStatusChangedCallback(IntPtr handle);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_set_interrupted_cb")]
		internal static extern int SetInterruptedCallback(IntPtr handle, InterruptedCallback callback, IntPtr userData);
		[DllImport(Libraries.Recorder, EntryPoint = "recorder_unset_interrupted_cb")]
		internal static extern int UnsetInterruptedCallback(IntPtr handle);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_set_audio_stream_cb")]
		internal static extern int SetAudioStreamCallback(IntPtr handle, AudioStreamCallback callback, IntPtr userData);
		[DllImport(Libraries.Recorder, EntryPoint = "recorder_unset_audio_stream_cb")]
		internal static extern int UnsetAudioStreamCallback(IntPtr handle);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_set_recording_limit_reached_cb")]
		internal static extern int SetLimitReachedCallback(IntPtr handle, RecordingLimitReachedCallback callback, IntPtr userData);
		[DllImport(Libraries.Recorder, EntryPoint = "recorder_unset_recording_limit_reached_cb")]
		internal static extern int UnsetLimitReachedCallback(IntPtr handle);

		[DllImport(Libraries.Recorder, EntryPoint = "recorder_set_error_cb")]
		internal static extern int SetErrorCallback(IntPtr handle, RecorderErrorCallback callback, IntPtr userData);
		[DllImport(Libraries.Recorder, EntryPoint = "recorder_unset_error_cb")]
		internal static extern int UnsetErrorCallback(IntPtr handle);
	}
}
