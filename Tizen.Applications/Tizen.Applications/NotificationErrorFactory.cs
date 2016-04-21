// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.Applications.Notifications
{
    internal enum NotificationError
    {
        None = Tizen.Internals.Errors.ErrorCode.None,
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
        OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
        IoError = Tizen.Internals.Errors.ErrorCode.IoError,
        DbError = -0x01140000 | 0x01,
        AlreadyExists = -0x01140000 | 0x02,
        DBusError = -0x01140000 | 0x03,
        DoesnotExist = -0x01140000 | 0x04,
        ServiceError = -0x01140000 | 0x05,
        PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
        InvalidOperation = Tizen.Internals.Errors.ErrorCode.InvalidOperation
    }

    internal static class NotificationErrorFactory
    {
        private const string _logTag = "Tizen.Applications.Notification";

        internal static Exception GetException(NotificationError ret, string msg)
        {
            switch (ret)
            {
                case NotificationError.InvalidParameter:
                    Log.Error(_logTag, msg);
                    return new ArgumentException(ret + " error occurred.");
                default:
                    Log.Error(_logTag, msg);
                    return new InvalidOperationException(ret + " error occurred.");
            }
        }
    }
}
