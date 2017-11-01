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

namespace Tizen.Maps
{
    /// <summary>
    /// The class representing a geographical area.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Area : IDisposable
    {
        internal Interop.AreaHandle handle;

        /// <summary>
        /// Constructs a rectangular area.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="topLeft">Top-left coordinates of the area.</param>
        /// <param name="bottomRight">Bottom-left coordinates of the area.</param>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown when input coordinates are invalid.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a native operation fails to allocate memory.</exception>
        public Area(Geocoordinates topLeft, Geocoordinates bottomRight)
        {
            handle = new Interop.AreaHandle(topLeft?.handle, bottomRight?.handle);
        }

        /// <summary>
        /// Constructs a circular area.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="center">Coordinates for center of the area.</param>
        /// <param name="radius">Radius of the area.</param>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown when input coordinates are invalid.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a native operation fails to allocate memory.</exception>
        public Area(Geocoordinates center, double radius)
        {
            handle = new Interop.AreaHandle(center?.handle, radius);
        }

        internal Area(Interop.AreaHandle nativeHandle)
        {
            handle = nativeHandle;
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">If true, managed and unmanaged resources can be disposed, otherwise only unmanaged resources can be disposed.</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                handle.Dispose();
                _disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all the resources used by this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
