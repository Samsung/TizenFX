// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;
using Tizen.Internals.Errors;
using Tizen.Applications;

namespace Tizen.Security
{
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
