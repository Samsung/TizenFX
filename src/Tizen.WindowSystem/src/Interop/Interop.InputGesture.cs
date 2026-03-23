using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

namespace Tizen.WindowSystem
{
    internal static partial class Interop
    {
        internal static class InputGesture
        {
            const string lib = "libcapi-ui-efl-util.so.0";

            internal static string LogTag = "Tizen.NUI.WindowSystem";

            [DllImport(lib, EntryPoint = "efl_util_gesture_initialize")]
            internal static extern SafeHandles.InputGestureHandle Initialize();

            [DllImport(lib, EntryPoint = "efl_util_gesture_deinitialize")]
            internal static extern ErrorCode Deinitialize(IntPtr gestureHandler);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_swipe_new")]
            internal static extern IntPtr EdgeSwipeNew(SafeHandles.InputGestureHandle gestureHandler, int fingers, GestureEdge edge);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_swipe_free")]
            internal static extern ErrorCode EdgeSwipeFree(SafeHandles.InputGestureHandle gestureHandler, IntPtr gestureData);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_swipe_size_set")]
            internal static extern ErrorCode EdgeSwipeSizeSet(IntPtr gestureData, GestureEdgeSize edgeSize, int startPoint, int endPoint);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_drag_new")]
            internal static extern IntPtr EdgeDragNew(SafeHandles.InputGestureHandle gestureHandler, int fingers, GestureEdge edge);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_drag_free")]
            internal static extern ErrorCode EdgeDragFree(SafeHandles.InputGestureHandle gestureHandler, IntPtr gestureData);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_drag_size_set")]
            internal static extern ErrorCode EdgeDragSizeSet(IntPtr gestureData, GestureEdgeSize edgeSize, int startPoint, int endPoint);

            [DllImport(lib, EntryPoint = "efl_util_gesture_tap_new")]
            internal static extern IntPtr TapNew(SafeHandles.InputGestureHandle gestureHandler, int fingers, int repeats);

            [DllImport(lib, EntryPoint = "efl_util_gesture_tap_free")]
            internal static extern ErrorCode TapFree(SafeHandles.InputGestureHandle gestureHandler, IntPtr gestureData);

            [DllImport(lib, EntryPoint = "efl_util_gesture_palm_cover_new")]
            internal static extern IntPtr PalmCoverNew(SafeHandles.InputGestureHandle gestureHandler);

            [DllImport(lib, EntryPoint = "efl_util_gesture_palm_cover_free")]
            internal static extern ErrorCode PalmCoverFree(SafeHandles.InputGestureHandle gestureHandler, IntPtr gestureData);

            [DllImport(lib, EntryPoint = "efl_util_gesture_grab")]
            internal static extern ErrorCode GestureGrab(SafeHandles.InputGestureHandle gestureHandler, IntPtr gestureData);

            [DllImport(lib, EntryPoint = "efl_util_gesture_grab_mode_set")]
            internal static extern ErrorCode SetGestureGrabMode(SafeHandles.InputGestureHandle gestureHandler, IntPtr gestureData, GestureGrabMode mode);

            [DllImport(lib, EntryPoint = "efl_util_gesture_ungrab")]
            internal static extern ErrorCode GestureUngrab(SafeHandles.InputGestureHandle gestureHandler, IntPtr gestureData);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_swipe_cb_set")]
            internal static extern ErrorCode SetEdgeSwipeCb(SafeHandles.InputGestureHandle gestureHandler, EdgeSwipeCb cbFunc, IntPtr usergestureData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void EdgeSwipeCb(IntPtr usergestureData, GestureState mode, int fingers, int sx, int sy, GestureEdge edge);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_drag_cb_set")]
            internal static extern ErrorCode SetEdgeDragCb(SafeHandles.InputGestureHandle gestureHandler, EdgeDragCb cbFunc, IntPtr usergestureData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void EdgeDragCb(IntPtr usergestureData, GestureState mode, int fingers, int cx, int cy, GestureEdge edge);

            [DllImport(lib, EntryPoint = "efl_util_gesture_tap_cb_set")]
            internal static extern ErrorCode SetTapCb(SafeHandles.InputGestureHandle gestureHandler, TapCb cbFunc, IntPtr usergestureData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void TapCb(IntPtr usergestureData, GestureState mode, int fingers, int repeats);

            [DllImport(lib, EntryPoint = "efl_util_gesture_palm_cover_cb_set")]
            internal static extern ErrorCode SetPalmCoverCb(SafeHandles.InputGestureHandle gestureHandler, PalmCoverCb cbFunc, IntPtr usergestureData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void PalmCoverCb(IntPtr usergestureData, GestureState mode, int duration, int cx, int cy, int size, double pressure);

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
