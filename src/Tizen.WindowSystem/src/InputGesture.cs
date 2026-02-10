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
using System.Collections.Generic;
using static Tizen.WindowSystem.Interop.InputGesture;

namespace Tizen.WindowSystem
{
    /// <summary>
    /// Class for the Tizen Input Gesture.
    /// Provides gesture detection through standard .NET events.
    /// Register which gestures to detect, then subscribe to events to receive notifications.
    /// Registration and event subscription are order-independent.
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

        // Native handles keyed by gesture parameters
        private readonly Dictionary<(int fingers, GestureEdge edge), IntPtr> _edgeSwipeHandles = new Dictionary<(int, GestureEdge), IntPtr>();
        private readonly Dictionary<(int fingers, GestureEdge edge), IntPtr> _edgeDragHandles = new Dictionary<(int, GestureEdge), IntPtr>();
        private readonly Dictionary<(int fingers, int repeats), IntPtr> _tapHandles = new Dictionary<(int, int), IntPtr>();
        private IntPtr _palmCoverHandle = IntPtr.Zero;

        // Native delegate instances (prevent GC)
        EdgeSwipeCb _edgeSwipeDelegate;
        EdgeDragCb _edgeDragDelegate;
        TapCb _tapDelegate;
        PalmCoverCb _palmCoverDelegate;

        // .NET events
        event EventHandler<EdgeGestureEventArgs> _edgeSwipeDetected;
        event EventHandler<EdgeGestureEventArgs> _edgeDragDetected;
        event EventHandler<TapEventArgs> _tapDetected;
        event EventHandler<PalmCoverEventArgs> _palmCoverDetected;

        /// <summary>
        /// Creates a new InputGesture.
        /// </summary>
        /// <remarks>This module operates in a NUI application and requires instantiation and disposal on the main thread.</remarks>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="Tizen.Applications.Exceptions.PermissionDeniedException">Thrown when the permission is denied.</exception>
        public InputGesture()
        {
            _handler = Interop.InputGesture.Initialize();
            if (_handler.IsInvalid)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                ErrorUtils.ThrowIfError(err, "Failed to initialize InputGesture");
            }

