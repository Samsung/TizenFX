using System;
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
    internal static partial class Interop
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SoundDeviceConnectionChangedCallback(IntPtr device, bool isConnected, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SoundDeviceStateChangedCallback(IntPtr device, AudioDeviceState changedState, IntPtr userData);

        internal static partial class AudioDevice
        {
            [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_list")]
            internal static extern int GetCurrentDeviceList(AudioDeviceOptions deviceMask, out IntPtr deviceList);

            [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_free_device_list")]
            internal static extern int FreeDeviceList(IntPtr deviceList);

            [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_next_device")]
            internal static extern int GetNextDevice(IntPtr deviceList, out IntPtr device);

            [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_type")]
            internal static extern int GetDeviceType(IntPtr device, out AudioDeviceType type);

            [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_io_direction")]
            internal static extern int GetDeviceIoDirection(IntPtr device, out AudioDeviceIoDirection ioDirection);

            [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_id")]
            internal static extern int GetDeviceId(IntPtr device, out int id);

            [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_name")]
            internal static extern int GetDeviceName(IntPtr device, out IntPtr name);

            [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_state")]
            internal static extern int GetDeviceState(IntPtr device, out AudioDeviceState state);

            [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_add_device_connection_changed_cb")]
            internal static extern int AddDeviceConnectionChangedCallback(AudioDeviceOptions deviceMask, SoundDeviceConnectionChangedCallback callback, IntPtr userData, out int id);

            [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_remove_device_connection_changed_cb")]
            internal static extern int RemoveDeviceConnectionChangedCallback(int id);

            [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_add_device_state_changed_cb")]
            internal static extern int AddDeviceStateChangedCallback(AudioDeviceOptions deviceMask, SoundDeviceStateChangedCallback callback, IntPtr userData, out int id);

            [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_remove_device_state_changed_cb")]
            internal static extern int RemoveDeviceStateChangedCallback(int id);
        }
    }
}