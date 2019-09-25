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

namespace Tizen.Applications
{
    /// <summary>
    ///  Provides data for the SuspendedState event.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class SuspendedStateEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the SuspendedStateEventArgs class.
        /// </summary>
        /// <param name="state">The information of the SuspendedState</param>
        /// <since_tizen> 6 </since_tizen>
        public SuspendedStateEventArgs(SuspendedState state)
        {
            SuspendedState = state;
        }

        /// <summary>
        /// Gets the suspended state of applications.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public SuspendedState SuspendedState { get; private set; }
    }
}
