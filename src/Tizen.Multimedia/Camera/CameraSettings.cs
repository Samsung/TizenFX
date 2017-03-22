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
using System.Linq;
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The camera setting class provides methods/properties to get and
    /// set basic camera attributes.
    /// </summary>
    public class CameraSettings
    {
        internal readonly Camera _camera;

        private readonly Range? _brightnessRange;
        private readonly Range? _contrastRange;
        private readonly Range? _panRange;
        private readonly Range? _tiltRange;
        private readonly Range? _exposureRange;
        private readonly Range? _zoomRange;

        internal CameraSettings(Camera camera)
        {
            _camera = camera;

            _contrastRange = GetRange(Interop.CameraSettings.GetContrastRange);
            _brightnessRange = GetRange(Interop.CameraSettings.GetBrightnessRange);
            _exposureRange = GetRange(Interop.CameraSettings.GetExposureRange);
            _zoomRange = GetRange(Interop.CameraSettings.GetZoomRange);
            _panRange = GetRange(Interop.CameraSettings.GetPanRange);
            _tiltRange = GetRange(Interop.CameraSettings.GetTiltRange);
        }

        private delegate int GetRangeDelegate(IntPtr handle, out int min, out int max);
        private Range? GetRange(GetRangeDelegate func)
        {
            int min = 0;
            int max = 0;

            CameraErrorFactory.ThrowIfError(func(_camera.GetHandle(), out min, out max),
                "Failed to initialize the camera settings");

            if (min > max)
            {
                return null;
            }

            return new Range(min, max);
        }

#region Auto Focus
        /// <summary>
        /// Sets auto focus area.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public void SetAutoFocusArea(int x, int y)
        {
            CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetAutoFocusArea(_camera.GetHandle(), x, y),
                "Failed to set the autofocus area.");
        }

        public void SetAutoFocusArea(Point pos)
        {
            CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetAutoFocusArea(_camera.GetHandle(), pos.X, pos.Y),
                "Failed to set the autofocus area.");
        }

        /// <summary>
        /// Clears the auto focus area.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        public void ClearFocusArea()
        {
            CameraErrorFactory.ThrowIfError(Interop.CameraSettings.ClearAutoFocusArea(_camera.GetHandle()),
                "Failed to clear the autofocus area.");
        }

        /// <summary>
        /// The auto focus mode.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        public CameraAutoFocusMode AutoFocusMode
        {
            get
            {
                CameraAutoFocusMode val = CameraAutoFocusMode.None;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetAutoFocusMode(_camera.GetHandle(), out val),
                    "Failed to get camera autofocus mode");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetAutoFocusMode(_camera.GetHandle(), value),
                    "Failed to set camera autofocus mode.");
            }
        }
        #endregion Auto Focus

#region Contrast
        /// <summary>
        /// The contrast level of the camera.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        public int Contrast
        {
            get
            {
                int val = 0;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetContrast(_camera.GetHandle(), out val),
                    "Failed to get camera contrast value");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetContrast(_camera.GetHandle(), value),
                    "Failed to set camera contrast value.");
            }
        }

        /// <summary>
        /// The auto contrast.
        /// If true auto contrast is enabled, otherwise false.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        public bool AutoContrast
        {
            get
            {
                bool val = false;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.IsEnabledAutoContrast(_camera.GetHandle(), out val),
                    "Failed to get camera auto contrast");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.EnableAutoContrast(_camera.GetHandle(), value),
                    "Failed to set camera enable auto contrast.");
            }
        }
        /// <summary>
        /// Gets the available contrast level.
        /// </summary>
        /// <remarks>
        /// If min value is greater than the max value, it means this feature is not supported.
        /// </remarks>
        public Range ContrastRange
        {
            get
            {
                if (_contrastRange.HasValue == false)
                {
                    throw new NotSupportedException("Contrast is not supported.");
                }

                return _contrastRange.Value;
            }
        }
#endregion Contrast

#region Brightness
        /// <summary>
        /// The brightness level of the camera.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        public int Brightness
        {
            get
            {
                int val = 0;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetBrightness(_camera.GetHandle(), out val),
                    "Failed to get camera brightness value");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetBrightness(_camera.GetHandle(), value),
                    "Failed to set camera brightness value.");
            }
        }

        /// <summary>
        /// Gets the available brightness level.
        /// </summary>
        /// <remarks>
        /// If min value is greater than the max value, it means this feature is not supported.
        /// </remarks>
        public Range BrightnessRange
        {
            get
            {
                if (_brightnessRange.HasValue == false)
                {
                    throw new NotSupportedException("Brightness is not supported.");
                }

                return _brightnessRange.Value;
            }
        }
