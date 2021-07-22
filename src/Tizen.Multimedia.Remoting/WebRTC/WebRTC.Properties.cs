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
using NativeWebRTC = Interop.NativeWebRTC;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides the ability to control WebRTC.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public partial class WebRTC
    {
        internal IntPtr Handle
        {
            get
            {
                ValidateNotDisposed();
                return _handle.DangerousGetHandle();
            }
        }

        /// <summary>
        /// Gets the state of the WebRTC.
        /// </summary>
        /// <value>The current state of the WebRTC.</value>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public WebRTCState State
        {
            get
            {
                ValidateNotDisposed();

                NativeWebRTC.GetState(Handle, out WebRTCState state).
                    ThrowIfFailed("Failed to retrieve the state of the WebRTC");

                Debug.Assert(Enum.IsDefined(typeof(WebRTCState), state));

                return state;
            }
        }

        /// <summary>
        /// Gets the Ice gathering state of the WebRTC.
        /// </summary>
        /// <value>The current Ice gathering state of the WebRTC.</value>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public WebRTCIceGatheringState IceGatheringState
        {
            get
            {
                ValidateNotDisposed();

                NativeWebRTC.GetIceGatheringState(Handle, out WebRTCIceGatheringState state).
                    ThrowIfFailed("Failed to retrieve the state of the WebRTC");

                Debug.Assert(Enum.IsDefined(typeof(WebRTCIceGatheringState), state));

                return state;
            }
        }

        /// <summary>
        /// Gets the signaling state of the WebRTC.
        /// </summary>
        /// <value>The current signaling state of the WebRTC.</value>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public WebRTCSignalingState SignalingState
        {
            get
            {
                ValidateNotDisposed();

                NativeWebRTC.GetSignalingState(Handle, out WebRTCSignalingState state).
                    ThrowIfFailed("Failed to retrieve the state of the WebRTC");

                Debug.Assert(Enum.IsDefined(typeof(WebRTCSignalingState), state));

                return state;
            }
        }

        /// <summary>
        /// Gets the peer connection state of the WebRTC.
        /// </summary>
        /// <value>The current peer connection state of the WebRTC.</value>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public WebRTCPeerConnectionState PeerConnectionState
        {
            get
            {
                ValidateNotDisposed();

                NativeWebRTC.GetPeerConnectionState(Handle, out WebRTCPeerConnectionState state).
                    ThrowIfFailed("Failed to retrieve the state of the WebRTC");

                Debug.Assert(Enum.IsDefined(typeof(WebRTCPeerConnectionState), state));

                return state;
            }
        }

        /// <summary>
        /// Gets the ICE connection state of the WebRTC.
        /// </summary>
        /// <value>The current ICE connection state of the WebRTC.</value>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public WebRTCIceConnectionState IceConnectionState
        {
            get
            {
                ValidateNotDisposed();

                NativeWebRTC.GetIceConnectionState(Handle, out WebRTCIceConnectionState state).
                    ThrowIfFailed("Failed to retrieve the state of the WebRTC");

                Debug.Assert(Enum.IsDefined(typeof(WebRTCIceConnectionState), state));

                return state;
            }
        }

        /// <summary>
        /// Gets or sets the STUN server url.
        /// </summary>
        /// <value>The STUN server url</value>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public string StunServer
        {
            get
            {
                ValidateNotDisposed();

                NativeWebRTC.GetStunServer(Handle, out string server).
                    ThrowIfFailed("Failed to get stun server name");

                return server;
            }
            set
            {
                ValidateNotDisposed();

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Stun server name is null.");
                }

                NativeWebRTC.SetStunServer(Handle, value).
                    ThrowIfFailed("Failed to set stun server name");
            }
        }

        /// <summary>
        /// Gets the display settings.
        /// </summary>
        /// <value>A <see cref="WebRTCDisplaySettings"/> that specifies the display settings.</value>
        /// <since_tizen> 9 </since_tizen>
        public WebRTCDisplaySettings DisplaySettings { get; }

        private WebRTCErrorCode SetDisplay(Display display)
            => display.ApplyTo(this);

        private void ReplaceDisplay(Display newDisplay)
        {
            _display?.SetOwner(null);
            _display = newDisplay;
            _display?.SetOwner(this);
        }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        /// <value>A <see cref="Multimedia.Display"/> that specifies the display.</value>
        /// <remarks>
        /// If user set video source with <see cref="TransceiverDirection.SendRecv"/>, <see cref="Display"/> must set.<br/>
        /// If not, the received video will be covered with entire screen.<br/>
        /// <see cref="Display"/> must be called in <see cref="TrackAdded"/> event.<br/>
        /// the display is created with <see cref="MediaView"/>.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed of.</exception>
        /// <exception cref="ArgumentException">The value has already been assigned to another WebRTC.</exception>
        /// <exception cref="InvalidOperationException">The WebRTC is not called in <see cref="TrackAdded"/> event.</exception>
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
                    SetDisplay(value).ThrowIfFailed("Failed to configure display of the WebRTC");
                    ReplaceDisplay(value);
                }
            }
        }

        WebRTCErrorCode IDisplayable<WebRTCErrorCode>.ApplyEvasDisplay(DisplayType type, EvasObject evasObject)
        {
            Debug.Assert(!IsDisposed);

            Debug.Assert(Enum.IsDefined(typeof(DisplayType), type));
            Debug.Assert(type != DisplayType.None);

            if (!_trackId.HasValue)
                throw new InvalidOperationException("Track is not added yet.");

            return NativeWebRTC.SetDisplay(Handle, _trackId.Value,
                type == DisplayType.Overlay ? WebRTCDisplayType.Overlay : WebRTCDisplayType.Evas, evasObject);
        }

        WebRTCErrorCode IDisplayable<WebRTCErrorCode>.ApplyEcoreWindow(IntPtr windowHandle)
        {
            Debug.Assert(!IsDisposed);

            if (!_trackId.HasValue)
                throw new InvalidOperationException("Track is not added yet.");

            return NativeWebRTC.SetEcoreDisplay(Handle, _trackId.Value, windowHandle);
        }
    }
}

