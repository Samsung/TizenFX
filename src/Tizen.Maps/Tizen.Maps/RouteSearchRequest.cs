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
    /// Route search request for Tizen map service requests
    /// </summary>
    public class RouteSearchRequest : MapServiceRequest<Route>
    {
        private Interop.Service.SearchRouteCallback _responseCallback;
        private List<Route> _routeList = new List<Route>();


        private Geocoordinates _from;
        private Geocoordinates _to;
        private List<Geocoordinates> _waypoints = new List<Geocoordinates>();
        private RouteSearchPreference _preferences;

        internal RouteSearchRequest(MapService service, Geocoordinates from, Geocoordinates to) : this(service, ServiceRequestType.SearchByEndPoint)
        {
            _from = from;
            _to = to;
            startExecutionAction = new Action(() =>
            {
                int requestID;
                errMessage = string.Format("Failed to get route list for given origin {0} and destination {1}", _from, _to);
                if (_waypoints?.Count == 0)
                {
                    _type = ServiceRequestType.SearchByEndPoint;
                    errorCode = Interop.Service.SearchRoute(_service, _from.handle, _to.handle, _preferences.handle, _responseCallback, IntPtr.Zero, out requestID);
                    if (errorCode.IsFailed() && errorCode != Interop.ErrorCode.Canceled)
                    {
                        _requestTask?.TrySetException(errorCode.GetException(errMessage));
                    }
                }
                else
                {
                    _type = ServiceRequestType.SearchWithWaypoints;

                    var waypoints = GetCoordinateListForWaypoints();
                    errorCode = Interop.Service.SearchRouteWaypoints(_service, waypoints, waypoints.Length, _preferences.handle, _responseCallback, IntPtr.Zero, out requestID);
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
            _preferences = service.RouteSearchPreferences;
            _responseCallback = (result, id, index, total, routeHandle, userData) =>
            {
                errorCode = result;
                if (result.IsSuccess())
                {
                    _routeList.Add(new Route(routeHandle));
                    if (_routeList.Count == total)
                    {
                        _requestTask?.TrySetResult(_routeList);
                    }
                    return true;
                }
                else
                {
                    _requestTask?.TrySetException(errorCode.GetException(errMessage));
                    return false;
                }
            };
        }

        /// <summary>
        /// List of way-points to cover between origin and destination
        /// </summary>
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
