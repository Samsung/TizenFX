using System;
using Tizen.Internals.Errors;

namespace Tizen.Multimedia
{
    internal enum RecorderError
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        TizenErrorRecorder = -0x01950000,
        RecorderErrorClass = TizenErrorRecorder | 0x10,
        InvalidState = RecorderErrorClass | 0x02,
        OutOfMemory = ErrorCode.OutOfMemory,
        ErrorDevice = RecorderErrorClass | 0x04,
        InvalidOperation = ErrorCode.InvalidOperation,
        SoundPolicy = RecorderErrorClass | 0x06,
        SecurityRestricted = RecorderErrorClass | 0x07,
        SoundPolicyByCall = RecorderErrorClass | 0x08,
        SoundPolicyByAlarm = RecorderErrorClass | 0x09,
        Esd = RecorderErrorClass | 0x0a,
        OutOfStorage = RecorderErrorClass | 0x0b,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported,
        ResourceConflict = RecorderErrorClass | 0x0c
    }

    internal static class RecorderErrorFactory
    {
        internal static void ThrowException(int errorCode, string errorMessage = null, string paramName = null)
        {
            RecorderError err = (RecorderError)errorCode;
            if(string.IsNullOrEmpty(errorMessage)) {
                errorMessage = err.ToString();
            }
            switch((RecorderError)errorCode) {
            case RecorderError.InvalidParameter:
                throw new ArgumentException(errorMessage, paramName);

            case RecorderError.InvalidState:
            case RecorderError.OutOfMemory:
            case RecorderError.ErrorDevice:
            case RecorderError.InvalidOperation:
            case RecorderError.SoundPolicy:
            case RecorderError.SecurityRestricted:
            case RecorderError.SoundPolicyByCall:
            case RecorderError.SoundPolicyByAlarm:
            case RecorderError.Esd:
            case RecorderError.OutOfStorage:
            case RecorderError.PermissionDenied:
            case RecorderError.NotSupported:
            case RecorderError.ResourceConflict:
                throw new InvalidOperationException(errorMessage);
            }
        }
    }
}

