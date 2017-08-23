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
using System.Runtime.CompilerServices;
using Tizen.Internals.Errors;

namespace Tizen.Applications.Messages
{
    internal enum MessagePortError
    {
        None = ErrorCode.None,
        IOError = ErrorCode.IoError,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidParameter = ErrorCode.InvalidParameter,
        InvalidOperation = ErrorCode.InvalidOperation,
        PortNotFound = -0x01130000 | 0x01,
        CertificateNotMatch = -0x01130000 | 0x02,
        MaxExceeded = -0x01130000 | 0x03,
        ResourceUnavailable = -0x01130000 | 0x04
    }

    internal static class MessagePortErrorFactory
    {
        private const string LogTag = "Tizen.Applications.MessagePort";
        internal static void ThrowException(int errorCode, string errorMessage = null, string paramName = null,
            [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            MessagePortError err = (MessagePortError)errorCode;
            if (String.IsNullOrEmpty(errorMessage))
            {
                errorMessage = err.ToString();
            }

            Log.Error(LogTag, $"{memberName}({lineNumber.ToString()}) : {filePath}");
            Log.Error(LogTag, "Error : " + errorMessage);

            switch ((MessagePortError)errorCode)
            {
                case MessagePortError.IOError:
                case MessagePortError.InvalidOperation:
                case MessagePortError.PortNotFound:
                case MessagePortError.ResourceUnavailable: throw new InvalidOperationException(errorMessage);
                case MessagePortError.InvalidParameter: throw new ArgumentException(errorMessage, paramName);
                case MessagePortError.CertificateNotMatch: throw new UnauthorizedAccessException(errorMessage);
                case MessagePortError.OutOfMemory: throw new OutOfMemoryException(errorMessage);
                case MessagePortError.MaxExceeded: throw new ArgumentOutOfRangeException(paramName, errorMessage);
            }
        }
    }
}
