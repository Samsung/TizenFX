using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.WindowSystem.Shell
{
    internal static partial class Interop
    {
        internal static partial class TizenShellRegion
        {
            const string lib = "libtzsh_common.so.0";

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_region_create")]
            internal static extern SafeHandles.ShellRegionHandle Create(SafeHandles.TizenShellHandle tzsh);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_region_destroy")]
            internal static extern int Destroy(IntPtr region);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_region_add")]
            internal static extern int Add(SafeHandles.ShellRegionHandle region, int x, int y, int w, int h);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_region_subtract")]
            internal static extern int Subtract(SafeHandles.ShellRegionHandle region, int x, int y, int w, int h);
        }
    }
}
