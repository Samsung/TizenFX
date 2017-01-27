using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class WavPlayer
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void WavPlayerCompletedCallback(int playerId, IntPtr userData);

        [DllImport(Libraries.WavPlayer, EntryPoint = "wav_player_start_new")]
        internal static extern int WavPlayerStart(string filePath, IntPtr streamInfoHandle, WavPlayerCompletedCallback completedCallback,
                                                     IntPtr userData, out int playerId);

        [DllImport(Libraries.WavPlayer, EntryPoint = "wav_player_stop")]
        internal static extern int WavPlayerStop(int PlayerId);
    }
}
