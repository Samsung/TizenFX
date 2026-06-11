using System;
using System.Runtime.InteropServices;

namespace Tizen.NUI.WindowSystem
{
    internal static partial class Interop
    {
        internal static class InputGesture
        {
            const string lib = "libtizen-core-wl.so.0";

            internal static string LogTag = "Tizen.NUI.WindowSystem";

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_create")]
            internal static extern int Create(IntPtr display, out IntPtr gesture);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_destroy")]
            internal static extern int Destroy(IntPtr gesture);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_edge_swipe_new")]
            internal static extern int EdgeSwipeNew(IntPtr gesture, uint fingers, int edge, out IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_edge_swipe_free")]
            internal static extern int EdgeSwipeFree(IntPtr gesture, IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_edge_swipe_size_set")]
            internal static extern int EdgeSwipeSizeSet(IntPtr data, int edgeSize, uint startPoint, uint endPoint);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_edge_drag_new")]
            internal static extern int EdgeDragNew(IntPtr gesture, uint fingers, int edge, out IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_edge_drag_free")]
            internal static extern int EdgeDragFree(IntPtr gesture, IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_edge_drag_size_set")]
            internal static extern int EdgeDragSizeSet(IntPtr data, int edgeSize, uint startPoint, uint endPoint);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_tap_new")]
            internal static extern int TapNew(IntPtr gesture, uint fingers, uint repeats, out IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_tap_free")]
            internal static extern int TapFree(IntPtr gesture, IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_palm_cover_new")]
            internal static extern int PalmCoverNew(IntPtr gesture, out IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_palm_cover_free")]
            internal static extern int PalmCoverFree(IntPtr gesture, IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_grab")]
            internal static extern int GestureGrab(IntPtr gesture, IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_grab_mode_set")]
            internal static extern int SetGestureGrabMode(IntPtr gesture, IntPtr data, int mode);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_ungrab")]
            internal static extern int GestureUngrab(IntPtr gesture, IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_edge_swipe_cb_set")]
            internal static extern int SetEdgeSwipeCb(IntPtr gesture, EdgeSwipeCb cbFunc, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void EdgeSwipeCb(IntPtr userData, int mode, int fingers, int sx, int sy, int edge);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_edge_drag_cb_set")]
            internal static extern int SetEdgeDragCb(IntPtr gesture, EdgeDragCb cbFunc, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void EdgeDragCb(IntPtr userData, int mode, int fingers, int cx, int cy, int edge);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_tap_cb_set")]
            internal static extern int SetTapCb(IntPtr gesture, TapCb cbFunc, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void TapCb(IntPtr userData, int mode, int fingers, int repeats);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_palm_cover_cb_set")]
            internal static extern int SetPalmCoverCb(IntPtr gesture, PalmCoverCb cbFunc, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void PalmCoverCb(IntPtr userData, int mode, int duration, int cx, int cy, int size, double pressure);

            internal enum ErrorCode
            {
                None = Tizen.Internals.Errors.ErrorCode.None,                            // Successful
                OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,              // Out of memory
                InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,    // Invalid parameter
                NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,            // NOT supported
                PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,    // Permission denied
                NotConnected = 0xA000 | 0x01,                                            // No connection to display server
            };
        }
    }
}
