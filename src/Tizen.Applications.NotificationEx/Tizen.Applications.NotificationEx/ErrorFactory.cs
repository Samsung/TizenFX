/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.CompilerServices;

namespace Tizen.Applications.NotificationEx
{
    internal static class ErrorFactory
    {
        private const string LogTag = "Tizen.Applications.NotificationEx";

        internal static void ThrowException(ErrorCode errorCode, string errorMessage = null,
            [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            Log.Error(LogTag, $"{memberName}({lineNumber.ToString()}) : {filePath}");
            switch (errorCode)
            {
                case ErrorCode.None:
                    return;
                case ErrorCode.OutOfMemory:
                case ErrorCode.IO:
                case ErrorCode.InvalidOperation:
                case ErrorCode.DB:
                case ErrorCode.AlreadyExistID:
                case ErrorCode.DBus:
                case ErrorCode.NotExistID:
                case ErrorCode.ServiceNotReady:
                case ErrorCode.MaxExceeded:
                    throw new InvalidOperationException(string.IsNullOrEmpty(errorMessage) ? "error code : " + errorCode.ToString() :
                        $"{errorMessage} - {errorCode}");
                case ErrorCode.InvalidParameter:
                    Log.Error(LogTag, "Invalid parameter : " + errorMessage);
                    throw new ArgumentException(string.IsNullOrEmpty(errorMessage) ? "Invalid parameter" : "Invalid parameter : " + errorMessage);
                case ErrorCode.PermissionDenied:
                    Log.Error(LogTag, "Permission denied : " + errorMessage);
                    throw new UnauthorizedAccessException(string.IsNullOrEmpty(errorMessage) ? "Permission denied" : "Permission denied : " + errorMessage);
                default:
                    Log.Error(LogTag, $"Unknown error : {errorMessage} - {errorCode}");
                    throw new InvalidOperationException(string.IsNullOrEmpty(errorMessage) ? "Unknown error : " + errorCode.ToString() :
                        $"Unknown error : {errorMessage} - {errorCode}");
            }
        }
    }
}
