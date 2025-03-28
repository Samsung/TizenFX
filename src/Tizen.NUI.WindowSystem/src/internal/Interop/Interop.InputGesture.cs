using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.WindowSystem
{
    internal static partial class Interop
    {
        internal static class InputGesture
        {
            const string lib = "libcapi-ui-efl-util.so.0";

            internal static string LogTag = "Tizen.NUI.WindowSystem";

            [DllImport(lib, EntryPoint = "efl_util_gesture_initialize")]
            internal static extern IntPtr Initialize();

            [DllImport(lib, EntryPoint = "efl_util_gesture_deinitialize")]
            internal static extern ErrorCode Deinitialize(IntPtr gestureHandler);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_swipe_new")]
            internal static extern IntPtr EdgeSwipeNew(IntPtr gestureHandler, int fingers, int edge);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_swipe_free")]
            internal static extern ErrorCode EdgeSwipeFree(IntPtr gestureHandler, IntPtr gestureData);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_swipe_size_set")]
            internal static extern ErrorCode EdgeSwipeSizeSet(IntPtr gestureData, int edgeSize, int startPoint, int endPoint);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_drag_new")]
            internal static extern IntPtr EdgeDragNew(IntPtr gestureHandler, int fingers, int edge);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_drag_free")]
            internal static extern ErrorCode EdgeDragFree(IntPtr gestureHandler, IntPtr gestureData);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_drag_size_set")]
            internal static extern ErrorCode EdgeDragSizeSet(IntPtr gestureData, int edgeSize, int startPoint, int endPoint);

            [DllImport(lib, EntryPoint = "efl_util_gesture_tap_new")]
            internal static extern IntPtr TapNew(IntPtr gestureHandler, int fingers, int repeats);

            [DllImport(lib, EntryPoint = "efl_util_gesture_tap_free")]
            internal static extern ErrorCode TapFree(IntPtr gestureHandler, IntPtr gestureData);

            [DllImport(lib, EntryPoint = "efl_util_gesture_palm_cover_new")]
            internal static extern IntPtr PalmCoverNew(IntPtr gestureHandler);

            [DllImport(lib, EntryPoint = "efl_util_gesture_palm_cover_free")]
            internal static extern ErrorCode PalmCoverFree(IntPtr gestureHandler, IntPtr gestureData);

            [DllImport(lib, EntryPoint = "efl_util_gesture_grab")]
            internal static extern ErrorCode GestureGrab(IntPtr gestureHandler, IntPtr gestureData);

            [DllImport(lib, EntryPoint = "efl_util_gesture_grab_mode_set")]
            internal static extern ErrorCode SetGestureGrabMode(IntPtr gestureHandler, IntPtr gestureData, int mode);

            [DllImport(lib, EntryPoint = "efl_util_gesture_ungrab")]
            internal static extern ErrorCode GestureUngrab(IntPtr gestureHandler, IntPtr gestureData);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_swipe_cb_set")]
            internal static extern ErrorCode SetEdgeSwipeCb(IntPtr gestureHandler, EdgeSwipeCb cbFunc, IntPtr usergestureData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void EdgeSwipeCb(IntPtr usergestureData, int mode, int fingers, int sx, int sy, int edge);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_drag_cb_set")]
            internal static extern ErrorCode SetEdgeDragCb(IntPtr gestureHandler, EdgeDragCb cbFunc, IntPtr usergestureData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void EdgeDragCb(IntPtr usergestureData, int mode, int fingers, int cx, int cy, int edge);

            [DllImport(lib, EntryPoint = "efl_util_gesture_tap_cb_set")]
            internal static extern ErrorCode SetTapCb(IntPtr gestureHandler, TapCb cbFunc, IntPtr usergestureData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void TapCb(IntPtr usergestureData, int mode, int fingers, int repeats);

            [DllImport(lib, EntryPoint = "efl_util_gesture_palm_cover_cb_set")]
            internal static extern ErrorCode SetPalmCoverCb(IntPtr gestureHandler, PalmCoverCb cbFunc, IntPtr usergestureData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void PalmCoverCb(IntPtr usergestureData, int mode, int duration, int cx, int cy, int size, double pressure);

            internal enum ErrorCode
            {
                None = Tizen.Internals.Errors.ErrorCode.None,                            // Successful
                OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,              // Out of memory
                InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,    // Invalid parameter
                InvalidOperation = Tizen.Internals.Errors.ErrorCode.InvalidOperation,    // Invalid operation
                PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,    // Permission denied
                NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,            // NOT supported
            };
        }
    }
}
