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
using Tizen.Internals.Errors;

namespace Tizen.Multimedia
{
    internal enum StreamRecorderError
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        TizenErrorStreamRecorder = -0x01A10000,
        InvalidState = TizenErrorStreamRecorder | 0x01,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidOperation = ErrorCode.InvalidOperation,
        OutOfStorage = TizenErrorStreamRecorder | 0x02,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported,
    }

    internal static class StreamRecorderErrorFactory
    {
        internal static void ThrowException(int errorCode, string errorMessage = null, string paramName = null)
        {
            StreamRecorderError err = (StreamRecorderError)errorCode;
            if(string.IsNullOrEmpty(errorMessage)) {
                errorMessage = err.ToString();
            }
            switch((StreamRecorderError)errorCode) {
            case StreamRecorderError.InvalidParameter:
                throw new ArgumentException(errorMessage, paramName);
            case StreamRecorderError.OutOfMemory:
                throw new OutOfMemoryException(errorMessage);
            case StreamRecorderError.PermissionDenied:
                throw new UnauthorizedAccessException(errorMessage);
            case StreamRecorderError.NotSupported:
                throw new NotSupportedException(errorMessage);
            case StreamRecorderError.InvalidState:
            case StreamRecorderError.InvalidOperation:
            case StreamRecorderError.OutOfStorage:
                throw new InvalidOperationException(errorMessage);
            }
        }
    }
}

