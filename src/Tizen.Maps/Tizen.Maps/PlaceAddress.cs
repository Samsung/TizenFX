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
using System.ComponentModel;

namespace Tizen.Maps
{
    /// <summary>
    /// Address information for the map point used in geocode and reverse geocode requests.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API11. Might be removed in API13.")]
    public class PlaceAddress : IDisposable
    {
        internal Interop.AddressHandle handle;

        /// <summary>
        /// Constructs a map address object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="System.InvalidOperationException">Thrown when native operation failed to allocate memory.</exception>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public PlaceAddress()
        {
            handle = new Interop.AddressHandle();
        }

        internal PlaceAddress(Interop.AddressHandle nativeHandle)
        {
            handle = nativeHandle;
        }

        /// <summary>
        /// Destroy the PlaceAddress object.
        /// </summary>
        ~PlaceAddress()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets a building number for this address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
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
        /// Gets a city name for this address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
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
        /// Gets a country name for this address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
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
        /// Gets a country code for this address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
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
        /// Gets a county for this address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
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
        /// Gets a district name for this address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
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
        /// Gets a free text associated with this address.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public string FreeText
        {
            get
            {
                return handle.FreeText;
            }
            set
            {
                handle.FreeText = value;
            }
        }

        /// <summary>
        /// Gets a postal code for this address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
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
        /// Gets a state name for this address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
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
        /// Gets a street name for this address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
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
        /// Returns a string that represents this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Returns a string which presents this object.</returns>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public override string ToString()
        {
            return $"{FreeText}";
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">If true, managed and unmanaged resources can be disposed, otherwise only unmanaged resources can be disposed.</param>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                handle?.Dispose();
                _disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all the resources used by this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
