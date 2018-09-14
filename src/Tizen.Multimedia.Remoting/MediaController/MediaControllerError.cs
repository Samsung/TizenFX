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

namespace Tizen.Multimedia.Remoting
{
    internal enum MediaControllerError
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidOperation = ErrorCode.InvalidOperation,
        NoSpaceOnDevice = ErrorCode.FileNoSpaceOnDevice,
        PermissionDenied = ErrorCode.PermissionDenied,
    }

    internal static class MediaControllerErrorExtensions
    {
        internal static void ThrowIfError(this MediaControllerError error, string message)
        {
            if (error == MediaControllerError.None)
            {
                return;
            }

            string msg = $"{ (message ?? "Operation failed") } : { error.ToString() }.";

            switch (error)
            {
                case MediaControllerError.InvalidParameter:
                    throw new ArgumentException(msg);

                // User should not throw System.OutOfMemoryException itself.
                case MediaControllerError.OutOfMemory:
                case MediaControllerError.InvalidOperation:
                    throw new InvalidOperationException(msg);

                case MediaControllerError.NoSpaceOnDevice:
                    throw new IOException($"Not enough storage : {msg}");

                case MediaControllerError.PermissionDenied:
                    throw new UnauthorizedAccessException(msg);
            }

            throw new InvalidOperationException($"Unknown error({error}) : {message}");
        }
    }
}