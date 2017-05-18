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
    /// <summary>
    /// Enumeration for thumbnail extractor's error codes.
    /// </summary>
    internal enum ThumbnailExtractorError
    {
        None = ErrorCode.None,                          // Success
        InvalidParameter = ErrorCode.InvalidParameter,  // Invalid parameter
        OutOfMemory = ErrorCode.OutOfMemory,            // Out of memory
        InvalidOperation = ErrorCode.InvalidOperation,  // Invalid operation
        FileNoSpaceOnDevice = ErrorCode.FileNoSpaceOnDevice,  // No space left on device
        PermissionDenied = ErrorCode.PermissionDenied,  // Permission deny
        TizenThumbnailUtilError = -0x02F90000,
        UnsupportedContent = TizenThumbnailUtilError | 0x01,  // Unsupported content
    };

    internal static class ThumbnailExtractorErrorFactory
    {
        internal static void ThrowIfError(ThumbnailExtractorError errorCode, string errorMessage)
        {
            switch (errorCode)
            {
                case ThumbnailExtractorError.InvalidParameter:
                    throw new ArgumentException("[" + errorCode.ToString() + "]" + errorMessage);

                case ThumbnailExtractorError.OutOfMemory:
                    throw new OutOfMemoryException("[" + errorCode.ToString() + "]" + errorMessage);

                case ThumbnailExtractorError.InvalidOperation:
                    throw new InvalidOperationException("[" + errorCode.ToString() + "]" + errorMessage);

                case ThumbnailExtractorError.FileNoSpaceOnDevice:
                    throw new IOException("[" + errorCode.ToString() + "] No space to write on the device");

                case ThumbnailExtractorError.PermissionDenied:
                    throw new UnauthorizedAccessException("[" + errorCode.ToString() + "]" + errorMessage);
            }
        }
    }
}

