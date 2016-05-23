using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class Volume
    {
        ///VolumeController

        /// Return Type: int
        ///type: sound_type_e->Anonymous_ad886fd4_d691_40b5_a17d_55fbb2f73a7f
        ///param1: int*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_max_volume")]
        internal static extern int GetMaxVolume(AudioType type, out int max);


        /// Return Type: int
        ///type: sound_type_e->Anonymous_ad886fd4_d691_40b5_a17d_55fbb2f73a7f
        ///volume: int
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_set_volume")]
        internal static extern int SetVolume(AudioType type, int volume);


        /// Return Type: int
        ///type: sound_type_e->Anonymous_ad886fd4_d691_40b5_a17d_55fbb2f73a7f
        ///volume: int*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_volume")]
        internal static extern int GetVolume(AudioType type, out int volume);


        /// Return Type: int
        ///type: sound_type_e->Anonymous_ad886fd4_d691_40b5_a17d_55fbb2f73a7f
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_set_current_sound_type")]
        internal static extern int SetCurrentSoundType(AudioType type);


        /// Return Type: int
        ///type: sound_type_e*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_current_sound_type")]
        internal static extern int GetCurrentSoundType(out AudioType type);


        /// Return Type: int
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_unset_current_sound_type")]
        internal static extern int UnsetCurrentType();


        /// Return Type: int
        ///callback: sound_manager_volume_changed_cb
        ///user_data: void*
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_set_volume_changed_cb")]
        internal static extern int SetVolumeChangedCallback(SoundManagerVolumeChangedCallback callback, IntPtr userData);


        /// Return Type: int
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_unset_volume_changed_cb")]
        internal static extern int UnsetVolumeChangedCallback();
    }

}
