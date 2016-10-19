using System;

namespace Tizen.Multimedia
{
    internal class AudioErrorHelper
    {
        public static void Try(int errorCode)
        {
            AudioIOError code = (AudioIOError)errorCode;
            // 현재는 에러코드 최상위 exception으로 전달, 추후 상황에 맞게 케이스 처리해야 함.

            Log.Info("Audio", "Error code = " + code);
            if (code > 0)
            {
                Log.Info("Audio", "Code > 0, no error!!!!");
                return;
            }

            switch (code)
            {
                case AudioIOError.None:
                    break;
                case AudioIOError.OutOfMemory:
                    Log.Info("Audio", "OutOfMemoryException");
                    throw new OutOfMemoryException();
                case AudioIOError.InvalidParameter:
                    Log.Info("Audio", "ArgumentException");
                    throw new ArgumentException();
                case AudioIOError.InvalidOperation:
                    Log.Info("Audio", "InvalidOperationException");
                    throw new InvalidOperationException();
                case AudioIOError.PermissionDenied:
                    Log.Info("Audio", "Permission Denied Error");
                    throw new Exception("Permission Denied Error");
                case AudioIOError.NotSupported:
                    Log.Info("Audio", "NotSupportedException");
                    throw new NotSupportedException();
                case AudioIOError.DevicePolicyRestriction:
                    Log.Info("Audio", "Device_policy_restriction");
                    throw new Exception("Device_policy_restriction");
                case AudioIOError.DeviceNotOpened:
                    Log.Info("Audio", "Device Not Opened Error");
                    throw new Exception("Device Not Opened Error");
                case AudioIOError.DeviceNotClosed:
                    Log.Info("Audio", "Device Not Closed Error");
                    throw new Exception("Device Not Closed Error");
                case AudioIOError.InvalidBuffer:
                    Log.Info("Audio", "Invalid Buffer Error");
                    throw new InvalidOperationException("Invalid Buffer Error");
                case AudioIOError.SoundPolicy:
                    Log.Info("Audio", "Sound Policy Error");
                    throw new Exception("Sound Policy Error");
                case AudioIOError.InvalidState:
                    Log.Info("Audio", "Invalid State Error");
                    throw new Exception("Invalid State Error");
                case AudioIOError.NotSupportedType:
                    Log.Info("Audio", "Not supported stream type Error");
                    throw new Exception("Not supported stream type Error");
                default:
                    Log.Info("Audio", "Unknown Exception" + code);
                    throw new Exception("Unknown Exception");
            } 
        }
    }
}
