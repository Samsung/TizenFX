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

namespace Tizen.PhonenumberUtils
{
    internal enum PhonenumberUtilsError
    {
        None = ErrorCode.None,
        IoError = ErrorCode.IoError,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidParameter = ErrorCode.InvalidParameter,
        FileNoSpaceOnDevice = ErrorCode.FileNoSpaceOnDevice,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported,
        NoData = ErrorCode.NoData,
        System = -0x02020000 | 0xEF,
    }

    static internal class Globals
    {
        internal const string LogTag = "Tizen.PhonenumberUtils";
    }

    internal static class PhonenumberUtilsErrorFactory
    {
        static internal void ThrowPhonenumberUtilsException(int e)
        {
            PhonenumberUtilsError err = (PhonenumberUtilsError)e;

            switch (err)
            {
                case PhonenumberUtilsError.InvalidParameter:
                    throw new ArgumentException(err.ToString());
                case PhonenumberUtilsError.NotSupported:
                    throw new NotSupportedException(err.ToString());
                case PhonenumberUtilsError.PermissionDenied:
                    throw new UnauthorizedAccessException(err.ToString());
                case PhonenumberUtilsError.OutOfMemory:
                    throw new OutOfMemoryException(err.ToString());
                default:
                    throw new InvalidOperationException(err.ToString());
            }
        }
    }
}
