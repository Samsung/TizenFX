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
        private Interop.MultiReverseGeocodeCallback _geocodeCallback;
        private List<PlaceAddress> _addressesList = new List<PlaceAddress>();

        internal MultiReverseGeocodeRequest(MapService service, IEnumerable<Geocoordinates> coordinates) : base(service, ServiceRequestType.ReverseGeocode)
        {
            // The Maps Service invokes this callback once when gets the response from map service provider
            // The value of total is same with requested coordinates list size. Even though one of address is not provided valid address handle is retrieved.
            _geocodeCallback = (result, id, total, handle, userData) =>
            {
                errorCode = result;
                if (result.IsSuccess())
                {
                    var addressListHandle = new Interop.AddressListHandle(handle, needToRelease: true);
                    var addressList = new PlaceAddressList(addressListHandle);
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

            var coordinateList = new GeocoordinatesList(coordinates);
            startExecutionAction = new Action(() =>
            {
                int requestID;
                errMessage = "Failed to get address list for given co-ordinate list";
                errorCode = _service.handle.MultiReverseGeocode(coordinateList.handle, _service.Preferences.handle, _geocodeCallback, IntPtr.Zero, out requestID);
                if (errorCode.IsFailed() && errorCode != Interop.ErrorCode.Canceled)
                {
                    _requestTask?.TrySetException(errorCode.GetException(errMessage));
                }
                _requestID = requestID;
            });
        }
    }
}
