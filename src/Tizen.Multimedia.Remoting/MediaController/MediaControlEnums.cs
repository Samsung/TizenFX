/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Diagnostics;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Specifies the playlist mode.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum MediaControlPlaylistMode
    {
        /// <summary>
        /// Playlist is created or update.
        /// </summary>
        Updated,

        /// <summary>
        /// Playlist is removed.
        /// </summary>
        Removed,
    }

    /// <summary>
    /// Specifies the repeat mode.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum MediaControlRepeatMode
    {
        /// <summary>
        /// Off.
        /// </summary>
        Off,

        /// <summary>
        /// On.
        /// </summary>
        On,

        /// <summary>
        /// One media.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        OneMedia
    }

    /// <summary>
    /// Specifies playback commands.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum MediaControlPlaybackCommand
    {
        /// <summary>
        /// Play.
        /// </summary>
        Play,

        /// <summary>
        /// Pause.
        /// </summary>
        Pause,

        /// <summary>
        /// Stop.
        /// </summary>
        Stop,

        /// <summary>
        /// Skip to next.
        /// </summary>
        Next,

        /// <summary>
        /// Skip to previous.
        /// </summary>
        Previous,

        /// <summary>
        /// Fast forward.
        /// </summary>
        FastForward,

        /// <summary>
        /// Rewind.
        /// </summary>
        Rewind,

        /// <summary>
        /// Toggle play/pause.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Toggle,
    }

    /// <summary>
    /// Specifies playback states.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum MediaControlPlaybackState
    {
        /// <summary>
        /// Unknown; no state is set.
        /// </summary>
        None,

        /// <summary>
        /// Playing.
        /// </summary>
        Playing,

        /// <summary>
        /// Paused.
        /// </summary>
        Paused,

        /// <summary>
        /// Stopped.
        /// </summary>
        Stopped,

        /// <summary>
        /// Fast forwarding.
        /// </summary>
        FastForwarding,

        /// <summary>
        /// Rewinding.
        /// </summary>
        Rewinding,

        /// <summary>
        /// Skipping to the next item.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        MovingToNext,

        /// <summary>
        /// Skipping to the previous item.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        MovingToPrevious,
    }

    /// <summary>
    /// Specifies the support type of media control capability.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum MediaControlCapabilitySupport
    {
        /// <summary>
        /// Supported.
        /// </summary>
        Supported,

        /// <summary>
        /// Not supported.
        /// </summary>
        NotSupported,

        /// <summary>
        /// There's no support info in server.
        /// </summary>
        /// <remarks>User should not set this value directly.</remarks>
        NotDecided
    }

    /// <summary>
    /// Specifies the content type.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum MediaControlContentType
    {
        /// <summary>
        /// Image type.
        /// </summary>
        Image,

        /// <summary>
        /// Video type.
        /// </summary>
        Video,

        /// <summary>
        /// Music type.
        /// </summary>
        Music,

        /// <summary>
        /// Other type.
        /// </summary>
        Other,

        /// <summary>
        /// There's no content type info in server.
        /// </summary>
        NotDecided
    }

    /// <summary>
    /// Specifies the search category.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum MediaControlSearchCategory
    {
        /// <summary>
        /// Search by all category.
        /// </summary>
        All,

        /// <summary>
        /// Search by content title.
        /// </summary>
        Title,

        /// <summary>
        /// Search by content artist.
        /// </summary>
        Artist,

        /// <summary>
        /// Search by content album.
        /// </summary>
        Album,

        /// <summary>
        /// Search by content genre.
        /// </summary>
        Genre,

        /// <summary>
        /// Search by TPO(Time Place Occasion).
        /// </summary>
        Tpo
    }

    internal static class EnumExtensions
    {
        internal static MediaControlPlaybackState ToPublic(this MediaControllerNativePlaybackState nativeState)
        {
            switch (nativeState)
            {
                case MediaControllerNativePlaybackState.None: return MediaControlPlaybackState.None;
                case MediaControllerNativePlaybackState.Play: return MediaControlPlaybackState.Playing;
                case MediaControllerNativePlaybackState.Pause: return MediaControlPlaybackState.Paused;
                case MediaControllerNativePlaybackState.Stop: return MediaControlPlaybackState.Stopped;
                case MediaControllerNativePlaybackState.Next:
                case MediaControllerNativePlaybackState.MovingToNext: return MediaControlPlaybackState.MovingToNext;
                case MediaControllerNativePlaybackState.Prev:
                case MediaControllerNativePlaybackState.MovingToPrev: return MediaControlPlaybackState.MovingToPrevious;
                case MediaControllerNativePlaybackState.FastForward:
                case MediaControllerNativePlaybackState.FastForwarding: return MediaControlPlaybackState.FastForwarding;
                case MediaControllerNativePlaybackState.Rewind:
                case MediaControllerNativePlaybackState.Rewinding: return MediaControlPlaybackState.Rewinding;
            }

            Debug.Fail($"Not supported code for playback state{nativeState}.");
            return MediaControlPlaybackState.None;
        }

        internal static MediaControllerNativePlaybackState ToNative(this MediaControlPlaybackState state)
        {
            switch (state)
            {
                case MediaControlPlaybackState.Playing: return MediaControllerNativePlaybackState.Play;
                case MediaControlPlaybackState.Paused: return MediaControllerNativePlaybackState.Pause;
                case MediaControlPlaybackState.Stopped: return MediaControllerNativePlaybackState.Stop;
                case MediaControlPlaybackState.MovingToNext: return MediaControllerNativePlaybackState.MovingToNext;
                case MediaControlPlaybackState.MovingToPrevious: return MediaControllerNativePlaybackState.MovingToPrev;
                case MediaControlPlaybackState.FastForwarding: return MediaControllerNativePlaybackState.FastForwarding;
                case MediaControlPlaybackState.Rewinding: return MediaControllerNativePlaybackState.Rewinding;
            }
            return MediaControllerNativePlaybackState.None;
        }

        internal static MediaControlPlaybackCommand ToPublic(this MediaControllerNativePlaybackAction nativeAction)
        {
            switch (nativeAction)
            {
                case MediaControllerNativePlaybackAction.Play: return MediaControlPlaybackCommand.Play;
                case MediaControllerNativePlaybackAction.Pause: return MediaControlPlaybackCommand.Pause;
                case MediaControllerNativePlaybackAction.Stop: return MediaControlPlaybackCommand.Stop;
                case MediaControllerNativePlaybackAction.Next: return MediaControlPlaybackCommand.Next;
                case MediaControllerNativePlaybackAction.Prev: return MediaControlPlaybackCommand.Previous;
                case MediaControllerNativePlaybackAction.FastForward: return MediaControlPlaybackCommand.FastForward;
                case MediaControllerNativePlaybackAction.Rewind: return MediaControlPlaybackCommand.Rewind;
                case MediaControllerNativePlaybackAction.Toggle: return MediaControlPlaybackCommand.Toggle;
            }

            Debug.Fail($"Not supported code for playback command{nativeAction}.");
            return MediaControlPlaybackCommand.Play;
        }

        internal static MediaControllerNativePlaybackAction ToNative(this MediaControlPlaybackCommand command)
        {
            switch (command)
            {
                case MediaControlPlaybackCommand.Play: return MediaControllerNativePlaybackAction.Play;
                case MediaControlPlaybackCommand.Pause: return MediaControllerNativePlaybackAction.Pause;
                case MediaControlPlaybackCommand.Stop: return MediaControllerNativePlaybackAction.Stop;
                case MediaControlPlaybackCommand.Next: return MediaControllerNativePlaybackAction.Next;
                case MediaControlPlaybackCommand.Previous: return MediaControllerNativePlaybackAction.Prev;
                case MediaControlPlaybackCommand.FastForward: return MediaControllerNativePlaybackAction.FastForward;
                case MediaControlPlaybackCommand.Rewind: return MediaControllerNativePlaybackAction.Rewind;
                case MediaControlPlaybackCommand.Toggle: return MediaControllerNativePlaybackAction.Toggle;
            }
            return MediaControllerNativePlaybackAction.Play;
        }

        internal static MediaControlRepeatMode ToPublic(this MediaControllerNativeRepeatMode mode)
        {
            Debug.Assert(Enum.IsDefined(typeof(MediaControllerNativeRepeatMode), mode));

            return mode == MediaControllerNativeRepeatMode.Off ? MediaControlRepeatMode.On :
                (mode == MediaControllerNativeRepeatMode.On ? MediaControlRepeatMode.Off : MediaControlRepeatMode.OneMedia);
        }

        internal static MediaControllerNativeRepeatMode ToNative(this MediaControlRepeatMode mode)
        {
            Debug.Assert(Enum.IsDefined(typeof(MediaControlRepeatMode), mode));

            return mode == MediaControlRepeatMode.Off ? MediaControllerNativeRepeatMode.On :
                (mode == MediaControlRepeatMode.On ? MediaControllerNativeRepeatMode.Off : MediaControllerNativeRepeatMode.OneMedia);
        }
    }
}