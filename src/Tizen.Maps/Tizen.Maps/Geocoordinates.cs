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
    /// A class representing geographical coordinates.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Geocoordinates : IDisposable
    {
        internal Interop.CoordinatesHandle handle;

        /// <summary>
        /// Constructs the map coordinates object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="latitude">Latitude value must be between (-90.0 ~ 90.0) degrees.</param>
        /// <param name="longitude">Longitude value must be between (-180.0 ~ 180.0) degrees.</param>
        /// <exception cref="System.ArgumentException">Thrown when values for latitude and longitude are not valid.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a native operation fails to allocate memory.</exception>
        public Geocoordinates(double latitude, double longitude)
        {
            handle = new Interop.CoordinatesHandle(latitude, longitude);
        }

        internal Geocoordinates(Interop.CoordinatesHandle nativeHandle)
        {
            handle = nativeHandle;
        }

        /// <summary>
        /// Gets the latitude coordinates.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public double Latitude
        {
            get
            {
                return handle.Latitude;
            }
        }

        /// <summary>
        /// Gets the longitude coordinates.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public double Longitude
        {
            get
            {
                return handle.Longitude;
            }
        }

        /// <summary>
        /// Returns a string that represents this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Returns a string that represents this object.</returns>
        public override string ToString()
        {
            return $"[{Latitude}, {Longitude}]";
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">If true, managed and unmanaged resources can be disposed, otherwise only unmanaged resources can be disposed.</param>
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
