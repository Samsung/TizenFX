using System;
using System.Runtime.InteropServices;
using Tizen.Multimedia;

internal static partial class Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SoundManagerVolumeChangedCallback(AudioVolumeType type, uint volume, IntPtr userData);

    internal static partial class AudioVolume
    {
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_max_volume")]
        internal static extern int GetMaxVolume(AudioVolumeType type, out int max);

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_set_volume")]
        internal static extern int SetVolume(AudioVolumeType type, int volume);

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_volume")]
        internal static extern int GetVolume(AudioVolumeType type, out int volume);

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_add_volume_changed_cb")]
        internal static extern int AddVolumeChangedCallback(SoundManagerVolumeChangedCallback callback, IntPtr userData, out int id);

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_remove_volume_changed_cb")]
        internal static extern int RemoveVolumeChangedCallback(int id);
    }
}
