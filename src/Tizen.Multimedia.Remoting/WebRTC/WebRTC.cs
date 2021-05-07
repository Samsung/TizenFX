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
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Tizen.Applications;
using static Interop;

namespace Tizen.Multimedia.Remoting
{
    internal static class WebRTCLog
    {
        internal const string Tag = "Tizen.Multimedia.WebRTC";
    }

    /// <summary>
    /// Provides the ability to control WebRTC.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public partial class WebRTC : IDisposable, IDisplayable<WebRTCErrorCode>
    {
        private readonly WebRTCHandle _handle;
        private List<MediaSource> _source;

        private Display _display;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebRTC"/> class.
        /// </summary>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 9 </since_tizen>
        public WebRTC()
        {
            if (!Features.IsSupported(WebRTCFeatures.Wifi) &&
                !Features.IsSupported(WebRTCFeatures.Telephony) &&
                !Features.IsSupported(WebRTCFeatures.Ethernet))
            {
                throw new NotSupportedException("Network features are not supported.");
            }

            NativeWebRTC.Create(out _handle).ThrowIfFailed("Failed to create webrtc");

            Debug.Assert(_handle != null);

            RegisterEvents();

            DisplaySettings = new WebRTCDisplaySettings(this);

            _source = new List<MediaSource>();
        }

        internal void ValidateWebRTCState(params WebRTCState[] desiredStates)
        {
            Debug.Assert(desiredStates.Length > 0);

            ValidateNotDisposed();

            WebRTCState curState = State;
            if (!curState.IsAnyOf(desiredStates))
            {
                throw new InvalidOperationException("The WebRTC is not in a valid state. " +
                    $"Current State : { curState }, Valid State : { string.Join(", ", desiredStates) }.");
            }
        }

        #region Dispose support
        private bool _disposed;

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="WebRTC"/>.
        /// </summary>
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources;
        /// false to release only unmanaged resources.
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed || !disposing)
                return;

            ReplaceDisplay(null);