#endregion Brightness

#region Exposure
        /// <summary>
        /// The exposure value.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        public int Exposure
        {
            get
            {
                int val = 0;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetExposure(_camera.GetHandle(), out val),
                    "Failed to get camera exposure value");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetExposure(_camera.GetHandle(), value),
                    "Failed to set camera exposure value.");
            }
        }

        /// <summary>
        /// The exposure mode.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        public CameraExposureMode ExposureMode
        {
            get
            {
                CameraExposureMode val = CameraExposureMode.Off;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetExposureMode(_camera.GetHandle(), out val),
                    "Failed to get camera exposure mode");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetExposureMode(_camera.GetHandle(), value),
                    "Failed to set camera exposure mode.");
            }
        }

        /// <summary>
        /// Gets the available exposure value.
        /// </summary>
        /// <remarks>
        /// If min value is greater than the max value, it means this feature is not supported.
        /// </remarks>
        public Range ExposureRange
        {
            get
            {
                if (_exposureRange.HasValue == false)
                {
                    throw new NotSupportedException("Exposure is not supported.");
                }

                return _exposureRange.Value;
            }
        }
        #endregion Exposure

#region Zoom
        /// <summary>
        /// The zoom level.
        /// The range for zoom level is received from ZoomRange property.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera.
        /// </privilege>
        public int ZoomLevel
        {
            get
            {
                int val = 0;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetZoom(_camera.GetHandle(), out val),
                    "Failed to get zoom level");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetZoom(_camera.GetHandle(), (int)value),
                    "Failed to set zoom level.");
            }
        }

        /// <summary>
        /// Gets the available zoom level.
        /// </summary>
        /// <remarks>
        /// If min value is greater than the max value, it means this feature is not supported.
        /// </remarks>
        public Range ZoomRange
        {
            get
            {
                if (_zoomRange.HasValue == false)
                {
                    throw new NotSupportedException("Zoom is not supported.");
                }

                return _zoomRange.Value;
            }
        }
#endregion Zoom

        /// <summary>
        /// The whitebalance mode.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        public CameraWhiteBalance WhiteBalance
        {
            get
            {
                CameraWhiteBalance val = CameraWhiteBalance.None;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetWhiteBalance(_camera.GetHandle(), out val),
                    "Failed to get camera whitebalance");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetWhitebalance(_camera.GetHandle(), value),
                    "Failed to set camera whitebalance.");
            }
        }

        /// <summary>
        /// The ISO level.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        public CameraIsoLevel IsoLevel
        {
            get
            {
                CameraIsoLevel val = CameraIsoLevel.Auto;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetIso(_camera.GetHandle(), out val),
                    "Failed to get camera Iso level");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetIso(_camera.GetHandle(), value),
                    "Failed to set camera Iso level.");
            }
        }

        /// <summary>
        /// The quality of the image.
        /// The range for image quality is 1 to 100.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera.
        /// </privilege>
        public int ImageQuality
        {
            get
            {
                int val = 0;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetImageQuality(_camera.GetHandle(), out val),
                    "Failed to get image quality");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetImageQuality(_camera.GetHandle(), value),
                    "Failed to set image quality.");
            }
        }

