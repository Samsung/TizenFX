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
        Mono = 0x80,
        Stereo
    };

    internal enum AudioIOError
    {
        None = ErrorCode.None,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidParameter = ErrorCode.InvalidParameter,
        InvalidOperation = ErrorCode.InvalidOperation,
        PermissionDenied = ErrorCode.PermissionDenied,      //Device open error by security
        NotSupported = ErrorCode.NotSupported,          //Not supported
        DevicePolicyRestriction = (-2147483648 / 2) + 4,
        DeviceNotOpened = -0x01900000 | 0x01,
        DeviceNotClosed = -0x01900000 | 0x02,
        InvalidBuffer = -0x01900000 | 0x03,
        SoundPolicy = -0x01900000 | 0x04,
        InvalidState = -0x01900000 | 0x05,
        NotSupportedType = -0x01900000 | 0x06,
    }

    /// <summary>
    /// Specifies the states for the <see cref="AudioPlayback"/>, <see cref="AudioCapture"/> and <see cref="AsyncAudioCapture"/>.
    /// </summary>
    public enum AudioIOState
    {
        /// <summary>
        /// Not prepared.
        /// </summary>
        Idle = 0,

        /// <summary>
        /// The stream is running.
        /// </summary>
        Running = 1,

        /// <summary>
        /// The stream is paused.
        /// </summary>
        Paused = 2
    }

    /// <summary>
    /// Enumeration for audio sample type.
    /// </summary>
    public enum AudioSampleType
    {
        /// <summary>
        /// Unsigned 8-bit audio samples.
        /// </summary>
        U8 = 0x70,
        /// <summary>
        /// Signed 16-bit audio samples.
        /// </summary>
        S16Le
    }

}
