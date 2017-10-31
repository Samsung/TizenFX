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

namespace Tizen.Multimedia.Util
{
    /// <summary>
    /// Provides the ability to transform an image.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class ImageTransformer : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageTransformer"/> class.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public ImageTransformer()
        {
        }

        /// <summary>
        /// Transforms an image with <see cref="ImageTransform"/>.
        /// </summary>
        /// <param name="source"><see cref="MediaPacket"/> to transform. The <see cref="MediaPacket.Format"/> of this <paramref name="source"/> must be <see cref="VideoMediaFormat"/>.</param>
        /// <param name="item"><see cref="ImageTransform"/> to apply.</param>
        /// <returns>A task that represents the asynchronous transforming operation.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="source"/> is null.<br/>
        ///     -or-<br/>
        ///     <paramref name="item"/> is null.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="ImageTransformer"/> has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">Failed to apply <see cref="ImageTransform"/>.</exception>
        /// <since_tizen> 4 </since_tizen>
        public Task<MediaPacket> TransformAsync(MediaPacket source, ImageTransform item)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(ImageTransformer));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return item.ApplyAsync(source);
        }

        #region IDisposable Support
        private bool _disposed = false;

        /// <summary>
        /// Releases the unmanaged resources used by the ImageTransformer.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the ImageTransformer.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
