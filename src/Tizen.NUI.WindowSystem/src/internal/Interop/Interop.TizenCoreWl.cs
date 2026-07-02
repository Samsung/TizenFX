using System;
using System.Runtime.InteropServices;

namespace Tizen.NUI.WindowSystem
{
    internal static partial class Interop
    {
        internal static partial class TizenCoreWl
        {
            const string lib = "libtizen-core-wl.so.0";

            [DllImport(lib, EntryPoint = "tizen_core_wl_init")]
            internal static extern int Init();

            [DllImport(lib, EntryPoint = "tizen_core_wl_shutdown")]
            internal static extern int Shutdown();

            [DllImport(lib, EntryPoint = "tizen_core_wl_display_create")]
            internal static extern int DisplayCreate(out IntPtr display);

            [DllImport(lib, EntryPoint = "tizen_core_wl_display_connect")]
            internal static extern int DisplayConnect(IntPtr display, string name);

            [DllImport(lib, EntryPoint = "tizen_core_wl_display_disconnect")]
            internal static extern int DisplayDisconnect(IntPtr display);

            [DllImport(lib, EntryPoint = "tizen_core_wl_display_destroy")]
            internal static extern int DisplayDestroy(IntPtr display);

            internal enum ErrorCode
            {
                None = Tizen.Internals.Errors.ErrorCode.None,
                InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
                OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
                NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
                PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
                NotConnected = -0x02000000 | 0xA000 | 0x01,
                NoResourceAvailable = -0x02000000 | 0xA000 | 0x02,
            }
        }
    }
}
