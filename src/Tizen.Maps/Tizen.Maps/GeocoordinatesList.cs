﻿/*
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

namespace Tizen.Maps
{
    /// <summary>
    /// List of <see cref="Geocoordinates"/> objects to be used in <see cref="MapService"/> APIs.
    /// </summary>
    internal class GeocoordinatesList : IDisposable
    {
        internal Interop.CoordinatesListHandle handle;

        internal GeocoordinatesList(IEnumerable<Geocoordinates> coordinateList, bool ownerShip = false)
        {
            handle = new Interop.CoordinatesListHandle(ownerShip);
            foreach (var coordinates in coordinateList)
            {
                handle.Add(coordinates.handle);
            }
        }

        /// <summary>
        /// Destroy the GeocoordinatesList object.
        /// </summary>
        ~GeocoordinatesList()
        {
            Dispose(false);
        }

        /// <summary>
        /// The iterator for coordinates in this list.
        /// </summary>
        internal IEnumerable<Geocoordinates> Coordinates
        {
            get
            {
                List<Geocoordinates> list = new List<Geocoordinates>();
                handle.ForEach(coordinateHandle => list.Add(new Geocoordinates(coordinateHandle)));
                return list;
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">If true, managed and unmanaged resources can be disposed, otherwise only unmanaged resources can be disposed.</param>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                handle?.Dispose();
                _disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all the resources used by this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
