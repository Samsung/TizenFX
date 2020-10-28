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

using System.Diagnostics;

namespace Tizen.Multimedia.Remoting
{
    internal enum MediaControllerPlaybackCode
    {
        None,
        Play,
        Pause,
        Stop,
        Next,
        Prev,
        FastForward,
        Rewind,
    }

    internal enum MediaControllerServerState
    {
        None,
        Activated,
        Deactivated,
    }

    internal enum MediaControllerShuffleMode
    {
        On,
        Off,
    }

    internal enum NativeRepeatMode
    {
        On,
        Off,
    }

    internal enum MediaControllerAttribute
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
}