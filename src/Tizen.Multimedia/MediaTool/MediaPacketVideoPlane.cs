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
using System.Diagnostics;
using Native = Tizen.Multimedia.Interop.MediaPacket;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents a video plane for the <see cref="MediaPacket"/>.
    /// This class is used if and only if the format of the packet is the raw video.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class MediaPacketVideoPlane
    {
        private readonly MediaPacket _packet;
        private readonly int _strideWidth;
        private readonly int _strideHeight;
        private readonly IMediaBuffer _buffer;

        internal MediaPacketVideoPlane(MediaPacket packet, int index)
        {
            Debug.Assert(packet != null, "The packet is null!");
            Debug.Assert(!packet.IsDisposed, "Packet is already disposed!");
            Debug.Assert(index >= 0, "Video plane index must not be negative!");

            _packet = packet;

            int ret = Native.GetVideoStrideWidth(packet.GetHandle(), index, out _strideWidth);
            MultimediaDebug.AssertNoError(ret);

            ret = Native.GetVideoStrideHeight(packet.GetHandle(), index, out _strideHeight);
            MultimediaDebug.AssertNoError(ret);

            Debug.Assert(_strideWidth >= 0 && _strideHeight >= 0, "size must not be negative!");

            ret = Native.GetVideoPlaneData(packet.GetHandle(), index, out var dataHandle);
            MultimediaDebug.AssertNoError(ret);

            Debug.Assert(dataHandle != IntPtr.Zero, "Data handle is invalid!");

            _buffer = new DependentMediaBuffer(packet, dataHandle, _strideWidth * _strideHeight);
        }

        /// <summary>
        /// Gets the buffer of the current video plane.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The MediaPacket that owns the current buffer has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public IMediaBuffer Buffer
        {
            get
            {
                _packet.EnsureReadableState();
                return _buffer;
            }
        }

        /// <summary>
        /// Gets the stride width of the current video plane.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The MediaPacket that owns the current buffer has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public int StrideWidth
        {
            get
            {
                _packet.EnsureReadableState();
                return _strideWidth;
            }
        }

        /// <summary>
        /// Gets the stride height of the current video plane.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The MediaPacket that owns the current buffer has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public int StrideHeight
        {
            get
            {
                _packet.EnsureReadableState();
                return _strideHeight;
            }
        }
    }
}
