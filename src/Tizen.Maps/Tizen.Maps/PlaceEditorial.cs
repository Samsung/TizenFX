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
    /// Place Editorial information, used in Place Discovery and Search requests
    /// </summary>
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
        /// Place editorial description
        /// </summary>
        public string Description { get { return _description; } }

        /// <summary>
        /// Place editorial language
        /// </summary>
        public string Language { get { return _language; } }

        /// <summary>
        /// Place editorial value
        /// </summary>
        public PlaceMedia Media { get { return _media; } }

        /// <summary>
        /// String that represents this place media
        /// </summary>
        public override string ToString()
        {
            return $"{Description}";
        }
    }
}
