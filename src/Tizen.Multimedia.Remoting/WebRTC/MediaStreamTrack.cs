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
    /// Provides the ability to control audio/video track.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public sealed class MediaStreamTrack : IDisplayable<WebRTCErrorCode>
    {
        private WebRTC _webRtc;
        private uint _trackId;
        private Display _display;

        internal MediaStreamTrack(WebRTC webRtc, MediaType type, uint trackId)
        {
            _webRtc = webRtc;
            _trackId = trackId;
            Type = type;
        }

        /// <summary>
        /// Gets the the of media stream track.
        /// </summary>
        /// <value><see cref="MediaType"/></value>
        /// <since_tizen> 9 </since_tizen>
        public MediaType Type { get; }

        private WebRTCErrorCode SetDisplay(Display display)
            => display.ApplyTo(this);

        private void ReplaceDisplay(Display newDisplay)
        {
            _display?.SetOwner(null);
            _display = newDisplay;
            _display?.SetOwner(this);
        }

        /// <summary>
        /// Gets or sets the display to show remote video.
        /// </summary>
        /// <value>A <see cref="Multimedia.Display"/> that specifies the display.</value>
        /// <remarks>
        /// If user set video source with <see cref="TransceiverDirection.SendRecv"/>, <see cref="Display"/> must set.<br/>
        /// If not, the received video will be covered with entire screen.<br/>
        /// If remote track, <see cref="Display"/> must be called in <see cref="WebRTC.TrackAdded"/> event.<br/>
        /// the display is created with <see cref="MediaView"/>.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed of.</exception>
        /// <exception cref="ArgumentException">The value has already been assigned to another WebRTC.</exception>
        /// <exception cref="InvalidOperationException">The WebRTC is not called in <see cref="WebRTC.TrackAdded"/> event.</exception>
        /// <since_tizen> 9 </since_tizen>
        public Display Display
        {
            get => _display;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Display cannot be null.");
                }

                if (value?.Owner != null)
                {
                    if (ReferenceEquals(this, value.Owner))
                    {
                        throw new ArgumentException("The display has already been assigned to another.");
                    }
                }
                else
                {
                    SetDisplay(value).ThrowIfFailed("Failed to configure display of the MediaStreamTrack");
                    ReplaceDisplay(value);
                }
            }
        }

        WebRTCErrorCode IDisplayable<WebRTCErrorCode>.ApplyEvasDisplay(DisplayType type, EvasObject evasObject)
        {
            Debug.Assert(Enum.IsDefined(typeof(DisplayType), type));
            Debug.Assert(type != DisplayType.None);

            return NativeWebRTC.SetDisplay(_webRtc.Handle, _trackId,
                type == DisplayType.Overlay ? WebRTCDisplayType.Overlay : WebRTCDisplayType.Evas, evasObject);
        }

        WebRTCErrorCode IDisplayable<WebRTCErrorCode>.ApplyEcoreWindow(IntPtr windowHandle)
        {
            return NativeWebRTC.SetEcoreDisplay(_webRtc.Handle, _trackId, windowHandle);
        }

        /// <summary>
        /// Applies the audio stream policy to remote track.
        /// </summary>
        /// <param name="policy">The <see cref="AudioStreamPolicy"/> to apply.</param>
        /// <remarks>
        /// This must be called in <see cref="WebRTC.TrackAdded"/> event.<br/>
        /// <br/>
        /// <see cref="WebRTC"/> does not support all <see cref="AudioStreamType"/>.<br/>
        /// Supported types are <see cref="AudioStreamType.Media"/>, <see cref="AudioStreamType.Voip"/>,
        /// <see cref="AudioStreamType.MediaExternalOnly"/>.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">
        ///     The WebRTC has already been disposed.<br/>
        ///     -or-<br/>
        ///     <paramref name="policy"/> has already been disposed.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="WebRTC.AudioFrameEncoded"/> was set <br/>.
        /// -or-<br/>
        /// This method was not called in <see cref="WebRTC.TrackAdded"/> event.
        /// </exception>
        /// <exception cref="ArgumentNullException"><paramref name="policy"/> is null.</exception>
        /// <exception cref="NotSupportedException">
        ///     <see cref="AudioStreamType"/> of <paramref name="policy"/> is not supported on the current platform.
        /// </exception>
        /// <seealso cref="AudioStreamPolicy"/>
        /// <seealso cref="WebRTC.TrackAdded"/>
        /// <since_tizen> 9 </since_tizen>
        public void ApplyAudioStreamPolicy(AudioStreamPolicy policy)
        {
            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }

            if (Type != MediaType.Audio)
            {
                throw new InvalidOperationException("Should be applied in Audio");
            }

            var ret = NativeWebRTC.SetAudioStreamPolicy(_webRtc.Handle, _trackId, policy.Handle);

            if (ret == WebRTCErrorCode.InvalidArgument)
            {
                throw new NotSupportedException("The specified policy is not supported on the current system.");
            }

            ret.ThrowIfFailed("Failed to set the audio stream policy to the WebRTC");
        }
    }
}
