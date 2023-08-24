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
using static Interop;
using NativeTransform = Interop.ImageUtil.Transform;

namespace Tizen.Multimedia.Util
{
    /// <summary>
    /// Rotates an image.
    /// </summary>
    /// <seealso cref="Rotation"/>
    /// <since_tizen> 4 </since_tizen>
    public class RotateTransform : ImageTransform
    {
        private Rotation _rotation;

        /// <summary>
        /// Initializes a new instance of the <see cref="RotateTransform"/> class.
        /// </summary>
        /// <param name="rotation">The value how to rotate an image.</param>
        /// <exception cref="ArgumentException"><paramref name="rotation"/> is invalid.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="rotation"/> is <see cref="Rotation.Rotate90"/>.</exception>
        /// <since_tizen> 4 </since_tizen>
        public RotateTransform(Rotation rotation)
        {
            Rotation = rotation;
        }

        /// <summary>
        /// Gets or sets the value how to rotate an image.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is invalid.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is <see cref="Rotation.Rotate90"/>.</exception>
        /// <since_tizen> 4 </since_tizen>
        public Rotation Rotation
        {
            get { return _rotation; }
            set
            {
                ValidationUtil.ValidateEnum(typeof(Rotation), value, nameof(Rotation));

                if (value == Rotation.Rotate0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Rotation can't be Rotate0.");
                }

                _rotation = value;
            }
        }

        internal override string GenerateNotSupportedErrorMessage(VideoMediaFormat format)
            => $"'{format.MimeType}' is not supported by RotateTransform.";

        internal override void Configure(TransformHandle handle)
        {
            NativeTransform.SetRotation(handle, GetImageRotation());
        }

        private ImageRotation GetImageRotation()
        {
            switch (Rotation)
            {
                case Rotation.Rotate90: return ImageRotation.Rotate90;
                case Rotation.Rotate180: return ImageRotation.Rotate180;
                case Rotation.Rotate270: return ImageRotation.Rotate270;
            }

            Debug.Fail("Rotation is invalid value!");
            return ImageRotation.Rotate0;
        }
    }
}
