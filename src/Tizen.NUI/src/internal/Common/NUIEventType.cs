/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using Tizen.Applications.CoreBackend;

namespace Tizen.NUI
{
    /// <summary>
    /// Class that represents the type of NUI event for backends. This class can be converted from string type.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class NUIEventType : EventType
    {
        /// <summary>
        /// Initializes the EventType class.
        /// </summary>
        /// <param name="name">The name of event type.</param>
        /// <since_tizen> 4 </since_tizen>
        public NUIEventType(string name) : base(name)
        {
        }

        /// <summary>
        /// Pre-defined event type. "TimeTick"
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly NUIEventType TimeTick = "TimeTick";

        /// <summary>
        /// Pre-defined event type. "AmbientTick"
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly NUIEventType AmbientTick = "AmbientTick";

        /// <summary>
        /// Pre-defined event type. "AmbientChanged"
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly NUIEventType AmbientChanged = "AmbientChanged";

        /// <summary>
        /// Converts a string to NUIEventType instance.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static implicit operator NUIEventType(string value)
        {
            return new NUIEventType(value);
        }
    }
}
