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
using System.Linq;

namespace Tizen.Maps
{
    /// <summary>
    /// Routes the search request for Tizen map service requests.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class RouteSearchRequest : MapServiceRequest<Route>
    {
        private Interop.SearchRouteCallback _routeCallback;
        private List<Route> _routeList = new List<Route>();

        private Geocoordinates _to;
        private Geocoordinates _from;
        private List<Geocoordinates> _waypoints = new List<Geocoordinates>();

        internal RouteSearchRequest(MapService service, Geocoordinates from, Geocoordinates to) : this(service, ServiceRequestType.SearchRoute)
        {
            _to = to;
            _from = from;
            startExecutionAction = new Action(() =>
            {
                int requestID;
                errMessage = $"Failed to get route list for given origin {_from} and destination {_to}";
                if (_waypoints?.Count == 0)
                {
                    _type = ServiceRequestType.SearchRoute;
                    errorCode = _service.handle.SearchRoute(_from.handle, _to.handle, _service.Preferences.handle, _routeCallback, IntPtr.Zero, out requestID);
                    if (errorCode.IsFailed() && errorCode != Interop.ErrorCode.Canceled)
                    {
                        _requestTask?.TrySetException(errorCode.GetException(errMessage));
                    }
                }
                else
                {
                    _type = ServiceRequestType.SearchRouteWithWaypoints;

                    var waypoints = GetCoordinateListForWaypoints();
                    errorCode = _service.handle.SearchRouteWaypoints(waypoints, waypoints.Length, _service.Preferences.handle, _routeCallback, IntPtr.Zero, out requestID);
                    if (errorCode.IsFailed() && errorCode != Interop.ErrorCode.Canceled)
                    {
                        _requestTask?.TrySetException(errorCode.GetException(errMessage));
                    }
                }
                _requestID = requestID;
            });
        }


        private RouteSearchRequest(MapService service, ServiceRequestType type) : base(service, type)
        {
            // The Maps Service invokes this callback while iterating through the set of obtained Routes.
            _routeCallback = (result, id, index, total, route, userData) =>
            {
                errorCode = result;
                if (result.IsSuccess())
                {
                    // The parameter route must be released using maps_route_destroy().
                    var routeHandle = new Interop.RouteHandle(route, needToRelease: true);
                    _routeList.Add(new Route(routeHandle));
                    if (_routeList.Count == total)
                    {
                        _requestTask?.TrySetResult(_routeList);
                    }
                    return true;
                }
                else
                {
                    // If search is failed, the value of total is 0 and route is NULL.
                    _requestTask?.TrySetException(errorCode.GetException(errMessage));
                    return false;
                }
            };
        }

        /// <summary>
        /// Gets or sets a list of way-points to cover between the origin and destination.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public IEnumerable<Geocoordinates> Waypoints
        {
            get
            {
                return _waypoints;
            }
            set
            {
                _waypoints = value.ToList();
            }
        }

        private IntPtr[] GetCoordinateListForWaypoints()
        {
            var waypoints = new IntPtr[_waypoints.Count + 2];
            waypoints[0] = _from.handle;
            for (int i = 0; i < _waypoints.Count; ++i)
            {
                waypoints[i + 1] = _waypoints[i].handle;
            }
            waypoints[waypoints.Length - 1] = _to.handle;
            return waypoints;
        }
    }
}
