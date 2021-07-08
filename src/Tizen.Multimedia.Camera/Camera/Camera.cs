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
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
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
    public partial class Camera : IDisposable, IDisplayable<CameraError>
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;
        private CameraState _state = CameraState.None;
        private CameraDeviceManager _cameraDeviceManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="Camera"/> class.
        /// </summary>
        /// <param name="device">The camera device to access.</param>
        /// <exception cref="ArgumentException">Invalid CameraDevice type.</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="NotSupportedException">The camera feature is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/camera </feature>
        public Camera(CameraDevice device)
        {
            ValidationUtil.ValidateEnum(typeof(CameraDevice), device, nameof(device));

            Create(device);

            Capabilities = new CameraCapabilities(this);
            Settings = new CameraSettings(this);
            DisplaySettings = new CameraDisplaySettings(this);

            RegisterCallbacks();

            SetState(CameraState.Created);
        }

        private void Create(CameraDevice device)
        {
            CameraDeviceType cameraDeviceType = CameraDeviceType.BuiltIn;

            try
            {
                _cameraDeviceManager = new CameraDeviceManager();
                var deviceInfo = _cameraDeviceManager.GetDeviceInformation();
                Log.Info(CameraLog.Tag, deviceInfo?.ToString());

                cameraDeviceType = deviceInfo.First().Type;
            }
            catch (NotSupportedException e)
            {
                Tizen.Log.Info(CameraLog.Tag,
                    $"CameraDeviceManager is not supported. {e.Message}. Not error.");
            }

            if (cameraDeviceType == CameraDeviceType.BuiltIn ||
                cameraDeviceType == CameraDeviceType.Usb)
            {
                Native.Create(device, out _handle).
                    ThrowIfFailed($"Failed to create {cameraDeviceType.ToString()} camera");
            }
            else
            {
                Native.CreateNetworkCamera(device, out _handle).
                    ThrowIfFailed($"Failed to create {cameraDeviceType.ToString()} camera");
            }
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

            Native.StartCapture(_handle, _capturingCallback, _captureCompletedCallback).
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

            Native.StartContinuousCapture(_handle, count, interval, _capturingCallback, _captureCompletedCallback).
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

            Native.StartFaceDetection(_handle, _faceDetectedCallback).
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
    }
}
