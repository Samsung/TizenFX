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
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Route
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool RoutePropertiesCallback(int index, int total, string key, string /* void */ value, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool RoutePathCallback(int index, int total, IntPtr /* maps_coordinates_h */ coordinates, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool RouteSegmentCallback(int index, int total, IntPtr /* maps_route_segment_h */ segment, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_route_h */ route);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_clone")]
        internal static extern ErrorCode Clone(RouteHandle /* maps_route_h */ origin, out IntPtr /* maps_route_h */ cloned);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_get_route_id")]
        internal static extern ErrorCode GetRouteId(RouteHandle /* maps_route_h */ route, out string routeId);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_get_origin")]
        internal static extern ErrorCode GetOrigin(RouteHandle /* maps_route_h */ route, out IntPtr /* maps_coordinates_h */ origin);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_get_destination")]
        internal static extern ErrorCode GetDestination(RouteHandle /* maps_route_h */ route, out IntPtr /* maps_coordinates_h */ destination);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_get_bounding_box")]
        internal static extern ErrorCode GetBoundingBox(RouteHandle /* maps_route_h */ route, out IntPtr /* maps_area_h */ boundingBox);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_get_transport_mode")]
        internal static extern ErrorCode GetTransportMode(RouteHandle /* maps_route_h */ route, out RouteTransportMode /* maps_route_transport_mode_e */ transportMode);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_get_total_distance")]
        internal static extern ErrorCode GetTotalDistance(RouteHandle /* maps_route_h */ route, out double totalDistance);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_get_total_duration")]
        internal static extern ErrorCode GetTotalDuration(RouteHandle /* maps_route_h */ route, out long totalDuration);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_get_distance_unit")]
        internal static extern ErrorCode GetDistanceUnit(RouteHandle /* maps_route_h */ route, out DistanceUnit /* maps_distance_unit_e */ distanceUnit);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_foreach_property")]
        internal static extern ErrorCode ForeachProperty(RouteHandle /* maps_route_h */ route, RoutePropertiesCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_foreach_path")]
        internal static extern ErrorCode ForeachPath(RouteHandle /* maps_route_h */ route, RoutePathCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_foreach_segment")]
        internal static extern ErrorCode ForeachSegment(RouteHandle /* maps_route_h */ route, RouteSegmentCallback callback, IntPtr /* void */ userData);
    }

    internal class RouteHandle : SafeMapsHandle
    {
        public RouteHandle(IntPtr handle, bool ownsHandle = true) : base(handle, ownsHandle) { Destroy = Route.Destroy; }
    }
}
