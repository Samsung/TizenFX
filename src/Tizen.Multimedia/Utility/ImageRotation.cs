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

namespace Tizen.Multimedia.Utility
{
    /// <summary>
    /// Image rotation options
    /// </summary>
    public enum ImageRotation
    {
        /// <summary>
        /// No rotation
        /// </summary>
        None = Interop.ImageRotation.None,
        /// <summary>
        /// Rotate 90 degree
        /// </summary>
        Rotate90 = Interop.ImageRotation.Rotate90,
        /// <summary>
        /// Rotate 180 degree
        /// </summary>
        Rotate180 = Interop.ImageRotation.Rotate180,
        /// <summary>
        /// Rotate 270 degree
        /// </summary>
        Rotate270 = Interop.ImageRotation.Rotate270,
        /// <summary>
        /// Flip horizontal
        /// </summary>
        FlipHorizontal = Interop.ImageRotation.FlipHorizontal,
        /// <summary>
        /// Flip vertical
        /// </summary>
        FlipVertical = Interop.ImageRotation.FlipVertical,
    }
}