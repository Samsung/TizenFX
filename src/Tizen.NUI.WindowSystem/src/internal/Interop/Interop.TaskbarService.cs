using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.WindowSystem.Shell
{
    internal static partial class Interop
    {
        internal static partial class TaskbarService
        {
            const string lib = "libtzsh_taskbar_service.so.0";

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_taskbar_service_create")]
            internal static extern IntPtr Create(IntPtr tzsh, uint win);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_taskbar_service_destroy")]
            internal static extern int Destroy(IntPtr taskbarService);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_taskbar_service_place_type_set")]
            internal static extern int SetPlaceType(IntPtr taskbarService, int placeType);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_taskbar_service_size_set")]
            internal static extern int SetSize(IntPtr taskbarService, uint width, uint height);
        }
    }
}
