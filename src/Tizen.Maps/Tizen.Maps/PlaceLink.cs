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
    /// Place link object information, used in place discovery and search requests.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API11. Might be removed in API13.")]
    public class PlaceLink
    {
        private string _id;
        private string _name;
        private string _link;
        private string _type;

        internal PlaceLink(Interop.PlaceLinkObjectHandle handle)
        {
            _id = handle.Id;
            _name = handle.Name;
            _link = handle.Link;
            _type = handle.Type;
        }

        /// <summary>
        /// Gets a string representing the ID for this place link.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public string Id { get { return _id; } }

        /// <summary>
        /// Gets a string representing the name for this place link.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public string Name { get { return _name; } }

        /// <summary>
        /// Gets a string representing the link for this place link.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public string Link { get { return _link; } }

        /// <summary>
        /// Gets a string representing the type for this place link.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public string Type { get { return _type; } }
    }
}
