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
using System.Diagnostics;

namespace Tizen.Multimedia.Remoting
{
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

        internal static MediaControllerNativeRepeatMode ToNative(this MediaControlRepeatMode mode)
        {
            Debug.Assert(Enum.IsDefined(typeof(MediaControlRepeatMode), mode));

            return mode == MediaControlRepeatMode.Off ? MediaControllerNativeRepeatMode.On :
                (mode == MediaControlRepeatMode.On ? MediaControllerNativeRepeatMode.Off : MediaControllerNativeRepeatMode.OneMedia);
        }

        internal static MediaControlRepeatMode ToPublic(this MediaControllerNativeRepeatMode mode)
        {
            Debug.Assert(Enum.IsDefined(typeof(MediaControllerNativeRepeatMode), mode));

            return mode == MediaControllerNativeRepeatMode.Off ? MediaControlRepeatMode.On :
                (mode == MediaControllerNativeRepeatMode.On ? MediaControlRepeatMode.Off : MediaControlRepeatMode.OneMedia);
        }
    }
}