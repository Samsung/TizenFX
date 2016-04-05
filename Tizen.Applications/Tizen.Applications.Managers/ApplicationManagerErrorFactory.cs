/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.
using System;

namespace Tizen.Applications.Managers
{
    internal enum ApplicationManagerError
    {
        None = Tizen.Internals.Errors.ErrorCode.None,
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
        OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
        IoError = Tizen.Internals.Errors.ErrorCode.IoError,
        NoSuchApp = -0x01110000 | 0x01,
        DbFailed = -0x01110000 | 0x03,
        InvalidPackage = -0x01110000 | 0x04,
        AppNoRunning = -0x01110000 | 0x05,
        RequestFailed = -0x01110000 | 0x06,
        PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied
    }

    internal static class ApplicationManagerErrorFactory
    {
        private const string LogTag = "Tizen.Applications.Managers";

        internal static void ExceptionChecker(int ret, string msg)
        {
            Log.Debug(LogTag, "ExceptionChecker");
            ApplicationManagerError err = (ApplicationManagerError)ret;
            switch(err)
            {
                case ApplicationManagerError.InvalidParameter:
                    Log.Error(LogTag, msg);
                    throw new ArgumentException(err + " error occurred.");
                case ApplicationManagerError.OutOfMemory:
                case ApplicationManagerError.IoError:
                case ApplicationManagerError.NoSuchApp:
                case ApplicationManagerError.DbFailed:
                case ApplicationManagerError.InvalidPackage:
                case ApplicationManagerError.AppNoRunning:
                case ApplicationManagerError.RequestFailed:
                case ApplicationManagerError.PermissionDenied:
                    Log.Error(LogTag, msg);
                    throw new InvalidOperationException(err + " error occurred.");
                default:
                    break;
            }
        }

    }
}
