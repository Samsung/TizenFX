using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.WindowSystem.Shell
{
    internal static partial class Interop
    {
        internal static partial class TaskbarService
        {
            const string lib = "libtzsh_taskbar_service.so.0";

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_taskbar_service_create")]
            internal static extern SafeHandles.TaskbarServiceHandle Create(SafeHandles.TizenShellHandle tzsh, uint win);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_taskbar_service_destroy")]
            internal static extern int Destroy(IntPtr taskbarService);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_taskbar_service_place_type_set")]
            internal static extern int SetPlaceType(SafeHandles.TaskbarServiceHandle taskbarService, TaskbarPosition placeType);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "tzsh_taskbar_service_size_set")]
            internal static extern int SetSize(SafeHandles.TaskbarServiceHandle taskbarService, int width, int height);
        }
    }
}
