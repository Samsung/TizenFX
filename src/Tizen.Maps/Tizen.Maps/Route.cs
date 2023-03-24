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
    /// Route information, used in Route Search requests.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API11. Might be removed in API13.")]
    public class Route : IDisposable
    {
        internal Interop.RouteHandle handle;

        internal Route(Interop.RouteHandle nativeHandle)
        {
            handle = nativeHandle;
        }

        /// <summary>
        /// Destroy the Route object.
        /// </summary>
        ~Route()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets an instance of <see cref="Geocoordinates"/> object representing destination coordinates for this route.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public Geocoordinates Destination
        {
            get
            {
                return new Geocoordinates(handle.Destination);
            }
        }

        /// <summary>
        /// Gets the total distance for this route.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public double Distance
        {
            get
            {
                return handle.Distance;
            }
        }

        /// <summary>
        /// Get the total duration to cover this route.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public double Duration
        {
            get
            {
                return handle.Duration;
            }
        }

        /// <summary>
        /// Gets an ID for this route.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public string Id
        {
            get
            {
                return handle.Id;
            }
        }

        /// <summary>
        /// Gets the transport mode for this route.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public TransportMode Mode
        {
            get
            {
                return (TransportMode)handle.TransportMode;
            }
        }

        /// <summary>
        /// Gets the origin coordinates for this route.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public Geocoordinates Origin
        {
            get
            {
                return new Geocoordinates(handle.Origin);
            }
        }

        /// <summary>
        /// Gets a coordinates list for this route.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
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
        /// Gets a segment list for this route.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
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
        /// Gets the distance unit for this route.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public DistanceUnit Unit
        {
            get
            {
                return (DistanceUnit)handle.Unit;
            }
        }

        /// <summary>
        /// Gets an instance of <see cref="Area"/> object which representing bounding area for this route.
        /// </summary>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        private Area BoundingBox
        {
            get
            {
                return new Area(handle.BoundingBox);
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">If true, managed and unmanaged resources can be disposed, otherwise only unmanaged resources can be disposed.</param>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                handle?.Dispose();
                _disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all the resources used by this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
