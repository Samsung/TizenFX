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

namespace Tizen.Maps
{
    /// <summary>
    /// Address information for the map point used in Geocode and Reverse Geocode requests.
    /// </summary>
    public class PlaceAddress
    {
        internal Interop.AddressHandle handle;
        private string _building;
        private string _city;
        private string _country;
        private string _countryCode;
        private string _county;
        private string _district;
        private string _freetext;
        private string _postalCode;
        private string _state;
        private string _street;

        /// <summary>
        /// Construct map address object
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Throws if native operation failed to allocate memory</exception>
        public PlaceAddress()
        {
            IntPtr nativeHandle;
            var err = Interop.Address.Create(out nativeHandle);
            err.ThrowIfFailed("Failed to create native address handle");

            handle = new Interop.AddressHandle(nativeHandle);
        }

        internal PlaceAddress(IntPtr nativeHandle)
        {
            handle = new Interop.AddressHandle(nativeHandle);
        }

        /// <summary>
        /// Building number for this address
        /// </summary>
        public string Building
        {
            get
            {
                if (string.IsNullOrEmpty(_building))
                {
                    var err = Interop.Address.GetBuildingNumber(handle, out _building);
                    err.WarnIfFailed("Failed to get building number");
                }
                return _building == null ? string.Empty : _building;
            }
            set
            {
                var err = Interop.Address.SetBuildingNumber(handle, value);
                if (err.WarnIfFailed("Failed to set building number"))
                {
                    _building = value;
                }
            }
        }

        /// <summary>
        /// City name for this address
        /// </summary>
        public string City
        {
            get
            {
                if (string.IsNullOrEmpty(_city))
                {
                    var err = Interop.Address.GetCity(handle, out _city);
                    err.WarnIfFailed("Failed to get city");
                }
                return _city == null ? string.Empty : _city;
            }
            set
            {
                var err = Interop.Address.SetCity(handle, value);
                if (err.WarnIfFailed("Failed to set city"))
                {
                    _city = value;
                }
            }
        }

        /// <summary>
        /// Country name for this address
        /// </summary>
        public string Country
        {
            get
            {
                if (string.IsNullOrEmpty(_country))
                {
                    var err = Interop.Address.GetCountry(handle, out _country);
                    err.WarnIfFailed("Failed to get country");
                }
                return _country == null ? string.Empty : _country;
            }
            set
            {
                var err = Interop.Address.SetCountry(handle, value);
                if (err.WarnIfFailed("Failed to set country"))
                {
                    _country = value;
                }
            }
        }

        /// <summary>
        /// Country code for this address
        /// </summary>
        public string CountryCode
        {
            get
            {
                if (string.IsNullOrEmpty(_countryCode))
                {
                    var err = Interop.Address.GetCountryCode(handle, out _countryCode);
                    err.WarnIfFailed("Failed to get country code");
                }
                return _countryCode == null ? string.Empty : _countryCode;
            }
            set
            {
                var err = Interop.Address.SetCountryCode(handle, value);
                if (err.WarnIfFailed("Failed to set country code"))
                {
                    _countryCode = value;
                }
            }
        }

        /// <summary>
        /// County for this address
        /// </summary>
        public string County
        {
            get
            {
                if (string.IsNullOrEmpty(_county))
                {
                    var err = Interop.Address.GetCounty(handle, out _county);
                    err.WarnIfFailed("Failed to get county");
                }
                return _county == null ? string.Empty : _county;
            }
            set
            {
                var err = Interop.Address.SetCounty(handle, value);
                if (err.WarnIfFailed("Failed to set county"))
                {
                    _county = value;
                }
            }
        }

        /// <summary>
        /// District name for this address
        /// </summary>
        public string District
        {
            get
            {
                if (string.IsNullOrEmpty(_district))
                {
                    var err = Interop.Address.GetDistrict(handle, out _district);
                    err.WarnIfFailed("Failed to get district");
                }
                return _district == null ? string.Empty : _district;
            }
            set
            {
                var err = Interop.Address.SetDistrict(handle, value);
                if (err.WarnIfFailed("Failed to set district"))
                {
                    _district = value;
                }
            }
        }

        /// <summary>
        /// Free text associated with this address
        /// </summary>
        public string Freetext
        {
            get
            {
                if (string.IsNullOrEmpty(_freetext))
                {
                    var err = Interop.Address.GetFreetext(handle, out _freetext);
                    err.WarnIfFailed("Failed to get free-text");
                }
                return _freetext == null ? string.Empty : _freetext;
            }
            set
            {
                var err = Interop.Address.SetFreetext(handle, value);
                if (err.WarnIfFailed("Failed to set free-text"))
                {
                    _freetext = value;
                }
            }
        }

        /// <summary>
        /// Postal code for this address
        /// </summary>
        public string PostalCode
        {
            get
            {
                if (string.IsNullOrEmpty(_postalCode))
                {
                    var err = Interop.Address.GetPostalCode(handle, out _postalCode);
                    err.WarnIfFailed("Failed to get postal code");
                }
                return _postalCode == null ? string.Empty : _postalCode;
            }
            set
            {
                var err = Interop.Address.SetPostalCode(handle, value);
                if (err.WarnIfFailed("Failed to set postal code"))
                {
                    _postalCode = value;
                }
            }
        }

        /// <summary>
        /// State name for this address
        /// </summary>
        public string State
        {
            get
            {
                if (string.IsNullOrEmpty(_state))
                {
                    var err = Interop.Address.GetState(handle, out _state);
                    err.WarnIfFailed("Failed to get state");
                }
                return _state == null ? string.Empty : _state;
            }
            set
            {
                var err = Interop.Address.SetState(handle, value);
                if (err.WarnIfFailed("Failed to set state"))
                {
                    _state = value;
                }
            }
        }

        /// <summary>
        /// Street name for this address
        /// </summary>
        public string Street
        {
            get
            {
                if (string.IsNullOrEmpty(_street))
                {
                    var err = Interop.Address.GetStreet(handle, out _street);
                    err.WarnIfFailed("Failed to get street");
                }
                return _street == null ? string.Empty : _street;
            }
            set
            {
                var err = Interop.Address.SetStreet(handle, value);
                if (err.WarnIfFailed("Failed to set street"))
                {
                    _street = value;
                }
            }
        }
    }
}
