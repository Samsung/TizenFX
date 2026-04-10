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
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RecorderErrorCallback(RecorderError error, RecorderState current, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RecordingLimitReachedCallback(RecordingLimitType type, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RecordingProgressCallback(ulong elapsedTime, ulong fileSize, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void AudioStreamCallback(IntPtr stream, int size, AudioSampleType type, int channel,
            uint timeStamp, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void StatechangedCallback(RecorderState previous, RecorderState current, bool byPolicy, IntPtr userData);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_set_error_cb")]
        internal static partial RecorderErrorCode SetErrorCallback(RecorderHandle handle, RecorderErrorCallback callback,
            IntPtr userData);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_unset_error_cb")]
        internal static partial RecorderErrorCode UnsetErrorCallback(RecorderHandle handle);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_set_state_changed_cb")]
        internal static partial RecorderErrorCode SetStateChangedCallback(RecorderHandle handle,
            StatechangedCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_unset_state_changed_cb")]
        internal static partial RecorderErrorCode UnsetStateChangedCallback(RecorderHandle handle);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_set_recording_status_cb")]
        internal static partial RecorderErrorCode SetRecordingProgressCallback(RecorderHandle handle,
            RecordingProgressCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_unset_recording_status_cb")]
        internal static partial RecorderErrorCode UnsetRecordingProgressCallback(RecorderHandle handle);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_set_audio_stream_cb")]
        internal static partial RecorderErrorCode SetAudioStreamCallback(RecorderHandle handle,
            AudioStreamCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_unset_audio_stream_cb")]
        internal static partial RecorderErrorCode UnsetAudioStreamCallback(RecorderHandle handle);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_set_recording_limit_reached_cb")]
        internal static partial RecorderErrorCode SetLimitReachedCallback(RecorderHandle handle,
            RecordingLimitReachedCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_unset_recording_limit_reached_cb")]
        internal static partial RecorderErrorCode UnsetLimitReachedCallback(RecorderHandle handle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MuxedStreamCallback(IntPtr stream, int size, ulong offset, IntPtr userData);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_set_muxed_stream_cb")]
        internal static partial RecorderErrorCode SetMuxedStreamCallback(RecorderHandle handle,
            MuxedStreamCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_unset_muxed_stream_cb")]
        internal static partial RecorderErrorCode UnsetMuxedStreamCallback(RecorderHandle handle);


        #region InterruptCallback
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InterruptedCallback(RecorderPolicy policy, RecorderState previous,
                RecorderState current, IntPtr userData);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_set_interrupted_cb")]
        internal static partial RecorderErrorCode SetInterruptedCallback(RecorderHandle handle,
            InterruptedCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_unset_interrupted_cb")]
        internal static partial RecorderErrorCode UnsetInterruptedCallback(RecorderHandle handle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InterruptStartedCallback(RecorderPolicy policy, RecorderState state,
                IntPtr userData);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_set_interrupt_started_cb")]
        internal static partial RecorderErrorCode SetInterruptStartedCallback(RecorderHandle handle,
            InterruptStartedCallback callback, IntPtr userData = default(IntPtr));

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_unset_interrupt_started_cb")]
        internal static partial RecorderErrorCode UnsetInterruptStartedCallback(RecorderHandle handle);

        #endregion


        #region DeviceStateChangedCallback
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DeviceStateChangedCallback(RecorderType type, RecorderDeviceState state, IntPtr userData);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_add_device_state_changed_cb")]
        internal static partial RecorderErrorCode AddDeviceStateChangedCallback(DeviceStateChangedCallback callback,
            IntPtr userData, out int id);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_remove_device_state_changed_cb")]
        internal static partial RecorderErrorCode RemoveDeviceStateChangedCallback(int id);
        #endregion
    }
}
