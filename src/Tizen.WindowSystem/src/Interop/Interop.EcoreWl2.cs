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
        }
    }
}
