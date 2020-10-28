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
        internal static MediaControlPlaybackState ToState(this MediaControllerPlaybackCode code)
        {
            switch (code)
            {
                case MediaControllerPlaybackCode.None: return MediaControlPlaybackState.None;
                case MediaControllerPlaybackCode.Play: return MediaControlPlaybackState.Playing;
                case MediaControllerPlaybackCode.Pause: return MediaControlPlaybackState.Paused;
                case MediaControllerPlaybackCode.Stop: return MediaControlPlaybackState.Stopped;
                case MediaControllerPlaybackCode.FastForward: return MediaControlPlaybackState.FastForwarding;
                case MediaControllerPlaybackCode.Rewind: return MediaControlPlaybackState.Rewinding;
            }

            Debug.Fail($"Not supported code for playback state{code}.");
            return MediaControlPlaybackState.None;
        }

        internal static MediaControllerPlaybackCode ToCode(this MediaControlPlaybackState state)
        {
            switch (state)
            {
                case MediaControlPlaybackState.Playing: return MediaControllerPlaybackCode.Play;
                case MediaControlPlaybackState.Paused: return MediaControllerPlaybackCode.Pause;
                case MediaControlPlaybackState.Stopped: return MediaControllerPlaybackCode.Stop;
                case MediaControlPlaybackState.FastForwarding: return MediaControllerPlaybackCode.FastForward;
                case MediaControlPlaybackState.Rewinding: return MediaControllerPlaybackCode.Rewind;
            }
            return MediaControllerPlaybackCode.None;
        }

        internal static MediaControlPlaybackCommand ToCommand(this MediaControllerPlaybackCode code)
        {
            switch (code)
            {
                case MediaControllerPlaybackCode.Play: return MediaControlPlaybackCommand.Play;
                case MediaControllerPlaybackCode.Pause: return MediaControlPlaybackCommand.Pause;
                case MediaControllerPlaybackCode.Stop: return MediaControlPlaybackCommand.Stop;
                case MediaControllerPlaybackCode.Next: return MediaControlPlaybackCommand.Next;
                case MediaControllerPlaybackCode.Prev: return MediaControlPlaybackCommand.Previous;
                case MediaControllerPlaybackCode.FastForward: return MediaControlPlaybackCommand.FastForward;
                case MediaControllerPlaybackCode.Rewind: return MediaControlPlaybackCommand.Rewind;
            }

            Debug.Fail($"Not supported code for playback command{code}.");
            return MediaControlPlaybackCommand.Play;
        }

        internal static MediaControllerPlaybackCode ToCode(this MediaControlPlaybackCommand command)
        {
            switch (command)
            {
                case MediaControlPlaybackCommand.Play: return MediaControllerPlaybackCode.Play;
                case MediaControlPlaybackCommand.Pause: return MediaControllerPlaybackCode.Pause;
                case MediaControlPlaybackCommand.Stop: return MediaControllerPlaybackCode.Stop;
                case MediaControlPlaybackCommand.Next: return MediaControllerPlaybackCode.Next;
                case MediaControlPlaybackCommand.Previous: return MediaControllerPlaybackCode.Prev;
                case MediaControlPlaybackCommand.FastForward: return MediaControllerPlaybackCode.FastForward;
                case MediaControlPlaybackCommand.Rewind: return MediaControllerPlaybackCode.Rewind;
            }
            return MediaControllerPlaybackCode.Play;
        }

        internal static NativeRepeatMode ToNative(this MediaControlRepeatMode mode)
        {
            Debug.Assert(Enum.IsDefined(typeof(MediaControlRepeatMode), mode));

            return mode == MediaControlRepeatMode.Off ? NativeRepeatMode.On : NativeRepeatMode.Off;
        }

        internal static MediaControlRepeatMode ToPublic(this NativeRepeatMode mode)
        {
            Debug.Assert(Enum.IsDefined(typeof(NativeRepeatMode), mode));

            return mode == NativeRepeatMode.Off ? MediaControlRepeatMode.On : MediaControlRepeatMode.Off;
        }
    }
}