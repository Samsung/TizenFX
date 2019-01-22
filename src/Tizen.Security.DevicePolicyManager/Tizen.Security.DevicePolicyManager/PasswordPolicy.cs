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
    public class PasswordPolicy : DevicePolicy
    {
        internal PasswordPolicy(DevicePolicyManager dpm) : base(dpm)
        {
        }

        /// <summary>
        /// Gets the number of days password expires.
        /// </summary>
        /// <value>Number of days after which the password expires. The default value is maximum of int.</value>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        public int DaysToExpiration
        {
            get
            {
                int value = int.MaxValue;
                int ret = Interop.DevicePolicyManager.PasswordGetExpires(_dpm.GetHandle(), out value);
                if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get password expires policy " + ret);
                }

                return value;
            }
        }

        /// <summary>
        /// Gets the number of min password history to avoid previous password.
        /// </summary>
        /// <value>Number of previous passwords which cannot be used when settings a new password. The default value is 0.</value>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        public int MinimumPreviousHistory
        {
            get
            {
                int value = 0;
                int ret = Interop.DevicePolicyManager.PasswordGetHistory(_dpm.GetHandle(), out value);
                if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get password history policy " + ret);
                }

                return value;
            }
        }

        /// <summary>
        /// Gets the maximum number of seconds of inactivity time before the screen timeout occurs.
        /// </summary>
        /// <value>Maximum inactivity time for device lock. The default value is maximum of int.</value>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        public int MaxInactivityTimeDeviceLock
        {
            get
            {
                int value = int.MaxValue;
                int ret = Interop.DevicePolicyManager.PasswordGetMaxInactivityTimeDeviceLock(_dpm.GetHandle(), out value);
                if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get password maximum inactivity time policy " + ret);
                }

                return value;
            }
        }

        /// <summary>
        /// Gets maximum number of failed attempts before device is wiped.
        /// If user fails the last attempt, device will be wiped.
        /// </summary>
        /// <value>Maximum count for failed passwords. The default value is maximum of int.</value>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        public int MaximumFailedAttemptsForWipe
        {
            get
            {
                int value = int.MaxValue;
                int ret = Interop.DevicePolicyManager.PasswordGetMaximumFailedAttemptsForWipe(_dpm.GetHandle(), out value);
                if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get password maximum failed attempts policy " + ret);
                }

                return value;
            }
        }

        /// <summary>
        /// Gets minimum complex char in password.
        /// Complex characters are all non-alphabetic characters; that is, numbers and symbols.
        /// </summary>
        /// <value>Number of minimum complex char in password. The default value is 0.</value>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        public int MinimumRequiredComplexChars
        {
            get
            {
                int value = 0;
                int ret = Interop.DevicePolicyManager.PasswordGetMinComplexChars(_dpm.GetHandle(), out value);
                if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get password min complext chars policy " + ret);
                }

                return value;
            }
        }

        /// <summary>
        /// Gets the minimum allowed password length.
        /// </summary>
        /// <value>Allowed minimum password length. The default value is 0.</value>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        public int MinimunLength
        {
            get
            {
                int value = 0;
                int ret = Interop.DevicePolicyManager.PasswordGetMinimumLength(_dpm.GetHandle(), out value);
                if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get password min length policy " + ret);
                }

                return value;
            }
        }

        /// <summary>
        /// Gets password quality.
        /// An administrator can get the password restrictions it is imposing.
        /// </summary>
        /// <value>Password quality type, values of PasswordQuality. The default value is PasswordQuality UNSPECIFIED.</value>
        /// <seealso cref="PasswordQuality"/>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/dpm.password</privilege>
        /// <privlevel>partner</privlevel>
        public PasswordQuality Quality
        {
            get
            {
                int quality;
                int ret = Interop.DevicePolicyManager.PasswordGetQuality(_dpm.GetHandle(), out quality);
                if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get password quality policy " + ret);
                    return PasswordQuality.Unspecified;
                }

                return (PasswordQuality)quality;
            }
        }
    }
}
