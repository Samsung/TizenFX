/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.WatchfaceComplication
{
    internal static class ErrorFactory
    {
        private const string LogTag = "WatchfaceComplication";

        internal static void ThrowException(ComplicationError errorCode, string errorMessage = null,
            [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            Log.Error(LogTag, $"{memberName}({lineNumber.ToString()}) : {filePath}");
            switch (errorCode)
            {
                case ComplicationError.None:
                    return;
                case ComplicationError.OutOfMemory:
                case ComplicationError.IO:
                case ComplicationError.NoData:
                case ComplicationError.DB:
                case ComplicationError.DBus:
                case ComplicationError.EditNotReady:
                case ComplicationError.ExistID:
                case ComplicationError.NotExist:
                    throw new InvalidOperationException(string.IsNullOrEmpty(errorMessage) ? "error code : " + errorCode.ToString() :
                        $"{errorMessage} - {errorCode}");
                case ComplicationError.InvalidParam:
                    Log.Error(LogTag, "Invalid parameter : " + errorMessage);
                    throw new ArgumentException(string.IsNullOrEmpty(errorMessage) ? "Invalid parameter" : "Invalid parameter : " + errorMessage);
                case ComplicationError.PermissionDeny:
                    Log.Error(LogTag, "Permission denied : " + errorMessage);
                    throw new UnauthorizedAccessException(string.IsNullOrEmpty(errorMessage) ? "Permission denied" : "Permission denied : " + errorMessage);
                case ComplicationError.NotSupported:
                    Log.Error(LogTag, "Not supported : " + errorMessage);
                    throw new NotSupportedException(string.IsNullOrEmpty(errorMessage) ? "Not supported" : "Not supported : " + errorMessage);
                default:
                    Log.Error(LogTag, $"Unknown error : {errorMessage} - {errorCode}");
                    throw new InvalidOperationException(string.IsNullOrEmpty(errorMessage) ? "Unknown error : " + errorCode.ToString() :
                        $"Unknown error : {errorMessage} - {errorCode}");
            }
        }
    }
}
