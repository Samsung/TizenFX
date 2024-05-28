/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using static Tizen.NUI.WindowSystem.Interop.InputGesture;

namespace Tizen.NUI.WindowSystem
{
    /// <summary>
    /// Enumeration of gesture modes.
    /// </summary>
    public enum GestureMode
    {
        /// <summary>
        /// None.
        /// </summary>
        None = Interop.InputGesture.GestureMode.None,

        /// <summary>
        /// Begin.
        /// </summary>
        Begin = Interop.InputGesture.GestureMode.Begin,

        /// <summary>
        /// Update.
        /// </summary>
        Update = Interop.InputGesture.GestureMode.Update,

        /// <summary>
        /// End.
        /// </summary>
        End = Interop.InputGesture.GestureMode.End,

        /// <summary>
        /// Done.
        /// </summary>
        Done = Interop.InputGesture.GestureMode.Done,
    }

    /// <summary>
    /// Enumeration of gesture edges.
    /// </summary>
    public enum GestureEdge
    {
        /// <summary>
        /// edge none.
        /// </summary>
        None = Interop.InputGesture.GestureEdge.None,

        /// <summary>
        /// edge top.
        /// </summary>
        Top = Interop.InputGesture.GestureEdge.Top,

        /// <summary>
        /// edge right.
        /// </summary>
        Right = Interop.InputGesture.GestureEdge.Right,

        /// <summary>
        /// edge bottom.
        /// </summary>
        Bottom = Interop.InputGesture.GestureEdge.Bottom,

        /// <summary>
        /// edge left.
        /// </summary>
        Left = Interop.InputGesture.GestureEdge.Left,
    }

    /// <summary>
    /// Enumeration of gesture edge sizes.
    /// /// </summary>
    public enum GestureEdgeSize
    {
        /// <summary>
        /// edge size none.
        /// </summary>
        None = Interop.InputGesture.GestureEdgeSize.None,

        /// <summary>
        /// edge size full.
        /// </summary>
        Full = Interop.InputGesture.GestureEdgeSize.Full,

        /// <summary>
        /// edge size partial.
        /// </summary>
        Partial = Interop.InputGesture.GestureEdgeSize.Partial,
    }

