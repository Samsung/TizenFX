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
    internal enum RecorderError
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        TizenErrorRecorder = -0x01950000,
        RecorderErrorClass = TizenErrorRecorder | 0x10,
        InvalidState = RecorderErrorClass | 0x02,
        OutOfMemory = ErrorCode.OutOfMemory,
        ErrorDevice = RecorderErrorClass | 0x04,
        InvalidOperation = ErrorCode.InvalidOperation,
        SoundPolicy = RecorderErrorClass | 0x06,
        SecurityRestricted = RecorderErrorClass | 0x07,
        SoundPolicyByCall = RecorderErrorClass | 0x08,
        SoundPolicyByAlarm = RecorderErrorClass | 0x09,
        Esd = RecorderErrorClass | 0x0a,
        OutOfStorage = RecorderErrorClass | 0x0b,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported,
        ResourceConflict = RecorderErrorClass | 0x0c
    }

    internal static class RecorderErrorFactory
    {
        internal static void ThrowException(int errorCode, string errorMessage = null, string paramName = null)
        {
            RecorderError err = (RecorderError)errorCode;
            if(string.IsNullOrEmpty(errorMessage)) {
                errorMessage = err.ToString();
            }
            switch((RecorderError)errorCode) {
            case RecorderError.InvalidParameter:
                throw new ArgumentException(errorMessage, paramName);

            case RecorderError.InvalidState:
            case RecorderError.OutOfMemory:
            case RecorderError.ErrorDevice:
            case RecorderError.InvalidOperation:
            case RecorderError.SoundPolicy:
            case RecorderError.SecurityRestricted:
            case RecorderError.SoundPolicyByCall:
            case RecorderError.SoundPolicyByAlarm:
            case RecorderError.Esd:
            case RecorderError.OutOfStorage:
            case RecorderError.PermissionDenied:
            case RecorderError.NotSupported:
            case RecorderError.ResourceConflict:
                throw new InvalidOperationException(errorMessage);
            }
        }
    }
}

