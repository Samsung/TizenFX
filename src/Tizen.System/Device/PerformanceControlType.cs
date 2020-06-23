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
using System.ComponentModel;

namespace Tizen.System
{
    /// <summary>
    /// This class represents the type of event for backends. This class can be converted from the string type.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PerformanceControlType
    {
        /// <summary>
        /// Pre-defined event type "PreCreated".
        /// </summary>
        public static readonly PerformanceControlType AppLaunchHome = new PerformanceControlType("AppLaunchHome");

        /// <summary>
        /// Pre-defined event type "HomeScreen".
        /// </summary>
        public static readonly PerformanceControlType HomeScreen = new PerformanceControlType("HomeScreen");

        private string _typeName;

        /// <summary>
        /// Initializes the PerformanceControlType class.
        /// </summary>
        /// <param name="name">The name of event type.</param>
        private PerformanceControlType(string name) {
            _typeName = name;
        }

        /// <summary>
        /// Returns the name of event type.
        /// </summary>
        public override string ToString() {
            return _typeName;
        }

        /// <summary>
        /// Returns the hash code for event type string.
        /// </summary>
        public override int GetHashCode() {
            if (_typeName == null) return 0;
            return _typeName.GetHashCode();
        }

        /// <summary>
        /// Determines whether this instance and a specified object.
        /// </summary>
        public override bool Equals(object obj) {
            PerformanceControlType other = obj as PerformanceControlType;
            return other != null && other._typeName == this._typeName;
        }
    }
}
