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
using System.Diagnostics;
using System.IO;
using System.Linq;
using Tizen.Internals.Errors;

namespace Tizen.Content.MediaContent
{
    internal enum MediaContentError
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

    internal static class MediaContentErrorExtensions
    {
        internal static MediaContentError Ignore(this MediaContentError err, params MediaContentError[] ignores)
        {
            if (ignores.Contains(err))
            {
                return MediaContentError.None;
            }
            return err;
        }


        internal static void ThrowIfError(this MediaContentError err, string msg)
        {
            if (err == MediaContentError.None)
            {
                return;
            }

            throw err.AsException(msg);
        }

        internal static Exception AsException(this MediaContentError err, string msg)
        {
            Debug.Assert(err != MediaContentError.None);

            switch (err)
            {
                case MediaContentError.InvalidParameter:
                    return new ArgumentException($"{msg}.");
                case MediaContentError.OutOfMemory:
                    return new OutOfMemoryException($"{msg}.");
                case MediaContentError.InvalidOperation:
                    return new InvalidOperationException($"{msg}.");
                case MediaContentError.FileNoSpaceOnDevice:
                    return new IOException($"{msg} : {err}.");
                case MediaContentError.PermissionDenied:
                    return new UnauthorizedAccessException($"{msg}.");
                case MediaContentError.DatabaseFailed:
                    return new MediaDatabaseException(MediaDatabaseError.OperationFailed);
                case MediaContentError.DatabaseBusy:
                    return new MediaDatabaseException(MediaDatabaseError.DatabaseBusy);
                case MediaContentError.NetworkFailed:
                    return new InvalidOperationException($"{msg} : {err}.");
                case MediaContentError.UnsupportedContent:
                    return new UnsupportedContentException();

                default:
                    return new InvalidOperationException($"Unknown Error : {err.ToString()}, {msg}.");
            }
        }
    }
}
