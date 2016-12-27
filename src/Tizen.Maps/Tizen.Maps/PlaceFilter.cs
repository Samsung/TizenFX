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
    /// Place Filter information, used in Place Discovery and Search requests
    /// </summary>
    public class PlaceFilter
    {
        internal Interop.PlaceFilterHandle handle;
        private string _address;
        private PlaceCategory _category;
        private string _keyword;
        private string _name;

        /// <summary>
        /// Constructs new place filter
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Throws if native operation failed to allocate memory</exception>
        public PlaceFilter()
        {
            IntPtr nativeHandle;
            var err = Interop.PlaceFilter.Create(out nativeHandle);
            err.ThrowIfFailed("Failed to create native place filter handle");

            handle = new Interop.PlaceFilterHandle(nativeHandle);
        }

        /// <summary>
        /// Filter string for place addresses
        /// </summary>
        public string Address
        {
            get
            {
                if (string.IsNullOrEmpty(_address))
                {
                    var err = Interop.PlaceFilter.GetPlaceAddress(handle, out _address);
                    err.WarnIfFailed("Failed to get filter string for place addresses");
                }
                return _address;
            }
            set
            {
                var err = Interop.PlaceFilter.SetPlaceAddress(handle, value);
                if (err.WarnIfFailed("Failed to set filter string for place addresses"))
                {
                    _address = value;
                }
            }
        }

        /// <summary>
        /// Category filter for places
        /// </summary>
        public PlaceCategory Category
        {
            get
            {
                if (_category == null)
                {
                    IntPtr nativeHandle;
                    var err = Interop.PlaceFilter.GetCategory(handle, out nativeHandle);
                    if (err.WarnIfFailed("Failed to get category filter for places"))
                    {
                        _category = new PlaceCategory(nativeHandle);
                    }
                }
                return _category;
            }
            set
            {
                var err = Interop.PlaceFilter.SetCategory(handle, value.handle);
                if (err.WarnIfFailed("Failed to set category filter for places"))
                {
                    _category = value;
                }
            }
        }

        /// <summary>
        /// Filter keyword for place
        /// </summary>
        public string Keyword
        {
            get
            {
                if (string.IsNullOrEmpty(_keyword))
                {
                    var err = Interop.PlaceFilter.GetKeyword(handle, out _keyword);
                    err.WarnIfFailed("Failed to get filter keywords for places");
                }
                return _keyword;
            }
            set
            {
                var err = Interop.PlaceFilter.SetKeyword(handle, value);
                if (err.WarnIfFailed("Failed to set filter keywords for places"))
                {
                    _keyword = value;
                }
            }
        }

        /// <summary>
        /// Filter string for place names
        /// </summary>
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                {
                    var err = Interop.PlaceFilter.GetPlaceName(handle, out _name);
                    err.WarnIfFailed("Failed to get filter string for place names");
                }
                return _name;
            }
            set
            {
                var err = Interop.PlaceFilter.SetPlaceName(handle, value);
                if (err.WarnIfFailed("Failed to set filter string for place names"))
                {
                    _name = value;
                }
            }
        }
    }
}
