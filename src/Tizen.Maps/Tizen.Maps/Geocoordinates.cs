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
    /// Class representing geographical coordinates.
    /// </summary>
    public class Geocoordinates : IDisposable
    {
        internal Interop.CoordinatesHandle handle;

        /// <summary>
        /// Constructs map coordinate object.
        /// </summary>
        /// <param name="latitude">Latitude value, must be between (-90.0 ~ 90.0) degrees</param>
        /// <param name="longitude">Longitude value, must be between (-180.0 ~ 180.0) degrees</param>
        /// <exception cref="System.ArgumentException">Thrown when values for latitude and longitude are not valid.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when native operation failed to allocate memory.</exception>
        public Geocoordinates(double latitude, double longitude)
        {
            handle = new Interop.CoordinatesHandle(latitude, longitude);
        }

        internal Geocoordinates(Interop.CoordinatesHandle nativeHandle)
        {
            handle = nativeHandle;
        }

        /// <summary>
        /// Gets latitude of the coordinates.
        /// </summary>
        public double Latitude
        {
            get
            {
                return handle.Latitude;
            }
        }

        /// <summary>
        /// Gets longitude of the coordinates.
        /// </summary>
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
        public override string ToString()
        {
            return $"[{Latitude}, {Longitude}]";
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                handle.Dispose();
                _disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all resources used by this object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
