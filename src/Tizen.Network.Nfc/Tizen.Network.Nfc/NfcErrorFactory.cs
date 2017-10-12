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
    /// Enumeration for the NFC Error.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum NfcError
    {
        /// <summary>
        /// Successful.
        /// </summary>
        None = ErrorCode.None,
        /// <summary>
        /// I/O Error.
        /// </summary>
        IoError = ErrorCode.IoError,
        /// <summary>
        /// Invalid Parameter.
        /// </summary>
        InvalidParameterError = ErrorCode.InvalidParameter,
        /// <summary>
        /// Out of Memory.
        /// </summary>
        OutOfMemoryError = ErrorCode.OutOfMemory,
        /// <summary>
        /// Timed Out.
        /// </summary>
        TimedOutError = ErrorCode.TimedOut,
        /// <summary>
        /// Device Busy.
        /// </summary>
        DeviceBusyError = ErrorCode.ResourceBusy,
        /// <summary>
        /// Not Supported.
        /// </summary>
        NotSupportedError = ErrorCode.NotSupported,
        /// <summary>
        /// Permission Denied.
        /// </summary>
        PermissionDeniedError = ErrorCode.PermissionDenied,
        /// <summary>
        /// Operation Failed.
        /// </summary>
        OperationFailedError = -0x01C20000 | 0x01,
        /// <summary>
        /// Invalied Ndef Message.
        /// </summary>
        InvalidNdefMessageError = -0x01C20000 | 0x02,
        /// <summary>
        /// Invalid Record Type.
        /// </summary>
        InvalidRecordTypeError = -0x01C20000 | 0x03,
        /// <summary>
        /// No Device.
        /// </summary>
        NoDeviceError = -0x01C20000 | 0x04,
        /// <summary>
        /// Not Activated.
        /// </summary>
        NotActivatedError = -0x01C20000 | 0x05,
        /// <summary>
        /// Already Activated.
        /// </summary>
        AlreadyActivatedError = -0x01C20000 | 0x06,
        /// <summary>
        /// Already Deactivated.
        /// </summary>
        AlreadyDeactivatedError = -0x01C20000 | 0x07,
        /// <summary>
        /// Read Only Ndef.
        /// </summary>
        ReadOnlyNdefError = -0x01C20000 | 0x08,
        /// <summary>
        /// No Space On Ndef.
        /// </summary>
        NoSpaceOnNdefError = -0x01C20000 | 0x09,
        /// <summary>
        /// No Ndef Message
        /// </summary>
        NoNdefMessageError = -0x01C20000 | 0x0a,
        /// <summary>
        /// No Ndef Format
        /// </summary>
        NotNdefFormatError = -0x01C20000 | 0x0b,
        /// <summary>
        /// Security Restricted
        /// </summary>
        SecurityRestrictedError = -0x01C20000 | 0x0c,
        /// <summary>
        /// Illegal State
        /// </summary>
        IllegalStateError = -0x01C20000 | 0x0d,
        /// <summary>
        /// Not Initialized
        /// </summary>
        NotInitializedError = -0x01C20000 | 0x0e,
        /// <summary>
        /// Tag Not Supported
        /// </summary>
        TagNotSupportedError = -0x01C20000 | 0x0f,
        /// <summary>
        /// Aid Already Registered
        /// </summary>
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
