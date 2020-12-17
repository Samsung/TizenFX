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
using System.Collections.Generic;
using static Interop;
using NativeTransform = Interop.ImageUtil.Transform;

namespace Tizen.Multimedia.Util
{
    /// <summary>
    /// Changes the colorspace of an image.
    /// </summary>
    /// <seealso cref="ColorSpace"/>
    /// <since_tizen> 4 </since_tizen>
    public class ColorSpaceTransform : ImageTransform
    {
        private ImageColorSpace _imageColorSpace;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorSpaceTransform"/> class.
        /// </summary>
        /// <param name="colorSpace">The colorspace of output image.</param>
        /// <exception cref="ArgumentException"><paramref name="colorSpace"/> is invalid.</exception>
        /// <exception cref="NotSupportedException"><paramref name="colorSpace"/> is not supported.</exception>
        /// <seealso cref="SupportedColorSpaces"/>
        /// <since_tizen> 4 </since_tizen>
        public ColorSpaceTransform(ColorSpace colorSpace)
        {
            ColorSpace = colorSpace;
        }

        /// <summary>
        /// Gets or sets the colorspace of the result image.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is invalid.</exception>
        /// <exception cref="NotSupportedException"><paramref name="value"/> is not supported.</exception>
        /// <seealso cref="SupportedColorSpaces"/>
        /// <since_tizen> 4 </since_tizen>
        public ColorSpace ColorSpace
        {
            get { return _imageColorSpace.ToCommonColorSpace(); }
            set
            {
                ValidationUtil.ValidateEnum(typeof(ColorSpace), value, nameof(ColorSpace));

                _imageColorSpace = value.ToImageColorSpace();
            }
        }

        internal override string GenerateNotSupportedErrorMessage(VideoMediaFormat format)
            => $"Converting colorspace from '{format.MimeType}' to '{ColorSpace.ToString()}' is not supported.";

        internal override void Configure(TransformHandle handle)
        {
            NativeTransform.SetColorspace(handle, _imageColorSpace);
        }


        /// <summary>
        /// Gets the supported colorspaces for <see cref="ColorSpaceTransform"/>.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static IEnumerable<ColorSpace> SupportedColorSpaces
        {
            get
            {
                foreach (ImageColorSpace value in Enum.GetValues(typeof(ImageColorSpace)))
                {
                    yield return value.ToCommonColorSpace();
                }
            }
        }
    }
}
