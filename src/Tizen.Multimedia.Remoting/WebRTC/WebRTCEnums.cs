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
using System.Diagnostics;
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

    internal static class WebRTCStateExtensions
    {
        internal static bool IsAnyOf(this WebRTCState thisState, params WebRTCState[] states) =>
            Array.IndexOf<WebRTCState>(states, thisState) != -1;
    }

    /// <summary>
    /// Specifies states that a <see cref="WebRTC"/> can have.
    /// </summary>
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
    public enum TransMode
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
        Camera,
        Microphone,
        AudioTest,
        VideoTest,
        MediaPacket,
        Screen
    }

    internal enum WebRTCDisplayType
    {
        Overlay,
        Evas,
    }
}