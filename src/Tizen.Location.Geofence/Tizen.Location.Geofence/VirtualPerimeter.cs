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

namespace Tizen.Location.Geofence
{
    /// <summary>
    /// Allows to create a virtual fence as Geofence using GeofenceManager instance.
    /// User can manage all the geofence/place related data and events.
    /// </summary>
    /// <since_tizen>3</since_tizen>
    public class VirtualPerimeter
    {
        private IntPtr Handle;

        /// <summary>
        /// Creates a VirtualPerimeter which can be used to create virtual fence.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <param name="manager">GeofenceManager instance.</param>
        /// <exception cref="ArgumentException"> Incase of invlid parameter.</exception>
        public VirtualPerimeter(GeofenceManager manager)
        {
            if (manager == null)
            {
                throw GeofenceErrorFactory.CreateException(GeofenceError.InvalidParameter, "Invalid GeofenceManager instance");
            }
            else
            {
                Handle = manager.Handle;
            }
        }

        /// <summary>
        /// Creates a new place for geofencing service.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <param name="name">A place name to be created.</param>
        /// <returns>The place id to be newly created on success.</returns>
        /// <privilege>http://tizen.org/privilege/location</privilege>
        /// <exception cref="ArgumentException">Incase of Invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Incase of any System error.</exception>
        /// <exception cref="UnauthorizedAccessException">Incase of Privileges are not defined.</exception>
        /// <exception cref="NotSupportedException">Incase of Geofence is not supported.</exception>
        public int AddPlaceName(string name)
        {
            int placeId = 0;
            GeofenceError ret = (GeofenceError)Interop.VirtualPerimeter.AddPlace(Handle, name, out placeId);
            if (ret != GeofenceError.None)
            {
                throw GeofenceErrorFactory.CreateException(ret, "Failed to add place to Geofence Manager for " + name);
            }

            return placeId;
        }

        /// <summary>
        /// Updates the place name of a given place id.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <param name="placeId">The specified place id.</param>
        /// <param name="name">A new place name of the place id.</param>
        /// <privilege>http://tizen.org/privilege/location</privilege>
        /// <exception cref="ArgumentException">Incase of Invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Incase of any System error.</exception>
        /// <exception cref="UnauthorizedAccessException">Incase of Privileges are not defined.</exception>
        /// <exception cref="NotSupportedException">Incase of Geofence is not supported.</exception>
        public void UpdatePlace(int placeId, string name)
        {
            GeofenceError ret = (GeofenceError)Interop.VirtualPerimeter.UpdatePlace(Handle, placeId, name);
            if (ret != GeofenceError.None)
            {
                throw GeofenceErrorFactory.CreateException(ret, "Failed to update place to Geofence Manager for " + placeId);
            }
        }

        /// <summary>
        /// Removes the specific place for geofencing service.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <param name="placeId">The specified place id.</param>
        /// <privilege>http://tizen.org/privilege/location</privilege>
        /// <exception cref="ArgumentException">Incase of Invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Incase of any System error.</exception>
        /// <exception cref="UnauthorizedAccessException">Incase of Privileges are not defined.</exception>
        /// <exception cref="NotSupportedException">Incase of Geofence is not supported.</exception>
        public void RemovePlace(int placeId)
        {
            GeofenceError ret = (GeofenceError)Interop.VirtualPerimeter.RemovePlace(Handle, placeId);
            if (ret != GeofenceError.None)
            {
                throw GeofenceErrorFactory.CreateException(ret, "Failed to remove place from Geofence Manager for " + placeId);
            }
        }

        /// <summary>
        /// Adds a geofence for a given geofence manager.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <param name="fence">The Geofence instance to be added.</param>
        /// <returns>The geofence id to be newly created on success.</returns>
        /// <remarks> The retun value will always be a number greater than zero.</remarks>
        /// <privilege>http://tizen.org/privilege/location</privilege>
        /// <exception cref="ArgumentException">Incase of Invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Incase of any System error.</exception>
        /// <exception cref="UnauthorizedAccessException">Incase of Privileges are not defined.</exception>
        /// <exception cref="NotSupportedException">Incase of Geofence is not supported.</exception>
        public int AddGeofence(Fence fence)
        {
            int fenceId = 0;
            GeofenceError ret = (GeofenceError)Interop.VirtualPerimeter.AddFence(Handle, fence.Handle, out fenceId);
            if (ret != GeofenceError.None)
            {
                throw GeofenceErrorFactory.CreateException(ret, "Failed to add fence to Geofence Manager ");
            }

            return fenceId;
        }

        /// <summary>
        /// Removes a geofence with a given geofence id.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <param name="fenceId">The specified geofence id.</param>
        /// <privilege>http://tizen.org/privilege/location</privilege>
        /// <exception cref="ArgumentException">Incase of Invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Incase of any System error.</exception>
        /// <exception cref="UnauthorizedAccessException">Incase of Privileges are not defined.</exception>
        /// <exception cref="NotSupportedException">Incase of Geofence is not supported.</exception>
        public void RemoveGeofence(int fenceId)
        {
            GeofenceError ret = (GeofenceError)Interop.VirtualPerimeter.RemoveFence(Handle, fenceId);
            if (ret != GeofenceError.None)
            {
                throw GeofenceErrorFactory.CreateException(ret, "Failed to remove geofence from Geofence Manager for " + fenceId);
            }
        }