#region Resolution, Format, Fps of preview, capture
        /// <summary>
        /// The preview frame rate.
        /// </summary>
        public CameraFps PreviewFps
        {
            get
            {
                CameraFps val = CameraFps.Auto;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetPreviewFps(_camera.GetHandle(), out val),
                    "Failed to get camera preview fps");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetPreviewFps(_camera.GetHandle(), value),
                    "Failed to set preview fps.");
            }
        }

        /// <summary>
        /// Gets or sets the resolution of preview
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public Size PreviewResolution
        {
            get
            {
                int width = 0;
                int height = 0;

                CameraErrorFactory.ThrowIfError(Interop.Camera.GetPreviewResolution(_camera.GetHandle(), out width, out height),
                    "Failed to get camera preview resolution");

                return new Size(width, height);
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.Camera.SetPreviewResolution(_camera.GetHandle(), value.Width, value.Height),
                    "Failed to set preview resolution.");
            }
        }

        /// <summary>
        /// Gets the recommended preview resolution.
        /// </summary>
        /// <remarks>
        /// Depending on the capture resolution aspect ratio and display resolution,
        /// the recommended preview resolution is determined.
        /// </remarks>
        public Size RecommendedPreviewResolution
        {
            get
            {
                int width = 0;
                int height = 0;

                CameraErrorFactory.ThrowIfError(Interop.Camera.GetRecommendedPreviewResolution(_camera.GetHandle(), out width, out height),
                    "Failed to get recommended preview resolution");

                return new Size(width, height);
            }
        }

        /// <summary>
        /// The preview data format.
        /// </summary>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public CameraPixelFormat PreviewPixelFormat
        {
            get
            {
                CameraPixelFormat val = 0;

                CameraErrorFactory.ThrowIfError(Interop.Camera.GetPreviewPixelFormat(_camera.GetHandle(), out val),
                    "Failed to get preview format");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.Camera.SetPreviewPixelFormat(_camera.GetHandle(), value),
                    "Failed to set preview format.");
            }
        }

        /// <summary>
        /// Resolution of the captured image.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public Size CaptureResolution
        {
            get
            {
                int width = 0;
                int height = 0;

                CameraErrorFactory.ThrowIfError(Interop.Camera.GetCaptureResolution(_camera.GetHandle(), out width, out height),
                    "Failed to get camera capture resolution");

                return new Size(width, height);
            }

            set
            {
                Size res = value;

                CameraErrorFactory.ThrowIfError(Interop.Camera.SetCaptureResolution(_camera.GetHandle(), res.Width, res.Height),
                    "Failed to set capture resolution.");
            }
        }

        /// <summary>
        /// Format of an image to be captured.
        /// </summary>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public CameraPixelFormat CapturePixelFormat
        {
            get
            {
                CameraPixelFormat val = CameraPixelFormat.Invalid;

                CameraErrorFactory.ThrowIfError(Interop.Camera.GetCaptureFormat(_camera.GetHandle(), out val),
                    "Failed to get camera capture formats");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.Camera.SetCaptureFormat(_camera.GetHandle(), value),
                    "Failed to set capture format.");
            }
        }
#endregion Resolution, Format, Fps of preview, capture

#region Encoded preview
        /// <summary>
        /// The bit rate of encoded preview.
        /// </summary>
        public int EncodedPreviewBitrate
        {
            get
            {
                int val = 0;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetBitrate(_camera.GetHandle(), out val),
                    "Failed to get preview bitrate");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetBitrate(_camera.GetHandle(), (int)value),
                    "Failed to set encoded preview bitrate.");
            }
        }

        /// <summary>
        /// GOP(Group Of Pictures) interval of encoded preview.
        /// </summary>
        public int EncodedPreviewGopInterval
        {
            get
            {
                int val = 0;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetGopInterval(_camera.GetHandle(), out val),
                    "Failed to get preview gop interval");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetGopInterval(_camera.GetHandle(), (int)value),
                    "Failed to set encoded preview gop intervals.");
            }
        }
