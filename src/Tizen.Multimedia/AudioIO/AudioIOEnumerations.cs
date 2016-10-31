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

using Tizen.Internals.Errors;

namespace Tizen.Multimedia
{
    public enum AudioChannel
    {
        Mono = 0x80,            // 1 channel, mono
        Stereo                  // 2 cahnnel, stereo
    };

    public enum AudioIOError
    {
        None = ErrorCode.None,                   // Successful
        OutOfMemory = ErrorCode.OutOfMemory,          //Out of memory
        InvalidParameter = ErrorCode.InvalidParameter,      //Invalid parameter
        InvalidOperation = ErrorCode.InvalidOperation,      //Invalid operation
        PermissionDenied = ErrorCode.PermissionDenied,      //Device open error by security
        NotSupported = ErrorCode.NotSupported,          //Not supported
        DevicePolicyRestriction = (-2147483648 / 2) + 4,
        DeviceNotOpened = -0x01900000 | 0x01,      //Device open error
        DeviceNotClosed = -0x01900000 | 0x02,      //Device close error
        InvalidBuffer = -0x01900000 | 0x03,         //Invalid buffer pointer
        SoundPolicy = -0x01900000 | 0x04,           //Sound policy error
        InvalidState = -0x01900000 | 0x05,       //Invalid state (Since 3.0)
        NotSupportedType = -0x01900000 | 0x06,  //Not supported stream type (Since 3.0)
    };

    public enum AudioState
    {
        Idle = 0,      /** Audio-io handle is created, but not prepared */
        Running = 1,   /** Audio-io handle is ready and the stream is running */
        Paused = 2    /** Audio-io handle is ready and the stream is paused */
    };
}
