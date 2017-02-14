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
    /// Enumeration for metadata extractor's error codes.
    /// </summary>
    internal enum MetadataEditorError
    {
        None = ErrorCode.None,                          // Success
        InvalidParameter = ErrorCode.InvalidParameter,  // Invalid parameter
        OutOfMemory = ErrorCode.OutOfMemory,            // Out of memory
        FileNotExists = ErrorCode.FileExists,              // File does not exist
        PermissionDenied = ErrorCode.PermissionDenied,  // Permission deny
        NotSupported = ErrorCode.NotSupported,          // Unsupported type
        TizenMetadataEditorError = -0x019C0000,
        OperationFailed = TizenMetadataEditorError | 0x01  // Invalid operation
    };

    internal static class MetadataEditorErrorFactory
    {
        internal static void ThrowIfError(MetadataEditorError errorCode, string errorMessage)
        {
            switch (errorCode)
            {
                case MetadataEditorError.InvalidParameter:
                    throw new ArgumentException(errorMessage);

                case MetadataEditorError.OutOfMemory:
                    throw new OutOfMemoryException(errorMessage);

                case MetadataEditorError.FileNotExists:
                    throw new FileNotFoundException(errorMessage);

                case MetadataEditorError.PermissionDenied:
                    throw new UnauthorizedAccessException(errorMessage);

                case MetadataEditorError.NotSupported:
                    throw new NotSupportedException(errorMessage);

                case MetadataEditorError.OperationFailed:
                    throw new InvalidOperationException(errorMessage);
            }
        }
    }
}