    /// <summary>
    /// Class for the Tizen Input Gesture.
    /// </summary>
    /// <privilege>
    /// http://tizen.org/privilege/gesturegrab
    /// </privilege>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class InputGesture : IDisposable
    {
        private SafeGestureHandle gestureHandle;

        private SafeGestureDataHandle edgeSwipeData;
        private SafeGestureDataHandle edgeDragData;
        private SafeGestureDataHandle tapData;
        private SafeGestureDataHandle palmCoverData;

        private bool disposed = false;

        private static event EventHandler<EdgeSwipeEventArgs> _edgeSwipeEventHandler;
        private static EdgeSwipeCb _edgeSwipeDelegate;

        private static event EventHandler<EdgeDragEventArgs> _edgeDragEventHandler;
        private static EdgeDragCb _edgeDragDelegate;


        private static event EventHandler<TapEventArgs> _tapEventHandler;
        private static TapCb _tapDelegate;

        private static event EventHandler<PalmCoverEventArgs> _palmCoverEventHandler;
        private static PalmCoverCb _palmCoverDelegate;


        internal void ErrorCodeThrow(Interop.InputGesture.ErrorCode error)
        {
            switch (error)
            {
                case Interop.InputGesture.ErrorCode.None :
                    return;
                case Interop.InputGesture.ErrorCode.OutOfMemory :
                    throw new Tizen.Applications.Exceptions.OutOfMemoryException("Out of Memory");
                case Interop.InputGesture.ErrorCode.InvalidParameter :
                    throw new ArgumentException("Invalid Parameter");
                case Interop.InputGesture.ErrorCode.PermissionDenied :
                    throw new Tizen.Applications.Exceptions.PermissionDeniedException("Permission denied");
                case Interop.InputGesture.ErrorCode.NotSupported :
                    throw new NotSupportedException("Not Supported");
                default :
                    throw new InvalidOperationException("Unknown Error");
            }
        }

        /// <summary>
        /// Creates a new InputGesture.
        /// </summary>
        public InputGesture()
        {
            gestureHandle = Interop.InputGesture.Init();
            Log.Debug(LogTag, "InputGesture Created");
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~InputGesture()
        {
            Dispose(false);
            Log.Debug(LogTag, "InputGesture Destroyed");
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                Interop.InputGesture.ErrorCode res = Interop.InputGesture.Deinit(gestureHandle);
                ErrorCodeThrow(res);

                if (disposing) {
                    gestureHandle?.Dispose();
                    gestureHandle = null;

                    edgeSwipeData?.Dispose();
                    edgeSwipeData = null;

                    edgeDragData?.Dispose();
                    edgeDragData = null;

                    tapData?.Dispose();
                    tapData = null;

                    palmCoverData?.Dispose();
                    palmCoverData = null;
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Generates a edge swipe gesture's grab info handle
        /// </summary>
        /// <param name="fingers"> The number of fingers </param>
        /// <param name="edge"> The position of edge</param>
        /// <returns> The edge swipe gesture data handle </returns>
        public SafeGestureDataHandle EdgeSwipeNew(int fingers, GestureEdge edge)
        {
            edgeSwipeData = Interop.InputGesture.EdgeSwipeNew(gestureHandle, fingers, (int)edge);
            Log.Debug(LogTag, "EdgeSwipeNew");
            return edgeSwipeData;
        }

        /// <summary>
        /// Frees a memory of edge swipe gesture's grab info handle
        /// </summary>
        /// <param name="data"> The edge swipe gesture data handle </param>
        public void EdgeSwipeFree(SafeGestureDataHandle data)
        {
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.EdgeSwipeFree(gestureHandle, data);
            ErrorCodeThrow(res);
        }

        /// <summary>
        /// Sets a specific size of edge for edge swipe gesture
        /// </summary>
        /// <param name="data"> The edge swipe gesture data handle </param>
        /// <param name="edgeSize"> The enum of gesture edge size </param>
        /// <param name="startPoint"> The start point of edge area </param>
        /// <param name="endPoint"> The end point of edge area</param>
        public void EdgeSwipeSizeSet(SafeGestureDataHandle data, GestureEdgeSize edgeSize, int startPoint, int endPoint)
        {
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.EdgeSwipeSizeSet(data, (int)edgeSize, startPoint, endPoint);
            ErrorCodeThrow(res);
        }

        /// <summary>
        /// Generates a edge drag gesture's grab info handle
        /// </summary>
        /// <param name="fingers"> The number of fingers </param>
        /// <param name="edge"> The position of edge</param>
        /// <returns> The edge drag gesture data handle </returns>
        public SafeGestureDataHandle EdgeDragNew(int fingers, GestureEdge edge)
        {
            edgeDragData = Interop.InputGesture.EdgeDragNew(gestureHandle, fingers, (int)edge);
            Log.Debug(LogTag, "EdgeDragNew");
            return edgeDragData;
        }

        /// <summary>
        /// Frees a memory of edge drag gesture's grab info handle
        /// </summary>
        /// <param name="data"> The edge drag gesture data handle </param>
        public void EdgeDrageFree(SafeGestureDataHandle data)
        {
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.EdgeDragFree(gestureHandle, data);
            ErrorCodeThrow(res);
        }

        /// <summary>
        /// Sets a specific size of edge for edge drag gesture
        /// </summary>
        /// <param name="data"> The edge drag gesture data handle </param>
        /// <param name="edgeSize"> The enum of gesture edge size </param>
        /// <param name="startPoint"> The start point of edge area </param>
        /// <param name="endPoint"> The end point of edge area</param>
        public void EdgeDragSizeSet(SafeGestureDataHandle data, GestureEdgeSize edgeSize, int startPoint, int endPoint)
        {
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.EdgeDragSizeSet(data, (int)edgeSize, startPoint, endPoint);
            ErrorCodeThrow(res);
        }

        /// <summary>
        /// Generates a tap gesture's grab info handle
        /// </summary>
        /// <param name="fingers"> The number of fingers </param>
        /// <param name="repeats"> The number of repeats</param>
        /// <returns> The tap gesture data handle </returns>
        public SafeGestureDataHandle TapNew(int fingers, int repeats)
        {
            tapData = Interop.InputGesture.TapNew(gestureHandle, fingers, repeats);
            Log.Debug(LogTag, "TapNew");
            return tapData;
        }

        /// <summary>
        /// Frees a memory of tap gesture's grab info handle
        /// </summary>
        /// <param name="data"> The tap gesture data handle </param>
        public void TapFree(SafeGestureDataHandle data)
        {
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.TapFree(gestureHandle, data);
            ErrorCodeThrow(res);
        }

        /// <summary>
        /// Generates a palm cover gesture's grab info handle
        /// </summary>
        /// <returns> The palm cover gesture data handle </returns>
        public SafeGestureDataHandle PalmCoverNew()
        {
            palmCoverData = Interop.InputGesture.PalmCoverNew(gestureHandle);
            Log.Debug(LogTag, "PalmCoverNew");
            return palmCoverData;
        }

        /// <summary>
        /// Frees a memory of palm cover gesture's grab info handle
        /// </summary>
        /// <param name="data"> The palm cover gesture data handle </param>
        public void PalmCoverFree(SafeGestureDataHandle data)
        {
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.PalmCoverFree(gestureHandle, data);
            ErrorCodeThrow(res);
        }

        /// <summary>
        /// Grabs a global gesture
        /// </summary>
        /// <param name="data">gesture data to grab</param>
        public void GestureGrab(SafeGestureDataHandle data)
        {
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.GestureGrab(gestureHandle, data);
            ErrorCodeThrow(res);
            Log.Debug(LogTag, "GestureGrab");
        }

        /// <summary>
        /// Ungrabs a global gesture.
        /// </summary>
        /// <param name="data">gesture data to ungrab</param>
        public void GestureUngrab(SafeGestureDataHandle data)
        {
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.GestureUngrab(gestureHandle, data);
            ErrorCodeThrow(res);
            Log.Debug(LogTag, "GestureUngrab");
        }

        /// <summary>
        /// Emits the event when the edge swipe event comes
        /// </summary>
        public event EventHandler<EdgeSwipeEventArgs> EdgeSwipeEventHandler
        {
            add
            {
                if (edgeSwipeData == null)
                {
                    Log.Info(LogTag, "EdgeSwipeData is NULL.");
                    return;
                }
                _edgeSwipeDelegate = (IntPtr userData, int mode,  int fingers, int sx, int sy, int edge) =>
                {
                    EdgeSwipeEventArgs args = new EdgeSwipeEventArgs(mode, fingers, sx, sy, edge);
                    Log.Info(LogTag, "EdgeSwipe Event received. mode: " + mode + ", fingers: " + fingers);
                    _edgeSwipeEventHandler?.Invoke(null, args);
                };
                Interop.InputGesture.ErrorCode error = Interop.InputGesture.SetEdgeSwipeCb(gestureHandle, edgeSwipeData, _edgeSwipeDelegate, IntPtr.Zero);
                if (error != Interop.InputGesture.ErrorCode.None)
                {
                    Log.Info(LogTag, "error" + error.ToString());
                }
                else
                {
                    _edgeSwipeEventHandler += value;
                }
            }
            remove
            {
                _edgeSwipeEventHandler -= value;
            }
        }

        /// <summary>
        /// Emits the event when the edge drag event comes
        /// </summary>
        public event EventHandler<EdgeDragEventArgs> EdgeDragEventHandler
        {
            add
            {
                if (edgeDragData == null)
                {
                    Log.Info(LogTag, "edgeDragData is NULL.");
                    return;
                }
                _edgeDragDelegate = (IntPtr userData, int mode,  int fingers, int cx, int cy, int edge) =>
                {
                    EdgeDragEventArgs args = new EdgeDragEventArgs(mode, fingers, cx, cy, edge);
                    Log.Info(LogTag, "EdgeDrag Event received. mode: " + mode + ", fingers: " + fingers);
                    _edgeDragEventHandler?.Invoke(null, args);
                };
                Interop.InputGesture.ErrorCode error = Interop.InputGesture.SetEdgeDragCb(gestureHandle, edgeDragData, _edgeDragDelegate, IntPtr.Zero);
                if (error != Interop.InputGesture.ErrorCode.None)
                {
                    Log.Info(LogTag, "error" + error.ToString());
                }
                else
                {
                    _edgeDragEventHandler += value;
                }
            }
            remove
            {
                _edgeDragEventHandler -= value;
            }
        }

        /// <summary>
        /// Emits the event when the tap event comes
        /// </summary>
        public event EventHandler<TapEventArgs> TapEventHandler
        {
            add
            {
                if (tapData == null)
                {
                    Log.Info(LogTag, "tapData is NULL.");
                    return;
                }
                _tapDelegate = (IntPtr userData, int mode,  int fingers, int repeats) =>
                {
                    TapEventArgs args = new TapEventArgs(mode, fingers, repeats);
                    Log.Info(LogTag, "Tap Event received. mode: " + mode + ", fingers: " + fingers + ", repeats: " + repeats);
                    _tapEventHandler?.Invoke(null, args);
                };
                Interop.InputGesture.ErrorCode error = Interop.InputGesture.SetTapCb(gestureHandle, tapData, _tapDelegate, IntPtr.Zero);
                if (error != Interop.InputGesture.ErrorCode.None)
                {
                    Log.Info(LogTag, "error" + error.ToString());
                }
                else
                {
                    _tapEventHandler += value;
                }
            }
            remove
            {
                _tapEventHandler -= value;
            }
        }
        /// <summary>
        /// Emits the event when the palm cover event comes
        /// </summary>
        public event EventHandler<PalmCoverEventArgs> PalmCoverEventHandler
        {
            add
            {
                if (palmCoverData == null)
                {
                    Log.Info(LogTag, "palmCoverData is NULL.");
                    return;
                }
                _palmCoverDelegate = (IntPtr userData, int mode,  int duration, int cx, int cy, int size, double pressure) =>
                {
                    PalmCoverEventArgs args = new PalmCoverEventArgs(mode, duration, cx, cy, size, pressure);
                    Log.Info(LogTag, "PalmCover Event received. mode: " + mode + ", duration: " + duration);
                    _palmCoverEventHandler?.Invoke(null, args);
                };
                Interop.InputGesture.ErrorCode error = Interop.InputGesture.SetPalmCoverCb(gestureHandle, palmCoverData, _palmCoverDelegate, IntPtr.Zero);
                if (error != Interop.InputGesture.ErrorCode.None)
                {
                    Log.Info(LogTag, "error" + error.ToString());
                }
                else
                {
                    _palmCoverEventHandler += value;
                }
            }
            remove
            {
                _palmCoverEventHandler -= value;
            }
        }
    }
}