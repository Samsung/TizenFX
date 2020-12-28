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
using System.Threading.Tasks;
using static Interop;
using NativeTransform = Interop.ImageUtil.Transform;

namespace Tizen.Multimedia.Util
{
    /// <summary>
    /// Flips an image.
    /// </summary>
    /// <seealso cref="Rotation"/>
    /// <since_tizen> 4 </since_tizen>
    public class FlipTransform : ImageTransform
    {
        private Flips _flip;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlipTransform"/> class.
        /// </summary>
        /// <param name="flip">The value how to flip an image.</param>
        /// <exception cref="ArgumentException"><paramref name="flip"/> is invalid.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="flip"/> is <see cref="Flips.None"/>.</exception>
        /// <since_tizen> 4 </since_tizen>
        public FlipTransform(Flips flip)
        {
            Flip = flip;
        }

        /// <summary>
        /// Gets or sets the value how to flip an image.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is invalid.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is <see cref="Flips.None"/>.</exception>
        /// <since_tizen> 4 </since_tizen>
        public Flips Flip
        {
            get { return _flip; }
            set
            {
                ValidationUtil.ValidateFlagsEnum(value, Flips.Horizontal | Flips.Vertical, nameof(Flips));

                if (value == Flips.None)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Flip can't be None.");
                }

                _flip = value;
            }
        }

        internal override string GenerateNotSupportedErrorMessage(VideoMediaFormat format)
            => $"'{format.MimeType}' is not supported by FlipTransform.";

        internal override void Configure(TransformHandle handle)
        {
            // intended blank
        }

        private async Task<MediaPacket> ApplyAsync(TransformHandle handle, MediaPacket source,
            ImageRotation rotation)
        {
            NativeTransform.SetRotation(handle, rotation);
            return await RunAsync(handle, source);
        }

        internal override async Task<MediaPacket> ApplyAsync(MediaPacket source)
        {
            using (TransformHandle handle = CreateHandle())
            {
                if (Flip.HasFlag(Flips.Vertical | Flips.Horizontal))
                {
                    var flipped = await ApplyAsync(handle, source, ImageRotation.FlipHorizontal);
                    try
                    {
                        return await ApplyAsync(handle, flipped, ImageRotation.FlipVertical);
                    }
                    finally
                    {
                        flipped.Dispose();
                    }
                }

                return await ApplyAsync(handle, source, Flip.HasFlag(Flips.Horizontal) ?
                    ImageRotation.FlipHorizontal : ImageRotation.FlipVertical);
            }
        }
    }
}
