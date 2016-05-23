using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Tizen.Multimedia;

internal static partial class Interop
    {
        /// Return Type: void
        ///type: sound_type_e->Anonymous_ad886fd4_d691_40b5_a17d_55fbb2f73a7f
        ///volume: unsigned int
        ///user_data: void*
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SoundManagerVolumeChangedCallback(AudioType type, uint volume, IntPtr userData);

        /// Return Type: void
        ///stream_info: sound_stream_info_h->sound_stream_info_s*
        ///reason: sound_stream_focus_change_reason_e->Anonymous_c962a37c_4a0d_40b4_b464_d69f56fabe32
        ///extra_info: char*
        ///user_data: void*
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SoundStreamFocusStateChangedCallback(IntPtr streamInfo, int reason, string extraInfo, IntPtr userData);

        /// Return Type: void
        ///focus_mask: sound_stream_focus_mask_e->Anonymous_b96ff9c9_3dc0_44b0_afcf_9f99535c2308
        ///focus_state: sound_stream_focus_state_e->Anonymous_cb2f9ad7_42d5_489f_a995_fa2abdccad4d
        ///reason: sound_stream_focus_change_reason_e->Anonymous_c962a37c_4a0d_40b4_b464_d69f56fabe32
        ///extra_info: char*
        ///user_data: void*
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]    
        internal delegate void SoundStreamFocusStateWatchCallback(AudioStreamFocusOptions focusMask, AudioStreamFocusState focusState, AudioStreamFocusChangedReason reason, string extraInfo, IntPtr userData);

        /// Return Type: void
        ///device: sound_device_h->void*
        ///is_connected: boolean
        ///user_data: void*
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]  
        internal delegate void SoundDeviceConnectedCallback(IntPtr device, bool isConnected, IntPtr userData);

        /// Return Type: void
        ///device: sound_device_h->void*
        ///changed_info: sound_device_changed_info_e->Anonymous_040524ee_1ef4_468d_86e5_7152316377f6
        ///user_data: void*
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SoundDeviceInformationChangedCallback(IntPtr device, AudioDeviceProperty changedInfo, IntPtr userData);

    
}
