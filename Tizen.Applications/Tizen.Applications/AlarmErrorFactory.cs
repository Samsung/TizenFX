// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.Applications
{
    internal enum AlarmError
    {
        None = Tizen.Internals.Errors.ErrorCode.None,
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
        InvalidTime = -0x01100000 | 0x05,
        InvalidDate = -0x01100000 | 0x06,
        ConnectionFail = -0x01100000 | 0x07,
        NotPermittedApp = -0x01100000 | 0x08,
        OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
        PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied
    }
    internal static class AlarmErrorFactory
    {
        private const string _logTag = "Tizen.Applications.Alarm";

        internal static Exception GetException(AlarmError ret, string msg)
        {
            switch (ret)
            {
                case AlarmError.InvalidParameter:
                //fall through
                case AlarmError.InvalidTime:
                //fall through
                case AlarmError.InvalidDate:
                    Log.Error(_logTag, msg);
                    return new ArgumentException(ret + " error occurred.");
                case AlarmError.NotPermittedApp:
                //fall through
                case AlarmError.PermissionDenied:
                    Log.Error(_logTag, msg);
                    return new UnauthorizedAccessException(ret + "error occured.");
                default:
                    Log.Error(_logTag, msg);
                    return new InvalidOperationException(ret + " error occurred.");
            }
        }
    }
}
