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
    /// Reverses the geocode request for a map service.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ReverseGeocodeRequest : MapServiceRequest<PlaceAddress>
    {
        private Interop.ReverseGeocodeCallback _geocodeCallback;
        private List<PlaceAddress> _addressList = new List<PlaceAddress>();

        internal ReverseGeocodeRequest(MapService service, double latitude, double longitute) : base(service, ServiceRequestType.ReverseGeocode)
        {
            // The Maps Service invokes this callback when the address is obtained from the specified coordinates.
            _geocodeCallback = (result, id, index, total, address, userData) =>
            {
                errorCode = result;
                if (result.IsSuccess())
                {
                    // The parameter address must be released using maps_address_destroy().
                    var addressHandle = new Interop.AddressHandle(address, needToRelease: true);
                    _addressList.Add(new PlaceAddress(addressHandle));
                    if (_addressList.Count == total)
                    {
                        _requestTask?.TrySetResult(_addressList);
                    }
                }
                else
                {
                    // If search is failed, the value of total is 0 and address is NULL
                    _requestTask?.TrySetException(errorCode.GetException(errMessage));
                }
            };

            startExecutionAction = new Action(() =>
            {
                int requestID;
                errMessage = $"Failed to get address for given coordinates: {latitude}:{longitute}";
                errorCode = _service.handle.ReverseGeocode(latitude, longitute, _service.Preferences.handle, _geocodeCallback, IntPtr.Zero, out requestID);
                if (errorCode.IsFailed() && errorCode != Interop.ErrorCode.Canceled)
                {
                    _requestTask?.TrySetException(errorCode.GetException(errMessage));
                }
                _requestID = requestID;
            });
        }
    }
}
