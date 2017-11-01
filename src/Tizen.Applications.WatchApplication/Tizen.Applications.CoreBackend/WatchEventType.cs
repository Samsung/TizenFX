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
using Tizen.Applications.CoreBackend;

namespace Tizen.Applications.CoreBackend
{
    /// <summary>
    /// Class that represents the type of event for backends. This class can be converted from string type.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class WatchEventType : EventType
    {
        /// <summary>
        /// Pre-defined event type. "Created"
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly WatchEventType TimeTick = "TimeTick";

        /// <summary>
        /// Pre-defined event type. "AmbientTick"
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly WatchEventType AmbientTick = "AmbientTick";

        /// <summary>
        /// Pre-defined event type. "AmbientChanged"
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly WatchEventType AmbientChanged = "AmbientChanged";

        /// <summary>
        /// Initializes the WatchEventType class.
        /// </summary>
        /// <param name="name">The name of watch event type.</param>
        /// <since_tizen> 4 </since_tizen>
        public WatchEventType(string name) : base(name)
        {
        }

        /// <summary>
        /// Converts a string to WatchEventType instance.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static implicit operator WatchEventType(string value)
        {
            return new WatchEventType(value);
        }
    }
}
