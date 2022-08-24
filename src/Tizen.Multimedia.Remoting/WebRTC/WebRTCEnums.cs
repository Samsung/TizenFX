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
    /// Specifies ICE gathering states that a <see cref="WebRTC"/> can have.
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
    /// Specifies signaling states that a <see cref="WebRTC"/> can have.
    /// </summary>
    /// <remarks>This state is related in SDP offer/answer.</remarks>
    /// <seealso cref="WebRTC.SetLocalDescription"/>
    /// <seealso cref="WebRTC.SetRemoteDescription"/>
    /// <seealso cref="WebRTC.CreateAnswerAsync()"/>
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
    /// Specifies peer connection states that a <see cref="WebRTC"/> can have.
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
    /// Specifies ICE connection states that a <see cref="WebRTC"/> can have.
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
    /// <remarks>
    /// See also https://www.w3.org/TR/webrtc/#rtcicetransportpolicy-enum
    /// </remarks>
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
    /// Specifies the display type.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public enum WebRTCDisplayMode
    {
        /// <summary>
        /// Letter box.
        /// </summary>
        LetterBox,

        /// <summary>
        /// Original size.
        /// </summary>
        OriginSize,

        /// <summary>
        /// Full screen.
        /// </summary>
        Full
    }

    /// <summary>
    /// Specifies the bundle policy.
    /// </summary>
    /// <remarks>
    /// The details of bundle policy enum is described in https://www.w3.org/TR/webrtc/#rtcbundlepolicy-enum.
    /// </remarks>
    /// <since_tizen> 10 </since_tizen>
    public enum WebRTCBundlePolicy
    {
        /// <summary>
        /// No bundle.
        /// </summary>
        None,

        /// <summary>
        /// Bundle all media tracks into a stream when it's transfered to remote peer.
        /// </summary>
        MaxBundle
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

    /// <summary>
    /// Specifies the type of WebRTC statistics.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [Flags]
    public enum WebRTCStatisticsCategory
    {
        /// <summary>
        /// Codec.
        /// </summary>
        Codec = 1,

        /// <summary>
        /// Inbound RTP.
        /// </summary>
        InboundRtp = 2,

        /// <summary>
        /// Outbound RTP.
        /// </summary>
        OutboundRtp = 4,

        /// <summary>
        /// Remote inbound RTP.
        /// </summary>
        RemoteInboundRtp = 8,

        /// <summary>
        /// Remote Outbound RTP.
        /// </summary>
        RemoteOutboundRtp = 16,

        /// <summary>
        /// All types of WebRTC statistics.
        /// </summary>
        All = Codec | InboundRtp | OutboundRtp | RemoteInboundRtp | RemoteOutboundRtp
    }

    [Flags]
    internal enum WebRTCStatisticsPropertyCategory
    {
        Common = 0x00000100,

        Codec = 0x00000200,

        RtpStream = 0x00000400,

        ReceivedRtpStream = 0x00000800,

        InboundRtpStream = 0x00001000,

        SentRtpStream = 0x00002000,

        OutboundRtpStream = 0x00004000,

        RemoteInboundRtpStream = 0x00008000,

        RemoteOutboundRtpStream = 0x00010000
    }

    /// <summary>
    /// Specifies the WebRTC statistics property.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public enum WebRTCStatisticsProperty
    {
        /// <summary>
        /// Timestamp.
        /// </summary>
        Timestamp = WebRTCStatisticsPropertyCategory.Common | 0x01,

        /// <summary>
        /// ID.
        /// </summary>
        Id = WebRTCStatisticsPropertyCategory.Common | 0x02,

        /// <summary>
        /// Payload type.
        /// </summary>
        PayloadType = WebRTCStatisticsPropertyCategory.Codec | 0x01,

        /// <summary>
        /// Clock rate.
        /// </summary>
        ClockRate = WebRTCStatisticsPropertyCategory.Codec | 0x02,

        /// <summary>
        /// Channels.
        /// </summary>
        Channels = WebRTCStatisticsPropertyCategory.Codec | 0x03,

        /// <summary>
        /// Mime type.
        /// </summary>
        MimeType = WebRTCStatisticsPropertyCategory.Codec | 0x04,

        /// <summary>
        /// Codec type.
        /// </summary>
        CodecType = WebRTCStatisticsPropertyCategory.Codec | 0x05,

        /// <summary>
        /// SDP FMTP line.
        /// </summary>
        SdpFmtpLine = WebRTCStatisticsPropertyCategory.Codec | 0x06,

        /// <summary>
        /// SSRC.
        /// </summary>
        Ssrc = WebRTCStatisticsPropertyCategory.RtpStream | 0x01,

        /// <summary>
        /// Transport ID.
        /// </summary>
        TransportId = WebRTCStatisticsPropertyCategory.RtpStream | 0x02,

        /// <summary>
        /// Codec ID.
        /// </summary>
        CodecId = WebRTCStatisticsPropertyCategory.RtpStream | 0x03,

        /// <summary>
        /// Received packet.
        /// </summary>
        PacketsReceived = WebRTCStatisticsPropertyCategory.ReceivedRtpStream | 0x01,

        /// <summary>
        /// Lost packet.
        /// </summary>
        PacketsLost = WebRTCStatisticsPropertyCategory.ReceivedRtpStream | 0x02,

        /// <summary>
        /// Discarted packet.
        /// </summary>
        PacketsDiscarded = WebRTCStatisticsPropertyCategory.ReceivedRtpStream | 0x03,

        /// <summary>
        /// Jitter.
        /// </summary>
        Jitter = WebRTCStatisticsPropertyCategory.ReceivedRtpStream | 0x05,

        /// <summary>
        /// Received bytes.
        /// </summary>
        BytesReceived = WebRTCStatisticsPropertyCategory.InboundRtpStream | 0x01,

        /// <summary>
        /// Duplicated packet.
        /// </summary>
        PacketsDuplicated = WebRTCStatisticsPropertyCategory.InboundRtpStream | 0x02,

        /// <summary>
        /// Sent bytes.
        /// </summary>
        BytesSent = WebRTCStatisticsPropertyCategory.SentRtpStream | 0x01,

        /// <summary>
        /// Sent packets.
        /// </summary>
        PacketsSent = WebRTCStatisticsPropertyCategory.SentRtpStream | 0x02,

        /// <summary>
        /// Remote ID.
        /// </summary>
        RemoteId = WebRTCStatisticsPropertyCategory.InboundRtpStream | WebRTCStatisticsPropertyCategory.OutboundRtpStream | 0x01,

        /// <summary>
        /// FIR count.
        /// </summary>
        FirCount = WebRTCStatisticsPropertyCategory.InboundRtpStream | WebRTCStatisticsPropertyCategory.OutboundRtpStream | 0x02,

        /// <summary>
        /// PLI count.
        /// </summary>
        PliCount = WebRTCStatisticsPropertyCategory.InboundRtpStream | WebRTCStatisticsPropertyCategory.OutboundRtpStream | 0x03,

        /// <summary>
        /// NACK count.
        /// </summary>
        NackCount = WebRTCStatisticsPropertyCategory.InboundRtpStream | WebRTCStatisticsPropertyCategory.OutboundRtpStream | 0x04,

        /// <summary>
        /// Round trip time.
        /// </summary>
        RoundTripTime = WebRTCStatisticsPropertyCategory.RemoteInboundRtpStream | 0x01,

        /// <summary>
        /// Lost fraction.
        /// </summary>
        FractionLost = WebRTCStatisticsPropertyCategory.RemoteInboundRtpStream | 0x02,

        /// <summary>
        /// Remote timestamp.
        /// </summary>
        RemoteTimestamp = WebRTCStatisticsPropertyCategory.OutboundRtpStream | 0x01,

        /// <summary>
        /// Local ID.
        /// </summary>
        LocalId = WebRTCStatisticsPropertyCategory.RemoteInboundRtpStream | WebRTCStatisticsPropertyCategory.RemoteOutboundRtpStream | 0x01
    }

    internal enum WebRTCStatsPropertyType
    {
        TypeBool,
        TypeInt,
        TypeUint,
        TypeInt64,
        TypeUint64,
        TypeFloat,
        TypeDouble,
        TypeString
    }
}
