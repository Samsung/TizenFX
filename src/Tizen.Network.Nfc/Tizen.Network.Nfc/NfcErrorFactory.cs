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

namespace Tizen.Network.Nfc
{
    /// <summary>
    /// Enumeration for Nfc Error.
    /// </summary>
    public enum NfcError
    {
        None = ErrorCode.None,
        IoError = ErrorCode.IoError,
        InvalidParameterError = ErrorCode.InvalidParameter,
        OutOfMemoryError = ErrorCode.OutOfMemory,
        TimedOutError = ErrorCode.TimedOut,
        DeviceBusyError = ErrorCode.ResourceBusy,
        NotSupportedError = ErrorCode.NotSupported,
        PermissionDeniedError = ErrorCode.PermissionDenied,
        OperationFailedError = -0x01C20000 | 0x01,
        InvalidNdefMessageError = -0x01C20000 | 0x02,
        InvalidRecordTypeError = -0x01C20000 | 0x03,
        NoDeviceError = -0x01C20000 | 0x04,
        NotActivatedError = -0x01C20000 | 0x05,
        AlreadyActivatedError = -0x01C20000 | 0x06,
        AlreadyDeactivatedError = -0x01C20000 | 0x07,
        ReadOnlyNdefError = -0x01C20000 | 0x08,
        NoSpaceOnNdefError = -0x01C20000 | 0x09,
        NoNdefMessageError = -0x01C20000 | 0x0a,
        NotNdefFormatError = -0x01C20000 | 0x0b,
        SecurityRestrictedError = -0x01C20000 | 0x0c,
        IllegalStateError = -0x01C20000 | 0x0d,
        NotInitializedError = -0x01C20000 | 0x0e,
        TagNotSupportedError = -0x01C20000 | 0x0f,
        AidAlreadyRegisteredError = -0x01C20000 | 0x10
    }

    internal static class NfcErrorFactory
    {
        static internal void ThrowNfcException(int e)
        {
            ThrowException(e, false);
        }

        static internal void ThrowNfcException(int e, int handle)
        {
            ThrowException(e, (handle < 0));
        }

        static private void ThrowException(int e, bool isHandleNull)
        {
            NfcError err = (NfcError)e;

            if (isHandleNull)
            {
                throw new InvalidOperationException("Invalid instance (object may have been disposed or released)");
            }

            if (err == NfcError.InvalidParameterError)
            {
                throw new ArgumentException(err.ToString());
            }
            else if (err == NfcError.NotSupportedError)
            {
                throw new NotSupportedException();
            }
            else
            {
                throw new InvalidOperationException(err.ToString());
            }
        }

    }
}
