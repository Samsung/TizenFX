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
using System.Collections;
namespace Tizen.Multimedia
{
    static internal class CameraLog
    {
        internal const string Tag = "Tizen.Multimedia.Camera";
    }

    /// <summary>
    /// The camera class provides methods to capture photos and support setting up notifications
    /// for state changes of capturing, previewing, focusing, information about resolution and binary format
    /// and functions for picture manipulations like sepia negative and many more.
    /// It also notifies you when a significant picture parameter changes e.g. focus.
    /// </summary>
    /// <privilege>
    /// http://tizen.org/privilege/camera
    /// </privilege>
    public class Camera : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;
        private CameraState _state = CameraState.None;
        private static Dictionary<object, int> _callbackIdInfo = new Dictionary<object, int>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Camera"/> Class.
        /// </summary>
        /// <param name="device">The camera device to access</param>
        public Camera(CameraDevice device)
        {
            CameraErrorFactory.ThrowIfError(Interop.Camera.Create((int)device, out _handle),
                "Failed to create camera instance");

            Feature = new CameraFeatures(this);
            Setting = new CameraSettings(this);
            Display = new CameraDisplay(this);

            RegisterCallbacks();

            _state = CameraState.Created;
        }

        /// <summary>
        /// Destructor of the camera class.
        /// </summary>
        ~Camera()
        {
            Dispose(false);
        }

