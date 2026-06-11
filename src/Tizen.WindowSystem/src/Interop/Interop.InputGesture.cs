using System;
using System.Runtime.InteropServices;

namespace Tizen.WindowSystem
{
    internal static partial class Interop
    {
        internal static class InputGesture
        {
            const string lib = "libtizen-core-wl.so.0";

            internal static string LogTag = "Tizen.WindowSystem";

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_create")]
            internal static extern int Create(IntPtr display, out IntPtr gesture);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_destroy")]
            internal static extern int Destroy(IntPtr gesture);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_edge_swipe_new")]
            internal static extern int EdgeSwipeNew(SafeHandles.InputGestureHandle gesture, uint fingers, GestureEdge edge, out IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_edge_swipe_free")]
            internal static extern int EdgeSwipeFree(SafeHandles.InputGestureHandle gesture, IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_edge_swipe_size_set")]
            internal static extern int EdgeSwipeSizeSet(IntPtr data, GestureEdgeSize edgeSize, uint startPoint, uint endPoint);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_edge_drag_new")]
            internal static extern int EdgeDragNew(SafeHandles.InputGestureHandle gesture, uint fingers, GestureEdge edge, out IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_edge_drag_free")]
            internal static extern int EdgeDragFree(SafeHandles.InputGestureHandle gesture, IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_edge_drag_size_set")]
            internal static extern int EdgeDragSizeSet(IntPtr data, GestureEdgeSize edgeSize, uint startPoint, uint endPoint);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_tap_new")]
            internal static extern int TapNew(SafeHandles.InputGestureHandle gesture, uint fingers, uint repeats, out IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_tap_free")]
            internal static extern int TapFree(SafeHandles.InputGestureHandle gesture, IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_palm_cover_new")]
            internal static extern int PalmCoverNew(SafeHandles.InputGestureHandle gesture, out IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_palm_cover_free")]
            internal static extern int PalmCoverFree(SafeHandles.InputGestureHandle gesture, IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_grab")]
            internal static extern int GestureGrab(SafeHandles.InputGestureHandle gesture, IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_grab_mode_set")]
            internal static extern int SetGestureGrabMode(SafeHandles.InputGestureHandle gesture, IntPtr data, GestureGrabMode mode);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_ungrab")]
            internal static extern int GestureUngrab(SafeHandles.InputGestureHandle gesture, IntPtr data);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_edge_swipe_cb_set")]
            internal static extern int SetEdgeSwipeCb(SafeHandles.InputGestureHandle gesture, EdgeSwipeCb cbFunc, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void EdgeSwipeCb(IntPtr userData, GestureState mode, int fingers, int sx, int sy, GestureEdge edge);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_edge_drag_cb_set")]
            internal static extern int SetEdgeDragCb(SafeHandles.InputGestureHandle gesture, EdgeDragCb cbFunc, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void EdgeDragCb(IntPtr userData, GestureState mode, int fingers, int cx, int cy, GestureEdge edge);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_tap_cb_set")]
            internal static extern int SetTapCb(SafeHandles.InputGestureHandle gesture, TapCb cbFunc, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void TapCb(IntPtr userData, GestureState mode, int fingers, int repeats);

            [DllImport(lib, EntryPoint = "tizen_core_wl_gesture_palm_cover_cb_set")]
            internal static extern int SetPalmCoverCb(SafeHandles.InputGestureHandle gesture, PalmCoverCb cbFunc, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void PalmCoverCb(IntPtr userData, GestureState mode, int duration, int cx, int cy, int size, double pressure);

            internal enum ErrorCode
            {
                None = Tizen.Internals.Errors.ErrorCode.None,                            // Successful
                OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,              // Out of memory
                InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,    // Invalid parameter
                NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,            // NOT supported
                PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,    // Permission denied
                NotConnected = -0x02000000 | 0xA000 | 0x01,                              // No connection to display server
            };
        }
    }
}
