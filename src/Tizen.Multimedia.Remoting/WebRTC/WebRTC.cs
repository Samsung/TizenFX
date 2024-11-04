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
using System.Runtime.InteropServices;
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
        /// Starts the WebRTC with specific media source.
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
        /// <since_tizen> 9 </since_tizen>
        public void Start()
        {
            ValidateWebRTCState(WebRTCState.Idle);

            NativeWebRTC.Start(Handle).ThrowIfFailed("Failed to start the WebRTC");
        }

        /// <summary>
        /// Starts the WebRTC asynchronously with specific media source.
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
        /// <since_tizen> 9 </since_tizen>
        public async Task StartAsync()
        {
            Log.Info(WebRTCLog.Tag, "Enter");

            ValidateWebRTCState(WebRTCState.Idle);

            var tcs = new TaskCompletionSource<bool>();
            var error = WebRTCError.ConnectionFailed;

            EventHandler<WebRTCStateChangedEventArgs> stateChangedEventHandler = (s, e) =>
            {
                if (e.Current == WebRTCState.Negotiating)
                {
                    tcs.TrySetResult(true);
                }
            };
            EventHandler<WebRTCErrorOccurredEventArgs> errorEventHandler = (s, e) =>
            {
                Log.Info(WebRTCLog.Tag, e.ToString());
                error = e.Error;
                tcs.TrySetResult(false);
            };

            try
            {
                StateChanged += stateChangedEventHandler;
                ErrorOccurred += errorEventHandler;

                NativeWebRTC.Start(Handle).ThrowIfFailed("Failed to start the WebRTC");

                var result = await tcs.Task.ConfigureAwait(false);
                await Task.Yield();

                if (!result)
                {
                    throw new InvalidOperationException(error.ToString());
                }
            }
            finally
            {
                StateChanged -= stateChangedEventHandler;
                ErrorOccurred -= errorEventHandler;
            }

            Log.Info(WebRTCLog.Tag, "Leave");
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
        /// Creates SDP(Session Description Protocol) offer asynchronously to start a new WebRTC connection to a remote peer.
        /// </summary>
        /// <remarks>
        /// The WebRTC must be in the <see cref="WebRTCState.Negotiating"/> or <see cref="WebRTCState.Playing"/>(Since API Level 12)
        /// </remarks>
        /// <returns>The SDP offer.</returns>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="CreateAnswerAsync()"/>
        /// <since_tizen> 9 </since_tizen>
        public async Task<string> CreateOfferAsync()
        {
            Log.Info(WebRTCLog.Tag, "Enter");

            ValidateWebRTCState(WebRTCState.Negotiating, WebRTCState.Playing);

            var tcsSdpCreated = new TaskCompletionSource<string>();

            NativeWebRTC.SdpCreatedCallback cb = (handle, sdp, _) =>
            {
                tcsSdpCreated.TrySetResult(sdp);
            };

            string offer = null;
            using (var cbKeeper = ObjectKeeper.Get(cb))
            {
                NativeWebRTC.CreateSDPOfferAsync(Handle, new SafeBundleHandle(), cb, IntPtr.Zero).
                    ThrowIfFailed("Failed to create offer asynchronously");

                offer = await tcsSdpCreated.Task.ConfigureAwait(false);
                await Task.Yield();
            }

            Log.Info(WebRTCLog.Tag, "Leave");

            return offer;
        }

        /// <summary>
        /// Creates SDP(Session Description Protocol) answer asynchronously with option to an offer received from a remote peer.
        /// </summary>
        /// <remarks>
        /// The WebRTC must be in the <see cref="WebRTCState.Negotiating"/> or <see cref="WebRTCState.Playing"/>(Since API Level 12)
        /// </remarks>
        /// <returns>The SDP answer.</returns>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="CreateOfferAsync()"/>
        /// <since_tizen> 9 </since_tizen>
        public async Task<string> CreateAnswerAsync()
        {
            Log.Info(WebRTCLog.Tag, "Enter");

            ValidateWebRTCState(WebRTCState.Negotiating, WebRTCState.Playing);

            var tcsSdpCreated = new TaskCompletionSource<string>();

            NativeWebRTC.SdpCreatedCallback cb = (handle, sdp, _) =>
            {
                tcsSdpCreated.TrySetResult(sdp);
            };

            string answer = null;
            using (var cbKeeper = ObjectKeeper.Get(cb))
            {
                NativeWebRTC.CreateSDPAnswerAsync(Handle, new SafeBundleHandle(), cb, IntPtr.Zero).
                    ThrowIfFailed("Failed to create answer asynchronously");

                answer = await tcsSdpCreated.Task.ConfigureAwait(false);
                await Task.Yield();
            }

            Log.Info(WebRTCLog.Tag, "Leave");

            return answer;
        }

        /// <summary>
        /// Sets the session description for a local peer.
        /// </summary>
        /// <remarks>
        /// The WebRTC must be in the <see cref="WebRTCState.Negotiating"/> or <see cref="WebRTCState.Playing"/>(Since API Level 12)
        /// </remarks>
        /// <param name="description">The local session description.</param>
        /// <exception cref="ArgumentException">The description is empty string.</exception>
        /// <exception cref="ArgumentNullException">The description is null.</exception>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="CreateOfferAsync()"/>
        /// <seealso cref="CreateAnswerAsync()"/>
        /// <seealso cref="GetLocalDescription()"/>
        /// <since_tizen> 9 </since_tizen>
        public void SetLocalDescription(string description)
        {
            ValidateWebRTCState(WebRTCState.Negotiating, WebRTCState.Playing);

            ValidationUtil.ValidateIsNullOrEmpty(description, nameof(description));

            NativeWebRTC.SetLocalDescription(Handle, description).ThrowIfFailed("Failed to set local description.");
        }

        /// <summary>
        /// Gets the session description for a local peer.
        /// </summary>
        /// <returns>The local session description string</returns>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="SetLocalDescription()"/>
        /// <since_tizen> 12 </since_tizen>
        public string GetLocalDescription()
        {
            ValidateNotDisposed();

            IntPtr description = IntPtr.Zero;
            try
            {
                NativeWebRTC.GetLocalDescription(Handle, out description).ThrowIfFailed("Failed to get local description.");

                return Marshal.PtrToStringAnsi(description);
            }
            finally
            {
                Marshal.FreeHGlobal(description);
            }
        }

        /// <summary>
        /// Sets the offer or answer session description from the current remote peer.
        /// </summary>
        /// <remarks>
        /// The WebRTC must be in the <see cref="WebRTCState.Negotiating"/> or <see cref="WebRTCState.Playing"/>(Since API Level 12)
        /// </remarks>
        /// <param name="description">The remote session description.</param>
        /// <exception cref="ArgumentException">The description is empty string.</exception>
        /// <exception cref="ArgumentNullException">The description is null.</exception>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="CreateOfferAsync()"/>
        /// <seealso cref="CreateAnswerAsync()"/>
        /// <seealso cref="GetRemoteDescription()"/>
        /// <since_tizen> 9 </since_tizen>
        public void SetRemoteDescription(string description)
        {
            ValidateWebRTCState(WebRTCState.Negotiating, WebRTCState.Playing);

            ValidationUtil.ValidateIsNullOrEmpty(description, nameof(description));

            NativeWebRTC.SetRemoteDescription(Handle, description).ThrowIfFailed("Failed to set remote description.");
        }

        /// <summary>
        /// Gets the offer or answer session description from the current remote peer.
        /// </summary>
        /// <value>The remote session description string</value>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <seealso cref="SetRemoteDescription"/>
        /// <since_tizen> 12 </since_tizen>
        public string GetRemoteDescription()
        {
            ValidateNotDisposed();

            IntPtr description = IntPtr.Zero;
            try
            {
                NativeWebRTC.GetRemoteDescription(Handle, out description).ThrowIfFailed("Failed to get remote description.");

                return Marshal.PtrToStringAnsi(description);
            }
            finally
            {
                Marshal.FreeHGlobal(description);
            }
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
        /// Adds media source to the current WebRTC.
        /// </summary>
        /// <remarks>
        /// This method does not throw state exception anymore(Since API Level 12). It can be called in any state.<br/>
        /// Each MediaSource requires different feature or privilege.<br/>
        /// <see cref="MediaCameraSource"/> needs camera feature and privilege.<br/>
        /// <see cref="MediaMicrophoneSource"/> needs microphone feature and recorder privilege.<br/>
        /// </remarks>
        /// <param name="source">The media sources to add.</param>
        /// <feature>http://tizen.org/feature/camera</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <feature>http://tizen.org/feature/display</feature>
        /// <privilege>http://tizen.org/privilege/camera</privilege>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <exception cref="ArgumentNullException">The media source is null.</exception>
        /// <exception cref="InvalidOperationException">
        /// An internal error occurs.<br/>
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

            source?.AttachTo(this);

            _source.Add(source);
        }

        /// <summary>
        /// Adds media sources from the current WebRTC.
        /// </summary>
        /// <remarks>
        /// This method does not throw state exception anymore(Since API Level 12). It can be called in any state.<br/>
        /// Each MediaSource requires different feature or privilege.<br/>
        /// <see cref="MediaCameraSource"/> needs camera feature and privilege.<br/>
        /// <see cref="MediaMicrophoneSource"/> needs microphone feature and recorder privilege.<br/>
        /// </remarks>
        /// <param name="sources">The media sources to add.</param>
        /// <feature>http://tizen.org/feature/camera</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <feature>http://tizen.org/feature/display</feature>
        /// <privilege>http://tizen.org/privilege/camera</privilege>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <exception cref="ArgumentNullException">The media source is null.</exception>
        /// <exception cref="InvalidOperationException">
        /// An internal error occurs.<br/>
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
            if (sources == null)
            {
                throw new ArgumentNullException(nameof(sources), "sources are null");
            }

            foreach (var source in sources)
            {
                AddSource(source);
            }
        }

        /// <summary>
        /// Removes media source from the current WebRTC.
        /// </summary>
        /// <remarks>
        /// This method does not throw state exception anymore(Since API Level 12). It can be called in any state.<br/>
        /// If user want to use removed MediaSource again, user should create new instance for it.
        /// </remarks>
        /// <param name="source">The media source to remove.</param>
        /// <exception cref="ArgumentNullException">The media source is null.</exception>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
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

            source?.DetachFrom(this);

            _source.Remove(source);

            source = null;
        }

        /// <summary>
        /// Removes media sources from the current WebRTC.
        /// </summary>
        /// <remarks>
        /// This method does not throw state exception anymore(Since API Level 12). It can be called in any state.<br/>
        /// If user want to use removed MediaSource again, user should create new instance for it.
        /// </remarks>
        /// <param name="sources">The media source to remove.</param>
        /// <exception cref="ArgumentNullException">The media source is null.</exception>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
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
        /// Sets a turn server for signalling with remote peer which cannot be connected directly.
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
        /// Sets turn servers for signalling with remote peer which cannot be connected directly.
        /// </summary>
        /// <exception cref="ArgumentNullException">The one of <paramref name="turnServers"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void SetTurnServers(params string[] turnServers)
        {
            ValidateNotDisposed();

            if (turnServers == null)
            {
                throw new ArgumentNullException(nameof(turnServers), "Turn server names are null.");
            }

            foreach (var turnServer in turnServers)
            {
                SetTurnServer(turnServer);
            }
        }

        /// <summary>
        /// Retrieves all turn servers.
        /// </summary>
        /// <returns>The turn server list.</returns>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public ReadOnlyCollection<string> GetTurnServer()
        {
            ValidateNotDisposed();

            var list = new List<string>();

            NativeWebRTC.RetrieveTurnServerCallback cb = (server, _) =>
            {
                if (!string.IsNullOrWhiteSpace(server))
                {
                    list.Add(server);
                }

                return true;
            };

            NativeWebRTC.ForeachTurnServer(Handle, cb).ThrowIfFailed("Failed to retrieve turn server");

            return list.AsReadOnly();
        }

        /// <summary>
        /// Retrieves the current statistics information.
        /// </summary>
        /// <remarks>
        /// The WebRTC must be in the <see cref="WebRTCState.Negotiating"/>(Since API Level 12) or <see cref="WebRTCState.Playing"/>
        /// </remarks>
        /// <returns>The WebRTC statistics informations.</returns>
        /// <param name="category">The category of statistics to get.</param>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <exception cref="InvalidOperationException">The WebRTC is not in the valid state.</exception>
        /// <since_tizen> 10 </since_tizen>
        public ReadOnlyCollection<WebRTCStatistics> GetStatistics(WebRTCStatisticsCategory category)
        {
            ValidateWebRTCState(WebRTCState.Negotiating, WebRTCState.Playing);

            var stats = new List<WebRTCStatistics>();
            Exception caught = null;

            NativeWebRTC.RetrieveStatsCallback cb = (category_, prop, _) =>
            {
                try
                {
                    stats.Add(new WebRTCStatistics(category_, prop));
                }
                catch (Exception e)
                {
                    caught = e;
                    return false;
                }

                return true;
            };

            using (var cbKeeper = ObjectKeeper.Get(cb))
            {
                NativeWebRTC.ForeachStats(Handle, (int)category, cb, IntPtr.Zero).
                    ThrowIfFailed("failed to retrieve stats");

                if (caught != null)
                {
                    throw caught;
                }
            }

            return new ReadOnlyCollection<WebRTCStatistics>(stats);
        }

        /// <summary>
        /// Represents WebRTC statistics information.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public class WebRTCStatistics
        {
            internal WebRTCStatistics(WebRTCStatisticsCategory type, IntPtr prop)
            {
                var unmanagedStruct = Marshal.PtrToStructure<NativeWebRTC.StatsPropertyStruct>(prop);

                Category = type;
                Name = unmanagedStruct.name;
                Property = unmanagedStruct.property;

                switch (unmanagedStruct.propertyType)
                {
                    case WebRTCStatsPropertyType.TypeBool:
                        Value = unmanagedStruct.value.@bool;
                        break;
                    case WebRTCStatsPropertyType.TypeInt:
                        Value = unmanagedStruct.value.@int;
                        break;
                    case WebRTCStatsPropertyType.TypeUint:
                        Value = unmanagedStruct.value.@uint;
                        break;
                    case WebRTCStatsPropertyType.TypeInt64:
                        Value = unmanagedStruct.value.@long;
                        break;
                    case WebRTCStatsPropertyType.TypeUint64:
                        Value = unmanagedStruct.value.@ulong;
                        break;
                    case WebRTCStatsPropertyType.TypeFloat:
                        Value = unmanagedStruct.value.@float;
                        break;
                    case WebRTCStatsPropertyType.TypeDouble:
                        Value = unmanagedStruct.value.@double;
                        break;
                    case WebRTCStatsPropertyType.TypeString:
                        Value = Marshal.PtrToStringAnsi(unmanagedStruct.value.@string);
                        break;
                    default:
                        throw new InvalidOperationException($"No matching type [{unmanagedStruct.propertyType}]");
                }
            }

            /// <summary>
            /// Gets the category of statistics.
            /// </summary>
            /// <value>The category of WebRTC statistics information</value>
            /// <since_tizen> 10 </since_tizen>
            public WebRTCStatisticsCategory Category { get; }

            /// <summary>
            /// Gets the name of statistics.
            /// </summary>
            /// <value>The name of WebRTC statistics information</value>
            /// <since_tizen> 10 </since_tizen>
            public string Name { get; }

            /// <summary>
            /// Gets the property of statistics.
            /// </summary>
            /// <value>The property of WebRTC statistics information</value>
            /// <since_tizen> 10 </since_tizen>
            public WebRTCStatisticsProperty Property { get; }

            /// <summary>
            /// Gets the value of statistics.
            /// </summary>
            /// <value>The value of WebRTC statistics information</value>
            /// <since_tizen> 10 </since_tizen>
            public object Value { get; }

            /// <summary>
            /// Returns a string that represents the current object.
            /// </summary>
            /// <returns>A string that represents the current object.</returns>
            /// <since_tizen> 10 </since_tizen>
            public override string ToString() =>
                $"Category={Category}, Name={Name}, Property={Property}, Value={Value}, Type={Value.GetType()}";
        }
    }
}
