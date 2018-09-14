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
    /// Specifies the audio sample types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum AudioSampleType
    {
        /// <summary>
        /// Unsigned 8-bit audio samples.
        /// </summary>
        U8 = 0x70,
        /// <summary>
        /// Signed 16-bit audio samples.
        /// </summary>
        S16Le,
        /// <summary>
        /// Signed 24-bit audio samples.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        S24Le,
        /// <summary>
        /// Signed 24-bit (packed in 32-bit) audio samples.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        S24LePacked
    }
}
