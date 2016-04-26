using System;
using Tizen.Internals.Errors;

namespace Tizen.Applications.Messages
{
    internal enum MessagePortError
    {
        None = ErrorCode.None,
        IOError = ErrorCode.IoError,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidParameter = ErrorCode.InvalidParameter,
        InvalidOperation = ErrorCode.InvalidOperation,
        PortNotFound = -0x01130000 | 0x01,
        CertificateNotMatch = -0x01130000 | 0x02,
        MaxExceeded = -0x01130000 | 0x03,
        ResourceUnavailable = -0x01130000 | 0x04
    }

    internal static class MessagePortErrorFactory
    {
        internal static void ThrowException(int errorCode, string errorMessage = null, string paramName = null)
        {
            MessagePortError err = (MessagePortError)errorCode;
            if (String.IsNullOrEmpty(errorMessage))
            {
                errorMessage = err.ToString();
            }
            switch ((MessagePortError)errorCode)
            {
                case MessagePortError.IOError:
                case MessagePortError.OutOfMemory:
                case MessagePortError.InvalidOperation:
                case MessagePortError.PortNotFound:
                case MessagePortError.ResourceUnavailable: throw new InvalidOperationException(errorMessage);
                case MessagePortError.InvalidParameter:
                case MessagePortError.CertificateNotMatch: throw new ArgumentException(errorMessage, paramName);
                case MessagePortError.MaxExceeded: throw new ArgumentOutOfRangeException(paramName, errorMessage);
            }
        }
    }
}
