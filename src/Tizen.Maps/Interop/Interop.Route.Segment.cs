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
    internal static partial class RouteSegment
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SegmentPathCallback(int index, int total, IntPtr /* maps_coordinates_h */ coordinates, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SegmentManeuverCallback(int index, int total, IntPtr /* maps_route_maneuver_h */ maneuver, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_segment_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_route_segment_h */ segment);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_segment_clone")]
        internal static extern ErrorCode Clone(RouteSegmentHandle /* maps_route_segment_h */ origin, out IntPtr /* maps_route_segment_h */ cloned);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_segment_get_origin")]
        internal static extern ErrorCode GetOrigin(RouteSegmentHandle /* maps_route_segment_h */ segment, out IntPtr /* maps_coordinates_h */ origin);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_segment_get_destination")]
        internal static extern ErrorCode GetDestination(RouteSegmentHandle /* maps_route_segment_h */ segment, out IntPtr /* maps_coordinates_h */ destination);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_segment_get_bounding_box")]
        internal static extern ErrorCode GetBoundingBox(RouteSegmentHandle /* maps_route_segment_h */ segment, out IntPtr /* maps_area_h */ boundingBox);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_segment_get_distance")]
        internal static extern ErrorCode GetDistance(RouteSegmentHandle /* maps_route_segment_h */ segment, out double distance);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_segment_get_duration")]
        internal static extern ErrorCode GetDuration(RouteSegmentHandle /* maps_route_segment_h */ segment, out long duration);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_segment_foreach_path")]
        internal static extern ErrorCode ForeachPath(RouteSegmentHandle /* maps_route_segment_h */ segment, SegmentPathCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_segment_foreach_maneuver")]
        internal static extern ErrorCode ForeachManeuver(RouteSegmentHandle /* maps_route_segment_h */ segment, SegmentManeuverCallback callback, IntPtr /* void */ userData);
    }

    internal class RouteSegmentHandle : SafeMapsHandle
    {
        public RouteSegmentHandle(IntPtr handle, bool ownsHandle = true) : base(handle, ownsHandle) { Destroy = RouteSegment.Destroy; }
    }
}