            if (_source != null && _source.Count > 0)
            {
                try
                {
                    foreach (var source in _source)
                    {
                        source.DetachFrom(this);
                    }
                    _source = null;
                }
                catch (Exception ex)
                {
                    Log.Error(WebRTCLog.Tag, ex.ToString());
                }
            }
            if (_handle != null)
            {
                _handle.Dispose();
                _disposed = true;
            }
        }

        internal void ValidateNotDisposed()
        {
            if (_disposed)
            {
                Log.Warn(WebRTCLog.Tag, "WebRTC was disposed");
                throw new ObjectDisposedException(nameof(WebRTC));
            }
        }

        internal bool IsDisposed => _disposed;
        #endregion

        /// <summary>
        /// Starts the WebRTC.
        /// </summary>
        /// <remarks>
        /// The WebRTC must be in the <see cref="WebRTCState.Idle"/> state.<br/>
        /// The WebRTC state will be <see cref="WebRTCState.Negotiating"/> state.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void Start()
        {
            ValidateWebRTCState(WebRTCState.Idle);

            NativeWebRTC.Start(Handle).ThrowIfFailed("Failed to start the WebRTC");
        }

        /// <summary>
        /// Stops the WebRTC.
        /// </summary>
        /// <remarks>
        /// The WebRTC must be in the <see cref="WebRTCState.Negotiating"/> or <see cref="WebRTCState.Playing"/> state.<br/>
        /// The WebRTC state will be <see cref="WebRTCState.Idle"/> state.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void Stop()
        {
            ValidateWebRTCState(WebRTCState.Negotiating, WebRTCState.Playing);

            NativeWebRTC.Stop(Handle).ThrowIfFailed("Failed to stop the WebRTC");
        }

        /// <summary>
        /// Creates SDP offer to start a new WebRTC connection to a remote peer and set it to local.
        /// </summary>
        /// <remarks>
        /// This API is helper method to create offer, set local description in one shot.<br/>
        /// The WebRTC must be in the <see cref="WebRTCState.Negotiating"/>
        /// </remarks>
        /// <returns>The SDP offer.</returns>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="CreateOffer()"/>
        /// <seealso cref="CreateOffer(Bundle)"/>
        /// <seealso cref="SetLocalDescription"/>
        /// <since_tizen> 9 </since_tizen>
        public string CreateSetOffer() => CreateSetOffer(null);

        /// <summary>
        /// Creates SDP offer to start a new WebRTC connection to a remote peer and set it to local.
        /// </summary>
        /// <remarks>
        /// This API is helper method to create offer, set local description in one shot.<br/>
        /// The WebRTC must be in the <see cref="WebRTCState.Negotiating"/>
        /// </remarks>
        /// <param name="bundle">Configuration options for the offer.</param>
        /// <returns>The SDP offer.</returns>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="CreateOffer()"/>
        /// <seealso cref="CreateOffer(Bundle)"/>
        /// <seealso cref="SetLocalDescription"/>
        /// <since_tizen> 9 </since_tizen>
        public string CreateSetOffer(Bundle bundle)
        {
            ValidateWebRTCState(WebRTCState.Negotiating);

            var bundle_ = bundle?.SafeBundleHandle ?? new SafeBundleHandle();
            NativeWebRTC.CreateSDPOffer(Handle, bundle_, out string offer).ThrowIfFailed("Failed to create offer");

            NativeWebRTC.SetLocalDescription(Handle, offer).ThrowIfFailed("Failed to set description.");

            return offer;
        }

        /// <summary>
        /// Creates SDP answer with option to an offer received from a remote peer and set it to local.
        /// </summary>
        /// <remarks>
        /// This API is helper method to set remote description, create answer, set local description in one shot.<br/>
        /// The WebRTC must be in the <see cref="WebRTCState.Negotiating"/>.
        /// </remarks>
        /// <param name="offer">The remote session description.</param>
        /// <returns>The SDP answer.</returns>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="SetRemoteDescription(string)"/>
        /// <seealso cref="CreateAnswer()"/>
        /// <seealso cref="CreateAnswer(Bundle)"/>
        /// <seealso cref="SetLocalDescription"/>
        /// <since_tizen> 9 </since_tizen>
        public string CreateSetAnswer(string offer) => CreateSetAnswer(offer, null);

        /// <summary>
        /// Creates SDP answer with option to an offer received from a remote peer and set it to local.
        /// </summary>
        /// <remarks>
        /// This API is helper method to set remote description, create answer, set local description in one shot.<br/>
        /// The WebRTC must be in the <see cref="WebRTCState.Negotiating"/>.
        /// </remarks>
        /// <param name="offer">The remote session description.</param>
        /// <param name="bundle">Configuration options for the answer.</param>
        /// <returns>The SDP answer.</returns>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="SetRemoteDescription(string)"/>
        /// <seealso cref="CreateAnswer()"/>
        /// <seealso cref="CreateAnswer(Bundle)"/>
        /// <seealso cref="SetLocalDescription"/>
        /// <since_tizen> 9 </since_tizen>
        public string CreateSetAnswer(string offer, Bundle bundle)
        {
            ValidateWebRTCState(WebRTCState.Negotiating);
            ValidationUtil.ValidateIsNullOrEmpty(offer, nameof(offer));

            NativeWebRTC.SetRemoteDescription(Handle, offer).ThrowIfFailed("Failed to set offer.");

            var bundle_ = bundle?.SafeBundleHandle ?? new SafeBundleHandle();
            NativeWebRTC.CreateSDPAnswer(Handle, bundle_, out string answer).ThrowIfFailed("Failed to create answer");

            NativeWebRTC.SetLocalDescription(Handle, answer).ThrowIfFailed("Failed to set description.");

            return answer;
        }

        /// <summary>
        /// Creates SDP offer to start a new WebRTC connection to a remote peer.
        /// </summary>
        /// <remarks>The WebRTC must be in the <see cref="WebRTCState.Negotiating"/></remarks>
        /// <returns>The SDP offer.</returns>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="CreateOffer(Bundle)"/>
        /// <since_tizen> 9 </since_tizen>
        public string CreateOffer() => CreateOffer(null);

        /// <summary>
        /// Creates SDP offer with option to start a new WebRTC connection to a remote peer.
        /// </summary>
        /// <remarks>The WebRTC must be in the <see cref="WebRTCState.Negotiating"/></remarks>
        /// <param name="bundle">Configuration options for the offer.</param>
        /// <returns>The SDP offer.</returns>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="CreateOffer()"/>
        /// <since_tizen> 9 </since_tizen>
        public string CreateOffer(Bundle bundle)
        {
            ValidateWebRTCState(WebRTCState.Negotiating);

            var bundle_ = bundle?.SafeBundleHandle ?? new SafeBundleHandle();
            NativeWebRTC.CreateSDPOffer(Handle, bundle_, out string offer).ThrowIfFailed("Failed to create offer");

            return offer;
        }

        /// <summary>
        /// Creates SDP answer to an offer received from a remote peer.
        /// </summary>
        /// <remarks>
        /// The WebRTC must be in the <see cref="WebRTCState.Negotiating"/>.<br/>
        /// The SDP offer must be set by <see cref="SetRemoteDescription"/> before creating answer.
        /// </remarks>
        /// <returns>The SDP answer.</returns>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="CreateAnswer(Bundle)"/>
        /// <seealso cref="SetRemoteDescription(string)"/>
        /// <since_tizen> 9 </since_tizen>
        public string CreateAnswer() => CreateAnswer(null);

        /// <summary>
        /// Creates SDP answer with option to an offer received from a remote peer.
        /// </summary>
        /// <remarks>
        /// The WebRTC must be in the <see cref="WebRTCState.Negotiating"/>.<br/>
        /// The SDP offer must be set by <see cref="SetRemoteDescription"/> before creating answer.
        /// </remarks>
        /// <param name="bundle">Configuration options for the answer.</param>
        /// <returns>The SDP answer.</returns>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="CreateAnswer()"/>
        /// <seealso cref="SetRemoteDescription(string)"/>
        /// <since_tizen> 9 </since_tizen>
        public string CreateAnswer(Bundle bundle)
        {
            ValidateWebRTCState(WebRTCState.Negotiating);

            var bundle_ = bundle?.SafeBundleHandle ?? new SafeBundleHandle();

            NativeWebRTC.CreateSDPAnswer(Handle, bundle_, out string answer).ThrowIfFailed("Failed to create answer");

            return answer;
        }

        /// <summary>
        /// Sets the session description for a local peer.
        /// </summary>
        /// <remarks>The WebRTC must be in the <see cref="WebRTCState.Negotiating"/>.</remarks>
        /// <param name="description">The local session description.</param>
        /// <exception cref="ArgumentException">The description is empty string.</exception>
        /// <exception cref="ArgumentNullException">The description is null.</exception>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="CreateOffer()"/>
        /// <seealso cref="CreateAnswer()"/>
        /// <since_tizen> 9 </since_tizen>
        public void SetLocalDescription(string description)
        {
            ValidateWebRTCState(WebRTCState.Negotiating);

            ValidationUtil.ValidateIsNullOrEmpty(description, nameof(description));

            NativeWebRTC.SetLocalDescription(Handle, description).ThrowIfFailed("Failed to set description.");
        }

        /// <summary>
        /// Sets the session description of the remote peer's current offer or answer.
        /// </summary>
        /// <remarks>The WebRTC must be in the <see cref="WebRTCState.Negotiating"/>.</remarks>
        /// <param name="description">The remote session description.</param>
        /// <exception cref="ArgumentException">The description is empty string.</exception>
        /// <exception cref="ArgumentNullException">The description is null.</exception>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="CreateOffer()"/>
        /// <seealso cref="CreateAnswer()"/>
        /// <since_tizen> 9 </since_tizen>
        public void SetRemoteDescription(string description)
        {
            ValidateWebRTCState(WebRTCState.Negotiating);

            ValidationUtil.ValidateIsNullOrEmpty(description, nameof(description));

            NativeWebRTC.SetRemoteDescription(Handle, description).ThrowIfFailed("Failed to set description.");
        }

        /// <summary>
        /// Adds a new ICE candidate from the remote peer over its signaling channel.
        /// </summary>
        /// <remarks>The WebRTC must be in the <see cref="WebRTCState.Negotiating"/>.</remarks>
        /// <param name="iceCandidate">The ICE candidate.</param>
        /// <exception cref="ArgumentException">The ICE candidate is empty string.</exception>
        /// <exception cref="ArgumentNullException">The ICE candidate is null.</exception>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void AddIceCandidate(string iceCandidate)
        {
            ValidateWebRTCState(WebRTCState.Negotiating);

            ValidationUtil.ValidateIsNullOrEmpty(iceCandidate, nameof(iceCandidate));

            NativeWebRTC.AddIceCandidate(Handle, iceCandidate).ThrowIfFailed("Failed to set ICE candidate.");
        }

        /// <summary>
        /// Adds new ICE candidates from the remote peer over its signaling channel.
        /// </summary>
        /// <remarks>The WebRTC must be in the <see cref="WebRTCState.Negotiating"/>.</remarks>
        /// <param name="iceCandidates">The ICE candidates.</param>
        /// <exception cref="ArgumentException">The ICE candidate is empty string.</exception>
        /// <exception cref="ArgumentNullException">The ICE candidate is null.</exception>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void AddIceCandidates(IEnumerable<string> iceCandidates)
        {
            ValidateWebRTCState(WebRTCState.Negotiating);

            ValidationUtil.ValidateIsAny(iceCandidates);

            #pragma warning disable CA1062
            foreach (string iceCandidate in iceCandidates)
            {
                AddIceCandidate(iceCandidate);
            }
            #pragma warning restore CA1062
        }

        /// <summary>
        /// Sets media source.
        /// </summary>
        /// <remarks>The WebRTC must be in the <see cref="WebRTCState.Idle"/>.<br/>
        /// <see cref="SetSource"/> should be set before <see cref="Start"/>.
        /// </remarks>
        /// <param name="source">The media source to set.</param>
        /// <exception cref="ArgumentNullException">The media source is null.</exception>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="MediaCameraSource"/>
        /// <seealso cref="MediaMicSource"/>
        /// <seealso cref="MediaAudioTestSource"/>
        /// <seealso cref="MediaVideoTestSource"/>
        /// <seealso cref="MediaPacketSource"/>
        /// <since_tizen> 9 </since_tizen>
        public void SetSource(MediaSource source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "source is null");
            }

            ValidateWebRTCState(WebRTCState.Idle);

            source?.AttachTo(this);

            _source.Add(source);
        }
    }
}