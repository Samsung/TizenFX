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
using System.Runtime.InteropServices;
using Tizen.Internals.Errors;
using Tizen.Multimedia;
using System.IO;

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
        private Interop.Camera.CapturingCallback _capturingCallback;
        private Interop.Camera.CaptureCompletedCallback _captureCompletedCallback;
        private Interop.Camera.FaceDetectedCallback _faceDetectedCallback;
        private EventHandler<CameraErrorOccurredEventArgs> _cameraErrorOccurred;
        private EventHandler<CameraStateChangedEventArgs> _cameraStateChanged;
        private EventHandler<PreviewEventArgs> _preview;
        private EventHandler<CameraFocusChangedEventArgs> _cameraFocusChanged;
        private EventHandler<CameraInterruptedEventArgs> _cameraInterrupted;
        private EventHandler<HdrCaptureProgressEventArgs> _hdrProgress;
        private EventHandler<MediaPacketPreviewEventArgs> _mediaPacketPreview;
        private readonly CameraFeature _cameraFeature;
        private readonly CameraSetting _cameraSetting;
        private readonly CameraDisplay _cameraDisplay;
        private readonly List<FaceDetectedData> _faces = new List<FaceDetectedData>();
        private Interop.Camera.PreviewCallback _previewCallback;
        Interop.Camera.MediaPacketPreviewCallback _mediaPacketCallback;
        private Interop.Camera.FocusChangedCallback _focusCallback;
        private Interop.Camera.HdrCaptureProgressCallback _hdrProgressCallback;
        private Interop.Camera.StateChangedCallback _stateChangedCallback;
        private Interop.Camera.InterruptedCallback _interruptedCallback;
        private Interop.Camera.ErrorCallback _errorCallback;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tizen.Multimedia.Camera"/> Class.
        /// </summary>
        /// <param name="device">Device.</param>
        public Camera(CameraDevice device)
        {
            int ret = Interop.Camera.Create((int)device, out _handle);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Failed to create camera instance");
            }

            _cameraFeature = new CameraFeature(_handle);
            _cameraSetting = new CameraSetting(_handle);
            _cameraDisplay = new CameraDisplay(_handle);
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

        /// <summary>
        /// Event that occurs when there is change in HDR capture progress.
        /// </summary>
        public event EventHandler<HdrCaptureProgressEventArgs> HdrCaptureProgress
        {
            add
            {
                if (_hdrProgress == null)
                {
                    _hdrProgressCallback = (int percent, IntPtr userData) =>
                    {
                        HdrCaptureProgressEventArgs eventArgs = new HdrCaptureProgressEventArgs(percent);
                        _hdrProgress?.Invoke(this, eventArgs);
                    };
                    int ret = Interop.Camera.SetHdrCaptureProgressCallback(_handle, _hdrProgressCallback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Setting hdr progress callback failed");
                    }
                }

                _hdrProgress += value;
            }

            remove
            {
                _hdrProgress -= value;
                if (_hdrProgress == null)
                {
                    int ret = Interop.Camera.UnsetHdrCaptureProgressCallback(_handle);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Unsetting hdr progress callback failed");
                    }
                }
            }
        }

        /// <summary>
        /// Event that occurs during capture of image.
        /// </summary>
        public event EventHandler<CapturingEventArgs> Capturing;

        /// <summary>
        /// Event that occurs after the capture of the image.
        /// </summary>
        public event EventHandler<EventArgs> CaptureCompleted;

        /// <summary>
        /// Event that occurs when camera state is changed.
        /// </summary>
        public event EventHandler<CameraStateChangedEventArgs> CameraStateChanged
        {
            add
            {
                if (_cameraStateChanged == null)
                {
                    _stateChangedCallback = (CameraState previous, CameraState current, bool byPolicy, IntPtr userData) =>
                    {
                        CameraStateChangedEventArgs eventArgs = new CameraStateChangedEventArgs(previous, current, byPolicy);
                        _cameraStateChanged?.Invoke(this, eventArgs);
                    };
                    int ret = Interop.Camera.SetStateChangedCallback(_handle, _stateChangedCallback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Setting state changed callback failed");
                    }
                }

                _cameraStateChanged += value;
            }

            remove
            {
                _cameraStateChanged -= value;
                if (_cameraStateChanged == null)
                {
                    int ret = Interop.Camera.UnsetStateChangedCallback(_handle);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Unsetting state changed callback failed");
                    }
                }
            }
        }

        /// <summary>
        /// Event that occurs when the auto-focus state of camera changes.
        /// </summary>
        public event EventHandler<CameraFocusChangedEventArgs> CameraFocusChanged
        {
            add
            {
                if (_cameraFocusChanged == null)
                {
                    _focusCallback = (CameraFocusState state, IntPtr userData) =>
                    {
                        CameraFocusChangedEventArgs eventArgs = new CameraFocusChangedEventArgs(state);
                        _cameraFocusChanged?.Invoke(this, eventArgs);
                    };
                    int ret = Interop.Camera.SetFocusChangedCallback(_handle, _focusCallback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Setting focus changed callback failed");
                    }
                }

                _cameraFocusChanged += value;
            }

            remove
            {
                _cameraFocusChanged -= value;
                if (_cameraFocusChanged == null)
                {
                    int ret = Interop.Camera.UnsetFocusChangedCallback(_handle);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Unsetting focus changed callback failed");
                    }
                }
            }
        }

        /// <summary>
        /// Event that occurs when an camera is interrupted by policy.
        /// </summary>
        public event EventHandler<CameraInterruptedEventArgs> CameraInterrupted
        {
            add
            {
                if (_cameraInterrupted == null)
                {
                    _interruptedCallback = (CameraPolicy policy, CameraState previous, CameraState current, IntPtr userData) =>
                    {
                        CameraInterruptedEventArgs eventArgs = new CameraInterruptedEventArgs(policy, previous, current);
                        _cameraInterrupted?.Invoke(this, eventArgs);
                    };
                    int ret = Interop.Camera.SetInterruptedCallback(_handle, _interruptedCallback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Setting interrupt callback failed");
                    }
                }

                _cameraInterrupted += value;
            }

            remove
            {
                _cameraInterrupted -= value;
                if (_cameraInterrupted == null)
                {
                    int ret = Interop.Camera.UnsetInterruptedCallback(_handle);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Unsetting interrupt callback failed");
                    }
                }
            }
        }

        /// <summary>
        /// Event that occurs when there is an asynchronous error.
        /// </summary>
        public event EventHandler<CameraErrorOccurredEventArgs> CameraErrorOccurred
        {
            add
            {
                if (_cameraErrorOccurred == null)
                {
                    _errorCallback = (CameraErrorCode error, CameraState current, IntPtr userData) =>
                    {
                        CameraErrorOccurredEventArgs eventArgs = new CameraErrorOccurredEventArgs(error, current);
                        _cameraErrorOccurred?.Invoke(this, eventArgs);
                    };
                    int ret = Interop.Camera.SetErrorCallback(_handle, _errorCallback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Setting error callback failed");
                    }
                }

                _cameraErrorOccurred += value;
            }

            remove
            {
                _cameraErrorOccurred -= value;
                if (_cameraErrorOccurred == null)
                {
                    int ret = Interop.Camera.UnsetErrorCallback(_handle);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Unsetting error callback failed");
                    }
                }
            }
        }

        /// <summary>
        /// Event that occurs when a face is detected in preview frame.
        /// </summary>
        public event EventHandler<FaceDetectedEventArgs> FaceDetected;

        /// <summary>
        /// Event that occurs once per frame when previewing.
        /// </summary>
        public event EventHandler<PreviewEventArgs> Preview
        {
            add
            {
                if (_preview == null)
                {
                    CreatePreviewCallback();
                }

                _preview += value;
            }

            remove
            {
                _preview -= value;
                if (_preview == null)
                {
                    int ret = Interop.Camera.UnsetPreviewCallback(_handle);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Unsetting preview callback failed");
                    }
                }
            }
        }

        /// <summary>
        /// Event that occurs once per frame when previewing.
        /// </summary>
        public event EventHandler<MediaPacketPreviewEventArgs> MediaPacketPreview
        {
            add
            {
                if (_mediaPacketPreview == null)
                {
                    CreateMediaPacketPreviewCallback();
                }

                _mediaPacketPreview += value;
            }

            remove
            {
                _mediaPacketPreview -= value;
                if (_mediaPacketPreview == null)
                {
                    int ret = Interop.Camera.UnsetMediaPacketPreviewCallback(_handle);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Unsetting media packet preview callback failed");
                    }
                }
            }
        }

        /// <summary>
        /// Get/Set the various camera settings.
        /// </summary>
        public CameraSetting Setting
        {
            get
            {
                return _cameraSetting;
            }
        }

        /// <summary>
        /// Gets the various camera features.
        /// </summary>
        public CameraFeature Feature
        {
            get
            {
                return _cameraFeature;
            }
        }

        /// <summary>
        /// Get/set various camera display properties.
        /// </summary>
        public CameraDisplay Display
        {
            get
            {
                return _cameraDisplay;
            }
        }

        /// <summary>
        /// Gets the state of the camera.
        /// </summary>
        public CameraState State
        {
            get
            {
                int val = 0;

                int ret = Interop.Camera.GetState(_handle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera state, " + (CameraError)ret);
                }

                return (CameraState)val;
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

                int ret = Interop.Camera.GetDisplayReuseHint(_handle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera display reuse hint, " + (CameraError)ret);
                }

                return val;
            }

            set
            {
                int ret = Interop.Camera.SetDisplayReuseHint(_handle, value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set display reuse hint, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set display reuse hint.");
                }
            }
        }

        /// <summary>
        /// Resolution of the preview.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public CameraResolution PreviewResolution
        {
            get
            {
                int width = 0;
                int height = 0;
                int ret = Interop.Camera.GetPreviewResolution(_handle, out width, out height);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera preview resolution, " + (CameraError)ret);
                }

                CameraResolution res = new CameraResolution(width, height);
                return res;
            }

            set
            {
                CameraResolution res = value;
                int ret = Interop.Camera.SetPreviewResolution(_handle, res.Width, res.Height);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set preview resolution, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set preview resolution.");
                }
            }
        }

        /// <summary>
        /// Gets the recommended preview resolution.
        /// </summary>
        /// <remarks>
        /// Depending on the capture resolution aspect ratio and display resolution,
        /// the recommended preview resolution is determined.
        /// </remarks>
        public CameraResolution RecommendedPreviewResolution
        {
            get
            {
                int width = 0;
                int height = 0;
                int ret = Interop.Camera.GetRecommendedPreviewResolution(_handle, out width, out height);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get recommended preview resolution, " + (CameraError)ret);
                }

                CameraResolution res = new CameraResolution(width, height);
                return res;
            }
        }

        /// <summary>
        /// Resolution of the captured image.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public CameraResolution CaptureResolution
        {
            get
            {
                int width = 0;
                int height = 0;
                int ret = Interop.Camera.GetCaptureResolution(_handle, out width, out height);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera capture resolution, " + (CameraError)ret);
                }

                CameraResolution res = new CameraResolution(width, height);
                return res;
            }

            set
            {
                CameraResolution res = value;
                int ret = Interop.Camera.SetCaptureResolution(_handle, res.Width, res.Height);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set capture resolution, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set capture resolution.");
                }
            }
        }

        /// <summary>
        /// Format of an image to be captured.
        /// </summary>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public CameraPixelFormat CaptureFormat
        {
            get
            {
                int val = 0;
                int ret = Interop.Camera.GetCaptureFormat(_handle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera capture format, " + (CameraError)ret);
                }

                return (CameraPixelFormat)val;
            }

            set
            {
                int ret = Interop.Camera.SetCaptureFormat(_handle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set capture format, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set capture format.");
                }
            }
        }

        /// <summary>
        /// The preview data format.
        /// </summary>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public CameraPixelFormat PreviewFormat
        {
            get
            {
                int val = 0;
                int ret = Interop.Camera.GetPreviewFormat(_handle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get preview format, " + (CameraError)ret);
                }

                return (CameraPixelFormat)val;
            }

            set
            {
                int ret = Interop.Camera.SetPreviewFormat(_handle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set preview format, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set preview format.");
                }
            }
        }

        /// <summary>
        /// Gets the facing direction of camera module.
        /// </summary>
        public CameraFacingDirection Direction
        {
            get
            {
                int val = 0;
                int ret = Interop.Camera.GetFacingDirection(_handle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera direction, " + (CameraError)ret);
                }

                return (CameraFacingDirection)val;
            }
        }

        /// <summary>
        /// Gets the camera's flash state.
        /// </summary>
        public CameraFlashState FlashState
        {
            get
            {
                int val = 0;
                int ret = Interop.Camera.GetFlashState(_handle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera flash state, " + (CameraError)ret);
                }

                return (CameraFlashState)val;
            }
        }

        /// <summary>
        /// Gets the camera device count.
        /// </summary>
        /// <remarks>
        /// If the device supports primary and secondary camera, this returns 2.
        /// If 1 is returned, the device only supports primary camera.
        /// </remarks>
        public int CameraCount
        {
            get
            {
                int val = 0;
                int ret = Interop.Camera.GetDeviceCount(_handle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera device count, " + (CameraError)ret);
                }

                return val;
            }
        }

        /// <summary>
        /// Changes the camera device.
        /// </summary>
        /// <param name="device">The hardware camera to access.</param>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <remarks>
        /// This method can be used to change camera device without using destory and create method.
        /// If display reuse is set using <see cref="Tizen.Multimedia.Camera.DisplayReuseHint"/>
        /// before stopping the preview, display handle  will be reused and last frame on display
        /// can be kept even though cameradevice is changed.
        /// </remarks>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations</exception>
        /// <exception cref="NotSupportedException">In case of ChangeDevice feature is not supported</exception>
        public void ChangeDevice(CameraDevice device)
        {
            int ret = Interop.Camera.ChangeDevice(_handle, (int)device);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Failed to change the camera device");
            }
        }

        /// <summary>
        /// Gets the device state.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <param name="device">The device to get state.</param>
        /// <returns>Returns the camera's horizontal position</returns>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported</exception>
        public CameraDeviceState GetDeviceState(CameraDevice device)
        {
            int val = 0;
            int ret = Interop.Camera.GetDeviceState(device, out val);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Failed to get the camera device state.");
            }

            return (CameraDeviceState)val;
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
            int ret = Interop.Camera.StartPreview(_handle);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Failed to start the camera preview.");
            }
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
            int ret = Interop.Camera.StopPreview(_handle);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Failed to stop the camera preview.");
            }
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
            Log.Info(CameraLog.Tag, "StartCapture API starting");

            _capturingCallback = (IntPtr image, IntPtr postview, IntPtr thumbnail, IntPtr userData) =>
            {
                Interop.Camera.ImageDataStruct _img = new Interop.Camera.ImageDataStruct();
                Interop.Camera.ImageDataStruct _post = new Interop.Camera.ImageDataStruct();
                Interop.Camera.ImageDataStruct _thumb = new Interop.Camera.ImageDataStruct();
                ImageData img = new ImageData();
                ImageData post = new ImageData();
                ImageData thumb = new ImageData();

                if (image != IntPtr.Zero)
                {
                    _img = Interop.Camera.IntPtrToImageDataStruct(image);
                    CopyImageData(img, _img);
                }
                if (postview != IntPtr.Zero)
                {
                    _post = Interop.Camera.IntPtrToImageDataStruct(postview);
                    CopyImageData(post, _post);
                }
                if (thumbnail != IntPtr.Zero)
                {
                    _thumb = Interop.Camera.IntPtrToImageDataStruct(thumbnail);
                    CopyImageData(thumb, _thumb);
                }

                CapturingEventArgs eventArgs = new CapturingEventArgs(img, post, thumb);
                Capturing?.Invoke(this, eventArgs);
            };

            _captureCompletedCallback = (IntPtr userData) =>
            {
                EventArgs eventArgs = new EventArgs();
                CaptureCompleted?.Invoke(this, eventArgs);
            };

            int ret = Interop.Camera.StartCapture(_handle, _capturingCallback, _captureCompletedCallback, IntPtr.Zero);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Failed to start the camera capture.");
            }
            Log.Info(CameraLog.Tag, "StartCapture API finished");
        }

        /// <summary>
        /// Aborts continuous capturing.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <exception cref="InvalidOperationException">In case of any invalid operations</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted</exception>
        public void StopContinuousCapture()
        {
            int ret = Interop.Camera.StopContinuousCapture(_handle);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Failed to stop the continuous capture.");
            }
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
        public void StartContinuousCapture(int count, int interval)
        {
            _capturingCallback = (IntPtr image, IntPtr postview, IntPtr thumbnail, IntPtr userData) =>
            {
                Interop.Camera.ImageDataStruct _img = new Interop.Camera.ImageDataStruct();
                Interop.Camera.ImageDataStruct _post = new Interop.Camera.ImageDataStruct();
                Interop.Camera.ImageDataStruct _thumb = new Interop.Camera.ImageDataStruct();
                ImageData img = new ImageData();
                ImageData post = new ImageData();
                ImageData thumb = new ImageData();

                if (image != IntPtr.Zero)
                {
                    _img = Interop.Camera.IntPtrToImageDataStruct(image);
                    CopyImageData(img, _img);
                }
                if (postview != IntPtr.Zero)
                {
                    _post = Interop.Camera.IntPtrToImageDataStruct(postview);
                    CopyImageData(post, _post);
                }
                if (thumbnail != IntPtr.Zero)
                {
                    _thumb = Interop.Camera.IntPtrToImageDataStruct(thumbnail);
                    CopyImageData(thumb, _thumb);
                }

                CapturingEventArgs eventArgs = new CapturingEventArgs(img, post, thumb);
                Capturing?.Invoke(this, eventArgs);
            };

            _captureCompletedCallback = (IntPtr userData) =>
            {
                EventArgs eventArgs = new EventArgs();
                CaptureCompleted?.Invoke(this, eventArgs);
            };

            int ret = Interop.Camera.StartContinuousCapture(_handle, count, interval, _capturingCallback, _captureCompletedCallback, IntPtr.Zero);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Failed to start the continuous capture.");
            }
        }

        /// <summary>
        /// Sets the display handle to show preview images.
        /// </summary>
        /// <param name="displayType">Display type.</param>
        /// <param name="preview">MediaView object to display preview.</param>
        /// <remarks>
        /// This method must be called before StartPreview() method.
        /// In Custom ROI display mode, DisplayRoiArea property must be set before calling this method.
        /// </remarks>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted</exception>
        public void SetDisplay(CameraDisplayType displayType, MediaView preview)
        {
             int ret = Interop.Camera.SetDisplay(_handle, (int)displayType, preview);
             if (ret != (int)CameraError.None)
             {
                 CameraErrorFactory.ThrowException(ret, "Failed to set the camera display.");
             }
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
            int ret = Interop.Camera.StartFocusing(_handle, continuous);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Failed to cancel the camera focus.");
            }
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
        public void CancelFocusing()
        {
            int ret = Interop.Camera.CancelFocusing(_handle);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Failed to cancel the camera focus.");
            }
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
            _faceDetectedCallback = (IntPtr faces, int count, IntPtr userData) =>
            {
                Interop.Camera.DetectedFaceStruct[] faceStruct = new Interop.Camera.DetectedFaceStruct[count];
                IntPtr current = faces;
                for (int i = 0; i < count; i++)
                {
                    faceStruct[i] = Marshal.PtrToStructure<Interop.Camera.DetectedFaceStruct>(current);
                    FaceDetectedData face = new FaceDetectedData(faceStruct[i].id, faceStruct[i].score, faceStruct[i].x, faceStruct[i].y, faceStruct[i].width, faceStruct[i].height);
                    _faces.Add(face);
                    current = (IntPtr)((long)current + Marshal.SizeOf(faceStruct[i]));
                }

                FaceDetectedEventArgs eventArgs = new FaceDetectedEventArgs(_faces);
                FaceDetected?.Invoke(this, eventArgs);
            };

            int ret = Interop.Camera.StartFaceDetection(_handle, _faceDetectedCallback, IntPtr.Zero);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Failed to start the face detection.");
            }
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
            int ret = Interop.Camera.StopFaceDetection(_handle);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Failed to stop the face detection.");
            }
        }

        /// <summary>
        /// DeviceChangedCallback delegate.
        /// </summary>
        public delegate void DeviceChangedCallback(CameraDevice device, CameraDeviceState state, IntPtr userData);

        /// <summary>
        /// set the DeviceStateChanged Callback.
        /// </summary>
        /// <param name="callback">Callback of type <see cref="Tizen.Multimedia.Camera.DeviceChangedCallback"/>.</param>
        /// <param name="callbackId">The Id of registered callback.</param>
        /// <exception cref="InvalidOperationException">In case of any invalid operations</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported</exception>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public static void SetDeviceStateChangedCallback(DeviceChangedCallback callback, out int callbackId)
        {
            int ret = Camera.AddDeviceChangedCallback(callback, IntPtr.Zero, out callbackId);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Setting device state changed callback failed");
            }
        }

        /// <summary>
        /// Unset the DeviceStateChanged Callback.
        /// </summary>
        /// <param name="callbackId">Registered callbackId to be deleted.</param>
        /// <exception cref="InvalidOperationException">In case of any invalid operations</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported</exception>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public static void UnsetDeviceStateChangedCallback(int callbackId)
        {
            int ret = Interop.Camera.UnsetDeviceStateChangedCallback(callbackId);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Unsetting device state changed callback failed");
            }
        }

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

        [DllImport(Interop.Libraries.Camera, EntryPoint = "camera_add_device_state_changed_cb")]
        internal static extern int AddDeviceChangedCallback(DeviceChangedCallback callback, IntPtr userData, out int callbackId);

        internal static void CopyImageData(ImageData image, Interop.Camera.ImageDataStruct img)
        {
            image._data = new byte[img.size];
            if(img.data != IntPtr.Zero)
                Marshal.Copy(img.data, image._data, 0, (int)img.size);
            image._width = img.width;
            image._height = img.height;
            image._format = img.format;
            image._exif = new byte[img.exifSize];
            if (img.exif != IntPtr.Zero)
                Marshal.Copy(img.exif, image._exif, 0, (int)img.exifSize);
        }

        internal static PreviewData CopyPreviewData(Interop.Camera.CameraPreviewDataStruct previewStruct, PlaneType type)
        {
            Log.Info(CameraLog.Tag, "plane type " + type.ToString());
            if (type == PlaneType.SinglePlane)
            {
                SinglePlaneData singleData = new SinglePlaneData();
                singleData.Format = previewStruct.format;
                singleData.Height = previewStruct.height;
                singleData.TimeStamp = previewStruct.timestamp;
                singleData.Width = previewStruct.width;
                Interop.Camera.SinglePlane singlePlane = previewStruct.frameData.singlePlane;
                singleData.YUVData = new byte[singlePlane.yuvsize];

                if (singlePlane.yuvsize > 0)
                    Marshal.Copy(singlePlane.yuv, singleData.YUVData, 0, (int)singlePlane.yuvsize);

                return singleData;
            }
            else if (type == PlaneType.DoublePlane)
            {
                DoublePlaneData doubleData = new DoublePlaneData();
                doubleData.Format = previewStruct.format;
                doubleData.Height = previewStruct.height;
                doubleData.TimeStamp = previewStruct.timestamp;
                doubleData.Width = previewStruct.width;
                Interop.Camera.DoublePlane doublePlane = previewStruct.frameData.doublePlane;
                doubleData.YData = new byte[doublePlane.ysize];
                doubleData.UVData = new byte[doublePlane.uvsize];
                Log.Info(CameraLog.Tag, "ysize " + doublePlane.ysize);
                Log.Info(CameraLog.Tag, "uv size " + doublePlane.uvsize);

                if (doublePlane.ysize > 0)
                    Marshal.Copy(doublePlane.y, doubleData.YData, 0, (int)doublePlane.ysize);

                if (doublePlane.uvsize > 0)
                    Marshal.Copy(doublePlane.uv, doubleData.UVData, 0, (int)doublePlane.uvsize);

                return doubleData;
            }
            else if (type == PlaneType.TriplePlane)
            {
                TriplePlaneData tripleData = new TriplePlaneData();
                tripleData.Format = previewStruct.format;
                tripleData.Height = previewStruct.height;
                tripleData.TimeStamp = previewStruct.timestamp;
                tripleData.Width = previewStruct.width;
                Interop.Camera.TriplePlane triplePlane = previewStruct.frameData.triplePlane;
                tripleData.YData = new byte[triplePlane.ysize];
                tripleData.UData = new byte[triplePlane.usize];
                tripleData.VData = new byte[triplePlane.vsize];

                if (triplePlane.ysize > 0)
                    Marshal.Copy(triplePlane.y, tripleData.YData, 0, (int)triplePlane.ysize);

                if (triplePlane.usize > 0)
                    Marshal.Copy(triplePlane.u, tripleData.UData, 0, (int)triplePlane.usize);

                if (triplePlane.vsize > 0)
                    Marshal.Copy(triplePlane.v, tripleData.VData, 0, (int)triplePlane.vsize);

                return tripleData;
            }
            else
            {
                EncodedPlaneData encodedData = new EncodedPlaneData();
                encodedData.Format = previewStruct.format;
                encodedData.Height = previewStruct.height;
                encodedData.TimeStamp = previewStruct.timestamp;
                encodedData.Width = previewStruct.width;
                Interop.Camera.EncodedPlane encodedPlane = previewStruct.frameData.encodedPlane;
                encodedData.Data = new byte[encodedPlane.size];

                if (encodedPlane.size > 0)
                    Marshal.Copy(encodedPlane.data, encodedData.Data, 0, (int)encodedPlane.size);

                return encodedData;
            }
        }

        private void CreatePreviewCallback()
        {
            Log.Info(CameraLog.Tag, "Create preview callback.");

            _previewCallback = (IntPtr frame, IntPtr userData) =>
            {
                Interop.Camera.CameraPreviewDataStruct _previewStruct = Interop.Camera.IntPtrToCameraPreviewDataStruct(frame);
                PlaneType _type = PlaneType.SinglePlane;
                PreviewData _previewData = new PreviewData();

                if (_previewStruct.format == CameraPixelFormat.H264 || _previewStruct.format == CameraPixelFormat.Jpeg)
                {
                    _type = PlaneType.EncodedPlane;
                    _previewData = CopyPreviewData(_previewStruct, _type);
                }
                else
                {
                    Log.Info(CameraLog.Tag, "Number of plane " + _previewStruct.numOfPlanes);
                    if (_previewStruct.numOfPlanes == 1)
                    {
                        _type = PlaneType.SinglePlane;
                        _previewData = CopyPreviewData(_previewStruct, _type);
                    }
                    else if (_previewStruct.numOfPlanes == 2)
                    {
                        _type = PlaneType.DoublePlane;
                        _previewData = CopyPreviewData(_previewStruct, _type);
                    }
                    else if (_previewStruct.numOfPlanes == 3)
                    {
                        _type = PlaneType.TriplePlane;
                        _previewData = CopyPreviewData(_previewStruct, _type);
                    }
                }

                PreviewEventArgs eventArgs = new PreviewEventArgs(_previewData, _type);

                _preview?.Invoke(this, eventArgs);
            };

            int ret = Interop.Camera.SetPreviewCallback(_handle, _previewCallback, IntPtr.Zero);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Setting preview callback failed");
            }
        }

        private void CreateMediaPacketPreviewCallback()
        {
            _mediaPacketCallback = (IntPtr mediaPacket, IntPtr userData) =>
            {
                MediaPacket packet = MediaPacket.From(mediaPacket);

                MediaPacketPreviewEventArgs eventArgs = new MediaPacketPreviewEventArgs(packet);
                _mediaPacketPreview?.Invoke(this, eventArgs);
            };

            int ret = Interop.Camera.SetMediaPacketPreviewCallback(_handle, _mediaPacketCallback, IntPtr.Zero);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Setting media packet preview callback failed");
            }
        }
    }
}

