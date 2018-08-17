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
        internal static MediaControlPlaybackState ToState(this MediaControllerPlaybackNativeState nativeState)
        {
            switch (nativeState)
            {
                case MediaControllerPlaybackNativeState.None: return MediaControlPlaybackState.None;
                case MediaControllerPlaybackNativeState.Play: return MediaControlPlaybackState.Playing;
                case MediaControllerPlaybackNativeState.Pause: return MediaControlPlaybackState.Paused;
                case MediaControllerPlaybackNativeState.Stop: return MediaControlPlaybackState.Stopped;
                case MediaControllerPlaybackNativeState.Next:
                case MediaControllerPlaybackNativeState.MovingToNext: return MediaControlPlaybackState.MovingToNext;
                case MediaControllerPlaybackNativeState.Prev:
                case MediaControllerPlaybackNativeState.MovingToPrev: return MediaControlPlaybackState.MovingToPrevious;
                case MediaControllerPlaybackNativeState.FastForward:
                case MediaControllerPlaybackNativeState.FastForwarding: return MediaControlPlaybackState.FastForwarding;
                case MediaControllerPlaybackNativeState.Rewind:
                case MediaControllerPlaybackNativeState.Rewinding: return MediaControlPlaybackState.Rewinding;
            }

            Debug.Fail($"Not supported code for playback state{nativeState}.");
            return MediaControlPlaybackState.None;
        }

        internal static MediaControllerPlaybackNativeState ToNativeState(this MediaControlPlaybackState state)
        {
            switch (state)
            {
                case MediaControlPlaybackState.Playing: return MediaControllerPlaybackNativeState.Play;
                case MediaControlPlaybackState.Paused: return MediaControllerPlaybackNativeState.Pause;
                case MediaControlPlaybackState.Stopped: return MediaControllerPlaybackNativeState.Stop;
                case MediaControlPlaybackState.MovingToNext: return MediaControllerPlaybackNativeState.MovingToNext;
                case MediaControlPlaybackState.MovingToPrevious: return MediaControllerPlaybackNativeState.MovingToPrev;
                case MediaControlPlaybackState.FastForwarding: return MediaControllerPlaybackNativeState.FastForwarding;
                case MediaControlPlaybackState.Rewinding: return MediaControllerPlaybackNativeState.Rewinding;
            }
            return MediaControllerPlaybackNativeState.None;
        }

        internal static MediaControlPlaybackCommand ToCommand(this MediaControllerPlaybackNativeAction nativeAction)
        {
            switch (nativeAction)
            {
                case MediaControllerPlaybackNativeAction.Play: return MediaControlPlaybackCommand.Play;
                case MediaControllerPlaybackNativeAction.Pause: return MediaControlPlaybackCommand.Pause;
                case MediaControllerPlaybackNativeAction.Stop: return MediaControlPlaybackCommand.Stop;
                case MediaControllerPlaybackNativeAction.Next: return MediaControlPlaybackCommand.Next;
                case MediaControllerPlaybackNativeAction.Prev: return MediaControlPlaybackCommand.Previous;
                case MediaControllerPlaybackNativeAction.FastForward: return MediaControlPlaybackCommand.FastForward;
                case MediaControllerPlaybackNativeAction.Rewind: return MediaControlPlaybackCommand.Rewind;
                case MediaControllerPlaybackNativeAction.Toggle: return MediaControlPlaybackCommand.Toggle;
            }

            Debug.Fail($"Not supported code for playback command{nativeAction}.");
            return MediaControlPlaybackCommand.Play;
        }

        internal static MediaControllerPlaybackNativeAction ToNativeAction(this MediaControlPlaybackCommand command)
        {
            switch (command)
            {
                case MediaControlPlaybackCommand.Play: return MediaControllerPlaybackNativeAction.Play;
                case MediaControlPlaybackCommand.Pause: return MediaControllerPlaybackNativeAction.Pause;
                case MediaControlPlaybackCommand.Stop: return MediaControllerPlaybackNativeAction.Stop;
                case MediaControlPlaybackCommand.Next: return MediaControllerPlaybackNativeAction.Next;
                case MediaControlPlaybackCommand.Previous: return MediaControllerPlaybackNativeAction.Prev;
                case MediaControlPlaybackCommand.FastForward: return MediaControllerPlaybackNativeAction.FastForward;
                case MediaControlPlaybackCommand.Rewind: return MediaControllerPlaybackNativeAction.Rewind;
                case MediaControlPlaybackCommand.Toggle: return MediaControllerPlaybackNativeAction.Toggle;
            }
            return MediaControllerPlaybackNativeAction.Play;
        }

        internal static NativeRepeatMode ToNative(this MediaControlRepeatMode mode)
        {
            Debug.Assert(Enum.IsDefined(typeof(MediaControlRepeatMode), mode));

            return mode == MediaControlRepeatMode.Off ? NativeRepeatMode.On :
                (mode == MediaControlRepeatMode.On ? NativeRepeatMode.Off : NativeRepeatMode.OneMedia);
        }

        internal static MediaControlRepeatMode ToPublic(this NativeRepeatMode mode)
        {
            Debug.Assert(Enum.IsDefined(typeof(NativeRepeatMode), mode));

            return mode == NativeRepeatMode.Off ? MediaControlRepeatMode.On :
                (mode == NativeRepeatMode.On ? MediaControlRepeatMode.Off : MediaControlRepeatMode.OneMedia);
        }

        internal static NativeShuffleMode ToNative(this MediaControlShuffleMode mode)
        {
            Debug.Assert(Enum.IsDefined(typeof(MediaControlShuffleMode), mode));

            return mode == MediaControlShuffleMode.Off ? NativeShuffleMode.On : NativeShuffleMode.Off;
        }

        internal static MediaControlShuffleMode ToPublic(this NativeShuffleMode mode)
        {
            Debug.Assert(Enum.IsDefined(typeof(NativeShuffleMode), mode));

            return mode == NativeShuffleMode.Off ? MediaControlShuffleMode.On : MediaControlShuffleMode.Off;
        }
    }
}