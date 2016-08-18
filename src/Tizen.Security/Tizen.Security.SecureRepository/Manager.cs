/*
 *  Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Security.SecureRepository
{
    /// <summary>
    /// This class is a base class of XxxManager classes. It provides the common methods for all sub classes.
    /// </summary>
    public class Manager
    {
        // ckmc_owner_id_separator
        // ckmc_owner_id_system

        /// <summary>
        /// Separator between alias and owner id.
        /// </summary>
        /// <remarks>
        /// Alias can be provided as an alias alone, or together with owner id. 
        /// In this case, separator " " (space bar) is used to separate id and alias.
        /// </remarks>
        public const string OwnerIdSeperator = " ";

        /// <summary>
        /// The owner of system database.
        /// </summary>
        /// <remarks>
        /// SystemOwnerId constains id connected with all SYSTEM applications that run
        /// with uid less than 5000.
        /// Client should use SystemOwnerId to access data owned by system application
        /// and stored in system database.
        /// Note: Client must have permission to access proper row.
        /// </remarks>
        public const string SystemOwnerId = "/System";

        /// <summary>
        /// Removes a an entry (no matter of type) from the key manager.
        /// </summary>
        /// <param name="alias">Item alias to be removed.</param>
        /// <remarks>To remove item, client must have remove permission to the specified item.</remarks>
        /// <remarks>The item owner can remove by default.</remarks>
        static public void RemoveAlias(string alias)
        {
            int ret = Interop.CkmcManager.CkmcRemoveAlias(alias);
            Interop.CheckNThrowException(ret, "Failed to remove alias. alias=" + alias);
        }

        /// <summary>
        /// Allows another application to access client's application data.
        /// </summary>
        /// <param name="alias">Item alias for which access will be granted.</param>
        /// <param name="otherPackageId">Package id of the application that will gain access rights.</param>
        /// <param name="permissions">Mask of permissions(Permission enum) granted for an application with otherPackageId.</param>
        /// <remarks>Data identified by alias should exist.</remarks>
        /// <remarks>The item owner can set permissions.</remarks>
        static public void SetPermission(string alias, string otherPackageId, int permissions)
        {
            int ret = Interop.CkmcManager.CkmcSetPermission(alias, otherPackageId, permissions);
            Interop.CheckNThrowException(ret, "Failed to set permission. alias=" + alias);
        }
    }
}
