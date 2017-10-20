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
using static Tizen.Multimedia.Remoting.InteropHelper;
using Native = Interop.ScreenMirroring;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides a means to retrieve the audio information which is negotiated with the source device.
    /// </summary>
    /// <seealso cref="ScreenMirroring"/>
    public class ScreenMirroringAudioInfo
    {
        private readonly ScreenMirroring _owner;

        internal ScreenMirroringAudioInfo(ScreenMirroring owner)
        {
            _owner = owner;
        }

        /// <summary>
        /// Gets the negotiated audio codec.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Not connected to a source.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="ScreenMirroring"/> has already been disposed.</exception>
        public ScreenMirroringAudioCodec Codec
        {
            get
            {
                _owner.ThrowIfNotConnected();

                GetValue(Native.GetNegotiatedAudioCodec, _owner.Handle, out ScreenMirroringAudioCodec value).
                    ThrowIfError("Failed to get audio codec.");

                return value;
            }
        }

        /// <summary>
        /// Gets the negotiated audio channels.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Not connected to a source.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="ScreenMirroring"/> has already been disposed.</exception>
        public int Channels
        {
            get
            {
                _owner.ThrowIfNotConnected();

                GetValue(Native.GetNegotiatedAudioChannel, _owner.Handle, out int value).
                    ThrowIfError("Failed to get audio channels.");

                return value;
            }
        }

        /// <summary>
        /// Gets the negotiated audio sample rate.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Not connected to a source.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="ScreenMirroring"/> has already been disposed.</exception>
        public int SampleRate
        {
            get
            {
                _owner.ThrowIfNotConnected();

                GetValue(Native.GetNegotiatedAudioSampleRate, _owner.Handle, out int value).
                    ThrowIfError("Failed to get audio sample rate.");

                return value;
            }
        }

        /// <summary>
        /// Gets the negotiated audio bit width.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Not connected to a source.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="ScreenMirroring"/> has already been disposed.</exception>
        public int BitWidth
        {
            get
            {
                _owner.ThrowIfNotConnected();

                GetValue(Native.GetNegotiatedAudioBitwidth, _owner.Handle, out int value).
                    ThrowIfError("Failed to get audio bit width.");

                return value;
            }
        }
    }
}
