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
    /// Place editorial information, used in place discovery and search requests.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PlaceEditorial
    {
        private string _description;
        private string _language;
        private PlaceMedia _media;

        internal PlaceEditorial(Interop.PlaceEditorialHandle handle)
        {
            _description = handle.Description;
            _language = handle.Language;
            _media = new PlaceMedia(handle.Media);
        }

        internal PlaceEditorial(IntPtr nativeHandle, bool needToRelease) : this(new Interop.PlaceEditorialHandle(nativeHandle, needToRelease))
        {
        }

        /// <summary>
        /// Gets a description for this place editorial.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Description { get { return _description; } }

        /// <summary>
        /// Gets a language for this place editorial.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Language { get { return _language; } }

        /// <summary>
        /// Gets an instance of <see cref="PlaceMedia"/> object which representing media for this place editorial.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PlaceMedia Media { get { return _media; } }

        /// <summary>
        /// Returns a string that represents this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Returns a string which presents this object.</returns>
        public override string ToString()
        {
            return $"{Description}";
        }
    }
}
