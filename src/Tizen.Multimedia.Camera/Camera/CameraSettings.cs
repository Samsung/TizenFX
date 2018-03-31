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
using System.Runtime.InteropServices;
using Native = Interop.CameraSettings;
using static Interop.Camera;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The camera setting class provides methods/properties to get and
    /// set basic camera attributes.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class CameraSettings
    {
        internal readonly Camera _camera;

        private readonly Range? _brightnessRange;
        private readonly Range? _contrastRange;
        private readonly Range? _exposureRange;
        private readonly Range? _hueRange = null;
        private readonly Range? _panRange;
        private readonly Range? _tiltRange;
        private readonly Range? _zoomRange;

        internal CameraSettings(Camera camera)
        {
            _camera = camera;

            _brightnessRange = GetRange(Native.GetBrightnessRange);
            _contrastRange = GetRange(Native.GetContrastRange);
            _exposureRange = GetRange(Native.GetExposureRange);
            _hueRange = GetRange(Native.GetHueRange);
            _panRange = GetRange(Native.GetPanRange);
            _tiltRange = GetRange(Native.GetTiltRange);
            _zoomRange = GetRange(Native.GetZoomRange);
        }

        private delegate CameraError GetRangeDelegate(IntPtr handle, out int min, out int max);
        private Range? GetRange(GetRangeDelegate func)
        {
            CameraErrorFactory.ThrowIfError(func(_camera.GetHandle(), out int min, out int max),
                "Failed to initialize the camera settings");

            if (min > max)
            {
                return null;
            }

            return new Range(min, max);
        }

        #region Auto Focus
        /// <summary>
        /// Sets the auto focus area.
        /// </summary>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <remarks>
        /// <see cref="CameraAutoFocusMode"/> should not be the <see cref="CameraAutoFocusMode.None"/>.
        /// </remarks>
        /// /// <exception cref="ArgumentException">In case of invalid parameters.</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public void SetAutoFocusArea(int x, int y)
        {
            CameraErrorFactory.ThrowIfError(Native.SetAutoFocusArea(_camera.GetHandle(), x, y),
                "Failed to set the autofocus area.");
        }

        /// <summary>
        /// Sets the auto focus area.
        /// </summary>
        /// <param name="pos"><see cref="Point"/> structure including X, Y position.</param>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <remarks>
        /// <see cref="CameraAutoFocusMode"/> should not be the <see cref="CameraAutoFocusMode.None"/>.
        /// </remarks>
        /// /// <exception cref="ArgumentException">In case of invalid parameters.</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public void SetAutoFocusArea(Point pos)
        {
            CameraErrorFactory.ThrowIfError(Native.SetAutoFocusArea(_camera.GetHandle(), pos.X, pos.Y),
                "Failed to set the autofocus area.");
        }

        /// <summary>
        /// Clears the auto focus area.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public void ClearFocusArea()
        {
            CameraErrorFactory.ThrowIfError(Native.ClearAutoFocusArea(_camera.GetHandle()),
                "Failed to clear the autofocus area.");
        }

        /// <summary>
        /// The auto focus mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A <see cref="CameraAutoFocusMode"/> that specifies the auto focus mode.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public CameraAutoFocusMode AutoFocusMode
        {
            get
            {
                CameraAutoFocusMode val = CameraAutoFocusMode.None;

                CameraErrorFactory.ThrowIfError(Native.GetAutoFocusMode(_camera.GetHandle(), out val),
                    "Failed to get camera autofocus mode");

                return val;
            }

            set
            {
                ValidationUtil.ValidateEnum(typeof(CameraAutoFocusMode), value, nameof(value));

                CameraErrorFactory.ThrowIfError(Native.SetAutoFocusMode(_camera.GetHandle(), value),
                    "Failed to set camera autofocus mode.");
            }
        }
        #endregion Auto Focus

        #region Contrast
        /// <summary>
        /// The contrast level of the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public int Contrast
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetContrast(_camera.GetHandle(), out int val),
                    "Failed to get camera contrast value");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Native.SetContrast(_camera.GetHandle(), value),
                    "Failed to set camera contrast value.");
            }
        }

        /// <summary>
        /// The auto contrast.
        /// If true auto contrast is enabled, otherwise false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public bool AutoContrast
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.IsEnabledAutoContrast(_camera.GetHandle(), out bool val),
                    "Failed to get camera auto contrast");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Native.EnableAutoContrast(_camera.GetHandle(), value),
                    "Failed to set camera enable auto contrast.");
            }
        }

        /// <summary>
        /// Gets the available contrast level.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// If the mininum value is greater than the maximum value, it means this feature is not supported.
        /// </remarks>
        /// <exception cref="NotSupportedException">In case of this feature is not supported.</exception>
        public Range ContrastRange
        {
            get
            {
                if (!_contrastRange.HasValue)
                {
                    throw new NotSupportedException("Contrast is not supported.");
                }

                return _contrastRange.Value;
            }
        }
        #endregion Contrast

        #region Hue
        /// <summary>
        /// The hue level of the camera.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public int Hue
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetHue(_camera.GetHandle(), out int val),
                    "Failed to get camera hue value");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Native.SetHue(_camera.GetHandle(), value),
                    "Failed to set camera hue value.");
            }
        }

        /// <summary>
        /// Gets the available hue level.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// <remarks>
        /// If HueRange returns null, it means that hue feature is not supported.
        /// It can be checked also with <seec cref="CameraCapabilities.IsHueSupported"/>.
        /// </remarks>
        /// <seealso cref="Hue"/>
        public Range? HueRange
        {
            get
            {
                if (!_hueRange.HasValue)
                {
                    return null;
                }

                return _hueRange.Value;
            }
        }
        #endregion

        #region Brightness
        /// <summary>
        /// The brightness level of the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public int Brightness
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetBrightness(_camera.GetHandle(), out int val),
                    "Failed to get camera brightness value");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Native.SetBrightness(_camera.GetHandle(), value),
                    "Failed to set camera brightness value.");
            }
        }

        /// <summary>
        /// Gets the available brightness level.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// If the minimum value is greater than the maximum value, it means this feature is not supported.
        /// </remarks>
        /// <exception cref="NotSupportedException">In case of this feature is not supported.</exception>
        public Range BrightnessRange
        {
            get
            {
                if (!_brightnessRange.HasValue)
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
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public int Exposure
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetExposure(_camera.GetHandle(), out int val),
                    "Failed to get camera exposure value");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Native.SetExposure(_camera.GetHandle(), value),
                    "Failed to set camera exposure value.");
            }
        }

        /// <summary>
        /// The exposure mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A <see cref="CameraExposureMode"/> that specifies the exposure mode.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public CameraExposureMode ExposureMode
        {
            get
            {
                CameraExposureMode val = CameraExposureMode.Off;

                CameraErrorFactory.ThrowIfError(Native.GetExposureMode(_camera.GetHandle(), out val),
                    "Failed to get camera exposure mode");

                return val;
            }

            set
            {
                ValidationUtil.ValidateEnum(typeof(CameraExposureMode), value, nameof(value));

                CameraErrorFactory.ThrowIfError(Native.SetExposureMode(_camera.GetHandle(), value),
                    "Failed to set camera exposure mode.");
            }
        }

        /// <summary>
        /// Gets the available exposure value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// If the minimum value is greater than the maximum value, it means this feature is not supported.
        /// </remarks>
        /// <exception cref="NotSupportedException">In case of this feature is not supported.</exception>
        public Range ExposureRange
        {
            get
            {
                if (!_exposureRange.HasValue)
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
        /// The range for the zoom level is received from the ZoomRange property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public int ZoomLevel
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetZoom(_camera.GetHandle(), out int val),
                    "Failed to get zoom level");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Native.SetZoom(_camera.GetHandle(), value),
                    "Failed to set zoom level.");
            }
        }

        /// <summary>
        /// Gets the available zoom level.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// If the minimum value is greater than the maximum value, it means this feature is not supported.
        /// </remarks>
        /// <exception cref="NotSupportedException">In case of this feature is not supported.</exception>
        public Range ZoomRange
        {
            get
            {
                if (!_zoomRange.HasValue)
                {
                    throw new NotSupportedException("Zoom is not supported.");
                }

                return _zoomRange.Value;
            }
        }
        #endregion Zoom

        /// <summary>
        /// The white balance mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A <see cref="CameraWhiteBalance"/> that specifies the white balance mode.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public CameraWhiteBalance WhiteBalance
        {
            get
            {
                CameraWhiteBalance val = CameraWhiteBalance.None;

                CameraErrorFactory.ThrowIfError(Native.GetWhiteBalance(_camera.GetHandle(), out val),
                    "Failed to get camera whitebalance");

                return val;
            }

            set
            {
                ValidationUtil.ValidateEnum(typeof(CameraWhiteBalance), value, nameof(value));

                CameraErrorFactory.ThrowIfError(Native.SetWhitebalance(_camera.GetHandle(), value),
                    "Failed to set camera whitebalance.");
            }
        }

        /// <summary>
        /// The ISO level.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A <see cref="CameraIsoLevel"/> that specifies the ISO level.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public CameraIsoLevel IsoLevel
        {
            get
            {
                CameraIsoLevel val = CameraIsoLevel.Auto;

                CameraErrorFactory.ThrowIfError(Native.GetIso(_camera.GetHandle(), out val),
                    "Failed to get camera Iso level");

                return val;
            }

            set
            {
                ValidationUtil.ValidateEnum(typeof(CameraIsoLevel), value, nameof(value));

                CameraErrorFactory.ThrowIfError(Native.SetIso(_camera.GetHandle(), value),
                    "Failed to set camera Iso level.");
            }
        }

        /// <summary>
        /// The quality of the image.
        /// The range for the image quality is 1 to 100.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public int ImageQuality
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetImageQuality(_camera.GetHandle(), out int val),
                    "Failed to get image quality");

                return val;
            }

            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException("Valid value is from 1(lowest quality) to 100(highest quality)");
                }

                CameraErrorFactory.ThrowIfError(Native.SetImageQuality(_camera.GetHandle(), value),
                    "Failed to set image quality.");
            }
        }

        #region Resolution, Format, Fps of preview, capture
        /// <summary>
        /// The preview frame rate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A <see cref="CameraFps"/> that specifies the preview frame rate.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public CameraFps PreviewFps
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetPreviewFps(_camera.GetHandle(), out var val),
                    "Failed to get camera preview fps");

                return val;
            }

            set
            {
                ValidationUtil.ValidateEnum(typeof(CameraFps), value, nameof(value));

                CameraErrorFactory.ThrowIfError(Native.SetPreviewFps(_camera.GetHandle(), value),
                    "Failed to set preview fps.");
            }
        }

        /// <summary>
        /// Gets or sets the resolution of the preview.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ArgumentException">In case of invalid parameters.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public Size PreviewResolution
        {
            get
            {
                CameraErrorFactory.ThrowIfError(GetPreviewResolution(_camera.GetHandle(), out int width, out int height),
                    "Failed to get camera preview resolution");

                return new Size(width, height);
            }

            set
            {
                CameraErrorFactory.ThrowIfError(SetPreviewResolution(_camera.GetHandle(), value.Width, value.Height),
                    "Failed to set preview resolution.");
            }
        }

        /// <summary>
        /// Gets the recommended preview resolution.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Depending on the capture resolution aspect ratio and the display resolution,
        /// the recommended preview resolution is determined.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public Size RecommendedPreviewResolution
        {
            get
            {
                CameraErrorFactory.ThrowIfError(GetRecommendedPreviewResolution(_camera.GetHandle(), out int width, out int height),
                    "Failed to get recommended preview resolution");

                return new Size(width, height);
            }
        }

        /// <summary>
        /// The preview data format.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A <see cref="CameraPixelFormat"/> that specifies the pixel format of the preview data.</value>
        /// <exception cref="ArgumentException">In case of invalid parameters.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public CameraPixelFormat PreviewPixelFormat
        {
            get
            {
                CameraErrorFactory.ThrowIfError(GetPreviewPixelFormat(_camera.GetHandle(), out var val),
                    "Failed to get preview format");

                return val;
            }

            set
            {
                ValidationUtil.ValidateEnum(typeof(CameraPixelFormat), value, nameof(value));

                CameraErrorFactory.ThrowIfError(SetPreviewPixelFormat(_camera.GetHandle(), value),
                    "Failed to set preview format.");
            }
        }

        /// <summary>
        /// Resolution of the captured image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ArgumentException">In case of invalid parameters.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public Size CaptureResolution
        {
            get
            {
                CameraErrorFactory.ThrowIfError(GetCaptureResolution(_camera.GetHandle(), out int width, out int height),
                    "Failed to get camera capture resolution");

                return new Size(width, height);
            }

            set
            {
                Size res = value;

                CameraErrorFactory.ThrowIfError(SetCaptureResolution(_camera.GetHandle(), res.Width, res.Height),
                    "Failed to set capture resolution.");
            }
        }

        /// <summary>
        /// Format of an image to be captured.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A <see cref="CameraPixelFormat"/> that specifies the pixel format of captured image.</value>
        /// <exception cref="ArgumentException">In case of invalid parameters.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public CameraPixelFormat CapturePixelFormat
        {
            get
            {
                CameraErrorFactory.ThrowIfError(GetCaptureFormat(_camera.GetHandle(), out var val),
                    "Failed to get camera capture formats");

                return val;
            }

            set
            {
                ValidationUtil.ValidateEnum(typeof(CameraPixelFormat), value, nameof(value));

                CameraErrorFactory.ThrowIfError(SetCaptureFormat(_camera.GetHandle(), value),
                    "Failed to set capture format.");
            }
        }
        #endregion Resolution, Format, Fps of preview, capture

        #region Encoded preview
        /// <summary>
        /// The bit rate of the encoded preview.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public int EncodedPreviewBitrate
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetBitrate(_camera.GetHandle(), out int val),
                    "Failed to get preview bitrate");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Native.SetBitrate(_camera.GetHandle(), value),
                    "Failed to set encoded preview bitrate.");
            }
        }

        /// <summary>
        /// The GOP(Group Of Pictures) interval of the encoded preview.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public int EncodedPreviewGopInterval
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetGopInterval(_camera.GetHandle(), out int val),
                    "Failed to get preview gop interval");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Native.SetGopInterval(_camera.GetHandle(), value),
                    "Failed to set encoded preview gop intervals.");
            }
        }
        #endregion Encoded preview

        /// <summary>
        /// The theater mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A <see cref="CameraTheaterMode"/> that specifies the theater mode.</value>
        /// <remarks>
        /// If you want to display the preview image on the external display with the full screen mode,
        /// use this property.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public CameraTheaterMode TheaterMode
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetTheaterMode(_camera.GetHandle(), out var val),
                    "Failed to get camera theater mode");

                return val;
            }

            set
            {
                ValidationUtil.ValidateEnum(typeof(CameraTheaterMode), value, nameof(value));

                CameraErrorFactory.ThrowIfError(Native.SetTheaterMode(_camera.GetHandle(), value),
                    "Failed to set camera theater mode.");
            }
        }

        /// <summary>
        /// The camera effect mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A <see cref="CameraEffectMode"/> that specifies the effect mode.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public CameraEffectMode Effect
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetEffect(_camera.GetHandle(), out var val),
                    "Failed to get camera effect");

                return val;
            }

            set
            {
                ValidationUtil.ValidateEnum(typeof(CameraEffectMode), value, nameof(value));

                CameraErrorFactory.ThrowIfError(Native.SetEffect(_camera.GetHandle(), value),
                    "Failed to set camera effect.");
            }
        }

        /// <summary>
        /// The scene mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A <see cref="CameraSceneMode"/> that specifies the scene mode.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public CameraSceneMode SceneMode
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetSceneMode(_camera.GetHandle(), out var val),
                    "Failed to get camera scene mode");

                return val;
            }

            set
            {
                ValidationUtil.ValidateEnum(typeof(CameraSceneMode), value, nameof(value));

                CameraErrorFactory.ThrowIfError(Native.SetSceneMode(_camera.GetHandle(), value),
                    "Failed to set camera scene mode.");
            }
        }

        /// <summary>
        /// The camera's flash mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A <see cref="CameraFlashMode"/> that specifies the flash mode.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public CameraFlashMode FlashMode
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetFlashMode(_camera.GetHandle(), out var val),
                    "Failed to get camera flash mode");

                return val;
            }

            set
            {
                ValidationUtil.ValidateEnum(typeof(CameraFlashMode), value, nameof(value));

                CameraErrorFactory.ThrowIfError(Native.SetFlashMode(_camera.GetHandle(), value),
                    "Failed to set camera flash mode.");
            }
        }

        /// <summary>
        /// Gets the camera lens orientation angle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public int LensOrientation
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetLensOrientation(_camera.GetHandle(), out var val),
                    "Failed to get camera lens orientation");

                return val;
            }
        }

        /// <summary>
        /// The stream rotation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A <see cref="Rotation"/> that specifies the rotation of camera device.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public Rotation StreamRotation
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetStreamRotation(_camera.GetHandle(), out var val),
                    "Failed to get camera stream rotation");

                return val;
            }

            set
            {
                ValidationUtil.ValidateEnum(typeof(Rotation), value, nameof(value));

                CameraErrorFactory.ThrowIfError(Native.SetStreamRotation(_camera.GetHandle(), value),
                    "Failed to set camera stream rotation.");
            }
        }

        /// <summary>
        /// The stream flip.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A <see cref="Flips"/> that specifies the camera flip type.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public Flips StreamFlip
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetFlip(_camera.GetHandle(), out var val),
                    "Failed to get camera stream flip");

                return val;
            }

            set
            {
                ValidationUtil.ValidateFlagsEnum(value, Flips.Horizontal | Flips.Vertical, nameof(Flips));

                CameraErrorFactory.ThrowIfError(Native.SetFlip(_camera.GetHandle(), value),
                    "Failed to set camera flip.");
            }
        }

        /// <summary>
        /// The mode of the HDR(High dynamic range) capture.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A <see cref="CameraHdrMode"/> that specifies the HDR mode.</value>
        /// <remarks>
        /// Taking multiple pictures at different exposure levels and intelligently stitching them together,
        /// so that we eventually arrive at a picture that is representative in both dark and bright areas.
        /// If this attribute is set, then event handler set for the HdrCaptureProgress event is invoked.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public CameraHdrMode HdrMode
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetHdrMode(_camera.GetHandle(), out var val),
                    "Failed to get camera hdr mode");

                return val;
            }

            set
            {
                ValidationUtil.ValidateEnum(typeof(CameraHdrMode), value, nameof(value));

                CameraErrorFactory.ThrowIfError(Native.SetHdrMode(_camera.GetHandle(), value),
                    "Failed to set camera hdr mode.");
            }
        }

        /// <summary>
        /// The anti shake feature.
        /// If true, the antishake feature is enabled, otherwise false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public bool AntiShake
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.IsEnabledAntiShake(_camera.GetHandle(), out bool val),
                    "Failed to get camera anti shake value");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Native.EnableAntiShake(_camera.GetHandle(), value),
                    "Failed to set camera anti shake value.");
            }
        }

        /// <summary>
        /// Enables or disables the video stabilization feature.
        /// If true, video stabilization is enabled, otherwise false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// If video stabilization is enabled, zero shutter lag is disabled.
        /// This feature is used to record a video.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public bool VideoStabilization
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.IsEnabledVideoStabilization(_camera.GetHandle(), out bool val),
                    "Failed to get camera video stabilization");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Native.EnableVideoStabilization(_camera.GetHandle(), value),
                    "Failed to set camera video stabilization.");
            }
        }

        /// <summary>
        /// Turn the shutter sound on or off, if it is permitted by policy.
        /// </summary>
        /// <param name="shutterSound">Shutter sound On/Off flag</param>
        /// <since_tizen> 4 </since_tizen>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <remarks>
        /// If this value is true, shutter sound will be disabled, otherwise enabled.
        /// In some countries, this operation is not permitted.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Disabling shutter sound is not permitted.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public void DisableShutterSound(bool shutterSound)
        {
            CameraErrorFactory.ThrowIfError(Native.DisableShutterSound(_camera.GetHandle(), shutterSound),
                    "Failed to set disable shutter sound.");
        }

        #region PTZ(Pan Tilt Zoom), Pan, Tilt
        /// <summary>
        /// Sets the type of the PTZ(Pan Tilt Zoom). Mechanical or electronic.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A <see cref="CameraPtzType"/> that specifies the type of the PTZ.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public CameraPtzType PtzType
        {
            set
            {
                ValidationUtil.ValidateEnum(typeof(CameraPtzType), value, nameof(value));

                CameraErrorFactory.ThrowIfError(Native.SetPtzType(_camera.GetHandle(), value),
                    "Failed to set camera ptz type.");
            }
        }

        /// <summary>
        /// Sets the position to move horizontally.
        /// </summary>
        /// <param name="type">The PTZ move type. <seealso cref="CameraPtzMoveType"/>.</param>
        /// <param name="panStep">The pan step.</param>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <exception cref="ArgumentException">In case of invalid parameters.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public void SetPan(CameraPtzMoveType type, int panStep)
        {
            ValidationUtil.ValidateEnum(typeof(CameraPtzMoveType), type, nameof(type));

            CameraErrorFactory.ThrowIfError(Native.SetPan(_camera.GetHandle(), type, panStep),
                "Failed to set the camera pan type.");
        }

        /// <summary>
        /// Gets the current position of the camera.
        /// </summary>
        /// <returns>Returns the camera's horizontal position.</returns>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public int GetPan()
        {
            CameraErrorFactory.ThrowIfError(Native.GetPan(_camera.GetHandle(), out int val),
                "Failed to get the camera pan step.");

            return val;
        }

        /// <summary>
        /// Sets the position to move vertically.
        /// </summary>
        /// <param name="type">the PTZ move type.</param>
        /// <param name="tiltStep">The tilt step.</param>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <exception cref="ArgumentException">In case of invalid parameters.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public void SetTilt(CameraPtzMoveType type, int tiltStep)
        {
            ValidationUtil.ValidateEnum(typeof(CameraPtzMoveType), type, nameof(type));
            CameraErrorFactory.ThrowIfError(Native.SetTilt(_camera.GetHandle(), type, tiltStep),
                "Failed to set the camera tilt type\t.");
        }

        /// <summary>
        /// Gets the current position of the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <returns>Returns the current vertical position.</returns>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public int GetTilt()
        {
            CameraErrorFactory.ThrowIfError(Native.GetTilt(_camera.GetHandle(), out int val),
                "Failed to set the camera current position.");

            return val;
        }

        /// <summary>
        /// Gets the lower limit and the upper limit for the pan position.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// If the minimum value is greater than the maximum value, it means this feature is not supported.
        /// </remarks>
        /// <exception cref="NotSupportedException">In case of this feature is not supported.</exception>
        public Range PanRange
        {
            get
            {
                if (!_panRange.HasValue)
                {
                    throw new NotSupportedException("Pan is not supported.");
                }

                return _panRange.Value;
            }
        }

        /// <summary>
        /// Gets the lower limit and the upper limit for the tilt position.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// If the minimum value is greater than the maximum value, it means this feature is not supported.
        /// </remarks>
        /// <exception cref="NotSupportedException">In case of this feature is not supported.</exception>
        public Range TiltRange
        {
            get
            {
                if (!_tiltRange.HasValue)
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
        /// </summary>
        /// <value>true if EXIF tags are enabled in the JPEG file, otherwise false.</value>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public bool EnableTag
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.IsEnabledTag(_camera.GetHandle(), out bool val),
                    "Failed to get camera enable tag");

                return val;
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Native.EnableTag(_camera.GetHandle(), value),
                    "Failed to set camera enable tag.");
            }
        }

        /// <summary>
        /// The camera image description in the EXIF tag.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public string ImageDescriptionTag
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    CameraErrorFactory.ThrowIfError(Native.GetImageDescription(_camera.GetHandle(), out val),
                    "Failed to get image description");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    LibcSupport.Free(val);
                }
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Native.SetImageDescription(_camera.GetHandle(), value),
                    "Failed to set image description.");
            }
        }

        /// <summary>
        /// The software information in the EXIF tag.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public string SoftwareTag
        {
            get
            {
                IntPtr val = IntPtr.Zero;

                try
                {
                    CameraErrorFactory.ThrowIfError(Native.GetTagSoftware(_camera.GetHandle(), out val),
                    "Failed to get tag software");

                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    LibcSupport.Free(val);
                }
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Native.SetTagSoftware(_camera.GetHandle(), value),
                    "Failed to set tag software.");
            }
        }

        /// <summary>
        /// The geo tag(GPS data) in the EXIF tag.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public Location GeoTag
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetGeotag(_camera.GetHandle(),
                    out double latitude, out double longitude, out double altitude), "Failed to get tag");

                return new Location(latitude, longitude, altitude);
            }

            set
            {
                CameraErrorFactory.ThrowIfError(Native.SetGeotag(_camera.GetHandle(),
                    value.Latitude, value.Longitude, value.Altitude), "Failed to set geo tag.");
            }
        }

        /// <summary>
        /// Removes the geo tag(GPS data) in the EXIF(EXchangeable Image File format) tag.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/camera </feature>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public void RemoveGeoTag()
        {
            CameraErrorFactory.ThrowIfError(Native.RemoveGeotag(_camera.GetHandle()),
                "Failed to remove the geotag\t.");
        }

        /// <summary>
        /// The camera orientation in the tag.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public CameraTagOrientation OrientationTag
        {
            get
            {
                CameraErrorFactory.ThrowIfError(Native.GetTagOrientation(_camera.GetHandle(), out var val),
                    "Failed to get camera tag orientation");

                return val;
            }

            set
            {
                ValidationUtil.ValidateEnum(typeof(CameraTagOrientation), value, nameof(value));

                CameraErrorFactory.ThrowIfError(Native.SetTagOrientation(_camera.GetHandle(), value),
                    "Failed to set camera tag orientation.");
            }
        }
        #endregion EXIF tag
    }
}
