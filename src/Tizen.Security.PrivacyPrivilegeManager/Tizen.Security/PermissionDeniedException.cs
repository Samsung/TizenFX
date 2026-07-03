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
    /// Exception thrown when one or more required permissions are denied.
    /// </summary>
    /// <since_tizen> 14 </since_tizen>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// try
    /// {
    ///     await PrivacyPrivilegeManager.RequestPermissionsAsync(required: privileges);
    /// }
    /// catch (PermissionDeniedException ex)
    /// {
    ///     foreach (var privilege in ex.DeniedPrivileges)
    ///     {
    ///         var status = ex.GetStatus(privilege);
    ///         var name = Tizen.Security.Privilege.GetDisplayName("12", privilege);
    ///         Console.WriteLine($"{name}: {status}");
    ///     }
    /// }
    /// ]]>
    /// </code>
    /// </example>
    public class PermissionDeniedException : Exception
    {
        private readonly IDictionary<string, PermissionStatus> _map;

        /// <summary>
        /// Gets the list of denied privilege names.
        /// </summary>
        /// <since_tizen> 14 </since_tizen>
        public IEnumerable<string> DeniedPrivileges => _map.Keys;

        /// <summary>
        /// Initializes a new instance of the PermissionDeniedException class with denied privileges and their statuses.
        /// </summary>
        /// <param name="denied">A dictionary mapping denied privilege names to their statuses.</param>
        /// <since_tizen> 14 </since_tizen>
        public PermissionDeniedException(IDictionary<string, PermissionStatus> denied)
            : base("Required permissions denied: " + string.Join(", ", denied.Keys))
        {
            _map = new Dictionary<string, PermissionStatus>(denied);
        }

        /// <summary>
        /// Gets the permission status for a specific denied privilege.
        /// </summary>
        /// <param name="privilege">The privilege name.</param>
        /// <returns>The permission status of the denied privilege.</returns>
        /// <exception cref="ArgumentException">Thrown when the privilege is not found in the denied list.</exception>
        /// <since_tizen> 14 </since_tizen>
        public PermissionStatus GetStatus(string privilege)
        {
            if (!_map.TryGetValue(privilege, out var status))
            {
                throw new ArgumentException($"Privilege '{privilege}' is not in the denied list.", nameof(privilege));
            }
            return status;
        }
    }
}
