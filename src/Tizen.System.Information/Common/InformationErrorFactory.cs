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
using System.ComponentModel;
using Tizen.Internals.Errors;

namespace Tizen.System
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal enum InformationError
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        OutOfMemory = ErrorCode.OutOfMemory,
        Io = ErrorCode.IoError,
        RemoteIo = ErrorCode.RemoteIo,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported,
        NoData = ErrorCode.NoData
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class InformationErrorFactory
    {
        internal const string LogTag = "Tizen.System.Information";

        internal static void ThrowException(InformationError err)
        {
            InformationError error = (InformationError)err;
            if (error == InformationError.InvalidParameter)
            {
                throw new ArgumentException("Invalid parameter");
            }
            else if (error == InformationError.OutOfMemory)
            {
                throw new OutOfMemoryException("Out of memory");
            }
            else if (error == InformationError.Io)
            {
                throw new IOException("I/O Error");
            }
            else if (error == InformationError.RemoteIo)
            {
                throw new IOException("Remote I/O Error");
            }
            else if (error == InformationError.PermissionDenied)
            {
                throw new UnauthorizedAccessException("Permission denied");
            }
            else if (error == InformationError.NotSupported)
            {
                throw new NotSupportedException("Not supported");
            }
            else if (error == InformationError.NoData)
            {
                throw new NotSupportedException("No data");
            }
        }
    }
}
