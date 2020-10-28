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

namespace Tizen.Multimedia.Util
{
    internal enum ThumbnailExtractorError
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidOperation = ErrorCode.InvalidOperation,
        FileNoSpaceOnDevice = ErrorCode.FileNoSpaceOnDevice,
        PermissionDenied = ErrorCode.PermissionDenied,
        TizenThumbnailUtilError = -0x02F90000,
        UnsupportedContent = TizenThumbnailUtilError | 0x01,
    };

    internal static class ThumbnailExtractorErrorExtensions
    {
        internal static void ThrowIfError(this ThumbnailExtractorError errorCode, string errorMessage)
        {
            if (errorCode == ThumbnailExtractorError.None)
            {
                return;
            }

            throw errorCode.ToException(errorMessage);
        }

        internal static Exception ToException(this ThumbnailExtractorError errorCode, string errorMessage)
        {
            switch (errorCode)
            {
                case ThumbnailExtractorError.InvalidParameter:
                    return new ArgumentException(errorMessage);

                case ThumbnailExtractorError.OutOfMemory:
                    return new OutOfMemoryException(errorMessage);

                case ThumbnailExtractorError.InvalidOperation:
                    return new InvalidOperationException(errorMessage);

                case ThumbnailExtractorError.FileNoSpaceOnDevice:
                    return new IOException("No space to write on the device.");

                case ThumbnailExtractorError.PermissionDenied:
                    return new UnauthorizedAccessException("[" + errorCode.ToString() + "]" + errorMessage);

                case ThumbnailExtractorError.UnsupportedContent:
                    return new FileFormatException(errorMessage);
            }

            return new InvalidOperationException("[" + errorCode.ToString() + "]" + errorMessage);
        }
    }
}

