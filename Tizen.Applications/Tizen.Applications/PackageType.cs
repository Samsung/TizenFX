// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.Applications
{
    /// <summary>
    /// Enumeration for package type.
    /// </summary>
    public enum PackageType
    {
        /// <summary>
        /// Tizen native application package
        /// </summary>
        TPK,
        /// <summary>
        /// Tizen web/ hybrid application Package
        /// </summary>
        WGT,
    }

    internal static class PackageTypeMethods
    {
        internal static PackageType ToPackageType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw PackageManagerErrorFactory.GetException(Interop.PackageManager.ErrorCode.InvalidParameter, "type can't be null or empty");
            }

            string lowerType = type.ToLower();
            if (lowerType == "tpk")
            {
                return PackageType.TPK;
            }
            else if (lowerType == "wgt")
            {
                return PackageType.WGT;
            }
            else
            {
                throw PackageManagerErrorFactory.GetException(Interop.PackageManager.ErrorCode.InvalidParameter, "type should be tpk or wgt");
            }
        }
    }
}
