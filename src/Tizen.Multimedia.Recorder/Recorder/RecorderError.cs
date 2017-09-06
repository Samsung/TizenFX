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
using System.IO;
using Tizen.Internals.Errors;

namespace Tizen.Multimedia
{
    internal enum RecorderErrorCode
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

    internal static class RecorderErrorCodeExtensions
    {
        internal static RecorderErrorCode Ignore(this RecorderErrorCode errorCode, RecorderErrorCode ignore)
        {
            return (ignore == errorCode) ? RecorderErrorCode.None : errorCode;
        }

        internal static void ThrowIfError(this RecorderErrorCode errorCode, string errorMessage)
        {
            if (errorCode == RecorderErrorCode.None)
            {
                return;
            }

            switch (errorCode)
            {
                case RecorderErrorCode.InvalidParameter:
                    throw new ArgumentException(errorMessage);

                case RecorderErrorCode.OutOfMemory:
                    throw new OutOfMemoryException($"{errorMessage}.");

                case RecorderErrorCode.DeviceError:
                case RecorderErrorCode.Esd:
                    throw new RecorderDeviceException($"{errorMessage}; {errorCode.ToString()}.");

                case RecorderErrorCode.SecurityRestricted:
                    throw new UnauthorizedAccessException($"The feature is currently disabled by the device policy; {errorCode.ToString()}.");

                case RecorderErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException($"{errorMessage}; {errorCode.ToString()}.");

                case RecorderErrorCode.NotSupported:
                    throw new NotSupportedException($"{errorMessage}.");

                case RecorderErrorCode.InvalidState:
                case RecorderErrorCode.InvalidOperation:
                case RecorderErrorCode.ResourceConflict:
                case RecorderErrorCode.ServiceDisconnected:
                    throw new InvalidOperationException($"{errorMessage}; {errorCode.ToString()}.");

                case RecorderErrorCode.OutOfStorage:
                    throw new IOException($"{errorMessage}; Not enough disk space or specified path is not available to .");

                default:
                    throw new Exception($"Unknown error : {errorCode.ToString()}.");
            }
        }
    }
}
