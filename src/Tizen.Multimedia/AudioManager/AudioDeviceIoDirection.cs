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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Defines the data flow directions for audio devices, indicating whether
    /// a device is for input, output, or both. This helps in managing audio
    /// interactions within applications effectively.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum AudioDeviceIoDirection
    {
        /// <summary>
        /// Input device.
        /// </summary>
        Input,

        /// <summary>
        /// Output device.
        /// </summary>
        Output,

        /// <summary>
        /// Input/output device (both directions are available).
        /// </summary>
        InputAndOutput
    }
}
