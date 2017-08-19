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
using System.IO;
using Tizen.Internals.Errors;

namespace Tizen.Multimedia
{
    internal enum StreamRecorderErrorCode
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        TizenErrorStreamRecorder = -0x01A10000,
        InvalidState = TizenErrorStreamRecorder | 0x01,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidOperation = ErrorCode.InvalidOperation,
        OutOfStorage = TizenErrorStreamRecorder | 0x02,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported,
    }

    internal static class StreamRecorderErrorExtensions
    {
        internal static StreamRecorderErrorCode Ignore(this StreamRecorderErrorCode errorCode, StreamRecorderErrorCode ignore)
        {
            return (ignore == errorCode) ? StreamRecorderErrorCode.None : errorCode;
        }

        internal static void ThrowIfError(this StreamRecorderErrorCode err, string errorMessage)
        {
            if (err == StreamRecorderErrorCode.None)
            {
                return;
            }

            switch (err)
            {
                case StreamRecorderErrorCode.InvalidParameter:
                    throw new ArgumentException(errorMessage);

                case StreamRecorderErrorCode.OutOfMemory:
                    throw new OutOfMemoryException(errorMessage);

                case StreamRecorderErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException(errorMessage);

                case StreamRecorderErrorCode.NotSupported:
                    throw new NotSupportedException(errorMessage);

                case StreamRecorderErrorCode.InvalidState:
                case StreamRecorderErrorCode.InvalidOperation:
                    throw new InvalidOperationException(errorMessage);

                case StreamRecorderErrorCode.OutOfStorage:
                    throw new IOException(errorMessage);
            }
        }
    }
}

