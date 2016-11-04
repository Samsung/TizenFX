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
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The class containing the captured image data.
    /// </summary>
    public class ImageData
    {
        internal byte[] _data;
        internal int _width;
        internal int _height;
        internal CameraPixelFormat _format;
        internal byte[] _exif;

        internal ImageData()
        {
        }

        /// <summary>
        /// The buffer containing image data.
        /// </summary>
        public byte[] Data
        {
            get
            {
                return _data;
            }
        }

        /// <summary>
        /// The width of the image.
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }
        }

        /// <summary>
        /// The height of the image.
        /// </summary>
        public int Height
        {
            get
            {
                return _height;
            }
        }

        /// <summary>
        /// The pixel format of the captured image.
        /// </summary>
        public CameraPixelFormat Format
        {
            get
            {
                return _format;
            }
        }

        /// <summary>
        /// String containing Exif data.
        /// </summary>
        public byte[] Exif
        {
            get
            {
                return _exif;
            }
        }
    }
}

