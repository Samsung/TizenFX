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
    internal enum CameraError
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        TizenErrorCamera = -0x01910000,
        CameraErrorClass = TizenErrorCamera | 0x00,
        InvalidState = CameraErrorClass | 0x02,
        OutOfMemory = ErrorCode.OutOfMemory,
        ErrorDevice = CameraErrorClass | 0x04,
        InvalidOperation = ErrorCode.InvalidOperation,
        SoundPolicy = CameraErrorClass | 0x06,
        SecurityRestricted = CameraErrorClass | 0x07,
        DeviceBusy = CameraErrorClass | 0x08,
        DeviceNotFound = CameraErrorClass | 0x09,
        SoundPolicyByCall = CameraErrorClass | 0x0a,
        SoundPolicyByAlarm = CameraErrorClass | 0x0b,
        Esd = CameraErrorClass | 0x0c,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported,
        ResourceConflict = CameraErrorClass | 0x0d,
        ServiceDisconnected = CameraErrorClass | 0x0e
    }

    internal static class CameraErrorFactory
    {
        internal static void ThrowException(int errorCode, string errorMessage = null, string paramName = null)
        {
            CameraError err = (CameraError)errorCode;
            if (string.IsNullOrEmpty(errorMessage))
            {
                errorMessage = err.ToString();
            }

            switch ((CameraError)errorCode)
            {
                case CameraError.InvalidParameter:
                    throw new ArgumentException(errorMessage, paramName);

                case CameraError.InvalidState:
                case CameraError.OutOfMemory:
                case CameraError.ErrorDevice:
                case CameraError.InvalidOperation:
                case CameraError.DeviceBusy:
                case CameraError.DeviceNotFound:
                case CameraError.SoundPolicy:
                case CameraError.SecurityRestricted:
                case CameraError.SoundPolicyByCall:
                case CameraError.SoundPolicyByAlarm:
                case CameraError.Esd:
                case CameraError.PermissionDenied:
		            throw new UnauthorizedAccessException(errorMessage);
                case CameraError.NotSupported:
                    throw new NotSupportedException(errorMessage);
                case CameraError.ResourceConflict:
                case CameraError.ServiceDisconnected:
                    throw new InvalidOperationException(errorMessage);
            }
        }
    }
}
