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
        internal static partial class AudioDevice
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void ConnectionChangedCallback(IntPtr device, bool isConnected, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void StateChangedCallback(IntPtr device, AudioDeviceState changedState, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void RunningChangedCallback(IntPtr device, bool isRunning, IntPtr userData);


            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_list")]
            internal static extern AudioManagerError GetDeviceList(AudioDeviceOptions deviceMask, out IntPtr deviceList);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_free_device_list")]
            internal static extern AudioManagerError FreeDeviceList(IntPtr deviceList);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_next_device")]
            internal static extern AudioManagerError GetNextDevice(IntPtr deviceList, out IntPtr device);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_type")]
            internal static extern int GetDeviceType(IntPtr device, out AudioDeviceType type);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_io_direction")]
            internal static extern int GetDeviceIoDirection(IntPtr device, out AudioDeviceIoDirection ioDirection);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_id")]
            internal static extern int GetDeviceId(IntPtr device, out int id);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_name")]
            internal static extern int GetDeviceName(IntPtr device, out IntPtr name);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_state_by_id")]
            internal static extern AudioManagerError GetDeviceState(int deviceId, out AudioDeviceState state);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_is_device_running_by_id")]
            internal static extern AudioManagerError IsDeviceRunning(int deviceId, out bool isRunning);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_supported_sample_formats_by_id")]
            internal static extern AudioManagerError GetSupportedSampleFormats(int deviceId, out IntPtr formats, out uint numOfElems);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_set_sample_format_by_id")]
            internal static extern AudioManagerError SetSampleFormat(int deviceId, AudioSampleFormat format);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_sample_format_by_id")]
            internal static extern AudioManagerError GetSampleFormat(int deviceId, out AudioSampleFormat format);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_supported_sample_rates_by_id")]
            internal static extern AudioManagerError GetSupportedSampleRates(int deviceId, out IntPtr rates, out uint numOfElems);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_set_sample_rate_by_id")]
            internal static extern AudioManagerError SetSampleRate(int deviceId, uint rate);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_sample_rate_by_id")]
            internal static extern AudioManagerError GetSampleRate(int deviceId, out uint rate);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_set_avoid_resampling_by_id")]
            internal static extern AudioManagerError SetAvoidResampling(int deviceId, bool enable);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_avoid_resampling_by_id")]
            internal static extern AudioManagerError GetAvoidResampling(int deviceId, out bool enabled);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_set_media_stream_only_by_id")]
            internal static extern AudioManagerError SetMediaStreamOnly(int deviceId, bool enable);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_get_media_stream_only_by_id")]
            internal static extern AudioManagerError GetMediaStreamOnly(int deviceId, out bool enabled);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_add_device_connection_changed_cb")]
            internal static extern AudioManagerError AddDeviceConnectionChangedCallback(
                AudioDeviceOptions deviceMask, ConnectionChangedCallback callback, IntPtr userData, out int id);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_remove_device_connection_changed_cb")]
            internal static extern AudioManagerError RemoveDeviceConnectionChangedCallback(int id);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_add_device_state_changed_cb")]
            internal static extern AudioManagerError AddDeviceStateChangedCallback(AudioDeviceOptions deviceMask,
                StateChangedCallback callback, IntPtr userData, out int id);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_remove_device_state_changed_cb")]
            internal static extern AudioManagerError RemoveDeviceStateChangedCallback(int id);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_add_device_running_changed_cb")]
            internal static extern AudioManagerError AddDeviceRunningChangedCallback(AudioDeviceOptions deviceMask,
                RunningChangedCallback callback, IntPtr userData, out int id);

            [DllImport(Libraries.SoundManager, EntryPoint = "sound_manager_remove_device_running_changed_cb")]
            internal static extern AudioManagerError RemoveDeviceRunningChangedCallback(int id);
        }
    }
}
