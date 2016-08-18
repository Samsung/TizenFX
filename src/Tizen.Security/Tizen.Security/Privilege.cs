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
        internal static string ToPackageTypeString(PackageType type)
        {
            if (type == PackageType.TPK)
            {
                return "PRVINFO_PACKAGE_TYPE_NATIVE";
            }
            else if (type == PackageType.WGT)
            {
                return "PRVINFO_PACKAGE_TYPE_WEB";
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
        /// <param name="privilege">The privilege name to get display name</param>
        /// <returns>display name of given privilege at given api version</returns>
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
        /// <param name="privilege">The privilege name to get display name</param>
        /// <param name="packageType">The package type to get privilege's display name</param>
        /// <returns>display name of given privilege at given api version and the package type</returns>
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
        /// <param name="privilege">The privilege name to get description</param>
        /// <returns>description of given privilege at given api version</returns>
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
        /// <param name="privilege">The privilege name to get description</param>
        /// <param name="packageType">The package type to get privilege's description</param>
        /// <returns>description of given privilege at given api version and the package type</returns>
        /// <exception cref="System.ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when internal error occurs.</exception>
        public static string GetDescription(string apiVersion, string privilege, PackageType packageType)
        {
            string description;
            int ret = Interop.Privilege.GetDescriptionByPkgtype(ToPackageTypeString(packageType),apiVersion, privilege, out description);
            PrivilegeErrorFactory.ThrowException(ret);
            return description;
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
