using System;
using System.Runtime.InteropServices;
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class TonePlayer
    {
        [DllImport(Libraries.TonePlayer, EntryPoint = "tone_player_start_new")]
        internal static extern int Start(ToneType tone, IntPtr streamInfoHandle, int durationMs, out int playerId);

        [DllImport(Libraries.TonePlayer, EntryPoint = "tone_player_stop")]
        internal static extern int Stop(int PlayerId);
    }
}
