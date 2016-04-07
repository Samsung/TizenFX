using System;

namespace Tizen.System.SystemSettings
{
    internal enum SystemSettingsError
    {
        None = Tizen.Internals.Errors.ErrorCode.None,
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
        OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
        IoError = Tizen.Internals.Errors.ErrorCode.IoError,
        PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
        NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
        LockScreenAppPasswordMode = -0x01140000 | 0x01
    };
    internal class SystemSettingsExceptionFactory
    {
        internal const string LogTag = "Tizen.System.SystemSettings";

        internal static Exception CreateException(SystemSettingsError err, string msg)
        {
            Exception exp;
            switch (err)
            {
                case SystemSettingsError.InvalidParameter:
                    exp = new ArgumentException(msg);
                    break;
                case SystemSettingsError.OutOfMemory:
                //fall through
                case SystemSettingsError.IoError:
                //fall through
                case SystemSettingsError.PermissionDenied:
                //fall through
                case SystemSettingsError.NotSupported:
                //fall through
                case SystemSettingsError.LockScreenAppPasswordMode:
                //fall through
                default:
                    exp = new InvalidOperationException(msg);
                    break;
            }
            return exp;
        }
    }
}
