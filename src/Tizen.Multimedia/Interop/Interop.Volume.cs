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
        internal static partial class AudioVolume
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void VolumeChangedCallback(AudioVolumeType type, uint volume, IntPtr userData);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_max_volume")]
            internal static extern AudioManagerError GetMaxVolume(AudioVolumeType type, out int max);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_set_volume")]
            internal static extern AudioManagerError SetVolume(AudioVolumeType type, int volume);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_volume")]
            internal static extern AudioManagerError GetVolume(AudioVolumeType type, out int volume);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_current_sound_type")]
            internal static extern AudioManagerError GetCurrentSoundType(out AudioVolumeType type);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_add_volume_changed_cb")]
            internal static extern AudioManagerError AddVolumeChangedCallback(VolumeChangedCallback callback,
                IntPtr userData, out int id);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_remove_volume_changed_cb")]
            internal static extern AudioManagerError RemoveVolumeChangedCallback(int id);
        }
    }
}