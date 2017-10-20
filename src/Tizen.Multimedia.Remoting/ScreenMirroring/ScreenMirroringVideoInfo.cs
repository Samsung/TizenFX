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
    /// Provides a means to retrieve the video information which is negotiated with the source device.
    /// </summary>
    public class ScreenMirroringVideoInfo
    {
        private readonly ScreenMirroring _owner;

        internal ScreenMirroringVideoInfo(ScreenMirroring owner)
        {
            _owner = owner;
        }

        /// <summary>
        /// Gets the negotiated video codec.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Not connected to a source.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="ScreenMirroring"/> has already been disposed.</exception>
        public ScreenMirroringVideoCodec Codec
        {
            get
            {
                _owner.ThrowIfNotConnected();

                GetValue(Native.GetNegotiatedVideoCodec, _owner.Handle, out ScreenMirroringVideoCodec value).
                    ThrowIfError("Failed to get video codec.");

                return value;
            }
        }

        /// <summary>
        /// Gets the negotiated video resolution.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Not connected to a source.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="ScreenMirroring"/> has already been disposed.</exception>
        public Size Resolution
        {
            get
            {
                _owner.ThrowIfNotConnected();

                var handle = _owner.Handle;
                Native.GetNegotiatedVideoResolution(ref handle, out var width, out var height).
                    ThrowIfError("Failed to get resolution.");

                return new Size(width, height);
            }
        }

        /// <summary>
        /// Gets the negotiated video frame rate.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Not connected to a source.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="ScreenMirroring"/> has already been disposed.</exception>
        public int FrameRate
        {
            get
            {
                _owner.ThrowIfNotConnected();

                GetValue(Native.GetNegotiatedVideoFrameRate, _owner.Handle, out int value).
                    ThrowIfError("Failed to get video frame rate.");

                return value;
            }
        }
    }
}
