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
using static Interop.Camera;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The class containing the captured still image.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class StillImage
    {
        internal StillImage(IntPtr ptr)
        {
            var unmanagedStruct = Marshal.PtrToStructure<StillImageDataStruct>(ptr);

            Format = unmanagedStruct.Format;
            Resolution = new Size(unmanagedStruct.Width, unmanagedStruct.Height);

            if (unmanagedStruct.Data != IntPtr.Zero && unmanagedStruct.DataLength > 0)
            {
                Data = new byte[unmanagedStruct.DataLength];
                Marshal.Copy(unmanagedStruct.Data, Data, 0, (int)unmanagedStruct.DataLength);
            }
            else
            {
                Debug.Fail("CameraStillImage Data is null!");
            }

            //Exif can be null
            if (unmanagedStruct.ExifLength > 0)
            {
                Exif = new byte[unmanagedStruct.ExifLength];
                Marshal.Copy(unmanagedStruct.Exif, Exif, 0, (int)unmanagedStruct.ExifLength);
            }
        }

        /// <summary>
        /// The pixel format of the still image.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public CameraPixelFormat Format { get; }

        /// <summary>
        /// The resolution of the still image.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public Size Resolution { get; }

        /// <summary>
        /// The buffer containing the still image.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public byte[] Data { get; }

        /// <summary>
        /// The Exif data describing additional metadata of still image.
        /// Please refer Exif specification for more details.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public byte[] Exif { get; }
    }
}
