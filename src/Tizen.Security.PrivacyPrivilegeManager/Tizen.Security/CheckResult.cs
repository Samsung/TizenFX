/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Security
{
    /// <summary>
    /// Enumeration for the result of a permission check.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum CheckResult
    {
        /// <summary>
        /// The access to privilege is allowed permanently.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Allow = Interop.PrivacyPrivilegeManager.CheckResult.Allow,
        /// <summary>
        /// The access to privilege is denied permanently.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Deny = Interop.PrivacyPrivilegeManager.CheckResult.Deny,
        /// <summary>
        /// The access to privilege must be resolved by the user.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Ask = Interop.PrivacyPrivilegeManager.CheckResult.Ask,
        /// <summary>
        /// The access to privilege is allowed for the current session only.
        /// </summary>
        /// <since_tizen> 14 </since_tizen>
        AllowSession = Interop.PrivacyPrivilegeManager.CheckResult.AllowSession,
        /// <summary>
        /// The access to privilege is denied for the current session only.
        /// </summary>
        /// <since_tizen> 14 </since_tizen>
        DenySession = Interop.PrivacyPrivilegeManager.CheckResult.DenySession,
        /// <summary>
        /// The access to privilege is allowed only while the application is in foreground.
        /// </summary>
        /// <since_tizen> 14 </since_tizen>
        AllowInUse = Interop.PrivacyPrivilegeManager.CheckResult.AllowInUse,
    }
}
