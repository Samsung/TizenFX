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
using static Interop;
using NativeTransform = Interop.ImageUtil.Transform;

namespace Tizen.Multimedia.Util
{
    /// <summary>
    /// Crops an image.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class CropTransform : ImageTransform
    {
        private Rectangle _region;

        /// <summary>
        /// Initializes a new instance of the <see cref="CropTransform"/> class.
        /// </summary>
        /// <param name="region">The crop region.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The X-position of <paramref name="region"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     The Y-position of <paramref name="region"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     The width of <paramref name="region"/> is less than or equal to zero.<br/>
        ///     -or-<br/>
        ///     The height of <paramref name="region"/> is less than or equal to zero.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public CropTransform(Rectangle region)
        {
            Region = region;
        }

        /// <summary>
        /// Gets or sets the crop region.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The X-position of <paramref name="value"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     The Y-position of <paramref name="value"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     The width of <paramref name="value"/> is less than or equal to zero.<br/>
        ///     -or-<br/>
        ///     The height of <paramref name="value"/> is less than or equal to zero.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public Rectangle Region
        {
            get { return _region; }
            set
            {

                if (value.X < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Region), value,
                        "X position of the region can't be less than zero.");
                }

                if (value.Y < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Region), value,
                        "Y position of the region can't be less than zero.");
                }

                if (value.Width <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Region), value,
                        "Width of the region can't be less than or equal zero.");
                }

                if (value.Height < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Region), value,
                        "Height of the region can't be less than or equal to zero.");
                }

                _region = value;
            }
        }

        internal override void Configure(TransformHandle handle)
        {
            NativeTransform.SetCropArea(handle, Region.Left, Region.Top, Region.Right, Region.Bottom);
        }

        internal override void ValidateFormat(VideoMediaFormat format)
        {
            if (format.Size.Width < Region.Right || format.Size.Height < Region.Bottom)
            {
                throw new InvalidOperationException(
                    $"Crop region is invalid; Source size({format.Size.ToString()}), Crop region({Region.ToString()}).");
            }
        }

        internal override string GenerateNotSupportedErrorMessage(VideoMediaFormat format)
        {
            return $"'{format.MimeType}' is not supported by CropTransform.";
        }
    }
}
