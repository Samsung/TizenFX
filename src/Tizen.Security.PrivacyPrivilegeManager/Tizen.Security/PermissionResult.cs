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

using System;
using System.Collections.Generic;
using System.Linq;

namespace Tizen.Security
{
    /// <summary>
    /// Represents the result of permission checks, implementing IDictionary&lt;string, PermissionState&gt;.
    /// Provides methods to check if privileges are granted.
    /// </summary>
    /// <since_tizen>14</since_tizen>
    /// <example>
    /// <code><![CDATA[
    /// PermissionResult permissions = await PrivacyPrivilegeManager.CheckPermissionsAsync(privileges);
    ///
    /// // Check if a specific privilege is granted (returns false for unknown privileges)
    /// bool isGranted = permissions.IsGranted("http://tizen.org/privilege/account.read");
    ///
    /// // Check if all privileges are granted
    /// bool allGranted = permissions.AllGranted();
    /// ]]></code>
    /// </example>
    public class PermissionResult : Dictionary<string, PermissionStatus>
    {
        /// <summary>
        /// Checks if a specific privilege is granted.
        /// Returns false for unknown privileges without throwing an exception.
        /// </summary>
        /// <param name="privilege">The privilege to check.</param>
        /// <returns>True if the privilege is granted; otherwise, false.</returns>
        /// <since_tizen>14</since_tizen>
        public bool IsGranted(string privilege) =>
            TryGetValue(privilege, out var status) && status.IsGranted();

        /// <summary>
        /// Checks if all privileges in this result are granted.
        /// </summary>
        /// <returns>True if all privileges are granted; otherwise, false.</returns>
        /// <since_tizen>14</since_tizen>
        public bool AreAllGranted() => Values.All(status => status.IsGranted());
    }
}
