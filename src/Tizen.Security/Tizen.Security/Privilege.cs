/*
 *  Copyright (c) 2016-2023 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices;
using Tizen.Internals.Errors;
using Tizen.Applications;

namespace Tizen.Security
{
    /// <summary>
    /// Stores the information on the given privilege and the API version.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public static class Privilege
    {
        internal static readonly string PackageTypeTpk = "PRVINFO_PACKAGE_TYPE_NATIVE";
        internal static readonly string PackageTypeWgt = "PRVINFO_PACKAGE_TYPE_WEB";
        internal static string ToPackageTypeString(PackageType type)
        {
            if (type == PackageType.TPK)
            {
                return PackageTypeTpk;
            }
            else if (type == PackageType.WGT)
            {
                return PackageTypeWgt;
            }
            else
            {
                Tizen.Log.Error(Interop.Privilege.LogTag, "Invalid Parameter: PackageType doesn't include TPK or WGT");
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Gets the display name of the given privilege.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// If there's no matching privilege, then it returns last token of the given privilege.
        /// Since Tizen 6.0, if there's no matching privilege then it returns ArgumentException.
        /// </remarks>
        /// <param name="apiVersion">API version of the application.</param>
        /// <param name="privilege">Given privilege.</param>
        /// <returns>Display name of the given privilege at the given API version.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when there is a null parameter.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when there is an invalid parameter, such as a non-existing <paramref name="privilege"/>.
        /// </exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when out of memory.</exception>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown when an internal error occurs.
        /// </exception>
        public static string GetDisplayName(string apiVersion, string privilege)
        {
            string displayName;
            if (apiVersion == null || privilege == null)
                PrivilegeErrorFactory.ThrowException(new ArgumentNullException(), "apiVersion and privilege should not be null.");
            PrivilegeErrorFactory.CheckNThrowException(
                    Interop.Privilege.GetDisplayName(apiVersion, privilege, out displayName),
                    "Failed to Get Privilege's Display Name.");
            return displayName;
        }

        /// <summary>
        /// Gets the display name of the given privilege by type of application package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// If there's no matching privilege, then it returns last token of the given privilege.
        /// Since Tizen 6.0, if there's no matching privilege then it returns ArgumentException.
        /// </remarks>
        /// <param name="apiVersion">API version of the application.</param>
        /// <param name="privilege">Given privilege.</param>
        /// <param name="packageType">Type of application package.</param>
        /// <returns>
        /// Display name of the given privilege at the given API version and the package type.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when there is a null parameter.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when there is an invalid parameter, such as a non-existing <paramref name="privilege"/>.
        /// </exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when out of memory.</exception>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown when an internal error occurs.
        /// </exception>
        public static string GetDisplayName(string apiVersion, string privilege, PackageType packageType)
        {
            string displayName;
            if (apiVersion == null || privilege == null)
                PrivilegeErrorFactory.ThrowException(new ArgumentNullException(), "apiVersion and privilege should not be null.");
            PrivilegeErrorFactory.CheckNThrowException(
                Interop.Privilege.GetDisplayNameByPkgtype(ToPackageTypeString(packageType), apiVersion, privilege, out displayName),
                "Failed to Get Privilege's Display Name.");
            return displayName;
        }

        /// <summary>
        /// Gets the description of the given privilege.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// If there's no matching privilege, then it returns description string for undefined privilege.
        /// Since Tizen 6.0, if there's no matching privilege then it returns ArgumentException.
        /// </remarks>
        /// <param name="apiVersion">API version of the application.</param>
        /// <param name="privilege">Given privilege.</param>
        /// <returns>Description of given privilege at the given API version</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when there is a null parameter.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when there is an invalid parameter, such as a non-existing <paramref name="privilege"/>.
        /// </exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when out of memory.</exception>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown when an internal error occurs.
        /// </exception>
        public static string GetDescription(string apiVersion, string privilege)
        {
            string description;
            if (apiVersion == null || privilege == null)
                PrivilegeErrorFactory.ThrowException(new ArgumentNullException(), "apiVersion and privilege should not be null.");
            PrivilegeErrorFactory.CheckNThrowException(
                    Interop.Privilege.GetDescription(apiVersion, privilege, out description),
                    "Failed to Get Privilege's Description.");
            return description;
        }

        /// <summary>
        /// Gets the description of the given privilege by type of application package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// If there's no matching privilege, then it returns description string for undefined privilege.
        /// Since Tizen 6.0, if there's no matching privilege then it returns ArgumentException.
        /// </remarks>
        /// <param name="apiVersion">API version of the application.</param>
        /// <param name="privilege">Given privilege.</param>
        /// <param name="packageType">Type of application package.</param>
        /// <returns>
        /// Description of given privilege at the given API version and the package type.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when there is a null parameter.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when there is an invalid parameter, such as a non-existing <paramref name="privilege"/>.
        /// </exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when out of memory.</exception>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown when an internal error occurs.
        /// </exception>
        public static string GetDescription(string apiVersion, string privilege, PackageType packageType)
        {
            string description;
            if (apiVersion == null || privilege == null)
                PrivilegeErrorFactory.ThrowException(new ArgumentNullException(), "apiVersion and privilege should not be null.");
            PrivilegeErrorFactory.CheckNThrowException(
                    Interop.Privilege.GetDescriptionByPkgtype(ToPackageTypeString(packageType),apiVersion, privilege, out description),
                    "Failed to Get Privilege's Description.");
            return description;
        }

        /// <summary>
        /// [Obsolete("Please do not use! This method is deprecated")]
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/security.privacy_privilege</feature>
        /// <remarks>Given privilege must be privacy related.</remarks>
        /// <param name="privilege">Given privilege.</param>
        /// <returns>Privacy group's display name in which the given privilege is included.</returns>
        /// <exception cref="System.NotSupportedException">
        /// Thrown when required feature is not supported.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when there is a null parameter.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when there is an invalid parameter, such as a non-existing <paramref name="privilege"/>.
        /// </exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when out of memory.</exception>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown when an internal error occurs.
        /// </exception>
        [Obsolete("Deprecated since API level 11.")]
        public static string GetPrivacyDisplayName(string privilege)
        {
            string displayName;
            if (privilege == null)
                PrivilegeErrorFactory.ThrowException(new ArgumentNullException(), "privilege should not be null.");
            PrivilegeErrorFactory.CheckNThrowException(
                    Interop.Privilege.GetPrivacyDisplayName(privilege, out displayName),
                    "Failed to Get Privacy's Display Name in Which the Given Privilege is included.");
            return displayName;
        }
    }

    internal static class PrivilegeErrorFactory
    {
        internal static void ThrowException(Exception e, string msg)
        {
            Tizen.Log.Error(Interop.Privilege.LogTag, "[" + e.ToString() + "] " + msg);
            throw e;
        }
        internal static void CheckNThrowException(int err, string msg)
        {
            if (err == (int)ErrorCode.None)
                return;
            if (err == (int)Interop.Privilege.ErrorCode.NoMatchingPrivilege)
                Tizen.Log.Error(Interop.Privilege.LogTag, "[System.ArgumentException] No such a privilege. " + msg);
            else
                Tizen.Log.Error(Interop.Privilege.LogTag, "[" + ErrorFacts.GetErrorMessage(err) + "] " + msg);
            switch (err)
            {
                case (int)ErrorCode.NotSupported:
                    throw new NotSupportedException();
                case (int)Interop.Privilege.ErrorCode.NoMatchingPrivilege:
                case (int)ErrorCode.InvalidParameter:
                    throw new ArgumentException();
                case (int)ErrorCode.OutOfMemory:
                    throw new OutOfMemoryException();
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
