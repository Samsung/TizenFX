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

namespace Tizen.Location
{
    /// <summary>
    /// An extended EventArgs class which contains the changed location service state.
    /// </summary>
    public class ServiceStateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Class Constructor for ServiceStateChangedEventArgs class.
        /// </summary>
        /// <param name="state"> An enumeration of type LocationServiceState.</param>
        public ServiceStateChangedEventArgs(ServiceState state)
        {
            ServiceState = state;
        }

        /// <summary>
        /// Get the Service state.
        /// </summary>
        public ServiceState ServiceState { get; private set; }
    }
}
