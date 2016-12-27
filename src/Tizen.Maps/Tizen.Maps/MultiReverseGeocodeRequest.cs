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
    /// Multiple Reverse geocode Request for Tizen map service
    /// </summary>
    public class MultiReverseGeocodeRequest : MapServiceRequest<PlaceAddress>
    {
        private Interop.Service.MultiReverseGeocodeCallback _responseCallback;
        private List<PlaceAddress> _addressesList = new List<PlaceAddress>();
        private GeocodePreference _preferences;

        internal MultiReverseGeocodeRequest(MapService service, IEnumerable<Geocoordinates> coordinates) : base(service, ServiceRequestType.ReverseGeocode)
        {
            var coordinateList = new GeocoordinatesList(coordinates, true);
            _preferences = service.GeocodePreferences;
            _responseCallback = (result, id, total, addressListHandle, userData) =>
            {
                errorCode = result;
                if (result.IsSuccess())
                {
                    var addressList = new PlaceAddressList(addressListHandle);
                    addressList.handle.ReleaseOwnership();
                    _addressesList = addressList.Addresses as List<PlaceAddress>;
                    _requestTask?.TrySetResult(_addressesList);
                    return true;
                }
                else
                {
                    _requestTask?.TrySetException(errorCode.GetException(errMessage));
                    return false;
                }
            };

            startExecutionAction = new Action(() =>
            {
                int requestID;
                errMessage = "Failed to get address list for given co-ordinate list";
                errorCode = Interop.Service.MultiReverseGeocode(_service, coordinateList.handle, _preferences.handle, _responseCallback, IntPtr.Zero, out requestID);
                if (errorCode.IsFailed() && errorCode != Interop.ErrorCode.Canceled)
                {
                    _requestTask?.TrySetException(errorCode.GetException(errMessage));
                }
                _requestID = requestID;
            });
        }
    }
}
