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
using System.Runtime.CompilerServices;

namespace Tizen.Applications.DataControl
{
    internal enum ErronType : int
    {
        Success = Interop.DataControl.NativeResultType.Success,
        OutOfMemory = Interop.DataControl.NativeResultType.OutOfMemory,
        IoError = Interop.DataControl.NativeResultType.IoError,
        InvalidParamer = Interop.DataControl.NativeResultType.InvalidParamer,
        PermissionDenied = Interop.DataControl.NativeResultType.PermissionDenied,
        MaxExceed = Interop.DataControl.NativeResultType.MaxExceed,
    }

    internal static class ErrorFactory
    {
        private const string LogTag = "Tizen.Applications.DataControl";

        internal static void ThrowException(ResultType errorCode, bool ignoreType, string errorMessage = null,
            [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            Log.Error(LogTag, $"{memberName}({lineNumber.ToString()}) : {filePath}");
            if (ignoreType)
            {
                throw new InvalidOperationException(string.IsNullOrEmpty(errorMessage) ? "error code : " + errorCode.ToString() :
                     $"{errorMessage} - {errorCode}");
            }

            switch (errorCode)
            {
                case ResultType.Success:
                    return;
                case ResultType.OutOfMemory:
                case ResultType.IoError:
                    throw new InvalidOperationException(string.IsNullOrEmpty(errorMessage) ? "error code : " + errorCode.ToString() :
                        $"{errorMessage} - {errorCode}");
                case ResultType.InvalidParamer:
                    Log.Error(LogTag, "Invalid parameter : " + errorMessage);
                    throw new ArgumentException(string.IsNullOrEmpty(errorMessage) ? "Invalid parameter" : "Invalid parameter : " + errorMessage);
                case ResultType.PermissionDenied:
                    Log.Error(LogTag, "Permission denied : " + errorMessage);
                    throw new UnauthorizedAccessException(string.IsNullOrEmpty(errorMessage) ? "Permission denied" : "Permission denied : " + errorMessage);
                case ResultType.MaxExceed:
                    Log.Error(LogTag, "Too long argument : " + errorMessage);
                    throw new ArgumentOutOfRangeException(string.IsNullOrEmpty(errorMessage) ? "Too long argument" : "Too long argument : " + errorMessage);                
                default:
                    Log.Error(LogTag, $"Unknown error : {errorMessage} - {errorCode}");
                    throw new InvalidOperationException(string.IsNullOrEmpty(errorMessage) ? "Unknown error : " + errorCode.ToString() :
                        $"Unknown error : {errorMessage} - {errorCode}");
            }
        }
    }
}
