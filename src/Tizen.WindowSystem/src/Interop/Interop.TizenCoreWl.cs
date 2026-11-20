using System;
using System.Runtime.InteropServices;

namespace Tizen.WindowSystem
{
    internal static partial class Interop
    {
        internal static partial class TizenCoreWl
        {
            const string lib = "libtizen-core-wl.so.0";
            const string glib = "libglib-2.0.so.0";
            const string waylandClient = "libwayland-client.so.0";

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

            [DllImport(lib, EntryPoint = "tizen_core_wl_window_get_native_surface")]
            internal static extern int WindowGetNativeSurface(IntPtr window, out IntPtr surface);

            [DllImport(waylandClient, EntryPoint = "wl_proxy_get_id")]
            internal static extern uint ProxyGetId(IntPtr proxy);

            [DllImport(lib, EntryPoint = "tizen_core_wl_window_get_display")]
            internal static extern int WindowGetDisplay(IntPtr window, out IntPtr display);

            [DllImport(lib, EntryPoint = "tizen_core_wl_display_get_output_device_list")]
            internal static extern int DisplayGetOutputDeviceList(IntPtr display, out IntPtr list);

            [DllImport(lib, EntryPoint = "tizen_core_wl_output_device_get_geometry")]
            internal static extern int OutputDeviceGetGeometry(IntPtr output, out int width, out int height);

            [DllImport(glib, EntryPoint = "g_list_free")]
            internal static extern void GListFree(IntPtr list);

            [StructLayout(LayoutKind.Sequential)]
            internal struct GList
            {
                internal IntPtr Data;
                internal IntPtr Next;
                internal IntPtr Previous;
            }

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
