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

namespace Tizen.Multimedia.Vision
{
    internal static class MediaVisionLog
    {
        internal const string Tag = "Tizen.Multimedia.MediaVision";
    }

    /// <summary>
    /// Enumeration for media vision's error codes.
    /// </summary>
    internal enum MediaVisionError
    {
        MediaVisionErrorCode = -0x019D0000,
        /// <summary>
        /// Successful.
        /// </summary>
        None = ErrorCode.None,
        /// <summary>
        /// Not supported.
        /// </summary>
        NotSupported = ErrorCode.NotSupported,
        /// <summary>
        /// Message too long.
        /// </summary>
        MsgTooLong = ErrorCode.MsgTooLong,
        /// <summary>
        /// No data.
        /// </summary>
        NoData = ErrorCode.NoData,
        /// <summary>
        /// Key not available.
        /// </summary>
        KeyNotAvailable = ErrorCode.KeyNotAvailable,
        /// <summary>
        /// Out of memory.
        /// </summary>
        OutOfMemory = ErrorCode.OutOfMemory,
        /// <summary>
        /// Invalid parameter.
        /// </summary>
        InvalidParameter = ErrorCode.InvalidParameter,
        /// <summary>
        /// Invalid operation.
        /// </summary>
        InvalidOperation = ErrorCode.InvalidOperation,
        /// <summary>
        /// Permission denied.
        /// </summary>
        PermissionDenied = ErrorCode.NotPermitted,
        /// <summary>
        /// Not supported format.
        /// </summary>
        NotSupportedFormat = MediaVisionErrorCode | 0x01,
        /// <summary>
        /// Internal error
        /// </summary>
        Internal = MediaVisionErrorCode | 0x02,
        /// <summary>
        /// Invalid data.
        /// </summary>
        InvalidData = MediaVisionErrorCode | 0x03,
        /// <summary>
        /// Invalid path (Since 3.0).
        /// </summary>
        InvalidPath = MediaVisionErrorCode | 0x04,
        /// <summary>
        /// Not supported engine.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        NotSupportedEngine = MediaVisionErrorCode | 0x05
    }

    internal static class MediaVisionErrorExtensions
    {
        public static void Validate(this MediaVisionError error, string msg)
        {
            if (error == MediaVisionError.None)
            {
                return;
            }

            switch (error)
            {
                case MediaVisionError.NotSupported:
                case MediaVisionError.NotSupportedEngine:
                    throw new NotSupportedException(msg);
                case MediaVisionError.MsgTooLong:
                    throw new ArgumentException($"{msg} : Message too long.");
                case MediaVisionError.NoData:
                    throw new InvalidOperationException($"{msg} : No Data.");
                case MediaVisionError.KeyNotAvailable:
                    throw new ArgumentException($"{msg} : Key Not Available.");
                case MediaVisionError.OutOfMemory:
                    throw new OutOfMemoryException($"{msg} : Out of Memory.");
                case MediaVisionError.InvalidParameter:
                    throw new ArgumentException($"{msg} : Invalid argument.");
                case MediaVisionError.InvalidOperation:
                    throw new InvalidOperationException($"{msg} : Invalid Operation.");
                case MediaVisionError.PermissionDenied:
                    throw new UnauthorizedAccessException($"{msg} : Permission Denied.");
                case MediaVisionError.NotSupportedFormat:
                    throw new NotSupportedException($"{msg} : Not Supported Format.");
                case MediaVisionError.Internal:
                    throw new InvalidOperationException($"{msg} : Internal Error.");
                case MediaVisionError.InvalidData:
                    throw new ArgumentException($"{msg} : Invalid Data.");
                case MediaVisionError.InvalidPath:
                    throw new FileNotFoundException($"{msg} : Invalid Path.");
                default:
                    throw new InvalidOperationException($"{msg} : Unknown Error.");
            }
        }
    }
}
