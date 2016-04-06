using System;
using Tizen.Internals.Errors;

namespace Tizen.System
{
    internal enum RuntimeInfoError
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        OutOfMemory = ErrorCode.OutOfMemory,
        Io = ErrorCode.IoError,
        RemoteIo = ErrorCode.RemoteIo,
        InvalidOperation = ErrorCode.InvalidOperation,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported
    }

    internal static class RuntimeInfoErrorFactory
    {
        internal const string LogTag = "Tizen.System.RuntimeInformation";

        internal static void ThrowException(int err)
        {
            RuntimeInfoError error = (RuntimeInfoError)err;
            if (error == RuntimeInfoError.OutOfMemory)
            {
                throw new InvalidOperationException("Out of memory");
            }
            else if (error == RuntimeInfoError.InvalidParameter)
            {
                throw new ArgumentException("Invalid parameter");
            }
            else if (error == RuntimeInfoError.Io)
            {
                throw new ArgumentException("I/O Error");
            }
            else if (error == RuntimeInfoError.RemoteIo)
            {
                throw new ArgumentException("Remote I/O Error");
            }
            else if (error == RuntimeInfoError.InvalidOperation)
            {
                throw new ArgumentException("Invalid operation");
            }
            else if (error == RuntimeInfoError.PermissionDenied)
            {
                throw new ArgumentException("Permission denied");
            }
            else if (error == RuntimeInfoError.NotSupported)
            {
                throw new ArgumentException("Not supported");
            }
        }
    }
}
