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
    /// <summary>
    /// Specifies the audio sample formats.
    /// </summary>
    /// <summary>
    /// Enumerates the various audio sample formats that are supported in the audio
    /// processing system. Each format represents a different way that audio signal
    /// data can be encoded and represented in memory.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum AudioSampleFormat
    {
        /// <summary>
        /// Represents audio samples encoded as unsigned 8-bit integers.
        /// This format is often used in low-quality audio files and
        /// applications where bandwidth or storage space is limited.
        /// </summary>
        U8,

        /// <summary>
        /// Represents audio samples encoded as signed 16-bit integers in
        /// little-endian format. This format is commonly used in CD-quality
        /// audio, providing a good balance between audio fidelity and file size.
        /// </summary>
        S16LE,

        /// <summary>
        /// Represents audio samples encoded as signed 24-bit integers in
        /// little-endian format. This high-resolution format allows for greater
        /// dynamic range and fidelity, making it suitable for professional audio
        /// applications and high-quality sound recordings.
        /// </summary>
        S24LE,

        /// <summary>
        /// Represents audio samples encoded as signed 24-bit integers,
        /// packed into 32-bit containers in little-endian format. This format
        /// can be used for applications that require compatibility with 32-bit
        /// processing, allowing for easier manipulation of samples at the cost of
        /// additional space.
        /// </summary>
        S24PackedIn32LE,
    }
}
