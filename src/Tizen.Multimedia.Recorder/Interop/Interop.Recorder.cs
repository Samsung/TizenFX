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
using System.Runtime.InteropServices.Marshalling;
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class Recorder
    {
        [DllImport(Libraries.Recorder, EntryPoint = "recorder_create_audiorecorder")]
        internal static extern RecorderErrorCode Create(out RecorderHandle handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_create_videorecorder")]
        internal static extern RecorderErrorCode CreateVideo(IntPtr cameraHandle, out RecorderHandle handle);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_prepare", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial RecorderErrorCode Prepare(RecorderHandle handle);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_unprepare", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial RecorderErrorCode Unprepare(RecorderHandle handle);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_start", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial RecorderErrorCode Start(RecorderHandle handle);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_pause", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial RecorderErrorCode Pause(RecorderHandle handle);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_commit", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial RecorderErrorCode Commit(RecorderHandle handle);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_cancel", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial RecorderErrorCode Cancel(RecorderHandle handle);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_get_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial RecorderErrorCode GetState(RecorderHandle handle, out RecorderState state);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_set_sound_stream_info", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial RecorderErrorCode SetAudioStreamPolicy(RecorderHandle handle, AudioStreamPolicyHandle streamInfoHandle);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_get_device_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial RecorderErrorCode GetDeviceState(RecorderType type, out RecorderDeviceState state);
    }

    internal partial class RecorderHandle : SafeHandle
    {
        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_destroy", StringMarshalling = StringMarshalling.Utf8)]
        private static partial RecorderErrorCode Destroy(IntPtr handle);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_cancel", StringMarshalling = StringMarshalling.Utf8)]
        private static partial RecorderErrorCode Cancel(IntPtr handle);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_unprepare", StringMarshalling = StringMarshalling.Utf8)]
        private static partial RecorderErrorCode Unprepare(IntPtr handle);

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