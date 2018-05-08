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
    internal enum CameraError
    {
        TizenErrorCamera = -0x01910000,
        CameraErrorClass = TizenErrorCamera,
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        InvalidState = CameraErrorClass | 0x02,
        OutOfMemory = ErrorCode.OutOfMemory,
        DeviceError = CameraErrorClass | 0x04,
        InvalidOperation = ErrorCode.InvalidOperation,
        SecurityRestricted = CameraErrorClass | 0x07,
        DeviceBusy = CameraErrorClass | 0x08,
        DeviceNotFound = CameraErrorClass | 0x09,
        Esd = CameraErrorClass | 0x0c,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported,
        ResourceConflict = CameraErrorClass | 0x0d,
        ServiceDisconnected = CameraErrorClass | 0x0e
    }

    internal static class CameraErrorCodeExtensions
    {
        internal static void ThrowIfFailed(this CameraError errorCode, string errorMessage = null,
            [CallerMemberName] string caller = null, [CallerLineNumber] int line = 0)
        {
            if (errorCode == CameraError.None)
            {
                return;
            }

            Log.Info(CameraLog.Tag, "errorCode : " + errorCode.ToString() + ", Caller : " + caller + ", line " + line.ToString());

            switch (errorCode)
            {
                case CameraError.InvalidParameter:
                    throw new ArgumentException(errorMessage);

                case CameraError.OutOfMemory:
                    throw new OutOfMemoryException(errorMessage);

                case CameraError.DeviceError:
                case CameraError.DeviceBusy:
                case CameraError.Esd:
                    throw new CameraDeviceException(errorMessage);

                case CameraError.DeviceNotFound:
                    throw new CameraDeviceNotFoundException(errorMessage);

                case CameraError.SecurityRestricted:
                case CameraError.PermissionDenied:
                    throw new UnauthorizedAccessException(errorMessage);

                case CameraError.NotSupported:
                    throw new NotSupportedException(errorMessage);

                case CameraError.InvalidState:
                case CameraError.InvalidOperation:
                case CameraError.ResourceConflict:
                case CameraError.ServiceDisconnected:
                    throw new InvalidOperationException(errorMessage);

                default:
                    throw new Exception("Unknown error : " + errorCode);
            }
        }
    }
}
