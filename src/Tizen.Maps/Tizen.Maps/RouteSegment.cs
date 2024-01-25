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
using System.Collections.Generic;

namespace Tizen.Maps
{
    /// <summary>
    /// Place Segment information used in Route Search requests.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API11. Might be removed in API13.")]
    public class RouteSegment
    {
        private Geocoordinates _origin;
        private Geocoordinates _destination;
        private double _distance;
        private double _duration;
        private Area _boundingBox;

        private List<RouteManeuver> _maneuvers = new List<RouteManeuver>();
        private List<Geocoordinates> _path = new List<Geocoordinates>();

        internal RouteSegment(Interop.RouteSegmentHandle handle)
        {
            _origin = new Geocoordinates(handle.Origin);
            _destination = new Geocoordinates(handle.Destination);
            _distance = handle.Distance;
            _duration = handle.Duration;
            _boundingBox = new Area(handle.BoundingBox);

            handle.ForeachManeuver(maneuverHandle => _maneuvers.Add(new RouteManeuver(maneuverHandle)));
            handle.ForeachPath(pathHandle => _path.Add(new Geocoordinates(pathHandle)));
        }

        /// <summary>
        /// Gets the origin coordinates for this segment.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public Geocoordinates Origin { get { return _origin; } }

        /// <summary>
        /// Gets the destination coordinates for this segment.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public Geocoordinates Destination { get { return _destination; } }

        /// <summary>
        /// Gets the total distance for this segment.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public double Distance { get { return _distance; } }

        /// <summary>
        /// Gets the total duration to cover this segment.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public double Duration { get { return _duration; } }

        /// <summary>
        /// Gets the maneuver list for this segment.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public IEnumerable<RouteManeuver> Maneuvers { get { return _maneuvers; } }

        /// <summary>
        /// Gets the coordinates list for this segment.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public IEnumerable<Geocoordinates> Path { get { return _path; } }

        private Area BoundingBox { get { return _boundingBox; } }
    }
}
