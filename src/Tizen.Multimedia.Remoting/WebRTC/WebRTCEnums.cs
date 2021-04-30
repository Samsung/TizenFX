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
    public enum WebRTCError
    {
        ConnectionFailed = WebRTCErrorCode.ConnectionFailed,
        StreamFailed = WebRTCErrorCode.StreamFailed,
        ResourceFailed = WebRTCErrorCode.ResourceFailed,
        ResourceConflict = WebRTCErrorCode.ResourceConflict,
        InvalidOperation = WebRTCErrorCode.InvalidOperation
    }

    public enum WebRTCState
    {
        Idle,
        Negotiating,
        Playing,
    }

    internal static class WebRTCStateExtensions
    {
        internal static bool IsAnyOf(this WebRTCState thisState, params WebRTCState[] states) =>
            Array.IndexOf<WebRTCState>(states, thisState) != -1;
    }

    public enum DataChannelType
    {
        Strings,
        Bytes,
    }

    public enum MediaPacketBufferStatus
    {
        Underrun,
        Overflow,
    }

    public enum MediaType
    {
        Audio,
        Video,
    }

    public enum TransMode
    {
        SendOnly,
        RecvOnly,
        SendRecv,
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum SignalingMessageType
    {
        Connected,
        Disconnected,
        SessionEstablished,
        SessionClosed,
        Sdp,
        IceCandidate,
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