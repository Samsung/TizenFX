/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
        internal static partial class AudioDevice
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void ConnectionChangedCallback(IntPtr device, [MarshalAs(UnmanagedType.U1)] bool isConnected, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void RunningChangedCallback(IntPtr device, [MarshalAs(UnmanagedType.U1)] bool isRunning, IntPtr userData);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_list", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError GetDeviceList(AudioDeviceOptions deviceMask, out IntPtr deviceList);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_free_device_list", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError FreeDeviceList(IntPtr deviceList);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_next_device", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError GetNextDevice(IntPtr deviceList, out IntPtr device);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_type", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetDeviceType(IntPtr device, out AudioDeviceType type);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_io_direction", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetDeviceIoDirection(IntPtr device, out AudioDeviceIoDirection ioDirection);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_id", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetDeviceId(IntPtr device, out int id);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_name", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetDeviceName(IntPtr device, out IntPtr name);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_is_device_running_by_id", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError IsDeviceRunning(int deviceId, [MarshalAs(UnmanagedType.U1)] out bool isRunning);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_supported_sample_formats_by_id", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError GetSupportedSampleFormats(int deviceId, out IntPtr formats, out uint numberOfElements);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_set_sample_format_by_id", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError SetSampleFormat(int deviceId, AudioSampleFormat format);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_sample_format_by_id", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError GetSampleFormat(int deviceId, out AudioSampleFormat format);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_supported_sample_rates_by_id", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError GetSupportedSampleRates(int deviceId, out IntPtr rates, out uint numberOfElements);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_set_sample_rate_by_id", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError SetSampleRate(int deviceId, uint rate);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_sample_rate_by_id", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError GetSampleRate(int deviceId, out uint rate);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_set_avoid_resampling_by_id", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError SetAvoidResampling(int deviceId, [MarshalAs(UnmanagedType.U1)] bool enable);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_avoid_resampling_by_id", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError GetAvoidResampling(int deviceId, [MarshalAs(UnmanagedType.U1)] out bool enabled);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_set_media_stream_only_by_id", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError SetMediaStreamOnly(int deviceId, [MarshalAs(UnmanagedType.U1)] bool enable);

            [LibraryImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_media_stream_only_by_id", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial AudioManagerError GetMediaStreamOnly(int deviceId, [MarshalAs(UnmanagedType.U1)] out bool enabled);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_add_device_connection_changed_cb", CallingConvention = CallingConvention.Cdecl)]
            internal static extern AudioManagerError AddDeviceConnectionChangedCallback(
                AudioDeviceOptions deviceMask, ConnectionChangedCallback callback, IntPtr userData, out int id);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_remove_device_connection_changed_cb", CallingConvention = CallingConvention.Cdecl)]
            internal static extern AudioManagerError RemoveDeviceConnectionChangedCallback(int id);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_add_device_running_changed_cb", CallingConvention = CallingConvention.Cdecl)]
            internal static extern AudioManagerError AddDeviceRunningChangedCallback(AudioDeviceOptions deviceMask,
                RunningChangedCallback callback, IntPtr userData, out int id);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_remove_device_running_changed_cb", CallingConvention = CallingConvention.Cdecl)]
            internal static extern AudioManagerError RemoveDeviceRunningChangedCallback(int id);
        }
    }
}
