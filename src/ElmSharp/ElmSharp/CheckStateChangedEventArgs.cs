/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace ElmSharp
{
    /// <summary>
    /// It inherits System.EventArgs.
    /// The CheckStateChangedEventArgs is an EventArgs to record the check's state.
    /// Include the old state and the new state.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class CheckStateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the OldState property. The return type is bool.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool OldState { get; private set; }

        /// <summary>
        /// Gets the NewState property. The return type is bool.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool NewState { get; private set; }

        /// <summary>
        /// Creates and initializes a new instance of the CheckStateChangedEventArgs class.
        /// </summary>
        /// <param name="oldState">Old state of check to use this CheckStateChangedEventArgs.</param>
        /// <param name="newState">New state of check to use this CheckStateChangedEventArgs.</param>
        /// <since_tizen> preview </since_tizen>
        public CheckStateChangedEventArgs(bool oldState, bool newState)
        {
            this.OldState = oldState;
            this.NewState = newState;
        }
    }
}
