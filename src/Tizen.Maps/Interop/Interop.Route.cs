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
    [DllImport(Libraries.MapService, EntryPoint = "maps_route_get_route_id")]
    internal static extern ErrorCode GetRouteId(this RouteHandle /* maps_route_h */ route, out string routeId);

    [DllImport(Libraries.MapService, EntryPoint = "maps_route_get_origin")]
    internal static extern ErrorCode GetOrigin(this RouteHandle /* maps_route_h */ route, out IntPtr /* maps_coordinates_h */ origin);

    [DllImport(Libraries.MapService, EntryPoint = "maps_route_get_destination")]
    internal static extern ErrorCode GetDestination(this RouteHandle /* maps_route_h */ route, out IntPtr /* maps_coordinates_h */ destination);

    [DllImport(Libraries.MapService, EntryPoint = "maps_route_get_bounding_box")]
    internal static extern ErrorCode GetBoundingBox(this RouteHandle /* maps_route_h */ route, out IntPtr /* maps_area_h */ boundingBox);

    [DllImport(Libraries.MapService, EntryPoint = "maps_route_get_transport_mode")]
    internal static extern ErrorCode GetTransportMode(this RouteHandle /* maps_route_h */ route, out RouteTransportMode /* maps_route_transport_mode_e */ transportMode);

    [DllImport(Libraries.MapService, EntryPoint = "maps_route_get_total_distance")]
    internal static extern ErrorCode GetTotalDistance(this RouteHandle /* maps_route_h */ route, out double totalDistance);

    [DllImport(Libraries.MapService, EntryPoint = "maps_route_get_total_duration")]
    internal static extern ErrorCode GetTotalDuration(this RouteHandle /* maps_route_h */ route, out long totalDuration);

    [DllImport(Libraries.MapService, EntryPoint = "maps_route_get_distance_unit")]
    internal static extern ErrorCode GetDistanceUnit(this RouteHandle /* maps_route_h */ route, out DistanceUnit /* maps_distance_unit_e */ distanceUnit);

    internal class RouteHandle : SafeMapsHandle
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PropertiesCallback(int index, int total, string key, string /* void */ value, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PathCallback(int index, int total, IntPtr /* maps_coordinates_h */ coordinates, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SegmentCallback(int index, int total, IntPtr /* maps_route_segment_h */ segment, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_foreach_property")]
        internal static extern ErrorCode ForeachProperty(IntPtr /* maps_route_h */ route, PropertiesCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_foreach_path")]
        internal static extern ErrorCode ForeachPath(IntPtr /* maps_route_h */ route, PathCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_foreach_segment")]
        internal static extern ErrorCode ForeachSegment(IntPtr /* maps_route_h */ route, SegmentCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_route_h */ route);

        internal string Id
        {
            get { return NativeGet(this.GetRouteId); }
        }

        internal double Distance
        {
            get { return NativeGet<double>(this.GetTotalDistance); }
        }

        internal long Duration
        {
            get { return NativeGet<long>(this.GetTotalDuration); }
        }

        internal DistanceUnit Unit
        {
            get { return NativeGet<DistanceUnit>(this.GetDistanceUnit); }
        }

        internal RouteTransportMode TransportMode
        {
            get { return NativeGet<RouteTransportMode>(this.GetTransportMode); }
        }

        internal CoordinatesHandle Origin
        {
            get { return NativeGet(this.GetOrigin, CoordinatesHandle.Create); }
        }

        internal CoordinatesHandle Destination
        {
            get { return NativeGet(this.GetDestination, CoordinatesHandle.Create); }
        }

        internal AreaHandle BoundingBox
        {
            get { return NativeGet(this.GetBoundingBox, AreaHandle.Create); }
        }

        public RouteHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease, Destroy)
        {
        }

        internal void ForeachProperty(Action<string, string> action)
        {
            PropertiesCallback callback = (index, total, key, value, userData) =>
            {
                action(key, value);
                return true;
            };

            ForeachProperty(handle, callback, IntPtr.Zero).WarnIfFailed("Failed to get property list from native handle");
        }

        internal void ForeachPath(Action<CoordinatesHandle> action)
        {
            PathCallback callback = (index, total, nativeHandle, userData) =>
            {
                if (handle != IntPtr.Zero)
                {
                    action(CoordinatesHandle.CloneFrom(nativeHandle));
                    //Destroy(nativeHandle);
                }
                return true;
            };

            ForeachPath(handle, callback, IntPtr.Zero).WarnIfFailed("Failed to get path coordinates list from native handle");
        }

        internal void ForeachSegment(Action<RouteSegmentHandle> action)
        {
            SegmentCallback callback = (index, total, nativeHandle, userData) =>
            {
                if (handle != IntPtr.Zero)
                {
                    action(RouteSegmentHandle.CloneFrom(nativeHandle));
                    //Destroy(nativeHandle);
                }
                return true;
            };

            ForeachSegment(handle, callback, IntPtr.Zero).WarnIfFailed("Failed to get segment list from native handle");
        }
    }
}
