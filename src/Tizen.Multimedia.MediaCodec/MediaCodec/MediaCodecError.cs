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

namespace Tizen.Multimedia.MediaCodec
{
    internal enum MediaCodecErrorCode
    {
        CodecDefinedBase = -0x019B0000,

        None = ErrorCode.None,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidParameter = ErrorCode.InvalidParameter,
        InvalidOperation = ErrorCode.InvalidOperation,
        NotSupportedOnDevice = ErrorCode.NotSupported,
        PermissionDenied = ErrorCode.PermissionDenied,

        InvalidState = CodecDefinedBase | 0x01,
        InvalidInBuffer = CodecDefinedBase | 0x02,
        InvalidOutBuffer = CodecDefinedBase | 0x03,
        Internal = CodecDefinedBase | 0x04,
        NotInitialized = CodecDefinedBase | 0x05,
        InvalidStream = CodecDefinedBase | 0x06,
        CodecNotFound = CodecDefinedBase | 0x07,
        DecodingError = CodecDefinedBase | 0x08,
        OutOfStorage = CodecDefinedBase | 0x09,
        StreamNotFound = CodecDefinedBase | 0x0a,
        NotSupportedFormat = CodecDefinedBase | 0x0b,
        NoAvailableBuffer = CodecDefinedBase | 0x0c,
        OverflowInBuffer = CodecDefinedBase | 0x0d,
    }

    /// <summary>
    /// Specifies the errors of <see cref="MediaCodec"/>.
    /// </summary>
    /// <seealso cref="MediaCodec.ErrorOccurred"/>
    /// <since_tizen> 3 </since_tizen>
    public enum MediaCodecError
    {
        /// <summary>
        /// The format is not supported.
        /// </summary>
        NotSupportedFormat = MediaCodecErrorCode.NotSupportedFormat,

        /// <summary>
        /// An internal error.
        /// </summary>
        InternalError = MediaCodecErrorCode.Internal,

        /// <summary>
        /// Not enough storage.
        /// </summary>
        OutOfStorage = MediaCodecErrorCode.OutOfStorage,

        /// <summary>
        /// The stream is invalid.
        /// </summary>
        InvalidStream = MediaCodecErrorCode.InvalidStream,
    }

    internal static class MediaCodecErrorExtensions
    {
        internal static void ThrowIfFailed(this MediaCodecErrorCode errorCode, string message)
        {
            if (errorCode == MediaCodecErrorCode.None)
            {
                return;
            }

            string msg = $"{ (message ?? "Operation failed") } : { errorCode.ToString() }.";

            switch (errorCode)
            {
                case MediaCodecErrorCode.OutOfMemory:
                    throw new OutOfMemoryException(msg);

                case MediaCodecErrorCode.InvalidParameter:
                    throw new ArgumentException(msg);

                case MediaCodecErrorCode.CodecNotFound:
                case MediaCodecErrorCode.DecodingError:
                case MediaCodecErrorCode.InvalidOperation:
                case MediaCodecErrorCode.InvalidState:
                case MediaCodecErrorCode.InvalidInBuffer:
                case MediaCodecErrorCode.InvalidOutBuffer:
                case MediaCodecErrorCode.Internal:
                case MediaCodecErrorCode.NotInitialized:
                case MediaCodecErrorCode.InvalidStream:
                case MediaCodecErrorCode.StreamNotFound:
                    throw new InvalidOperationException(msg);

                case MediaCodecErrorCode.NotSupportedOnDevice:
                case MediaCodecErrorCode.NotSupportedFormat:
                    throw new NotSupportedException(msg);

                case MediaCodecErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException(msg);

                case MediaCodecErrorCode.OutOfStorage:
                    throw new IOException($"{msg}; Not enough disk space or specified path is not available to .");

                case MediaCodecErrorCode.NoAvailableBuffer:
                case MediaCodecErrorCode.OverflowInBuffer:
                    throw new InternalBufferOverflowException(msg);

                default:
                    throw new Exception($"Unknown error : {errorCode.ToString()}.");
            }
        }
    }
}
