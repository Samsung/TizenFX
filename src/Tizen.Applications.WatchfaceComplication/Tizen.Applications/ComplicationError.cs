namespace Tizen.Applications.WatchfaceComplication
{    
    public enum ComplicationError
    {
        None = Tizen.Internals.Errors.ErrorCode.None,
        OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
        InvalidParam = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
        IO = Tizen.Internals.Errors.ErrorCode.IoError,
        NoData = Tizen.Internals.Errors.ErrorCode.NoData,
        PermissionDeny = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
        NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
        DB = -0x02FC0000 | 0x1,
        DBus = -0x02FC0000 | 0x2,
        EditNotReady = -0x02FC0000 | 0x3,
        ExistID = -0x02FC0000 | 0x4,
        NotExist = -0x02FC0000 | 0x5
    }
}
