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

namespace Tizen.Multimedia
{
    /// <summary>
    /// The class containing the captured image data.
    /// </summary>
    public class ImageData
    {
        internal ImageData(IntPtr ptr)
        {
            var unmanagedStruct = Marshal.PtrToStructure<Interop.Camera.ImageDataStruct>(ptr);

            Format = unmanagedStruct.Format;
            Width = unmanagedStruct.Width;
            Height = unmanagedStruct.Height;

            if (unmanagedStruct.Data != IntPtr.Zero && unmanagedStruct.DataLength > 0)
            {
                Data = new byte[unmanagedStruct.DataLength];
                Marshal.Copy(unmanagedStruct.Data, Data, 0, (int)unmanagedStruct.DataLength);
            }
            else
            {
                Debug.Fail("ImageData is null!");
            }

            //Exif can be null
            if (unmanagedStruct.ExifLength > 0)
            {
                Exif = new byte[unmanagedStruct.ExifLength];
                Marshal.Copy(unmanagedStruct.Exif, Exif, 0, (int)unmanagedStruct.ExifLength);
            }
        }

        /// <summary>
        /// The pixel format of the captured image.
        /// </summary>
        public CameraPixelFormat Format { get; }

        /// <summary>
        /// The width of the image.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// The height of the image.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// The buffer containing image data.
        /// </summary>
        public byte[] Data { get; }

        /// <summary>
        /// String containing Exif data.
        /// </summary>
        public byte[] Exif { get; }
    }
}

