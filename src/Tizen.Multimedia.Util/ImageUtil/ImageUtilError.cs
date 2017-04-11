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
using Tizen.Internals.Errors;

namespace Tizen.Multimedia.Util
{

    internal enum ImageUtilError
    {
        None = ErrorCode.None,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidParameter = ErrorCode.InvalidParameter,
        InvalidOperation = ErrorCode.InvalidOperation,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported,
        NoSuchFile = ErrorCode.NoSuchFile,
        NotSupportedFormat = -0x01920000 | 0x01,
    }

    internal static class ImageUtilErrorExtesions
    {
        internal static void ThrowIfFailed(this ImageUtilError err, string message)
        {
            if (err == ImageUtilError.None)
            {
                return;
            }

            throw err.ToException(message);
        }

        internal static Exception ToException(this ImageUtilError err, string message)
        {
            Debug.Assert(err != ImageUtilError.None);

            string errMessage = $"{message}; {err}.";
            switch (err)
            {
                case ImageUtilError.PermissionDenied:
                    return new UnauthorizedAccessException(errMessage);

                case ImageUtilError.InvalidParameter:
                    return new ArgumentException(errMessage);

                case ImageUtilError.NoSuchFile:
                    return new FileNotFoundException(errMessage);

                case ImageUtilError.OutOfMemory:
                    return new OutOfMemoryException(errMessage);

                case ImageUtilError.NotSupported:
                    return new NotSupportedException(errMessage);

                case ImageUtilError.NotSupportedFormat:
                    return new FileFormatException(errMessage);

                case ImageUtilError.InvalidOperation:
                default:
                    return new InvalidOperationException(errMessage);
            }
        }
    }

}
