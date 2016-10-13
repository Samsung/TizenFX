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

using System;
using System.Runtime.InteropServices;
using Tizen.Internals.Errors;
using Tizen.Applications;

namespace Tizen.Security
{
    /// <summary>
    /// The class provides the information of the given privilege and API version.
    /// </summary>
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
                throw PrivilegeErrorFactory.GetException(ErrorCode.InvalidParameter, "Invalid Parameter");
            }
        }

        /// <summary>
        /// Gets the display name of the given privilege.
        /// </summary>
        /// <param name="apiVersion">The api version</param>
        /// <param name="privilege">The privilege</param>
        /// <returns>The display name of given privilege at given api version</returns>
        /// <exception cref="System.ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when internal error occurs.</exception>
        public static string GetDisplayName(string apiVersion, string privilege)
        {
            string displayName;
            int ret = Interop.Privilege.GetDisplayName(apiVersion, privilege, out displayName);
            PrivilegeErrorFactory.ThrowException(ret);
            return displayName;
        }

        /// <summary>
        /// Gets the display name of the given privilege.
        /// </summary>
        /// <param name="apiVersion">The api version</param>
        /// <param name="privilege">The privilege</param>
        /// <param name="packageType">The type of application package</param>
        /// <returns>The display name of given privilege at given api version and the package type</returns>
        /// <exception cref="System.ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when internal error occurs.</exception>
        public static string GetDisplayName(string apiVersion, string privilege, PackageType packageType)
        {
            string displayName;
            int ret = Interop.Privilege.GetDisplayNameByPkgtype(ToPackageTypeString(packageType), apiVersion, privilege, out displayName);
            PrivilegeErrorFactory.ThrowException(ret);
            return displayName;
        }

        /// <summary>
        /// Gets the description of the given privilege.
        /// </summary>
        /// <param name="apiVersion">The api version</param>
        /// <param name="privilege">The privilege</param>
        /// <returns>The description of given privilege at given api version</returns>
        /// <exception cref="System.ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when internal error occurs.</exception>
        public static string GetDescription(string apiVersion, string privilege)
        {
            string description;
            int ret = Interop.Privilege.GetDescription(apiVersion, privilege, out description);
            PrivilegeErrorFactory.ThrowException(ret);
            return description;
        }

        /// <summary>
        /// Gets the description of the given privilege.
        /// </summary>
        /// <param name="apiVersion">The api version</param>
        /// <param name="privilege">The privilege</param>
        /// <param name="packageType">The type of application package</param>
        /// <returns>The description of given privilege at given api version and the package type</returns>
        /// <exception cref="System.ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when internal error occurs.</exception>
        public static string GetDescription(string apiVersion, string privilege, PackageType packageType)
        {
            string description;
            int ret = Interop.Privilege.GetDescriptionByPkgtype(ToPackageTypeString(packageType),apiVersion, privilege, out description);
            PrivilegeErrorFactory.ThrowException(ret);
            return description;
        }

        /// <summary>
        /// Gets the display name of the privacy group in which the given privilege is included.
        /// </summary>
        /// <param name="privilege">The privilege</param>
        /// <remarks>The privilege must be privacy related.</remarks>
        /// <returns>The privacy group's display name that the given privilege is included in</returns>
        /// <exception cref="System.ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when internal error occurs.</exception>
        public static string GetPrivacyDisplayName(string privilege)
        {
            string displayName;
            int ret = Interop.Privilege.GetPrivacyDisplayName(privilege, out displayName);
            PrivilegeErrorFactory.ThrowException(ret);
            return displayName;
        }

        /// <summary>
        /// Gets the status of the given privacy related privilege.
        /// </summary>
        /// <param name="privilege">The privilege</param>
        /// <remarks>The privilege must be privacy related.</remarks>
        /// <remarks>In case of errors, status is set to true</remarks>
        /// <returns>status true if the privilege is on and false if the privilege is off.</returns>
        /// <exception cref="System.ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when internal error occurs.</exception>
        public static bool GetPrivacyPrivilegeStatus(string privilege)
        {
            bool status;
            int ret = Interop.Privilege.GetPrivacyPrivilegeStatus(privilege, out status);
            PrivilegeErrorFactory.ThrowException(ret);
            return status;
        }
    }

    internal static class PrivilegeErrorFactory
    {
        static internal Exception GetException(ErrorCode err, string message)
        {
            string errorMessage = string.Format("{0} err = {1}", message, err);
            switch (err)
            {
                case ErrorCode.InvalidParameter:
                    return new ArgumentException(errorMessage);
                case ErrorCode.OutOfMemory:
                    return new InvalidOperationException(errorMessage);
                default:
                    return new InvalidOperationException(errorMessage);
            }
        }

        static internal void ThrowException(int error)
        {
            if ((ErrorCode)error == ErrorCode.None)
            {
                return;
            }
            else if ((ErrorCode)error == ErrorCode.InvalidParameter)
            {
                throw new ArgumentException("Invalid parameter");
            }
            else if ((ErrorCode)error == ErrorCode.OutOfMemory)
            {
                throw new InvalidOperationException("Out of memory");
            }
        }
    }
}