        internal IntPtr GetHandle()
        {
            ValidateNotDisposed();
            return _handle;
        }

#region Dispose support
        /// <summary>
        /// Release any unmanaged resources used by this object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

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
                    Interop.Camera.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }

                _disposed = true;
            }
        }

        internal void ValidateNotDisposed()
        {
            if (_disposed)
            {
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
        /// Event that occurs when an camera is interrupted by policy.
        /// </summary>
        public event EventHandler<CameraInterruptedEventArgs> Interrupted;
        private Interop.Camera.InterruptedCallback _interruptedCallback;

        /// <summary>
        /// Event that occurs when there is an asynchronous error.
        /// </summary>
        public event EventHandler<CameraErrorOccurredEventArgs> ErrorOccurred;
        private Interop.Camera.ErrorCallback _errorCallback;

        /// <summary>
        /// Event that occurs when the auto focus state is changed.
        /// </summary>
        public event EventHandler<CameraFocusStateChangedEventArgs> FocusStateChanged;
        private Interop.Camera.FocusStateChangedCallback _focusStateChangedCallback;

        /// <summary>
        /// Event that occurs when a face is detected in preview frame.
        /// </summary>
        public event EventHandler<FaceDetectedEventArgs> FaceDetected;
        private Interop.Camera.FaceDetectedCallback _faceDetectedCallback;

        /// <summary>
        /// Event that occurs during capture of image.
        /// </summary>
        public event EventHandler<CameraCapturingEventArgs> Capturing;
        private Interop.Camera.CapturingCallback _capturingCallback;

        /// <summary>
        /// Event that occurs after the capture of the image.
        /// </summary>
        public event EventHandler<EventArgs> CaptureCompleted;
        private Interop.Camera.CaptureCompletedCallback _captureCompletedCallback;

        /// <summary>
        /// Event that occurs when there is change in HDR capture progress.
        /// Check whether HdrCapture feature is supported or not before add this EventHandler.
        /// </summary>
        public event EventHandler<HdrCaptureProgressEventArgs> HdrCaptureProgress;
        private Interop.Camera.HdrCaptureProgressCallback _hdrCaptureProgressCallback;

        /// <summary>
        /// Event that occurs when camera state is changed.
        /// </summary>
        public event EventHandler<CameraStateChangedEventArgs> StateChanged;
        private Interop.Camera.StateChangedCallback _stateChangedCallback;

    #region DeviceStateChanged callback
        internal static Interop.Camera.DeviceStateChangedCallback _deviceStateChangedCallback;
        public static event EventHandler<CameraDeviceStateChangedEventArgs> _deviceStateChanged;
        public static object _deviceStateChangedEventLock = new object();

        /// <summary>
        /// Set the DeviceStateChanged Callback.
        /// User doesn't need to create camera instance.
        /// This static EventHandler calls platform function every time because each callback function have to remain its own callbackId.
        /// </summary>
        /// <param name="callback">Callback of type <see cref="Interop.Camera.DeviceStateChangedCallback"/>.</param>
        /// <param name="callbackId">The Id of registered callback.</param>
        /// <exception cref="InvalidOperationException">In case of any invalid operations</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported</exception>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public static event EventHandler<CameraDeviceStateChangedEventArgs> DeviceStateChanged
        {
            add
            {
                lock (_deviceStateChangedEventLock)
                {
                    int callbackId = 0;

                    _deviceStateChangedCallback = (CameraDevice device, CameraDeviceState state, IntPtr userData) =>
                    {
                        _deviceStateChanged?.Invoke(null, new CameraDeviceStateChangedEventArgs(device, state));
                    };
                    CameraErrorFactory.ThrowIfError(Interop.Camera.SetDeviceStateChangedCallback(_deviceStateChangedCallback, IntPtr.Zero, out callbackId),
                        "Failed to set interrupt callback");

                    // Keep current callbackId and EventHandler pair to remove EventHandler later.
                    _callbackIdInfo.Add(value, callbackId);
                    Log.Info(CameraLog.Tag, "add callbackId " + callbackId.ToString());

                    _deviceStateChanged += value;
                }
            }

            remove
            {
                lock (_deviceStateChangedEventLock)
                {
                    _deviceStateChanged -= value;

                    int callbackId = 0;
                    _callbackIdInfo.TryGetValue(value, out callbackId);
                    Log.Info(CameraLog.Tag, "remove callbackId " + callbackId.ToString());

                    CameraErrorFactory.ThrowIfError(Interop.Camera.UnsetDeviceStateChangedCallback(callbackId),
                            "Unsetting media packet preview callback failed");

                    _callbackIdInfo.Remove(value);

                    if (_deviceStateChanged == null)
                    {
                        _deviceStateChangedCallback = null;
                    }
                }
            }
        }
        #endregion DeviceStateChanged callback

    #region Preview EventHandler
        private Interop.Camera.PreviewCallback _previewCallback;
        private event EventHandler<PreviewEventArgs> _preview;
        private object _previewEventLock = new object();
        /// <summary>
        /// Event that occurs once per frame when previewing.
        /// Preview callback is registered when user add callback explicitly to avoid useless P/Invoke.
        /// </summary>
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
                        CameraErrorFactory.ThrowIfError(Interop.Camera.UnsetPreviewCallback(_handle),
                            "Unsetting preview callback failed");
                        _previewCallback = null;
                    }
                }
            }
        }
    #endregion Preview EventHandler

    #region MediaPacketPreview EventHandler
        private Interop.Camera.MediaPacketPreviewCallback _mediaPacketPreviewCallback;
        private EventHandler<MediaPacketPreviewEventArgs> _mediaPacketPreview;
        private object _mediaPacketPreviewEventLock = new object();

        /// <summary>
        /// Event that occurs once per frame when previewing.
        /// Preview callback is registered when user add callback explicitly to avoid useless P/Invoke.
        /// </summary>
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
                        CameraErrorFactory.ThrowIfError(Interop.Camera.UnsetMediaPacketPreviewCallback(_handle),
                            "Unsetting media packet preview callback failed");
                        _mediaPacketPreviewCallback = null;
                    }
                }
            }
        }
    #endregion MediaPacketPreview EventHandler

#endregion EventHandlers