            SetupNativeCallbacks();
            Log.Debug(LogTag, "InputGesture Created");
        }

        /// <summary>
        /// Sets up native callbacks once during construction.
        /// These persist for the lifetime of the InputGesture instance.
        /// </summary>
        void SetupNativeCallbacks()
        {
            _edgeSwipeDelegate = (IntPtr userData, GestureState mode, int fingers, int sx, int sy, GestureEdge edge) =>
            {
                var args = new EdgeGestureEventArgs(mode, fingers, sx, sy, edge);
                Log.Debug(LogTag, "EdgeSwipe Event received. mode: " + mode + ", fingers: " + fingers);
                _edgeSwipeDetected?.Invoke(this, args);
            };
            Interop.InputGesture.ErrorCode res = Interop.InputGesture.SetEdgeSwipeCb(_handler, _edgeSwipeDelegate, IntPtr.Zero);
            ErrorUtils.ThrowIfError((int)res, "Failed to set edge swipe callback");

            _edgeDragDelegate = (IntPtr userData, GestureState mode, int fingers, int cx, int cy, GestureEdge edge) =>
            {
                var args = new EdgeGestureEventArgs(mode, fingers, cx, cy, edge);
                Log.Debug(LogTag, "EdgeDrag Event received. mode: " + mode + ", fingers: " + fingers);
                _edgeDragDetected?.Invoke(this, args);
            };
            res = Interop.InputGesture.SetEdgeDragCb(_handler, _edgeDragDelegate, IntPtr.Zero);
            ErrorUtils.ThrowIfError((int)res, "Failed to set edge drag callback");

            _tapDelegate = (IntPtr userData, GestureState mode, int fingers, int repeats) =>
            {
                var args = new TapEventArgs(mode, fingers, repeats);
                Log.Debug(LogTag, "Tap Event received. mode: " + mode + ", fingers: " + fingers + ", repeats: " + repeats);
                _tapDetected?.Invoke(this, args);
            };
            res = Interop.InputGesture.SetTapCb(_handler, _tapDelegate, IntPtr.Zero);
            ErrorUtils.ThrowIfError((int)res, "Failed to set tap callback");

            _palmCoverDelegate = (IntPtr userData, GestureState mode, int duration, int cx, int cy, int size, double pressure) =>
            {
                var args = new PalmCoverEventArgs(mode, duration, cx, cy, size, pressure);
                Log.Debug(LogTag, "PalmCover Event received. mode: " + mode + ", duration: " + duration);
                _palmCoverDetected?.Invoke(this, args);
            };
            res = Interop.InputGesture.SetPalmCoverCb(_handler, _palmCoverDelegate, IntPtr.Zero);
            ErrorUtils.ThrowIfError((int)res, "Failed to set palm cover callback");
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
            if (disposed) return;

            // Free all native gesture handles
            foreach (var kvp in _edgeSwipeHandles)
                Interop.InputGesture.EdgeSwipeFree(_handler, kvp.Value);
            _edgeSwipeHandles.Clear();

            foreach (var kvp in _edgeDragHandles)
                Interop.InputGesture.EdgeDragFree(_handler, kvp.Value);
            _edgeDragHandles.Clear();

            foreach (var kvp in _tapHandles)
                Interop.InputGesture.TapFree(_handler, kvp.Value);
            _tapHandles.Clear();

            if (_palmCoverHandle != IntPtr.Zero)
            {
                Interop.InputGesture.PalmCoverFree(_handler, _palmCoverHandle);
                _palmCoverHandle = IntPtr.Zero;
            }

            if (disposing)
            {
                _handler?.Dispose();
            }

            disposed = true;
        }

        /// <summary>
        /// Occurs when an edge swipe gesture is detected.
        /// Subscribe to this event and call <see cref="RegisterEdgeSwipe"/> to specify which gestures to detect.
        /// Subscription and registration are order-independent.
        /// </summary>
        public event EventHandler<EdgeGestureEventArgs> EdgeSwipeDetected
        {
            add => _edgeSwipeDetected += value;
            remove => _edgeSwipeDetected -= value;
        }

        /// <summary>
        /// Occurs when an edge drag gesture is detected.
        /// Subscribe to this event and call <see cref="RegisterEdgeDrag"/> to specify which gestures to detect.
        /// Subscription and registration are order-independent.
        /// </summary>
        public event EventHandler<EdgeGestureEventArgs> EdgeDragDetected
        {
            add => _edgeDragDetected += value;
            remove => _edgeDragDetected -= value;
        }

        /// <summary>
        /// Occurs when a tap gesture is detected.
        /// Subscribe to this event and call <see cref="RegisterTap"/> to specify which gestures to detect.
        /// Subscription and registration are order-independent.
        /// </summary>
        public event EventHandler<TapEventArgs> TapDetected
        {
            add => _tapDetected += value;
            remove => _tapDetected -= value;
        }

        /// <summary>
        /// Occurs when a palm cover gesture is detected.
        /// Subscribe to this event and call <see cref="RegisterPalmCover"/> to specify which gestures to detect.
        /// Subscription and registration are order-independent.
        /// </summary>
        public event EventHandler<PalmCoverEventArgs> PalmCoverDetected
        {
            add => _palmCoverDetected += value;
            remove => _palmCoverDetected -= value;
        }

        /// <summary>
        /// Registers an edge swipe gesture to detect.
        /// </summary>
        /// <param name="fingers">The number of fingers.</param>
        /// <param name="edge">The position of edge.</param>
        /// <param name="edgeSize">Optional edge size.</param>
        /// <param name="startPoint">The start point of edge area.</param>
        /// <param name="endPoint">The end point of edge area.</param>
        /// <param name="grabMode">Optional grab mode.</param>
        /// <exception cref="ArgumentException">Thrown when the gesture is already registered or argument is invalid.</exception>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        public void RegisterEdgeSwipe(int fingers, GestureEdge edge, GestureEdgeSize? edgeSize = null, int startPoint = 0, int endPoint = 0, GestureGrabMode? grabMode = null)
        {
            var key = (fingers, edge);
            if (_edgeSwipeHandles.ContainsKey(key))
                throw new ArgumentException("Edge swipe gesture already registered for this (fingers, edge) combination.");

            IntPtr handle = Interop.InputGesture.EdgeSwipeNew(_handler, fingers, edge);
            if (handle == IntPtr.Zero)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                ErrorUtils.ThrowIfError(err, "Failed to create edge swipe gesture");
            }

            if (edgeSize.HasValue)
            {
                var res = Interop.InputGesture.EdgeSwipeSizeSet(handle, edgeSize.Value, startPoint, endPoint);
                if (res != Interop.InputGesture.ErrorCode.None)
                {
                    Interop.InputGesture.EdgeSwipeFree(_handler, handle);
                    ErrorUtils.ThrowIfError((int)res, "Failed to set edge swipe size");
                }
            }

            if (grabMode.HasValue)
            {
                var res = Interop.InputGesture.SetGestureGrabMode(_handler, handle, grabMode.Value);
                if (res != Interop.InputGesture.ErrorCode.None)
                {
                    Interop.InputGesture.EdgeSwipeFree(_handler, handle);
                    ErrorUtils.ThrowIfError((int)res, "Failed to set grab mode");
                }
            }

            var grabRes = Interop.InputGesture.GestureGrab(_handler, handle);
            if (grabRes != Interop.InputGesture.ErrorCode.None)
            {
                Interop.InputGesture.EdgeSwipeFree(_handler, handle);
                ErrorUtils.ThrowIfError((int)grabRes, "Failed to grab edge swipe gesture");
            }

            _edgeSwipeHandles[key] = handle;
            Log.Debug(LogTag, $"RegisterEdgeSwipe fingers: {fingers}, edge: {edge}");
        }

        /// <summary>
        /// Unregisters an edge swipe gesture.
        /// </summary>
        /// <param name="fingers">The number of fingers.</param>
        /// <param name="edge">The position of edge.</param>
        public void UnregisterEdgeSwipe(int fingers, GestureEdge edge)
        {
            var key = (fingers, edge);
            if (_edgeSwipeHandles.TryGetValue(key, out IntPtr handle))
            {
                Interop.InputGesture.GestureUngrab(_handler, handle);
                Interop.InputGesture.EdgeSwipeFree(_handler, handle);
                _edgeSwipeHandles.Remove(key);
            }
        }

        /// <summary>
        /// Sets the size of a registered edge swipe gesture.
        /// </summary>
        /// <param name="fingers">The number of fingers.</param>
        /// <param name="edge">The position of edge.</param>
        /// <param name="edgeSize">The edge size.</param>
        /// <param name="startPoint">The start point of edge area.</param>
        /// <param name="endPoint">The end point of edge area.</param>
        /// <exception cref="ArgumentException">Thrown when gesture is not registered.</exception>
        public void SetEdgeSwipeSize(int fingers, GestureEdge edge, GestureEdgeSize edgeSize, int startPoint, int endPoint)
        {
            var key = (fingers, edge);
            if (!_edgeSwipeHandles.TryGetValue(key, out IntPtr handle))
                throw new ArgumentException("Edge swipe gesture not registered for this (fingers, edge) combination.");

            var res = Interop.InputGesture.EdgeSwipeSizeSet(handle, edgeSize, startPoint, endPoint);
            ErrorUtils.ThrowIfError((int)res, "Failed to set edge swipe size");
        }

        /// <summary>
        /// Registers an edge drag gesture to detect.
        /// </summary>
        /// <param name="fingers">The number of fingers.</param>
        /// <param name="edge">The position of edge.</param>
        /// <param name="edgeSize">Optional edge size.</param>
        /// <param name="startPoint">The start point of edge area.</param>
        /// <param name="endPoint">The end point of edge area.</param>
        /// <param name="grabMode">Optional grab mode.</param>
        /// <exception cref="ArgumentException">Thrown when the gesture is already registered or argument is invalid.</exception>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        public void RegisterEdgeDrag(int fingers, GestureEdge edge, GestureEdgeSize? edgeSize = null, int startPoint = 0, int endPoint = 0, GestureGrabMode? grabMode = null)
        {
            var key = (fingers, edge);
            if (_edgeDragHandles.ContainsKey(key))
                throw new ArgumentException("Edge drag gesture already registered for this (fingers, edge) combination.");

            IntPtr handle = Interop.InputGesture.EdgeDragNew(_handler, fingers, edge);
            if (handle == IntPtr.Zero)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                ErrorUtils.ThrowIfError(err, "Failed to create edge drag gesture");
            }

            if (edgeSize.HasValue)
            {
                var res = Interop.InputGesture.EdgeDragSizeSet(handle, edgeSize.Value, startPoint, endPoint);
                if (res != Interop.InputGesture.ErrorCode.None)
                {
                    Interop.InputGesture.EdgeDragFree(_handler, handle);
                    ErrorUtils.ThrowIfError((int)res, "Failed to set edge drag size");
                }
            }

            if (grabMode.HasValue)
            {
                var res = Interop.InputGesture.SetGestureGrabMode(_handler, handle, grabMode.Value);
                if (res != Interop.InputGesture.ErrorCode.None)
                {
                    Interop.InputGesture.EdgeDragFree(_handler, handle);
                    ErrorUtils.ThrowIfError((int)res, "Failed to set grab mode");
                }
            }

            var grabRes = Interop.InputGesture.GestureGrab(_handler, handle);
            if (grabRes != Interop.InputGesture.ErrorCode.None)
            {
                Interop.InputGesture.EdgeDragFree(_handler, handle);
                ErrorUtils.ThrowIfError((int)grabRes, "Failed to grab edge drag gesture");
            }

            _edgeDragHandles[key] = handle;
            Log.Debug(LogTag, $"RegisterEdgeDrag fingers: {fingers}, edge: {edge}");
        }

        /// <summary>
        /// Unregisters an edge drag gesture.
        /// </summary>
        /// <param name="fingers">The number of fingers.</param>
        /// <param name="edge">The position of edge.</param>
        public void UnregisterEdgeDrag(int fingers, GestureEdge edge)
        {
            var key = (fingers, edge);
            if (_edgeDragHandles.TryGetValue(key, out IntPtr handle))
            {
                Interop.InputGesture.GestureUngrab(_handler, handle);
                Interop.InputGesture.EdgeDragFree(_handler, handle);
                _edgeDragHandles.Remove(key);
            }
        }

        /// <summary>
        /// Sets the size of a registered edge drag gesture.
        /// </summary>
        /// <param name="fingers">The number of fingers.</param>
        /// <param name="edge">The position of edge.</param>
        /// <param name="edgeSize">The edge size.</param>
        /// <param name="startPoint">The start point of edge area.</param>
        /// <param name="endPoint">The end point of edge area.</param>
        /// <exception cref="ArgumentException">Thrown when gesture is not registered.</exception>
        public void SetEdgeDragSize(int fingers, GestureEdge edge, GestureEdgeSize edgeSize, int startPoint, int endPoint)
        {
            var key = (fingers, edge);
            if (!_edgeDragHandles.TryGetValue(key, out IntPtr handle))
                throw new ArgumentException("Edge drag gesture not registered for this (fingers, edge) combination.");

            var res = Interop.InputGesture.EdgeDragSizeSet(handle, edgeSize, startPoint, endPoint);
            ErrorUtils.ThrowIfError((int)res, "Failed to set edge drag size");
        }

        /// <summary>
        /// Registers a tap gesture to detect.
        /// </summary>
        /// <param name="fingers">The number of fingers.</param>
        /// <param name="repeats">The number of repeats.</param>
        /// <param name="grabMode">Optional grab mode.</param>
        /// <exception cref="ArgumentException">Thrown when the gesture is already registered or argument is invalid.</exception>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        public void RegisterTap(int fingers, int repeats, GestureGrabMode? grabMode = null)
        {
            var key = (fingers, repeats);
            if (_tapHandles.ContainsKey(key))
                throw new ArgumentException("Tap gesture already registered for this (fingers, repeats) combination.");

            IntPtr handle = Interop.InputGesture.TapNew(_handler, fingers, repeats);
            if (handle == IntPtr.Zero)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                ErrorUtils.ThrowIfError(err, "Failed to create tap gesture");
            }

            if (grabMode.HasValue)
            {
                var res = Interop.InputGesture.SetGestureGrabMode(_handler, handle, grabMode.Value);
                if (res != Interop.InputGesture.ErrorCode.None)
                {
                    Interop.InputGesture.TapFree(_handler, handle);
                    ErrorUtils.ThrowIfError((int)res, "Failed to set grab mode");
                }
            }

            var grabRes = Interop.InputGesture.GestureGrab(_handler, handle);
            if (grabRes != Interop.InputGesture.ErrorCode.None)
            {
                Interop.InputGesture.TapFree(_handler, handle);
                ErrorUtils.ThrowIfError((int)grabRes, "Failed to grab tap gesture");
            }

            _tapHandles[key] = handle;
            Log.Debug(LogTag, $"RegisterTap fingers: {fingers}, repeats: {repeats}");
        }

        /// <summary>
        /// Unregisters a tap gesture.
        /// </summary>
        /// <param name="fingers">The number of fingers.</param>
        /// <param name="repeats">The number of repeats.</param>
        public void UnregisterTap(int fingers, int repeats)
        {
            var key = (fingers, repeats);
            if (_tapHandles.TryGetValue(key, out IntPtr handle))
            {
                Interop.InputGesture.GestureUngrab(_handler, handle);
                Interop.InputGesture.TapFree(_handler, handle);
                _tapHandles.Remove(key);
            }
        }

        /// <summary>
        /// Registers a palm cover gesture to detect.
        /// </summary>
        /// <param name="grabMode">Optional grab mode.</param>
        /// <exception cref="ArgumentException">Thrown when the gesture is already registered.</exception>
        /// <exception cref="Tizen.Applications.Exceptions.OutOfMemoryException">Thrown when the memory is not enough to allocate.</exception>
        public void RegisterPalmCover(GestureGrabMode? grabMode = null)
        {
            if (_palmCoverHandle != IntPtr.Zero)
                throw new ArgumentException("Palm cover gesture already registered.");

            IntPtr handle = Interop.InputGesture.PalmCoverNew(_handler);
            if (handle == IntPtr.Zero)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                ErrorUtils.ThrowIfError(err, "Failed to create palm cover gesture");
            }

            if (grabMode.HasValue)
            {
                var res = Interop.InputGesture.SetGestureGrabMode(_handler, handle, grabMode.Value);
                if (res != Interop.InputGesture.ErrorCode.None)
                {
                    Interop.InputGesture.PalmCoverFree(_handler, handle);
                    ErrorUtils.ThrowIfError((int)res, "Failed to set grab mode");
                }
            }

            var grabRes = Interop.InputGesture.GestureGrab(_handler, handle);
            if (grabRes != Interop.InputGesture.ErrorCode.None)
            {
                Interop.InputGesture.PalmCoverFree(_handler, handle);
                ErrorUtils.ThrowIfError((int)grabRes, "Failed to grab palm cover gesture");
            }

            _palmCoverHandle = handle;
            Log.Debug(LogTag, "RegisterPalmCover");
        }

        /// <summary>
        /// Unregisters a palm cover gesture.
        /// </summary>
        public void UnregisterPalmCover()
        {
            if (_palmCoverHandle != IntPtr.Zero)
            {
                Interop.InputGesture.GestureUngrab(_handler, _palmCoverHandle);
                Interop.InputGesture.PalmCoverFree(_handler, _palmCoverHandle);
                _palmCoverHandle = IntPtr.Zero;
            }
        }
    }
}
