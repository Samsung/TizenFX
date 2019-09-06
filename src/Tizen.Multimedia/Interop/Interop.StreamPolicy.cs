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

namespace Tizen.Multimedia
{
    internal static partial class Interop
    {
        internal static partial class AudioStreamPolicy
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void FocusStateChangedCallback(IntPtr streamInfo, AudioStreamFocusOptions focusMask,
                AudioStreamFocusState focusState, AudioStreamFocusChangedReason reason,
                AudioStreamBehaviors audioStreamBehavior, string extraInfo, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void FocusStateWatchCallback(int id, AudioStreamFocusOptions focusMask,
                AudioStreamFocusState focusState, AudioStreamFocusChangedReason reason, string extraInfo,
                IntPtr userData);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_create_stream_information")]
            internal static extern AudioManagerError Create(AudioStreamType streamType,
                FocusStateChangedCallback callback, IntPtr userData, out AudioStreamPolicyHandle streamInfo);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_destroy_stream_information")]
            internal static extern AudioManagerError Destroy(IntPtr streamInfo);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_add_device_id_for_stream_routing")]
            internal static extern AudioManagerError AddDeviceForStreamRouting(
                AudioStreamPolicyHandle streamInfo, int deviceId);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_remove_device_id_for_stream_routing")]
            internal static extern AudioManagerError RemoveDeviceForStreamRouting(
                AudioStreamPolicyHandle streamInfo, int device);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_apply_stream_routing")]
            internal static extern AudioManagerError ApplyStreamRouting(AudioStreamPolicyHandle streamInfo);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_set_stream_preferred_device_id")]
            internal static extern AudioManagerError SetPreferredDevice(AudioStreamPolicyHandle streamInfo, AudioDeviceIoDirection direction, int deviceId);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_stream_preferred_device")]
            internal static extern AudioManagerError GetPreferredDevice(AudioStreamPolicyHandle streamInfo, out int inDeviceId, out int outDeviceId);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_acquire_focus")]
            internal static extern AudioManagerError AcquireFocus(AudioStreamPolicyHandle streamInfo,
                AudioStreamFocusOptions focusMask, AudioStreamBehaviors audioStreamBehavior, string extraInfo);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_release_focus")]
            internal static extern AudioManagerError ReleaseFocus(AudioStreamPolicyHandle streamInfo,
                AudioStreamFocusOptions focusMask, AudioStreamBehaviors audioStreamBehavior, string extraInfo);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_focus_state")]
            internal static extern int GetFocusState(AudioStreamPolicyHandle streamInfo,
                out AudioStreamFocusState stateForPlayback, out AudioStreamFocusState stateForRecording);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_set_focus_reacquisition")]
            internal static extern AudioManagerError SetFocusReacquisition(AudioStreamPolicyHandle streamInfo,
                bool enable);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_focus_reacquisition")]
            internal static extern AudioManagerError GetFocusReacquisition(AudioStreamPolicyHandle streamInfo,
                out bool enabled);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_sound_type")]
            internal static extern AudioManagerError GetSoundType(AudioStreamPolicyHandle streamInfo,
                out AudioVolumeType soundType);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_add_focus_state_watch_cb")]
            internal static extern AudioManagerError AddFocusStateWatchCallback(AudioStreamFocusOptions focusMask,
                FocusStateWatchCallback callback, IntPtr userData, out int id);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_remove_focus_state_watch_cb")]
            internal static extern int RemoveFocusStateWatchCallback(int id);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_is_stream_on_device_by_id")]
            internal static extern AudioManagerError IsStreamOnDevice(AudioStreamPolicyHandle streamInfo, int deviceId,
                out bool isOn);
        }
    }
}