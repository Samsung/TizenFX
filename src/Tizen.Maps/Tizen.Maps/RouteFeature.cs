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
    /// Route features, used for route search requests
    /// </summary>
    public enum RouteFeature
    {
        /// <summary>
        /// Indicates no route features (are selected).
        /// </summary>
        None = Interop.RouteRequestFeature.None,
        /// <summary>
        /// Indicates toll roads (toll gates/booths).
        /// </summary>
        Toll = Interop.RouteRequestFeature.Toll,
        /// <summary>
        /// Indicates motorway.
        /// </summary>
        Motorway = Interop.RouteRequestFeature.MotorWay,
        /// <summary>
        /// Indicates a boat ferry.
        /// </summary>
        BoatFerry = Interop.RouteRequestFeature.BoatFerry,
        /// <summary>
        /// Indicates rail (train) ferry.
        /// </summary>
        RailFerry = Interop.RouteRequestFeature.RailFerry,
        /// <summary>
        /// Indicates public transport.
        /// </summary>
        PublicTransit = Interop.RouteRequestFeature.PublicTransit,
        /// <summary>
        /// Indicates tunnel.
        /// </summary>
        Tunnel = Interop.RouteRequestFeature.Tunnel,
        /// <summary>
        /// Indicates dirt road.
        /// </summary>
        DirtRoad = Interop.RouteRequestFeature.DirtRoad,
        /// <summary>
        /// Indicates park.
        /// </summary>
        Parks = Interop.RouteRequestFeature.Parks,
        /// <summary>
        /// Indicates a high-occupancy vehicle lane.
        /// </summary>
        Hovlane = Interop.RouteRequestFeature.Hovlane,
        /// <summary>
        /// Indicates stairs.
        /// </summary>
        Stairs = Interop.RouteRequestFeature.Stairs,
    }
}
