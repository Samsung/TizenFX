/*
 *  Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

namespace Tizen.Security.DevicePolicyManager
{
    /// <summary>
    /// Enumeration for dpm password quality type
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum PasswordQuality
    {
        /// <summary>
        /// No requirements for password.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        UNSPECIFIED = 0x00,
        /// <summary>
        /// EAS(Exchange ActiveSync) requirement for simple password.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        SIMPLE = 0x01,
        /// <summary>
        /// Some kind password required, but doesn't care what it is.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        SOMETHING = 0x10,
        /// <summary>
        /// Containing at least numeric character.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        NUMERIC = 0x20,
        /// <summary>
        /// Containing at least alphabetic (or other symbol) characters.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ALPHABETIC = 0x40,
        /// <summary>
        /// Containing at least numeric and alphabetic characters.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ALPHANUMERIC = 0x80
    }
}
