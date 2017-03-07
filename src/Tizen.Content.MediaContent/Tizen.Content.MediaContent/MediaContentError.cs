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

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// Enumeration for media content's error code
    /// </summary>
    /// <remarks><paramref name="NotSupported"/> error occurs when the device does not support the function.</remarks>
    public enum MediaContentError
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidOperation = ErrorCode.InvalidOperation,
        FileNoSpaceOnDevice = ErrorCode.FileNoSpaceOnDevice,
        PermissionDenied = ErrorCode.PermissionDenied,
        TizenMediaContentError = -0x01610000,
        DatabaseFailed = TizenMediaContentError | 0x01,
        DatabaseBusy = TizenMediaContentError | 0x02,
        NetworkFailed = TizenMediaContentError | 0x03,
        UnsupportedContent = TizenMediaContentError | 0x04,
        NotSupported = ErrorCode.NotSupported,
    }
    internal class MediaContentRetValidator
    {
        internal const string LogTag = "Tizen.Content.MediaContent";

        internal static void ThrowIfError(MediaContentError err, string msg)
        {
            switch (err)
            {
                case MediaContentError.InvalidParameter:
                    throw new ArgumentException(msg);
                case MediaContentError.OutOfMemory:
                    throw new OutOfMemoryException(msg);
                case MediaContentError.InvalidOperation:
                    throw new InvalidOperationException(msg);
                case MediaContentError.FileNoSpaceOnDevice:
                    throw new IOException(msg);
                case MediaContentError.PermissionDenied:
                    throw new UnauthorizedAccessException(msg);
                case MediaContentError.DatabaseFailed:
                    throw new InvalidOperationException("[DB Failed]" + msg);
                case MediaContentError.DatabaseBusy:
                    throw new InvalidOperationException("[DB Busy]" + msg);
                case MediaContentError.NetworkFailed:
                    throw new InvalidOperationException("[Network Error]" + msg);
                case MediaContentError.UnsupportedContent:
                    throw new PlatformNotSupportedException(msg);
            }
        }
    }
}
