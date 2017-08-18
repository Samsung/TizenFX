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
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RecorderErrorCallback(RecorderErrorCode error, RecorderState current, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InterruptedCallback(RecorderPolicy policy, RecorderState previous, RecorderState current, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RecordingLimitReachedCallback(RecordingLimitType type, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RecordingProgressCallback(ulong elapsedTime, ulong fileSize, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void AudioStreamCallback(IntPtr stream, int size, AudioSampleType type, int channel, uint timeStamp, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void StatechangedCallback(RecorderState previous, RecorderState current, bool byPolicy, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MuxedStreamCallback(IntPtr stream, int size, ulong offset, IntPtr userData);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_create_audiorecorder")]
        internal static extern RecorderError Create(out IntPtr handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_create_videorecorder")]
        internal static extern RecorderError CreateVideo(IntPtr cameraHandle, out IntPtr handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_destroy")]
        internal static extern RecorderError Destroy(IntPtr handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_prepare")]
        internal static extern RecorderError Prepare(IntPtr handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_unprepare")]
        internal static extern RecorderError Unprepare(IntPtr handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_start")]
        internal static extern RecorderError Start(IntPtr handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_pause")]
        internal static extern RecorderError Pause(IntPtr handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_commit")]
        internal static extern RecorderError Commit(IntPtr handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_cancel")]
        internal static extern RecorderError Cancel(IntPtr handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_state")]
        internal static extern RecorderError GetState(IntPtr handle, out RecorderState state);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_sound_stream_info")]
        internal static extern RecorderError SetAudioStreamPolicy(IntPtr handle, AudioStreamPolicyHandle streamInfoHandle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_error_cb")]
        internal static extern RecorderError SetErrorCallback(IntPtr handle, RecorderErrorCallback callback, IntPtr userData);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_unset_error_cb")]
        internal static extern RecorderError UnsetErrorCallback(IntPtr handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_interrupted_cb")]
        internal static extern RecorderError SetInterruptedCallback(IntPtr handle, InterruptedCallback callback, IntPtr userData);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_unset_interrupted_cb")]
        internal static extern RecorderError UnsetInterruptedCallback(IntPtr handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_state_changed_cb")]
        internal static extern RecorderError SetStateChangedCallback(IntPtr handle, StatechangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_unset_state_changed_cb")]
        internal static extern RecorderError UnsetStateChangedCallback(IntPtr handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_recording_status_cb")]
        internal static extern RecorderError SetRecordingProgressCallback(IntPtr handle, RecordingProgressCallback callback, IntPtr userData);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_unset_recording_status_cb")]
        internal static extern RecorderError UnsetRecordingProgressCallback(IntPtr handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_audio_stream_cb")]
        internal static extern RecorderError SetAudioStreamCallback(IntPtr handle, AudioStreamCallback callback, IntPtr userData);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_unset_audio_stream_cb")]
        internal static extern RecorderError UnsetAudioStreamCallback(IntPtr handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_recording_limit_reached_cb")]
        internal static extern RecorderError SetLimitReachedCallback(IntPtr handle, RecordingLimitReachedCallback callback, IntPtr userData);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_unset_recording_limit_reached_cb")]
        internal static extern RecorderError UnsetLimitReachedCallback(IntPtr handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_muxed_stream_cb")]
        internal static extern RecorderError SetMuxedStreamCallback(IntPtr handle, MuxedStreamCallback callback, IntPtr userData);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_unset_muxed_stream_cb")]
        internal static extern RecorderError UnsetMuxedStreamCallback(IntPtr handle);
    }
}