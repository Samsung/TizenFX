/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// Arguments for the event raised when the application is enabled.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ApplicationEnabledEventArgs : EventArgs
    {
        private readonly ApplicationEventState _eventState;
        private readonly string _applicationId;

        internal ApplicationEnabledEventArgs(string appId, ApplicationEventState eventState)
        {
            _applicationId = appId;
            _eventState = eventState;
        }

        /// <summary>
        /// The ID of the application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string ApplicationId { get { return _applicationId; } }

        /// <summary>
        /// The event state of the application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ApplicationEventState EventState { get { return _eventState; } }
    }
}

