using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Tizen.Multimedia;


internal static partial class Interop
{
    internal static partial class StreamPolicy
    {

        /// Return Type: int
        ///stream_type: sound_stream_type_e->Anonymous_49a61343_50ca_4b20_a0ee_fc8affa00d5f
        ///callback: sound_stream_focus_state_changed_cb
        ///user_data: void*
        ///stream_info: sound_stream_info_h*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_create_stream_information")]
        internal static extern int CreateStreamInformation(int streamType, SoundStreamFocusStateChangedCallback callback, IntPtr userData, out IntPtr streamInfo);


        /// Return Type: int
        ///stream_info: sound_stream_info_h->sound_stream_info_s*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_destroy_stream_information")]
        internal static extern int DestroyStreamInformation(IntPtr streamInfo);


        /// Return Type: int
        ///stream_info: sound_stream_info_h->sound_stream_info_s*
        ///device: sound_device_h->void*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_add_device_for_stream_routing")]
        internal static extern int AddDeviceForStreamRouting(IntPtr streamInfo, IntPtr device);


        /// Return Type: int
        ///stream_info: sound_stream_info_h->sound_stream_info_s*
        ///device: sound_device_h->void*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_remove_device_for_stream_routing")]
        internal static extern int RemoveDeviceForStreamRouting(IntPtr streamInfo, IntPtr device);


        /// Return Type: int
        ///stream_info: sound_stream_info_h->sound_stream_info_s*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_apply_stream_routing")]
        internal static extern int ApplyStreamRouting(IntPtr streamInfo);


        /// Return Type: int
        ///stream_info: sound_stream_info_h->sound_stream_info_s*
        ///focus_mask: sound_stream_focus_mask_e->Anonymous_b96ff9c9_3dc0_44b0_afcf_9f99535c2308
        ///extra_info: char*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_acquire_focus")]
        internal static extern int AcquireFocus(IntPtr streamInfo, AudioStreamFocusOptions focusMask, string extraInfo);


        /// Return Type: int
        ///stream_info: sound_stream_info_h->sound_stream_info_s*
        ///focus_mask: sound_stream_focus_mask_e->Anonymous_b96ff9c9_3dc0_44b0_afcf_9f99535c2308
        ///extra_info: char*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_release_focus")]
        internal static extern int ReleaseFocus(IntPtr streamInfo, AudioStreamFocusOptions focusMask, string extraInfo);

        /// Return Type: int
        ///stream_info: sound_stream_info_h->sound_stream_info_s*
        ///state_for_playback: sound_stream_focus_state_e*
        ///state_for_recording: sound_stream_focus_state_e*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_focus_state")]
        internal static extern int GetFocusState(IntPtr streaInfo, out AudioStreamFocusState stateForPlayback, out AudioStreamFocusState stateForRecording);


        /// Return Type: int
        ///stream_info: sound_stream_info_h->sound_stream_info_s*
        ///enable: boolean
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_set_focus_reacquisition")]
        internal static extern int SetFocusReacquisition(IntPtr streamInfo, bool enable);


        /// Return Type: int
        ///stream_info: sound_stream_info_h->sound_stream_info_s*
        ///enabled: boolean*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_focus_reacquisition")]
        internal static extern int GetFocusReacquisition(IntPtr streamInfo, out bool enabled);


        /// Return Type: int
        ///stream_info: sound_stream_info_h->sound_stream_info_s*
        ///sound_type: sound_type_e*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_sound_type")]
        internal static extern int GetSoundType(IntPtr streamInfo, out AudioType soundType);


        /// Return Type: int
        ///focus_mask: sound_stream_focus_mask_e->Anonymous_55404683_3978_4094_9b40_a0e0d5e93af7
        ///callback: sound_stream_focus_state_watch_cb
        ///user_data: void*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_set_focus_state_watch_cb")]
        internal static extern int SetFocusStateWatchCallback(AudioStreamFocusOptions focusMask, SoundStreamFocusStateWatchCallback callback, IntPtr userData);


        /// Return Type: int
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_unset_focus_state_watch_cb")]
        internal static extern int UnsetFocusStateWatchCallback();
    }

}
