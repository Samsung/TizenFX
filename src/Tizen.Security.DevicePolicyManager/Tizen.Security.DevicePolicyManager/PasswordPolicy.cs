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
    /// The PasswordPolicy provides methods to control password policies.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class PasswordPolicy
    {
        private readonly DevicePolicyManager handle;

        internal PasswordPolicy()
        {
        }

        internal PasswordPolicy(DevicePolicyManager dpm)
        {
            handle = dpm;
        }

        /// <summary>
        /// Gets the number of days password expires.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        /// <returns>Number of days after which the password expires.</returns>
        public int GetExpires()
        {
            int value;
            int ret = Interop.DevicePolicyManager.PasswordGetExpires(handle.GetHandle(), out value);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }

            return value;
        }

        /// <summary>
        /// Gets the number of min password history to avoid previous password.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        /// <returns>Number of previous passwords which cannot be used when settings a new password.</returns>
        public int GetHistory()
        {
            int value;
            int ret = Interop.DevicePolicyManager.PasswordGetHistory(handle.GetHandle(), out value);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }

            return value;
        }

        /// <summary>
        /// Gets the maximum number of seconds of inactivity time before the screen timeout occurs.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        /// <returns>Maximum inactivity time for device lock.</returns>
        public int GetMaxInactivityTimeDeviceLock()
        {
            int value;
            int ret = Interop.DevicePolicyManager.PasswordGetMaxInactivityTimeDeviceLock(handle.GetHandle(), out value);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }

            return value;
        }

        /// <summary>
        /// Gets maximum number of failed attempts before device is wiped.
        /// If user fails the last attempt, device will be wiped.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        /// <returns>Maximum count for failed passwords.</returns>
        public int GetMaximumFailedAttemptsForWipe()
        {
            int value;
            int ret = Interop.DevicePolicyManager.PasswordGetMaximumFailedAttemptsForWipe(handle.GetHandle(), out value);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }

            return value;
        }

        /// <summary>
        /// Gets minimum complex char in password.
        /// Complex characters are all non-alphabetic characters; that is, numbers and symbols.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        /// <returns>Number of minimum complex char in password.</returns>
        public int GetMinComplexChars()
        {
            int value;
            int ret = Interop.DevicePolicyManager.PasswordGetMinComplexChars(handle.GetHandle(), out value);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }

            return value;
        }

        /// <summary>
        /// Gets the minimum allowed password length.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        /// <returns>Allowed minimum password length.</returns>
        public int GetMinimumLength()
        {
            int value;
            int ret = Interop.DevicePolicyManager.PasswordGetMinimumLength(handle.GetHandle(), out value);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }

            return value;
        }

        /// <summary>
        /// Gets password quality.
        /// An administrator can get the password restrictions it is imposing.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        /// <returns>Password quality type, values of PasswordQuality combined with bitwise 'or'</returns>
        public int GetQuality()
        {
            int quality;
            int ret = Interop.DevicePolicyManager.PasswordGetQuality(handle.GetHandle(), out quality);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }

            return quality;
        }
    }
}
