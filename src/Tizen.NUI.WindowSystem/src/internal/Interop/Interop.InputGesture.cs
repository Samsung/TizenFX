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
            internal static extern SafeGestureHandle Initialize();

            [DllImport(lib, EntryPoint = "efl_util_gesture_deinitialize")]
            internal static extern ErrorCode Deinitialize(SafeGestureHandle gestureHandle);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_swipe_new")]
            internal static extern SafeGestureHandle EdgeSwipeNew(SafeGestureHandle gestureHandle, int fingers, int edge);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_swipe_free")]
            internal static extern ErrorCode EdgeSwipeFree(SafeGestureHandle gestureHandle, SafeGestureHandle data);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_swipe_size_set")]
            internal static extern ErrorCode EdgeSwipeSizeSet(SafeGestureHandle data, int edgeSize, int startPoint, int endPoint);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_drag_new")]
            internal static extern SafeGestureHandle EdgeDragNew(SafeGestureHandle gestureHandle, int fingers, int edge);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_drag_free")]
            internal static extern ErrorCode EdgeDragFree(SafeGestureHandle gestureHandle, SafeGestureHandle data);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_drag_size_set")]
            internal static extern ErrorCode EdgeDragSizeSet(SafeGestureHandle data, int edgeSize, int startPoint, int endPoint);

            [DllImport(lib, EntryPoint = "efl_util_gesture_tap_new")]
            internal static extern SafeGestureHandle TapNew(SafeGestureHandle gestureHandle, int fingers, int repeats);

            [DllImport(lib, EntryPoint = "efl_util_gesture_tap_free")]
            internal static extern ErrorCode TapFree(SafeGestureHandle gestureHandle, SafeGestureHandle data);

            [DllImport(lib, EntryPoint = "efl_util_gesture_palm_cover_new")]
            internal static extern SafeGestureHandle PalmCoverNew(SafeGestureHandle gestureHandle);

            [DllImport(lib, EntryPoint = "efl_util_gesture_palm_cover_free")]
            internal static extern ErrorCode PalmCoverFree(SafeGestureHandle gestureHandle, SafeGestureHandle data);

            [DllImport(lib, EntryPoint = "efl_util_gesture_grab")]
            internal static extern ErrorCode GestureGrab(SafeGestureHandle gestureHandle, SafeGestureHandle data);

            [DllImport(lib, EntryPoint = "efl_util_gesture_ungrab")]
            internal static extern ErrorCode GestureUngrab(SafeGestureHandle gestureHandle, SafeGestureHandle data);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_swipe_cb_set")]
            internal static extern ErrorCode SetEdgeSwipeCb(SafeGestureHandle gestureHandle, SafeGestureHandle data, EdgeSwipeCb cbFunc, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void EdgeSwipeCb(IntPtr userData, int mode, int fingers, int sx, int sy, int edge);

            [DllImport(lib, EntryPoint = "efl_util_gesture_edge_drag_cb_set")]
            internal static extern ErrorCode SetEdgeDragCb(SafeGestureHandle gestureHandle, SafeGestureHandle data, EdgeDragCb cbFunc, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void EdgeDragCb(IntPtr userData, int mode, int fingers, int cx, int cy, int edge);

            [DllImport(lib, EntryPoint = "efl_util_gesture_tap_cb_set")]
            internal static extern ErrorCode SetTapCb(SafeGestureHandle gestureHandle, SafeGestureHandle data, TapCb cbFunc, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void TapCb(IntPtr userData, int mode, int fingers, int repeats);

            [DllImport(lib, EntryPoint = "efl_util_gesture_palm_cover_cb_set")]
            internal static extern ErrorCode SetPalmCoverCb(SafeGestureHandle gestureHandle, SafeGestureHandle data, PalmCoverCb cbFunc, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void PalmCoverCb(IntPtr userData, int mode, int duration, int cx, int cy, int size, double pressure);

            internal enum ErrorCode
            {
                None = Tizen.Internals.Errors.ErrorCode.None,                            // Successful
                OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,              // Out of memory
                InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,    // Invalid parameter
                InvalidOperation = Tizen.Internals.Errors.ErrorCode.InvalidOperation,    // Invalid operation
                PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,    // Permission denied
                NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,            // NOT supported
            };

            /// <summary>
            /// Represents a wrapper class for a unmanaged gesture handle.
            /// </summary>
            public sealed class SafeGestureHandle : SafeHandle
            {
                /// <summary>
                /// Initializes a new instance of the SafeGestureHandle class.
                /// </summary>
                public SafeGestureHandle(IntPtr handle)
                    : base(IntPtr.Zero, true)
                {
                    SetHandle(handle);
                }
                /// <summary>
                /// Initializes a new instance of the SafeGestureHandle class.
                /// </summary>
                public SafeGestureHandle()
                    : base(IntPtr.Zero, true)
                {
                }
                /// <summary>
                /// Gets a value that indicates whether the handle is invalid.
                /// </summary>
                public override bool IsInvalid
                {
                    get { return this.handle == IntPtr.Zero; }
                }
                /// <summary>
                /// When overridden in a derived class, executes the code required to free the handle.
                /// </summary>
                /// <returns>true if the handle is released successfully</returns>
                protected override bool ReleaseHandle()
                {
                    this.SetHandle(IntPtr.Zero);
                    return true;
                }
            }
        }
    }
}