#region Properties
        /// <summary>
        /// Get/Set the various camera settings.
        /// </summary>
        public CameraSettings Setting { get; }

        /// <summary>
        /// Gets the various camera features.
        /// </summary>
        public CameraFeatures Feature { get; }

        /// <summary>
        /// Get/set various camera display properties.
        /// </summary>
        public CameraDisplay Display { get; }

        /// <summary>
        /// Gets the state of the camera.
        /// </summary>
        public CameraState State
        {
            get
            {
                CameraState val = CameraState.None;
                CameraErrorFactory.ThrowIfError(Interop.Camera.GetState(_handle, out val),
                    "Failed to get camera state");

                return val;
            }
        }

        /// <summary>
        /// The hint for display reuse.
        /// If the hint is set to true, the display will be reused when the camera device is changed with
        /// ChangeDevice method.
        /// </summary>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public bool DisplayReuseHint
        {
            get
            {
                bool val = false;

                CameraErrorFactory.ThrowIfError(Interop.Camera.GetDisplayReuseHint(_handle, out val),
                    "Failed to get camera display reuse hint");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.Camera.SetDisplayReuseHint(_handle, value),
                    "Failed to set display reuse hint.");
            }
        }

        /// <summary>
        /// Gets the facing direction of camera module.
        /// </summary>
        public CameraFacingDirection Direction
        {
            get
            {
                CameraFacingDirection val = 0;

                CameraErrorFactory.ThrowIfError(Interop.Camera.GetFacingDirection(_handle, out val),
                    "Failed to get camera direction");

                return val;
            }
        }

        /// <summary>
        /// Gets the camera device count.
        /// </summary>
        /// <remarks>
        /// This returns 2, if the device supports primary and secondary cameras.
        /// Otherwise 1, if the device only supports primary camera.
        /// </remarks>
        public int CameraCount
        {
            get
            {
                int val = 0;

                CameraErrorFactory.ThrowIfError(Interop.Camera.GetDeviceCount(_handle, out val),
                    "Failed to get camera device count");

                return val;
            }
        }
#endregion Properties

