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

using ElmSharp;
using System;
using System.Diagnostics;
using static Interop;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// MediaSource is a base class for <see cref="WebRTC"/> sources.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public abstract class MediaSource : IDisplayable<uint>
    {
        internal WebRTC WebRtc { get; set; }
        internal uint? SourceId { get; set; }
        private Display _display;

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
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
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
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
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
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public bool Mute
        {
            get
            {
                NativeWebRTC.GetMute(WebRtc.Handle, SourceId.Value, MediaType, out bool isMuted).
                    ThrowIfFailed("Failed to get mute");

                return isMuted;
            }
            set
            {
                NativeWebRTC.SetMute(WebRtc.Handle, SourceId.Value, MediaType, value).
                    ThrowIfFailed("Failed to set mute");
            }
        }

        /// <summary>
        /// Gets or sets the video resolution of the current media source.
        /// </summary>
        /// <value>A value that specifies the mute status.</value>
        /// <exception cref="ArgumentException">This source is not video source.</exception>
        /// <exception cref="InvalidOperationException">MediaSource is not attached yet.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
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

        /// <summary>
        /// Enables the audio loopback. The local audio will be played with <paramref name="policy"/>.
        /// </summary>
        /// <param name="policy">The <see cref="AudioStreamPolicy"/> to apply.</param>
        /// <remarks>
        /// <see cref="MediaSource"/> does not support all <see cref="AudioStreamType"/>.<br/>
        /// Supported types are <see cref="AudioStreamType.Media"/>, <see cref="AudioStreamType.Voip"/>,
        /// <see cref="AudioStreamType.MediaExternalOnly"/>.<br/>
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="policy"/> is null.</exception>
        /// <exception cref="InvalidOperationException">This MediaSource is not Audio</exception>
        /// <exception cref="NotSupportedException">
        ///     <see cref="AudioStreamType"/> of <paramref name="policy"/> is not supported on the current platform.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     <paramref name="policy"/> or WebRTC has already been disposed.
        /// </exception>
        /// <returns><see cref="MediaStreamTrack"/></returns>
        public MediaStreamTrack EnableAudioLoopback(AudioStreamPolicy policy)
        {
            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }

            if (MediaType != MediaType.Audio)
            {
                throw new InvalidOperationException("AudioLoopback is only for Audio MediaSource");
            }

            var ret = NativeWebRTC.SetAudioLoopback(WebRtc.Handle, SourceId.Value, policy.Handle, out uint trackId);

            if (ret == WebRTCErrorCode.InvalidArgument)
            {
                throw new NotSupportedException("The specified policy is not supported on the current system.");
            }

            ret.ThrowIfFailed("Failed to set the audio stream policy to the WebRTC");

            return new MediaStreamTrack(WebRtc, MediaType, trackId);
        }

        private uint SetDisplay(Display display)
            => display.ApplyTo(this);

        internal void ReplaceDisplay(Display newDisplay)
        {
            _display?.SetOwner(null);
            _display = newDisplay;
            _display?.SetOwner(this);
        }

        /// <summary>
        /// Enables the video loopback. The local video will be diaplayed in <paramref name="display"/>.
        /// </summary>
        /// <param name="display">The <see cref="Display"/> to apply.</param>
        /// <exception cref="ArgumentException">The display has already been assigned to another.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="display"/> is null.</exception>
        /// <exception cref="InvalidOperationException">This MediaSource is not Video</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <returns><see cref="MediaStreamTrack"/></returns>
        public MediaStreamTrack EnableVideoLoopback(Display display)
        {
            uint trackId = 0;

            if (display == null)
            {
                throw new ArgumentNullException(nameof(display), "Display cannot be null.");
            }

            if (MediaType != MediaType.Video)
            {
                throw new InvalidOperationException("VideoLoopback is only for Video MediaSource");
            }

            if (display?.Owner != null)
            {
                if (ReferenceEquals(this, display.Owner))
                {
                    throw new ArgumentException("The display has already been assigned to another.");
                }
            }
            else
            {
                trackId = SetDisplay(display);
                ReplaceDisplay(display);
            }

            return new MediaStreamTrack(WebRtc, MediaType, trackId);
        }

        uint IDisplayable<uint>.ApplyEvasDisplay(DisplayType type, EvasObject evasObject)
        {
            Debug.Assert(Enum.IsDefined(typeof(DisplayType), type));
            Debug.Assert(type != DisplayType.None);

            NativeWebRTC.SetVideoLoopback(WebRtc.Handle, SourceId.Value,
                type == DisplayType.Overlay ? WebRTCDisplayType.Overlay : WebRTCDisplayType.Evas, evasObject,
                out uint trackId).ThrowIfFailed("Failed to set video loopback");

            return trackId;
        }

        uint IDisplayable<uint>.ApplyEcoreWindow(IntPtr windowHandle)
        {
            NativeWebRTC.SetEcoreVideoLoopback(WebRtc.Handle, SourceId.Value, windowHandle, out uint trackId).
                ThrowIfFailed("Failed to set ecore video loopback");

            return trackId;
        }
    }
}