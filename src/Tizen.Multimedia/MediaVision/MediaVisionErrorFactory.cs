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
        /// Successful
        /// </summary>
        None = ErrorCode.None,
        /// <summary>
        /// Not supported
        /// </summary>
        NotSupported = ErrorCode.NotSupported,
        /// <summary>
        /// Message too long
        /// </summary>
        MsgTooLong = ErrorCode.MsgTooLong,
        /// <summary>
        /// No data
        /// </summary>
        NoData = ErrorCode.NoData,
        /// <summary>
        /// Key not available
        /// </summary>
        KeyNotAvailable = ErrorCode.KeyNotAvailable,
        /// <summary>
        /// Out of memory
        /// </summary>
        OutOfMemory = ErrorCode.OutOfMemory,
        /// <summary>
        /// Invalid parameter
        /// </summary>
        InvalidParameter = ErrorCode.InvalidParameter,
        /// <summary>
        /// Invalid operation
        /// </summary>
        InvalidOperation = ErrorCode.InvalidOperation,
        /// <summary>
        /// Permission denied
        /// </summary>
        PermissionDenied = ErrorCode.PermissionDenied,
        /// <summary>
        /// Not supported format
        /// </summary>
        NotSupportedFormat = MediaVisionErrorCode | 0x01,
        /// <summary>
        /// Internal error
        /// </summary>
        Internal = MediaVisionErrorCode | 0x02,
        /// <summary>
        /// Invalid data
        /// </summary>
        InvalidData = MediaVisionErrorCode | 0x03,
        /// <summary>
        /// Invalid path (Since 3.0)
        /// </summary>
        InvalidPath = MediaVisionErrorCode | 0x04
    }

    internal static class MediaVisionErrorFactory
    {
        internal static void CheckAndThrowException(int error, string msg)
        {
            MediaVisionError e = (MediaVisionError)error;
            if (e != MediaVisionError.None)
            {
                Log.Error(MediaVisionLog.Tag, String.Format("{0} : {1}", e.ToString(), msg));
                throw GetException(error, msg);
            }
        }

        internal static Exception GetException(int err, string msg)
        {
            MediaVisionError e = (MediaVisionError)err;
            switch (e)
            {
                case MediaVisionError.None:
                    return null;
                case MediaVisionError.NotSupported:
                    throw new NotSupportedException("Not Supported: " + msg);
                case MediaVisionError.MsgTooLong:
                    throw new InvalidOperationException("Message too long: " + msg);
                case MediaVisionError.NoData:
                    throw new InvalidOperationException("No Data: " + msg);
                case MediaVisionError.KeyNotAvailable:
                    throw new InvalidOperationException("Key Not Available: " + msg);
                case MediaVisionError.OutOfMemory:
                    throw new OutOfMemoryException("Out of Memory: " + msg);
                case MediaVisionError.InvalidParameter:
                    throw new ArgumentException("Invalid Parameter: " + msg);
                case MediaVisionError.InvalidOperation:
                    throw new InvalidOperationException("Invalid Opertation: " + msg);
                case MediaVisionError.PermissionDenied:
                    throw new UnauthorizedAccessException("Permission Denied: " + msg);
                case MediaVisionError.NotSupportedFormat:
                    throw new InvalidOperationException("Not Supported Format: " + msg);
                case MediaVisionError.Internal:
                    throw new InvalidOperationException("Internal Error: " + msg);
                case MediaVisionError.InvalidData:
                    throw new InvalidOperationException("Invalid Data: " + msg);
                case MediaVisionError.InvalidPath:
                    throw new InvalidOperationException("Invalid Path: " + msg);
                default:
                    throw new InvalidOperationException("Unknown Error: " + msg);
            }
        }
    }
}