#region Methods
        /// <summary>
        /// Changes the camera device.
        /// </summary>
        /// <param name="device">The hardware camera to access.</param>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <remarks>
        /// If display reuse is set using <see cref="DisplayReuseHint"/>
        /// before stopping the preview, the display will be reused and last frame on the display
        /// can be kept even though camera device is changed.
        /// The camera must be in the <see cref="CameraState.Created"/> or <see cref="CameraState.Preview"/> state.
        /// </remarks>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations</exception>
        /// <exception cref="NotSupportedException">In case of ChangeDevice feature is not supported</exception>
        public void ChangeDevice(CameraDevice device)
        {
            ValidateState(CameraState.Created, CameraState.Preview);

            CameraErrorFactory.ThrowIfError(Interop.Camera.ChangeDevice(_handle, (int)device),
                "Failed to change the camera device");
        }

        /// <summary>
        /// Gets the device state.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <param name="device">The device to get state.</param>
        /// <returns>Returns the state of camera device</returns>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported</exception>
        public CameraDeviceState GetDeviceState(CameraDevice device)
        {
            int val = 0;

            CameraErrorFactory.ThrowIfError(Interop.Camera.GetDeviceState(device, out val),
                "Failed to get the camera device state.");

            return (CameraDeviceState)val;
        }

        public static CameraFlashState GetFlashState(CameraDevice device)
        {
            CameraFlashState val = CameraFlashState.NotUsed;

            CameraErrorFactory.ThrowIfError(Interop.Camera.GetFlashState(device, out val),
                "Failed to get camera flash state");

            return val;
        }

        /// <summary>
        /// Starts capturing and drawing preview frames on the screen.
        /// The display handle must be set using <see cref="Tizen.Multimedia.Camera.SetDisplay"/>
        /// before using this method.
        /// If needed set fps <see cref="Tizen.Multimedia.CameraSetting.PreviewFps"/>, preview resolution
        /// <see cref="Tizen.Multimedia.Camera.PreviewResolution"/>, or preview format <see cref="Tizen.Multimedia.Camera.PreviewFormat"/>
        /// before using this method.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <exception cref="InvalidOperationException">In case of any invalid operations</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted</exception>
        public void StartPreview()
        {
            ValidateState(CameraState.Created, CameraState.Captured);

            CameraErrorFactory.ThrowIfError(Interop.Camera.StartPreview(_handle),
                "Failed to start the camera preview.");

            // Update by StateChangedCallback can be delayed for dozens of milliseconds.
            SetState(CameraState.Preview);
        }

        /// <summary>
        /// Stops capturing and drawing preview frames on the screen.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <exception cref="InvalidOperationException">In case of any invalid operations</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted</exception>
        public void StopPreview()
        {
            CameraErrorFactory.ThrowIfError(Interop.Camera.StopPreview(_handle),
                "Failed to stop the camera preview.");

            SetState(CameraState.Created);
        }

        /// <summary>
        /// Starts capturing of still images.
        /// EventHandler must be set for capturing using <see cref="Tizen.Multimedia.Camera.Capturing"/>
        /// and for completed using <see cref="Tizen.Multimedia.Camera.CaptureCompleted"/> before
        /// calling this method.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <remarks>
        /// This function causes the transition of the camera state from Capturing to Captured
        /// automatically and the corresponding EventHandlers will be invoked.
        /// The camera's preview should be restarted by calling <see cref="Tizen.Multimedia.Camera.StartPreview"/>
        /// method.
        /// </remarks>
        /// <exception cref="InvalidOperationException">In case of any invalid operations</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted</exception>
        public void StartCapture()
        {
            ValidateState(CameraState.Preview);

            CameraErrorFactory.ThrowIfError(Interop.Camera.StartCapture(_handle, _capturingCallback, _captureCompletedCallback, IntPtr.Zero),
                "Failed to start the camera capture.");

            SetState(CameraState.Capturing);
        }

        /// <summary>
        /// Starts continuously capturing still images.
        /// EventHandler must be set for capturing using <see cref="Tizen.Multimedia.Camera.Capturing"/>
        /// and for completed using <see cref="Tizen.Multimedia.Camera.CaptureCompleted"/> before
        /// calling this method.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <param name="count">The number of still images.</param>
        /// <param name="interval">The interval of the capture(milliseconds).</param>
        /// <remarks>
        /// If this is not supported zero shutter lag occurs. The capture resolution could be
        /// changed to the preview resolution. This function causes the transition of the camera state
        /// from Capturing to Captured automatically and the corresponding Eventhandlers will be invoked.
        /// Each captured image will be delivered through Eventhandler set using <see cref="Tizen.Multimedia.Camera.Capturing"/> event.
        /// The camera's preview should be restarted by calling <see cref="Tizen.Multimedia.Camera.StartPreview"/> method.
        /// </remarks>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted</exception>
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
                    CameraErrorFactory.ThrowIfError(Interop.Camera.StopContinuousCapture(_handle),
                        "Failed to cancel the continuous capture");
                    SetState(CameraState.Captured);
                });
            }

            CameraErrorFactory.ThrowIfError(Interop.Camera.StartContinuousCapture(_handle, count, interval,
                _capturingCallback, _captureCompletedCallback, IntPtr.Zero), "Failed to start the continuous capture.");

            SetState(CameraState.Capturing);
        }

        /// <summary>
        /// Starts camera auto-focusing, asynchronously.
        /// </summary>
        /// <param name="continuous">Continuous.</param>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <remarks>
        /// If continuous status is true, the camera continuously tries to focus.
        /// </remarks>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted</exception>
        public void StartFocusing(bool continuous)
        {
            ValidateState(CameraState.Preview, CameraState.Captured);

            CameraErrorFactory.ThrowIfError(Interop.Camera.StartFocusing(_handle, continuous),
                "Failed to cancel the camera focus.");
        }

        /// <summary>
        /// Stops camera auto focusing.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <exception cref="InvalidOperationException">In case of any invalid operations</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted</exception>
        public void StopFocusing()
        {
            ValidateState(CameraState.Preview, CameraState.Captured);

            CameraErrorFactory.ThrowIfError(Interop.Camera.CancelFocusing(_handle),
                "Failed to cancel the camera focus.");
        }

        /// <summary>
        /// Starts face detection.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <remarks>
        /// This should be called after <see cref="Tizen.Multimedia.Camera.StartPreview"/> is started.
        /// The Eventhandler set using <see cref="Tizen.Multimedia.Camera.FaceDetected"/> invoked when the face is detected in preview frame.
        /// Internally it starts continuous focus and focusing on the detected face.
        /// </remarks>
        /// <exception cref="InvalidOperationException">In case of any invalid operations</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted</exception>
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
                    current = IntPtr.Add(current, Marshal.SizeOf<Interop.Camera.DetectedFaceStruct>());
                }

                FaceDetected?.Invoke(this, new FaceDetectedEventArgs(result));
            };
            CameraErrorFactory.ThrowIfError(Interop.Camera.StartFaceDetection(_handle, _faceDetectedCallback, IntPtr.Zero),
                "Failed to start face detection");
        }

        /// <summary>
        /// Stops face detection.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <exception cref="InvalidOperationException">In case of any invalid operations</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted</exception>
        public void StopFaceDetection()
        {
            if (_faceDetectedCallback == null)
            {
                throw new InvalidOperationException("The face detection is not started.");
            }

            CameraErrorFactory.ThrowIfError(Interop.Camera.StopFaceDetection(_handle),
                "Failed to stop the face detection.");

            _faceDetectedCallback = null;
        }
