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
    public enum PlayerError
    {
        NoSuchFile = ErrorCode.NoSuchFile,
        InternalError = ErrorCode.InvalidOperation,
        NoSpaceOnDevice = PlayerErrorCode.NoSpaceOnDevice,
        FeatureNotSupported = ErrorCode.NotSupported,
        PermissionDenied = ErrorCode.PermissionDenied,
        BufferSpace = ErrorCode.BufferSpace,
        SeekFailed = PlayerErrorCode.SeekFailed,
        InvalidState = PlayerErrorCode.InvalidState,
        NotSupportedFile = PlayerErrorCode.NotSupportedFile,
        InvalidUri = PlayerErrorCode.InvalidUri,
        SoundPolicy = PlayerErrorCode.SoundPolicyError,
        ConnectionFailed = PlayerErrorCode.ConnectionFailed,
        VideoCaptureFailed = PlayerErrorCode.VideoCaptureFailed,
        DrmExpired = PlayerErrorCode.DrmExpired,
        DrmNoLicense = PlayerErrorCode.DrmNoLicense,
        DrmFutureUse = PlayerErrorCode.DrmFutureUse,
        DrmNotPermitted = PlayerErrorCode.DrmNotPermitted,
        ResourceLimit = PlayerErrorCode.ResourceLimit,
        ServiceDisconnected = PlayerErrorCode.ServiceDisconnected,
        SubtitleNotSupported = PlayerErrorCode.NotSupportedSubtitle,
    }

    /// <summary>
    /// Specifies states that a <see cref="Player"/> can have.
    /// </summary>
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
        /// Preparing in progress.
        /// </summary>
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
    /// Specifies audio latency modes for <see cref="Player"/> .
    /// </summary>
    /// <seealso cref="Player.AudioLatencyMode"/>
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
    /// Specifies display rotation modes for <see cref="Player"/>.
    /// </summary>
    /// <seealso cref="Display.Rotation"/>
    public enum PlayerDisplayRotation
    {
        /// <summary>
        /// Display is not rotated
        /// </summary>
        RotationNone,

        /// <summary>
        ///  Display is rotated 90 degrees
        /// </summary>
        Rotation90,

        /// <summary>
        /// Display is rotated 180 degrees
        /// </summary>
        Rotation180,

        /// <summary>
        /// Display is rotated 270 degrees
        /// </summary>
        Rotation270
    }


    /// <summary>
    /// Specifies display modes for <see cref="Player"/>
    /// </summary>
    /// <seealso cref="Display.Mode"/>
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
        /// Origin size (if surface size is larger than video size(width/height)) or
        /// Letter box (if video size(width/height) is larger than surface size).
        /// </summary>
        OriginalOrFull,

        /// <summary>
        /// Region of interest, See <see cref="Display.SetRoi(Rectangle)"/>.
        /// </summary>
        Roi
    }

    internal enum StreamType
    {
        /// <summary>
        ///  Audio element stream type
        /// </summary>
        Audio = 1,

        /// <summary>
        /// Video element stream type
        /// </summary>
        Video,

        /// <summary>
        /// Text type
        /// </summary>
        Text
    }

    /// <summary>
    /// Specifies the streaming buffer status.
    /// </summary>
    /// <seealso cref="MediaStreamConfiguration.BufferStatusChanged"/>
    /// <seealso cref="MediaStreamBufferStatusChangedEventArgs"/>
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
    public enum PlaybackInterruptionReason
    {
        /// <summary>
        /// Interrupted by a resource conflict and the <see cref="Player"/> will be unprepared, automatically.
        /// </summary>
        ResourceConflict = 4
    }

    /// <summary>
    /// Specifies keys for the metadata.
    /// </summary>
    /// <seealso cref="StreamInfo.GetMetadata(StreamMetadataKey)"/>
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
