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
using static Interop;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// MediaSource is a base class for <see cref="WebRTC"/> sources.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public abstract class MediaSource
    {
        internal uint? SourceId { get; set; }

        internal WebRTC WebRtc { get; set; }

        internal MediaSource()
        {
        }

        internal void AttachTo(WebRTC webRtc) => OnAttached(webRtc);

        internal void DetachFrom(WebRTC webRtc) => OnDetached(webRtc);

        internal abstract void OnAttached(WebRTC webRtc);

        internal abstract void OnDetached(WebRTC webRtc);

        /// <summary>
        /// Gets the current transceiver direction.
        /// </summary>
        /// <remarks>The default value is <see cref="TransceiverDirection.SendRecv"/></remarks>
        /// <param name="type"></param>
        /// <returns>The current transceiver direction.</returns>
        /// <since_tizen> 9 </since_tizen>
        public TransceiverDirection GetTransceiverDirection(MediaType type)
        {
            if (!SourceId.HasValue)
            {
                throw new InvalidOperationException("MediaSource is not attached yet. Call SetSource() first.");
            }

            NativeWebRTC.GetTransceiverDirection(WebRtc.Handle, SourceId.Value, type, out TransceiverDirection mode).
                ThrowIfFailed("Failed to get transceiver direction.");

            return mode;
        }

        /// <summary>
        /// Sets the transceiver direction of current media source.
        /// </summary>
        /// <param name="type">The media type.</param>
        /// <param name="direction">The transceiver direction.</param>
        /// <since_tizen> 9 </since_tizen>
        public void SetTransceiverDirection(MediaType type, TransceiverDirection direction)
        {
            if (!SourceId.HasValue)
            {
                throw new InvalidOperationException("MediaSource is not attached yet. Call SetSource() first.");
            }

            NativeWebRTC.SetTransceiverDirection(WebRtc.Handle, SourceId.Value, type, direction).
                ThrowIfFailed("Failed to get transceiver direction.");
        }
    }
}