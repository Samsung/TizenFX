using System;
using System.Runtime.InteropServices;
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class StreamRecorder
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RecordingLimitReachedCallback(RecordingLimitType type, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RecordingStatusCallback(ulong elapsedTime, ulong fileSize, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void NotifiedCallback(int previous, int current,
            StreamRecorderNotify notify, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RecorderErrorCallback(StreamRecorderErrorCode error,
            RecorderState current, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void BufferConsumedCallback(IntPtr buffer, IntPtr userData);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_notify_cb")]
        internal static extern StreamRecorderErrorCode SetNotifiedCallback(StreamRecorderHandle handle,
            NotifiedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_unset_notify_cb")]
        internal static extern int UnsetNotifiedCallback(StreamRecorderHandle handle);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_recording_status_cb")]
        internal static extern StreamRecorderErrorCode SetStatusChangedCallback(StreamRecorderHandle handle,
            RecordingStatusCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_unset_recording_status_cb")]
        internal static extern int UnsetStatusChangedCallback(StreamRecorderHandle handle);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_recording_limit_reached_cb")]
        internal static extern StreamRecorderErrorCode SetLimitReachedCallback(StreamRecorderHandle handle,
            RecordingLimitReachedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_unset_recording_limit_reached_cb")]
        internal static extern int UnsetLimitReachedCallback(StreamRecorderHandle handle);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_error_cb")]
        internal static extern StreamRecorderErrorCode SetErrorCallback(StreamRecorderHandle handle,
            RecorderErrorCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_unset_error_cb")]
        internal static extern int UnsetErrorCallback(StreamRecorderHandle handle);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_set_buffer_consume_completed_cb")]
        internal static extern StreamRecorderErrorCode SetBufferConsumedCallback(StreamRecorderHandle handle,
            BufferConsumedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_unset_buffer_consume_completed_cb")]
        internal static extern int UnsetBufferConsumedCallback(StreamRecorderHandle handle);
    }
}
