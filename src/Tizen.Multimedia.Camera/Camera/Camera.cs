/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using static Interop;
using Native = Interop.Camera;

namespace Tizen.Multimedia
{
    static internal class CameraLog
    {
        internal const string Tag = "Tizen.Multimedia.Camera";
        internal const string Enter = "[Enter]";
        internal const string Leave = "[Leave]";
    }

    /// <summary>
    /// This camera class provides methods to capture photos and supports setting up notifications
    /// for state changes of capturing, previewing, focusing, and informing about the resolution and the binary format,
    /// and functions for picture manipulations like sepia, negative, and many more.
    /// It also notifies you when a significant picture parameter changes, (For example, focus).
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// <feature> http://tizen.org/feature/camera </feature>
    public class Camera : IDisposable, IDisplayable<CameraError>
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;
        private CameraState _state = CameraState.None;

        /// <summary>
        /// Initializes a new instance of the <see cref="Camera"/> class.
        /// </summary>
        /// <param name="device">The camera device to access.</param>
        /// <exception cref="ArgumentException">Invalid CameraDevice type.</exception>
        /// <exception cref="NotSupportedException">The camera feature is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/camera </feature>
        public Camera(CameraDevice device)
        {
            Native.Create(device, out _handle).ThrowIfFailed("Failed to create camera instance");

            Capabilities = new CameraCapabilities(this);
            Settings = new CameraSettings(this);
            DisplaySettings = new CameraDisplaySettings(this);

            RegisterCallbacks();

            SetState(CameraState.Created);
        }

        /// <summary>
        /// Finalizes an instance of the Camera class.
        /// </summary>
        ~Camera()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the native handle of the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/camera </feature>
        public IntPtr Handle => GetHandle();

        internal IntPtr GetHandle()
        {
            ValidateNotDisposed();
            return _handle;
        }

