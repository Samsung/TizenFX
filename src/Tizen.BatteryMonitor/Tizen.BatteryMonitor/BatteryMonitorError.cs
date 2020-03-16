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

namespace Tizen.BatteryMonitor
{
    /// <summary>
    /// Battery Monitor error codes.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum BatteryMonitorError
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
        /// No data available.
        /// </summary>
        NoData = ErrorCode.NoData,

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
        RecordNotFound = 0x9100000 | 0x01,

        /// <summary>
        /// DB operation failed .
        /// </summary>
        DBFailed = 0x9100000 | 0x02,

        /// <summary>
        /// DB is not connected.
        /// </summary>
        DBNotOpened = 0x9100000 | 0x03,

        /// <summary>
        /// Internal error for generic use.
        /// </summary>
        Internal = 0x9100000 | 0x04
    }

    internal static class BatteryMonitorErrorFactory
    {
        internal static Exception ThrowBatteryMonitorException(int errCode)
        {
            Log.Error(Globals.LogTag, "Throw BatteryMonitor Exception : " + errCode);
            BatteryMonitorError error = (BatteryMonitorError)errCode;
            switch (error)
            {
                case BatteryMonitorError.OutOfMemory:
                    return new InvalidOperationException("Out of memory");
                case BatteryMonitorError.InvalidParameter:
                    return new ArgumentException("Invalid Parameter passed");
                case BatteryMonitorError.NoData:
                    return new UnauthorizedAccessException("No data available");
                case BatteryMonitorError.AcessibilityNotallowed:
                    return new NotSupportedException("Permission denied");
                case BatteryMonitorError.NotSupported:
                    return new InvalidOperationException("Address family not supported");
                case BatteryMonitorError.RecordNotFound:
                    return new InvalidOperationException("Related record does not exist");
                case BatteryMonitorError.DBFailed:
                    return new InvalidOperationException("DB operation failed");
                case BatteryMonitorError.DBNotOpened:
                    return new InvalidOperationException("DB is not connected");
                case BatteryMonitorError.Internal:
                    return new InvalidOperationException("Internal error for generic use");
                default:
                    return new InvalidOperationException("Unknown Error");
            }
        }
    }



}
