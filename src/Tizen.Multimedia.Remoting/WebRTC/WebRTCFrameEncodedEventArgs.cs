/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides data for the <see cref="WebRTC.AudioFrameEncoded"/> or <see cref="WebRTC.VideoFrameEncoded"/> event.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class WebRTCFrameEncodedEventArgs : EventArgs
    {
        internal WebRTCFrameEncodedEventArgs(MediaStreamTrack track, MediaPacket packet)
        {
            MediaStreamTrack = track;
            Packet = packet;
        }

        /// <summary>
        /// Gets the track information.
        /// </summary>
        /// <value>The media type.</value>
        /// <since_tizen> 9 </since_tizen>
        public MediaStreamTrack MediaStreamTrack { get; }

        /// <summary>
        /// Gets the media packet which has a frame data.
        /// </summary>
        /// <value>The media packet which has a frame data.</value>
        /// <since_tizen> 9 </since_tizen>
        public MediaPacket Packet { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 9 </since_tizen>
        public override string ToString() => $"MediaType={MediaStreamTrack.Type}";
    }
}
