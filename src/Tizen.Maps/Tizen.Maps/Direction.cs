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

namespace Tizen.Maps
{
    /// <summary>
    /// Direction types for route maneuver
    /// </summary>
    /// <since_tizen>3</since_tizen>
    public enum DirectionType
    {
        /// <summary>
        /// Indicates unknown direction.
        /// </summary>
        None = Interop.RouteDirection.None,
        /// <summary>
        /// Indicates north direction.
        /// </summary>
        North = Interop.RouteDirection.North,
        /// <summary>
        /// Indicates north-west direction.
        /// </summary>
        NorthWest = Interop.RouteDirection.NorthWest,
        /// <summary>
        /// Indicates north-east direction.
        /// </summary>
        NorthEast = Interop.RouteDirection.NorthEast,
        /// <summary>
        /// Indicates south direction.
        /// </summary>
        South = Interop.RouteDirection.South,
        /// <summary>
        /// Indicates south-East direction.
        /// </summary>
        SouthEast = Interop.RouteDirection.SouthEast,
        /// <summary>
        /// Indicates south-West direction.
        /// </summary>
        SouthWest = Interop.RouteDirection.SouthWest,
        /// <summary>
        /// Indicates west direction.
        /// </summary>
        West = Interop.RouteDirection.West,
        /// <summary>
        /// Indicates east direction.
        /// </summary>
        East = Interop.RouteDirection.East,
    }
}
