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

namespace Tizen.Account.SyncManager
{
    internal enum SyncManagerErrorCode
    {
        None = ErrorCode.None,
        NotSupported = ErrorCode.NotSupported,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidParameter = ErrorCode.InvalidParameter,
        InvalidOperation = ErrorCode.InvalidOperation,
        PermissionDenied = ErrorCode.PermissionDenied,
        IoError = ErrorCode.IoError,
        AlreadyInProgress = ErrorCode.AlreadyInProgress,
        QuotaExceeded = ErrorCode.QuotaExceeded,
        SystemError = -0x01020000 | 0X01,
        AdapterNotFound = -0x01020000 | 0X02
    }

    internal class ErrorFactory
    {
        internal static string LogTag = "Tizen.Account.SyncManager";

        internal static Exception GetException(int error)
        {
            if ((SyncManagerErrorCode)error == SyncManagerErrorCode.NotSupported)
            {
                return new NotSupportedException("Not supported (%http://tizen.org/feature/account.sync)");
            }
            else if ((SyncManagerErrorCode)error == SyncManagerErrorCode.OutOfMemory)
            {
                return new OutOfMemoryException("Out of memory");
            }
            else if ((SyncManagerErrorCode)error == SyncManagerErrorCode.InvalidParameter)
            {
                return new ArgumentException("Invalid parameter");
            }
            else if ((SyncManagerErrorCode)error == SyncManagerErrorCode.InvalidOperation)
            {
                return new InvalidOperationException("Invalid operation");
            }
            else if ((SyncManagerErrorCode)error == SyncManagerErrorCode.PermissionDenied)
            {
                return new UnauthorizedAccessException("Permission denied (%http://tizen.org/privilege/alarm.set, %http://tizen.org/privilege/calendar.read, %http://tizen.org/privilege/contact.read)");
            }
            else if ((SyncManagerErrorCode)error == SyncManagerErrorCode.IoError)
            {
                return new Exception("IO error occured");
            }
            else if ((SyncManagerErrorCode)error == SyncManagerErrorCode.AlreadyInProgress)
            {
                return new InvalidOperationException("Sync is already in progress");
            }
            else if ((SyncManagerErrorCode)error == SyncManagerErrorCode.QuotaExceeded)
            {
                return new InvalidOperationException("Quota for sync jobs exceeded");
            }
            else if ((SyncManagerErrorCode)error == SyncManagerErrorCode.SystemError)
            {
                return new Exception("System error occured");
            }
            else if ((SyncManagerErrorCode)error == SyncManagerErrorCode.AdapterNotFound)
            {
                return new InvalidOperationException("Sync adapter couldn't be found");
            }
            else
            {
                return new Exception("Unknown error");
            }
        }
    }
}

