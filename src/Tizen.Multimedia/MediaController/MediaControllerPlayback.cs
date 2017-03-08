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

namespace Tizen.Multimedia.MediaController
{
    /// <summary>
    /// Playback represents a playback state and playback position.
    /// </summary>
    public class MediaControllerPlayback
    {
        /// <summary>
        /// The constructor of MediaControllerPlayback class.
        /// </summary>
        public MediaControllerPlayback(MediaControllerPlaybackState state, ulong position) {
            State = state;
            Position = position;
        }

        internal MediaControllerPlayback(IntPtr _handle) {
            MediaControllerPlaybackState state = MediaControllerPlaybackState.None;
            ulong position = 0L;

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerClient.GetPlaybackState(_handle, out state), "Get Playback state failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerClient.GetPlaybackPosition(_handle, out position), "Get Playback position failed");

            State = state;
            Position = position;
        }

       /// <summary>
       /// Set/Get the State of playback information
       /// </summary>
        public MediaControllerPlaybackState State { get; }

        /// <summary>
        /// Set/Get the Position of playback information
        /// </summary>
        public ulong Position { get; }
    }
}

