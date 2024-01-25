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
namespace Tizen.Location.Geofence
{
    /// <summary>
    /// Represents the geofence list item data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API11. Might be removed in API13")]
    public class FenceData
    {
        internal FenceData(int fenceId, IntPtr handle, int index, int count)
        {
            GeofenceId = fenceId;
            Fence = new Fence(handle);
            Index = index;
            Count = count;
        }
        /// <summary>
        /// The geofence instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API11. Might be removed in API13")]
        public Fence Fence
        {
            get;
            internal set;
        }

        /// <summary>
        /// The geofence ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API11. Might be removed in API13")]
        public int GeofenceId
        {
            get;
            internal set;
        }

        /// <summary>
        /// The index number of fences in the list.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The index value starts from 1.</value>
        [Obsolete("Deprecated since API11. Might be removed in API13")]
        public int Index
        {
            get;
            internal set;
        }

        /// <summary>
        /// The total number of fences that exists for the requester.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API11. Might be removed in API13")]
        public int Count
        {
            get;
            internal set;
        }
    };

    /// <summary>
    /// Represents the place list item data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API11. Might be removed in API13")]
    public class PlaceData
    {
        internal PlaceData(int id, string name, int index, int count)
        {
            PlaceId = id;
            Name = name;
            Index = index;
            Count = count;
        }
        /// <summary>
        /// The current place ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API11. Might be removed in API13")]
        public int PlaceId
        {
            get;
            internal set;
        }

        /// <summary>
        /// The current place name.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API11. Might be removed in API13")]
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        /// The index number of places in the list.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The index value starts from 1.</value>
        [Obsolete("Deprecated since API11. Might be removed in API13")]
        public int Index
        {
            get;
            internal set;
        }

        /// <summary>
        /// The total number of places that exists for the requester.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API11. Might be removed in API13")]
        public int Count
        {
            get;
            internal set;
        }
    };
}
