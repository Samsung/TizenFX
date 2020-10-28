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

namespace Tizen.Network.Mtp
{
    static internal class MtpErrorValue
    {
        internal const int Base = -0x01CC0000;
    }

    /// <summary>
    /// Enumeration for Mtp Error.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum MtpError
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
        /// Out of memory.
        /// </summary>
        OutOfMemoryError = ErrorCode.OutOfMemory,
        /// <summary>
        /// Permission Denied.
        /// </summary>
        PermissionDeniedError = ErrorCode.PermissionDenied,
        /// <summary>
        /// Not Supported.
        /// </summary>
        NotSupportedError = ErrorCode.NotSupported,
        /// <summary>
        /// Not available communication with Mtp framework.
        /// </summary>
        CommunicationError = MtpErrorValue.Base | 0x01,
        /// <summary>
        /// Controller Error.
        /// </summary>
        ControllerError = MtpErrorValue.Base | 0x02,
        /// <summary>
        /// No device.
        /// </summary>
        NoDeviceError = MtpErrorValue.Base | 0x03,
        /// <summary>
        /// Not Initialized.
        /// </summary>
        NotInitializedError = MtpErrorValue.Base | 0x04,
        /// <summary>
        /// Not Activated.
        /// </summary>
        NotActivatedError = MtpErrorValue.Base | 0x05,
        /// <summary>
        /// Not Activated Communication.
        /// </summary>
        NotActivatedCommunicationError = MtpErrorValue.Base | 0x06,
        /// <summary>
        /// Plugin Fail.
        /// </summary>
        PluginFailError = MtpErrorValue.Base | 0x07
    }

    internal static class MtpErrorFactory
    {
        static internal void ThrowMtpException(int e)
        {
            ThrowException(e, false);
        }

        static internal void ThrowMtpException(int e, int handle)
        {
            ThrowException(e, (handle < 0));
        }

        static private void ThrowException(int e, bool isHandleNull)
        {
            MtpError err = (MtpError)e;

            if (isHandleNull)
            {
                throw new InvalidOperationException("Invalid instance (object may have been disposed or released)");
            }

            if (err == MtpError.InvalidParameterError)
            {
                throw new ArgumentException(err.ToString());
            }
            else if (err == MtpError.NotSupportedError)
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
