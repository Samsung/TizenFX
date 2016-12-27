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
    /// Geocode request for map service
    /// </summary>
    public class GeocodeRequest : MapServiceRequest<Geocoordinates>
    {
        private Interop.Service.GeocodeCallback _responseCallback;
        private List<Geocoordinates> _coordinateList = new List<Geocoordinates>();
        private GeocodePreference _preferences = new GeocodePreference();

        internal GeocodeRequest(MapService service, string address) : this(service, ServiceRequestType.Geocode)
        {
            startExecutionAction = new Action(() =>
            {
                int requestID;
                errMessage = string.Format("Failed to get co-ordinates for given address {0}", address);
                errorCode = Interop.Service.Geocode(_service, address, _preferences.handle, _responseCallback, IntPtr.Zero, out requestID);
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
                errMessage = string.Format("Failed to get co-ordinates for given address {0}", address);
                errorCode = Interop.Service.GeocodeInsideArea(_service, address, boundry.handle, _preferences.handle, _responseCallback, IntPtr.Zero, out requestID);
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
                errMessage = string.Format("Failed to get co-ordinates for given address {0}", address);
                errorCode = Interop.Service.GeocodeByStructuredAddress(_service, address.handle, _preferences.handle, _responseCallback, IntPtr.Zero, out requestID);
                if (errorCode.IsFailed() && errorCode != Interop.ErrorCode.Canceled)
                {
                    _requestTask?.TrySetException(errorCode.GetException(errMessage));
                }
                _requestID = requestID;
            });
        }

        private GeocodeRequest(MapService service, ServiceRequestType type) : base(service, type)
        {
            _preferences = service.GeocodePreferences;
            _responseCallback = (result, id, index, total, coordinatesHandle, userData) =>
            {
                errorCode = result;
                if (result.IsSuccess())
                {
                    _coordinateList.Add(new Geocoordinates(coordinatesHandle));
                    if (_coordinateList.Count == total)
                    {
                        _requestTask?.TrySetResult(_coordinateList);
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
