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
    internal enum AudioIOError
    {
        None = ErrorCode.None,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidParameter = ErrorCode.InvalidParameter,
        InvalidOperation = ErrorCode.InvalidOperation,
        PermissionDenied = ErrorCode.PermissionDenied,      //Device open error by security
        NotSupported = ErrorCode.NotSupported,          //Not supported
        DevicePolicyRestriction = (-2147483648 / 2) + 4,
        DeviceNotOpened = -0x01900000 | 0x01,
        DeviceNotClosed = -0x01900000 | 0x02,
        InvalidBuffer = -0x01900000 | 0x03,
        SoundPolicy = -0x01900000 | 0x04,
        InvalidState = -0x01900000 | 0x05,
        NotSupportedType = -0x01900000 | 0x06,
    }

    internal static class AudioIOErrorCodeExtensions
    {
        internal static void ThrowIfFailed(this AudioIOError errorCode, string message)
        {
            if (errorCode == AudioIOError.None || !Enum.IsDefined(typeof(AudioIOError), errorCode))
            {
                return;
            }

            string errorMessage = $"{ (message ?? "Operation failed") } : { errorCode.ToString() }.";

            switch(errorCode)
            {
                case AudioIOError.OutOfMemory:
                case AudioIOError.InvalidParameter:
                    throw new ArgumentException(errorMessage);

                case AudioIOError.DevicePolicyRestriction:
                case AudioIOError.PermissionDenied:
                    throw new UnauthorizedAccessException(errorMessage);

                case AudioIOError.SoundPolicy:
                    throw new AudioPolicyException(errorMessage);

                case AudioIOError.NotSupported:
                case AudioIOError.NotSupportedType:
                    throw new NotSupportedException(errorMessage);

                case AudioIOError.DeviceNotOpened:
                case AudioIOError.DeviceNotClosed:
                case AudioIOError.InvalidBuffer:
                case AudioIOError.InvalidOperation:
                case AudioIOError.InvalidState:
                    throw new InvalidOperationException(errorMessage);

                default:
                    throw new InvalidOperationException($"{message} : Unknown error({errorCode.ToString()}).");
            }
        }
    }
}
