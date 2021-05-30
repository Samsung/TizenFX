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
    /// Provides the ability to control WebRTC.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public partial class WebRTC
    {
        private NativeWebRTC.ErrorOccurredCallback _webRtcErrorOccurredCallback;
        private NativeWebRTC.StateChangedCallback _webRtcStateChangedCallback;
        private NativeWebRTC.IceGatheringStateChangedCallback _webRtcIceGatheringStateChangedCallback;
        private NativeWebRTC.SignalingStateChangedCallback _webRtcSignalingStateChangedCallback;
        private NativeWebRTC.PeerConnectionStateChangedCallback _webRtcPeerConnectionStateChangedCallback;
        private NativeWebRTC.IceConnectionStateChangedCallback _webRtcIceConnectionStateChangedCallback;
        private NativeWebRTC.NegotiationNeededCallback _webRtcNegotiationNeededCallback;
        private NativeWebRTC.IceCandidateCallback _webRtcIceCandicateCallback;
        private NativeWebRTC.TrackAddedCallback _webRtcTrackAddedCallback;
        private NativeWebRTC.FrameEncodedCallback _webRtcAudioFrameEncodedCallback;
        private NativeWebRTC.FrameEncodedCallback _webRtcVideoFrameEncodedCallback;
        private NativeDataChannel.CreatedCallback _webRtcDataChannelCreatedCallback;
        private uint? _trackId;

        /// <summary>
        /// Occurs when any error occurs.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<WebRTCErrorOccurredEventArgs> ErrorOccurred;

        /// <summary>
        /// Occurs when WebRTC state is changed.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<WebRTCStateChangedEventArgs> StateChanged;

        /// <summary>
        /// Occurs when the WebRTC ICE gathering state is changed.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<WebRTCIceGatheringStateChangedEventArgs> IceGatheringStateChanged;

        /// <summary>
        /// Occurs when the WebRTC signaling state is changed.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<WebRTCSignalingStateChangedEventArgs> SignalingStateChanged;

        /// <summary>
        /// Occurs when the WebRTC peer connection state is changed.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<WebRTCPeerConnectionStateChangedEventArgs> PeerConnectionStateChanged;

        /// <summary>
        /// Occurs when the WebRTC ICE connection state is changed.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<WebRTCIceConnectionStateChangedEventArgs> IceConnectionStateChanged;

        /// <summary>
        /// Occurs when negotiation is needed.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<EventArgs> NegotiationNeeded;

        /// <summary>
        /// Occurs when the WebRTC needs to send the ICE candidate message to the remote peer.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<WebRTCIceCandicateEventArgs> IceCandidate;

        /// <summary>
        /// Occurs when a new track has been added to the WebRTC.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<WebRTCTrackAddedEventArgs> TrackAdded;

        private event EventHandler<WebRTCFrameEncodedEventArgs> _audioFrameEncoded;

        /// <summary>
        /// Occurs when each audio frame is ready to render.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<WebRTCFrameEncodedEventArgs> AudioFrameEncoded
        {
            add
            {
                if (_audioFrameEncoded == null)
                {
                    RegisterAudioFrameEncodedCallback();
                }

                _audioFrameEncoded += value;
            }
            remove
            {
                _audioFrameEncoded -= value;

                if (_audioFrameEncoded == null)
                {
                    UnregisterAudioFrameEncodedCallback();
                }
            }
        }

        private event EventHandler<WebRTCFrameEncodedEventArgs> _videoFrameEncoded;

        /// <summary>
        /// Occurs when each video frame is ready to render.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<WebRTCFrameEncodedEventArgs> VideoFrameEncoded
        {
            add
            {
                if (_videoFrameEncoded == null)
                {
                    RegisterVideoFrameEncodedCallback();
                }

                _videoFrameEncoded += value;
            }
            remove
            {
                _videoFrameEncoded -= value;

                if (_videoFrameEncoded == null)
                {
                    UnregisterVideoFrameEncodedCallback();
                }
            }
        }

        /// <summary>
        /// Occurs when the data channel is created to the connection by the remote peer.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<WebRTCDataChannelEventArgs> DataChannel;

        private void RegisterEvents()
        {
            RegisterErrorOccurredCallback();
            RegisterStateChangedCallback();
            RegisterIceGatheringStateChangedCallback();
            RegisterSignalingStateChangedCallback();
            RegisterPeerConnectionStateChangedCallback();
            RegisterIceConnectionStateChangedCallback();
            RegisterNegotiationNeededCallback();
            RegisterIceCandidateCallback();
            RegisterTrackAddedCallback();
            RegisterDataChannelCreatedCallback();
        }

        private void RegisterErrorOccurredCallback()
        {
            _webRtcErrorOccurredCallback = (handle, error, state, _) =>
            {
                Log.Info(WebRTCLog.Tag, $"{error}, {state}");

                ErrorOccurred?.Invoke(this, new WebRTCErrorOccurredEventArgs((WebRTCError)error, state));
            };

            NativeWebRTC.SetErrorOccurredCb(Handle, _webRtcErrorOccurredCallback).
                ThrowIfFailed("Failed to set error occurred callback.");
        }

        private void RegisterStateChangedCallback()
        {
            _webRtcStateChangedCallback = (handle, previous, current, _) =>
            {
                Log.Info(WebRTCLog.Tag, $"{previous}, {current}");

                StateChanged?.Invoke(this, new WebRTCStateChangedEventArgs(previous, current));
            };

            NativeWebRTC.SetStateChangedCb(Handle, _webRtcStateChangedCallback).
                ThrowIfFailed("Failed to set state changed callback.");
        }

        private void RegisterIceGatheringStateChangedCallback()
        {
            _webRtcIceGatheringStateChangedCallback = (handle, state, _) =>
            {
                Log.Info(WebRTCLog.Tag, $"Ice gathering state : {state}");

                IceGatheringStateChanged?.Invoke(this, new WebRTCIceGatheringStateChangedEventArgs(state));
            };

            NativeWebRTC.SetIceGatheringStateChangedCb(Handle, _webRtcIceGatheringStateChangedCallback).
                ThrowIfFailed("Failed to set Ice gathering state changed callback.");
        }

        private void RegisterSignalingStateChangedCallback()
        {
            _webRtcSignalingStateChangedCallback = (handle, state, _) =>
            {
                Log.Info(WebRTCLog.Tag, $"Signaling state : {state}");

                SignalingStateChanged?.Invoke(this, new WebRTCSignalingStateChangedEventArgs(state));
            };

            NativeWebRTC.SetSignalingStateChangedCb(Handle, _webRtcSignalingStateChangedCallback).
                ThrowIfFailed("Failed to set signaling state changed callback.");
        }

        private void RegisterPeerConnectionStateChangedCallback()
        {
            _webRtcPeerConnectionStateChangedCallback = (handle, state, _) =>
            {
                Log.Info(WebRTCLog.Tag, $"Peer connection state : {state}");

                PeerConnectionStateChanged?.Invoke(this, new WebRTCPeerConnectionStateChangedEventArgs(state));
            };

            NativeWebRTC.SetPeerConnectionStateChangedCb(Handle, _webRtcPeerConnectionStateChangedCallback).
                ThrowIfFailed("Failed to set peer connection state changed callback.");
        }

        private void RegisterIceConnectionStateChangedCallback()
        {
            _webRtcIceConnectionStateChangedCallback = (handle, state, _) =>
            {
                Log.Info(WebRTCLog.Tag, $"Ice connection state : {state}");

                IceConnectionStateChanged?.Invoke(this, new WebRTCIceConnectionStateChangedEventArgs(state));
            };

            NativeWebRTC.SetIceConnectionStateChangedCb(Handle, _webRtcIceConnectionStateChangedCallback).
                ThrowIfFailed("Failed to set ICE connection state changed callback.");
        }

        private void RegisterNegotiationNeededCallback()
        {
            _webRtcNegotiationNeededCallback = (handle, _) =>
            {
                NegotiationNeeded?.Invoke(this, new EventArgs());
            };

            NativeWebRTC.SetNegotiationNeededCb(Handle, _webRtcNegotiationNeededCallback).
                ThrowIfFailed("Failed to set negotiation needed callback.");
        }

        private void RegisterIceCandidateCallback()
        {
            _webRtcIceCandicateCallback = (handle, candidate, _) =>
            {
                IceCandidate?.Invoke(this, new WebRTCIceCandicateEventArgs(candidate));
            };

            NativeWebRTC.SetIceCandidateCb(Handle, _webRtcIceCandicateCallback).
                ThrowIfFailed("Failed to set ice candidate callback.");
        }

        private void RegisterTrackAddedCallback()
        {
            _webRtcTrackAddedCallback = (handle, type, id, _) =>
            {
                if (type == MediaType.Video)
                {
                    Log.Info(WebRTCLog.Tag, $"track id : {id}");
                    _trackId = id;
                }

                TrackAdded?.Invoke(this, new WebRTCTrackAddedEventArgs(type, id));
            };

            NativeWebRTC.SetTrackAddedCb(Handle, _webRtcTrackAddedCallback).
                ThrowIfFailed("Failed to set track added callback.");
        }

        private void RegisterAudioFrameEncodedCallback()
        {
            _webRtcAudioFrameEncodedCallback = (handle, type, id, packet, _) =>
            {
                _audioFrameEncoded?.Invoke(this, new WebRTCFrameEncodedEventArgs(type, id, MediaPacket.From(packet)));
            };

            NativeWebRTC.SetAudioFrameEncodedCb(Handle, _webRtcAudioFrameEncodedCallback).
                ThrowIfFailed("Failed to set audio frame encoded callback.");
        }

        private void UnregisterAudioFrameEncodedCallback()
        {
            NativeWebRTC.UnsetAudioFrameEncodedCb(Handle).
                ThrowIfFailed("Failed to unset audio frame encoded callback.");
        }

        private void RegisterVideoFrameEncodedCallback()
        {
            _webRtcVideoFrameEncodedCallback = (handle, type, id, packet, _) =>
            {
                _videoFrameEncoded?.Invoke(this, new WebRTCFrameEncodedEventArgs(type, id, MediaPacket.From(packet)));
            };

            NativeWebRTC.SetVideoFrameEncodedCb(Handle, _webRtcVideoFrameEncodedCallback).
                ThrowIfFailed("Failed to set video frame encoded callback.");
        }

        private void UnregisterVideoFrameEncodedCallback()
        {
            NativeWebRTC.UnsetVideoFrameEncodedCb(Handle).
                ThrowIfFailed("Failed to unset video frame encoded callback.");
        }

        private void RegisterDataChannelCreatedCallback()
        {
            _webRtcDataChannelCreatedCallback = (handle, dataChannelHandle, _) =>
            {
                Log.Debug(WebRTCLog.Tag, "Enter");

                DataChannel?.Invoke(this, new WebRTCDataChannelEventArgs(dataChannelHandle));
            };

            NativeDataChannel.SetCreatedByPeerCb(Handle, _webRtcDataChannelCreatedCallback).
                ThrowIfFailed("Failed to set data channel created callback.");
        }
    }
}
