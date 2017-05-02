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
    public enum MtpError
    {
        None = ErrorCode.None,
        IoError = ErrorCode.IoError,
        InvalidParameterError = ErrorCode.InvalidParameter,
        OutOfMemoryError = ErrorCode.OutOfMemory,
        PermissionDeniedError = ErrorCode.PermissionDenied,
        NotSupportedError = ErrorCode.NotSupported,

        CommunicationError = MtpErrorValue.Base | 0x01,
        ControllerError = MtpErrorValue.Base | 0x02,
        NoDeviceError = MtpErrorValue.Base | 0x03,
        NotInitializedError = MtpErrorValue.Base | 0x04,
        NotActivatedError = MtpErrorValue.Base | 0x05,
        NotActivatedCommunicationError = MtpErrorValue.Base | 0x06,
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
