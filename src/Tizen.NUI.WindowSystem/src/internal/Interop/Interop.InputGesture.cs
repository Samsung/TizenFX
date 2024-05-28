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
            internal static extern SafeGestureHandle Init();

            [DllImport(lib, EntryPoint = "efl_util_gesture_deinitialize")]
            internal static extern ErrorCode Deinit(SafeGestureHandle gestureHandle);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_swipe_new")]
            internal static extern SafeGestureDataHandle EdgeSwipeNew(SafeGestureHandle gestureHandle, int fingers, int edge);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_swipe_free")]
            internal static extern ErrorCode EdgeSwipeFree(SafeGestureHandle gestureHandle, SafeGestureDataHandle data);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_swipe_size_set")]
            internal static extern ErrorCode EdgeSwipeSizeSet(SafeGestureDataHandle data, int edgeSize, int startPoint, int endPoint);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_drag_new")]
            internal static extern SafeGestureDataHandle EdgeDragNew(SafeGestureHandle gestureHandle, int fingers, int edge);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_drag_free")]
            internal static extern ErrorCode EdgeDragFree(SafeGestureHandle gestureHandle, SafeGestureDataHandle data);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_drag_size_set")]
            internal static extern ErrorCode EdgeDragSizeSet(SafeGestureDataHandle data, int edgeSize, int startPoint, int endPoint);

            [DllImport(lib, EntryPoint = "efl_util_gesture_tap_new")]
            internal static extern SafeGestureDataHandle TapNew(SafeGestureHandle gestureHandle, int fingers, int repeats);

            [DllImport(lib, EntryPoint = "efl_util_gesture_tap_free")]
            internal static extern ErrorCode TapFree(SafeGestureHandle gestureHandle, SafeGestureDataHandle data);

            [DllImport(lib, EntryPoint = "efl_util_gesture_palm_cover_new")]
            internal static extern SafeGestureDataHandle PalmCoverNew(SafeGestureHandle gestureHandle);

            [DllImport(lib, EntryPoint = "efl_util_gesture_palm_cover_free")]
            internal static extern ErrorCode PalmCoverFree(SafeGestureHandle gestureHandle, SafeGestureDataHandle data);

            [DllImport(lib, EntryPoint = "efl_util_gesture_grab")]
            internal static extern ErrorCode GestureGrab(SafeGestureHandle gestureHandle, SafeGestureDataHandle data);

            [DllImport(lib, EntryPoint = "efl_util_gesture_ungrab")]
            internal static extern ErrorCode GestureUngrab(SafeGestureHandle gestureHandle, SafeGestureDataHandle data);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_swipe_cb_set")]
            internal static extern ErrorCode SetEdgeSwipeCb(SafeGestureHandle gestureHandle, SafeGestureDataHandle data, EdgeSwipeCb cbFunc, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void EdgeSwipeCb(IntPtr userData, int mode, int fingers, int sx, int sy, int edge);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_drag_cb_set")]
            internal static extern ErrorCode SetEdgeDragCb(SafeGestureHandle gestureHandle, SafeGestureDataHandle data, EdgeDragCb cbFunc, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void EdgeDragCb(IntPtr userData, int mode, int fingers, int cx, int cy, int edge);

            [DllImport(lib, EntryPoint = "efl_util_gesture_tap_cb_set")]
            internal static extern ErrorCode SetTapCb(SafeGestureHandle gestureHandle, SafeGestureDataHandle data, TapCb cbFunc, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void TapCb(IntPtr userData, int mode, int fingers, int repeats);

            [DllImport(lib, EntryPoint = "efl_util_gesture_palm_cover_cb_set")]
            internal static extern ErrorCode SetPalmCoverCb(SafeGestureHandle gestureHandle, SafeGestureDataHandle data, PalmCoverCb cbFunc, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void PalmCoverCb(IntPtr userData, int mode, int duration, int cx, int cy, int size, double pressure);

            //Enumeration of gesture modes
            internal enum GestureMode
            {
                None = 0x0,
                Begin,
                Update,
                End,
                Done,
            };

            //Enumeration of gesture edges
            internal enum GestureEdge
            {
                None = 0x0,
                Top,
                Right,
                Bottom,
                Left,
            };

            //Enumeration of gesture edge sizes
            internal enum GestureEdgeSize
            {
                None = 0x0,
                Full,
                Partial,
            };

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