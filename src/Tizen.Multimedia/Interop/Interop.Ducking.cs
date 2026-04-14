/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
        internal static partial class AudioDucking
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void DuckingStateChangedCallback(IntPtr ducking, bool isDucked, IntPtr userData);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_create_stream_ducking", CallingConvention = CallingConvention.Cdecl)]
        internal static extern AudioManagerError Create(AudioStreamType targetType,
                DuckingStateChangedCallback callback, IntPtr userData, out AudioDuckingHandle ducking);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_destroy_stream_ducking")]
            internal static partial AudioManagerError Destroy(IntPtr ducking);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_is_ducked")]
            internal static partial AudioManagerError IsDucked(AudioDuckingHandle ducking, [MarshalAs(UnmanagedType.U1)] out bool isDucked);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_activate_ducking")]
            internal static partial AudioManagerError Activate(AudioDuckingHandle ducking, uint duration, double ratio);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_deactivate_ducking")]
            internal static partial AudioManagerError Deactivate(AudioDuckingHandle ducking);
        }
    }
}
