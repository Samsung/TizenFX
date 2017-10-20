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

namespace Tizen.Multimedia.Util
{
    /// <summary>
    /// Represents the gif image data used to encode a gif image with <see cref="GifEncoder"/>.
    /// </summary>
    public class GifFrame
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="GifFrame"/> class with a buffer and a delay.
        /// </summary>
        /// <param name="buffer">The raw image buffer to be encoded.</param>
        /// <param name="delay">The delay for this image in milliseconds.</param>
        /// <exception cref="ArgumentNullException"><paramref name="buffer"/> is null.</exception>
        /// <exception cref="ArgumentException">The length of <paramref name="buffer"/> is zero.</exception>
        public GifFrame(byte[] buffer, uint delay)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            if (buffer.Length == 0)
            {
                throw new ArgumentException("buffer has no element.", nameof(buffer));
            }

            Buffer = buffer;
            Delay = delay;
        }

        /// <summary>
        /// Gets the raw image data.
        /// </summary>
        public byte[] Buffer { get; }

        /// <summary>
        /// Gets or sets the delay for this image.
        /// </summary>
        /// <value>Time delay in milliseconds.</value>
        public uint Delay { get; set; }
    }
}
