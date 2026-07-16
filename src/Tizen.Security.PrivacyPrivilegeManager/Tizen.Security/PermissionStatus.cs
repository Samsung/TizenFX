/*
 * Copyright (c) 2026 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// Enumeration for the status of a permission.
    /// </summary>
    /// <since_tizen> 14 </since_tizen>
    public enum PermissionStatus
    {
        /// <summary>
        /// The privilege is granted.
        /// </summary>
        Granted = 0,
        /// <summary>
        /// The privilege is denied.
        /// </summary>
        Denied = 1,
        /// <summary>
        /// The permission is denied until user grants it. Use RequestPermissionAsync() to ask the user for the permission.
        /// </summary>
        Ask = 2,
        /// <summary>
        /// The privilege is granted for the current session only.
        /// </summary>
        GrantedSession = 3,
        /// <summary>
        /// The privilege is denied for the current session only.
        /// </summary>
        DeniedSession = 4,
        /// <summary>
        /// The privilege is granted only while the application is in foreground.
        /// </summary>
        GrantedInUse = 5,
        /// <summary>
        /// The privilege is denied once - user did not allow the permission this time and chose to be asked again later.
        /// </summary>
        Deferred = 90,
    }

    /// <summary>
    /// Extension methods for PermissionState.
    /// </summary>
    /// <since_tizen> 14 </since_tizen>
    public static class PermissionStateExtensions
    {
        /// <summary>
        /// Checks if the permission state indicates that the privilege is granted.
        /// </summary>
        /// <param name="state">The permission state to check.</param>
        /// <returns>True if the privilege is granted (Granted, GrantedSession, or GrantedInUse); otherwise, false.</returns>
        /// <since_tizen> 14 </since_tizen>
        public static bool IsGranted(this PermissionStatus state)
        {
            return state == PermissionStatus.Granted ||
                   state == PermissionStatus.GrantedSession ||
                   state == PermissionStatus.GrantedInUse;
        }
    }

    /// <summary>
    /// Internal helper class for converting between interop enums and PermissionStatus.
    /// </summary>
    internal static class PermissionStatusConverter
    {
        /// <summary>
        /// Converts Interop.CheckResult to PermissionState.
        /// </summary>
        internal static PermissionStatus ToPermissionStatus(this Interop.PrivacyPrivilegeManager.CheckResult checkResult)
        {
            // Values match directly for all cases.
            return (PermissionStatus)checkResult;
        }

        /// <summary>
        /// Converts RequestResult to PermissionState.
        /// </summary>
        internal static PermissionStatus ToPermissionStatus(this RequestResult requestResult)
        {
            // Value DenyOnce maps to Deferred (90). Others match directly.
            if (requestResult == RequestResult.DenyOnce)
            {
                return PermissionStatus.Deferred;
            }
            return (PermissionStatus)requestResult;
        }
    }
}
