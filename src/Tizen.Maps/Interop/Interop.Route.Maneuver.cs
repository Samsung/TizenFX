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
    internal enum RouteDirection
    {
        None, // MAPS_ROUTE_DIRECTION_NONE
        North, // MAPS_ROUTE_DIRECTION_NORTH
        NorthWest, // MAPS_ROUTE_DIRECTION_NORTHWEST
        NorthEast, // MAPS_ROUTE_DIRECTION_NORTHEAST
        South, // MAPS_ROUTE_DIRECTION_SOUTH
        SouthEast, // MAPS_ROUTE_DIRECTION_SOUTHEAST
        SouthWest, // MAPS_ROUTE_DIRECTION_SOUTHWEST
        West, // MAPS_ROUTE_DIRECTION_WEST
        East, // MAPS_ROUTE_DIRECTION_EAST
    }

    internal enum RouteTurnType
    {
        None, // MAPS_ROUTE_TURN_TYPE_NONE
        Straight, // MAPS_ROUTE_TURN_TYPE_STRAIGHT
        BearRight, // MAPS_ROUTE_TURN_TYPE_BEAR_RIGHT
        LightRight, // MAPS_ROUTE_TURN_TYPE_LIGHT_RIGHT
        Right, // MAPS_ROUTE_TURN_TYPE_RIGHT
        HardRight, // MAPS_ROUTE_TURN_TYPE_HARD_RIGHT
        UturnRight, // MAPS_ROUTE_TURN_TYPE_UTURN_RIGHT
        UturnLeft, // MAPS_ROUTE_TURN_TYPE_UTURN_LEFT
        HardLeft, // MAPS_ROUTE_TURN_TYPE_HARD_LEFT
        Left, // MAPS_ROUTE_TURN_TYPE_LEFT
        LightLeft, // MAPS_ROUTE_TURN_TYPE_LIGHT_LEFT
        BearLeft, // MAPS_ROUTE_TURN_TYPE_BEAR_LEFT
        RightFork, // MAPS_ROUTE_TURN_TYPE_RIGHT_FORK
        LeftFork, // MAPS_ROUTE_TURN_TYPE_LEFT_FORK
        StraightFork, // MAPS_ROUTE_TURN_TYPE_STRAIGHT_FORK
    }

    internal static partial class RouteManeuver
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_route_maneuver_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_route_maneuver_h */ maneuver);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_maneuver_clone")]
        internal static extern ErrorCode Clone(RouteManeuverHandle /* maps_route_maneuver_h */ origin, out IntPtr /* maps_route_maneuver_h */ cloned);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_maneuver_get_direction_id")]
        internal static extern ErrorCode GetDirectionId(RouteManeuverHandle /* maps_route_maneuver_h */ maneuver, out RouteDirection /* maps_route_direction_e */ directionId);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_maneuver_get_turn_type")]
        internal static extern ErrorCode GetTurnType(RouteManeuverHandle /* maps_route_maneuver_h */ maneuver, out RouteTurnType /* maps_route_turn_type_e */ turnType);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_maneuver_get_position")]
        internal static extern ErrorCode GetPosition(RouteManeuverHandle /* maps_route_maneuver_h */ maneuver, out IntPtr /* maps_coordinates_h */ position);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_maneuver_get_road_name")]
        internal static extern ErrorCode GetRoadName(RouteManeuverHandle /* maps_route_maneuver_h */ maneuver, out string roadName);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_maneuver_get_instruction_text")]
        internal static extern ErrorCode GetInstructionText(RouteManeuverHandle /* maps_route_maneuver_h */ maneuver, out string instructionText);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_maneuver_get_locale")]
        internal static extern ErrorCode GetLocale(RouteManeuverHandle /* maps_route_maneuver_h */ maneuver, out string locale);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_maneuver_get_time_to_next_instruction")]
        internal static extern ErrorCode GetTimeToNextInstruction(RouteManeuverHandle /* maps_route_maneuver_h */ maneuver, out int timeToNextInstruction);

        [DllImport(Libraries.MapService, EntryPoint = "maps_route_maneuver_get_distance_to_next_instruction")]
        internal static extern ErrorCode GetDistanceToNextInstruction(RouteManeuverHandle /* maps_route_maneuver_h */ maneuver, out double distanceToNextInstruction);
    }

    internal class RouteManeuverHandle : SafeMapsHandle
    {
        public RouteManeuverHandle(IntPtr handle, bool ownsHandle = true) : base(handle, ownsHandle) { Destroy = RouteManeuver.Destroy; }
    }
}
