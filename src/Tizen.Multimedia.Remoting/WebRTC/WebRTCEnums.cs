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
using System.ComponentModel;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Specifies errors.
    /// </summary>
    /// <seealso cref="WebRTC.ErrorOccurred"/>
    /// <seealso cref="WebRTCErrorOccurredEventArgs"/>
    /// <since_tizen> 9 </since_tizen>
    public enum WebRTCError
    {
        /// <summary>
        /// The connection failed.
        /// </summary>
        ConnectionFailed = WebRTCErrorCode.ConnectionFailed,

        /// <summary>
        /// The stream failed.
        /// </summary>
        StreamFailed = WebRTCErrorCode.StreamFailed,

        /// <summary>
        /// The resource failed.
        /// </summary>
        ResourceFailed = WebRTCErrorCode.ResourceFailed,

        /// <summary>
        /// The resource conflicted.
        /// </summary>
        ResourceConflict = WebRTCErrorCode.ResourceConflict,

        /// <summary>
        /// The invalid operation.
        /// </summary>
        InvalidOperation = WebRTCErrorCode.InvalidOperation
    }

    /// <summary>
    /// Specifies states that a <see cref="WebRTC"/> can have.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public enum WebRTCState
    {
        /// <summary>
        /// The Initial state, create but not started.
        /// </summary>
        Idle,

        /// <summary>
        /// Started and negotiating.
        /// </summary>
        Negotiating,

        /// <summary>
        /// Negotiated and started all streams.
        /// </summary>
        Playing,
    }

    /// <summary>
    /// Specifies states that a <see cref="WebRTC"/> can have.
    /// </summary>
    /// <seealso cref="WebRTC.IceCandidate"/>
    /// <since_tizen> 9 </since_tizen>
    public enum WebRTCIceGatheringState
    {
        /// <summary>
        /// The Initial state.
        /// </summary>
        New,

        /// <summary>
        /// Ice candidate is creating.
        /// </summary>
        Gathering,

        /// <summary>
        /// Ice gathering sequence has been completed.
        /// </summary>
        Completed,
    }

    /// <summary>
    /// Specifies states that a <see cref="WebRTC"/> can have.
    /// </summary>
    /// <remarks>This state is related in SDP offer/answer.</remarks>
    /// <seealso cref="WebRTC.SetLocalDescription"/>
    /// <seealso cref="WebRTC.SetRemoteDescription"/>
    /// <seealso cref="WebRTC.CreateAnswer()"/>
    /// <since_tizen> 9 </since_tizen>
    public enum WebRTCSignalingState
    {
        /// <summary>
        /// The Initial state.
        /// </summary>
        Stable,

        /// <summary>
        /// The local SDP offer has been applied successfully.
        /// </summary>
        HaveLocalOffer,

        /// <summary>
        /// The remote SDP offer has been applied successfully.
        /// </summary>
        HaveRemoteOffer,

        /// <summary>
        /// The SDP offer sent by the remote peer has been applied and <br/>
        /// an answer has been created and applied.
        /// </summary>
        HaveLocalPrAnswer,

        /// <summary>
        /// A provisional answer has been received and successfully applied in local.
        /// </summary>
        HaveRemotePrAnswer,

        /// <summary>
        /// The connection is closed.
        /// </summary>
        Closed
    }

    /// <summary>
    /// Specifies states that a <see cref="WebRTC"/> can have.
    /// </summary>
    /// <remarks>This state is related in peer connection.</remarks>
    /// <since_tizen> 9 </since_tizen>
    public enum WebRTCPeerConnectionState
    {
        /// <summary>
        /// The Initial state.
        /// </summary>
        New,

        /// <summary>
        /// Establishing a connection is in the process.
        /// </summary>
        Connecting,

        /// <summary>
        /// The remote SDP offer has been applied successfully.
        /// </summary>
        Connected,

        /// <summary>
        /// The SDP offer sent by the remote peer has been applied and an answer has been created and applied.
        /// </summary>
        Disconnected,

        /// <summary>
        /// A provisional answer has been received and successfully applied in local.
        /// </summary>
        Failed,

        /// <summary>
        /// The connection is closed.
        /// </summary>
        Closed
    }

    /// <summary>
    /// Specifies states that a <see cref="WebRTC"/> can have.
    /// </summary>
    /// <remarks>This state describe the current state of local and its connection to the ICE server(STUN or TURN).</remarks>
    /// <since_tizen> 9 </since_tizen>
    public enum WebRTCIceConnectionState
    {
        /// <summary>
        /// The Initial state.
        /// </summary>
        New,

        /// <summary>
        /// Checking pairs of local and remote candidates against one another to try to find a compatible match.
        /// </summary>
        Checking,

        /// <summary>
        /// A usable pairing of local and remote candidates has been found for all components of the connection,<br/>
        /// and the connection has been established.
        /// </summary>
        Connected,

        /// <summary>
        /// Gathering candidates has been finished and hecked all pairs against one another,<br/>
        /// and has found a connection for all components.
        /// </summary>
        Completed,

        /// <summary>
        /// There's no compatible matches.
        /// </summary>
        Failed,

        /// <summary>
        /// This is a less stringent test than "Failed" and may trigger intermittently and resolve just as spontaneously on less reliable networks,<br/>
        /// or during temporary disconnections. When the problem resolves, the connection may return to the "connected" state.
        /// </summary>
        Disconnected,

        /// <summary>
        /// Closed.
        /// </summary>
        Closed
    }

    internal static class WebRTCStateExtensions
    {
        internal static bool IsAnyOf<T>(this T thisState, params T[] states) =>
            Array.IndexOf<T>(states, thisState) != -1;
    }

    /// <summary>
    /// Specifies data type that transfers on data channel.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public enum DataChannelType
    {
        /// <summary>
        /// The string data type.
        /// </summary>
        Strings,

        /// <summary>
        /// The byte data type.
        /// </summary>
        Bytes,
    }

    /// <summary>
    /// Specifies the buffer state type of <see cref="MediaPacketSource"/>.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public enum MediaPacketBufferStatus
    {
        /// <summary>
        /// The buffer underrun.
        /// </summary>
        Underrun,

        /// <summary>
        /// The buffer overflow.
        /// </summary>
        Overflow,
    }

    /// <summary>
    /// Specifies the media type.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public enum MediaType
    {
        /// <summary>
        /// The audio type.
        /// </summary>
        Audio,

        /// <summary>
        /// The video type.
        /// </summary>
        Video,
    }

    /// <summary>
    /// Specifies the transceiver direction type.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public enum TransceiverDirection
    {
        /// <summary>
        /// Send only.
        /// </summary>
        SendOnly,

        /// <summary>
        /// Receive only.
        /// </summary>
        RecvOnly,

        /// <summary>
        /// Send and receive.
        /// </summary>
        SendRecv,
    }

    /// <summary>
    /// Specifies the policy of Ice transport.
    /// </summary>
    /// <seealso aref="https://www.w3.org/TR/webrtc/#rtcicetransportpolicy-enum"/>
    /// <since_tizen> 9 </since_tizen>
    public enum IceTransportPolicy
    {
        /// <summary>
        /// All.
        /// </summary>
        All,

        /// <summary>
        /// Relay.
        /// </summary>
        Relay
    }

    /// <summary>
    /// Specifies the signaling message type.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum SignalingMessageType
    {
        /// <summary>
        /// Connected.
        /// </summary>
        Connected,

        /// <summary>
        /// Disconnected.
        /// </summary>
        Disconnected,

        /// <summary>
        /// Session established.
        /// </summary>
        SessionEstablished,

        /// <summary>
        /// Session closed.
        /// </summary>
        SessionClosed,

        /// <summary>
        /// SDP(Session Description Protocol).
        /// </summary>
        Sdp,

        /// <summary>
        /// ICE(Interactive Connectivity Establishment) candidate.
        /// </summary>
        IceCandidate,

        /// <summary>
        /// Error.
        /// </summary>
        Error,
    }

    internal enum MediaSourceType
    {
        AudioTest,

        VideoTest,

        Microphone,

        Camera,

        Screen,

        File,

        MediaPacket
    }

    internal enum CustomMediaSourceType
    {
        Audio = 7,

        Video
    }

    internal enum WebRTCDisplayType
    {
        Overlay,

        Evas,
    }
}