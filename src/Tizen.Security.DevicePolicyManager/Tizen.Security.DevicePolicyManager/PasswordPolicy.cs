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

using System;

namespace Tizen.Security.DevicePolicyManager
{
    /// <summary>
    /// The PasswordPolicy provides methods to manage password policies.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class PasswordPolicy
    {
        private readonly DevicePolicyManager _dpm;

        internal PasswordPolicy()
        {
        }

        internal PasswordPolicy(DevicePolicyManager dpm)
        {
            _dpm = dpm;
        }

        /// <summary>
        /// Gets the number of days password expires.
        /// </summary>
        /// <returns>Number of days after which the password expires.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        /// <exception cref="ArgumentException">Thrown when failed because of invalid handle of DevicePolicyManager.</exception>
        /// <exception cref="TimeoutException">Thrown when failed because of timeout.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        public int GetExpires()
        {
            int value;
            int ret = Interop.DevicePolicyManager.PasswordGetExpires(_dpm.GetHandle(), out value);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }

            return value;
        }

        /// <summary>
        /// Gets the number of min password history to avoid previous password.
        /// </summary>
        /// <returns>Number of previous passwords which cannot be used when settings a new password.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        /// <exception cref="ArgumentException">Thrown when failed because of invalid handle of DevicePolicyManager.</exception>
        /// <exception cref="TimeoutException">Thrown when failed because of timeout.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        public int GetHistory()
        {
            int value;
            int ret = Interop.DevicePolicyManager.PasswordGetHistory(_dpm.GetHandle(), out value);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }

            return value;
        }

        /// <summary>
        /// Gets the maximum number of seconds of inactivity time before the screen timeout occurs.
        /// </summary>
        /// <returns>Maximum inactivity time for device lock.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        /// <exception cref="ArgumentException">Thrown when failed because of invalid handle of DevicePolicyManager.</exception>
        /// <exception cref="TimeoutException">Thrown when failed because of timeout.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        public int GetMaxInactivityTimeDeviceLock()
        {
            int value;
            int ret = Interop.DevicePolicyManager.PasswordGetMaxInactivityTimeDeviceLock(_dpm.GetHandle(), out value);
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
        /// <returns>Maximum count for failed passwords.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        /// <exception cref="ArgumentException">Thrown when failed because of invalid handle of DevicePolicyManager.</exception>
        /// <exception cref="TimeoutException">Thrown when failed because of timeout.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        public int GetMaximumFailedAttemptsForWipe()
        {
            int value;
            int ret = Interop.DevicePolicyManager.PasswordGetMaximumFailedAttemptsForWipe(_dpm.GetHandle(), out value);
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
        /// <returns>Number of minimum complex char in password.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        /// <exception cref="ArgumentException">Thrown when failed because of invalid handle of DevicePolicyManager.</exception>
        /// <exception cref="TimeoutException">Thrown when failed because of timeout.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        public int GetMinComplexChars()
        {
            int value;
            int ret = Interop.DevicePolicyManager.PasswordGetMinComplexChars(_dpm.GetHandle(), out value);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }

            return value;
        }

        /// <summary>
        /// Gets the minimum allowed password length.
        /// </summary>
        /// <returns>Allowed minimum password length.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        /// <exception cref="ArgumentException">Thrown when failed because of invalid handle of DevicePolicyManager.</exception>
        /// <exception cref="TimeoutException">Thrown when failed because of timeout.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        public int GetMinimumLength()
        {
            int value;
            int ret = Interop.DevicePolicyManager.PasswordGetMinimumLength(_dpm.GetHandle(), out value);
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
        /// <returns>Password quality type, values of PasswordQuality combined with bitwise 'or'</returns>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        /// <exception cref="ArgumentException">Thrown when failed because of invalid handle of DevicePolicyManager.</exception>
        /// <exception cref="TimeoutException">Thrown when failed because of timeout.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        public int GetQuality()
        {
            int quality;
            int ret = Interop.DevicePolicyManager.PasswordGetQuality(_dpm.GetHandle(), out quality);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }

            return quality;
        }
    }
}
