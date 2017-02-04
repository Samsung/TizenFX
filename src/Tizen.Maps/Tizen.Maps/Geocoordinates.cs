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
    /// Class representing geographical co-ordinates
    /// </summary>
    public class Geocoordinates : IDisposable
    {
        internal Interop.CoordinatesHandle handle;

        /// <summary>
        /// Constructs map coordinate object
        /// </summary>
        /// <param name="latitude">latitude value, must be between (-90.0 ~ 90.0) degrees</param>
        /// <param name="longitude">longitude value, must be between (-180.0 ~ 180.0) degrees</param>
        /// <exception cref="System.ArgumentException">Throws if values for latitude and longitude are not valid</exception>
        /// <exception cref="System.InvalidOperationException">Throws if native operation failed to allocate memory</exception>
        public Geocoordinates(double latitude, double longitude)
        {
            handle = new Interop.CoordinatesHandle(latitude, longitude);
        }

        internal Geocoordinates(Interop.CoordinatesHandle nativeHandle)
        {
            handle = nativeHandle;
        }

        /// <summary>
        /// Latitude for this coordinate
        /// </summary>
        public double Latitude
        {
            get
            {
                return handle.Latitude;
            }
        }

        /// <summary>
        /// Longitude for this coordinate
        /// </summary>
        public double Longitude
        {
            get
            {
                return handle.Longitude;
            }
        }

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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
