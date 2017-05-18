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

namespace Tizen.Multimedia
{
    internal enum RecorderError
    {
        TizenErrorRecorder = -0x01950000,
        RecorderErrorClass = TizenErrorRecorder | 0x10,
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        InvalidState = RecorderErrorClass | 0x02,
        OutOfMemory = ErrorCode.OutOfMemory,
        DeviceError = RecorderErrorClass | 0x04,
        InvalidOperation = ErrorCode.InvalidOperation,
        SecurityRestricted = RecorderErrorClass | 0x07,
        Esd = RecorderErrorClass | 0x0a,
        OutOfStorage = RecorderErrorClass | 0x0b,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported,
        ResourceConflict = RecorderErrorClass | 0x0c,
        ServiceDisconnected = RecorderErrorClass | 0x0d
    }

    internal static class RecorderErrorFactory
    {
        internal static void ThrowIfError(RecorderError errorCode, string errorMessage = null,
            [CallerMemberName] string caller = null, [CallerLineNumber] int line = 0)
        {
            if (errorCode == RecorderError.None)
            {
                return;
            }

            Log.Info(RecorderLog.Tag, "errorCode : " + errorCode.ToString() + ", Caller : " + caller + ", line " + line.ToString());

            switch (errorCode)
            {
                case RecorderError.InvalidParameter:
                    throw new ArgumentException(errorMessage);

                case RecorderError.OutOfMemory:
                    throw new OutOfMemoryException(errorMessage);

                case RecorderError.DeviceError:
                case RecorderError.Esd:
                case RecorderError.SecurityRestricted:
                case RecorderError.PermissionDenied:
                    throw new UnauthorizedAccessException(errorMessage);

                case RecorderError.NotSupported:
                    throw new NotSupportedException(errorMessage);

                case RecorderError.InvalidState:
                case RecorderError.InvalidOperation:
                case RecorderError.ResourceConflict:
                case RecorderError.ServiceDisconnected:
                case RecorderError.OutOfStorage: //TODO need to alloc new proper exception class
                    throw new InvalidOperationException(errorMessage);

                default:
                    throw new Exception("Unknown error : " + errorCode.ToString());
            }
        }
    }
}
