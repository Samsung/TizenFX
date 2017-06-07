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

    internal enum RadioError
    {
        None = ErrorCode.None,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidParameter = ErrorCode.InvalidParameter,
        InvalidOperation = ErrorCode.InvalidOperation,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported,

        InvalidState = -0x019A0000 | 0x01,
        SoundPolicy = -0x019A0000 | 0x02,
        NoAntenna = -0x019A0000 | 0x03,
    }

    internal static class RadioErrorExtesions
    {
        internal static void ThrowIfFailed(this RadioError err, string message)
        {
            if (err == RadioError.None)
            {
                return;
            }

            string errMessage = $"{message}; {err}.";
            switch (err)
            {
                case RadioError.PermissionDenied:
                    throw new UnauthorizedAccessException(errMessage);

                case RadioError.InvalidParameter:
                    throw new ArgumentException(errMessage);

                case RadioError.OutOfMemory:
                    throw new OutOfMemoryException(errMessage);

                case RadioError.NotSupported:
                case RadioError.NoAntenna:
                    throw new NotSupportedException(errMessage);

                default:
                    throw new InvalidOperationException(errMessage);
            }
        }

    }

}
