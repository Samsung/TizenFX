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

namespace Tizen.Multimedia.MediaCodec
{
    /// <summary>
    /// Provides data for the <see cref="MediaCodec.InputProcessed"/> event.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class InputProcessedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the InputProcessedEventArgs class.
        /// </summary>
        /// <param name="packet">The packet that the codec has processed.</param>
        internal InputProcessedEventArgs(MediaPacket packet)
        {
            Debug.Assert(packet != null);

            Packet = packet;
        }

        /// <summary>
        /// Gets the packet processed by the codec.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public MediaPacket Packet { get; }
    }
}
