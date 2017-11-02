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

namespace Tizen.CallManager
{
    /// <summary>
    /// A class which defines the properties of conference call.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class ConferenceCallData
    {
        internal uint CallId;
        internal string Number;
        internal int PersonIndex;
        internal CallNameMode NameMode;
        internal ConferenceCallData()
        {
        }

        /// <summary>
        /// Conference call ID.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public uint Id
        {
            get
            {
                return CallId;
            }
        }

        /// <summary>
        /// Call number.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string CallNumber
        {
            get
            {
                return Number;
            }
        }

        /// <summary>
        /// Person ID.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int PersonId
        {
            get
            {
                return PersonIndex;
            }
        }

        /// <summary>
        /// Call name mode.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public CallNameMode Mode
        {
            get
            {
                return NameMode;
            }
        }
    }
}
