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

namespace Tizen.Maps
{
    /// <summary>
    /// List of <see cref="Geocoordinates"/> objects to be used in <see cref="MapService"/> APIs
    /// </summary>
    internal class GeocoordinatesList
    {
        internal Interop.CoordinatesListHandle handle;

        internal GeocoordinatesList(IEnumerable<Geocoordinates> coordinateList, bool ownsHandle)
        {
            IntPtr nativeHandle;
            var err = Interop.Coordinates.ListCreate(out nativeHandle);
            err.ThrowIfFailed("Failed to create native handle for coordinate list");

            handle = new Interop.CoordinatesListHandle(nativeHandle, ownsHandle);
            foreach (var coordinates in coordinateList)
            {
                IntPtr clonedNativeHandle;
                err = Interop.Coordinates.Clone(coordinates.handle, out clonedNativeHandle);
                err.WarnIfFailed("Failed to clone native handle for coordinates");

                Interop.CoordinatesHandle clonedHandle = new Interop.CoordinatesHandle(clonedNativeHandle);
                err = Interop.Coordinates.ListAppend(handle, clonedHandle);
                if (err.WarnIfFailed("Failed to add coordinate to the list"))
                {
                    clonedHandle.ReleaseOwnership();
                }
            }
        }

        /// <summary>
        /// Iterator for coordinates in this list
        /// </summary>
        internal IEnumerable<Geocoordinates> Coordinates
        {
            get
            {
                List<Geocoordinates> list = new List<Geocoordinates>();
                Interop.Coordinates.CoordinatesCallback callback = (index, handle, userData) =>
                {
                    IntPtr clonedNativeHandle;
                    var result = Interop.Coordinates.Clone(handle, out clonedNativeHandle);
                    if (result.WarnIfFailed("Failed to add coordinate to the list"))
                    {
                        Interop.CoordinatesHandle clonedHandle = new Interop.CoordinatesHandle(clonedNativeHandle);
                        list.Add(new Geocoordinates(clonedHandle));
                    }
                    return true;
                };

                var err = Interop.Coordinates.ListForeach(handle, callback, IntPtr.Zero);
                err.WarnIfFailed("Failed to get coordinates list from native handle");
                return list;
            }
        }
    }
}
