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

namespace Tizen.Messaging.Email
{
    internal enum EmailError
    {
        None = ErrorCode.None,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidParameter = ErrorCode.InvalidParameter,
        ServerNotReady = -0x01710000 | 0x501,
        CommunicationWithServerFailed = -0x01710000 | 0x502,
        OutOfRange = -0x01710000 | 0x503,
        SendingFailed = -0x01710000 | 0x504,
        OperationFailed = -0x01710000 | 0x505,
        NoSimCard = -0x01710000 | 0x506,
        NoData = -0x01710000 | 0x507,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported
    }

    internal static class EmailErrorFactory
    {
        internal const string LogTag = "Tizen.Messaging.Email";

        internal static Exception GetException(int err)
        {
            EmailError error = (EmailError)err;
            if (error == EmailError.OutOfMemory)
            {
                return new OutOfMemoryException("Out of memory");
            }
            else if (error == EmailError.InvalidParameter)
            {
                return new ArgumentException("Invalid parameter");
            }
            else if (error == EmailError.ServerNotReady)
            {
                return new IOException("Server not ready yet"); ;
            }
            else if (error == EmailError.NoData)
            {
                return new InvalidDataException("No data found");
            }
            else if (error == EmailError.CommunicationWithServerFailed)
            {
                return new TimeoutException("timed out");
            }
            else if (error == EmailError.PermissionDenied)
            {
                return new UnauthorizedAccessException("Permission denied");
            }
            else if (error == EmailError.NotSupported)
            {
                return new NotSupportedException("Not supported");
            }
            else if (error == EmailError.OutOfRange)
            {
                return new IndexOutOfRangeException("Out of range");
            }
            else if (error == EmailError.SendingFailed)
            {
                return new Exception("Sending failed");
            }
            else if (error == EmailError.OperationFailed)
            {
                return new InvalidOperationException("operation failed");
            }
            else if (error == EmailError.NoSimCard)
            {
                return new Exception("No sim card found");
            }
            else
            {
                return new Exception("System operation");
            }
        }
    }
}
