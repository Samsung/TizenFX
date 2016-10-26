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

namespace Tizen.Multimedia
{
    /// <summary>
    /// The camera setting class provides methods/properties to get and
    /// set basic camera attributes.
    /// </summary>
    public class CameraSetting
    {
        internal readonly IntPtr _settingHandle;

        internal CameraSetting(IntPtr _handle)
        {
            _settingHandle = _handle;
        }

        /// <summary>
        /// Sets auto focus area.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public void SetFocusArea(int x, int y)
        {
            int ret = Interop.CameraSetting.SetAfArea(_settingHandle, x, y);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Failed to set the autofocus area.");
            }
        }

        /// <summary>
        /// Clears the auto focus area.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        public void ClearFocusArea()
        {
            int ret = Interop.CameraSetting.ClearAfArea(_settingHandle);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Failed to clear the autofocus area.");
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
            int ret = Interop.CameraSetting.SetPan(_settingHandle, (int)type, panStep);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Failed to set the camera pan type.");
            }
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
            int ret = Interop.CameraSetting.GetPan(_settingHandle, out val);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Failed to get the camera pan step.");
            }

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
            int ret = Interop.CameraSetting.SetTilt(_settingHandle, (int)type, tiltStep);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Failed to set the camera tilt type\t.");
            }
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
            int ret = Interop.CameraSetting.GetTilt(_settingHandle, out val);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Failed to set the camera current position.");
            }

            return val;
        }

        /// <summary>
        /// Removes the geotag(GPS data) in the EXIF(Exchangeable image file format) tag.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        public void RemoveGeoTag()
        {
            int ret = Interop.CameraSetting.RemoveGeotag(_settingHandle);
            if (ret != (int)CameraError.None)
            {
                CameraErrorFactory.ThrowException(ret, "Failed to remove the geotag\t.");
            }
        }

        /// <summary>
        /// The preview frame rate.
        /// </summary>
        public CameraFps PreviewFps
        {
            get
            {
                int val = 0;
                int ret = Interop.CameraSetting.GetPreviewFps(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera preview fps, " + (CameraError)ret);
                }

                return (CameraFps)val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetPreviewFps(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set preview fps, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set preview fps.");
                }
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
                int ret = Interop.CameraSetting.GetImageQuality(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get image quality, " + (CameraError)ret);
                }

                return val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetImageQuality(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set image quality, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set image quality.");
                }
            }
        }

        /// <summary>
        /// The bit rate of encoded preview.
        /// </summary>
        public int EncodedPreviewBitrate
        {
            get
            {
                int val = 0;
                int ret = Interop.CameraSetting.GetBitrate(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get preview bitrate, " + (CameraError)ret);
                }

                return val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetBitrate(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set encoded preview bitrate, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set encoded preview bitrate.");
                }
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
                int ret = Interop.CameraSetting.GetGopInterval(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get preview gop interval, " + (CameraError)ret);
                }

                return val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetGopInterval(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set encoded preview gop interval, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set encoded preview gop intervals.");
                }
            }
        }

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
                int ret = Interop.CameraSetting.GetZoom(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get zoom level, " + (CameraError)ret);
                }

                return val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetZoom(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set zoom level, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set zoom level.");
                }
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
                int min = 0;
                int max = 0;

                int ret = Interop.CameraSetting.GetZoomRange(_settingHandle, out min, out max);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get zoom range, " + (CameraError)ret);
                }

                Range res = new Range(min, max);
                return res;
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
                int min = 0;
                int max = 0;

                int ret = Interop.CameraSetting.GetExposureRange(_settingHandle, out min, out max);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get exposure range, " + (CameraError)ret);
                }

                Range res = new Range(min, max);
                return res;
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
                int min = 0;
                int max = 0;

                int ret = Interop.CameraSetting.GetBrightnessRange(_settingHandle, out min, out max);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get brightness range, " + (CameraError)ret);
                }

                Range res = new Range(min, max);
                return res;
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
                int min = 0;
                int max = 0;

                int ret = Interop.CameraSetting.GetContrastRange(_settingHandle, out min, out max);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get contrast range, " + (CameraError)ret);
                }

                Range res = new Range(min, max);
                return res;
            }
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
                int min = 0;
                int max = 0;

                int ret = Interop.CameraSetting.GetPanRange(_settingHandle, out min, out max);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get pan range, " + (CameraError)ret);
                }

                Range res = new Range(min, max);
                return res;
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
                int min = 0;
                int max = 0;

                int ret = Interop.CameraSetting.GetTiltRange(_settingHandle, out min, out max);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get tilt range, " + (CameraError)ret);
                }

                Range res = new Range(min, max);
                return res;
            }
        }

        /// <summary>
        /// The auto focus mode.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        public CameraAutoFocusMode AfMode
        {
            get
            {
                int val = 0;
                int ret = Interop.CameraSetting.GetAfMode(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera autofocus mode, " + (CameraError)ret);
                }

                return (CameraAutoFocusMode)val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetAfMode(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera autofocus mode, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera autofocus mode.");
                }
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
                int val = 0;
                int ret = Interop.CameraSetting.GetExposureMode(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera exposure mode, " + (CameraError)ret);
                }

                return (CameraExposureMode)val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetExposureMode(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera exposure mode, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera exposure mode.");
                }
            }
        }

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
                int ret = Interop.CameraSetting.GetExposure(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera exposure value, " + (CameraError)ret);
                }

                return val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetExposure(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera exposure value, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera exposure value.");
                }
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
                int val = 0;
                int ret = Interop.CameraSetting.GetIso(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera Iso level, " + (CameraError)ret);
                }

                return (CameraIsoLevel)val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetIso(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera Iso level, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera Iso level.");
                }
            }
        }

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
                int val = 0;
                int ret = Interop.CameraSetting.GetTheaterMode(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera theater mode, " + (CameraError)ret);
                }

                return (CameraTheaterMode)val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetTheaterMode(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera theater mode, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera theater mode.");
                }
            }
        }

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
                int ret = Interop.CameraSetting.GetBrightness(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera brightness value, " + (CameraError)ret);
                }

                return val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetBrightness(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera brightness value, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera brightness value.");
                }
            }
        }

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
                int ret = Interop.CameraSetting.GetContrast(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera contrast value, " + (CameraError)ret);
                }

                return val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetContrast(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera contrast value, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera contrast value.");
                }
            }
        }

        /// <summary>
        /// The whitebalance mode.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        public CameraWhitebalance Whitebalance
        {
            get
            {
                int val = 0;
                int ret = Interop.CameraSetting.GetWhitebalance(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera whitebalance, " + (CameraError)ret);
                }

                return (CameraWhitebalance)val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetWhitebalance(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera whitebalance, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera whitebalance.");
                }
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
                int val = 0;
                int ret = Interop.CameraSetting.GetEffect(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera effect, " + (CameraError)ret);
                }

                return (CameraEffectMode)val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetEffect(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera effect, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera effect.");
                }
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
                int val = 0;
                int ret = Interop.CameraSetting.GetSceneMode(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera scene mode, " + (CameraError)ret);
                }

                return (CameraSceneMode)val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetSceneMode(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera scene mode, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera scene mode.");
                }
            }
        }

        /// <summary>
        /// The scene mode.
        /// true if EXIF tags are enabled in JPEG file, otherwise false.
        /// </summary>
        public bool EnableTag
        {
            get
            {
                bool val = false;
                int ret = Interop.CameraSetting.IsEnabledTag(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera enable tag, " + (CameraError)ret);
                }

                return val;
            }

            set
            {
                int ret = Interop.CameraSetting.EnableTag(_settingHandle, (bool)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera enable tag, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera enable tag.");
                }
            }
        }

        /// <summary>
        /// The camera image description in the EXIF tag.
        /// </summary>
        public string ImageDescription
        {
            get
            {
                IntPtr val;
                int ret = Interop.CameraSetting.GetImageDescription(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get image description, " + (CameraError)ret);
                }

                string result = Marshal.PtrToStringAnsi(val);
                Interop.Libc.Free(val);
                return result;
            }

            set
            {
                int ret = Interop.CameraSetting.SetImageDescription(_settingHandle, value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set image description, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set image description.");
                }
            }
        }

        /// <summary>
        /// The software information in the EXIF tag.
        /// </summary>
        public string TagSoftware
        {
            get
            {
                IntPtr val;
                int ret = Interop.CameraSetting.GetTagSoftware(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get tag software, " + (CameraError)ret);
                }

                string result = Marshal.PtrToStringAnsi(val);
                Interop.Libc.Free(val);
                return result;
            }

            set
            {
                int ret = Interop.CameraSetting.SetTagSoftware(_settingHandle, value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set tag software, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set tag software.");
                }
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

                int ret = Interop.CameraSetting.GetGeotag(_settingHandle, out latitude, out longitude, out altitude);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get tag, " + (CameraError)ret);
                }

                Location loc = new Location(latitude, longitude, altitude);
                return loc;
            }

            set
            {
                Location loc = value;
                int ret = Interop.CameraSetting.SetGeotag(_settingHandle, loc.Latitude, loc.Longitude, loc.Altitude);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get contrast range, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set geo tag.");
                }
            }
        }

        /// <summary>
        /// The camera orientation in the tag.
        /// </summary>
        public CameraTagOrientation TagOrientation
        {
            get
            {
                int val = 0;
                int ret = Interop.CameraSetting.GetTagOrientation(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera tag orientation, " + (CameraError)ret);
                }

                return (CameraTagOrientation)val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetTagOrientation(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera tag orientation, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera tag orientation.");
                }
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
                int val = 0;
                int ret = Interop.CameraSetting.GetFlashMode(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera flash mode, " + (CameraError)ret);
                }

                return (CameraFlashMode)val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetFlashMode(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera flash mode, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera flash mode.");
                }
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
                int ret = Interop.CameraSetting.GetLensOrientation(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera lens orientation, " + (CameraError)ret);
                }

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
                int val = 0;
                int ret = Interop.CameraSetting.GetStreamRotation(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera stream rotation, " + (CameraError)ret);
                }

                return (CameraRotation)val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetStreamRotation(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera stream rotation, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera stream rotation.");
                }
            }
        }

        /// <summary>
        /// The stream flip.
        /// </summary>
        public CameraFlip StreamFlip
        {
            get
            {
                int val = 0;
                int ret = Interop.CameraSetting.GetFlip(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera stream flip, " + (CameraError)ret);
                }

                return (CameraFlip)val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetFlip(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera stream flip, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera flip.");
                }
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
                int val = 0;
                int ret = Interop.CameraSetting.GetHdrMode(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera hdr mode, " + (CameraError)ret);
                }

                return (CameraHdrMode)val;
            }

            set
            {
                int ret = Interop.CameraSetting.SetHdrMode(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera hdr mode, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera hdr mode.");
                }
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
                int ret = Interop.CameraSetting.IsEnabledAntiShake(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera anti shake value, " + (CameraError)ret);
                }

                return val;
            }

            set
            {
                int ret = Interop.CameraSetting.EnableAntiShake(_settingHandle, (bool)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera anti shake value, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera anti shake value.");
                }
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
                int ret = Interop.CameraSetting.IsEnabledVideoStabilization(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera video stabilization, " + (CameraError)ret);
                }

                return val;
            }

            set
            {
                int ret = Interop.CameraSetting.EnableVideoStabilization(_settingHandle, (bool)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera video stabilization, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera video stabilization.");
                }
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
                int ret = Interop.CameraSetting.IsEnabledAutoContrast(_settingHandle, out val);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get camera auto contrast, " + (CameraError)ret);
                }

                return val;
            }

            set
            {
                int ret = Interop.CameraSetting.EnableAutoContrast(_settingHandle, (bool)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera enable auto contrast, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera enable auto contrast.");
                }
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
                int ret = Interop.CameraSetting.DisableShutterSound(_settingHandle, (bool)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to disable shutter sound, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set disable shutter sound.");
                }
            }
        }

        /// <summary>
        /// Sets the type of PTZ(Pan Tilt Zoom).
        /// </summary>
        public CameraPtzType PtzType
        {
            set
            {
                int ret = Interop.CameraSetting.SetPtzType(_settingHandle, (int)value);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set camera ptz type, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set camera ptz type.");
                }
            }
        }

        /// <summary>
        /// the ROI(Region Of Interest) area of display.
        /// </summary>
        public Area DisplayRoiArea
        {
            get
            {
                int x = 0;
                int y = 0;
                int width = 0;
                int height = 0;

                int ret = Interop.CameraSetting.GetDisplayRoiArea(_settingHandle, out x, out y, out width, out height);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to get display roi area, " + (CameraError)ret);
                }

                Area ar = new Area(x, y, width, height);
                return ar;
            }

            set
            {
                Area ar = (Area)value;
                int ret = Interop.CameraSetting.SetDisplayRoiArea(_settingHandle, ar.X, ar.Y, ar.Width, ar.Height);
                if ((CameraError)ret != CameraError.None)
                {
                    Log.Error(CameraLog.Tag, "Failed to set display roi area, " + (CameraError)ret);
                    CameraErrorFactory.ThrowException(ret, "Failed to set display roi area.");
                }
            }
        }
    }
}

