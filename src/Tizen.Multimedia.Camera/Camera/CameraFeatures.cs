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
using NativeFeatures = Interop.CameraFeatures;
using NativeSettings = Interop.CameraSettings;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The CameraFeatures class provides properties
    /// to get various capability information of the camera device.
    /// </summary>
    public class CameraFeatures
    {
        internal readonly Camera _camera;

        private List<Size> _previewResolutions;
        private List<Size> _cameraResolutions;
        private List<CameraPixelFormat> _captureFormats;
        private List<CameraPixelFormat> _previewFormats;
        private List<CameraFps> _fps;
        private List<CameraFps> _fpsByResolution;
        private List<CameraAutoFocusMode> _autoFocusModes;
        private List<CameraExposureMode> _exposureModes;
        private List<CameraIsoLevel> _isoLevels;
        private List<CameraTheaterMode> _theaterModes;
        private List<CameraWhiteBalance> _whitebalances;
        private List<CameraFlashMode> _flashModes;
        private List<CameraSceneMode> _sceneModes;
        private List<CameraEffectMode> _effectModes;
        private List<CameraRotation> _streamRotations;
        private List<CameraFlip> _streamFlips;
        private List<CameraPtzType> _ptzTypes;

        private delegate CameraError GetRangeDelegate(IntPtr handle, out int min, out int max);
        private delegate bool IsSupportedDelegate(IntPtr handle);

        internal CameraFeatures(Camera camera)
        {
            _camera = camera;

            IsFaceDetectionSupported = IsFeatureSupported(NativeFeatures.IsFaceDetectionSupported);
            IsMediaPacketPreviewCallbackSupported = IsFeatureSupported(NativeFeatures.IsMediaPacketPreviewCallbackSupported);
            IsZeroShutterLagSupported = IsFeatureSupported(NativeFeatures.IsZeroShutterLagSupported);
            IsContinuousCaptureSupported = IsFeatureSupported(NativeFeatures.IsContinuousCaptureSupported);
            IsHdrCaptureSupported = IsFeatureSupported(NativeFeatures.IsHdrCaptureSupported);
            IsAntiShakeSupported = IsFeatureSupported(NativeFeatures.IsAntiShakeSupported);
            IsVideoStabilizationSupported = IsFeatureSupported(NativeFeatures.IsVideoStabilizationSupported);
            IsAutoContrastSupported = IsFeatureSupported(NativeFeatures.IsAutoContrastSupported);
            IsBrigtnessSupported = CheckRangeValid(NativeSettings.GetBrightnessRange);
            IsExposureSupported = CheckRangeValid(NativeSettings.GetExposureRange);
            IsZoomSupported = CheckRangeValid(NativeSettings.GetZoomRange);
            IsPanSupported = CheckRangeValid(NativeSettings.GetPanRange);
            IsTiltSupported = CheckRangeValid(NativeSettings.GetTiltRange);
        }

        private bool IsFeatureSupported(IsSupportedDelegate func)
        {
            return func(_camera.GetHandle());
        }

        private bool CheckRangeValid(GetRangeDelegate func)
        {
            int min = 0;
            int max = 0;

            CameraErrorFactory.ThrowIfError(func(_camera.GetHandle(), out min, out max),
                "Failed to check feature is suported or not.");

            return min < max;
        }

        /// <summary>
        /// Gets the face detection feature's supported state.
        /// true if supported, otherwise false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsFaceDetectionSupported { get; }

        /// <summary>
        /// Gets the media packet preview callback feature's supported state.
        /// true if supported, otherwise false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsMediaPacketPreviewCallbackSupported { get; }

        /// <summary>
        /// Gets the zero shutter lag feature's supported state.
        /// true if supported, otherwise false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsZeroShutterLagSupported { get; }

        /// <summary>
        /// Gets continuous capture feature's supported state.
        /// true if supported, otherwise false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsContinuousCaptureSupported { get; }

        /// <summary>
        /// Gets the support state of HDR capture.
        /// true if supported, otherwise false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsHdrCaptureSupported { get; }

        /// <summary>
        /// Gets the support state of the anti-shake feature.
        /// true if supported, otherwise false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsAntiShakeSupported { get; }

        /// <summary>
        /// Gets the support state of the video stabilization feature.
        /// true if supported, otherwise false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsVideoStabilizationSupported { get; }

        /// <summary>
        /// Gets the support state of auto contrast feature.
        /// true if supported, otherwise false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsAutoContrastSupported { get; }

        /// <summary>
        /// Gets the support state of brightness feature.
        /// true if supported, otherwise false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsBrigtnessSupported { get; }

        /// <summary>
        /// Gets the support state of exposure feature.
        /// true if supported, otherwise false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsExposureSupported { get; }

        /// <summary>
        /// Gets the support state of zoom feature.
        /// true if supported, otherwise false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsZoomSupported { get; }

        /// <summary>
        /// Gets the support state of pan feature.
        /// true if supported, otherwise false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsPanSupported { get; }

        /// <summary>
        /// Gets the support state of tilt feature.
        /// true if supported, otherwise false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsTiltSupported { get; }

        /// <summary>
        /// Retrieves all the preview resolutions supported by the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// It returns a list containing all the supported preview resolutions.
        /// by recorder.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public IEnumerable<Size> SupportedPreviewResolutions
        {
            get
            {
                if (_previewResolutions == null)
                {
                    try
                    {
                        _previewResolutions = new List<Size>();

                        NativeFeatures.PreviewResolutionCallback callback = (int width, int height, IntPtr userData) =>
                        {
                            _previewResolutions.Add(new Size(width, height));
                            return true;
                        };
                        CameraErrorFactory.ThrowIfError(NativeFeatures.SupportedPreviewResolutions(_camera.GetHandle(), callback, IntPtr.Zero),
                            "Failed to get the supported preview resolutions");
                    }
                    catch
                    {
                        _previewResolutions = null;
                        throw;
                    }
                }

                return _previewResolutions;
            }
        }

        /// <summary>
        /// Retrieves all the capture resolutions supported by the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// It returns a list containing all the supported capture resolutions.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public IEnumerable<Size> SupportedCaptureResolutions
        {
            get
            {
                if (_cameraResolutions == null)
                {
                    try
                    {
                        _cameraResolutions = new List<Size>();

                        NativeFeatures.CaptureResolutionCallback callback = (int width, int height, IntPtr userData) =>
                        {
                            _cameraResolutions.Add(new Size(width, height));
                            return true;
                        };
                        CameraErrorFactory.ThrowIfError(NativeFeatures.SupportedCaptureResolutions(_camera.GetHandle(), callback, IntPtr.Zero),
                            "Failed to get the supported capture resolutions");
                    }
                    catch
                    {
                        _cameraResolutions = null;
                        throw;
                    }
                }

                return _cameraResolutions;
            }
        }

        /// <summary>
        /// Retrieves all the capture formats supported by the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// It returns a list containing all the supported <see cref="CameraPixelFormat"/>.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public IEnumerable<CameraPixelFormat> SupportedCapturePixelFormats
        {
            get
            {
                if (_captureFormats == null)
                {
                    try
                    {
                        _captureFormats = new List<CameraPixelFormat>();

                        NativeFeatures.CaptureFormatCallback callback = (CameraPixelFormat format, IntPtr userData) =>
                        {
                            _captureFormats.Add(format);
                            return true;
                        };
                        CameraErrorFactory.ThrowIfError(NativeFeatures.SupportedCapturePixelFormats(_camera.GetHandle(), callback, IntPtr.Zero),
                            "Failed to get the supported capture formats.");
                    }
                    catch
                    {
                        _captureFormats = null;
                        throw;
                    }
                }

                return _captureFormats;
            }
        }

        /// <summary>
        /// Retrieves all the preview formats supported by the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// It returns a list containing all the supported <see cref="CameraPixelFormat"/>.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public IEnumerable<CameraPixelFormat> SupportedPreviewPixelFormats
        {
            get
            {
                if (_previewFormats == null)
                {
                    try
                    {
                        _previewFormats = new List<CameraPixelFormat>();

                        NativeFeatures.PreviewFormatCallback callback = (CameraPixelFormat format, IntPtr userData) =>
                        {
                            _previewFormats.Add(format);
                            return true;
                        };
                        CameraErrorFactory.ThrowIfError(NativeFeatures.SupportedPreviewPixelFormats(_camera.GetHandle(), callback, IntPtr.Zero),
                            "Failed to get the supported preview formats.");
                    }
                    catch
                    {
                        _previewFormats = null;
                        throw;
                    }
                }

                return _previewFormats;
            }
        }

        /// <summary>
        /// Retrieves all the fps supported by the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// It returns a list containing all the supported <see cref="CameraFps"/>.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public IEnumerable<CameraFps> SupportedPreviewFps
        {
            get
            {
                if (_fps == null)
                {
                    try
                    {
                        _fps = new List<CameraFps>();

                        NativeFeatures.FpsCallback callback = (CameraFps fps, IntPtr userData) =>
                        {
                            _fps.Add(fps);
                            return true;
                        };
                        CameraErrorFactory.ThrowIfError(NativeFeatures.SupportedPreviewFps(_camera.GetHandle(), callback, IntPtr.Zero),
                            "Failed to get the supported camera fps");
                    }
                    catch
                    {
                        _fps = null;
                        throw;
                    }
                }

                return _fps;
            }
        }

        /// <summary>
        /// Retrieves all the fps by resolution supported by the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// It returns a list containing all the supported <see cref="CameraFps"/> by resolution.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public IEnumerable<CameraFps> GetSupportedPreviewFpsByResolution(int width, int height)
        {
            if (_fpsByResolution == null)
            {
                try
                {
                    _fpsByResolution = new List<CameraFps>();

                    NativeFeatures.FpsByResolutionCallback callback = (CameraFps fps, IntPtr userData) =>
                    {
                        _fpsByResolution.Add(fps);
                        return true;
                    };
                    CameraErrorFactory.ThrowIfError(NativeFeatures.SupportedPreviewFpsByResolution(_camera.GetHandle(),
                        width, height, callback, IntPtr.Zero), "Failed to get the supported fps by resolutions.");
                }
                catch
                {
                    _fpsByResolution = null;
                    throw;
                }
            }

            return _fpsByResolution;
        }

        /// <summary>
        /// Retrieves all the fps by resolution supported by the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// It returns a list containing all the supported <see cref="CameraFps"/> by resolution.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public IEnumerable<CameraFps> GetSupportedPreviewFpsByResolution(Size size)
        {
            return GetSupportedPreviewFpsByResolution(size.Width, size.Height);
        }

        /// <summary>
        /// Retrieves all the auto focus modes supported by the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// It returns a list containing all the supported <see cref="CameraAutoFocusMode"/>.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public IEnumerable<CameraAutoFocusMode> SupportedAutoFocusModes
        {
            get
            {
                if (_autoFocusModes == null)
                {
                    try
                    {
                        _autoFocusModes = new List<CameraAutoFocusMode>();

                        NativeFeatures.AfModeCallback callback = (CameraAutoFocusMode mode, IntPtr userData) =>
                        {
                            _autoFocusModes.Add(mode);
                            return true;
                        };
                        CameraErrorFactory.ThrowIfError(NativeFeatures.SupportedAfModes(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported Auto focus modes.");
                    }
                    catch
                    {
                        _autoFocusModes = null;
                        throw;
                    }
                }

                return _autoFocusModes;
            }
        }

        /// <summary>
        /// Retrieves all the exposure modes supported by the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// It returns a list containing all the supported <see cref="CameraExposureMode"/>.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public IEnumerable<CameraExposureMode> SupportedExposureModes
        {
            get
            {
                if (_exposureModes == null)
                {
                    try
                    {
                        _exposureModes = new List<CameraExposureMode>();

                        NativeFeatures.ExposureModeCallback callback = (CameraExposureMode mode, IntPtr userData) =>
                        {
                            _exposureModes.Add(mode);
                            return true;
                        };
                        CameraErrorFactory.ThrowIfError(NativeFeatures.SupportedExposureModes(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported Exposure modes.");
                    }
                    catch
                    {
                        _exposureModes = null;
                        throw;
                    }
                }

                return _exposureModes;
            }
        }

        /// <summary>
        /// Retrieves all the Iso level supported by the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// It returns a list containing all the supported <see cref="CameraIsoLevel"/>.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public IEnumerable<CameraIsoLevel> SupportedIsoLevels
        {
            get
            {
                if (_isoLevels == null)
                {
                    try
                    {
                        _isoLevels = new List<CameraIsoLevel>();

                        NativeFeatures.IsoCallback callback = (CameraIsoLevel iso, IntPtr userData) =>
                        {
                            _isoLevels.Add(iso);
                            return true;
                        };
                        CameraErrorFactory.ThrowIfError(NativeFeatures.SupportedIso(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported Iso levels.");
                    }
                    catch
                    {
                        _isoLevels = null;
                        throw;
                    }
                }

                return _isoLevels;
            }
        }

        /// <summary>
        /// Retrieves all the theater modes supported by the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// It returns a list containing all the supported <see cref="CameraTheaterMode"/>.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public IEnumerable<CameraTheaterMode> SupportedTheaterModes
        {
            get
            {
                if (_theaterModes == null)
                {
                    try
                    {
                        _theaterModes = new List<CameraTheaterMode>();

                        NativeFeatures.TheaterModeCallback callback = (CameraTheaterMode theaterMode, IntPtr userData) =>
                        {
                            _theaterModes.Add(theaterMode);
                            return true;
                        };
                        CameraErrorFactory.ThrowIfError(NativeFeatures.SupportedTheaterModes(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported theater modes.");
                    }
                    catch
                    {
                        _theaterModes = null;
                        throw;
                    }
                }

                return _theaterModes;
            }
        }

        /// <summary>
        /// Retrieves all the whitebalance modes supported by the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// It returns a list containing all the supported <see cref="CameraWhiteBalance"/>.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public IEnumerable<CameraWhiteBalance> SupportedWhiteBalances
        {
            get
            {
                if (_whitebalances == null)
                {
                    try
                    {
                        _whitebalances = new List<CameraWhiteBalance>();

                        NativeFeatures.WhitebalanceCallback callback = (CameraWhiteBalance whiteBalance, IntPtr userData) =>
                        {
                            _whitebalances.Add(whiteBalance);
                            return true;
                        };
                        CameraErrorFactory.ThrowIfError(NativeFeatures.SupportedWhitebalance(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported white balance.");
                    }
                    catch
                    {
                        _whitebalances = null;
                        throw;
                    }
                }

                return _whitebalances;
            }
        }

        /// <summary>
        /// Retrieves all the flash modes supported by the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// It returns a list containing all the supported <see cref="CameraFlashMode"/>.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public IEnumerable<CameraFlashMode> SupportedFlashModes
        {
            get
            {
                if (_flashModes == null)
                {
                    try
                    {
                        _flashModes = new List<CameraFlashMode>();

                        NativeFeatures.FlashModeCallback callback = (CameraFlashMode flashMode, IntPtr userData) =>
                        {
                            _flashModes.Add(flashMode);
                            return true;
                        };
                        CameraErrorFactory.ThrowIfError(NativeFeatures.SupportedFlashModes(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported flash modes.");
                    }
                    catch
                    {
                        _flashModes = null;
                        throw;
                    }
                }

                return _flashModes;
            }
        }

        /// <summary>
        /// Retrieves all the scene modes supported by the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// It returns a list containing all the supported <see cref="CameraSceneMode"/>.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public IEnumerable<CameraSceneMode> SupportedSceneModes
        {
            get
            {
                if (_sceneModes == null)
                {
                    try
                    {
                        _sceneModes = new List<CameraSceneMode>();

                        NativeFeatures.SceneModeCallback callback = (CameraSceneMode sceneMode, IntPtr userData) =>
                        {
                            _sceneModes.Add(sceneMode);
                            return true;
                        };
                        CameraErrorFactory.ThrowIfError(NativeFeatures.SupportedSceneModes(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported scene modes.");
                    }
                    catch
                    {
                        _sceneModes = null;
                        throw;
                    }
                }

                return _sceneModes;
            }
        }

        /// <summary>
        /// Retrieves all the effect modes supported by the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// It returns a list containing all the supported <see cref="CameraEffectMode"/>.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public IEnumerable<CameraEffectMode> SupportedEffects
        {
            get
            {
                if (_effectModes == null)
                {
                    try
                    {
                        _effectModes = new List<CameraEffectMode>();

                        NativeFeatures.EffectCallback callback = (CameraEffectMode effect, IntPtr userData) =>
                        {
                            _effectModes.Add(effect);
                            return true;
                        };
                        CameraErrorFactory.ThrowIfError(NativeFeatures.SupportedEffects(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported camera effects.");
                    }
                    catch
                    {
                        _effectModes = null;
                        throw;
                    }
                }

                return _effectModes;
            }
        }

        /// <summary>
        /// Retrieves all the stream rotation supported by the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// It returns a list containing all the supported <see cref="CameraRotation"/>.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public IEnumerable<CameraRotation> SupportedStreamRotations
        {
            get
            {
                if (_streamRotations == null)
                {
                    try
                    {
                        _streamRotations = new List<CameraRotation>();

                        NativeFeatures.StreamRotationCallback callback = (CameraRotation streamRotation, IntPtr userData) =>
                        {
                            _streamRotations.Add(streamRotation);
                            return true;
                        };
                        CameraErrorFactory.ThrowIfError(NativeFeatures.SupportedStreamRotations(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported camera rotations.");
                    }
                    catch
                    {
                        _streamRotations = null;
                        throw;
                    }
                }

                return _streamRotations;
            }
        }

        /// <summary>
        /// Retrieves all the flips supported by the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// It returns a list containing all the supported <see cref="CameraFlip"/>.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public IEnumerable<CameraFlip> SupportedStreamFlips
        {
            get
            {
                if (_streamFlips == null)
                {
                    try
                    {
                        _streamFlips = new List<CameraFlip>();

                        NativeFeatures.StreamFlipCallback callback = (CameraFlip streamFlip, IntPtr userData) =>
                        {
                            _streamFlips.Add(streamFlip);
                            return true;
                        };
                        CameraErrorFactory.ThrowIfError(NativeFeatures.SupportedStreamFlips(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported camera flips.");
                    }
                    catch
                    {
                        _streamFlips = null;
                        throw;
                    }
                }

                return _streamFlips;
            }
        }

        /// <summary>
        /// Retrieves all the ptz types by the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// It returns a list containing all the supported <see cref="CameraPtzType"/>.
        /// </returns>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public IEnumerable<CameraPtzType> SupportedPtzTypes
        {
            get
            {
                if (_ptzTypes.Count == 0)
                {
                    try
                    {
                        _ptzTypes = new List<CameraPtzType>();

                        NativeFeatures.PtzTypeCallback callback = (CameraPtzType ptzType, IntPtr userData) =>
                        {
                            _ptzTypes.Add(ptzType);
                            return true;
                        };
                        CameraErrorFactory.ThrowIfError(NativeFeatures.SupportedPtzTypes(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported Ptz types.");
                    }
                    catch
                    {
                        _ptzTypes = null;
                        throw;
                    }
                }

                return _ptzTypes;
            }
        }
    }
}
