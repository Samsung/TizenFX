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
    /// Get value of changed state. It provides getting state values which are returned when state is changed.
    /// </summary>
    /// <remarks>
    /// Return error and state code.
    /// </remarks>
    public class StateChangedEventArgs : EventArgs
    {
        internal int _state;
        internal int _error;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="state"> State Changed </param>
        /// <param name="error"> Error Occurred </param>
        internal StateChangedEventArgs(int state, int error)
        {
            _state = state;
            _error = error;
        }

        /// <summary>
        /// Get the error code of screen mirroring.
        /// </summary>
        /// <value> Get the error code which is one of enums in 'ScreenMirroringErrorCode' when screen mirroring error is occurred.</value>
        public ScreenMirroringErrorCode Error
        {
            get
            {
                return (ScreenMirroringErrorCode)_error;
            }
        }

        /// <summary>
        /// Get the current state of screen mirroring.
        /// </summary>
        /// <value> Get state code which is one of enums in 'ScreenMirroringSinkState' when screen mirroring state is changed. </value>
        public ScreenMirroringSinkState State
        {
            get
            {
                return (ScreenMirroringSinkState)_state;
            }
        }
    }
}