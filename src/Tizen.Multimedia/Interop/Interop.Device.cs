using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class Device
    {

        /// Return Type: int
        ///device_mask: sound_device_mask_e->Anonymous_3fc56cd6_e4da_41dd_9811_f92df21c2418
        ///device_list: sound_device_list_h*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_current_device_list")]
        internal static extern int GetCurrentDeviceList(AudioDeviceOptions deviceMask, out IntPtr deviceList);


        /// Return Type: int
        ///device_list: sound_device_list_h->void*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_free_device_list")]
        internal static extern int FreeDeviceList(IntPtr deviceList);


        /// Return Type: int
        ///device_list: sound_device_list_h->void*
        ///device: sound_device_h*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_next_device")]
        internal static extern int GetNextDevice(IntPtr deviceList, out IntPtr device);


        /// Return Type: int
        ///device_list: sound_device_list_h->void*
        ///device: sound_device_h*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_prev_device")]
        internal static extern int GetPrevDevice(IntPtr deviceList, out IntPtr device);


        /// Return Type: int
        ///device: sound_device_h->void*
        ///type: sound_device_type_e*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_type")]
        internal static extern int GetDeviceType(IntPtr device, out AudioDeviceType type);


        /// Return Type: int
        ///device: sound_device_h->void*
        ///io_direction: sound_device_io_direction_e*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_io_direction")]
        internal static extern int GetDeviceIoDirection(IntPtr device, out AudioDeviceIoDirection ioDirection);


        /// Return Type: int
        ///device: sound_device_h->void*
        ///id: int*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_id")]
        internal static extern int GetDeviceId(IntPtr device, out int id);


        /// Return Type: int
        ///device: sound_device_h->void*
        ///name: char**
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_name")]
        internal static extern int GetDeviceName(IntPtr device, out IntPtr name);


        /// Return Type: int
        ///device: sound_device_h->void*
        ///state: sound_device_state_e*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_device_state")]
        internal static extern int GetDeviceState(IntPtr device, out AudioDeviceState state);


        /// Return Type: int
        ///device_mask: sound_device_mask_e->Anonymous_3fc56cd6_e4da_41dd_9811_f92df21c2418
        ///callback: sound_device_connected_cb
        ///user_data: void*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_set_device_connected_cb")]
        internal static extern int SetDeviceConnectedCallback(AudioDeviceOptions deviceMask, SoundDeviceConnectedCallback callback, IntPtr userData);


        /// Return Type: int
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_unset_device_connected_cb")]
        internal static extern int UnsetDeviceConnectedCallback();


        /// Return Type: int
        ///device_mask: sound_deviceMask_e->Anonymous_3fc56cd6_e4da_41dd_9811_f92df21c2418
        ///callback: sound_device_information_changed_cb
        ///user_data: void*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_set_device_information_changed_cb")]
        internal static extern int SetDeviceInformationChangedCallback(AudioDeviceOptions deviceMask, SoundDeviceInformationChangedCallback callback, IntPtr userData);


        /// Return Type: int
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_unset_device_information_changed_cb")]
        internal static extern int UnsetDeviceInformationChangedCallback();


        internal static bool GetDeviceId()
        {
            throw new NotImplementedException();
        }
    }

}
