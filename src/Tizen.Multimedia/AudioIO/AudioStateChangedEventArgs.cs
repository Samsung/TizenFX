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
    /// Argument for the event that is Audio State Changed.
    /// </summary>
    public class AudioStateChangedEventArgs : EventArgs
    {
        private readonly AudioState _previous;
        private readonly AudioState _current;
        private readonly bool _by_policy;
        /// <summary>
        /// Initializes the instance of the AudioStateChangedEventArgs class. 
        /// </summary>
        /// <param name="_prev"></param>
        /// <param name="_current"></param>
        /// <param name="by_policy"></param>
        internal AudioStateChangedEventArgs(AudioState previous, AudioState current, bool by_policy) 
        {
            this._previous = previous;
            this._current = current;
            this._by_policy = by_policy;
        }

        public AudioState Previous { get { return _previous; } }
        public AudioState Current { get { return _current; } }
        public bool Policy { get { return _by_policy; } }
    }
}
