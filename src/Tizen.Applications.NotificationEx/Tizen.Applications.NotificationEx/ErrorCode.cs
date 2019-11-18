using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public enum ErrorCode
    {
        None = Tizen.Internals.Errors.ErrorCode.None,
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
        OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
        IO = Tizen.Internals.Errors.ErrorCode.IoError,
        PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
        InvalidOperation = Tizen.Internals.Errors.ErrorCode.InvalidOperation,
        DB = -0x01140000 | 0x01,
        AlreadyExistID = -0x01140000 | 0x02,
        DBus = -0x01140000 | 0x03,
        NotExistID = -0x01140000 | 0x04,
        ServiceNotReady = -0x01140000 | 0x05,
        MaxExceeded = -0x01140000 | 0x06,
    }
}
