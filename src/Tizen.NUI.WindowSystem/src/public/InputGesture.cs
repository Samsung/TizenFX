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
        None,

        /// <summary>
        /// Begin.
        /// </summary>
        Begin,

        /// <summary>
        /// Update.
        /// </summary>
        Update,

        /// <summary>
        /// End.
        /// </summary>
        End,

        /// <summary>
        /// Done.
        /// </summary>
        Done,
    }

    /// <summary>
    /// Enumeration of gesture edges.
    /// </summary>
    public enum GestureEdge
    {
        /// <summary>
        /// edge none.
        /// </summary>
        None,

        /// <summary>
        /// edge top.
        /// </summary>
        Top,

        /// <summary>
        /// edge right.
        /// </summary>
        Right,

        /// <summary>
        /// edge bottom.
        /// </summary>
        Bottom,

        /// <summary>
        /// edge left.
        /// </summary>
        Left,
    }

    /// <summary>
    /// Enumeration of gesture edge sizes.
    /// /// </summary>
    public enum GestureEdgeSize
    {
        /// <summary>
        /// edge size none.
        /// </summary>
        None,

        /// <summary>
        /// edge size full.
        /// </summary>
        Full,

        /// <summary>
        /// edge size partial.
        /// </summary>
        Partial,
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

        private EdgeSwipeData edgeSwipeData;
        private EdgeDragData edgeDragData;
        private TapData tapData;
        private PalmCoverData palmCoverData;

        private bool disposed = false;

        private event EventHandler<EdgeDragEventArgs> edgeDragDetected;
        private EdgeDragCb edgeDragDelegate;

        private event EventHandler<EdgeSwipeEventArgs> edgeSwipeDetected;
        private EdgeSwipeCb edgeSwipeDelegate;

        private event EventHandler<TapEventArgs> tapDetected;
        private TapCb tapDelegate;

        private event EventHandler<PalmCoverEventArgs> palmCoverDetected;
        private PalmCoverCb palmCoverDelegate;

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
            gestureHandle = Interop.InputGesture.Initialize();
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
                Interop.InputGesture.ErrorCode res = Interop.InputGesture.Deinitialize(gestureHandle);
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

        internal SafeGestureHandle GetNativeHandle()
        {
            return gestureHandle;
        }

        /// <summary>
        /// Grabs a edge drag gesture
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public void GrabEdgeDragGesture(EdgeDragData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (data.GetNativeHandle().IsInvalid)
            {
                throw new ArgumentException("edgeDragData is not valid.");
            }
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.GestureGrab(gestureHandle, data.GetNativeHandle());
            ErrorCodeThrow(res);
            edgeDragData = data;
            Log.Debug(LogTag, "GrabEdgeDragGesture");
        }

        /// <summary>
        /// Ungrabs a edge drag gesture.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public void UngrabEdgeDragGesture(EdgeDragData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (data.GetNativeHandle().IsInvalid)
            {
                throw new ArgumentException("edgeDragData is not valid.");
            }
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.GestureUngrab(gestureHandle, data.GetNativeHandle());
            ErrorCodeThrow(res);
            edgeDragData = null;
            Log.Debug(LogTag, "UngrabEdgeDragGesture");
        }

        /// <summary>
        /// Grabs a edge swipe gesture
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public void GrabEdgeSwipeGesture(EdgeSwipeData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (data.GetNativeHandle().IsInvalid)
            {
                throw new ArgumentException("edgeSwipeData is not valid.");
            }
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.GestureGrab(gestureHandle, data.GetNativeHandle());
            ErrorCodeThrow(res);
            edgeSwipeData = data;
            Log.Debug(LogTag, "GrabEdgeDragGesture");
        }

        /// <summary>
        /// Ungrabs a edge swipe gesture.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public void UngrabEdgeSwipeGesture(EdgeSwipeData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (data.GetNativeHandle().IsInvalid)
            {
                throw new ArgumentException("edgeSwipeData is not valid.");
            }
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.GestureUngrab(gestureHandle, data.GetNativeHandle());
            ErrorCodeThrow(res);
            edgeSwipeData = null;
            Log.Debug(LogTag, "UngrabEdgeSwipeGesture");
        }

        /// <summary>
        /// Grabs a tap gesture
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public void GrabTapGesture(TapData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (data.GetNativeHandle().IsInvalid)
            {
                throw new ArgumentException("tapData is not valid.");
            }
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.GestureGrab(gestureHandle, data.GetNativeHandle());
            ErrorCodeThrow(res);
            tapData = data;
            Log.Debug(LogTag, "GrabTapGesture");
        }

        /// <summary>
        /// Ungrabs a tap gesture.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public void UngrabTapGesture(TapData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (data.GetNativeHandle().IsInvalid)
            {
                throw new ArgumentException("tapData is not valid.");
            }
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.GestureUngrab(gestureHandle, data.GetNativeHandle());
            ErrorCodeThrow(res);
            tapData = null;
            Log.Debug(LogTag, "GrabTapGesture");
        }

        /// <summary>
        /// Grabs a palm cover gesture
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public void GrabPalmCoverGesture(PalmCoverData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (data.GetNativeHandle().IsInvalid)
            {
                throw new ArgumentException("palmCoverData is not valid.");
            }
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.GestureGrab(gestureHandle, data.GetNativeHandle());
            ErrorCodeThrow(res);
            palmCoverData = data;
            Log.Debug(LogTag, "GrabPalmCoverGesture");
        }

        /// <summary>
        /// Ungrabs a palm cover gesture.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="ArgumentNullException">Thrown when a argument is null.</exception>
        public void UngrabPalmCoverGesture(PalmCoverData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (data.GetNativeHandle().IsInvalid)
            {
                throw new ArgumentException("palmCoverData is not valid.");
            }
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.GestureUngrab(gestureHandle, data.GetNativeHandle());
            ErrorCodeThrow(res);
            palmCoverData = null;
            Log.Debug(LogTag, "UngrabPalmCoverGesture");
        }

        /// <summary>
        /// Emits the event when the edge drag event comes
        /// </summary>
        public event EventHandler<EdgeDragEventArgs> EdgeDragEventHandler
        {
            add
            {
                if (edgeDragDetected == null)
                {
                    if (edgeDragData == null)
                    {
                        throw new InvalidOperationException("edgeDragData is NULL");
                    }
                    if (edgeDragData.GetNativeHandle() == null)
                    {
                        Log.Info(LogTag, "Invalid Native Handle");
                        return;
                    }
                    edgeDragDelegate = (IntPtr userData, int mode,  int fingers, int cx, int cy, int edge) =>
                    {
                        EdgeDragEventArgs args = new EdgeDragEventArgs(mode, fingers, cx, cy, edge);
                        Log.Info(LogTag, "EdgeDrag Event received. mode: " + mode + ", fingers: " + fingers);
                        edgeDragDetected?.Invoke(null, args);
                    };
                    Interop.InputGesture.ErrorCode error = Interop.InputGesture.SetEdgeDragCb(gestureHandle, edgeDragData.GetNativeHandle(), edgeDragDelegate, IntPtr.Zero);
                    if (error != Interop.InputGesture.ErrorCode.None)
                    {
                        Log.Info(LogTag, "error" + error.ToString());
                    }
                    else
                    {
                        edgeDragDetected += value;
                    }
                }
            }
            remove
            {
                edgeDragDetected -= value;
            }
        }

        /// <summary>
        /// Emits the event when the edge swipe event comes
        /// </summary>
        public event EventHandler<EdgeSwipeEventArgs> EdgeSwipeEventHandler
        {
            add
            {
                if (edgeSwipeDetected == null)
                {
                    if (edgeSwipeData == null)
                    {
                        throw new InvalidOperationException("edgeSwipeData is NULL");
                    }
                    if (edgeSwipeData.GetNativeHandle() == null)
                    {
                        Log.Info(LogTag, "Invalid Native Handle");
                        return;
                    }
                    edgeSwipeDelegate = (IntPtr userData, int mode,  int fingers, int sx, int sy, int edge) =>
                    {
                        EdgeSwipeEventArgs args = new EdgeSwipeEventArgs(mode, fingers, sx, sy, edge);
                        Log.Info(LogTag, "EdgeSwipe Event received. mode: " + mode + ", fingers: " + fingers);
                        edgeSwipeDetected?.Invoke(null, args);
                    };
                    Interop.InputGesture.ErrorCode error = Interop.InputGesture.SetEdgeSwipeCb(gestureHandle, edgeSwipeData.GetNativeHandle(), edgeSwipeDelegate, IntPtr.Zero);
                    if (error != Interop.InputGesture.ErrorCode.None)
                    {
                        Log.Info(LogTag, "error" + error.ToString());
                    }
                    else
                    {
                        edgeSwipeDetected += value;
                    }
                }
            }
            remove
            {
                edgeSwipeDetected -= value;
            }
        }

        /// <summary>
        /// Emits the event when the tap event comes
        /// </summary>
        public event EventHandler<TapEventArgs> TapEventHandler
        {
            add
            {
                if (tapDetected == null)
                {
                    if (tapData == null)
                    {
                        throw new InvalidOperationException("tapData is NULL");
                    }
                    if (tapData.GetNativeHandle() == null)
                    {
                        Log.Info(LogTag, "Invalid Native Handle");
                        return;
                    }
                    tapDelegate = (IntPtr userData, int mode,  int fingers, int repeats) =>
                    {
                        TapEventArgs args = new TapEventArgs(mode, fingers, repeats);
                        Log.Info(LogTag, "Tap Event received. mode: " + mode + ", fingers: " + fingers + ", repeats: " + repeats);
                        tapDetected?.Invoke(null, args);
                    };
                    Interop.InputGesture.ErrorCode error = Interop.InputGesture.SetTapCb(gestureHandle, tapData.GetNativeHandle(), tapDelegate, IntPtr.Zero);
                    if (error != Interop.InputGesture.ErrorCode.None)
                    {
                        Log.Info(LogTag, "error" + error.ToString());
                    }
                    else
                    {
                        tapDetected += value;
                    }
                }
            }
            remove
            {
                tapDetected -= value;
            }
        }

        /// <summary>
        /// Emits the event when the palm cover event comes
        /// </summary>
        public event EventHandler<PalmCoverEventArgs> PalmCoverEventHandler
        {
            add
            {
                if (palmCoverDetected == null)
                {
                    if (palmCoverData == null)
                    {
                        throw new InvalidOperationException("palmCoverData is NULL");
                    }
                    if (palmCoverData.GetNativeHandle() == null)
                    {
                        Log.Info(LogTag, "Invalid Native Handle");
                        return;
                    }
                    palmCoverDelegate = (IntPtr userData, int mode,  int duration, int cx, int cy, int size, double pressure) =>
                    {
                        PalmCoverEventArgs args = new PalmCoverEventArgs(mode, duration, cx, cy, size, pressure);
                        Log.Info(LogTag, "PalmCover Event received. mode: " + mode + ", duration: " + duration);
                        palmCoverDetected?.Invoke(null, args);
                    };
                    Interop.InputGesture.ErrorCode error = Interop.InputGesture.SetPalmCoverCb(gestureHandle, palmCoverData.GetNativeHandle(), palmCoverDelegate, IntPtr.Zero);
                    if (error != Interop.InputGesture.ErrorCode.None)
                    {
                        Log.Info(LogTag, "error" + error.ToString());
                    }
                    else
                    {
                        palmCoverDetected += value;
                    }
                }
            }
            remove
            {
                palmCoverDetected -= value;
            }
        }
    }
}
