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

namespace Tizen.Pims.Calendar
{
    internal enum CalendarError
    {
        None = Tizen.Internals.Errors.ErrorCode.None,                           /**< Successful */
        OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,             /**< Out of Memory */
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,   /**< Invalid parameter */
        FileNoSpace = Tizen.Internals.Errors.ErrorCode.FileNoSpaceOnDevice,     /** <FS Full*/
        PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,   /**< Permission denied */
        NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,           /**< Not supported */
        NoData = Tizen.Internals.Errors.ErrorCode.NoData,                       /**< Requested data does not exist */
        DBLocked = Globals.ErrorCalendar | 0x81,                                        /**< Database table locked or file locked */
        ErrorDB = Globals.ErrorCalendar | 0x9F,                                         /**< Unknown DB error */
        IPCNotAvailable = Globals.ErrorCalendar | 0xB1,                                 /**< IPC server is not available */
        ErrorIPC = Globals.ErrorCalendar | 0xBF,                                        /**< Unknown IPC error */
        ErrorSystem = Globals.ErrorCalendar | 0xEF,                                     /**< Internal system module error */
        ErrorInternal = Globals.ErrorCalendar | 0xFF,                                   /**< Implementation Error Temporary Use */
    };

    internal static class Globals
    {
        internal const string LogTag = "Tizen.Pims.Calendar";
        internal const int ErrorCalendar = -0x02010000;
    }

    internal static class CalendarErrorFactory
    {
        internal static void ThrowException(int e)
        {
            throw GetException(e);
        }

        internal static Exception GetException(int e)
        {
            Exception exp;
            switch ((CalendarError)e)
            {
            case CalendarError.OutOfMemory:
                exp = new OutOfMemoryException("Out of memory");
                Log.Error(Globals.LogTag, "Out of memory");
                break;
            case CalendarError.InvalidParameter:
                exp = new ArgumentException("Invalid parameter");
                Log.Error(Globals.LogTag, "Invalid parameter");
                break;
            case CalendarError.FileNoSpace:
                exp = new InvalidOperationException("File no space Error");
                Log.Error(Globals.LogTag, "File no space Error");
                break;
            case CalendarError.PermissionDenied:
                exp = new UnauthorizedAccessException("Permission denied");
                Log.Error(Globals.LogTag, "Permission denied");
                break;
            case CalendarError.NotSupported:
                exp = new NotSupportedException("Not supported");
                Log.Error(Globals.LogTag, "Not supported");
                break;
            case CalendarError.NoData:
                exp = new InvalidOperationException("No data found");
                Log.Error(Globals.LogTag, "No data found");
                break;
            case CalendarError.DBLocked:
                exp = new InvalidOperationException("Db locked");
                Log.Error(Globals.LogTag, "Db locked");
                break;
            case CalendarError.ErrorDB:
                exp = new InvalidOperationException("DB error");
                Log.Error(Globals.LogTag, "DB error");
                break;
            case CalendarError.IPCNotAvailable:
                exp = new InvalidOperationException("IPC not available");
                Log.Error(Globals.LogTag, "IPC not available");
                break;
            case CalendarError.ErrorIPC:
                exp = new InvalidOperationException("IPC error");
                Log.Error(Globals.LogTag, "IPC error");
                break;
            case CalendarError.ErrorSystem:
                exp = new InvalidOperationException("System error");
                Log.Error(Globals.LogTag, "System error");
                break;
            case CalendarError.ErrorInternal:
                exp = new InvalidOperationException("Internal error");
                Log.Error(Globals.LogTag, "Internal error");
                break;
            default:
                exp = new InvalidOperationException("Invalid operation");
                Log.Error(Globals.LogTag, "Invalid operation");
                break;
            }
            return exp;
        }
    }
}
