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
using System.ComponentModel;
using Tizen.Internals.Errors;

namespace Tizen.System
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal enum RuntimeInfoError
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
    internal static class RuntimeInfoErrorFactory
    {
        internal const string LogTag = "Tizen.System.RuntimeInformation";

        internal static void ThrowException(int err)
        {
            RuntimeInfoError error = (RuntimeInfoError)err;
            if (error == RuntimeInfoError.InvalidParameter)
            {
                throw new ArgumentException("Invalid parameter");
            }
            else if (error == RuntimeInfoError.OutOfMemory)
            {
                throw new OutOfMemoryException("Out of memory");
            }
            else if (error == RuntimeInfoError.Io)
            {
                throw new ArgumentException("I/O Error");
            }
            else if (error == RuntimeInfoError.RemoteIo)
            {
                throw new ArgumentException("Remote I/O Error");
            }
            else if (error == RuntimeInfoError.PermissionDenied)
            {
                throw new UnauthorizedAccessException("Permission denied");
            }
            else if (error == RuntimeInfoError.NotSupported)
            {
                throw new NotSupportedException("Not supported");
            }
            else if (error == RuntimeInfoError.NoData)
            {
                throw new NotSupportedException("No data");
            }
        }
    }
}
