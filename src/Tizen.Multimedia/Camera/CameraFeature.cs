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
using System.Xml.Schema;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The CameraFeature class provides properties
    /// to get various capability information of the camera device.
    /// </summary>
    public class CameraFeature
    {
        internal readonly IntPtr _cameraHandle;
        private readonly List<CameraResolution> _previewResolution;
        private readonly List<CameraResolution> _cameraResolution;
        private readonly List<CameraPixelFormat> _captureFormat;
        private readonly List<CameraPixelFormat> _previewFormat;
        private readonly List<CameraFps> _fps;
        private readonly List<CameraFps> _fpsResolution;
        private readonly List<CameraAutoFocusMode> _afMode;
        private readonly List<CameraExposureMode> _exposureMode;
        private readonly List<CameraTheaterMode> _theater;
        private readonly List<CameraWhitebalance> _whitebalance;
        private readonly List<CameraIsoLevel> _iso;
        private readonly List<CameraEffectMode> _effect;
        private readonly List<CameraSceneMode> _sceneMode;
        private readonly List<CameraFlashMode> _flashMode;
        private readonly List<CameraRotation> _streamRotation;
        private readonly List<CameraFlip> _streamFlip;
        private readonly List<CameraPtzType> _ptzType;

        internal CameraFeature(IntPtr _handle)
        {
            _cameraHandle = _handle;
            _previewResolution = new List<CameraResolution>();
            _cameraResolution = new List<CameraResolution>();
            _captureFormat = new List<CameraPixelFormat>();
            _previewFormat = new List<CameraPixelFormat>();
            _fps = new List<CameraFps>();
            _fpsResolution = new List<CameraFps>();
            _afMode = new List<CameraAutoFocusMode>();
            _exposureMode = new List<CameraExposureMode>();
            _theater = new List<CameraTheaterMode>();
            _whitebalance = new List<CameraWhitebalance>();
            _iso = new List<CameraIsoLevel>();
            _effect = new List<CameraEffectMode>();
            _sceneMode = new List<CameraSceneMode>();
            _flashMode = new List<CameraFlashMode>();
            _streamRotation = new List<CameraRotation>();
            _streamFlip = new List<CameraFlip>();
            _ptzType = new List<CameraPtzType>();
        }

        /// <summary>
        /// Gets continuous capture feature's supported state.
        /// true if supported, otherwise false.
        /// </summary>
        public bool ContinuousCapture
        {
            get
            {
                bool val = false;

                val = Interop.CameraFeature.ContinuousCaptureSupport(_cameraHandle);
                int ret = ErrorFacts.GetLastResult();
                if ((CameraError)ret != CameraError.None)
                {
                    CameraError err = (CameraError)ret;
                    Log.Error(CameraLog.Tag, "Failed to get continuous feature support, " + err.ToString());
                }

                return val;
            }
        }

        /// <summary>
        /// Gets the face detection feature's supported state.
        /// true if supported, otherwise false.
        /// </summary>
        public bool FaceDetectionSupported
        {
            get
            {
                bool val = false;

                val = Interop.CameraFeature.FaceDetectionSupport(_cameraHandle);
                int ret = ErrorFacts.GetLastResult();
                if ((CameraError)ret != CameraError.None)
                {
                    CameraError err = (CameraError)ret;
                    Log.Error(CameraLog.Tag, "Failed to get face detection support, " + err.ToString());
                }

                return val;
            }
        }

        /// <summary>
        /// Gets the zero shutter lag feature's supported state.
        /// true if supported, otherwise false.
        /// </summary>
        public bool ZeroShutterLag
        {
            get
            {
                bool val = false;

                val = Interop.CameraFeature.ZeroShutterLagSupport(_cameraHandle);
                int ret = ErrorFacts.GetLastResult();
                if ((CameraError)ret != CameraError.None)
                {
                    CameraError err = (CameraError)ret;
                    Log.Error(CameraLog.Tag, "Failed to get zero shutter lag support, " + err.ToString());
                }

                return val;
            }
        }

        /// <summary>
        /// Gets the media packet preview callback feature's supported state.
        /// true if supported, otherwise false.
        /// </summary>
        public bool MediaPacketPreviewCallback
        {
            get
            {
                bool val = false;

                val = Interop.CameraFeature.MediaPacketPreviewCallbackSupport(_cameraHandle);
                int ret = ErrorFacts.GetLastResult();
                if ((CameraError)ret != CameraError.None)
                {
                    CameraError err = (CameraError)ret;
                    Log.Error(CameraLog.Tag, "Failed to get media packet preview callback support, " + err.ToString());
                }

                return val;
            }
        }

        /// <summary>
        /// Gets the support state of HDR capture.
        /// true if supported, otherwise false.
        /// </summary>
        public bool HdrCapture
        {
            get
            {
                bool val = false;

                val = Interop.CameraFeature.HdrCaptureSupport(_cameraHandle);
                int ret = ErrorFacts.GetLastResult();
                if ((CameraError)ret != CameraError.None)
                {
                    CameraError err = (CameraError)ret;
                    Log.Error(CameraLog.Tag, "Failed to get hdr capture feature support, " + err.ToString());
                }

                return val;
            }
        }

        /// <summary>
        /// Gets the support state of the anti-shake feature.
        /// true if supported, otherwise false.
        /// </summary>
        public bool AntiShake
        {
            get
            {
                bool val = false;

                val = Interop.CameraFeature.AntiShakeSupport(_cameraHandle);
                int ret = ErrorFacts.GetLastResult();
                if ((CameraError)ret != CameraError.None)
                {
                    CameraError err = (CameraError)ret;
                    Log.Error(CameraLog.Tag, "Failed to get anti shake feature support, " + err.ToString());
                }

                return val;
            }
        }

        /// <summary>
        /// Gets the support state of the video stabilization feature.
        /// true if supported, otherwise false.
        /// </summary>
        public bool VideoStabilization
        {
            get
            {
                bool val = false;

                val = Interop.CameraFeature.VideoStabilizationSupport(_cameraHandle);
                int ret = ErrorFacts.GetLastResult();
                if ((CameraError)ret != CameraError.None)
                {
                    CameraError err = (CameraError)ret;
                    Log.Error(CameraLog.Tag, "Failed to get video stabilization feature support, " + err.ToString());
                }

                return val;
            }
        }

        /// <summary>
        /// Gets state of support of auto contrast feature.
        /// true if supported, otherwise false.
        /// </summary>
        public bool AutoContrast
        {
            get
            {
                bool val = false;

                val = Interop.CameraFeature.AutoContrastSupport(_cameraHandle);
                int ret = ErrorFacts.GetLastResult();
                if ((CameraError)ret != CameraError.None)
                {
                    CameraError err = (CameraError)ret;
                    Log.Error(CameraLog.Tag, "Failed to get auto contrast feature support, " + err.ToString());
                }

                return val;
            }
        }

        /// <summary>
        /// Retrieves all the preview resolutions supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported preview resolutions.
        /// by recorder.
        /// </returns>
        public IEnumerable<CameraResolution> PreviewResolutions
        {
            get
            {
                if (_previewResolution.Count == 0)
                {
                    Interop.CameraFeature.PreviewResolutionCallback callback = (int width, int height, IntPtr userData) =>
                    {
                        CameraResolution temp = new CameraResolution(width, height);
                        _previewResolution.Add(temp);
                        return true;
                    };

                    int ret = Interop.CameraFeature.SupportedPreviewResolutions(_cameraHandle, callback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Failed to get the supported preview resolutions");
                    }
                }

                return _previewResolution;
            }
        }

        /// <summary>
        /// Retrieves all the capture resolutions supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported capture resolutions.
        /// </returns>
        public IEnumerable<CameraResolution> CaptureResolutions
        {
            get
            {
                if (_cameraResolution.Count == 0)
                {
                    Interop.CameraFeature.CaptureResolutionCallback callback = (int width, int height, IntPtr userData) =>
                    {
                        CameraResolution temp = new CameraResolution(width, height);
                        _cameraResolution.Add(temp);
                        return true;
                    };

                    int ret = Interop.CameraFeature.SupportedCaptureResolutions(_cameraHandle, callback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Failed to get the supported capture resolutions");
                    }
                }

                return _cameraResolution;
            }
        }

        /// <summary>
        /// Retrieves all the capture formats supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported capture formats.
        /// </returns>
        public IEnumerable<CameraPixelFormat> CaptureFormats
        {
            get
            {
                if (_captureFormat.Count == 0)
                {
                    Interop.CameraFeature.CaptureFormatCallback callback = (CameraPixelFormat format, IntPtr userData) =>
                    {
                        _captureFormat.Add(format);
                        return true;
                    };

                    int ret = Interop.CameraFeature.SupportedCaptureFormats(_cameraHandle, callback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Failed to get the supported capture formats.");
                    }
                }

                return _captureFormat;
            }
        }

        /// <summary>
        /// Retrieves all the preview formats supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported preview formats.
        /// </returns>
        public IEnumerable<CameraPixelFormat> PreviewFormats
        {
            get
            {
                if (_previewFormat.Count == 0)
                {
                    Interop.CameraFeature.PreviewFormatCallback callback = (CameraPixelFormat format, IntPtr userData) =>
                    {
                        _previewFormat.Add(format);
                        return true;
                    };

                    int ret = Interop.CameraFeature.SupportedPreviewFormats(_cameraHandle, callback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Failed to get the supported preview formats.");
                    }
                }

                return _previewFormat;
            }
        }

        /// <summary>
        /// Retrieves all the fps supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported fps.
        /// </returns>
        public IEnumerable<CameraFps> Fps
        {
            get
            {
                if (_fps.Count == 0)
                {
                    Interop.CameraFeature.FpsCallback callback = (CameraFps fps, IntPtr userData) =>
                    {
                        _fps.Add(fps);
                        return true;
                    };

                    int ret = Interop.CameraFeature.SupportedFps(_cameraHandle, callback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Failed to get the supported camera fps");
                    }
                }

                return _fps;
            }
        }

        private bool resolutionCallback(CameraFps fps, IntPtr userData)
        {
            _fpsResolution.Add(fps);
            return true;
        }

        /// <summary>
        /// Retrieves all the fps by resolution supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported fps by resolution.
        /// </returns>
        public IEnumerable<CameraFps> FpsByResolution(int width, int height)
        {
            if (_fpsResolution.Count == 0)
            {
                int ret = Interop.CameraFeature.SupportedFpsByResolution(_cameraHandle, width, height, resolutionCallback, IntPtr.Zero);
                if (ret != (int)CameraError.None)
                {
                    CameraErrorFactory.ThrowException(ret, "Failed to get the supported fps by resolutions.");
                }
            }

            return _fpsResolution;
        }

        /// <summary>
        /// Retrieves all the fps by resolution supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported fps by resolution.
        /// </returns>
        public IEnumerable<CameraAutoFocusMode> AfMode
        {
            get
            {
                if (_afMode.Count == 0)
                {
                    Interop.CameraFeature.AfModeCallback callback = (CameraAutoFocusMode mode, IntPtr userData) =>
                    {
                        _afMode.Add(mode);
                        return true;
                    };

                    int ret = Interop.CameraFeature.SupportedAfModes(_cameraHandle, callback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Failed to get the supported Auto focus modes.");
                    }
                }

                return _afMode;
            }
        }

        /// <summary>
        /// Retrieves all the exposure modes supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported camera exposure modes.
        /// </returns>
        public IEnumerable<CameraExposureMode> ExposureModes
        {
            get
            {
                if (_exposureMode.Count == 0)
                {
                    Interop.CameraFeature.ExposureModeCallback callback = (CameraExposureMode mode, IntPtr userData) =>
                    {
                        _exposureMode.Add(mode);
                        return true;
                    };

                    int ret = Interop.CameraFeature.SupportedExposureModes(_cameraHandle, callback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Failed to get the supported Exposure modes.");
                    }
                }

                return _exposureMode;
            }
        }

        /// <summary>
        /// Retrieves all the Iso level supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported camera Iso levels.
        /// </returns>
        public IEnumerable<CameraIsoLevel> IsoLevel
        {
            get
            {
                if (_iso.Count == 0)
                {
                    Interop.CameraFeature.IsoCallback callback = (CameraIsoLevel iso, IntPtr userData) =>
                    {
                        _iso.Add(iso);
                        return true;
                    };

                    int ret = Interop.CameraFeature.SupportedIso(_cameraHandle, callback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Failed to get the supported Iso levels.");
                    }
                }

                return _iso;
            }
        }

        /// <summary>
        /// Retrieves all the theater modes supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported camera theater modes.
        /// </returns>
        public IEnumerable<CameraTheaterMode> TheaterMode
        {
            get
            {
                if (_theater.Count == 0)
                {
                    Interop.CameraFeature.TheaterModeCallback callback = (CameraTheaterMode theaterMode, IntPtr userData) =>
                    {
                        _theater.Add(theaterMode);
                        return true;
                    };

                    int ret = Interop.CameraFeature.SupportedTheaterModes(_cameraHandle, callback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Failed to get the supported theater modes.");
                    }
                }

                return _theater;
            }
        }

        /// <summary>
        /// Retrieves all the whitebalance mode supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported camera white balance modes.
        /// </returns>
        public IEnumerable<CameraWhitebalance> Whitebalance
        {
            get
            {
                if (_whitebalance.Count == 0)
                {
                    Interop.CameraFeature.WhitebalanceCallback callback = (CameraWhitebalance whitebalance, IntPtr userData) =>
                    {
                        _whitebalance.Add(whitebalance);
                        return true;
                    };
                    int ret = Interop.CameraFeature.SupportedWhitebalance(_cameraHandle, callback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Failed to get the supported white balance.");
                    }
                }

                return _whitebalance;
            }
        }

        /// <summary>
        /// Retrieves all the flash modes supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported camera flash modes.
        /// </returns>
        public IEnumerable<CameraFlashMode> FlashMode
        {
            get
            {
                if (_flashMode.Count == 0)
                {
                    Interop.CameraFeature.FlashModeCallback callback = (CameraFlashMode flashMode, IntPtr userData) =>
                    {
                        _flashMode.Add(flashMode);
                        return true;
                    };
                    int ret = Interop.CameraFeature.SupportedFlashModes(_cameraHandle, callback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Failed to get the supported flash modes.");
                    }
                }

                return _flashMode;
            }
        }

        /// <summary>
        /// Retrieves all the scene modes supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported camera scene modes.
        /// </returns>
        public IEnumerable<CameraSceneMode> SceneMode
        {
            get
            {
                if (_sceneMode.Count == 0)
                {
                    Interop.CameraFeature.SceneModeCallback callback = (CameraSceneMode sceneMode, IntPtr userData) =>
                    {
                        _sceneMode.Add(sceneMode);
                        return true;
                    };
                    int ret = Interop.CameraFeature.SupportedSceneModes(_cameraHandle, callback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Failed to get the supported scene modes.");
                    }
                }

                return _sceneMode;
            }
        }

        /// <summary>
        /// Retrieves all the effects supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported camera effects.
        /// </returns>
        public IEnumerable<CameraEffectMode> Effect
        {
            get
            {
                if (_effect.Count == 0)
                {
                    Interop.CameraFeature.EffectCallback callback = (CameraEffectMode effect, IntPtr userData) =>
                    {
                        _effect.Add(effect);
                        return true;
                    };
                    int ret = Interop.CameraFeature.SupportedEffects(_cameraHandle, callback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Failed to get the supported camera effects.");
                    }
                }

                return _effect;
            }
        }

        /// <summary>
        /// Retrieves all the stream rotation supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported camera stream rotations.
        /// </returns>
        public IEnumerable<CameraRotation> StreamRotation
        {
            get
            {
                if (_streamRotation.Count == 0)
                {
                    Interop.CameraFeature.StreamRotationCallback callback = (CameraRotation streamRotation, IntPtr userData) =>
                    {
                        _streamRotation.Add(streamRotation);
                        return true;
                    };
                    int ret = Interop.CameraFeature.SupportedStreamRotations(_cameraHandle, callback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Failed to get the supported camera rotations.");
                    }
                }

                return _streamRotation;
            }
        }

        /// <summary>
        /// Retrieves all the flips supported by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported camera flip.
        /// </returns>
        public IEnumerable<CameraFlip> StreamFlip
        {
            get
            {
                if (_streamFlip.Count == 0)
                {
                    Interop.CameraFeature.StreamFlipCallback callback = (CameraFlip streamFlip, IntPtr userData) =>
                    {
                        _streamFlip.Add(streamFlip);
                        return true;
                    };
                    int ret = Interop.CameraFeature.SupportedStreamFlips(_cameraHandle, callback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Failed to get the supported camera flips.");
                    }
                }

                return _streamFlip;
            }
        }

        /// <summary>
        /// Retrieves all the ptz types by the camera.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported ptz types.
        /// </returns>
        public IEnumerable<CameraPtzType> PtzType
        {
            get
            {
                if (_ptzType.Count == 0)
                {
                    Interop.CameraFeature.PtzTypeCallback callback = (CameraPtzType ptzType, IntPtr userData) =>
                    {
                        _ptzType.Add(ptzType);
                        return true;
                    };
                    int ret = Interop.CameraFeature.SupportedPtzTypes(_cameraHandle, callback, IntPtr.Zero);
                    if (ret != (int)CameraError.None)
                    {
                        CameraErrorFactory.ThrowException(ret, "Failed to get the supported Ptz types.");
                    }
                }

                return _ptzType;
            }
        }
    }
}
