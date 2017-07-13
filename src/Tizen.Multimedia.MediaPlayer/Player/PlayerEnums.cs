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

        //TODO must be removed.
        /// <summary>
        /// Not supported.
        /// </summary>
        FeatureNotSupported = ErrorCode.NotSupported,

        //TODO must be removed.
        /// <summary>
        /// Permission denined.
        /// </summary>
        PermissionDenied = ErrorCode.PermissionDenied,

        /// <summary>
        /// Not enough buffer.
        /// </summary>
        BufferSpace = ErrorCode.BufferSpace,

        /// <summary>
        /// <see cref="Player.SetPlayPositionAsync(int, bool)/> failed.
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

        //TODO must be removed.
        /// <summary>
        /// Sound policy error.
        /// </summary>
        SoundPolicy = PlayerErrorCode.SoundPolicyError,

        /// <summary>
        /// Connection to service failed.
        /// </summary>
        ConnectionFailed = PlayerErrorCode.ConnectionFailed,

        // TODO must be removed.
        /// <summary>
        /// Capture failed.
        /// </summary>
        VideoCaptureFailed = PlayerErrorCode.VideoCaptureFailed,

        // TODO must be removed.
        /// <summary>
        /// DRM expired.
        /// </summary>
        DrmExpired = PlayerErrorCode.DrmExpired,

        // TODO must be removed.
        /// <summary>
        /// No license of DRM.
        /// </summary>
        DrmNoLicense = PlayerErrorCode.DrmNoLicense,

        // TODO must be removed.
        /// <summary>
        /// Not used.
        /// </summary>
        DrmFutureUse = PlayerErrorCode.DrmFutureUse,

        /// <summary>
        /// Not permitted DRM.
        /// </summary>
        DrmNotPermitted = PlayerErrorCode.DrmNotPermitted,

        // TODO must be removed.
        /// <summary>
        /// Not enough resource.
        /// </summary>
        ResourceLimit = PlayerErrorCode.ResourceLimit,

        /// <summary>
        /// Service disconnected.
        /// </summary>
        ServiceDisconnected = PlayerErrorCode.ServiceDisconnected,

        /// <summary>
        /// Not supported subtitle file.
        /// </summary>
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
