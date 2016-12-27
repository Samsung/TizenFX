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
        private Interop.Service.SearchPlaceCallback _responseCallback;
        private List<Place> _placeList = new List<Place>();
        private PlaceFilter _filter;
        private PlaceSearchPreference _preferences;

        internal PlaceSearchRequest(MapService service, Geocoordinates position, int distance) : this(service, ServiceRequestType.SearchPlace)
        {
            startExecutionAction = new Action(() =>
            {
                int requestID;
                errMessage = string.Format("Failed to get place list for given co-ordinate {0} and distance {1}", position, distance);
                errorCode = Interop.Service.SearchPlace(_service, position.handle, distance, _filter.handle, _preferences.handle, _responseCallback, IntPtr.Zero, out requestID);
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
                errMessage = string.Format("Failed to get place list for given boundary {0}", boundary);
                errorCode = Interop.Service.SearchPlaceByArea(_service, boundary.handle, _filter.handle, _preferences.handle, _responseCallback, IntPtr.Zero, out requestID);
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
                errMessage = string.Format("Failed to get co-ordinates for given address {0} and boundary {1}", address, boundary);
                errorCode = Interop.Service.SearchPlaceByAddress(_service, address, boundary.handle, _filter.handle, _preferences.handle, _responseCallback, IntPtr.Zero, out requestID);
                if (errorCode.IsFailed() && errorCode != Interop.ErrorCode.Canceled)
                {
                    _requestTask?.TrySetException(errorCode.GetException(errMessage));
                }
                _requestID = requestID;
            });
        }

        private PlaceSearchRequest(MapService service, ServiceRequestType type) : base(service, type)
        {
            _filter = service._filter;
            _preferences = service.PlaceSearchPreferences;
            _responseCallback = (result, id, index, total, placeHandle, userData) =>
            {
                errorCode = result;
                if (result.IsSuccess())
                {
                    _placeList.Add(new Place(placeHandle));
                    if (_placeList.Count == total)
                    {
                        _requestTask?.TrySetResult(_placeList);
                    }
                    return true;
                }
                else
                {
                    _requestTask?.TrySetException(errorCode.GetException(errMessage));
                    return false;
                }
            };
        }
    }
}
