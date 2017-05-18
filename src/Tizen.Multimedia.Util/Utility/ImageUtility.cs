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

using System.Collections.Generic;
using static Interop;

namespace Tizen.Multimedia.Utility
{
    /// <summary>
    /// Image utility class
    /// </summary>
    public struct ImageUtility
    {
        /// <summary>
        /// Supported color-space for image encoding/ decoding
        /// </summary>
        /// <param name="type">image type</param>
        /// <returns>Supported color-space</returns>
        public static IEnumerable<ImageColorSpace> GetSupportedColorspace(ImageFormat type)
        {
            var colorspaces = new List<ImageColorSpace>();
            ImageUtil.ForeachSupportedColorspace((ImageType)type, (colorspace) => colorspaces.Add((ImageColorSpace)colorspace));
            return colorspaces;
        }

        /// <summary>
        /// Calculates the size of the image buffer for the specified resolution and color-space
        /// </summary>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// <param name="colorspace">Image color-space</param>
        /// <returns>Buffer size</returns>
        public static uint CalculateBufferSize(int width, int height, ImageColorSpace colorspace)
        {
            uint bufferSize;
            ImageUtil.CalculateBufferSize(width, height, (global::Interop.ImageColorSpace)colorspace, out bufferSize)
                   .ThrowIfFailed("Failed to calculate buffer size for given parameter");
            return bufferSize;
        }
    }
}
