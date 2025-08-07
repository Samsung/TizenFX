using System;
using System.ComponentModel;
using Tizen.Internals.Errors;


namespace Tizen.Network.Tethering
{
    public enum TetheringType
    {
        All = 0,
        USB = 1,
        WiFi = 2,
        BT = 3,
    }

    public enum TetheringDisabledCause
    {
        FlightMode = 1,
        LowBattery = 2,
        NetworkClose = 3,
        Timeout = 4,
        Others = 5,
        Request = 6,
        WiFiOn = 7,
    }

    public enum TetheringError
    {
        None = ErrorCode.None,
        OpeartionNotPermitted = ErrorCode.NotPermitted,
        InvalidParam = ErrorCode.InvalidParameter,
        OutOfMemory = ErrorCode.OutOfMemory,
        ResourceBusy = ErrorCode.ResourceBusy,
        NotEnabled = -0x01C40000 | 0x0501,
        OperationFailed = -0x01C40000 | 0x0502,
        InvalidOperation = ErrorCode.InvalidOperation,
        ApiNotSupported = ErrorCode.NotSupported,
        PermissionDenied = ErrorCode.PermissionDenied,
    }
}
