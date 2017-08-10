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
    /// Arguments for the event that is raised when the application is disabled.
    /// </summary>
    public class ApplicationDisabledEventArgs : EventArgs
    {
        private readonly ApplicationEventState _eventState;
        private readonly string _applicationId;

        internal ApplicationDisabledEventArgs(string appId, ApplicationEventState eventState)
        {
            _applicationId = appId;
            _eventState = eventState;
        }

        /// <summary>
        /// The Id of the application
        /// </summary>
        public string ApplicationId { get { return _applicationId; } }

        /// <summary>
        /// The Event state of the application
        /// </summary>
        public ApplicationEventState EventState { get { return _eventState; } }
    }
}

