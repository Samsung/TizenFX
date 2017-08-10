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
        internal RecorderStateChangedEventArgs(RecorderState previous, RecorderState current, bool byPolicy)
        {
            Previous = previous;
            Current = current;
            IsStateChangedByPolicy = byPolicy;
        }

        /// <summary>
        /// Previous state of the recorder.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public RecorderState Previous { get; }

        /// <summary>
        /// Current state of the recorder.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public RecorderState Current { get; }

        /// <summary>
        /// true if the state changed by policy such as Resource Conflict or Security, otherwise false
        /// in normal state change.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsStateChangedByPolicy { get; }
    }
}
