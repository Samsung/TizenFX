using System;
using System.Runtime.InteropServices;
using Tizen.Multimedia;

internal static partial class Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SoundDeviceConnectedCallback(IntPtr device, bool isConnected, IntPtr userData);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SoundDeviceInformationChangedCallback(IntPtr device, AudioDeviceProperty changedInfo, IntPtr userData);

    internal static partial class AudioDevice
    {
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_current_device_list")]
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

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_set_device_connected_cb")]
        internal static extern int SetDeviceConnectedCallback(AudioDeviceOptions deviceMask, SoundDeviceConnectedCallback callback, IntPtr userData);

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_unset_device_connected_cb")]
        internal static extern int UnsetDeviceConnectedCallback();

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_set_device_information_changed_cb")]
        internal static extern int SetDeviceInformationChangedCallback(AudioDeviceOptions deviceMask, SoundDeviceInformationChangedCallback callback, IntPtr userData);

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_unset_device_information_changed_cb")]
        internal static extern int UnsetDeviceInformationChangedCallback();
    }
}