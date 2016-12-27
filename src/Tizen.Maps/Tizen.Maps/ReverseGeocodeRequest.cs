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
    /// Reverse geocode request for Tizen map service
    /// </summary>
    public class ReverseGeocodeRequest : MapServiceRequest<PlaceAddress>
    {
        private Interop.Service.ReverseGeocodeCallback _responseCallback;
        private List<PlaceAddress> _addressList = new List<PlaceAddress>();
        private GeocodePreference _preferences;

        internal ReverseGeocodeRequest(MapService service, double latitude, double longitute) : base(service, ServiceRequestType.ReverseGeocode)
        {
            _preferences = service.GeocodePreferences;
            _responseCallback = (result, id, index, total, addressHandle, userData) =>
            {
                errorCode = result;
                if (result.IsSuccess())
                {
                    _addressList.Add(new PlaceAddress(addressHandle));
                    if (_addressList.Count == total)
                    {
                        _requestTask?.TrySetResult(_addressList);
                    }
                }
                else
                {
                    _requestTask?.TrySetException(errorCode.GetException(errMessage));
                }
            };

            startExecutionAction = new Action(() =>
            {
                int requestID;
                errMessage = string.Format("Failed to get co-ordinates for given Coordinate: {0}:{1}", latitude, longitute);
                errorCode = Interop.Service.ReverseGeocode(_service, latitude, longitute, _preferences.handle, _responseCallback, IntPtr.Zero, out requestID);
                if (errorCode.IsFailed() && errorCode != Interop.ErrorCode.Canceled)
                {
                    _requestTask?.TrySetException(errorCode.GetException(errMessage));
                }
                _requestID = requestID;
            });
        }
    }
}
