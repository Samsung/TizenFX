﻿/*
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
    /// Place image information, used in place discovery and search requests.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API11. Might be removed in API13.")]
    public class PlaceImage
    {
        private string _id;
        private string _url;
        private int _width;
        private int _height;
        private PlaceLink _userLink;
        private PlaceMedia _media;

        internal PlaceImage(Interop.PlaceImageHandle handle)
        {
            _id = handle.Id;
            _url = handle.Url;
            _width = handle.Width;
            _height = handle.Height;
            _userLink = new PlaceLink(handle.User);
            _media = new PlaceMedia(handle.Media);
        }

        /// <summary>
        /// Gets an ID for this place image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public string Id { get { return _id; } }

        /// <summary>
        /// Gets an URL for this place image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public string Url { get { return _url; } }

        /// <summary>
        /// Gets the width for this place image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public int Width { get { return _width; } }

        /// <summary>
        /// Gets the height for this place image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public int Height { get { return _height; } }

        /// <summary>
        /// Gets an object representing the user link for this place image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public PlaceLink UserLink { get { return _userLink; } }

        /// <summary>
        /// Gets an object representing the image media for this place image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public PlaceMedia ImageMedia { get { return _media; } }
    }
}
