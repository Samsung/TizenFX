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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides data for the <see cref="AudioCaptureBase.StateChanged"/> event and the <see cref="AudioPlayback.StateChanged"/> event.
    /// </summary>
    public class AudioIOStateChangedEventArgs : EventArgs
    {
        internal AudioIOStateChangedEventArgs(AudioIOState previous, AudioIOState current, bool byPolicy)
        {
            Previous = previous;
            Current = current;
            ByPolicy = byPolicy;
        }

        /// <summary>
        /// Gets the previous state.
        /// </summary>
        public AudioIOState Previous { get; }

        /// <summary>
        /// Gets the current state.
        /// </summary>
        public AudioIOState Current { get; }

        /// <summary>
        /// Gets the value indicating whether the state is changed by a policy or not.
        /// </summary>
        public bool ByPolicy { get; }
    }
}
