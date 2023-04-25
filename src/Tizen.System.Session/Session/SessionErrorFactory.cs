/*
* Copyright (c) 2023 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.System
{
    internal enum SessionError
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        Io = ErrorCode.IoError,
        OutOfMemory = ErrorCode.OutOfMemory,
        AlreadyExists = ErrorCode.FileExists,
        NotAvailible = ErrorCode.NoSuchDevice,
        ResourceBusy = ErrorCode.ResourceBusy,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported,
    }

    internal static class SessionErrorFactory
    {
        internal const string LogTag = "Tizen.System.Session";

        internal static Exception CreateException(SessionError err)
        {
            SessionError error = (SessionError)err;
            if (error == SessionError.InvalidParameter)
            {
                return new ArgumentException("Invalid parameter");
            }
            else if (error == SessionError.Io)
            {
                return new IOException("I/O error");
            }
            else if (error == SessionError.OutOfMemory)
            {
                return new InvalidOperationException("Out of memory");
            }
            else if (error == SessionError.AlreadyExists)
            {
                return new InvalidOperationException("Already exists");
            }
            else if (error == SessionError.NotAvailible)
            {
                return new InvalidOperationException("Not availible");
            }
            else if (error == SessionError.ResourceBusy)
            {
                return new InvalidOperationException("Resource busy");
            }
            else if (error == SessionError.PermissionDenied)
            {
                return new UnauthorizedAccessException("Permission denied");
            }
            else if (error == SessionError.NotSupported)
            {
                return new NotSupportedException("Not supported");
            }
			else
			{
				return null;
			}
		}
    }
}
