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
    /// List of <see cref="PlaceAddress"/> objects to be used in <see cref="ServiceData.MapService"/> APIs
    /// </summary>
    internal class PlaceAddressList
    {
        internal Interop.AddressListHandle handle;
        private List<PlaceAddress> _list;

        /// <summary>
        /// Construct map address list object
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Throws if native operation failed to allocate memory</exception>
        public PlaceAddressList()
        {
            IntPtr nativeHandle;
            var err = Interop.Address.ListCreate(out nativeHandle);
            err.ThrowIfFailed("Failed to create native handle for address list");

            handle = new Interop.AddressListHandle(nativeHandle);
        }

        internal PlaceAddressList(IntPtr nativeHandle)
        {
            handle = new Interop.AddressListHandle(nativeHandle);
        }

        /// <summary>
        /// Iterator for addresses in this list
        /// </summary>
        public IEnumerable<PlaceAddress> Addresses
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<PlaceAddress>();
                    Interop.Address.AddressCallback callback = (index, handle, userData) =>
                    {
                        IntPtr cloned;
                        // we need to clone handle as it will not be there once this callback returns
                        if (Interop.Address.Clone(handle, out cloned).IsSuccess())
                        {
                            _list.Add(new PlaceAddress(cloned));
                        }
                        return true;
                    };

                    var err = Interop.Address.ListForeach(handle, callback, IntPtr.Zero);
                    err.WarnIfFailed("Failed to get address list from native handle");
                }
                return _list;
            }
        }
    }
}
