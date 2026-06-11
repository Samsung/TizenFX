/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.WindowSystem
{
    /// <summary>
    /// Enumeration of gesture modes.
    /// </summary>
    /// This enum is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
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
    /// This enum is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
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
    /// </summary>
    /// This enum is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
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
    /// Enumeration of gesture grab modes.
    /// </summary>
    /// This enum is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum GestureGrabMode
    {
        /// <summary>
        /// mode none.
        /// </summary>
        None,

        /// <summary>
        /// mode exclusive.
        /// </summary>
        Exclusive,

        /// <summary>
        /// mode shared.
        /// </summary>
        Shared,
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
        private IntPtr _handler;
        private TizenCoreWlDisplay _display;
        private bool disposed = false;
        private bool isDisposeQueued = false;

        private event EventHandler<EdgeSwipeEventArgs> _edgeSwipeEventHandler;
        private Interop.InputGesture.EdgeSwipeCb _edgeSwipeDelegate;

        private event EventHandler<EdgeDragEventArgs> _edgeDragEventHandler;
        private Interop.InputGesture.EdgeDragCb _edgeDragDelegate;

        private event EventHandler<TapEventArgs> _tapEventHandler;
        private Interop.InputGesture.TapCb _tapDelegate;

        private event EventHandler<PalmCoverEventArgs> _palmCoverEventHandler;
        private Interop.InputGesture.PalmCoverCb _palmCoverDelegate;

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
                case Interop.InputGesture.ErrorCode.NotConnected :
                    throw new InvalidOperationException("Not Connected");
                default :
                    throw new InvalidOperationException($"Unknown Error: {error}");
            }
        }

        /// <summary>
        /// Creates a new InputGesture.
        /// </summary>
        /// <param name="display">The TizenCoreWlDisplay instance.</param>
        /// <remarks> This module operates in a NUI application and requires instantiation and disposal on the main thread.</remarks>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="Tizen.Applications.Exceptions.PermissionDeniedException">Thrown when the permission is denied.</exception>
        public InputGesture(TizenCoreWlDisplay display)
        {
            if (display == null)
            {
                throw new ArgumentNullException(nameof(display));
            }

            IntPtr displayHandle = display.GetNativeHandle();
            if (displayHandle == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(display));
            }

            _display = display;
            int ret = Interop.InputGesture.Create(displayHandle, out _handler);
            if (ret != (int)Interop.InputGesture.ErrorCode.None)
            {
                disposed = true;
                GC.SuppressFinalize(this);
                ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
            }
            Log.Debug(Interop.InputGesture.LogTag, "InputGesture Created");
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~InputGesture()
        {
            if (!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(DisposeTypes.Explicit);
                GC.SuppressFinalize(this);
            }
        }

        /// <inheritdoc/>
        protected virtual void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            disposed = true;
            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            if (_handler != global::System.IntPtr.Zero)
            {
                if (_display != null && _display.GetNativeHandle() != IntPtr.Zero)
                {
                    try
                    {
                        int res = Interop.InputGesture.Destroy(_handler);
                        if (res != (int)Interop.InputGesture.ErrorCode.None)
                        {
                            Log.Error(Interop.InputGesture.LogTag, $"Failed to destroy input gesture, error={res}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(Interop.InputGesture.LogTag, $"Exception during destroy: {ex.Message}");
                    }
                }
                _handler = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Generates a edge swipe gesture's grab info handle
        /// </summary>
        /// <param name="fingers"> The number of fingers </param>
        /// <param name="edge"> The position of edge</param>
        /// <returns> The edge swipe gesture data handle </returns>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        public IntPtr CreateEdgeSwipeData(int fingers, GestureEdge edge)
        {
            if (disposed || _handler == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(InputGesture));
            }
            if (_display == null || _display.GetNativeHandle() == IntPtr.Zero)
            {
                throw new InvalidOperationException("Associated display has been disposed");
            }
            if (fingers <=0)
            {
                throw new ArgumentException("fingers must be greater than 0");
            }

            IntPtr edgeSwipeG = IntPtr.Zero;
            int ret = Interop.InputGesture.EdgeSwipeNew(_handler, (uint)fingers, (int)edge, out edgeSwipeG);
            if (ret != (int)Interop.InputGesture.ErrorCode.None)
            {
                ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
            }
            Log.Debug(Interop.InputGesture.LogTag, $"CreateEdgeSwipeData fingers: {fingers}, edge: {(int)edge}");
            return edgeSwipeG;
        }

        /// <summary>
        /// Frees a memory of edge swipe gesture's grab info handle
        /// </summary>
        /// <param name="data"> The edge swipe gesture data handle </param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void ReleaseEdgeSwipeData(IntPtr data)
        {
            if (disposed || _handler == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(InputGesture));
            }
            if (_display == null || _display.GetNativeHandle() == IntPtr.Zero)
            {
                throw new InvalidOperationException("Associated display has been disposed");
            }
            if (data == IntPtr.Zero)
            {
                throw new ArgumentException("EdgeSwipeData is not valid.");
            }
            int ret = Interop.InputGesture.EdgeSwipeFree(_handler, data);
            ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
            Log.Debug(Interop.InputGesture.LogTag, "ReleaseEdgeSwipeData");
        }

        /// <summary>
        /// Sets a specific size of edge for edge swipe gesture
        /// </summary>
        /// <param name="data"> The edge swipe gesture data handle </param>
        /// <param name="edgeSize"> The enum of gesture edge size </param>
        /// <param name="startPoint"> The start point of edge area </param>
        /// <param name="endPoint"> The end point of edge area</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void SetEdgeSwipeSize(IntPtr data, GestureEdgeSize edgeSize, int startPoint, int endPoint)
        {
            if (disposed || _handler == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(InputGesture));
            }
            if (_display == null || _display.GetNativeHandle() == IntPtr.Zero)
            {
                throw new InvalidOperationException("Associated display has been disposed");
            }
            if (startPoint < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startPoint), "startPoint must be greater than or equal to 0");
            }
            if (endPoint < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(endPoint), "endPoint must be greater than or equal to 0");
            }
            if (data == IntPtr.Zero)
            {
                throw new ArgumentException("EdgeSwipeData is not valid.");
            }
            int ret = Interop.InputGesture.EdgeSwipeSizeSet(data, (int)edgeSize, (uint)startPoint, (uint)endPoint);
            ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
            Log.Debug(Interop.InputGesture.LogTag, $"SetEdgeSwipeSize size: {(int)edgeSize}, startPoint: {startPoint}, endPoint: {endPoint}");
        }

        /// <summary>
        /// Generates a edge drag gesture's grab info handle
        /// </summary>
        /// <param name="fingers"> The number of fingers </param>
        /// <param name="edge"> The position of edge</param>
        /// <returns> The edge drag gesture data handle </returns>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        public IntPtr CreateEdgeDragData(int fingers, GestureEdge edge)
        {
            if (disposed || _handler == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(InputGesture));
            }
            if (_display == null || _display.GetNativeHandle() == IntPtr.Zero)
            {
                throw new InvalidOperationException("Associated display has been disposed");
            }
            if (fingers <=0)
            {
                throw new ArgumentException("fingers must be greater than 0");
            }

            IntPtr edgeDragG = IntPtr.Zero;
            int ret = Interop.InputGesture.EdgeDragNew(_handler, (uint)fingers, (int)edge, out edgeDragG);
            if (ret != (int)Interop.InputGesture.ErrorCode.None)
            {
                ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
            }
            Log.Debug(Interop.InputGesture.LogTag, $"CreateEdgeDragData fingers: {fingers}, edge: {(int)edge}");
            return edgeDragG;
        }

        /// <summary>
        /// Frees a memory of edge drag gesture's grab info handle
        /// </summary>
        /// <param name="data"> The edge drag gesture data handle </param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void ReleaseEdgeDrageData(IntPtr data)
        {
            if (disposed || _handler == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(InputGesture));
            }
            if (_display == null || _display.GetNativeHandle() == IntPtr.Zero)
            {
                throw new InvalidOperationException("Associated display has been disposed");
            }
            if (data == IntPtr.Zero)
            {
                throw new ArgumentException("EdgeDragData is not valid.");
            }
            int ret = Interop.InputGesture.EdgeDragFree(_handler, data);
            ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
            Log.Debug(Interop.InputGesture.LogTag, "ReleaseEdgeDrageData");
        }

        /// <summary>
        /// Sets a specific size of edge for edge drag gesture
        /// </summary>
        /// <param name="data"> The edge drag gesture data handle </param>
        /// <param name="edgeSize"> The enum of gesture edge size </param>
        /// <param name="startPoint"> The start point of edge area </param>
        /// <param name="endPoint"> The end point of edge area</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void SetEdgeDragSize(IntPtr data, GestureEdgeSize edgeSize, int startPoint, int endPoint)
        {
            if (disposed || _handler == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(InputGesture));
            }
            if (_display == null || _display.GetNativeHandle() == IntPtr.Zero)
            {
                throw new InvalidOperationException("Associated display has been disposed");
            }
            if (startPoint < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startPoint), "startPoint must be greater than or equal to 0");
            }
            if (endPoint < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(endPoint), "endPoint must be greater than or equal to 0");
            }
            if (data == IntPtr.Zero)
            {
                throw new ArgumentException("EdgeDragData is not valid.");
            }
            int ret = Interop.InputGesture.EdgeDragSizeSet(data, (int)edgeSize, (uint)startPoint, (uint)endPoint);
            ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
            Log.Debug(Interop.InputGesture.LogTag, $"SetEdgeDragSize size: {(int)edgeSize}, startPoint: {startPoint}, endPoint: {endPoint}");
        }

        /// <summary>
        /// Generates a tap gesture's grab info handle
        /// </summary>
        /// <param name="fingers"> The number of fingers </param>
        /// <param name="repeats"> The number of repeats</param>
        /// <returns> The tap gesture data handle </returns>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        public IntPtr CreateTapData(int fingers, int repeats)
        {
            if (disposed || _handler == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(InputGesture));
            }
            if (_display == null || _display.GetNativeHandle() == IntPtr.Zero)
            {
                throw new InvalidOperationException("Associated display has been disposed");
            }
            if (fingers <=0)
            {
                throw new ArgumentException("fingers must be greater than 0");
            }
            if (repeats < 0)
            {
                throw new ArgumentException("repeats must be greater than or equal to 0");
            }

            IntPtr tapG = IntPtr.Zero;
            int ret = Interop.InputGesture.TapNew(_handler, (uint)fingers, (uint)repeats, out tapG);
            if (ret != (int)Interop.InputGesture.ErrorCode.None)
            {
                ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
            }
            Log.Debug(Interop.InputGesture.LogTag, $"CreateTapData fingers: {fingers}, repeats: {repeats}");
            return tapG;
        }

        /// <summary>
        /// Frees a memory of tap gesture's grab info handle
        /// </summary>
        /// <param name="data"> The tap gesture data handle </param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void ReleaseTapData(IntPtr data)
        {
            if (disposed || _handler == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(InputGesture));
            }
            if (_display == null || _display.GetNativeHandle() == IntPtr.Zero)
            {
                throw new InvalidOperationException("Associated display has been disposed");
            }
            if (data == IntPtr.Zero)
            {
                throw new ArgumentException("tapData is not valid.");
            }
            int ret = Interop.InputGesture.TapFree(_handler, data);
            ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
            Log.Debug(Interop.InputGesture.LogTag, "ReleaseTapData");
        }

        /// <summary>
        /// Generates a palm cover gesture's grab info handle
        /// </summary>
        /// <returns> The palm cover gesture data handle </returns>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        public IntPtr CreatePalmCoverData()
        {
            if (disposed || _handler == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(InputGesture));
            }
            if (_display == null || _display.GetNativeHandle() == IntPtr.Zero)
            {
                throw new InvalidOperationException("Associated display has been disposed");
            }
            IntPtr palmCoverG = IntPtr.Zero;
            int ret = Interop.InputGesture.PalmCoverNew(_handler, out palmCoverG);
            if (ret != (int)Interop.InputGesture.ErrorCode.None)
            {
                ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
            }
            Log.Debug(Interop.InputGesture.LogTag, "CreatePalmCoverData");
            return palmCoverG;
        }

        /// <summary>
        /// Frees a memory of palm cover gesture's grab info handle
        /// </summary>
        /// <param name="data"> The palm cover gesture data handle </param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void ReleasePalmCoverData(IntPtr data)
        {
            if (disposed || _handler == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(InputGesture));
            }
            if (_display == null || _display.GetNativeHandle() == IntPtr.Zero)
            {
                throw new InvalidOperationException("Associated display has been disposed");
            }
            if (data == IntPtr.Zero)
            {
                throw new ArgumentException("palmCoverData is not valid.");
            }
            int ret = Interop.InputGesture.PalmCoverFree(_handler, data);
            ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
            Log.Debug(Interop.InputGesture.LogTag, "ReleasePalmCoverData");
        }

        /// <summary>
        /// Grabs a global gesture
        /// </summary>
        /// <param name="data">gesture data to grab</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void GrabGesture(IntPtr data)
        {
            if (disposed || _handler == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(InputGesture));
            }
            if (_display == null || _display.GetNativeHandle() == IntPtr.Zero)
            {
                throw new InvalidOperationException("Associated display has been disposed");
            }
            if (data == IntPtr.Zero)
            {
                throw new ArgumentException("gesture data is not valid.");
            }
            int ret = Interop.InputGesture.GestureGrab(_handler, data);
            ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
            Log.Debug(Interop.InputGesture.LogTag, "GrabGesture");
        }

        /// <summary>
        /// Sets grab mode of global gesture
        /// </summary>
        /// <param name="data">gesture data to grab</param>
        /// <param name="mode"> The mode of gesture grab</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void SetGestureGrabMode(IntPtr data, GestureGrabMode mode)
        {
            if (disposed || _handler == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(InputGesture));
            }
            if (_display == null || _display.GetNativeHandle() == IntPtr.Zero)
            {
                throw new InvalidOperationException("Associated display has been disposed");
            }
            if (data == IntPtr.Zero)
            {
                throw new ArgumentException("gesture data is not valid.");
            }
            int ret = Interop.InputGesture.SetGestureGrabMode(_handler, data, (int)mode);
            ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
            Log.Debug(Interop.InputGesture.LogTag, "SetGestureGrabMode");
        }

        /// <summary>
        /// Ungrabs a global gesture.
        /// </summary>
        /// <param name="data">gesture data to ungrab</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public void UngrabGesture(IntPtr data)
        {
            if (disposed || _handler == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(InputGesture));
            }
            if (_display == null || _display.GetNativeHandle() == IntPtr.Zero)
            {
                throw new InvalidOperationException("Associated display has been disposed");
            }
            if (data == IntPtr.Zero)
            {
                throw new ArgumentException("gesture data is not valid.");
            }
            int ret = Interop.InputGesture.GestureUngrab(_handler, data);
            ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
            Log.Debug(Interop.InputGesture.LogTag, "UngrabGesture");
        }

        /// <summary>
        /// Emits the event when the edge swipe event comes
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public event EventHandler<EdgeSwipeEventArgs> EdgeSwipeEventHandler
        {
            add
            {
                if (disposed || _handler == IntPtr.Zero)
                {
                    throw new ObjectDisposedException(nameof(InputGesture));
                }

                if (_edgeSwipeEventHandler == null)
                {
                    _edgeSwipeDelegate = (IntPtr userData, int mode,  int fingers, int sx, int sy, int edge) =>
                    {
                        EdgeSwipeEventArgs args = new EdgeSwipeEventArgs(mode, fingers, sx, sy, edge);
                        Log.Debug(Interop.InputGesture.LogTag, $"EdgeSwipe Event received. mode: {mode}, fingers: {fingers}");
                        _edgeSwipeEventHandler?.Invoke(null, args);
                    };
                    int ret = Interop.InputGesture.SetEdgeSwipeCb(_handler, _edgeSwipeDelegate, IntPtr.Zero);
                    ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
                }

                _edgeSwipeEventHandler += value;
            }
            remove
            {
                _edgeSwipeEventHandler -= value;
                if (_edgeSwipeEventHandler == null && _edgeSwipeDelegate != null)
                {
                    if (disposed || _handler == IntPtr.Zero)
                    {
                        return;
                    }
                    int ret = Interop.InputGesture.SetEdgeSwipeCb(_handler, null, IntPtr.Zero);
                    _edgeSwipeDelegate = null;
                    ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
                }
            }
        }

        /// <summary>
        /// Emits the event when the edge drag event comes
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public event EventHandler<EdgeDragEventArgs> EdgeDragEventHandler
        {
            add
            {
                if (disposed || _handler == IntPtr.Zero)
                {
                    throw new ObjectDisposedException(nameof(InputGesture));
                }

                if (_edgeDragEventHandler == null)
                {
                    _edgeDragDelegate = (IntPtr userData, int mode,  int fingers, int cx, int cy, int edge) =>
                    {
                        EdgeDragEventArgs args = new EdgeDragEventArgs(mode, fingers, cx, cy, edge);
                        Log.Debug(Interop.InputGesture.LogTag, $"EdgeDrag Event received. mode: {mode}, fingers: {fingers}");
                        _edgeDragEventHandler?.Invoke(null, args);
                    };
                    int ret = Interop.InputGesture.SetEdgeDragCb(_handler, _edgeDragDelegate, IntPtr.Zero);
                    ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
                }

                _edgeDragEventHandler += value;
            }
            remove
            {
                _edgeDragEventHandler -= value;
                if (_edgeDragEventHandler == null && _edgeDragDelegate != null)
                {
                    if (disposed || _handler == IntPtr.Zero)
                    {
                        return;
                    }
                    int ret = Interop.InputGesture.SetEdgeDragCb(_handler, null, IntPtr.Zero);
                    _edgeDragDelegate = null;
                    ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
                }
            }
        }

        /// <summary>
        /// Emits the event when the tap event comes
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public event EventHandler<TapEventArgs> TapEventHandler
        {
            add
            {
                if (disposed || _handler == IntPtr.Zero)
                {
                    throw new ObjectDisposedException(nameof(InputGesture));
                }

                if (_tapEventHandler == null)
                {
                    _tapDelegate = (IntPtr userData, int mode,  int fingers, int repeats) =>
                    {
                        TapEventArgs args = new TapEventArgs(mode, fingers, repeats);
                        Log.Debug(Interop.InputGesture.LogTag, $"Tap Event received. mode: {mode}, fingers: {fingers}, repeats: {repeats}");
                        _tapEventHandler?.Invoke(null, args);
                    };
                    int ret = Interop.InputGesture.SetTapCb(_handler, _tapDelegate, IntPtr.Zero);
                    ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
                }

                _tapEventHandler += value;
            }
            remove
            {
                _tapEventHandler -= value;
                if (_tapEventHandler == null && _tapDelegate != null)
                {
                    if (disposed || _handler == IntPtr.Zero)
                    {
                        return;
                    }
                    int ret = Interop.InputGesture.SetTapCb(_handler, null, IntPtr.Zero);
                    _tapDelegate = null;
                    ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
                }
            }
        }
        /// <summary>
        /// Emits the event when the palm cover event comes
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        public event EventHandler<PalmCoverEventArgs> PalmCoverEventHandler
        {
            add
            {
                if (disposed || _handler == IntPtr.Zero)
                {
                    throw new ObjectDisposedException(nameof(InputGesture));
                }

                if (_palmCoverEventHandler == null)
                {
                    _palmCoverDelegate = (IntPtr userData, int mode,  int duration, int cx, int cy, int size, double pressure) =>
                    {
                        PalmCoverEventArgs args = new PalmCoverEventArgs(mode, duration, cx, cy, size, pressure);
                        Log.Debug(Interop.InputGesture.LogTag, $"PalmCover Event received. mode: {mode}, duration: {duration}");
                        _palmCoverEventHandler?.Invoke(null, args);
                    };
                    int ret = Interop.InputGesture.SetPalmCoverCb(_handler, _palmCoverDelegate, IntPtr.Zero);
                    ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
                }
                _palmCoverEventHandler += value;
            }
            remove
            {
                _palmCoverEventHandler -= value;
                if (_palmCoverEventHandler == null && _palmCoverDelegate != null)
                {
                    if (disposed || _handler == IntPtr.Zero)
                    {
                        return;
                    }
                    int ret = Interop.InputGesture.SetPalmCoverCb(_handler, null, IntPtr.Zero);
                    _palmCoverDelegate = null;
                    ErrorCodeThrow((Interop.InputGesture.ErrorCode)ret);
                }
            }
        }
    }
}
