using System;
using Tizen.Internals.Errors;


namespace Tizen.Network.Tethering
{
    /// <summary>
    /// Enumeration for the Tethering type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum TetheringType
    {

        /// <summary>
        /// Tethering All type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        All = 0,
        /// <summary>
        /// Tethering USB type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        USB = 1,
        /// <summary>
        /// Tethering WiFi type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        WiFi = 2,
        /// <summary>
        /// Tethering Bluetooth type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        BT = 3,
    }

    /// <summary>
    /// Enumeration for the Tethering disabled reason.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum TetheringDisabledCause
    {
        /// <summary>
        /// Disabled due to FlightMode on.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        FlightMode = 1,
        /// <summary>
        /// Disabled due to Low Battery.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        LowBattery = 2,
        /// <summary>
        /// Disabled due to Network close.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        NetworkClose = 3,
        /// <summary>
        /// Disabled due to Timeout.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Timeout = 4,
        /// <summary>
        /// Disabled due to other reason.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Others = 5,
        /// <summary>
        /// Disabled due to user request.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Request = 6,
        /// <summary>
        /// Disabled due to WiFi beign on .
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        WiFiOn = 7,
    }

    /// <summary>
    /// Enumeration for the Tethering error code.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum TetheringError
    {
        /// <summary>
        /// Successful.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        None = ErrorCode.None,
        /// <summary>
        /// Operation not permitted.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        OpeartionNotPermitted = ErrorCode.NotPermitted,
        /// <summary>
        /// Invalid Parameters.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        InvalidParam = ErrorCode.InvalidParameter,
        /// <summary>
        /// Out of memory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        OutOfMemory = ErrorCode.OutOfMemory,
        /// <summary>
        /// Resource Busy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ResourceBusy = ErrorCode.ResourceBusy,
        /// <summary>
        /// Tethering not enabled.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        NotEnabled = -0x01C40000 | 0x0501,
        /// <summary>
        /// Operation failed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        OperationFailed = -0x01C40000 | 0x0502,
        /// <summary>
        /// Invalid Opeartion.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        InvalidOperation = ErrorCode.InvalidOperation,
        /// <summary>
        /// API not supported.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ApiNotSupported = ErrorCode.NotSupported,
        /// <summary>
        /// Permission Denied.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        PermissionDenied = ErrorCode.PermissionDenied,
    }
}
