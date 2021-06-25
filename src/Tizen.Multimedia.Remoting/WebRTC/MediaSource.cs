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

        /// <summary>
        /// Gets the type of MediaSource.
        /// </summary>
        /// <value><see cref="MediaType"/></value>
        /// <since_tizen> 9 </since_tizen>
        protected MediaType MediaType { get; }

        private bool IsDetached {get; set;} = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaSource"/> class.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        protected MediaSource(MediaType mediaType)
        {
            MediaType = mediaType;
        }

        internal void AttachTo(WebRTC webRtc)
        {
            if (IsDetached)
            {
                throw new InvalidOperationException("MediaSource was already detached.");
            }

            OnAttached(webRtc);
        }

        internal void DetachFrom(WebRTC webRtc)
        {
            OnDetached(webRtc);
            IsDetached = true;
        }

        internal abstract void OnAttached(WebRTC webRtc);

        internal abstract void OnDetached(WebRTC webRtc);

        /// <summary>
        /// Gets or sets the transceiver direction of current media source.
        /// </summary>
        /// <value>A <see cref="TransceiverDirection"/> that specifies the transceiver direction.</value>
        /// <exception cref="InvalidOperationException">MediaSource is not attached yet.</exception>
        /// <since_tizen> 9 </since_tizen>
        public TransceiverDirection TransceiverDirection
        {
            get
            {
                if (!SourceId.HasValue)
                {
                    throw new InvalidOperationException("MediaSource is not attached yet. Call SetSource() first.");
                }

                NativeWebRTC.GetTransceiverDirection(WebRtc.Handle, SourceId.Value, MediaType, out TransceiverDirection mode).
                    ThrowIfFailed("Failed to get transceiver direction.");

                return mode;
            }
            set
            {
                if (!SourceId.HasValue)
                {
                    throw new InvalidOperationException("MediaSource is not attached yet. Call SetSource() first.");
                }

                NativeWebRTC.SetTransceiverDirection(WebRtc.Handle, SourceId.Value, MediaType, value).
                    ThrowIfFailed("Failed to get transceiver direction.");
            }
        }

        /// <summary>
        /// Gets or sets the pause status of current media source.
        /// </summary>
        /// <value>A value that specifies the pause status.</value>
        /// <exception cref="InvalidOperationException">MediaSource is not attached yet.</exception>
        /// <since_tizen> 9 </since_tizen>
        public bool Pause
        {
            get
            {
                NativeWebRTC.GetPause(WebRtc.Handle, SourceId.Value, MediaType, out bool isPaused).
                    ThrowIfFailed("Failed to get pause");

                return isPaused;
            }
            set
            {
                NativeWebRTC.SetPause(WebRtc.Handle, SourceId.Value, MediaType, value).
                    ThrowIfFailed("Failed to set pause");
            }
        }

        /// <summary>
        /// Gets or sets the mute status of the current media source.
        /// </summary>
        /// <value>A value that specifies the mute status.</value>
        /// <exception cref="InvalidOperationException">MediaSource is not attached yet.</exception>
        /// <since_tizen> 9 </since_tizen>
        public bool Mute
        {
            get
            {
                NativeWebRTC.GetMute(WebRtc.Handle, SourceId.Value, MediaType, out bool isMuted).
                    ThrowIfFailed("Failed to get pause");

                return isMuted;
            }
            set
            {
                NativeWebRTC.SetMute(WebRtc.Handle, SourceId.Value, MediaType, value).
                    ThrowIfFailed("Failed to set pause");
            }
        }

        /// <summary>
        /// Gets or sets the video resolution of the current media source.
        /// </summary>
        /// <value>A value that specifies the mute status.</value>
        /// <exception cref="ArgumentException">This source is not video source.</exception>
        /// <exception cref="InvalidOperationException">MediaSource is not attached yet.</exception>
        /// <since_tizen> 9 </since_tizen>
        public Size VideoResolution
        {
            get
            {
                if (MediaType != MediaType.Video)
                {
                    throw new ArgumentException("This property is only for video.");
                }

                NativeWebRTC.GetVideoResolution(WebRtc.Handle, SourceId.Value, out int width, out int height).
                    ThrowIfFailed("Failed to get video resolution");

                return new Size(width, height);
            }
            set
            {
                if (MediaType != MediaType.Video)
                {
                    throw new ArgumentException("This property is only for video.");
                }

                NativeWebRTC.SetVideoResolution(WebRtc.Handle, SourceId.Value, value.Width, value.Height).
                    ThrowIfFailed("Failed to set video resolution");
            }
        }
    }
}