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
    public class Route : IDisposable
    {
        internal Interop.RouteHandle handle;

        internal Route(Interop.RouteHandle nativeHandle)
        {
            handle = nativeHandle;
        }

        /// <summary>
        /// Destination coordinates for this route
        /// </summary>
        public Geocoordinates Destination
        {
            get
            {
                return new Geocoordinates(handle.Destination);
            }
        }

        /// <summary>
        /// Total distance for this route
        /// </summary>
        public double Distance
        {
            get
            {
                return handle.Distance;
            }
        }

        /// <summary>
        /// Total duration to cover this route
        /// </summary>
        public double Duration
        {
            get
            {
                return handle.Duration;
            }
        }

        public string Id
        {
            get
            {
                return handle.Id;
            }
        }

        /// <summary>
        /// Transport Mode for this route
        /// </summary>
        public TransportMode Mode
        {
            get
            {
                return (TransportMode)handle.TransportMode;
            }
        }

        /// <summary>
        /// Origin coordinates for this route
        /// </summary>
        public Geocoordinates Origin
        {
            get
            {
                return new Geocoordinates(handle.Origin);
            }
        }

        /// <summary>
        /// Coordinates list for this route
        /// </summary>
        public IEnumerable<Geocoordinates> Path
        {
            get
            {
                var path = new List<Geocoordinates>();
                handle.ForeachPath(coordinateHandle => path.Add(new Geocoordinates(coordinateHandle)));
                return path;
            }
        }

        /// <summary>
        /// Segment list for this route
        /// </summary>
        public IEnumerable<RouteSegment> Segments
        {
            get
            {
                var segments = new List<RouteSegment>();
                handle.ForeachSegment(segmentHandle => segments.Add(new RouteSegment(segmentHandle)));
                return segments;
            }
        }

        /// <summary>
        /// Distance unit for this route
        /// </summary>
        public DistanceUnit Unit
        {
            get
            {
                return (DistanceUnit)handle.Unit;
            }
        }

        /// <summary>
        /// Bounding area for this route
        /// </summary>
        private Area BoundingBox
        {
            get
            {
                return new Area(handle.BoundingBox);
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                handle.Dispose();
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
