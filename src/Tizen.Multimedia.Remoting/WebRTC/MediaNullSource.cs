/*
 * Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.ObjectModel;
using System.Diagnostics;
using NativeWebRTC = Interop.NativeWebRTC;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Represents a media source that only receives media streams from peer.
    /// </summary>
    /// <remarks>
    /// If you add this source, WebRTC only receives media stream.<br/>
    /// <see cref="TransceiverDirection"/> is set <see cref="TransceiverDirection.RecvOnly"/> by default.
    /// </remarks>
    /// <seealso cref="WebRTC.AddSource"/>
    /// <since_tizen> 10 </since_tizen>
    public sealed class MediaNullSource : MediaSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaNullSource"/> class.
        /// </summary>
        /// <remarks>TransceiverCodec should be set to receive audio, video stream.</remarks>
        /// <seealso cref="SetTransceiverCodec"/>
        /// <since_tizen> 10 </since_tizen>
        public MediaNullSource() : base() {}

        /// <summary>
        /// Gets the transceiver codec for receiving media stream.
        /// </summary>
        /// <param name="type">The media type.</param>
        /// <returns>The transceiver codec.</returns>
        /// <exception cref="InvalidOperationException">MediaSource is not attached yet.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="SetTransceiverCodec"/>
        /// <since_tizen> 10 </since_tizen>
        public TransceiverCodec GetTransceiverCodec(MediaType type)
        {
            if (!SourceId.HasValue)
            {
                throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
            }

            NativeWebRTC.GetTransceiverCodec(WebRtc.Handle, SourceId.Value, type, out TransceiverCodec codec).
                ThrowIfFailed("Failed to get transceiver codec");

            return codec;
        }

        /// <summary>
        /// Sets the transceiver codec for receiving media stream.
        /// </summary>
        /// <remarks>
        /// This method does not throw state exception anymore(Since API Level 12). It can be called in any state.<br/>
        /// </remarks>
        /// <param name="type">The media type.</param>
        /// <param name="codec">The transceiver codec.</param>
        /// <exception cref="InvalidOperationException">MediaSource is not attached yet.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="GetTransceiverCodec"/>
        /// <since_tizen> 10 </since_tizen>
        public void SetTransceiverCodec(MediaType type, TransceiverCodec codec)
        {
            if (!SourceId.HasValue)
            {
                throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
            }

            NativeWebRTC.SetTransceiverCodec(WebRtc.Handle, SourceId.Value, type, codec).
                ThrowIfFailed("Failed to set transceiver codec");
        }

        /// <summary>
        /// Retrieves the supported transceiver codecs for receiving media stream.
        /// </summary>
        /// <param name="type">The media type.</param>
        /// <returns>The supported transceiver codecs.</returns>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 10 </since_tizen>
        public ReadOnlyCollection<TransceiverCodec> GetSupportedTransceiverCodecs(MediaType type)
        {
            return new ReadOnlyCollection<TransceiverCodec>(ForeachSupportedTransceiverCodecs(type));
        }

        internal override void OnAttached(WebRTC webRtc)
        {
            Debug.Assert(webRtc != null);

            if (WebRtc != null)
            {
                throw new InvalidOperationException("The source is has already been assigned to another WebRTC.");
            }

            NativeWebRTC.AddMediaSource(webRtc.Handle, MediaSourceType.Null, out uint sourceId).
                ThrowIfFailed("Failed to add MediaNullSource.");

            WebRtc = webRtc;
            SourceId = sourceId;
            TransceiverDirection = TransceiverDirection.RecvOnly;
        }

        internal override void OnDetached(WebRTC webRtc)
        {
            NativeWebRTC.RemoveMediaSource(webRtc.Handle, SourceId.Value).
                ThrowIfFailed("Failed to remove MediaNullSource.");

            WebRtc = null;
        }
    }
}
