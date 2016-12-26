using System;
using System.Runtime.InteropServices;
using Tizen.Multimedia;


internal static partial class Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SoundStreamFocusStateChangedCallback(IntPtr streamInfo, AudioStreamFocusOptions focusMask, AudioStreamFocusState focusState, int reason, int audioStreamBehavior, string extraInfo, IntPtr userData);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SoundStreamFocusStateWatchCallback(int id, AudioStreamFocusOptions focusMask, AudioStreamFocusState focusState, AudioStreamFocusChangedReason reason, string extraInfo, IntPtr userData);

    internal static partial class AudioStreamPolicy
    {
        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_create_stream_information")]
        internal static extern int CreateStreamInformation(int streamType, SoundStreamFocusStateChangedCallback callback, IntPtr userData, out IntPtr streamInfo);

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_destroy_stream_information")]
        internal static extern int DestroyStreamInformation(IntPtr streamInfo);

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_add_device_for_stream_routing")]
        internal static extern int AddDeviceForStreamRouting(IntPtr streamInfo, IntPtr device);

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_remove_device_for_stream_routing")]
        internal static extern int RemoveDeviceForStreamRouting(IntPtr streamInfo, IntPtr device);

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_apply_stream_routing")]
        internal static extern int ApplyStreamRouting(IntPtr streamInfo);

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_acquire_focus")]
        internal static extern int AcquireFocus(IntPtr streamInfo, AudioStreamFocusOptions focusMask, int audioStreamBehavior, string extraInfo);

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_release_focus")]
        internal static extern int ReleaseFocus(IntPtr streamInfo, AudioStreamFocusOptions focusMask, int audioStreamBehavior, string extraInfo);

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_focus_state")]
        internal static extern int GetFocusState(IntPtr streaInfo, out AudioStreamFocusState stateForPlayback, out AudioStreamFocusState stateForRecording);

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_set_focus_reacquisition")]
        internal static extern int SetFocusReacquisition(IntPtr streamInfo, bool enable);

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_focus_reacquisition")]
        internal static extern int GetFocusReacquisition(IntPtr streamInfo, out bool enabled);

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_get_sound_type")]
        internal static extern int GetSoundType(IntPtr streamInfo, out AudioVolumeType soundType);

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_add_focus_state_watch_cb")]
        internal static extern int AddFocusStateWatchCallback(AudioStreamFocusOptions focusMask, SoundStreamFocusStateWatchCallback callback, IntPtr userData, out int id);

        [DllImportAttribute(Libraries.SoundManager, EntryPoint = "sound_manager_remove_focus_state_watch_cb")]
        internal static extern int RemoveFocusStateWatchCallback(int id);
    }
}
