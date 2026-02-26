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

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_create_stream_information", CallingConvention = CallingConvention.Cdecl)]
        internal static extern AudioManagerError Create(AudioStreamType streamType,
                FocusStateChangedCallback callback, IntPtr userData, out AudioStreamPolicyHandle streamInfo);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_destroy_stream_information", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError Destroy(IntPtr streamInfo);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_add_device_id_for_stream_routing", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError AddDeviceForStreamRouting(
                AudioStreamPolicyHandle streamInfo, int deviceId);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_remove_device_id_for_stream_routing", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError RemoveDeviceForStreamRouting(
                AudioStreamPolicyHandle streamInfo, int device);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_apply_stream_routing", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError ApplyStreamRouting(AudioStreamPolicyHandle streamInfo);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_set_stream_preferred_device_id", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError SetPreferredDevice(AudioStreamPolicyHandle streamInfo, AudioDeviceIoDirection direction, int deviceId);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_stream_preferred_device", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError GetPreferredDevice(AudioStreamPolicyHandle streamInfo, out int inDeviceId, out int outDeviceId);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_acquire_focus", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError AcquireFocus(AudioStreamPolicyHandle streamInfo,
                AudioStreamFocusOptions focusMask, AudioStreamBehaviors audioStreamBehavior, string extraInfo);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_release_focus", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError ReleaseFocus(AudioStreamPolicyHandle streamInfo,
                AudioStreamFocusOptions focusMask, AudioStreamBehaviors audioStreamBehavior, string extraInfo);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_focus_state", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetFocusState(AudioStreamPolicyHandle streamInfo,
                out AudioStreamFocusState stateForPlayback, out AudioStreamFocusState stateForRecording);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_set_focus_reacquisition", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError SetFocusReacquisition(AudioStreamPolicyHandle streamInfo,
                [MarshalAs(UnmanagedType.U1)] bool enable);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_focus_reacquisition", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError GetFocusReacquisition(AudioStreamPolicyHandle streamInfo,
                [MarshalAs(UnmanagedType.U1)] out bool enabled);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_sound_type", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError GetSoundType(AudioStreamPolicyHandle streamInfo,
                out AudioVolumeType soundType);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_add_focus_state_watch_cb", CallingConvention = CallingConvention.Cdecl)]
            internal static extern AudioManagerError AddFocusStateWatchCallback(AudioStreamFocusOptions focusMask,
                FocusStateWatchCallback callback, IntPtr userData, out int id);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_remove_focus_state_watch_cb", CallingConvention = CallingConvention.Cdecl)]
            internal static extern int RemoveFocusStateWatchCallback(int id);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_is_stream_on_device_by_id", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError IsStreamOnDevice(AudioStreamPolicyHandle streamInfo, int deviceId,
                [MarshalAs(UnmanagedType.U1)] out bool isOn);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_set_effect_method_with_reference_by_id", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError SetSoundEffectWithReference(AudioStreamPolicyHandle streamInfo,
                SoundEffectWithReferenceNative effect, int deviceId);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_effect_method_with_reference", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError GetSoundEffectWithReference(AudioStreamPolicyHandle streamInfo,
                out SoundEffectWithReferenceNative effect, out int deviceId);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_set_effect_method", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError SetSoundEffect(AudioStreamPolicyHandle streamInfo, int effect);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_effect_method", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError GetSoundEffect(AudioStreamPolicyHandle streamInfo, out int effect);
        }
    }
}

