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

namespace Tizen.Network.Smartcard
{
    internal enum SmartcardError
    {
        None = ErrorCode.None,
        IoError = ErrorCode.IoError,
        InvalidParameterError = ErrorCode.InvalidParameter,
        PermissionDeniedError = ErrorCode.PermissionDenied,
        NotSupportedError = ErrorCode.NotSupported,
        GeneralError = -0x01C70000 | 0x01,
        NoSuchElementError = -0x01C70000 | 0x02,
        IllegalStateError = -0x01C70000 | 0x03,
        IllegalReferenceError = -0x01C70000 | 0x04,
        OperationNotSupportError = -0x01C70000 | 0x05,
        ChannelNotAvailableError = -0x01C70000 | 0x06,
        NotInitializedError = -0x01C70000 | 0x07
    }

    internal static class SmartcardErrorFactory
    {
        static internal void ThrowSmartcardException(int e)
        {
            ThrowException(e, false);
        }

        static internal void ThrowSmartcardException(int e, int handle)
        {
            ThrowException(e, (handle < 0));
        }

        static private void ThrowException(int e, bool isHandleNull)
        {
            SmartcardError err = (SmartcardError)e;

            if (isHandleNull)
            {
                throw new InvalidOperationException("Invalid instance (object may have been disposed or released)");
            }

            if (err == SmartcardError.InvalidParameterError)
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
