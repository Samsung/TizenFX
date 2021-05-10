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
using System.ComponentModel;
using Native = Interop.Camera;

namespace Tizen.Multimedia
{
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

        private Native.ExtraPreviewCallback _extraPreviewCallback;
        private event EventHandler<ExtraPreviewEventArgs> _extraPreview;
        /// <summary>
        /// An event that occurs once per frame when previewing.
        /// Preview callback is registered when an user adds a callback explicitly to avoid useless P/Invoke.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ExtraPreviewEventArgs> ExtraPreview
        {
            add
            {
                if (_extraPreview == null)
                {
                    RegisterExtraPreviewCallback();
                }

                _extraPreview += value;
            }

            remove
            {
                _extraPreview -= value;

                if (_extraPreview == null)
                {
                    UnregisterExtraPreviewCallback();
                }
            }
        }

        private void RegisterCallbacks()
        {
            RegisterErrorCallback();
            RegisterFocusStateChanged();
            RegisterInterruptStartedCallback();
            RegisterInterruptedCallback();
            RegisterStateChangedCallback();

            //Define capturing callback
            _capturingCallback = (main, postview, thumbnail, userData) =>
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
            _interruptStartedCallback = (policy, state, _) =>
            {
                InterruptStarted?.Invoke(this, new CameraInterruptStartedEventArgs(policy, state));
            };

            Native.SetInterruptStartedCallback(_handle, _interruptStartedCallback).
                ThrowIfFailed("Failed to set interrupt callback.");
        }

        private void RegisterInterruptedCallback()
        {
            _interruptedCallback = (policy, previous, current, _) =>
            {
                Interrupted?.Invoke(this, new CameraInterruptedEventArgs(policy, previous, current));
            };

            Native.SetInterruptedCallback(_handle, _interruptedCallback).
                ThrowIfFailed("Failed to set interrupt callback.");
        }

        private void RegisterErrorCallback()
        {
            _errorCallback = (error, current, _) =>
            {
                ErrorOccurred?.Invoke(this, new CameraErrorOccurredEventArgs(error, current));
            };

            Native.SetErrorCallback(_handle, _errorCallback).
                ThrowIfFailed("Setting error callback failed");
        }

        private void RegisterStateChangedCallback()
        {
            _stateChangedCallback = (previous, current, byPolicy, _) =>
            {
                SetState(current);
                Log.Info(CameraLog.Tag, "Camera state changed " + previous.ToString() + " -> " + current.ToString());
                StateChanged?.Invoke(this, new CameraStateChangedEventArgs(previous, current, byPolicy));
            };

            Native.SetStateChangedCallback(_handle, _stateChangedCallback).
                ThrowIfFailed("Failed to set state changed callback.");
        }

        private static void RegisterDeviceStateChangedCallback()
        {
            _deviceStateChangedCallback = (device, state, _) =>
            {
                _deviceStateChanged?.Invoke(null, new CameraDeviceStateChangedEventArgs(device, state));
            };

            Native.SetDeviceStateChangedCallback(_deviceStateChangedCallback, IntPtr.Zero, out _deviceStateCallbackId).
                ThrowIfFailed("Failed to set device state changed callback.");

            Log.Info(CameraLog.Tag, "add callbackId " + _deviceStateCallbackId.ToString());
        }

        private static void UnregisterDeviceStateChangedCallback()
        {
            Native.UnsetDeviceStateChangedCallback(_deviceStateCallbackId).
                ThrowIfFailed("Failed to unset device state changed callback.");

            _deviceStateChangedCallback = null;
            _deviceStateCallbackId = 0;
        }

        private void RegisterFocusStateChanged()
        {
            _focusStateChangedCallback = (state, _) =>
            {
                FocusStateChanged?.Invoke(this, new CameraFocusStateChangedEventArgs(state));
            };

            Native.SetFocusStateChangedCallback(_handle, _focusStateChangedCallback).
                ThrowIfFailed("Failed to set focus changed callback.");
        }

        private void RegisterHdrCaptureProgress()
        {
            _hdrCaptureProgressCallback = (percent, _) =>
            {
                _hdrCaptureProgress?.Invoke(this, new HdrCaptureProgressEventArgs(percent));
            };

            Native.SetHdrCaptureProgressCallback(_handle, _hdrCaptureProgressCallback).
                ThrowIfFailed("Failed to set Hdr capture progress callback.");
        }

        private void UnregisterHdrCaptureProgress()
        {
            Native.UnsetHdrCaptureProgressCallback(_handle).
                ThrowIfFailed("Failed to unset hdr capture progres callback.");

            _hdrCaptureProgressCallback = null;
        }

        private void RegisterPreviewCallback()
        {
            _previewCallback = (frame, _) =>
            {
                _preview?.Invoke(this, new PreviewEventArgs(new PreviewFrame(frame)));
            };

            Native.SetPreviewCallback(_handle, _previewCallback).
                ThrowIfFailed("Failed to set preview callback.");
        }

        private void UnregisterPreviewCallback()
        {
            Native.UnsetPreviewCallback(_handle).
                ThrowIfFailed("Failed to unset preview callback.");

            _previewCallback = null;
        }

        private void RegisterMediaPacketPreviewCallback()
        {
            _mediaPacketPreviewCallback = (mediaPacket, _) =>
            {
                MediaPacket packet = MediaPacket.From(mediaPacket);

                var eventHandler = _mediaPacketPreview;

                if (eventHandler != null)
                {
                    eventHandler.Invoke(this, new MediaPacketPreviewEventArgs(packet));
                }

                packet.Dispose();
            };

            Native.SetMediaPacketPreviewCallback(_handle, _mediaPacketPreviewCallback).
                ThrowIfFailed("Failed to set media packet preview callback.");
        }

        private void UnregisterMediaPacketPreviewCallback()
        {
            Native.UnsetMediaPacketPreviewCallback(_handle).
                ThrowIfFailed("Failed to unset media packet preview callback.");

            _mediaPacketPreviewCallback = null;
        }

        private void RegisterExtraPreviewCallback()
        {
            _extraPreviewCallback = (frame, streamId, _) =>
            {
                _extraPreview?.Invoke(this, new ExtraPreviewEventArgs(new PreviewFrame(frame), streamId));
            };

            Native.SetExtraPreviewCallback(_handle, _extraPreviewCallback).
                ThrowIfFailed("Failed to set extra preview callback.");
        }

        private void UnregisterExtraPreviewCallback()
        {
            Native.UnsetPreviewCallback(_handle).
                ThrowIfFailed("Failed to unset preview callback.");

            _extraPreviewCallback = null;
        }
    }
}