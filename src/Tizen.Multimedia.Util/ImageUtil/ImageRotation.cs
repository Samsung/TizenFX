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

namespace Tizen.Multimedia.Util
{
    /// <summary>
    /// Specifies how an image is rotated or flipped.
    /// </summary>
    /// <seealso cref="RotateTransform"/>
    public enum ImageRotation
    {
        /// <summary>
        /// No rotation.
        /// </summary>
        Rotate0,
        /// <summary>
        /// Rotate 90 degree clockwise.
        /// </summary>
        Rotate90,
        /// <summary>
        /// Rotate 180 degree clockwise.
        /// </summary>
        Rotate180,
        /// <summary>
        /// Rotate 270 degree clockwise.
        /// </summary>
        Rotate270,
        /// <summary>
        /// Flip horizontally.
        /// </summary>
        FlipHorizontal,
        /// <summary>
        /// Flip vertically.
        /// </summary>
        FlipVertical,
    }
}
