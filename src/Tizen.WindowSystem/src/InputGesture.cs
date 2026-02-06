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
using static Tizen.WindowSystem.Interop.InputGesture;

namespace Tizen.WindowSystem
{


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
        SafeHandles.InputGestureHandle _handler;
        bool disposed = false;

        event EventHandler<EdgeSwipeEventArgs> _edgeSwipeEventHandler;
        EdgeSwipeCb _edgeSwipeDelegate;

        event EventHandler<EdgeDragEventArgs> _edgeDragEventHandler;
        EdgeDragCb _edgeDragDelegate;

        event EventHandler<TapEventArgs> _tapEventHandler;
        TapCb _tapDelegate;

        event EventHandler<PalmCoverEventArgs> _palmCoverEventHandler;
        PalmCoverCb _palmCoverDelegate;

        internal void ThrowIfError(Interop.InputGesture.ErrorCode error)
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
        /// <remarks> This module operates in a NUI application and requires instantiation and disposal on the main thread.</remarks>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="Tizen.Applications.Exceptions.PermissionDeniedException">Thrown when the permission is denied.</exception>
        public InputGesture()
        {
            _handler = Interop.InputGesture.Initialize();
            if (_handler.IsInvalid)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                ThrowIfError((Interop.InputGesture.ErrorCode)err);
            }
            Log.Debug(LogTag, "InputGesture Created");
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
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                _handler?.Dispose();
            }

            disposed = true;
        }


        /// <summary>
        /// Generates a edge swipe gesture handle.
        /// </summary>
        /// <param name="fingers"> The number of fingers </param>
        /// <param name="edge"> The position of edge</param>
        /// <returns> The edge swipe gesture object </returns>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        public EdgeSwipeGesture CreateEdgeSwipe(int fingers, GestureEdge edge)
        {
            IntPtr edgeSwipeG = IntPtr.Zero;
            edgeSwipeG = Interop.InputGesture.EdgeSwipeNew(_handler, fingers, edge);
            if (edgeSwipeG == IntPtr.Zero)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                ThrowIfError((Interop.InputGesture.ErrorCode)err);
            }
            Log.Debug(LogTag, "CreateEdgeSwipe" + "fingers: " + fingers, "edge: " + (int)edge);
            return new EdgeSwipeGesture(this, _handler, edgeSwipeG, fingers, edge);
        }


        /// <summary>
        /// Generates a edge drag gesture handle.
        /// </summary>
        /// <param name="fingers"> The number of fingers </param>
        /// <param name="edge"> The position of edge</param>
        /// <returns> The edge drag gesture object </returns>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        public EdgeDragGesture CreateEdgeDrag(int fingers, GestureEdge edge)
        {
            IntPtr edgeDragG = IntPtr.Zero;
            edgeDragG = Interop.InputGesture.EdgeDragNew(_handler, fingers, edge);
            if (edgeDragG == IntPtr.Zero)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                ThrowIfError((Interop.InputGesture.ErrorCode)err);
            }
            Log.Debug(LogTag, "CreateEdgeDrag" + "fingers: " + fingers, "edge: " + (int)edge);
            return new EdgeDragGesture(this, _handler, edgeDragG, fingers, edge);
        }


        /// <summary>
        /// Generates a tap gesture handle.
        /// </summary>
        /// <param name="fingers"> The number of fingers </param>
        /// <param name="repeats"> The number of repeats</param>
        /// <returns> The tap gesture object </returns>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        public TapGesture CreateTap(int fingers, int repeats)
        {
            IntPtr tapG = IntPtr.Zero;
            tapG = Interop.InputGesture.TapNew(_handler, fingers, repeats);
            if (tapG == IntPtr.Zero)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                ThrowIfError((Interop.InputGesture.ErrorCode)err);
            }
            Log.Debug(LogTag, "CreateTap" + "fingers: " + fingers, "repeats: " + repeats);
            return new TapGesture(this, _handler, tapG, fingers, repeats);
        }
        /// <summary>
        /// Generates a palm cover gesture handle.
        /// </summary>
        /// <returns> The palm cover gesture object </returns>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        public PalmCoverGesture CreatePalmCover()
        {
            IntPtr palmCoverG = IntPtr.Zero;
            palmCoverG = Interop.InputGesture.PalmCoverNew(_handler);
            if (palmCoverG == IntPtr.Zero)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                ThrowIfError((Interop.InputGesture.ErrorCode)err);
            }
            Log.Debug(LogTag, "CreatePalmCover");
            return new PalmCoverGesture(this, _handler, palmCoverG);
        }
        /// <summary>
        /// Emits the event when the edge swipe event comes
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        internal event EventHandler<EdgeSwipeEventArgs> EdgeSwipeEventHandler
        {
            add
            {
                if (_edgeSwipeEventHandler == null)
                {
                    _edgeSwipeDelegate = (IntPtr userData, GestureState mode,  int fingers, int sx, int sy, GestureEdge edge) =>
                    {
                        EdgeSwipeEventArgs args = new EdgeSwipeEventArgs(mode, fingers, sx, sy, edge);
                        Log.Debug(LogTag, "EdgeSwipe Event received. mode: " + mode + ", fingers: " + fingers);
                        _edgeSwipeEventHandler?.Invoke(null, args);
                    };
                    Interop.InputGesture.ErrorCode res = Interop.InputGesture.SetEdgeSwipeCb(_handler, _edgeSwipeDelegate, IntPtr.Zero);
                    ThrowIfError(res);
                }

                _edgeSwipeEventHandler += value;
            }
            remove
            {
                _edgeSwipeEventHandler -= value;
                if (_edgeSwipeEventHandler == null)
                {
                    Interop.InputGesture.ErrorCode res = Interop.InputGesture.SetEdgeSwipeCb(_handler, null, IntPtr.Zero);
                    ThrowIfError(res);
                }
            }
        }

        /// <summary>
        /// Emits the event when the edge drag event comes
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        internal event EventHandler<EdgeDragEventArgs> EdgeDragEventHandler
        {
            add
            {
                if (_edgeDragEventHandler == null)
                {
                    _edgeDragDelegate = (IntPtr userData, GestureState mode,  int fingers, int cx, int cy, GestureEdge edge) =>
                    {
                        EdgeDragEventArgs args = new EdgeDragEventArgs(mode, fingers, cx, cy, edge);
                        Log.Debug(LogTag, "EdgeDrag Event received. mode: " + mode + ", fingers: " + fingers);
                        _edgeDragEventHandler?.Invoke(null, args);
                    };
                    Interop.InputGesture.ErrorCode res = Interop.InputGesture.SetEdgeDragCb(_handler, _edgeDragDelegate, IntPtr.Zero);
                    ThrowIfError(res);
                }

                _edgeDragEventHandler += value;
            }
            remove
            {
                _edgeDragEventHandler -= value;
                if (_edgeDragEventHandler == null)
                {
                    Interop.InputGesture.ErrorCode res = Interop.InputGesture.SetEdgeDragCb(_handler, null, IntPtr.Zero);
                    ThrowIfError(res);
                }
            }
        }

        /// <summary>
        /// Emits the event when the tap event comes
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        internal event EventHandler<TapEventArgs> TapEventHandler
        {
            add
            {
                if (_tapEventHandler == null)
                {
                    _tapDelegate = (IntPtr userData, GestureState mode,  int fingers, int repeats) =>
                    {
                        TapEventArgs args = new TapEventArgs(mode, fingers, repeats);
                        Log.Debug(LogTag, "Tap Event received. mode: " + mode + ", fingers: " + fingers + ", repeats: " + repeats);
                        _tapEventHandler?.Invoke(null, args);
                    };
                    Interop.InputGesture.ErrorCode res = Interop.InputGesture.SetTapCb(_handler, _tapDelegate, IntPtr.Zero);
                    ThrowIfError(res);
                }

                _tapEventHandler += value;
            }
            remove
            {
                _tapEventHandler -= value;
                if (_tapEventHandler == null)
                {
                    Interop.InputGesture.ErrorCode res = Interop.InputGesture.SetTapCb(_handler, null, IntPtr.Zero);
                    ThrowIfError(res);
                }
            }
        }
        /// <summary>
        /// Emits the event when the palm cover event comes
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        internal event EventHandler<PalmCoverEventArgs> PalmCoverEventHandler
        {
            add
            {
                if (_palmCoverEventHandler == null)
                {
                    _palmCoverDelegate = (IntPtr userData, GestureState mode,  int duration, int cx, int cy, int size, double pressure) =>
                    {
                        PalmCoverEventArgs args = new PalmCoverEventArgs(mode, duration, cx, cy, size, pressure);
                        Log.Debug(LogTag, "PalmCover Event received. mode: " + mode + ", duration: " + duration);
                        _palmCoverEventHandler?.Invoke(null, args);
                    };
                    Interop.InputGesture.ErrorCode res = Interop.InputGesture.SetPalmCoverCb(_handler, _palmCoverDelegate, IntPtr.Zero);
                    ThrowIfError(res);
                }
                _palmCoverEventHandler += value;
            }
            remove
            {
                _palmCoverEventHandler -= value;
                if (_palmCoverEventHandler == null)
                {
                    Interop.InputGesture.ErrorCode res = Interop.InputGesture.SetPalmCoverCb(_handler, null, IntPtr.Zero);
                    ThrowIfError(res);
                }
            }
        }
    }
}
