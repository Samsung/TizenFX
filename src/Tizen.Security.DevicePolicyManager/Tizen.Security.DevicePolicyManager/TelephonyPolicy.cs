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
    /// The TelephonyPolicy provides methods to control telephony policies.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    class TelephonyPolicy
    {
        private readonly DevicePolicyManager handle;

        internal TelephonyPolicy()
        {
        }

        internal TelephonyPolicy(DevicePolicyManager dpm)
        {
            handle = dpm;
        }

        /// <summary>
        /// Checks whether the text messaging is allowed or not.
        /// </summary>
        /// <param name="simId">SIM identifier</param>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>true if the messaging is allowed, false otherwise.</returns>
        public bool GetMessagingState(string simId)
        {
            int state;
            int ret = Interop.DevicePolicyManager.RestrictionGetMessagingState(handle.GetHandle(), simId, out state);

            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }

            if (state == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
