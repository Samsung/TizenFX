/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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
