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
using System.Collections.Generic;
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

        /// <summary>
        /// Connecting.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Connecting,

        /// <summary>
        /// Buffering.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Buffering,

        /// <summary>
        /// Error while playback.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Error
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

    /// <summary>
    /// Specifies the display mode.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum MediaControlDisplayMode
    {
        /// <summary>
        /// Letter box
        /// </summary>
        LetterBox,

        /// <summary>
        /// Original size
        /// </summary>
        OriginSize,

        /// <summary>
        /// Full screen
        /// </summary>
        FullScreen,

        /// <summary>
        /// Cropped full screen
        /// </summary>
        CroppedFull
    }

    /// <summary>
    /// Specifies the code which represents the result of communication between client and server.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public enum MediaControlResult
    {
        /// <summary>
        /// The command or the event has been successfully completed.
        /// </summary>
        Success,

        /// <summary>
        /// The command or the event had already been completed.
        /// </summary>
        AlreadyDone = 200,

        /// <summary>
        /// The command or the event is aborted by some external event (e.g. aborted play command by incoming call).
        /// </summary>
        Aborted = 300,

        /// <summary>
        /// The command or the event is denied due to application policy (e.g. cannot rewind in recording).
        /// </summary>
        ActionDenied,

        /// <summary>
        /// The command or the event is not supported.
        /// </summary>
        NotSupported,

        /// <summary>
        /// The command or the event is out of supported range or the limit is reached.
        /// </summary>
        Invalid,

        /// <summary>
        /// Timeout has occurred.
        /// </summary>
        Timeout = 400,

        /// <summary>
        /// The application has failed.
        /// </summary>
        ApplicationFailed,

        /// <summary>
        /// The command or the event has failed because the application has no media.
        /// </summary>
        NoMedia,

        /// <summary>
        /// The command or the event has failed because there is no audio output device.
        /// </summary>
        NoAudioOutputDevice,

        /// <summary>
        /// The command or the event has failed because there is no peer.
        /// </summary>
        NoPeer,

        /// <summary>
        /// The network has failed.
        /// </summary>
        NetworkFailed = 500,

        /// <summary>
        /// The application does not have account.
        /// </summary>
        NoAccount = 600,

        /// <summary>
        /// The application could not log in.
        /// </summary>
        LoginFailed,

        /// <summary>
        /// Unknown error.
        /// </summary>
        Unknown = Int32.MaxValue
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
                case MediaControllerNativePlaybackState.Connecting: return MediaControlPlaybackState.Connecting;
                case MediaControllerNativePlaybackState.Buffering: return MediaControlPlaybackState.Buffering;
                case MediaControllerNativePlaybackState.Error: return MediaControlPlaybackState.Error;
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
                case MediaControlPlaybackState.Connecting: return MediaControllerNativePlaybackState.Connecting;
                case MediaControlPlaybackState.Buffering: return MediaControllerNativePlaybackState.Buffering;
                case MediaControlPlaybackState.Error: return MediaControllerNativePlaybackState.Error;
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

        internal static MediaControlNativeDisplayMode ToNative(this MediaControlDisplayMode mode)
        {
            Debug.Assert(Enum.IsDefined(typeof(MediaControlDisplayMode), mode));

            MediaControlNativeDisplayMode nativeMode = MediaControlNativeDisplayMode.LetterBox;
            switch (mode)
            {
                case MediaControlDisplayMode.LetterBox:
                    nativeMode = MediaControlNativeDisplayMode.LetterBox;
                    break;
                case MediaControlDisplayMode.OriginSize:
                    nativeMode = MediaControlNativeDisplayMode.OriginSize;
                    break;
                case MediaControlDisplayMode.FullScreen:
                    nativeMode = MediaControlNativeDisplayMode.FullScreen;
                    break;
                case MediaControlDisplayMode.CroppedFull:
                    nativeMode = MediaControlNativeDisplayMode.CroppedFull;
                    break;
            }
            return nativeMode;
        }

        internal static MediaControlDisplayMode ToPublic(this MediaControlNativeDisplayMode mode)
        {
            Debug.Assert(Enum.IsDefined(typeof(MediaControlNativeDisplayMode), mode));
            MediaControlDisplayMode nativeMode = MediaControlDisplayMode.LetterBox;
            switch (mode)
            {
                case MediaControlNativeDisplayMode.LetterBox:
                    nativeMode = MediaControlDisplayMode.LetterBox;
                    break;
                case MediaControlNativeDisplayMode.OriginSize:
                    nativeMode = MediaControlDisplayMode.OriginSize;
                    break;
                case MediaControlNativeDisplayMode.FullScreen:
                    nativeMode = MediaControlDisplayMode.FullScreen;
                    break;
                case MediaControlNativeDisplayMode.CroppedFull:
                    nativeMode = MediaControlDisplayMode.CroppedFull;
                    break;
            }
            return nativeMode;
        }

        internal static IList<MediaControlDisplayMode> ToPublicList(this MediaControlNativeDisplayMode modes)
        {
            var supportedModes = new List<MediaControlDisplayMode>();

            foreach (MediaControlNativeDisplayMode mode in Enum.GetValues(typeof(MediaControlNativeDisplayMode)))
            {
                if (modes.HasFlag(mode))
                {
                    supportedModes.Add(mode.ToPublic());
                }
            }

            return supportedModes.AsReadOnly();
        }

        internal static MediaControlNativeDisplayRotation ToNative(this Rotation mode)
        {
            Debug.Assert(Enum.IsDefined(typeof(Rotation), mode));

            MediaControlNativeDisplayRotation nativeMode = MediaControlNativeDisplayRotation.Rotate0;
            switch (mode)
            {
                case Rotation.Rotate0:
                    nativeMode = MediaControlNativeDisplayRotation.Rotate0;
                    break;
                case Rotation.Rotate90:
                    nativeMode = MediaControlNativeDisplayRotation.Rotate90;
                    break;
                case Rotation.Rotate180:
                    nativeMode = MediaControlNativeDisplayRotation.Rotate180;
                    break;
                case Rotation.Rotate270:
                    nativeMode = MediaControlNativeDisplayRotation.Rotate270;
                    break;
            }
            return nativeMode;
        }

        internal static Rotation ToPublic(this MediaControlNativeDisplayRotation mode)
        {
            Debug.Assert(Enum.IsDefined(typeof(MediaControlNativeDisplayRotation), mode));
            Rotation nativeMode = Rotation.Rotate0;
            switch (mode)
            {
                case MediaControlNativeDisplayRotation.Rotate0:
                    nativeMode = Rotation.Rotate0;
                    break;
                case MediaControlNativeDisplayRotation.Rotate90:
                    nativeMode = Rotation.Rotate90;
                    break;
                case MediaControlNativeDisplayRotation.Rotate180:
                    nativeMode = Rotation.Rotate180;
                    break;
                case MediaControlNativeDisplayRotation.Rotate270:
                    nativeMode = Rotation.Rotate270;
                    break;
            }
            return nativeMode;
        }

        internal static IList<Rotation> ToPublicList(this MediaControlNativeDisplayRotation modes)
        {
            var supportedRotations = new List<Rotation>();

            foreach (MediaControlNativeDisplayRotation mode in Enum.GetValues(typeof(MediaControlNativeDisplayRotation)))
            {
                if (modes.HasFlag(mode))
                {
                    supportedRotations.Add(mode.ToPublic());
                }
            }

            return supportedRotations.AsReadOnly();
        }
    }
}