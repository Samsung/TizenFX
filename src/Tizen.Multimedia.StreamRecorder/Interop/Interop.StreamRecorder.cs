using System;
using System.Runtime.InteropServices;
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class StreamRecorder
    {
        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_create")]
        internal static extern StreamRecorderErrorCode Create(out StreamRecorderHandle handle);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_prepare")]
        internal static extern StreamRecorderErrorCode Prepare(StreamRecorderHandle handle);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_unprepare")]
        internal static extern StreamRecorderErrorCode Unprepare(StreamRecorderHandle handle);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_start")]
        internal static extern StreamRecorderErrorCode Start(StreamRecorderHandle handle);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_pause")]
        internal static extern StreamRecorderErrorCode Pause(StreamRecorderHandle handle);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_commit")]
        internal static extern StreamRecorderErrorCode Commit(StreamRecorderHandle handle);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_cancel")]
        internal static extern StreamRecorderErrorCode Cancel(StreamRecorderHandle handle);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_push_stream_buffer")]
        internal static extern StreamRecorderErrorCode PushStreamBuffer(StreamRecorderHandle handle,
            IntPtr mediaPacketHandle);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_enable_source_buffer")]
        internal static extern StreamRecorderErrorCode EnableSourceBuffer(StreamRecorderHandle handle,
            StreamRecorderSourceType type);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_get_state")]
        internal static extern StreamRecorderErrorCode GetState(StreamRecorderHandle handle, out RecorderState state);
    }

    internal class StreamRecorderHandle : SafeHandle
    {
        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_destroy")]
        private static extern StreamRecorderErrorCode Destroy(IntPtr handle);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_cancel")]
        private static extern StreamRecorderErrorCode Cancel(IntPtr handle);

        [DllImport(Libraries.StreamRecorder, EntryPoint = "streamrecorder_unprepare")]
        private static extern StreamRecorderErrorCode Unprepare(IntPtr handle);

        protected StreamRecorderHandle() : base(IntPtr.Zero, true)
        {
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            try
            {
                Cancel(handle).Ignore(StreamRecorderErrorCode.InvalidState).ThrowIfError("Failed to cancel.");
                Unprepare(handle).Ignore(StreamRecorderErrorCode.InvalidState).ThrowIfError("Failed to unprepare.");
                Destroy(handle).ThrowIfError("Failed to destory.");

                return true;
            }
            catch (Exception e)
            {
                Tizen.Log.Debug(GetType().FullName, $"Failed to release native RecorderHandle; {e.Message}");

                return false;
            }
        }
    }
}