        #region Dispose support
        /// <summary>
        /// Releases the unmanaged resources used by the camera.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // to be used if there are any other disposable objects
                }

                if (_handle != IntPtr.Zero)
                {
                    Native.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/camera </feature>
        public void Dispose()
        {
            ReplaceDisplay(null);
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void ValidateNotDisposed()
        {
            if (_disposed)
            {
                Log.Error(CameraLog.Tag, "Camera handle is disposed.");
                throw new ObjectDisposedException(nameof(Camera));
            }
        }
        #endregion Dispose support

        #region Check camera state
        internal void ValidateState(params CameraState[] required)
        {
            ValidateNotDisposed();

            Debug.Assert(required.Length > 0);

            var curState = _state;
            if (!required.Contains(curState))
            {
                throw new InvalidOperationException($"The camera is not in a valid state. " +
                    $"Current State : { curState }, Valid State : { string.Join(", ", required) }.");
            }
        }

        internal void SetState(CameraState state)
        {
            _state = state;
        }
        #endregion Check camera state

        #region EventHandlers
        /// <summary>
        /// An event that occurs when the camera interrupt is started by the policy.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<CameraInterruptStartedEventArgs> InterruptStarted;
        private Native.InterruptStartedCallback _interruptStartedCallback;

        /// <summary>
        /// An event that occurs when an camera is interrupted by the policy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<CameraInterruptedEventArgs> Interrupted;
        private Native.InterruptedCallback _interruptedCallback;

        /// <summary>
        /// An event that occurs when there is an asynchronous error.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<CameraErrorOccurredEventArgs> ErrorOccurred;
        private Native.ErrorCallback _errorCallback;

        /// <summary>
        /// An event that occurs when the auto focus state is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<CameraFocusStateChangedEventArgs> FocusStateChanged;
        private Native.FocusStateChangedCallback _focusStateChangedCallback;

        /// <summary>
        /// An event that occurs when a face is detected in the preview frame.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<FaceDetectedEventArgs> FaceDetected;
        private Native.FaceDetectedCallback _faceDetectedCallback;

        /// <summary>
        /// An event that occurs during capture of an image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<CameraCapturingEventArgs> Capturing;
        private Native.CapturingCallback _capturingCallback;

        /// <summary>
        /// An event that occurs after the capture of the image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<EventArgs> CaptureCompleted;
        private Native.CaptureCompletedCallback _captureCompletedCallback;

        private Native.HdrCaptureProgressCallback _hdrCaptureProgressCallback;
        private event EventHandler<HdrCaptureProgressEventArgs> _hdrCaptureProgress;
        private object _hdrCaptureProgressEventLock = new object();

        /// <summary>
        /// An event that occurs when there is a change in the HDR capture progress.
        /// Checks whether the <see cref="CameraCapabilities.IsHdrCaptureSupported"/> is supported or not before adding this EventHandler.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="NotSupportedException">In case of HDR feature is not supported.</exception>
        public event EventHandler<HdrCaptureProgressEventArgs> HdrCaptureProgress
        {
            add
            {
                lock (_hdrCaptureProgressEventLock)
                {
                    if (_hdrCaptureProgress == null)
                    {
                        RegisterHdrCaptureProgress();
                    }

                    _hdrCaptureProgress += value;
                }
            }

            remove
            {
                lock (_hdrCaptureProgressEventLock)
                {
                    _hdrCaptureProgress -= value;

                    if (_hdrCaptureProgress == null)
                    {
                        UnregisterHdrCaptureProgress();
                    }
                }
            }
        }

        /// <summary>
        /// An event that occurs when the camera state is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<CameraStateChangedEventArgs> StateChanged;
        private Native.StateChangedCallback _stateChangedCallback;

        private static Native.DeviceStateChangedCallback _deviceStateChangedCallback;
        private static event EventHandler<CameraDeviceStateChangedEventArgs> _deviceStateChanged;
        private static object _deviceStateChangedEventLock = new object();
        private static int _deviceStateCallbackId;

        /// <summary>
        /// An event that occurs after the <see cref="CameraDeviceState"/> is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported.</exception>
        /// <exception cref="ArgumentException">In case of invalid parameters.</exception>
        public static event EventHandler<CameraDeviceStateChangedEventArgs> DeviceStateChanged
        {
            add
            {
                lock (_deviceStateChangedEventLock)
                {
                    if (_deviceStateChanged == null)
                    {
                        RegisterDeviceStateChangedCallback();
                    }

                    _deviceStateChanged += value;
                }
            }

            remove
            {
                lock (_deviceStateChangedEventLock)
                {
                    _deviceStateChanged -= value;

                    if (_deviceStateChanged == null)
                    {
                        UnregisterDeviceStateChangedCallback();
                    }
                }
            }
        }

        private Native.PreviewCallback _previewCallback;
        private event EventHandler<PreviewEventArgs> _preview;
        private object _previewEventLock = new object();
        /// <summary>
        /// An event that occurs once per frame when previewing.
        /// Preview callback is registered when an user adds a callback explicitly to avoid useless P/Invoke.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<PreviewEventArgs> Preview
        {
            add
            {
                lock (_previewEventLock)
                {
                    if (_preview == null)
                    {
                        RegisterPreviewCallback();
                    }

                    _preview += value;
                }
            }

            remove
            {
                lock (_previewEventLock)
                {
                    _preview -= value;

                    if (_preview == null)
                    {
                        UnregisterPreviewCallback();
                    }
                }
            }
        }

        private Native.MediaPacketPreviewCallback _mediaPacketPreviewCallback;
        private EventHandler<MediaPacketPreviewEventArgs> _mediaPacketPreview;
        private object _mediaPacketPreviewEventLock = new object();

        /// <summary>
        /// An event that occurs once per frame when previewing.
        /// Preview callback is registered when an user adds a callback explicitly to avoid useless P/Invoke.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<MediaPacketPreviewEventArgs> MediaPacketPreview
        {
            add
            {
                lock (_mediaPacketPreviewEventLock)
                {
                    if (_mediaPacketPreview == null)
                    {
                        RegisterMediaPacketPreviewCallback();
                    }

                    _mediaPacketPreview += value;
                }
            }

            remove
            {
                lock (_mediaPacketPreviewEventLock)
                {
                    _mediaPacketPreview -= value;

                    if (_mediaPacketPreview == null)
                    {
                        UnregisterMediaPacketPreviewCallback();
                    }
                }
            }
        }
        #endregion EventHandlers

        #region Properties
        /// <summary>
        /// Gets or sets the various camera settings.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public CameraSettings Settings { get; }

        /// <summary>
        /// Gets the various camera capabilities.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public CameraCapabilities Capabilities { get; }

        /// <summary>
        /// Get/set various camera display properties.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public CameraDisplaySettings DisplaySettings { get; }

        private Display _display;

        private CameraError SetDisplay(Display display)
        {
            if (display == null)
            {
                return CameraDisplay.SetDisplay(GetHandle(), DisplayType.None, IntPtr.Zero);
            }

            return display.ApplyTo(this);
        }

        private void ReplaceDisplay(Display newDisplay)
        {
            _display?.SetOwner(null);
            _display = newDisplay;
            _display?.SetOwner(this);
        }

        /// <summary>
        /// Sets or gets the display type and handle to show preview images.
        /// The camera must be in the <see cref="CameraState.Created"/> state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// This must be set before the StartPreview() method.
        /// In custom ROI display mode, DisplayRoiArea property must be set before calling this method.
        /// </remarks>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException" > The camera already has been disposed of.</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted.</exception>
        public Display Display
        {
            get
            {
                return _display;
            }

            set
            {
                ValidateState(CameraState.Created);

                if (value?.Owner != null)
                {
                    if (ReferenceEquals(this, value.Owner))
                    {
                        return;
                    }

                    throw new ArgumentException("The display has already been assigned to another.");
                }

                SetDisplay(value).ThrowIfFailed("Failed to set the camera display");

                ReplaceDisplay(value);
            }
        }

        CameraError IDisplayable<CameraError>.ApplyEvasDisplay(DisplayType type, ElmSharp.EvasObject evasObject)
        {
            Debug.Assert(_disposed == false);
            ValidationUtil.ValidateEnum(typeof(DisplayType), type, nameof(type));

            return CameraDisplay.SetDisplay(GetHandle(), type, evasObject);
        }

        CameraError IDisplayable<CameraError>.ApplyEcoreWindow(IntPtr windowHandle)
        {
            Debug.Assert(_disposed == false);

            return CameraDisplay.SetEcoreDisplay(GetHandle(), windowHandle);
        }

        /// <summary>
        /// Gets the state of the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> None, Created, Preview, Capturing, Captured.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public CameraState State
        {
            get
            {
                ValidateNotDisposed();

                CameraState val = CameraState.None;

                Native.GetState(_handle, out val).ThrowIfFailed("Failed to get camera state");

                return val;
            }
        }

        /// <summary>
        /// The hint for the display reuse.
        /// If the hint is set to true, the display will be reused when the camera device is changed with
        /// the ChangeDevice method.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ArgumentException">In case of invalid parameters.</exception>
        /// <exception cref="InvalidOperationException">An invalid state.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public bool DisplayReuseHint
        {
            get
            {
                ValidateNotDisposed();

                Native.GetDisplayReuseHint(_handle, out bool val).ThrowIfFailed("Failed to get camera display reuse hint");

                return val;
            }

            set
            {
                ValidateState(CameraState.Preview);

                Native.SetDisplayReuseHint(_handle, value).ThrowIfFailed("Failed to set display reuse hint.");
            }
        }

        /// <summary>
        /// Gets the facing direction of the camera module.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A <see cref="CameraFacingDirection"/> that specifies the facing direction of the camera device.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public CameraFacingDirection Direction
        {
            get
            {
                ValidateNotDisposed();

                Native.GetFacingDirection(_handle, out var val).ThrowIfFailed("Failed to get camera direction");

                return val;
            }
        }

        /// <summary>
        /// Gets the camera device count.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>This returns 2, if the device supports primary and secondary cameras.
        /// Otherwise 1, if the device only supports primary camera.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public int CameraCount
        {
            get
            {
                ValidateNotDisposed();

                Native.GetDeviceCount(_handle, out int val).ThrowIfFailed("Failed to get camera device count");

                return val;
            }
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Changes the camera device.
        /// </summary>
        /// <param name="device">The hardware camera to access.</param>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <remarks>
        /// If display reuse is set using <see cref="DisplayReuseHint"/>
        /// before stopping the preview, the display will be reused and last frame on the display
        /// can be kept even though camera device is changed.
        /// The camera must be in the <see cref="CameraState.Created"/>.
        /// </remarks>
        /// <exception cref="ArgumentException">In case of invalid parameters.</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="NotSupportedException">In case of the ChangeDevice feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public void ChangeDevice(CameraDevice device)
        {
            ValidateState(CameraState.Created);
            ValidationUtil.ValidateEnum(typeof(CameraDevice), device, nameof(device));

            Native.ChangeDevice(_handle, device).ThrowIfFailed("Failed to change the camera device");
        }

        /// <summary>
        /// Gets the device state.
        /// </summary>
        /// <param name="device">The device to get the state.</param>
        /// <returns>Returns the state of the camera device.</returns>
        /// <since_tizen> 4 </since_tizen>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <exception cref="ArgumentException">In case of invalid parameters.</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported.</exception>
        public static CameraDeviceState GetDeviceState(CameraDevice device)
        {
            ValidationUtil.ValidateEnum(typeof(CameraDevice), device, nameof(device));

            Native.GetDeviceState(device, out var val).ThrowIfFailed("Failed to get the camera device state.");

            return val;
        }

        /// <summary>
        /// Gets the flash state.
        /// </summary>
        /// <param name="device">The device to get the state.</param>
        /// <returns>Returns the flash state of the camera device.</returns>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <exception cref="ArgumentException">In case of invalid parameters.</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported.</exception>
        public static CameraFlashState GetFlashState(CameraDevice device)
        {
            ValidationUtil.ValidateEnum(typeof(CameraDevice), device, nameof(device));

            Native.GetFlashState(device, out var val).ThrowIfFailed("Failed to get camera flash state");

            return val;
        }

        /// <summary>
        /// Starts capturing and drawing preview frames on the screen.
        /// The display property must be set using <see cref="Display"/> before using this method.
        /// If needed set fps <see cref="CameraSettings.PreviewFps"/>, preview resolution
        /// <see cref="CameraSettings.PreviewResolution"/>, or preview format <see cref="CameraSettings.PreviewPixelFormat"/>
        /// before using this method.
        /// The camera must be in the <see cref="CameraState.Created"/> or the <see cref="CameraState.Captured"/> state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege> http://tizen.org/privilege/camera </privilege>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted.</exception>
        public void StartPreview()
        {
            ValidateState(CameraState.Created, CameraState.Captured);

            Native.StartPreview(_handle).ThrowIfFailed("Failed to start the camera preview.");

            // Update by StateChangedCallback can be delayed for dozens of milliseconds.
            SetState(CameraState.Preview);
        }

        /// <summary>
        /// Stops capturing and drawing preview frames on the screen.
        /// The camera must be in the <see cref="CameraState.Preview"/> state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege> http://tizen.org/privilege/camera </privilege>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted.</exception>
        public void StopPreview()
        {
            ValidateState(CameraState.Preview);

            Native.StopPreview(_handle).ThrowIfFailed("Failed to stop the camera preview.");

            SetState(CameraState.Created);
        }

        /// <summary>
        /// Starts capturing of still images.
        /// EventHandler must be set for capturing using <see cref="Capturing"/>
        /// and for completed using <see cref="CaptureCompleted"/> before calling this method.
        /// The camera must be in the <see cref="CameraState.Preview"/> state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege> http://tizen.org/privilege/camera </privilege>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <remarks>
        /// This function causes the transition of the camera state from capturing to captured
        /// automatically and the corresponding EventHandlers will be invoked.
        /// The preview should be restarted by calling the <see cref="StartPreview"/> method after capture is completed.
        /// </remarks>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted.</exception>
        public void StartCapture()
        {
            ValidateState(CameraState.Preview);

            Native.StartCapture(_handle, _capturingCallback, _captureCompletedCallback, IntPtr.Zero).
                ThrowIfFailed("Failed to start the camera capture.");

            SetState(CameraState.Capturing);
        }

        /// <summary>
        /// Starts continuously capturing still images.
        /// EventHandler must be set for capturing using <see cref="Capturing"/>
        /// and for completed using <see cref="CaptureCompleted"/> before calling this method.
        /// The camera must be in the <see cref="CameraState.Preview"/> state.
        /// </summary>
        /// <param name="count">The number of still images.</param>
        /// <param name="interval">The interval of the capture(milliseconds).</param>
        /// <param name="cancellationToken">The cancellation token to cancel capturing.</param>
        /// <seealso cref="CancellationToken"/>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege> http://tizen.org/privilege/camera </privilege>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <remarks>
        /// If this is not supported, zero shutter lag occurs. The capture resolution could be
        /// changed to the preview resolution. This function causes the transition of the camera state
        /// from capturing to captured automatically and the corresponding Eventhandlers will be invoked.
        /// Each captured image will be delivered through Eventhandler set using the <see cref="Capturing"/> event.
        /// The preview should be restarted by calling the <see cref="StartPreview"/> method after capture is completed.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">In case of invalid parameters.</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted.</exception>
        public void StartCapture(int count, int interval, CancellationToken cancellationToken)
        {
            ValidateState(CameraState.Preview);

            if (count < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, $"{nameof(count)} should be greater than one.");
            }

            if (interval < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(interval), interval, $"{nameof(interval)} should be greater than or equal to zero.");
            }

            //Handle CancellationToken
            if (cancellationToken != CancellationToken.None)
            {
                cancellationToken.Register(() =>
                {
                    Native.StopContinuousCapture(_handle).ThrowIfFailed("Failed to cancel the continuous capture");
                    SetState(CameraState.Captured);
                });
            }

            Native.StartContinuousCapture(_handle, count, interval, _capturingCallback, _captureCompletedCallback, IntPtr.Zero).
                ThrowIfFailed("Failed to start the continuous capture.");

            SetState(CameraState.Capturing);
        }

        /// <summary>
        /// Starts camera auto-focusing, asynchronously.
        /// The camera must be in the <see cref="CameraState.Preview"/> or the <see cref="CameraState.Captured"/> state.
        /// </summary>
        /// <param name="continuous">Continuous auto focus.</param>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege> http://tizen.org/privilege/camera </privilege>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <remarks>
        /// If continuous status is true, the camera continuously tries to focus.
        /// </remarks>
        /// <exception cref="ArgumentException">In case of invalid parameters.</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted.</exception>
        public void StartFocusing(bool continuous)
        {
            ValidateState(CameraState.Preview, CameraState.Captured);

            Native.StartFocusing(_handle, continuous).ThrowIfFailed("Failed to cancel the camera focus.");
        }

        /// <summary>
        /// Stops camera auto focusing.
        /// The camera must be in the <see cref="CameraState.Preview"/> or the <see cref="CameraState.Captured"/> state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege> http://tizen.org/privilege/camera </privilege>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted.</exception>
        public void StopFocusing()
        {
            ValidateState(CameraState.Preview, CameraState.Captured);

            Native.CancelFocusing(_handle).ThrowIfFailed("Failed to cancel the camera focus.");
        }

        /// <summary>
        /// Starts face detection.
        /// The camera must be in the <see cref="CameraState.Preview"/> state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege> http://tizen.org/privilege/camera </privilege>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <remarks>
        /// This should be called after <see cref="StartPreview"/> is started.
        /// The Eventhandler set using <see cref="FaceDetected"/> is invoked when the face is detected in the preview frame.
        /// Internally, it starts continuously focus and focusing on the detected face.
        /// </remarks>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted.</exception>
        public void StartFaceDetection()
        {
            ValidateState(CameraState.Preview);

            _faceDetectedCallback = (IntPtr faces, int count, IntPtr userData) =>
            {
                var result = new List<FaceDetectionData>();
                IntPtr current = faces;

                for (int i = 0; i < count; i++)
                {
                    result.Add(new FaceDetectionData(current));
                    current = IntPtr.Add(current, Marshal.SizeOf<Native.DetectedFaceStruct>());
                }

                FaceDetected?.Invoke(this, new FaceDetectedEventArgs(result));
            };

            Native.StartFaceDetection(_handle, _faceDetectedCallback, IntPtr.Zero).
                ThrowIfFailed("Failed to start face detection");
        }

        /// <summary>
        /// Stops face detection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege> http://tizen.org/privilege/camera </privilege>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted.</exception>
        public void StopFaceDetection()
        {
            ValidateNotDisposed();

            if (_faceDetectedCallback == null)
            {
                throw new InvalidOperationException("The face detection is not started.");
            }

            Native.StopFaceDetection(_handle).ThrowIfFailed("Failed to stop the face detection.");

            _faceDetectedCallback = null;
        }
        #endregion Methods

        #region Callback registrations
        private void RegisterCallbacks()
        {
            RegisterErrorCallback();
            RegisterFocusStateChanged();
            RegisterInterruptStartedCallback();
            RegisterInterruptedCallback();
            RegisterStateChangedCallback();

            //Define capturing callback
            _capturingCallback = (IntPtr main, IntPtr postview, IntPtr thumbnail, IntPtr userData) =>
            {
                Capturing?.Invoke(this, new CameraCapturingEventArgs(new StillImage(main),
                    postview == IntPtr.Zero ? null : new StillImage(postview),
                    thumbnail == IntPtr.Zero ? null : new StillImage(thumbnail)));
            };

            //Define captureCompleted callback
            _captureCompletedCallback = _ =>
            {
                SetState(CameraState.Captured);
                CaptureCompleted?.Invoke(this, EventArgs.Empty);
            };
        }

        private void RegisterInterruptStartedCallback()
        {
            _interruptStartedCallback = (CameraPolicy policy, CameraState state, IntPtr userData) =>
            {
                InterruptStarted?.Invoke(this, new CameraInterruptStartedEventArgs(policy, state));
            };

            Native.SetInterruptStartedCallback(_handle, _interruptStartedCallback, IntPtr.Zero).
                ThrowIfFailed("Failed to set interrupt callback");
        }

        private void RegisterInterruptedCallback()
        {
            _interruptedCallback = (CameraPolicy policy, CameraState previous, CameraState current, IntPtr userData) =>
            {
                Interrupted?.Invoke(this, new CameraInterruptedEventArgs(policy, previous, current));
            };

            Native.SetInterruptedCallback(_handle, _interruptedCallback, IntPtr.Zero).
                ThrowIfFailed("Failed to set interrupt callback");
        }

        private void RegisterErrorCallback()
        {
            _errorCallback = (CameraErrorCode error, CameraState current, IntPtr userData) =>
            {
                ErrorOccurred?.Invoke(this, new CameraErrorOccurredEventArgs(error, current));
            };

            Native.SetErrorCallback(_handle, _errorCallback, IntPtr.Zero).ThrowIfFailed("Setting error callback failed");
        }

        private void RegisterStateChangedCallback()
        {
            _stateChangedCallback = (CameraState previous, CameraState current, bool byPolicy, IntPtr _) =>
            {
                SetState(current);
                Log.Info(CameraLog.Tag, "Camera state changed " + previous.ToString() + " -> " + current.ToString());
                StateChanged?.Invoke(this, new CameraStateChangedEventArgs(previous, current, byPolicy));
            };

            Native.SetStateChangedCallback(_handle, _stateChangedCallback, IntPtr.Zero).
                ThrowIfFailed("Setting state changed callback failed");
        }

        private static void RegisterDeviceStateChangedCallback()
        {
            _deviceStateChangedCallback = (CameraDevice device, CameraDeviceState state, IntPtr userData) =>
            {
                _deviceStateChanged?.Invoke(null, new CameraDeviceStateChangedEventArgs(device, state));
            };

            Native.SetDeviceStateChangedCallback(_deviceStateChangedCallback, IntPtr.Zero, out _deviceStateCallbackId).
                ThrowIfFailed("Failed to set device state changed callback");

            Log.Info(CameraLog.Tag, "add callbackId " + _deviceStateCallbackId.ToString());
        }

        private static void UnregisterDeviceStateChangedCallback()
        {
            Native.UnsetDeviceStateChangedCallback(_deviceStateCallbackId).
                ThrowIfFailed("Unsetting device state changed callback failed");

            _deviceStateChangedCallback = null;
            _deviceStateCallbackId = 0;
        }

        private void RegisterFocusStateChanged()
        {
            _focusStateChangedCallback = (CameraFocusState state, IntPtr userData) =>
            {
                FocusStateChanged?.Invoke(this, new CameraFocusStateChangedEventArgs(state));
            };

            Native.SetFocusStateChangedCallback(_handle, _focusStateChangedCallback, IntPtr.Zero).
                ThrowIfFailed("Setting focus changed callback failed");
        }

        private void RegisterHdrCaptureProgress()
        {
            _hdrCaptureProgressCallback = (int percent, IntPtr userData) =>
            {
                _hdrCaptureProgress?.Invoke(this, new HdrCaptureProgressEventArgs(percent));
            };

            Native.SetHdrCaptureProgressCallback(_handle, _hdrCaptureProgressCallback, IntPtr.Zero).
                ThrowIfFailed("Setting Hdr capture progress callback failed");
        }

        private void UnregisterHdrCaptureProgress()
        {
            Native.UnsetHdrCaptureProgressCallback(_handle).
                ThrowIfFailed("Unsetting hdr capture progress is failed");

            _hdrCaptureProgressCallback = null;
        }

        private void RegisterPreviewCallback()
        {
            _previewCallback = (IntPtr frame, IntPtr userData) =>
            {
                _preview?.Invoke(this, new PreviewEventArgs(new PreviewFrame(frame)));
            };

            Native.SetPreviewCallback(_handle, _previewCallback, IntPtr.Zero).
                ThrowIfFailed("Setting preview callback failed");
        }

        private void UnregisterPreviewCallback()
        {
            Native.UnsetPreviewCallback(_handle).ThrowIfFailed("Unsetting preview callback failed");

            _previewCallback = null;
        }

        private void RegisterMediaPacketPreviewCallback()
        {
            _mediaPacketPreviewCallback = (IntPtr mediaPacket, IntPtr userData) =>
            {
                MediaPacket packet = MediaPacket.From(mediaPacket);

                var eventHandler = _mediaPacketPreview;

                if (eventHandler != null)
                {
                    eventHandler.Invoke(this, new MediaPacketPreviewEventArgs(packet));
                }

                packet.Dispose();
            };

            Native.SetMediaPacketPreviewCallback(_handle, _mediaPacketPreviewCallback, IntPtr.Zero).
                ThrowIfFailed("Setting media packet preview callback failed");
        }

        private void UnregisterMediaPacketPreviewCallback()
        {
            Native.UnsetMediaPacketPreviewCallback(_handle).
                ThrowIfFailed("Unsetting media packet preview callback failed");

            _mediaPacketPreviewCallback = null;
        }
        #endregion Callback registrations
    }
}
