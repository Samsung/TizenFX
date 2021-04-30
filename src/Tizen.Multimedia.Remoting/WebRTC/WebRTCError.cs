/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Multimedia.Remoting
{
    internal enum WebRTCErrorCode
    {
        None = ErrorCode.None,
        FeatureNotSupported = ErrorCode.NotSupported,
        PermissionDenied = ErrorCode.PermissionDenied,
        InvalidArgument = ErrorCode.InvalidParameter,
        InvalidOperation = ErrorCode.InvalidOperation,
        TizenWebRTCError = -0x03000000,
        InvalidState = TizenWebRTCError | 0x01,
        ConnectionFailed = TizenWebRTCError | 0x02,
        StreamFailed = TizenWebRTCError | 0x03,
        ResourceFailed = TizenWebRTCError | 0x04,
        ResourceConflict = TizenWebRTCError | 0x05
    }

    internal static class WebRTCErrorCodeExtensions
    {
        internal static void ThrowIfFailed(this WebRTCErrorCode errorCode, string message)
        {
            if (errorCode == WebRTCErrorCode.None)
                return;

            string errMessage = (message ?? "Operation failed") + " : " + errorCode.ToString() + ".";

            switch (errorCode)
            {
                case WebRTCErrorCode.FeatureNotSupported:
                    throw new NotSupportedException(errMessage);
                case WebRTCErrorCode.InvalidState:
                case WebRTCErrorCode.ConnectionFailed:
                case WebRTCErrorCode.StreamFailed:
                case WebRTCErrorCode.ResourceFailed:
                case WebRTCErrorCode.ResourceConflict:
                case WebRTCErrorCode.InvalidOperation:
                    throw new InvalidOperationException(errMessage);
                case WebRTCErrorCode.InvalidArgument:
                    throw new ArgumentException(errMessage);
                case WebRTCErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException(errMessage);
            }
        }
    }
}

