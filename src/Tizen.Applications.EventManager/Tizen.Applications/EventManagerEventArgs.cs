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

namespace Tizen.Applications.EventManager
{
    /// <summary>
    /// Arguments for the event raised when the application event is received
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class EventManagerEventArgs : EventArgs
    {
        private readonly Bundle _eventData;
        private readonly string _eventName;

        internal EventManagerEventArgs(string eventName, Bundle eventData)
        {
            _eventName = eventName;
            _eventData = eventData;
        }

        /// <summary>
        /// The Name of the event.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Name
        {
            get
            {
                return _eventName;
            }
        }

        /// <summary>
        /// The event data of the application event.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Bundle Data
        {
            get
            {
                return _eventData;
            }
        }
    }
}