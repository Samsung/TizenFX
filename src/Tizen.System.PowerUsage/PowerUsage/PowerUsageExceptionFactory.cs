/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Internals.Errors;

namespace Tizen.System
{
    /// <summary>
    /// Power Usage error codes.
    /// </summary>
    /// <since_tizen> 7 </since_tizen>
    internal enum PowerUsageError
    {
        /// <summary>
        /// Successful.
        /// </summary>
        None = ErrorCode.None,

        /// <summary>
        /// Out of memory error.
        /// </summary>
        OutOfMemory = ErrorCode.OutOfMemory,

        /// <summary>
        /// Invalid parameter.
        /// </summary>
        InvalidParameter = ErrorCode.InvalidParameter,

        /// <summary>
        /// Permission denied.
        /// </summary>
        AcessibilityNotallowed = ErrorCode.PermissionDenied,

        /// <summary>
        /// Address family not supported.
        /// </summary>
        NotSupported = ErrorCode.NotSupported,

        /// <summary>
        /// Related record does not exist.
        /// </summary>
        RecordNotFound = -0x03060000 | 0x01,

        /// <summary>
        /// DB operation failed .
        /// </summary>
        DBFailed = -0x03060000 | 0x02,

        /// <summary>
        /// DB is not connected.
        /// </summary>
        DBNotOpened = -0x03060000 | 0x03,

        /// <summary>
        /// Internal error for generic use.
        /// </summary>
        Internal = -0x03060000 | 0x04
    }

    internal static class PowerUsageErrorFactory
    {
        internal const string LogTag = "Tizen.System.PowerUsage";
        internal static Exception ThrowPowerUsageException(PowerUsageError errCode)
        {
            Log.Error(LogTag, "Throw PowerUsage Exception : " + errCode);

            switch (errCode)
            {
                case PowerUsageError.OutOfMemory:
                    return new InvalidOperationException("Out of memory");
                case PowerUsageError.InvalidParameter:
                    return new ArgumentException("Invalid Parameter passed");
                case PowerUsageError.AcessibilityNotallowed:
                    return new UnauthorizedAccessException("Permission denied");
                case PowerUsageError.NotSupported:
                    return new NotSupportedException("Not supported");
                case PowerUsageError.RecordNotFound:
                    return new InvalidOperationException("Related record does not exist");
                case PowerUsageError.DBFailed:
                    return new InvalidOperationException("DB operation failed");
                case PowerUsageError.DBNotOpened:
                    return new InvalidOperationException("DB is not connected");
                case PowerUsageError.Internal:
                    return new InvalidOperationException("Internal error for generic use");
                default:
                    return new InvalidOperationException("Unknown Error");
            }
        }
    }
}