        /// <summary>
        /// Gets the name of place.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <param name="placeId">The place id.</param>
        /// <returns>The name of the place.</returns>
        /// <privilege>http://tizen.org/privilege/location</privilege>
        /// <exception cref="ArgumentException">Incase of Invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Incase of any System error.</exception>
        /// <exception cref="UnauthorizedAccessException">Incase of Privileges are not defined.</exception>
        /// <exception cref="NotSupportedException">Incase of Geofence is not supported.</exception>
        public string GetPlaceName(int placeId)
        {
            string name = "";
            GeofenceError ret = (GeofenceError)Interop.VirtualPerimeter.GetPlaceName(Handle, placeId, out name);
            if (ret != GeofenceError.None)
            {
                throw GeofenceErrorFactory.CreateException(ret, "Failed to get placenamefrom Geofence Manager for " + placeId);
            }

            return name;
        }

        /// <summary>
        /// Retrieves a list of places registered in the specified geofence manager.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <returns>list of places registered as PlaceData instance list.</returns>
        /// <privilege>http://tizen.org/privilege/location</privilege>
        /// <exception cref="InvalidOperationException">Incase of any System error.</exception>
        /// <exception cref="UnauthorizedAccessException">Incase of Privileges are not defined.</exception>
        /// <exception cref="NotSupportedException">Incase of Geofence is not supported.</exception>
        public IEnumerable<PlaceData> GetPlaceDataList()
        {
            List<PlaceData> places = new List<PlaceData>();
            Interop.VirtualPerimeter.ForEachPlaceListCallback placeCallback = (int placeId, string name, int index, int count, IntPtr data) =>
            {
                if (count != 0)
                {
                    PlaceData place = new PlaceData(placeId, name, index, count);
                    places.Add(place);
                }
                return true;
            };

            GeofenceError ret = (GeofenceError)Interop.VirtualPerimeter.GetForEachPlaceList(Handle, placeCallback, IntPtr.Zero);
            if (ret != GeofenceError.None)
            {
                throw GeofenceErrorFactory.CreateException(ret, "Failed to get Places list from Geofence Manager ");
            }

            return places;
        }

        /// <summary>
        /// Retrieves a list of fences registered in the specified geofence manager.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <returns>list of FenceData instances registred for each Geofence.</returns>
        /// <privilege>http://tizen.org/privilege/location</privilege>
        /// <exception cref="InvalidOperationException">Incase of any System error.</exception>
        /// <exception cref="UnauthorizedAccessException">Incase of Privileges are not defined.</exception>
        /// <exception cref="NotSupportedException">Incase of Geofence is not supported.</exception>
        public IEnumerable<FenceData> GetFenceDataList()
        {
            List<FenceData> fences = new List<FenceData>();
            Interop.VirtualPerimeter.ForEachFenceListCallback callback = (int fenceId, IntPtr handle, int index, int count, IntPtr data) =>
            {
                if (count != 0)
                {
                    FenceData fence = new FenceData(fenceId, handle, index, count);
                    fences.Add(fence);
                }
                return true;
            };

            GeofenceError ret = (GeofenceError)Interop.VirtualPerimeter.GetForEachFenceList(Handle, callback, IntPtr.Zero);
            if (ret != GeofenceError.None)
            {
                throw GeofenceErrorFactory.CreateException(ret, "Failed to get Geofence list from Geofence Manager ");
            }

            return fences;
        }

        /// <summary>
        /// Retrieves a list of fences registered in the specified place.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <param name="placeId"> The place id.</param>
        /// <returns>list of FenceData instances registred for each Geofence for specified place.</returns>
        /// <privilege>http://tizen.org/privilege/location</privilege>
        /// <exception cref="ArgumentException">Incase of Invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Incase of any System error.</exception>
        /// <exception cref="UnauthorizedAccessException">Incase of Privileges are not defined.</exception>
        /// <exception cref="NotSupportedException">Incase of Geofence is not supported.</exception>
        public IEnumerable<FenceData> GetGeofenceDataListByPlaceId(int placeId)
        {
            List<FenceData> fences = new List<FenceData>();
            Interop.VirtualPerimeter.ForEachFenceListCallback callback = (int fenceId, IntPtr handle, int index, int count, IntPtr data) =>
            {
                FenceData fence = new FenceData(fenceId, handle, index, count);
                fences.Add(fence);
                return true;
            };

            GeofenceError ret = (GeofenceError)Interop.VirtualPerimeter.GetForEachPlaceFenceList(Handle, placeId, callback, IntPtr.Zero);
            if (ret != GeofenceError.None)
            {
                throw GeofenceErrorFactory.CreateException(ret, "Failed to get Geofence list from Geofence Manager for " + placeId);
            }

            return fences;
        }
    }
}
