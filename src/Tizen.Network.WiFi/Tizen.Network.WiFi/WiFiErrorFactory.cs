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

namespace Tizen.Network.WiFi
{
    static internal class WiFiErrorValue
    {
        internal const int Base = -0x01CE0000;
    }

    internal enum WiFiError
    {
        None = ErrorCode.None,
        InvalidParameterError = ErrorCode.InvalidParameter,
        OutOfMemoryError = ErrorCode.OutOfMemory,
        InvalidOperationError = ErrorCode.InvalidOperation,
        AddressFamilyNotSupportedError = ErrorCode.AddressFamilyNotSupported,
        OperationFailedError = WiFiErrorValue.Base | 0x01,
        NoConnectionError = WiFiErrorValue.Base | 0x02,
        NowInProgressError = ErrorCode.NowInProgress,
        AlreadyExistsError = WiFiErrorValue.Base | 0x03,
        OperationAbortedError = WiFiErrorValue.Base | 0x04,
        DhcpFailedError = WiFiErrorValue.Base | 0x05,
        InvalidKeyError = WiFiErrorValue.Base | 0x06,
        NoReplyError = WiFiErrorValue.Base | 0x07,
        SecurityRestrictedError = WiFiErrorValue.Base | 0x08,
        PermissionDeniedError = ErrorCode.PermissionDenied,
        NotSupportedError = ErrorCode.NotSupported
    }

    internal static class WiFiErrorFactory
    {
        static internal void ThrowWiFiException(int e, IntPtr handle)
        {
            ThrowException(e, (handle == IntPtr.Zero), false, "");
        }

        static internal void ThrowWiFiException(int e, IntPtr handle1, IntPtr handle2)
        {
            ThrowException(e, (handle1 == IntPtr.Zero), (handle2 == IntPtr.Zero), "");
        }

        static internal void ThrowWiFiException(int e, string message)
        {
            ThrowException(e, false, false, message);
        }

        static internal void ThrowWiFiException(int e, IntPtr handle, string message)
        {
            ThrowException(e, (handle == IntPtr.Zero), false, message);
        }

        static internal void ThrowWiFiException(int e, IntPtr handle1, IntPtr handle2, string message)
        {
            ThrowException(e, (handle1 == IntPtr.Zero), (handle2 == IntPtr.Zero), message);
        }

        static private void ThrowException(int e, bool isHandle1Null, bool isHandle2Null, string message)
        {
            WiFiError err = (WiFiError)e;
            if (err == WiFiError.NotSupportedError)
            {
                throw new NotSupportedException("Unsupported feature http://tizen.org/feature/network.wifi");
            }

            if (err == WiFiError.PermissionDeniedError)
            {
                throw new UnauthorizedAccessException("Permission denied " + message);
            }

            if (err == WiFiError.OutOfMemoryError)
            {
                throw new OutOfMemoryException("Out of memory");
            }

            if (err == WiFiError.InvalidParameterError || err == WiFiError.InvalidKeyError)
            {
                if (isHandle1Null || isHandle2Null)
                {
                    throw new InvalidOperationException("Invalid instance (object may have been disposed or released)");
                }

                throw new ArgumentException("Invalid parameter");
            }

            throw new InvalidOperationException(err.ToString());
        }
    }
}
