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
    internal enum ScreenMirroringError
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidOperation = ErrorCode.InvalidOperation,
        ConnectionTimeOut = ErrorCode.ConnectionTimeout,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported,
        Unknown = ErrorCode.Unknown
    };
    public class ScreenMirroringErrorFactory
    {
        private const string LogTag = "Tizen.Multimedia.ScreenMirroring";
        internal static void ThrowException(int errorCode, string errorMessage = null)
        {
            ScreenMirroringError err = (ScreenMirroringError)errorCode;

            if (err == ScreenMirroringError.None)
            {
                return;
            }

            Log.Error(LogTag,"errorCode is : " + errorCode);
            if (string.IsNullOrEmpty(errorMessage))
            {
                errorMessage = err.ToString();
            }

            switch (err)
            {
                case ScreenMirroringError.InvalidParameter:
                    throw new ArgumentException(errorMessage);

                case ScreenMirroringError.OutOfMemory:
                    throw new OutOfMemoryException(errorMessage);

                case ScreenMirroringError.PermissionDenied:
                    throw new UnauthorizedAccessException(errorMessage);

                case ScreenMirroringError.NotSupported:
                    throw new NotSupportedException(errorMessage);

                case ScreenMirroringError.ConnectionTimeOut:
                case ScreenMirroringError.InvalidOperation:
                    throw new InvalidOperationException(errorMessage);

                default:
                    throw new Exception("Unknown error : " + errorCode);
            }
        }
    }
}

