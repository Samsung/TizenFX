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

using System.Threading.Tasks;
using static Interop;

namespace Tizen.Multimedia.Util
{
    // TODO need to improve performance
    /// <summary>
    /// Represents a <see cref="ImageTransform"/> that is a composite of the transforms.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class ImageTransformGroup : ImageTransform
    {
        /// <summary>
        /// Gets or sets the <see cref="ImageTransformCollection"/>.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public ImageTransformCollection Children { get; set; }

        /// <summary>
        /// Initializes a new instance of the ImageTransformGroup class.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public ImageTransformGroup()
        {
            Children = new ImageTransformCollection();
        }

        internal override void Configure(TransformHandle handle)
        {
            // intended blank
        }

        internal override async Task<MediaPacket> ApplyAsync(MediaPacket source)
        {
            if (Children.Count == 0)
            {
                return source;
            }

            var items = Children;

            MediaPacket curPacket = await items[0].ApplyAsync(source);

            for (int i = 1; i < items.Count; ++i)
            {
                var oldPacket = curPacket;
                try
                {
                    curPacket = await items[i].ApplyAsync(curPacket);
                }
                finally
                {
                    oldPacket.Dispose();
                }
            }

            return curPacket;
        }

        internal override string GenerateNotSupportedErrorMessage(VideoMediaFormat format)
        {
            return null;
        }
    }
}
