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
    /// Place media information, used in place discovery and search requests.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PlaceMedia
    {
        private string _attribution;
        private PlaceLink _supplier;
        private PlaceLink _via;

        internal PlaceMedia(Interop.PlaceMediaHandle handle)
        {
            _attribution = handle.Attribution;
            _supplier = new PlaceLink(handle.Supplier);
            _via = new PlaceLink(handle.Via);
        }

        /// <summary>
        /// Gets a string representing the attribution for this place media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Attribution { get { return _attribution; } }

        /// <summary>
        /// Gets an instance of <see cref="PlaceLink"/> object representing the supplier for this place media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PlaceLink Supplier { get { return _supplier; } }

        /// <summary>
        /// Gets an instance of <see cref="PlaceLink"/> object representing via data for this place media.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PlaceLink Via { get { return _via; } }
    }
}
