namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Enumeration for the complication error.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum ComplicationError
    {
        /// <summary>
        /// Error none.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        None = Tizen.Internals.Errors.ErrorCode.None,
        /// <summary>
        /// Out of memory error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
        /// <summary>
        /// Invalid parameter error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        InvalidParam = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
        /// <summary>
        /// IO error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        IO = Tizen.Internals.Errors.ErrorCode.IoError,
        /// <summary>
        /// No data error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        NoData = Tizen.Internals.Errors.ErrorCode.NoData,
        /// <summary>
        /// Permission deny error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        PermissionDeny = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
        /// <summary>
        /// The complication API is not supported error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
        /// <summary>
        /// DB operation error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        DB = -0x02FC0000 | 0x1,
        /// <summary>
        /// DBus operation error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        DBus = -0x02FC0000 | 0x2,
        /// <summary>
        /// The editor is not ready for editing error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        EditNotReady = -0x02FC0000 | 0x3,
        /// <summary>
        /// Already exist ID error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        ExistID = -0x02FC0000 | 0x4,
        /// <summary>
        /// Not exist error.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        NotExist = -0x02FC0000 | 0x5
    }
}
