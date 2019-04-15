/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Internals.Errors;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Specifies errors.
    /// </summary>
    /// <seealso cref="Player.ErrorOccurred"/>
    /// <seealso cref="PlayerErrorOccurredEventArgs"/>
    /// <since_tizen> 3 </since_tizen>
    public enum PlayerError
    {
        /// <summary>
        /// File does not exists.
        /// </summary>
        NoSuchFile = ErrorCode.NoSuchFile,

        /// <summary>
        /// Internal error.
        /// </summary>
        InternalError = ErrorCode.InvalidOperation,

        /// <summary>
        /// No space.
        /// </summary>
        NoSpaceOnDevice = PlayerErrorCode.NoSpaceOnDevice,

        /// <summary>
        /// Not enough buffer.
        /// </summary>
        BufferSpace = ErrorCode.BufferSpace,

        /// <summary>
        /// <see cref="Player.SetPlayPositionAsync(int, bool)"/> failed.
        /// </summary>
        SeekFailed = PlayerErrorCode.SeekFailed,

        /// <summary>
        /// Invalid state.
        /// </summary>
        InvalidState = PlayerErrorCode.InvalidState,

        /// <summary>
        /// Not supported file.
        /// </summary>
        NotSupportedFile = PlayerErrorCode.NotSupportedFile,

        /// <summary>
        /// Invalid uri.
        /// </summary>
        InvalidUri = PlayerErrorCode.InvalidUri,

        /// <summary>
        /// Connection to service failed.
        /// </summary>
        ConnectionFailed = PlayerErrorCode.ConnectionFailed,

        /// <summary>
        /// Not permitted DRM.
        /// </summary>
        DrmNotPermitted = PlayerErrorCode.DrmNotPermitted,

        /// <summary>
        /// Service disconnected.
        /// </summary>
        ServiceDisconnected = PlayerErrorCode.ServiceDisconnected,

        /// <summary>
        /// Not supported audio codec.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        AudioCodecNotSupported = PlayerErrorCode.NotSupportedAudioCodec,

        /// <summary>
        /// Not supported video codec.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        VideoCodecNotSupported = PlayerErrorCode.NotSupportedVideoCodec,

        /// <summary>
        /// Not supported subtitle file.
        /// </summary>
        SubtitleNotSupported = PlayerErrorCode.NotSupportedSubtitle,
    }

    /// <summary>
    /// Specifies states that a <see cref="Player"/> can have.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum PlayerState
    {
        /// <summary>
        /// Initial state, unprepared.
        /// </summary>
        /// <seealso cref="Player.Unprepare"/>
        Idle = 1,

        /// <summary>
        /// Prepared.
        /// </summary>
        /// <seealso cref="Player.PrepareAsync"/>
        Ready,

        /// <summary>
        /// Playing.
        /// </summary>
        /// <seealso cref="Player.Start"/>
        Playing,

        /// <summary>
        /// Paused while playing media.
        /// </summary>
        /// <seealso cref="Player.Pause"/>
        Paused,

        /// <summary>
        /// Preparation in progress.
        /// </summary>
        /// <remarks>In this state, other methods and properties cannot be set.</remarks>
        /// <seealso cref="Player.PrepareAsync"/>/>
        Preparing,
    }

    internal static class PlayerStateExtensions
    {
        internal static bool IsAnyOf(this PlayerState thisState, params PlayerState[] states)
        {
            return Array.IndexOf(states, thisState) != -1;
        }
    }

    /// <summary>
    /// Specifies audio latency modes for <see cref="Player"/>.
    /// </summary>
    /// <seealso cref="Player.AudioLatencyMode"/>
    /// <since_tizen> 3 </since_tizen>
    public enum AudioLatencyMode
    {
        /// <summary>
        /// Low audio latency mode.
        /// </summary>
        Low,

        /// <summary>
        ///  Middle audio latency mode.
        /// </summary>
        Mid,

        /// <summary>
        /// High audio latency mode.
        /// </summary>
        High,
    }

    /// <summary>
    /// Specifies display modes for <see cref="Player"/>.
    /// </summary>
    /// <seealso cref="PlayerDisplaySettings.Mode"/>
    /// <since_tizen> 3 </since_tizen>
    public enum PlayerDisplayMode
    {
        /// <summary>
        /// Letter box.
        /// </summary>
        LetterBox,

        /// <summary>
        /// Original size.
        /// </summary>
        OriginalSize,

        /// <summary>
        /// Full-screen.
        /// </summary>
        FullScreen,

        /// <summary>
        /// Cropped full-screen.
        /// </summary>
        CroppedFull,

        /// <summary>
        /// Original size (if surface size is larger than video size(width/height)) or
        /// letter box (if video size(width/height) is larger than surface size).
        /// </summary>
        OriginalOrFull,

        /// <summary>
        /// Region of interest.
        /// </summary>
        /// <seealso cref="PlayerDisplaySettings.SetRoi(Rectangle)"/>
        Roi
    }

    internal enum StreamType
    {
        /// <summary>
        ///  Audio element stream type.
        /// </summary>
        Audio = 1,

        /// <summary>
        /// Video element stream type.
        /// </summary>
        Video,

        /// <summary>
        /// Text type.
        /// </summary>
        Text
    }

    /// <summary>
    /// Specifies the streaming buffer status.
    /// </summary>
    /// <seealso cref="MediaStreamConfiguration.BufferStatusChanged"/>
    /// <seealso cref="MediaStreamBufferStatusChangedEventArgs"/>
    /// <since_tizen> 3 </since_tizen>
    public enum MediaStreamBufferStatus
    {
        /// <summary>
        /// Underrun.
        /// </summary>
        Underrun,

        /// <summary>
        ///  Completed.
        /// </summary>
        Overflow,
    }

    /// <summary>
    /// Specifies the reason for the playback interruption.
    /// </summary>
    /// <seealso cref="Player.PlaybackInterrupted"/>
    /// <since_tizen> 3 </since_tizen>
    public enum PlaybackInterruptionReason
    {
        /// <summary>
        /// Interrupted by a resource conflict and the <see cref="Player"/> will be unprepared automatically.
        /// </summary>
        ResourceConflict = 4
    }

    /// <summary>
    /// Specifies keys for the metadata.
    /// </summary>
    /// <seealso cref="StreamInfo.GetMetadata(StreamMetadataKey)"/>
    /// <since_tizen> 3 </since_tizen>
    public enum StreamMetadataKey
    {
        /// <summary>
        /// Album.
        /// </summary>
        Album,

        /// <summary>
        /// Artists.
        /// </summary>
        Artist,

        /// <summary>
        /// Author.
        /// </summary>
        Author,

        /// <summary>
        /// Genre.
        /// </summary>
        Genre,

        /// <summary>
        /// Title.
        /// </summary>
        Title,

        /// <summary>
        /// Year.
        /// </summary>
        Year
    }
}
