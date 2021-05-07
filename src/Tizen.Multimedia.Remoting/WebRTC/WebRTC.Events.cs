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
        private NativeWebRTC.NegotiationNeededCallback _webRtcNegotiationNeededCallback;
        private NativeWebRTC.IceCandidateCallback _webRtcIceCandicateCallback;
        private NativeWebRTC.TrackAddedCallback _webRtcTrackAddedCallback;
        private NativeWebRTC.FrameEncodedCallback _webRtcFrameEncodedCallback;
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

        /// <summary>
        /// Occurs when each audio frame is ready to render.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<WebRTCFrameEncodedEventArgs> AudioFrameEncoded;

        /// <summary>
        /// Occurs when each video frame is ready to render.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<WebRTCFrameEncodedEventArgs> VideoFrameEncoded;

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
            RegisterNegotiationNeededCallback();
            RegisterIceCandidateCallback();
            RegisterTrackAddedCallback();
            RegisterFrameEncodedCallback();
            RegisterDataChannelCreatedCallback();
        }

        private void RegisterErrorOccurredCallback()
        {
            _webRtcErrorOccurredCallback = (handle, error, state, _) =>
            {
                Log.Info(WebRTCLog.Tag, $"{error}, {state}");

                ErrorOccurred?.Invoke(this, new WebRTCErrorOccurredEventArgs((WebRTCError)error, state));
            };

            NativeWebRTC.SetErrorOccurredCb(Handle, _webRtcErrorOccurredCallback, IntPtr.Zero).
                ThrowIfFailed("Failed to set error occurred callback.");
        }

        private void RegisterStateChangedCallback()
        {
            _webRtcStateChangedCallback = (handle, previous, current, _) =>
            {
                Log.Info(WebRTCLog.Tag, $"{previous}, {current}");

                StateChanged?.Invoke(this, new WebRTCStateChangedEventArgs(previous, current));
            };

            NativeWebRTC.SetStateChangedCb(Handle, _webRtcStateChangedCallback, IntPtr.Zero).
                ThrowIfFailed("Failed to set state changed callback.");
        }

        private void RegisterIceGatheringStateChangedCallback()
        {
            _webRtcIceGatheringStateChangedCallback = (handle, state, _) =>
            {
                Log.Info(WebRTCLog.Tag, $"{state}");

                IceGatheringStateChanged?.Invoke(this, new WebRTCIceGatheringStateChangedEventArgs(state));
            };

            NativeWebRTC.SetIceGatheringStateChangedCb(Handle, _webRtcIceGatheringStateChangedCallback, IntPtr.Zero).
                ThrowIfFailed("Failed to set Ice gathering state changed callback.");
        }

        private void RegisterNegotiationNeededCallback()
        {
            _webRtcNegotiationNeededCallback = (handle, _) =>
            {
                NegotiationNeeded?.Invoke(this, new EventArgs());
            };

            NativeWebRTC.SetNegotiationNeededCb(Handle, _webRtcNegotiationNeededCallback, IntPtr.Zero).
                ThrowIfFailed("Failed to set negotiation needed callback.");
        }

        private void RegisterIceCandidateCallback()
        {
            _webRtcIceCandicateCallback = (handle, candidate, _) =>
            {
                IceCandidate?.Invoke(this, new WebRTCIceCandicateEventArgs(candidate));
            };

            NativeWebRTC.SetIceCandidateCb(Handle, _webRtcIceCandicateCallback, IntPtr.Zero).
                ThrowIfFailed("Failed to set ice candidate callback.");
        }

        private void RegisterTrackAddedCallback()
        {
            _webRtcTrackAddedCallback = (handle, type, id, _) =>
            {
                if (type == MediaType.Video)
                {
                    _trackId = id;
                }

                TrackAdded?.Invoke(this, new WebRTCTrackAddedEventArgs(type, id));
            };

            NativeWebRTC.SetTrackAddedCb(Handle, _webRtcTrackAddedCallback, IntPtr.Zero).
                ThrowIfFailed("Failed to set track added callback.");
        }

        private void RegisterFrameEncodedCallback()
        {
            _webRtcFrameEncodedCallback = (handle, type, id, packet, _) =>
            {
                if (type == MediaType.Audio)
                {
                    AudioFrameEncoded?.Invoke(this, new WebRTCFrameEncodedEventArgs(type, id, MediaPacket.From(packet)));
                }
                else
                {
                    VideoFrameEncoded?.Invoke(this, new WebRTCFrameEncodedEventArgs(type, id, MediaPacket.From(packet)));
                }
            };

            NativeWebRTC.SetAudioFrameEncodedCb(Handle, _webRtcFrameEncodedCallback, IntPtr.Zero).
                ThrowIfFailed("Failed to set audio frame encoded callback.");

            NativeWebRTC.SetVideoFrameEncodedCb(Handle, _webRtcFrameEncodedCallback, IntPtr.Zero).
                ThrowIfFailed("Failed to set video frame encoded callback.");
        }

        private void RegisterDataChannelCreatedCallback()
        {
            _webRtcDataChannelCreatedCallback = (handle, dataChannelHandle, _) =>
            {
                Log.Debug(WebRTCLog.Tag, "Enter");

                DataChannel?.Invoke(this, new WebRTCDataChannelEventArgs(dataChannelHandle));
            };

            NativeDataChannel.SetCreatedByPeerCb(Handle, _webRtcDataChannelCreatedCallback, IntPtr.Zero).
                ThrowIfFailed("Failed to set data channel created callback.");
        }
    }
}
