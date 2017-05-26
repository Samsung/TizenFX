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
    /// Place search request for Tizen map service
    /// </summary>
    public class PlaceSearchRequest : MapServiceRequest<Place>
    {
        private Interop.SearchPlaceCallback _placeCallback;
        private List<Place> _placeList = new List<Place>();

        internal PlaceSearchRequest(MapService service, Geocoordinates position, int distance) : this(service, ServiceRequestType.SearchPlace)
        {
            startExecutionAction = new Action(() =>
            {
                int requestID;
                errMessage = $"Failed to get place list for given co-ordinate {position} and distance {distance}";
                errorCode = _service.handle.SearchPlace(position.handle, distance, _service.PlaceSearchFilter.handle, _service.Preferences.handle, _placeCallback, IntPtr.Zero, out requestID);
                if (errorCode.IsFailed() && errorCode != Interop.ErrorCode.Canceled)
                {
                    _requestTask?.TrySetException(errorCode.GetException(errMessage));
                }
                _requestID = requestID;
            });
        }

        internal PlaceSearchRequest(MapService service, Area boundary) : this(service, ServiceRequestType.SearchPlaceByArea)
        {
            startExecutionAction = new Action(() =>
            {
                int requestID;
                errMessage = $"Failed to get place list for given boundary";
                errorCode = _service.handle.SearchPlaceByArea(boundary.handle, _service.PlaceSearchFilter.handle, _service.Preferences.handle, _placeCallback, IntPtr.Zero, out requestID);
                if (errorCode.IsFailed() && errorCode != Interop.ErrorCode.Canceled)
                {
                    _requestTask?.TrySetException(errorCode.GetException(errMessage));
                }
                _requestID = requestID;
            });
        }

        internal PlaceSearchRequest(MapService service, string address, Area boundary) : this(service, ServiceRequestType.SearchPlaceByAddress)
        {
            startExecutionAction = new Action(() =>
            {
                int requestID;
                errMessage = $"Failed to get coordinates for address {address} in given boundary";
                errorCode = _service.handle.SearchPlaceByAddress(address, boundary.handle, _service.PlaceSearchFilter.handle, _service.Preferences.handle, _placeCallback, IntPtr.Zero, out requestID);
                if (errorCode.IsFailed() && errorCode != Interop.ErrorCode.Canceled)
                {
                    _requestTask?.TrySetException(errorCode.GetException(errMessage));
                }
                _requestID = requestID;
            });
        }

        private PlaceSearchRequest(MapService service, ServiceRequestType type) : base(service, type)
        {
            // The Maps Service invokes this callback while iterating through the set of obtained Place data.
            _placeCallback = (result, id, index, total, place, userData) =>
            {
                errorCode = result;
                if (result.IsSuccess())
                {
                    // The parameter place must be released using maps_place_destroy().
                    var placeHandle = new Interop.PlaceHandle(place, needToRelease: true);
                    _placeList.Add(new Place(placeHandle));
                    if (_placeList.Count == total)
                    {
                        _requestTask?.TrySetResult(_placeList);
                    }
                    return true;
                }
                else
                {
                    // If search is failed, the value of total is 0 and place is NULL
                    _requestTask?.TrySetException(errorCode.GetException(errMessage));
                    return false;
                }
            };
        }
    }
}
