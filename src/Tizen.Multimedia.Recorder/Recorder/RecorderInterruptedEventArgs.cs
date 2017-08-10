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
using System.Collections.Generic;

namespace Tizen.Multimedia
{
    /// <summary>
    /// An extended Eventargs class which contains interrupted policy details, previous and current
    /// state of the recorder.
    /// </summary>
    public class RecorderInterruptedEventArgs : EventArgs
    {
        internal RecorderInterruptedEventArgs(RecorderPolicy policy, RecorderState previous, RecorderState current)
        {
            Policy = policy;
            Previous = previous;
            Current = current;
        }

        /// <summary>
        /// The policy that interrupted the recorder.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public RecorderPolicy Policy { get; }

        /// <summary>
        /// The previous state of the recorder.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public RecorderState Previous { get; }

        /// <summary>
        /// The current state of the recorder.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public RecorderState Current { get; }
    }
}
