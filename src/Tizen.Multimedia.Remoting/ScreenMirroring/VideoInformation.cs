/// Video Information
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
using Native = Interop.ScreenMirroring;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Video Information class provides video information which is negotiated with source device for screen mirroring. e.g codec
    /// </summary>
    /// <remarks>
    /// This class provides properties and API that are required for setting video information.
    /// For getting property using this api, we should call it after connectAsync() api.
    /// </remarks>
    public class VideoInformation
    {
        internal IntPtr _handle;
        private int _codec;
        private int _height;
        private int _width;
        private int _frameRate;

        internal VideoInformation()
        {
        }

        /// <summary>
        /// Get video codec.
        /// </summary>
        /// <value> Get video codec which is one of enums in 'VideoCodec' which is negotiaged with source device. </value>
        /// <exception cref="InvalidOperationException">Thrown when method fail due to an internal error</exception>
        public VideoCodec Codec
        {
            get
            {
                int ret;
                ret = Native.GetNegotiatedVideoCodec(ref _handle, out _codec);
                if (ret != (int)ScreenMirroringError.None)
                {
                    Log.Error(ScreenMirroringLog.LogTag, "Failed to get video codec" + (ScreenMirroringError)ret);
                    ScreenMirroringErrorFactory.ThrowException(ret, "failed to get video codec");
                }

                return (VideoCodec)_codec;
            }
        }

        /// <summary>
        /// Get height of video resolution.
        /// </summary>
        /// <value> Get height property of video resolution which is negotiated with source device. </value>
        /// <exception cref="InvalidOperationException">Thrown when method fail due to an internal error</exception>
        public int Height
        {
            get
            {
                int ret;
                ret = Native.GetNegotiatedVideoResolution(ref _handle, out _width, out _height);
                if (ret != (int)ScreenMirroringError.None)
                {
                    Log.Error(ScreenMirroringLog.LogTag, "Failed to get height" + (ScreenMirroringError)ret);
                    ScreenMirroringErrorFactory.ThrowException(ret, "failed to get video height");
                }

                return _height;
            }
        }

        /// <summary>
        /// Get width of video.
        /// </summary>
        /// <value> Get width property of video resolution which is negotiated with source device. </value>
        /// <exception cref="InvalidOperationException">Thrown when method fail due to an internal error</exception>
        public int Width
        {
            get
            {
                int ret;
                ret = Native.GetNegotiatedVideoResolution(ref _handle, out _width, out _height);
                if (ret != (int)ScreenMirroringError.None)
                {
                    Log.Error(ScreenMirroringLog.LogTag, "Failed to get width" + (ScreenMirroringError)ret);
                    ScreenMirroringErrorFactory.ThrowException(ret, "failed to get video width");
                }

                return _width;
            }
        }

        /// <summary>
        /// Get video frame rate.
        /// </summary>
        /// <value> Get video frame rate property which is negotiated with source device.  </value>
        /// <exception cref="InvalidOperationException">Thrown when method fail due to an internal error</exception>
        public int FrameRate
        {
            get
            {
                int ret;
                ret = Native.GetNegotiatedVideoFrameRate(ref _handle, out _frameRate);
                if (ret != (int)ScreenMirroringError.None)
                {
                    Log.Error(ScreenMirroringLog.LogTag, "Failed to get frame rate" + (ScreenMirroringError)ret);
                    ScreenMirroringErrorFactory.ThrowException(ret, "failed to get video frame rate");
                }

                return _frameRate;
            }
        }
    }
}
