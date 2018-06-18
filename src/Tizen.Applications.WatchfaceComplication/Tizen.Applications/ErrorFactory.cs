using System;
using System.Runtime.CompilerServices;

namespace Tizen.Applications.WatchfaceComplication
{
    internal static class ErrorFactory
    {
        private const string LogTag = "Tizen.Applications.WatchfaceComplication";

        internal static void ThrowException(ComplicationError errorCode, string errorMessage = null,
            [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            Log.Error(LogTag, $"{memberName}({lineNumber.ToString()}) : {filePath}");
            switch (errorCode)
            {
                case ComplicationError.None:
                    return;
                case ComplicationError.OutOfMemory:
                case ComplicationError.IO:
                case ComplicationError.NoData:
                case ComplicationError.NotSupported:
                case ComplicationError.DB:
                case ComplicationError.DBus:
                case ComplicationError.EditNotReady:
                case ComplicationError.ExistID:
                case ComplicationError.NotExist:
                    throw new InvalidOperationException(string.IsNullOrEmpty(errorMessage) ? "error code : " + errorCode.ToString() :
                        $"{errorMessage} - {errorCode}");
                case ComplicationError.InvalidParam:
                    Log.Error(LogTag, "Invalid parameter : " + errorMessage);
                    throw new ArgumentException(string.IsNullOrEmpty(errorMessage) ? "Invalid parameter" : "Invalid parameter : " + errorMessage);
                case ComplicationError.PermissionDeny:
                    Log.Error(LogTag, "Permission denied : " + errorMessage);
                    throw new UnauthorizedAccessException(string.IsNullOrEmpty(errorMessage) ? "Permission denied" : "Permission denied : " + errorMessage);                
                default:
                    Log.Error(LogTag, $"Unknown error : {errorMessage} - {errorCode}");
                    throw new InvalidOperationException(string.IsNullOrEmpty(errorMessage) ? "Unknown error : " + errorCode.ToString() :
                        $"Unknown error : {errorMessage} - {errorCode}");
            }
        }
    }
}