#endregion Encoded preview

        /// <summary>
        /// The theater mode.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <remarks>
        /// If you want to display the preview image on the external display with the full screen mode,
        /// use this property.
        /// </remarks>
        public CameraTheaterMode TheaterMode
        {
            get
            {
                CameraTheaterMode val = CameraTheaterMode.Disable;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetTheaterMode(_camera.GetHandle(), out val),
                    "Failed to get camera theater mode");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetTheaterMode(_camera.GetHandle(), value),
                    "Failed to set camera theater mode.");
            }
        }

        /// <summary>
        /// The camera effect mode.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        public CameraEffectMode Effect
        {
            get
            {
                CameraEffectMode val = CameraEffectMode.None;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetEffect(_camera.GetHandle(), out val),
                    "Failed to get camera effect");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetEffect(_camera.GetHandle(), value),
                    "Failed to set camera effect.");
            }
        }

        /// <summary>
        /// The scene mode.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        public CameraSceneMode SceneMode
        {
            get
            {
                CameraSceneMode val = CameraSceneMode.Normal;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetSceneMode(_camera.GetHandle(), out val),
                    "Failed to get camera scene mode");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetSceneMode(_camera.GetHandle(), value),
                    "Failed to set camera scene mode.");
            }
        }

        /// <summary>
        /// The camera's flash mode.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        public CameraFlashMode FlashMode
        {
            get
            {
                CameraFlashMode val = CameraFlashMode.Off;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetFlashMode(_camera.GetHandle(), out val),
                    "Failed to get camera flash mode");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetFlashMode(_camera.GetHandle(), value),
                    "Failed to set camera flash mode.");
            }
        }

        /// <summary>
        /// Gets the camera lens orientation angle.
        /// </summary>
        public int LensOrientation
        {
            get
            {
                int val = 0;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetLensOrientation(_camera.GetHandle(), out val),
                    "Failed to get camera lens orientation");

                return val;
            }
        }

        /// <summary>
        /// The stream rotation.
        /// </summary>
        public CameraRotation StreamRotation
        {
            get
            {
                CameraRotation val = CameraRotation.None;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetStreamRotation(_camera.GetHandle(), out val),
                    "Failed to get camera stream rotation");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetStreamRotation(_camera.GetHandle(), value),
                    "Failed to set camera stream rotation.");
            }
        }

        /// <summary>
        /// The stream flip.
        /// </summary>
        public CameraFlip StreamFlip
        {
            get
            {
                CameraFlip val = CameraFlip.None;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetFlip(_camera.GetHandle(), out val),
                    "Failed to get camera stream flip");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetFlip(_camera.GetHandle(), value),
                    "Failed to set camera flip.");
            }
        }

        /// <summary>
        /// The mode of HDR(High dynamic range) capture.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <remarks>
        /// Taking multiple pictures at different exposure levels and intelligently stitching them together
        /// so that we eventually arrive at a picture that is representative in both dark and bright areas.
        /// If this attribute is set, then eventhandler set for HdrCaptureProgress event is invoked.
        /// </remarks>
        public CameraHdrMode HdrMode
        {
            get
            {
                CameraHdrMode val = 0;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetHdrMode(_camera.GetHandle(), out val),
                    "Failed to get camera hdr mode");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetHdrMode(_camera.GetHandle(), value),
                    "Failed to set camera hdr mode.");
            }
        }

        /// <summary>
        /// The anti shake feature.
        /// If true the antishake feature is enabled, otherwise false.
        /// </summary>
        public bool AntiShake
        {
            get
            {
                bool val = false;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.IsEnabledAntiShake(_camera.GetHandle(), out val),
                    "Failed to get camera anti shake value");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.EnableAntiShake(_camera.GetHandle(), value),
                    "Failed to set camera anti shake value.");
            }
        }

        /// <summary>
        /// Enables/Disables the video stabilization feature.
        /// If true video stabilization is enabled, otherwise false.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <remarks>
        /// If video stabilization is enabled, zero shutter lag is disabled.
        /// This feature is used to record a video.
        /// </remarks>
        public bool VideoStabilization
        {
            get
            {
                bool val = false;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.IsEnabledVideoStabilization(_camera.GetHandle(), out val),
                    "Failed to get camera video stabilization");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.EnableVideoStabilization(_camera.GetHandle(), value),
                    "Failed to set camera video stabilization.");
            }
        }

        /// <summary>
        /// Disables shutter sound.
        /// If true shutter sound is disabled, otherwise false.
        /// </summary>
        /// <remarks>
        /// In some countries, this operation is not permitted.
        /// </remarks>
        public bool DisableShutterSound
        {
            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.DisableShutterSound(_camera.GetHandle(), value),
                    "Failed to set disable shutter sound.");
            }
        }

