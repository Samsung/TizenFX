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
using System.Runtime.InteropServices;

namespace Tizen.Multimedia.Util
{
    /// <summary>
    /// Represents image data returned by a decoder class.
    /// </summary>
    public class BitmapFrame
    {
        internal BitmapFrame(IntPtr nativeBuffer, int width, int height, int size)
        {
            Debug.Assert(nativeBuffer != IntPtr.Zero);
            
            byte[] buf = new byte[size];
            Marshal.Copy(nativeBuffer, buf, 0, size);

            Buffer = buf;

            Size = new Size(width, height);
        }

        /// <summary>
        /// Gets the raw image data.
        /// </summary>
        public byte[] Buffer { get; }

        /// <summary>
        /// Gets the size of the image.
        /// </summary>
        public Size Size { get; }
    }
}
