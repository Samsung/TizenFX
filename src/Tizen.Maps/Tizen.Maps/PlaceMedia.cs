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
    /// Place Media information, used in Place Discovery and Search requests
    /// </summary>
    public class PlaceMedia
    {
        private string _attribution;
        private PlaceLink _supplier;
        private PlaceLink _via;

        internal PlaceMedia(IntPtr nativeHandle)
        {
            var handle = new Interop.PlaceMediaHandle(nativeHandle);

            Interop.PlaceMedia.GetAttribution(handle, out _attribution);

            IntPtr supplierHandle;
            var err = Interop.PlaceMedia.GetSupplier(handle, out supplierHandle);
            if (err.IsSuccess())
                _supplier = new PlaceLink(supplierHandle);

            IntPtr viaHandle;
            err = Interop.PlaceMedia.GetVia(handle, out viaHandle);
            if (err.IsSuccess())
                _via = new PlaceLink(viaHandle);
        }

        /// <summary>
        /// Place media attribution
        /// </summary>
        public string Attribution { get { return _attribution; } }

        /// <summary>
        /// Place media supplier value
        /// </summary>
        public PlaceLink Supplier { get { return _supplier; } }

        /// <summary>
        /// Place media via value
        /// </summary>
        public PlaceLink Via { get { return _via; } }
    }
}
