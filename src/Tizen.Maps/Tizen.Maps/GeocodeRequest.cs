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
    /// Geocode request for the map service.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class GeocodeRequest : MapServiceRequest<Geocoordinates>
    {
        private Interop.GeocodeCallback _geocodeCallback;
        private List<Geocoordinates> _coordinateList = new List<Geocoordinates>();

        internal GeocodeRequest(MapService service, string address) : this(service, ServiceRequestType.Geocode)
        {
            startExecutionAction = new Action(() =>
            {
                int requestID;
                errMessage = $"Failed to get coordinates for given address {address}";
                errorCode = _service.handle.Geocode(address, _service.Preferences.handle, _geocodeCallback, IntPtr.Zero, out requestID);
                if (errorCode.IsFailed() && errorCode != Interop.ErrorCode.Canceled)
                {
                    _requestTask?.TrySetException(errorCode.GetException(errMessage));
                }
                _requestID = requestID;
            });
        }

        internal GeocodeRequest(MapService service, string address, Area boundry) : this(service, ServiceRequestType.GeocodeInsideArea)
        {
            startExecutionAction = new Action(() =>
            {
                int requestID;
                errMessage = $"Failed to get coordinates for given address {address}";
                errorCode = _service.handle.GeocodeInsideArea(address, boundry.handle, _service.Preferences.handle, _geocodeCallback, IntPtr.Zero, out requestID);
                if (errorCode.IsFailed() && errorCode != Interop.ErrorCode.Canceled)
                {
                    _requestTask?.TrySetException(errorCode.GetException(errMessage));
                }
                _requestID = requestID;
            });
        }

        internal GeocodeRequest(MapService service, PlaceAddress address) : this(service, ServiceRequestType.GeocodeByStructuredAddress)
        {
            startExecutionAction = new Action(() =>
            {
                int requestID;
                errMessage = $"Failed to get coordinates for given address {address}";
                errorCode = _service.handle.GeocodeByStructuredAddress(address.handle, _service.Preferences.handle, _geocodeCallback, IntPtr.Zero, out requestID);
                if (errorCode.IsFailed() && errorCode != Interop.ErrorCode.Canceled)
                {
                    _requestTask?.TrySetException(errorCode.GetException(errMessage));
                }
                _requestID = requestID;
            });
        }

        private GeocodeRequest(MapService service, ServiceRequestType type) : base(service, type)
        {
            // The Maps Service invokes this callback while iterating through the list of obtained coordinates of the specified place.
            _geocodeCallback = (result, id, index, total, coordinates, userData) =>
            {
                errorCode = result;
                if (result.IsSuccess())
                {
                    // The parameter coordinates must be released using maps_coordinates_destroy()
                    var coordinatesHandle = new Interop.CoordinatesHandle(coordinates, needToRelease: true);
                    _coordinateList.Add(new Geocoordinates(coordinatesHandle));
                    if (_coordinateList.Count == total)
                    {
                        _requestTask?.TrySetResult(_coordinateList);
                    }
                    return true;
                }
                else
                {
                    // If the search fails, the value of total is 0 and coordinates is NULL.
                    _requestTask?.TrySetException(result.GetException(errMessage));
                    return false;
                }
            };
        }
    }
}
