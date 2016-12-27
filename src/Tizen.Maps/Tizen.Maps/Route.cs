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
    /// Route information, used in Route Search requests
    /// </summary>
    public class Route
    {
        internal Interop.RouteHandle handle;
        private Area _bondingBox;
        private Geocoordinates _destination;
        private double _distance;
        private long _duration;
        private string _id = string.Empty;
        private Geocoordinates _origin;
        private List<Geocoordinates> _path;

        private Dictionary<string, string> _properties;
        private List<RouteSegment> _segments;
        private Interop.RouteTransportMode _transportMode;
        private Interop.DistanceUnit _unit;

        internal Route(IntPtr nativeHandle)
        {
            handle = new Interop.RouteHandle(nativeHandle);

            var err = Interop.Route.GetTransportMode(handle, out _transportMode);
            err.WarnIfFailed("Failed to get transport mode for the segment");

            err = Interop.Route.GetTotalDistance(handle, out _distance);
            err.WarnIfFailed("Failed to get distance for the segment");

            err = Interop.Route.GetDistanceUnit(handle, out _unit);
            err.WarnIfFailed("Failed to get distance for the segment");

            err = Interop.Route.GetTotalDuration(handle, out _duration);
            err.WarnIfFailed("Failed to get duration for the segment");
        }

        /// <summary>
        /// Destination coordinates for this route
        /// </summary>
        public Geocoordinates Destination
        {
            get
            {
                if (_destination != null) return _destination;

                IntPtr destinationHandle;
                var err = Interop.Route.GetDestination(handle, out destinationHandle);
                if (err.WarnIfFailed("Failed to get destination for the route"))
                {
                    _destination = new Geocoordinates(destinationHandle);
                }
                return _destination;
            }
        }

        /// <summary>
        /// Total distance for this route
        /// </summary>
        public double Distance { get { return _distance; } }

        /// <summary>
        /// Total duration to cover this route
        /// </summary>
        public double Duration { get { return _duration; } }

        public string Id
        {
            get
            {
                if (string.IsNullOrEmpty(_id))
                {
                    string id;
                    var err = Interop.Route.GetRouteId(handle, out id);
                    if (err.WarnIfFailed("Failed to get route id"))
                    {
                        _id = id;
                    }
                }
                return _id;
            }
        }

        /// <summary>
        /// Transport Mode for this route
        /// </summary>
        public TransportMode Mode { get { return (TransportMode)_transportMode; } }

        /// <summary>
        /// Origin coordinates for this route
        /// </summary>
        public Geocoordinates Origin
        {
            get
            {
                if (_origin != null) return _origin;

                IntPtr originHandle;
                var err = Interop.Route.GetOrigin(handle, out originHandle);
                if (err.WarnIfFailed("Failed to get origin for the route"))
                {
                    _origin = new Geocoordinates(originHandle);
                }
                return _origin;
            }
        }

        /// <summary>
        /// Coordinates list for this route
        /// </summary>
        public IEnumerable<Geocoordinates> Path
        {
            get
            {
                if (_path != null) return _path;

                _path = new List<Geocoordinates>();
                Interop.Route.RoutePathCallback callback = (index, total, coordinateHandle, userData) =>
                {
                    _path.Add(new Geocoordinates(coordinateHandle));
                    return true;
                };

                var err = Interop.Route.ForeachPath(handle, callback, IntPtr.Zero);
                err.WarnIfFailed("Failed to get path coordinates for this route");
                return _path;
            }
        }

        /// <summary>
        /// All properties attached with this route
        /// </summary>
        public IDictionary<string, string> Properties
        {
            get
            {
                if (_properties != null) return _properties;
                _properties = new Dictionary<string, string>();
                Interop.Route.RoutePropertiesCallback callback = (index, total, key, value, userData) =>
                {
                    _properties[key] = value;
                    return true;
                };
                var err = Interop.Route.ForeachProperty(handle, callback, IntPtr.Zero);
                err.WarnIfFailed("Failed to get all properties for this route");

                return _properties;
            }
        }

        /// <summary>
        /// Segment list for this route
        /// </summary>
        public IEnumerable<RouteSegment> Segments
        {
            get
            {
                if (_segments != null) return _segments;

                _segments = new List<RouteSegment>();
                Interop.Route.RouteSegmentCallback callback = (index, total, segmentHandle, userData) =>
                {
                    _segments.Add(new RouteSegment(segmentHandle));
                    return true;
                };

                var err = Interop.Route.ForeachSegment(handle, callback, IntPtr.Zero);
                err.WarnIfFailed("Failed to get path segments for this route");
                return _segments;
            }
        }

        /// <summary>
        /// Distance unit for this route
        /// </summary>
        public DistanceUnit Unit { get { return (DistanceUnit)_unit; } }

        /// <summary>
        /// Bounding area for this route
        /// </summary>
        private Area BoundingBox
        {
            get
            {
                if (_bondingBox != null) return _bondingBox;

                IntPtr areaHandle;
                var err = Interop.Route.GetBoundingBox(handle, out areaHandle);
                if (err.WarnIfFailed("Failed to get bonding box for the route"))
                {
                    _bondingBox = new Area(areaHandle);
                }
                return _bondingBox;
            }
        }
    }
}
