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
    [DllImport(Libraries.MapService, EntryPoint = "maps_route_segment_get_origin")]
    internal static extern ErrorCode GetOrigin(this RouteSegmentHandle /* maps_route_segment_h */ segment, out IntPtr /* maps_coordinates_h */ origin);

    [DllImport(Libraries.MapService, EntryPoint = "maps_route_segment_get_destination")]
    internal static extern ErrorCode GetDestination(this RouteSegmentHandle /* maps_route_segment_h */ segment, out IntPtr /* maps_coordinates_h */ destination);

    [DllImport(Libraries.MapService, EntryPoint = "maps_route_segment_get_bounding_box")]
    internal static extern ErrorCode GetBoundingBox(this RouteSegmentHandle /* maps_route_segment_h */ segment, out IntPtr /* maps_area_h */ boundingBox);

    [DllImport(Libraries.MapService, EntryPoint = "maps_route_segment_get_distance")]
    internal static extern ErrorCode GetDistance(this RouteSegmentHandle /* maps_route_segment_h */ segment, out double distance);

    [DllImport(Libraries.MapService, EntryPoint = "maps_route_segment_get_duration")]
    internal static extern ErrorCode GetDuration(this RouteSegmentHandle /* maps_route_segment_h */ segment, out long duration);

    internal class RouteSegmentHandle : SafeMapsHandle
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PathCallback(int index, int total, IntPtr /* maps_coordinates_h */ coordinates, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ManeuverCallback(int index, int total, IntPtr /* maps_route_maneuver_h */ maneuver, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_segment_foreach_path")]
        internal static extern ErrorCode ForeachPath(IntPtr /* maps_route_segment_h */ segment, PathCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_segment_foreach_maneuver")]
        internal static extern ErrorCode ForeachManeuver(IntPtr /* maps_route_segment_h */ segment, ManeuverCallback callback, IntPtr /* void */ userData);


        [DllImport(Libraries.MapService, EntryPoint = "maps_route_segment_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_route_segment_h */ segment);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_segment_clone")]
        internal static extern ErrorCode Clone(IntPtr /* maps_route_segment_h */ origin, out IntPtr /* maps_route_segment_h */ cloned);

        internal double Distance
        {
            get { return NativeGet<double>(this.GetDistance); }
        }

        internal long Duration
        {
            get { return NativeGet<long>(this.GetDuration); }
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

        public RouteSegmentHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease, Destroy)
        {
        }

        internal static RouteSegmentHandle CloneFrom(IntPtr nativeHandle)
        {
            IntPtr handle;
            Clone(nativeHandle, out handle).ThrowIfFailed("Failed to clone native handle");
            return new RouteSegmentHandle(handle, true);
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

        internal void ForeachManeuver(Action<RouteManeuverHandle> action)
        {
            ManeuverCallback callback = (index, total, nativeHandle, userData) =>
            {
                if (handle != IntPtr.Zero)
                {
                    action(RouteManeuverHandle.CloneFrom(nativeHandle));
                    //Destroy(nativeHandle);
                }
                return true;
            };

            ForeachManeuver(handle, callback, IntPtr.Zero).WarnIfFailed("Failed to get segment list from native handle");
        }
    }
}
