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
    /// Resizes an image.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class ResizeTransform : ImageTransform
    {
        private Size _size;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResizeTransform"/> class.
        /// </summary>
        /// <param name="size">The size that an image is resized to.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The width of <paramref name="size"/> is less than or equal to zero.<br/>
        ///     -or-<br/>
        ///     The height of <paramref name="size"/> is less than or equal to zero.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public ResizeTransform(Size size)
        {
            Size = size;
        }

        internal override string GenerateNotSupportedErrorMessage(VideoMediaFormat format)
            => $"'{format.MimeType}' is not supported by ResizeTransform.";

        /// <summary>
        /// Gets or sets the size that an image is resized to.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The width of <paramref name="value"/> is less than or equal to zero.<br/>
        ///     -or-<br/>
        ///     The height of <paramref name="value"/> is less than or equal to zero.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public Size Size
        {
            get { return _size; }
            set
            {
                if (value.Width <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Size), value,
                        "Width of the size can't be less than or equal to zero.");
                }

                if (value.Height <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Size), value,
                        "Height of the size can't be less than or equal to zero.");
                }

                _size = value;
            }
        }

        internal override void Configure(TransformHandle handle)
        {
            NativeTransform.SetResolution(handle, (uint)Size.Width, (uint)Size.Height);
        }
    }
}
