using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.WindowSystem.Shell
{
    internal static partial class Interop
    {
        internal static partial class ScreensaverService
        {
            const string lib = "libtzsh_screensaver_service.so.0";

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_screensaver_service_create")]
            internal static extern SafeHandles.ScreensaverServiceHandle Create(SafeHandles.TizenShellHandle tzsh, uint win);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_screensaver_service_destroy")]
            internal static extern int Destroy(IntPtr ScreensaverService);
        }
    }
}
