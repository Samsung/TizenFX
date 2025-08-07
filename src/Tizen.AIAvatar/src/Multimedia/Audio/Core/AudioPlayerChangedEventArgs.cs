/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.ComponentModel;

namespace Tizen.AIAvatar
{
    /// <summary>   
    /// This class provides arguments for handling Audio State change events.
    /// <member name = "Previous" > The previous state of the audio.</member>  
    /// <member name = "Current" > The current state of the audio.</member>  
    /// </summary>  
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AudioPlayerChangedEventArgs : EventArgs
    {
        /// <summary>  
        /// Initializes a new instance of the AudioChangedEventArgs class with the specified previous and current states.  
        /// </summary>  
        /// <param name="previous">The previous state of the audio.</param>  
        /// <param name="current">The current state of the audio.</param>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AudioPlayerChangedEventArgs(AudioPlayerState previous, AudioPlayerState current)
        {
            Previous = previous;
            Current = current;
        }

        /// <summary>
        /// The previous state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AudioPlayerState Previous
        {
            get;
            internal set;
        }

        /// <summary>
        /// The current state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AudioPlayerState Current
        {
            get;
            internal set;
        }
    }
}
