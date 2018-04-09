/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.InteropServices;
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class Recorder
    {
        [DllImport(Libraries.Recorder, EntryPoint = "recorder_create_audiorecorder")]
        internal static extern RecorderErrorCode Create(out RecorderHandle handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_create_videorecorder")]
        internal static extern RecorderErrorCode CreateVideo(IntPtr cameraHandle, out RecorderHandle handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_prepare")]
        internal static extern RecorderErrorCode Prepare(RecorderHandle handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_unprepare")]
        internal static extern RecorderErrorCode Unprepare(RecorderHandle handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_start")]
        internal static extern RecorderErrorCode Start(RecorderHandle handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_pause")]
        internal static extern RecorderErrorCode Pause(RecorderHandle handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_commit")]
        internal static extern RecorderErrorCode Commit(RecorderHandle handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_cancel")]
        internal static extern RecorderErrorCode Cancel(RecorderHandle handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_state")]
        internal static extern RecorderErrorCode GetState(RecorderHandle handle, out RecorderState state);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_sound_stream_info")]
        internal static extern RecorderErrorCode SetAudioStreamPolicy(RecorderHandle handle, AudioStreamPolicyHandle streamInfoHandle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_device_state")]
        internal static extern RecorderErrorCode GetDeviceState(RecorderType type, out RecorderDeviceState state);
    }

    internal class RecorderHandle : SafeHandle
    {
        [DllImport(Libraries.Recorder, EntryPoint = "recorder_destroy")]
        private static extern RecorderErrorCode Destroy(IntPtr handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_cancel")]
        private static extern RecorderErrorCode Cancel(IntPtr handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_unprepare")]
        private static extern RecorderErrorCode Unprepare(IntPtr handle);

        protected RecorderHandle() : base(IntPtr.Zero, true)
        {
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            Cancel(handle).Ignore(RecorderErrorCode.InvalidState).ThrowIfError("Failed to cancel");
            Unprepare(handle).Ignore(RecorderErrorCode.InvalidState).ThrowIfError("Failed to unprepare");

            var ret = Destroy(handle);
            if (ret != RecorderErrorCode.None)
            {
                Tizen.Log.Debug(GetType().FullName, $"Failed to release native RecorderHandle.");

                return false;
            }
            return true;
        }
    }
}