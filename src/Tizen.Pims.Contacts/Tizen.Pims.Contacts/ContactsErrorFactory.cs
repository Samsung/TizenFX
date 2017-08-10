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

namespace Tizen.Pims.Contacts
{
    internal enum ContactsError
    {
        None = (int)ErrorCode.None,
        InvalidParameter = (int)ErrorCode.InvalidParameter,
        NotSupported = (int)ErrorCode.NotSupported,
        PermissionDenied = (int)ErrorCode.PermissionDenied,
        OutOfMemory = (int)ErrorCode.OutOfMemory,
        FileNoSpaceOnDevice = (int)ErrorCode.FileNoSpaceOnDevice,
        NoData = (int)ErrorCode.NoData,

        DatabaseLocked = -0x02010000 | 0x81,
        Database = -0x02010000 | 0x9F,
        IpcNotAvaliable = -0x02010000 | 0xB1,
        Ipc = -0x02010000 | 0xBF,
        System = -0x02010000 | 0xEF
    }

    internal static class Globals
    {
        internal const string LogTag = "Tizen.Pims.Contacts";
    }

    internal static class ContactsErrorFactory
    {
        static internal Exception CheckAndCreateException(int error)
        {
            ContactsError e = (ContactsError)error;
            switch (e)
            {
                case ContactsError.None:
                    return null;
                case ContactsError.InvalidParameter:
                    return new ArgumentException("Invalid Parameters Provided");
                case ContactsError.NotSupported:
                    return new NotSupportedException("Not Supported");
                case ContactsError.PermissionDenied:
                    return new UnauthorizedAccessException("Permission Denied");
                case ContactsError.OutOfMemory:
                    return new OutOfMemoryException("Out of Memory");
                case ContactsError.FileNoSpaceOnDevice:
                    return new InvalidOperationException("File System is Full");
                case ContactsError.NoData:
                    return new InvalidOperationException("No Data");
                case ContactsError.DatabaseLocked:
                    return new InvalidOperationException("Database Locked");
                case ContactsError.Database:
                    return new InvalidOperationException("Database Failed");
                case ContactsError.IpcNotAvaliable:
                    return new InvalidOperationException("IPC Not Avaliable");
                case ContactsError.Ipc:
                    return new InvalidOperationException("IPC failed");
                case ContactsError.System:
                    return new InvalidOperationException("Internal system error");
                default:
                    return new InvalidOperationException("Unknown Error Code");
            }
        }
    }
}
