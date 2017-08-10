/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Context.AppHistory
{
    internal enum AppHistoryError
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        OutOfMemory = ErrorCode.OutOfMemory,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported,
        NoData = ErrorCode.NoData,
        OperationFailed = -0x02480000 | 0x04,
    }

    internal static class AppHistoryErrorFactory
    {
        internal const string LogTag = "Tizen.Context.AppHistory";

        internal static Exception CheckAndThrowException(AppHistoryError error, string msg)
        {
            switch (error)
            {
                case AppHistoryError.None:
                    return null;
                case AppHistoryError.InvalidParameter:
                    return new ArgumentException("Invalid Parameter: " + msg);
                case AppHistoryError.OutOfMemory:
                    return new OutOfMemoryException("Out of Memory: " + msg);
                case AppHistoryError.PermissionDenied:
                    return new UnauthorizedAccessException("Permission Denied: " + msg);
                case AppHistoryError.NotSupported:
                    return new NotSupportedException("Not Supported: " + msg);
                case AppHistoryError.OperationFailed:
                    return new InvalidOperationException("Operation Failed: " + msg);
                default:
                    return new InvalidOperationException("Unknown Error Code: " + msg);
            }
        }
    }
}
