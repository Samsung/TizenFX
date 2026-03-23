using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.WindowSystem
{
    internal static partial class Interop
    {
        internal static partial class EcoreWl2
        {
            const string lib = "libecore_wl2.so.1";

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "ecore_wl2_window_id_get")]
            internal static extern int GetWindowId(IntPtr win);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "ecore_wl2_window_display_get")]
            internal static extern IntPtr GetDisplay(IntPtr win);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "ecore_wl2_display_screen_size_get")]
            internal static extern void GetScreenSize(IntPtr display, out int w, out int h);
        }
    }
}
