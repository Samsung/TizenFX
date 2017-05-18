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
using Tizen.Common;
using static Interop.ImageUtil;

namespace Tizen.Multimedia.Utility
{
    /// <summary>
    /// Image data class used with ImageDecoder
    /// </summary>
    public class ImageData
    {
        private Lazy<Color> _color;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="buffer">Image buffer</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <param name="size">Buffer size</param>
        public ImageData(byte[] buffer, int width, int height)
        {
            if (buffer == null || buffer.Length == 0)
                throw new ArgumentNullException("buffer");

            Buffer = buffer;
            Width = width;
            Height = height;

            _color = new Lazy<Color>(() => GetColor());
        }

        internal ImageData(IntPtr nativeBuffer, int width, int height, int size)
        {
            Buffer = NativeToByteArray(nativeBuffer, size);
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Image buffer
        /// </summary>
        public byte[] Buffer { get; }

        /// <summary>
        /// Image width
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Image height
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Image color
        /// </summary>
        public Color color
        {
            get
            {
                return _color.Value;
            }
        }

        private Color GetColor()
        {
            byte r, g, b, a = 0;
            ExtractColorFromMemory(Buffer, Width, Height, out r, out g, out b)
                   .ThrowIfFailed("Failed to extract color from buffer");
            return new Color(r, g, b, a);
        }
    }
}
