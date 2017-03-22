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
using Tizen.Internals.Errors;


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

        private delegate int GetRangeDelegate(IntPtr handle, out int min, out int max);
        private delegate bool IsSupportedDelegate(IntPtr handle);

        internal CameraFeatures(Camera camera)
        {
            _camera = camera;

            IsFaceDetectionSupported = IsFeatureSupported(Interop.CameraFeatures.IsFaceDetectionSupported);
            IsMediaPacketPreviewCallbackSupported = IsFeatureSupported(Interop.CameraFeatures.IsMediaPacketPreviewCallbackSupported);
            IsZeroShutterLagSupported = IsFeatureSupported(Interop.CameraFeatures.IsZeroShutterLagSupported);
            IsContinuousCaptureSupported = IsFeatureSupported(Interop.CameraFeatures.IsContinuousCaptureSupported);
            IsHdrCaptureSupported = IsFeatureSupported(Interop.CameraFeatures.IsHdrCaptureSupported);
            IsAntiShakeSupported = IsFeatureSupported(Interop.CameraFeatures.IsAntiShakeSupported);
            IsVideoStabilizationSupported = IsFeatureSupported(Interop.CameraFeatures.IsVideoStabilizationSupported);
            IsAutoContrastSupported = IsFeatureSupported(Interop.CameraFeatures.IsAutoContrastSupported);
            IsBrigtnessSupported = CheckRangeValid(Interop.CameraSettings.GetBrightnessRange);
            IsExposureSupported = CheckRangeValid(Interop.CameraSettings.GetExposureRange);
            IsZoomSupported = CheckRangeValid(Interop.CameraSettings.GetZoomRange);
            IsPanSupported = CheckRangeValid(Interop.CameraSettings.GetPanRange);
            IsTiltSupported = CheckRangeValid(Interop.CameraSettings.GetTiltRange);
        }

        private bool IsFeatureSupported(IsSupportedDelegate func)
        {
            return func(_camera.GetHandle());
        }

        private bool CheckRangeValid(GetRangeDelegate func)
        {
            int min = 0;
            int max = 0;

            CameraErrorFactory.ThrowIfError(func(_camera.GetHandle(), out min, out max), "Failed to check feature is suported or not.");

            return min < max;
        }

        /// <summary>
        /// Gets the face detection feature's supported state.
        /// true if supported, otherwise false.
        /// </summary>
        public bool IsFaceDetectionSupported { get; }

        /// <summary>
        /// Gets the media packet preview callback feature's supported state.
        /// true if supported, otherwise false.
        /// </summary>
        public bool IsMediaPacketPreviewCallbackSupported { get; }

        /// <summary>
        /// Gets the zero shutter lag feature's supported state.
        /// true if supported, otherwise false.
        /// </summary>
        public bool IsZeroShutterLagSupported { get; }

        /// <summary>
        /// Gets continuous capture feature's supported state.
        /// true if supported, otherwise false.
        /// </summary>
        public bool IsContinuousCaptureSupported { get; }

        /// <summary>
        /// Gets the support state of HDR capture.
        /// true if supported, otherwise false.
        /// </summary>
        public bool IsHdrCaptureSupported { get; }

        /// <summary>
        /// Gets the support state of the anti-shake feature.
        /// true if supported, otherwise false.
        /// </summary>
        public bool IsAntiShakeSupported { get; }

        /// <summary>
        /// Gets the support state of the video stabilization feature.
        /// true if supported, otherwise false.
        /// </summary>
        public bool IsVideoStabilizationSupported { get; }

        /// <summary>
        /// Gets the support state of auto contrast feature.
        /// true if supported, otherwise false.
        /// </summary>
        public bool IsAutoContrastSupported { get; }

        /// <summary>
        /// Gets the support state of brightness feature.
        /// true if supported, otherwise false.
        /// </summary>
        public bool IsBrigtnessSupported { get; }

        /// <summary>
        /// Gets the support state of exposure feature.
        /// true if supported, otherwise false.
        /// </summary>
        public bool IsExposureSupported { get; }

        /// <summary>
        /// Gets the support state of zoom feature.
        /// true if supported, otherwise false.
        /// </summary>
        public bool IsZoomSupported { get; }

        /// <summary>
        /// Gets the support state of pan feature.
        /// true if supported, otherwise false.
        /// </summary>
        public bool IsPanSupported { get; }

        /// <summary>
        /// Gets the support state of tilt feature.
        /// true if supported, otherwise false.
        /// </summary>
        public bool IsTiltSupported { get; }

        /// <summary>
        /// Retrieves all the preview resolutions supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported preview resolutions.
        /// by recorder.
        /// </returns>
        public IEnumerable<Size> SupportedPreviewResolutions
        {
            get
            {
                if (_previewResolutions == null)
                {
                    _previewResolutions = new List<Size>();

                    Interop.CameraFeatures.PreviewResolutionCallback callback = (int width, int height, IntPtr userData) =>
                    {
                        _previewResolutions.Add(new Size(width, height));
                        return true;
                    };
                    CameraErrorFactory.ThrowIfError(Interop.CameraFeatures.SupportedPreviewResolutions(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported preview resolutions");
                }

                return _previewResolutions;
            }
        }

        /// <summary>
        /// Retrieves all the capture resolutions supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported capture resolutions.
        /// </returns>
        public IEnumerable<Size> SupportedCaptureResolutions
        {
            get
            {
                if (_cameraResolutions == null)
                {
                    _cameraResolutions = new List<Size>();

                    Interop.CameraFeatures.CaptureResolutionCallback callback = (int width, int height, IntPtr userData) =>
                    {
                        _cameraResolutions.Add(new Size(width, height));
                        return true;
                    };
                    CameraErrorFactory.ThrowIfError(Interop.CameraFeatures.SupportedCaptureResolutions(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported capture resolutions");
                }

                return _cameraResolutions;
            }
        }

        /// <summary>
        /// Retrieves all the capture formats supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported capture formats.
        /// </returns>
        public IEnumerable<CameraPixelFormat> SupportedCapturePixelFormats
        {
            get
            {
                if (_captureFormats == null)
                {
                    _captureFormats = new List<CameraPixelFormat>();

                    Interop.CameraFeatures.CaptureFormatCallback callback = (CameraPixelFormat format, IntPtr userData) =>
                    {
                        _captureFormats.Add(format);
                        return true;
                    };
                    CameraErrorFactory.ThrowIfError(Interop.CameraFeatures.SupportedCapturePixelFormats(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported capture formats.");
                }

                return _captureFormats;
            }
        }

        /// <summary>
        /// Retrieves all the preview formats supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported preview formats.
        /// </returns>
        public IEnumerable<CameraPixelFormat> SupportedPreviewPixelFormats
        {
            get
            {
                if (_previewFormats == null)
                {
                    _previewFormats = new List<CameraPixelFormat>();

                    Interop.CameraFeatures.PreviewFormatCallback callback = (CameraPixelFormat format, IntPtr userData) =>
                    {
                        _previewFormats.Add(format);
                        return true;
                    };
                    CameraErrorFactory.ThrowIfError(Interop.CameraFeatures.SupportedPreviewPixelFormats(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported preview formats.");
                }

                return _previewFormats;
            }
        }

        /// <summary>
        /// Retrieves all the fps supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported fps.
        /// </returns>
        public IEnumerable<CameraFps> SupportedPreviewFps
        {
            get
            {
                if (_fps == null)
                {
                    _fps = new List<CameraFps>();

                    Interop.CameraFeatures.FpsCallback callback = (CameraFps fps, IntPtr userData) =>
                    {
                        _fps.Add(fps);
                        return true;
                    };
                    CameraErrorFactory.ThrowIfError(Interop.CameraFeatures.SupportedPreviewFps(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported camera fps");
                }

                return _fps;
            }
        }

        /// <summary>
        /// Retrieves all the fps by resolution supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported fps by resolution.
        /// </returns>
        public IEnumerable<CameraFps> GetSupportedPreviewFpsByResolution(int width, int height)
        {
            var result = new List<CameraFps>();

            Interop.CameraFeatures.FpsByResolutionCallback callback = (CameraFps fps, IntPtr userData) =>
            {
                result.Add(fps);
                return true;
            };
            CameraErrorFactory.ThrowIfError(Interop.CameraFeatures.SupportedPreviewFpsByResolution(_camera.GetHandle(),
                width, height, callback, IntPtr.Zero), "Failed to get the supported fps by resolutions.");

            return result;
        }

        /// <summary>
        /// Retrieves all the fps by resolution supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported fps by resolution.
        /// </returns>
        public IEnumerable<CameraFps> GetSupportedPreviewFpsByResolution(Size size)
        {
            return GetSupportedPreviewFpsByResolution(size.Width, size.Height);
        }

        /// <summary>
        /// Retrieves all the fps by resolution supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported fps by resolution.
        /// </returns>
        public IEnumerable<CameraAutoFocusMode> SupportedAutoFocusModes
        {
            get
            {
                if (_autoFocusModes == null)
                {
                    _autoFocusModes = new List<CameraAutoFocusMode>();

                    Interop.CameraFeatures.AfModeCallback callback = (CameraAutoFocusMode mode, IntPtr userData) =>
                    {
                        _autoFocusModes.Add(mode);
                        return true;
                    };
                    CameraErrorFactory.ThrowIfError(Interop.CameraFeatures.SupportedAfModes(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported Auto focus modes.");
                }

                return _autoFocusModes;
            }
        }

        /// <summary>
        /// Retrieves all the exposure modes supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported camera exposure modes.
        /// </returns>
        public IEnumerable<CameraExposureMode> SupportedExposureModes
        {
            get
            {
                if (_exposureModes == null)
                {
                    _exposureModes = new List<CameraExposureMode>();

                    Interop.CameraFeatures.ExposureModeCallback callback = (CameraExposureMode mode, IntPtr userData) =>
                    {
                        _exposureModes.Add(mode);
                        return true;
                    };
                    CameraErrorFactory.ThrowIfError(Interop.CameraFeatures.SupportedExposureModes(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported Exposure modes.");
                }

                return _exposureModes;
            }
        }

        /// <summary>
        /// Retrieves all the Iso level supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported camera Iso levels.
        /// </returns>
        public IEnumerable<CameraIsoLevel> SupportedIsoLevels
        {
            get
            {
                if (_isoLevels == null)
                {
                    _isoLevels = new List<CameraIsoLevel>();

                    Interop.CameraFeatures.IsoCallback callback = (CameraIsoLevel iso, IntPtr userData) =>
                    {
                        _isoLevels.Add(iso);
                        return true;
                    };
                    CameraErrorFactory.ThrowIfError(Interop.CameraFeatures.SupportedIso(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported Iso levels.");
                }

                return _isoLevels;
            }
        }

        /// <summary>
        /// Retrieves all the theater modes supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported camera theater modes.
        /// </returns>
        public IEnumerable<CameraTheaterMode> SupportedTheaterModes
        {
            get
            {
                if (_theaterModes == null)
                {
                    _theaterModes = new List<CameraTheaterMode>();

                    Interop.CameraFeatures.TheaterModeCallback callback = (CameraTheaterMode theaterMode, IntPtr userData) =>
                    {
                        _theaterModes.Add(theaterMode);
                        return true;
                    };
                    CameraErrorFactory.ThrowIfError(Interop.CameraFeatures.SupportedTheaterModes(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported theater modes.");
                }

                return _theaterModes;
            }
        }

        /// <summary>
        /// Retrieves all the whitebalance mode supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported camera white balance modes.
        /// </returns>
        public IEnumerable<CameraWhiteBalance> SupportedWhiteBalances
        {
            get
            {
                if (_whitebalances == null)
                {
                    _whitebalances = new List<CameraWhiteBalance>();

                    Interop.CameraFeatures.WhitebalanceCallback callback = (CameraWhiteBalance whiteBalance, IntPtr userData) =>
                    {
                        _whitebalances.Add(whiteBalance);
                        return true;
                    };
                    CameraErrorFactory.ThrowIfError(Interop.CameraFeatures.SupportedWhitebalance(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported white balance.");
                }

                return _whitebalances;
            }
        }

        /// <summary>
        /// Retrieves all the flash modes supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported camera flash modes.
        /// </returns>
        public IEnumerable<CameraFlashMode> SupportedFlashModes
        {
            get
            {
                if (_flashModes == null)
                {
                    _flashModes = new List<CameraFlashMode>();

                    Interop.CameraFeatures.FlashModeCallback callback = (CameraFlashMode flashMode, IntPtr userData) =>
                    {
                        _flashModes.Add(flashMode);
                        return true;
                    };
                    CameraErrorFactory.ThrowIfError(Interop.CameraFeatures.SupportedFlashModes(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported flash modes.");
                }

                return _flashModes;
            }
        }

        /// <summary>
        /// Retrieves all the scene modes supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported camera scene modes.
        /// </returns>
        public IEnumerable<CameraSceneMode> SupportedSceneModes
        {
            get
            {
                if (_sceneModes == null)
                {
                    _sceneModes = new List<CameraSceneMode>();

                    Interop.CameraFeatures.SceneModeCallback callback = (CameraSceneMode sceneMode, IntPtr userData) =>
                    {
                        _sceneModes.Add(sceneMode);
                        return true;
                    };
                    CameraErrorFactory.ThrowIfError(Interop.CameraFeatures.SupportedSceneModes(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported scene modes.");
                }

                return _sceneModes;
            }
        }

        /// <summary>
        /// Retrieves all the effects supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported camera effects.
        /// </returns>
        public IEnumerable<CameraEffectMode> SupportedEffects
        {
            get
            {
                if (_effectModes == null)
                {
                    _effectModes = new List<CameraEffectMode>();

                    Interop.CameraFeatures.EffectCallback callback = (CameraEffectMode effect, IntPtr userData) =>
                    {
                        _effectModes.Add(effect);
                        return true;
                    };
                    CameraErrorFactory.ThrowIfError(Interop.CameraFeatures.SupportedEffects(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported camera effects.");
                }

                return _effectModes;
            }
        }

        /// <summary>
        /// Retrieves all the stream rotation supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported camera stream rotations.
        /// </returns>
        public IEnumerable<CameraRotation> SupportedStreamRotations
        {
            get
            {
                if (_streamRotations == null)
                {
                    _streamRotations = new List<CameraRotation>();

                    Interop.CameraFeatures.StreamRotationCallback callback = (CameraRotation streamRotation, IntPtr userData) =>
                    {
                        _streamRotations.Add(streamRotation);
                        return true;
                    };
                    CameraErrorFactory.ThrowIfError(Interop.CameraFeatures.SupportedStreamRotations(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported camera rotations.");
                }

                return _streamRotations;
            }
        }

        /// <summary>
        /// Retrieves all the flips supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported camera flip.
        /// </returns>
        public IEnumerable<CameraFlip> SupportedStreamFlips
        {
            get
            {
                if (_streamFlips == null)
                {
                    _streamFlips = new List<CameraFlip>();

                    Interop.CameraFeatures.StreamFlipCallback callback = (CameraFlip streamFlip, IntPtr userData) =>
                    {
                        _streamFlips.Add(streamFlip);
                        return true;
                    };
                    CameraErrorFactory.ThrowIfError(Interop.CameraFeatures.SupportedStreamFlips(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported camera flips.");
                }

                return _streamFlips;
            }
        }

        /// <summary>
        /// Retrieves all the ptz types by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported ptz types.
        /// </returns>
        public IEnumerable<CameraPtzType> SupportedPtzTypes
        {
            get
            {
                if (_ptzTypes.Count == 0)
                {
                    _ptzTypes = new List<CameraPtzType>();

                    Interop.CameraFeatures.PtzTypeCallback callback = (CameraPtzType ptzType, IntPtr userData) =>
                    {
                        _ptzTypes.Add(ptzType);
                        return true;
                    };
                    CameraErrorFactory.ThrowIfError(Interop.CameraFeatures.SupportedPtzTypes(_camera.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported Ptz types.");
                }

                return _ptzTypes;
            }
        }
    }
}