#region PTZ(Pan Tilt Zoom), Pan, Tilt
        /// <summary>
        /// Sets the type of PTZ(Pan Tilt Zoom). Mechanical or Electronic.
        /// </summary>
        public CameraPtzType PtzType
        {
            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetPtzType(_camera.GetHandle(), (int)value),
                    "Failed to set camera ptz type.");
            }
        }

        /// <summary>
        /// Sets the position to move horizontally.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <param name="type">ptz move type.</param>
        /// <param name="panStep">pan step</param>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public void SetPan(CameraPtzMoveType type, int panStep)
        {
            CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetPan(_camera.GetHandle(), type, panStep),
                "Failed to set the camera pan type.");
        }

        /// <summary>
        /// Gets the current position of the camera.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <returns>Returns the camera's horizontal position</returns>
        public int GetPan()
        {
            int val = 0;

            CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetPan(_camera.GetHandle(), out val),
                "Failed to get the camera pan step.");

            return val;
        }

        /// <summary>
        /// Sets the position to move vertically.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <param name="type">ptz move type</param>
        /// <param name="tiltStep">tilt step</param>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public void SetTilt(CameraPtzMoveType type, int tiltStep)
        {
            CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetTilt(_camera.GetHandle(), type, tiltStep),
                "Failed to set the camera tilt type\t.");
        }

        /// <summary>
        /// Gets the current position of the camera.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <returns>Returns the current vertical position</returns>
        public int GetTilt()
        {
            int val = 0;

            CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetTilt(_camera.GetHandle(), out val),
                "Failed to set the camera current position.");

            return val;
        }

        /// <summary>
        /// Gets lower limit and upper limit for pan position.
        /// </summary>
        /// <remarks>
        /// If min value is greater than the max value, it means this feature is not supported.
        /// </remarks>
        public Range PanRange
        {
            get
            {
                if (_panRange.HasValue == false)
                {
                    throw new NotSupportedException("Pan is not supported.");
                }
                return _panRange.Value;
            }
        }

        /// <summary>
        /// Gets lower limit and upper limit for tilt position.
        /// </summary>
        /// <remarks>
        /// If min value is greater than the max value, it means this feature is not supported.
        /// </remarks>
        public Range TiltRange
        {
            get
            {
                if (_tiltRange.HasValue == false)
                {
                    throw new NotSupportedException("Tilt is not supported.");
                }
                return _tiltRange.Value;
            }
        }
#endregion PTZ(Pan Tilt Zoom), Pan, Tilt

#region EXIF tag
        /// <summary>
        /// The scene mode.
        /// true if EXIF tags are enabled in JPEG file, otherwise false.
        /// </summary>
        public bool EnableTag
        {
            get
            {
                bool val = false;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.IsEnabledTag(_camera.GetHandle(), out val),
                    "Failed to get camera enable tag");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.EnableTag(_camera.GetHandle(), value),
                    "Failed to set camera enable tag.");
            }
        }

        /// <summary>
        /// The camera image description in the EXIF tag.
        /// </summary>
        public string ImageDescriptionTag
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetImageDescription(_camera.GetHandle(), out val),
                    "Failed to get image description");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetImageDescription(_camera.GetHandle(), value),
                    "Failed to set image description.");
            }
        }

        /// <summary>
        /// The software information in the EXIF tag.
        /// </summary>
        public string SoftwareTag
        {
            get
            {
                IntPtr val = IntPtr.Zero;

                try
                {
                    CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetTagSoftware(_camera.GetHandle(), out val),
                    "Failed to get tag software");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetTagSoftware(_camera.GetHandle(), value),
                    "Failed to set tag software.");
            }
        }

        /// <summary>
        /// The geotag(GPS data) in the EXIF tag.
        /// </summary>
        public Location GeoTag
        {
            get
            {
                double latitude = 0.0;
                double longitude = 0.0;
                double altitude = 0.0;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetGeotag(_camera.GetHandle(), out latitude, out longitude, out altitude),
                    "Failed to get tag");

                return new Location(latitude, longitude, altitude);
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetGeotag(_camera.GetHandle(),
                    value.Latitude, value.Longitude, value.Altitude), "Failed to set geo tag.");
            }
        }

        /// <summary>
        /// Removes the geotag(GPS data) in the EXIF(Exchangeable image file format) tag.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        public void RemoveGeoTag()
        {
            CameraErrorFactory.ThrowIfError(Interop.CameraSettings.RemoveGeotag(_camera.GetHandle()),
                "Failed to remove the geotag\t.");
        }

        /// <summary>
        /// The camera orientation in the tag.
        /// </summary>
        public CameraTagOrientation OrientationTag
        {
            get
            {
                CameraTagOrientation val = 0;

                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.GetTagOrientation(_camera.GetHandle(), out val),
                    "Failed to get camera tag orientation");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Interop.CameraSettings.SetTagOrientation(_camera.GetHandle(), value),
                    "Failed to set camera tag orientation.");
            }
        }
#endregion EXIF tag
    }
}

