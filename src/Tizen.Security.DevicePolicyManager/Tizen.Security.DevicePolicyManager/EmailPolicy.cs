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
    /// The EmailPolicy provides methods to control email policies.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class EmailPolicy
    {
        private readonly DevicePolicyManager handle;

        internal EmailPolicy()
        {
        }
 
        internal EmailPolicy(DevicePolicyManager dpm)
        {
            handle = dpm;
        }

        /// <summary>
        /// Checks whether the access to POP or IMAP email is allowed or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>true if the POP or IMAP email is allowed, false otherwise.</returns>
        public bool GetPopImapState()
        {
            int state;
            int ret = Interop.DevicePolicyManager.RestrictionGetPopimapEmailState(handle.GetHandle(), out state);

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
