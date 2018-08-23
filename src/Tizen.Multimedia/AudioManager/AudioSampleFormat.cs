/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
    public enum AudioSampleFormat
    {
        /// <summary>
        /// Unsigned 8 bit samples.
        /// </summary>
        U8,

        /// <summary>
        /// Signed 16 bit samples.
        /// </summary>
        S16_LE,

        /// <summary>
        /// Signed 24 bit samples.
        /// </summary>
        S24_LE,

        /// <summary>
        /// Signed 24 bit(packed in 32 bit) samples.
        /// </summary>
        S24_32_LE,
    }
}
