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
    internal enum WiFiError
    {
        None = ErrorCode.None,
        InvalidParameterError = ErrorCode.InvalidParameter,
        OutOfMemoryError = ErrorCode.OutOfMemory,
        InvalidOperationError = ErrorCode.InvalidOperation,
        AddressFamilyNotSupportedError = ErrorCode.AddressFamilyNotSupported,
        OperationFailedError = -0x01C50000 | 0x0301,
        NoConnectionError = -0x01C50000 | 0x0302,
        NowInProgressError = ErrorCode.NowInProgress,
        AlreadyExistsError = -0x01C50000 | 0x0303,
        OperationAbortedError = -0x01C50000 | 0x0304,
        DhcpFailedError = -0x01C50000 | 0x0306,
        InvalidKeyError = -0x01C50000 | 0x0307,
        NoReplyError = -0x01C50000 | 0x0308,
        SecurityRestrictedError = -0x01C50000 | 0x0309,
        PermissionDeniedError = ErrorCode.PermissionDenied,
        NotSupportedError = ErrorCode.NotSupported
    }

    internal static class WiFiErrorFactory
    {
        static internal void ThrowWiFiException(int e)
        {
            ThrowExcption(e, false);
        }

        static internal void ThrowWiFiException(int e, IntPtr handle)
        {
            ThrowExcption(e, (handle == IntPtr.Zero));
        }

        static private void ThrowExcption(int e, bool isHandleNull)
        {
            WiFiError err = (WiFiError)e;
            if (err == WiFiError.NotSupportedError)
            {
                throw new NotSupportedException("Not Supported");
            }

            if (isHandleNull)
            {
                if (err == WiFiError.InvalidParameterError || err == WiFiError.InvalidKeyError)
                {
                    throw new ArgumentException(err.ToString());
                }
                else
                {
                    throw new InvalidOperationException("Invalid instance (object may have been disposed or released)");
                }
            }

            if (err == WiFiError.InvalidParameterError || err == WiFiError.InvalidKeyError)
            {
                throw new ArgumentException(err.ToString());
            }
            else
            {
                throw new InvalidOperationException(err.ToString());
            }
        }
    }
}
