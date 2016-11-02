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

namespace Tizen.Multimedia.MediaCodec
{
    /// <summary>
    /// Provides data for the <see cref="MediaCodec.OutputAvailable"/> event.
    /// </summary>
    /// <remarks>The output packet needs to be disposed after it is used to clean up unmanaged resources.</remarks>
    public class OutputAvailableEventArgs : EventArgs
    {
        private readonly MediaPacket _packet;

        internal OutputAvailableEventArgs(IntPtr packetHandle)
        {
            _packet = MediaPacket.From(packetHandle);
        }

        /// <summary>
        /// Gets the result packet.
        /// </summary>
        public MediaPacket Packet
        {
            get
            {
                return _packet;
            }
        }
    }
}
