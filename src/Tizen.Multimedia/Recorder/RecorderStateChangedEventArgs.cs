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
    /// An extended EventArgs class which contains details about previous and current state
    /// of the recorder when its state is changed.
    /// </summary>
    public class RecorderStateChangedEventArgs : EventArgs
    {
        private RecorderState _previous = RecorderState.None;
        private RecorderState _current = RecorderState.None;
        private bool _policy = false;

        internal RecorderStateChangedEventArgs(RecorderState previous, RecorderState current, bool policy)
        {
            _previous = previous;
            _current = current;
            _policy = policy;
        }

        /// <summary>
        /// Previous state of the recorder.
        /// </summary>
        public RecorderState Previous {
            get {
                return _previous;
            }
        }

        /// <summary>
        /// Current state of the recorder.
        /// </summary>
        public RecorderState Current {
            get {
                return _current;
            }
        }

        /// <summary>
        /// true if the state changed by policy such as Resource Conflict or Security, otherwise false
        /// in normal state change.
        /// </summary>
        public bool ByPolicy {
            get {
                return _policy;
            }
        }
    }
}
