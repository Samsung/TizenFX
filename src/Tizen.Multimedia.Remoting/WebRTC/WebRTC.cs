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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
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
    public partial class WebRTC : IDisposable
    {
        private readonly WebRTCHandle _handle;
        private List<MediaSource> _source;

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

            if (_source != null && _source.Count > 0)
            {
                try
                {
                    Log.Info(WebRTCLog.Tag, "Detach sources");
                    foreach (var source in _source)
                    {
                        source.ReplaceDisplay(null);
                        source.DetachFrom(this);
                    }
                    _source.Clear();
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
        /// The WebRTC state will be <see cref="WebRTCState.Negotiating"/> state.<br/>
        /// The user should check whether <see cref="State" /> is changed to <see cref="WebRTCState.Negotiating"/> state or not.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <see also="WebRTCState"/>
        /// <see also="StateChanged"/>
        /// <see also="CreateOffer"/>
        /// <see also="CreateSetOffer"/>
        /// <since_tizen> 9 </since_tizen>
        public void Start()
        {
            ValidateWebRTCState(WebRTCState.Idle);

            NativeWebRTC.Start(Handle).ThrowIfFailed("Failed to start the WebRTC");
        }

        /// <summary>
        /// Starts the WebRTC asynchronously.
        /// </summary>
        /// <remarks>
        /// The WebRTC must be in the <see cref="WebRTCState.Idle"/> state.<br/>
        /// The WebRTC state will be <see cref="WebRTCState.Negotiating"/> state.<br/>
        /// This ensures that <see cref="State" /> is changed to <see cref="WebRTCState.Negotiating"/> state.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <see also="WebRTCState"/>
        /// <see also="CreateOffer"/>
        /// <see also="CreateSetOffer"/>
        /// <since_tizen> 9 </since_tizen>
        public async Task StartAsync()
        {
            ValidateWebRTCState(WebRTCState.Idle);

            var tcs = new TaskCompletionSource<bool>();
            EventHandler<WebRTCStateChangedEventArgs> stateChangedEventHandler = (s, e) =>
            {
                if (e.Current == WebRTCState.Negotiating)
                {
                    tcs.TrySetResult(true);
                }
            };

            try
            {
                StateChanged += stateChangedEventHandler;

                NativeWebRTC.Start(Handle).ThrowIfFailed("Failed to start the WebRTC");

                await tcs.Task.ConfigureAwait(false);
                await Task.Yield();
            }
            finally
            {
                StateChanged -= stateChangedEventHandler;
            }
        }

        /// <summary>
        /// Stops the WebRTC.
        /// </summary>
        /// <remarks>
        /// The WebRTC must be in the <see cref="WebRTCState.Negotiating"/> or <see cref="WebRTCState.Playing"/> state.<br/>
        /// The WebRTC state will be <see cref="WebRTCState.Idle"/> state.<br/>
        /// The user should check whether <see cref="State" /> is changed to <see cref="WebRTCState.Idle"/> state or not.
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
        /// Creates SDP offer asynchronously to start a new WebRTC connection to a remote peer.
        /// </summary>
        /// <remarks>The WebRTC must be in the <see cref="WebRTCState.Negotiating"/></remarks>
        /// <returns>The SDP offer.</returns>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="CreateAnswerAsync()"/>
        /// <since_tizen> 9 </since_tizen>
        public async Task<string> CreateOfferAsync()
        {
            ValidateWebRTCState(WebRTCState.Negotiating);

            var tcsSdpCreated = new TaskCompletionSource<string>();

            NativeWebRTC.SdpCreatedCallback cb = (handle, sdp, _) =>
            {
                tcsSdpCreated.TrySetResult(sdp);
            };

            NativeWebRTC.CreateSDPOfferAsync(Handle, new SafeBundleHandle(), cb, IntPtr.Zero).
                    ThrowIfFailed("Failed to create offer asynchronously");

            var offer = await tcsSdpCreated.Task.ConfigureAwait(false);
            await Task.Yield();

            return offer;
        }

        /// <summary>
        /// Creates SDP answer asynchronously with option to an offer received from a remote peer.
        /// </summary>
        /// <remarks>The WebRTC must be in the <see cref="WebRTCState.Negotiating"/></remarks>
        /// <returns>The SDP answer.</returns>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="CreateOfferAsync()"/>
        /// <since_tizen> 9 </since_tizen>
        public async Task<string> CreateAnswerAsync()
        {
            ValidateWebRTCState(WebRTCState.Negotiating);

            var tcsSdpCreated = new TaskCompletionSource<string>();

            NativeWebRTC.SdpCreatedCallback cb = (handle, sdp, _) =>
            {
                tcsSdpCreated.TrySetResult(sdp);
            };

            NativeWebRTC.CreateSDPAnswerAsync(Handle, new SafeBundleHandle(), cb, IntPtr.Zero).
                    ThrowIfFailed("Failed to create answer asynchronously");

            var answer = await tcsSdpCreated.Task.ConfigureAwait(false);
            await Task.Yield();

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
        /// Adds media source.
        /// </summary>
        /// <remarks>
        /// The WebRTC must be in the <see cref="WebRTCState.Idle"/>.<br/>
        /// Each MediaSource requires different feature or privilege.<br/>
        /// <see cref="MediaCameraSource"/> needs camera feature and privilege.<br/>
        /// <see cref="MediaFileSource"/> needs mediastorage or externalstorage privilege.<br/>
        /// <see cref="MediaMicrophoneSource"/> needs microphone feature and recorder privilege.<br/>
        /// </remarks>
        /// <param name="source">The media sources to add.</param>
        /// <feature>http://tizen.org/feature/camera</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <privilege>http://tizen.org/privilege/camera</privilege>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <exception cref="ArgumentNullException">The media source is null.</exception>
        /// <exception cref="InvalidOperationException">
        /// The WebRTC is not in the valid state.<br/>
        /// - or -<br/>
        /// All or one of <paramref name="source"/> was already detached.
        /// </exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        /// <seealso cref="MediaCameraSource"/>
        /// <seealso cref="MediaMicrophoneSource"/>
        /// <seealso cref="MediaTestSource"/>
        /// <seealso cref="MediaPacketSource"/>
        /// <seealso cref="AddSources"/>
        /// <seealso cref="RemoveSource"/>
        /// <seealso cref="RemoveSources"/>
        /// <since_tizen> 9 </since_tizen>
        public void AddSource(MediaSource source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "source is null");
            }

            ValidateWebRTCState(WebRTCState.Idle);

            source?.AttachTo(this);

            _source.Add(source);
        }

        /// <summary>
        /// Adds media sources.
        /// </summary>
        /// <remarks>
        /// The WebRTC must be in the <see cref="WebRTCState.Idle"/>.<br/>
        /// Each MediaSource requires different feature or privilege.<br/>
        /// <see cref="MediaCameraSource"/> needs camera feature and privilege.<br/>
        /// <see cref="MediaFileSource"/> needs mediastorage or externalstorage privilege.<br/>
        /// <see cref="MediaMicrophoneSource"/> needs microphone feature and recorder privilege.<br/>
        /// </remarks>
        /// <param name="sources">The media sources to add.</param>
        /// <feature>http://tizen.org/feature/camera</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <privilege>http://tizen.org/privilege/camera</privilege>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <exception cref="ArgumentNullException">The media source is null.</exception>
        /// <exception cref="InvalidOperationException">
        /// The WebRTC is not in the valid state.<br/>
        /// - or -<br/>
        /// All or one of <paramref name="sources"/> was already detached.
        /// </exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        /// <seealso cref="MediaCameraSource"/>
        /// <seealso cref="MediaMicrophoneSource"/>
        /// <seealso cref="MediaTestSource"/>
        /// <seealso cref="MediaPacketSource"/>
        /// <seealso cref="AddSource"/>
        /// <seealso cref="RemoveSource"/>
        /// <seealso cref="RemoveSources"/>
        /// <since_tizen> 9 </since_tizen>
        public void AddSources(params MediaSource[] sources)
        {
            foreach (var source in sources)
            {
                AddSource(source);
            }
        }

        /// <summary>
        /// Removes media source.
        /// </summary>
        /// <remarks>
        /// The WebRTC must be in the <see cref="WebRTCState.Idle"/>.<br/>
        /// If user want to use removed MediaSource again, user should create new instance for it.
        /// </remarks>
        /// <param name="source">The media source to remove.</param>
        /// <exception cref="ArgumentNullException">The media source is null.</exception>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="MediaCameraSource"/>
        /// <seealso cref="MediaMicrophoneSource"/>
        /// <seealso cref="MediaTestSource"/>
        /// <seealso cref="MediaPacketSource"/>
        /// <seealso cref="AddSource"/>
        /// <seealso cref="AddSources"/>
        /// <seealso cref="RemoveSources"/>
        /// <since_tizen> 9 </since_tizen>
        public void RemoveSource(MediaSource source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "source is null");
            }

            ValidateWebRTCState(WebRTCState.Idle);

            source?.DetachFrom(this);

            _source.Remove(source);

            source = null;
        }

        /// <summary>
        /// Removes media sources.
        /// </summary>
        /// <remarks>
        /// The WebRTC must be in the <see cref="WebRTCState.Idle"/>.<br/>
        /// If user want to use removed MediaSource again, user should create new instance for it.
        /// </remarks>
        /// <param name="sources">The media source to remove.</param>
        /// <exception cref="ArgumentNullException">The media source is null.</exception>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="MediaCameraSource"/>
        /// <seealso cref="MediaMicrophoneSource"/>
        /// <seealso cref="MediaTestSource"/>
        /// <seealso cref="MediaPacketSource"/>
        /// <seealso cref="AddSource"/>
        /// <seealso cref="AddSources"/>
        /// <seealso cref="RemoveSource"/>
        /// <since_tizen> 9 </since_tizen>
        public void RemoveSources(params MediaSource[] sources)
        {
            foreach (var source in sources)
            {
                RemoveSource(source);
            }
        }

        /// <summary>
        /// Sets a turn server.
        /// </summary>
        /// <exception cref="ArgumentNullException">The <paramref name="turnServer"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void SetTurnServer(string turnServer)
        {
            ValidateNotDisposed();

            if (turnServer == null)
            {
                throw new ArgumentNullException(nameof(turnServer), "Turn server name is null.");
            }

            NativeWebRTC.AddTurnServer(Handle, turnServer).
                ThrowIfFailed("Failed to add turn server");
        }

        /// <summary>
        /// Sets turn servers.
        /// </summary>
        /// <exception cref="ArgumentNullException">The one of <paramref name="turnServers"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void SetTurnServers(params string[] turnServers)
        {
            ValidateNotDisposed();

            foreach (var turnServer in turnServers)
            {
                SetTurnServer(turnServer);
            }
        }

        /// <summary>
        /// Gets all turn servers.
        /// </summary>
        /// <returns>The turn server list.</returns>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public ReadOnlyCollection<string> GetTurnServer()
        {
            ValidateNotDisposed();

            var list = new List<string>();

            NativeWebRTC.RetrieveTurnServerCallback callback = (server, _) =>
            {
                if (!string.IsNullOrWhiteSpace(server))
                {
                    list.Add(server);
                }

                return true;
            };

            NativeWebRTC.ForeachTurnServer(Handle, callback).ThrowIfFailed("Failed to retrieve turn server");

            return list.AsReadOnly();
        }
    }
}