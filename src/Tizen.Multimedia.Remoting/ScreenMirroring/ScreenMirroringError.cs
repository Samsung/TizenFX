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
using System.Diagnostics;
using Tizen.Internals.Errors;

namespace Tizen.Multimedia.Remoting
{
    internal enum ScreenMirroringErrorCode
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidOperation = ErrorCode.InvalidOperation,
        ConnectionTimeOut = ErrorCode.ConnectionTimeout,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported,
        Unknown = ErrorCode.Unknown
    }

    internal static class ScreenMirroringErrorExtensions
    {
        internal static void ThrowIfError(this ScreenMirroringErrorCode err, string message)
        {
            if (err == ScreenMirroringErrorCode.None)
            {
                return;
            }

            throw err.AsException(message);
        }

        internal static Exception AsException(this ScreenMirroringErrorCode err, string message)
        {
            Debug.Assert(err != ScreenMirroringErrorCode.None);

            switch (err)
            {
                case ScreenMirroringErrorCode.InvalidParameter:
                    return new ArgumentException(message);

                case ScreenMirroringErrorCode.OutOfMemory:
                    return new OutOfMemoryException(message);

                case ScreenMirroringErrorCode.PermissionDenied:
                    return new UnauthorizedAccessException(message);

                case ScreenMirroringErrorCode.NotSupported:
                    return new NotSupportedException(message);

                case ScreenMirroringErrorCode.InvalidOperation:
                    return new InvalidOperationException(message);

                case ScreenMirroringErrorCode.ConnectionTimeOut:
                    return new TimeoutException(message);

                default:
                    return new InvalidOperationException($"Unknown error : {err.ToString()}.");
            }
        }

        internal static ScreenMirroringError ToCsharp(this ScreenMirroringErrorCode err)
        {
            switch (err)
            {
                case ScreenMirroringErrorCode.InvalidOperation:
                    return ScreenMirroringError.InvalidOperation;

                default:
                    throw new InvalidOperationException($"Unknown error : {err.ToString()}.");
            }
        }
    }
}

