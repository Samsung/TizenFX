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
    /// Place Segment information, used in Route Search requests
    /// </summary>
    public class RouteSegment
    {
        internal Interop.RouteSegmentHandle handle;
        private Area _bondingBox;
        private Geocoordinates _destination;
        private double _distance;
        private long _duration;
        private List<RouteManeuver> _manuevers;
        private Geocoordinates _origin;
        private List<Geocoordinates> _path;

        internal RouteSegment(IntPtr nativeHandle)
        {
            handle = new Interop.RouteSegmentHandle(nativeHandle);

            var err = Interop.RouteSegment.GetDistance(handle, out _distance);
            err.WarnIfFailed("Failed to get distance for the segment");

            err = Interop.RouteSegment.GetDuration(handle, out _duration);
            err.WarnIfFailed("Failed to get duration for the segment");

            IntPtr areaHandle;
            err = Interop.RouteSegment.GetBoundingBox(handle, out areaHandle);
            if (err.WarnIfFailed("Failed to get bonding box for the segment"))
            {
                _bondingBox = new Area(areaHandle);
            }

            IntPtr originHandle;
            err = Interop.RouteSegment.GetOrigin(handle, out originHandle);
            if (err.WarnIfFailed("Failed to get origin for the segment"))
            {
                _origin = new Geocoordinates(originHandle);
            }

            IntPtr destinationHandle;
            err = Interop.RouteSegment.GetDestination(handle, out destinationHandle);
            if (err.WarnIfFailed("Failed to get destination for the segment"))
            {
                _destination = new Geocoordinates(destinationHandle);
            }

            _manuevers = new List<RouteManeuver>();
            Interop.RouteSegment.SegmentManeuverCallback maneuvarCallback = (index, total, maneuverHandle, userData) =>
            {
                _manuevers.Add(new RouteManeuver(maneuverHandle));
                return true;
            };

            err = Interop.RouteSegment.ForeachManeuver(handle, maneuvarCallback, IntPtr.Zero);
            err.WarnIfFailed("Failed to get path maneuver for this segment");

            _path = new List<Geocoordinates>();
            Interop.RouteSegment.SegmentPathCallback pathcallback = (index, total, coordinateHandle, userData) =>
            {
                _path.Add(new Geocoordinates(coordinateHandle));
                return true;
            };

            err = Interop.RouteSegment.ForeachPath(handle, pathcallback, IntPtr.Zero);
            err.WarnIfFailed("Failed to get path coordinates for this segment");
        }

        /// <summary>
        /// Origin coordinates for this segment
        /// </summary>
        public Geocoordinates Origin { get { return _origin; } }

        /// <summary>
        /// Destination coordinates for this segment
        /// </summary>
        public Geocoordinates Destination { get { return _destination; } }

        /// <summary>
        /// Total distance for this segment
        /// </summary>
        public double Distance { get { return _distance; } }

        /// <summary>
        /// Total duration to cover this segment
        /// </summary>
        public double Duration { get { return _duration; } }

        /// <summary>
        /// Maneuver list for this segment path
        /// </summary>
        public IEnumerable<RouteManeuver> Maneuvers { get { return _manuevers; } }

        /// <summary>
        /// Coordinates list for this segment path
        /// </summary>
        public IEnumerable<Geocoordinates> Path { get { return _path; } }

        /// <summary>
        /// Bounding area for this segment
        /// </summary>
        private Area BoundingBox { get { return _bondingBox; } }
    }
}
