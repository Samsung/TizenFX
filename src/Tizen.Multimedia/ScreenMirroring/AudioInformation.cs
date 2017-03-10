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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Audio Information class provides audio information which is negotiated with source device for screen mirroring. e.g codec
    /// </summary>
    /// <remarks>
    /// This class provides properties and API that are required for setting audio information.
    /// For getting property using this api, we should call it after connectAsync() api.
    /// </remarks>
    public class AudioInformation
    {
        internal IntPtr _handle;
        private int _codec;
        private int _channel;
        private int _sampleRate;
        private int _bitWidth;

        internal AudioInformation()
        {
        }

        /// <summary>
        /// Get audio codec.
        /// </summary>
        /// <value> Get audio codec which is one of enums in 'AudioCodec' which is negotiaged with source device.  </value>
        /// <exception cref="InvalidOperationException">Thrown when method fail due to an internal error</exception>
        public AudioCodec Codec
        {
            get
            {
                int ret;
                ret = Interop.ScreenMirroring.GetNegotiatedAudioCodec(ref _handle, out _codec);
                if (ret != (int)ScreenMirroringError.None)
                {
                    Log.Error(ScreenMirroringLog.LogTag, "Failed to get audio codec" + (ScreenMirroringError)ret);
                    ScreenMirroringErrorFactory.ThrowException(ret, "failed to get audio codec");
                }

                return (AudioCodec)_codec;
            }
        }

        /// <summary>
        /// Get audio channel.
        /// </summary>
        /// <value> Get audio channel property of audio information which is negotiated with source device. </value>
        /// <exception cref="InvalidOperationException">Thrown when method fail due to an internal error</exception>
        public int Channel
        {
            get
            {
                int ret;
                ret = Interop.ScreenMirroring.GetNegotiatedAudioChannel(ref _handle, out _channel);
                if (ret != (int)ScreenMirroringError.None)
                {
                    Log.Error(ScreenMirroringLog.LogTag, "Failed to get audio channel" + (ScreenMirroringError)ret);
                    ScreenMirroringErrorFactory.ThrowException(ret, "failed to get audio channel");
                }

                return _channel;
            }
        }

        /// <summary>
        /// Get audio sample rate.
        /// </summary>
        /// <value> Get audio sample rate property which is negotiated with source device. </value>
        /// <exception cref="InvalidOperationException">Thrown when method fail due to an internal error</exception>
        public int SampleRate
        {
            get
            {
                int ret;
                ret = Interop.ScreenMirroring.GetNegotiatedAudioSampleRate(ref _handle, out _sampleRate);
                if (ret != (int)ScreenMirroringError.None)
                {
                    Log.Error(ScreenMirroringLog.LogTag, "Failed to get audio sample rate" + (ScreenMirroringError)ret);
                    ScreenMirroringErrorFactory.ThrowException(ret, "failed to get audio sample rate");
                }

                return _sampleRate;
            }
        }

        /// <summary>
        /// Get audio bitwidth.
        /// </summary>
        /// <value> Get audio bitwidth property which is negotiated with source device. </value>
        /// <exception cref="InvalidOperationException">Thrown when method fail due to an internal error</exception>
        public int BitWidth
        {
            get
            {
                int ret;
                ret = Interop.ScreenMirroring.GetNegotiatedAudioBitwidth(ref _handle, out _bitWidth);
                if (ret != (int)ScreenMirroringError.None)
                {
                    Log.Error(ScreenMirroringLog.LogTag, "Failed to get audio bitwidth" + (ScreenMirroringError)ret);
                    ScreenMirroringErrorFactory.ThrowException(ret, "failed to get audio bitwidth");
                }

                return _bitWidth;
            }
        }
    }
}
