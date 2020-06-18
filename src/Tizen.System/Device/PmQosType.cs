/*
* Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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

using Tizen.Common;

namespace Tizen.System
{
    /// <summary>
    /// This class represents the type of event for backends. This class can be converted from the string type.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class PmQosType
    {
        /// <summary>
        /// Pre-defined event type "PreCreated".
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public static readonly PmQosType AppLaunchHome = "AppLaunchHome";

        /// <summary>
        /// Pre-defined event type "HomeScreen".
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public static readonly PmQosType HomeScreen = "HomeScreen";

        private string _typeName;

        /// <summary>
        /// Initializes the PmQosType class.
        /// </summary>
        /// <param name="name">The name of event type.</param>
        /// <since_tizen> 8 </since_tizen>
        public PmQosType(string name) {
            _typeName = name;
        }

        /// <summary>
        /// Returns the name of event type.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public override string ToString() {
            return _typeName;
        }

        /// <summary>
        /// Returns the hash code for event type string.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public override int GetHashCode() {
            if (_typeName == null) return 0;
            return _typeName.GetHashCode();
        }

        /// <summary>
        /// Determines whether this instance and a specified object.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public override bool Equals(object obj) {
            PmQosType other = obj as PmQosType;
            return other != null && other._typeName == this._typeName;
        }

        /// <summary>
        /// Converts a string to PmQosType instance.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public static implicit operator PmQosType(string value) {
            return new PmQosType(value);
        }
    }
}
