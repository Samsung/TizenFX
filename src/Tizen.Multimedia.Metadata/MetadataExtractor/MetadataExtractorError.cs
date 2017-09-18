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
    /// Enumeration for the metadata extractor's error codes.
    /// </summary>
    internal enum MetadataExtractorError
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        OutOfMemory = ErrorCode.OutOfMemory,
        FileExists = ErrorCode.FileExists,
        PermissionDenied = ErrorCode.PermissionDenied,
        TizenMetadataExtractorError = -0x01930000,
        OperationFailed = TizenMetadataExtractorError | 0x01  // Invalid operation
    }

    internal static class MetadataExtractorRetValidator
    {
        internal static void ThrowIfError(MetadataExtractorError error, string errorMessage)
        {
            switch (error)
            {
                case MetadataExtractorError.InvalidParameter:
                    throw new ArgumentException(errorMessage);

                case MetadataExtractorError.FileExists:
                    throw new FileNotFoundException(errorMessage);

                case MetadataExtractorError.PermissionDenied:
                    throw new UnauthorizedAccessException(errorMessage);

                case MetadataExtractorError.OutOfMemory:
                    throw new OutOfMemoryException();

                case MetadataExtractorError.OperationFailed:
                    throw new InvalidOperationException(errorMessage);
            }
        }
    }
}

