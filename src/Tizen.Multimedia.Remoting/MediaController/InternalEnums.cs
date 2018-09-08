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

namespace Tizen.Multimedia.Remoting
{
    internal enum MediaControllerNativePlaybackState
    {
        None,
        Play,
        Pause,
        Stop,
        Next,           // Deprecated since 4.0
        Prev,           // Deprecated since 4.0
        FastForward,    // Deprecated since 4.0
        Rewind,         // Deprecated since 4.0
        MovingToNext,   // Since 4.0
        MovingToPrev,   // Since 4.0
        FastForwarding, // Since 4.0
        Rewinding       // Since 4.0
    }

    internal enum MediaControllerNativePlaybackAction
    {
        Play,
        Pause,
        Stop,
        Next,
        Prev,
        FastForward,
        Rewind,
        Toggle
    }

    internal enum MediaControllerNativeServerState
    {
        None,
        Activated,
        Deactivated,
    }

    internal enum MediaControllerNativeShuffleMode
    {
        On,
        Off,
    }

    internal enum MediaControllerNativeRepeatMode
    {
        On,
        Off,
        OneMedia
    }

    internal enum MediaControllerNativeAttribute
    {
        Title,
        Artist,
        Album,
        Author,
        Genre,
        Duration,
        Date,
        Copyright,
        Description,
        TrackNumber,
        Picture,
    }

    internal enum MediaControlCommand
    {
        Custom,
        CustomExtra,
        Playback,
        PlaybackPosition,
        Playlist,
        RepeatMode,
        ShuffleMode,
    }
}