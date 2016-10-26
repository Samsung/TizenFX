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
    /// StateChanged event arguments
    /// </summary>
    /// <remarks>
    /// StateChanged event arguments
    /// </remarks>
    public class StateChangedEventArgs : EventArgs
    {
        internal int _state;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="state"> State Changed </param>
        internal StateChangedEventArgs(int state)
        {
            _state = state;
        }

        /// <summary>
        /// Get the current state.
        /// </summary>
        /// <value> current state </value>
        public SCMirroringSinkState State
        {
            get
            {
                return (SCMirroringSinkState)_state;
            }
        }
    }
}