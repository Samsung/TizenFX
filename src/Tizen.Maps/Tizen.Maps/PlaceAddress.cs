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
    public class PlaceAddress : IDisposable
    {
        internal Interop.AddressHandle handle;

        /// <summary>
        /// Construct map address object
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Throws if native operation failed to allocate memory</exception>
        public PlaceAddress()
        {
            handle = new Interop.AddressHandle();
        }

        internal PlaceAddress(Interop.AddressHandle nativeHandle)
        {
            handle = nativeHandle;
        }

        /// <summary>
        /// Building number for this address
        /// </summary>
        public string Building
        {
            get
            {
                return handle.Building;
            }
            set
            {
                handle.Building = value;
            }
        }

        /// <summary>
        /// City name for this address
        /// </summary>
        public string City
        {
            get
            {
                return handle.City;
            }
            set
            {
                handle.City = value;
            }
        }

        /// <summary>
        /// Country name for this address
        /// </summary>
        public string Country
        {
            get
            {
                return handle.Country;
            }
            set
            {
                handle.Country = value;
            }
        }

        /// <summary>
        /// Country code for this address
        /// </summary>
        public string CountryCode
        {
            get
            {
                return handle.CountryCode;
            }
            set
            {
                handle.CountryCode = value;
            }
        }

        /// <summary>
        /// County for this address
        /// </summary>
        public string County
        {
            get
            {
                return handle.County;
            }
            set
            {
                handle.County = value;
            }
        }

        /// <summary>
        /// District name for this address
        /// </summary>
        public string District
        {
            get
            {
                return handle.District;
            }
            set
            {
                handle.District = value;
            }
        }

        /// <summary>
        /// Free text associated with this address
        /// </summary>
        public string Freetext
        {
            get
            {
                return handle.Freetext;
            }
            set
            {
                handle.Freetext = value;
            }
        }

        /// <summary>
        /// Postal code for this address
        /// </summary>
        public string PostalCode
        {
            get
            {
                return handle.PostalCode;
            }
            set
            {
                handle.PostalCode = value;
            }
        }

        /// <summary>
        /// State name for this address
        /// </summary>
        public string State
        {
            get
            {
                return handle.State;
            }
            set
            {
                handle.State = value;
            }
        }

        /// <summary>
        /// Street name for this address
        /// </summary>
        public string Street
        {
            get
            {
                return handle.Street;
            }
            set
            {
                handle.Street = value;
            }
        }

        /// <summary>
        /// String that represents this address
        /// </summary>
        public override string ToString()
        {
            return $"{Freetext}";
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                handle.Dispose();
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
