/*
* Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
*
* Licensed under the Apache License, Version 2.0 (the License);
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an AS IS BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Diagnostics;
using System.Linq;

namespace Tizen.Multimedia
{
    internal static class AudioIOUtil
    {
        internal static void ThrowIfError(int errorCode, string msg = null)
        {
            AudioIOError code = (AudioIOError)errorCode;
            // 현재는 에러코드 최상위 exception으로 전달, 추후 상황에 맞게 케이스 처리해야 함.

            msg = (msg == null ? "" : msg + " ") + $": { code }";

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
                    throw new ArgumentException(msg);
                case AudioIOError.InvalidOperation:
                    throw new InvalidOperationException(msg);
                case AudioIOError.PermissionDenied:
                    Log.Info("Audio", "Permission Denied Error");
                    throw new InvalidOperationException(msg);
                case AudioIOError.NotSupported:
                    throw new NotSupportedException(msg);
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
                    throw new InvalidOperationException(msg);
                case AudioIOError.SoundPolicy:
                    Log.Info("Audio", "Sound Policy Error");
                    throw new Exception(msg);
                case AudioIOError.InvalidState:
                    Log.Info("Audio", "Invalid State Error");
                    throw new InvalidOperationException(msg);
                case AudioIOError.NotSupportedType:
                    Log.Info("Audio", "Not supported stream type Error");
                    throw new NotSupportedException(msg);
                default:
                    Log.Info("Audio", "Unknown Exception" + code);
                    throw new Exception(msg);
            }
        }

        internal static void ValidateState(AudioIOState curState, params AudioIOState[] desiredStates)
        {
            Debug.Assert(desiredStates.Length > 0);

            if (desiredStates.Contains(curState))
            {
                return;
            }

            throw new InvalidOperationException($"The audio is not in a valid state. " +
                $"Current State : { curState }, Valid State : { string.Join(", ", desiredStates) }.");
        }
    }
}
