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

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// Represents the image media stored in the device.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class ImageInfo : MediaInfo
    {
        internal ImageInfo(Interop.MediaInfoHandle handle) : base(handle)
        {
            IntPtr imageHandle = IntPtr.Zero;

            try
            {
                Interop.MediaInfo.GetImage(handle, out imageHandle).ThrowIfError("Failed to retrieve data");

                Debug.Assert(imageHandle != IntPtr.Zero);

                Width = InteropHelper.GetValue<int>(imageHandle, Interop.ImageInfo.GetWidth);
                Height = InteropHelper.GetValue<int>(imageHandle, Interop.ImageInfo.GetHeight);

                Orientation = InteropHelper.GetValue<Orientation>(imageHandle, Interop.ImageInfo.GetOrientation);

                DateTaken = InteropHelper.GetString(imageHandle, Interop.ImageInfo.GetDateTaken);
                //ExposureTime = InteropHelper.GetString(imageHandle, Interop.ImageInfo.GetExposureTime);

                //FNumber = InteropHelper.GetValue<double>(imageHandle, Interop.ImageInfo.GetFNumber);
                //Iso = InteropHelper.GetValue<int>(imageHandle, Interop.ImageInfo.GetISO);

                //Model = InteropHelper.GetString(imageHandle, Interop.ImageInfo.GetModel);

            }
            finally
            {
                Interop.ImageInfo.Destroy(imageHandle);
            }
        }

        /// <summary>
        /// Gets the image width in pixels.
        /// </summary>
        /// <value>The image width in pixels.</value>
        /// <since_tizen> 4 </since_tizen>
        public int Width { get; }

        /// <summary>
        /// Gets the image height in pixels.
        /// </summary>
        /// <value>The image height in pixels.</value>
        /// <since_tizen> 4 </since_tizen>
        public int Height { get; }

        /// <summary>
        /// Gets the orientation of image.
        /// </summary>
        /// <value>The orientation of image.</value>
        /// <since_tizen> 4 </since_tizen>
        public Orientation Orientation { get; }

        /// <summary>
        /// Gets the date of the creation time as a formatted string.
        /// </summary>
        /// <value>The date of the creation time as a formatted string.</value>
        /// <since_tizen> 4 </since_tizen>
        public string DateTaken { get; }

        /// <summary>
        /// Gets the exposure time from EXIF.
        /// </summary>
        /// <value>The exposure time from EXIF.</value>
        /// <since_tizen> 4 </since_tizen>
        //[Obsolete("Deprecated since API11. Will be removed in API13.")]
        //public string ExposureTime { get; }

        /// <summary>
        /// Gets the FNumber from EXIF.
        /// </summary>
        /// <value>The FNumber from EXIF.</value>
        /// <since_tizen> 4 </since_tizen>
        //[Obsolete("Deprecated since API11. Will be removed in API13.")]
        //public double FNumber { get; }

        /// <summary>
        /// Gets the ISO from EXIF.
        /// </summary>
        /// <value>The iso from EXIF.</value>
        /// <since_tizen> 4 </since_tizen>
        //[Obsolete("Deprecated since API11. Will be removed in API13.")]
        //public int Iso { get; }

        /// <summary>
        /// Gets the model from EXIF.
        /// </summary>
        /// <value>The model from EXIF.</value>
        /// <since_tizen> 4 </since_tizen>
        //[Obsolete("Deprecated since API11. Will be removed in API13.")]
        //public string Model { get; }
    }
}