#endregion Methods

#region Callback registrations
        public void RegisterCallbacks()
        {
            RegisterErrorCallback();
            RegisterFocusStateChanged();
            RegisterHdrCaptureProgress();
            RegisterInterruptedCallback();
            RegisterStateChangedCallback();

            //Define capturing callback
            _capturingCallback = (IntPtr image, IntPtr postview, IntPtr thumbnail, IntPtr userData) =>
            {
                Capturing?.Invoke(this, new CameraCapturingEventArgs(new ImageData(image),
                    postview == IntPtr.Zero ? null : new ImageData(postview),
                    thumbnail == IntPtr.Zero ? null : new ImageData(thumbnail)));
            };

            //Define captureCompleted callback
            _captureCompletedCallback = _ =>
            {
                SetState(CameraState.Captured);
                CaptureCompleted?.Invoke(this, EventArgs.Empty);
            };
        }

        private void RegisterInterruptedCallback()
        {
            _interruptedCallback = (CameraPolicy policy, CameraState previous, CameraState current, IntPtr userData) =>
            {
                Interrupted?.Invoke(this, new CameraInterruptedEventArgs(policy, previous, current));
            };
            CameraErrorFactory.ThrowIfError(Interop.Camera.SetInterruptedCallback(_handle, _interruptedCallback, IntPtr.Zero),
                "Failed to set interrupt callback");
        }

        private void RegisterErrorCallback()
        {
            _errorCallback = (CameraErrorCode error, CameraState current, IntPtr userData) =>
            {
                ErrorOccurred?.Invoke(this, new CameraErrorOccurredEventArgs(error, current));
            };
            CameraErrorFactory.ThrowIfError(Interop.Camera.SetErrorCallback(_handle, _errorCallback, IntPtr.Zero),
                "Setting error callback failed");
        }

        private void RegisterStateChangedCallback()
        {
            _stateChangedCallback = (CameraState previous, CameraState current, bool byPolicy, IntPtr _) =>
            {
                _state = current;
                Log.Info(CameraLog.Tag, "Camera state changed " + previous.ToString() + " -> " + current.ToString());
                StateChanged?.Invoke(this, new CameraStateChangedEventArgs(previous, current, byPolicy));
            };
            CameraErrorFactory.ThrowIfError(Interop.Camera.SetStateChangedCallback(_handle, _stateChangedCallback, IntPtr.Zero),
                "Setting state changed callback failed");
        }

        private void RegisterFocusStateChanged()
        {
            _focusStateChangedCallback = (CameraFocusState state, IntPtr userData) =>
            {
                FocusStateChanged?.Invoke(this, new CameraFocusStateChangedEventArgs(state));
            };
            CameraErrorFactory.ThrowIfError(Interop.Camera.SetFocusStateChangedCallback(_handle, _focusStateChangedCallback, IntPtr.Zero),
                "Setting focus changed callback failed");
        }

        private void RegisterHdrCaptureProgress()
        {
            //Hdr Capture can not be supported.
            if (Feature.IsHdrCaptureSupported)
            {
                _hdrCaptureProgressCallback = (int percent, IntPtr userData) =>
                {
                    HdrCaptureProgress?.Invoke(this, new HdrCaptureProgressEventArgs(percent));
                };
                CameraErrorFactory.ThrowIfError(Interop.Camera.SetHdrCaptureProgressCallback(_handle, _hdrCaptureProgressCallback, IntPtr.Zero),
                    "Setting Hdr capture progress callback failed");
            }
        }

        private void RegisterPreviewCallback()
        {
            _previewCallback = (IntPtr frame, IntPtr userData) =>
            {
                _preview?.Invoke(this, new PreviewEventArgs(new PreviewData(frame)));
            };
            CameraErrorFactory.ThrowIfError(Interop.Camera.SetPreviewCallback(_handle, _previewCallback, IntPtr.Zero),
                "Setting preview callback failed");
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
                else
                {
                    packet.Dispose();
                }
            };
            CameraErrorFactory.ThrowIfError(Interop.Camera.SetMediaPacketPreviewCallback(_handle, _mediaPacketPreviewCallback, IntPtr.Zero),
                "Setting media packet preview callback failed");
        }
#endregion Callback registrations
    }
}

