using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tizen.System
{
    internal enum DeviceError
    {
        None = Tizen.Internals.Errors.ErrorCode.None,
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
        PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
        InvalidOperation = Tizen.Internals.Errors.ErrorCode.InvalidOperation,
        AlreadyInProgress = Tizen.Internals.Errors.ErrorCode.NowInProgress,
        NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
        ResourceBusy = Tizen.Internals.Errors.ErrorCode.ResourceBusy,
        OperationFailed = -0x01140000 | 0x01,
        NotInitialized = -0x01140000 | 0x02
    };

    class DeviceExceptionFactory
    {
        internal const string LogTag = "Tizen.System.Device";

        internal static Exception CreateException(DeviceError err, string msg)
        {
            Exception exp;
            switch (err)
            {
                case DeviceError.InvalidParameter:
                    exp =  new ArgumentException(msg);
                    break;
                case DeviceError.AlreadyInProgress:
                    //fall through
                case DeviceError.NotSupported:
                    //fall through
                case DeviceError.ResourceBusy:
                    //fall through
                case DeviceError.OperationFailed:
                    //fall through
                case DeviceError.NotInitialized:
                    //fall through
                case DeviceError.PermissionDenied:
                    //fall through
                case DeviceError.InvalidOperation:
                    exp = new InvalidOperationException(msg);
                    break;
                default:
                    exp = new InvalidOperationException("Unknown error occured.");
                    break;
            }
            return exp;
        }
    }
}
