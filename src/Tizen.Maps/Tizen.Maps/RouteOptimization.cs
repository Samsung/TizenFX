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
    /// Allowed route optimization option used in route search requests.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// <remarks>
    /// Depending on the loaded maps plug-in using <see cref="MapService"/>, some features might have no effect or differences with the descriptions.
    /// </remarks>
    public enum RouteOptimization
    {
        /// <summary>
        /// Indicates searching for the fastest routes.
        /// </summary>
        Fastest = Interop.RouteOptimization.Fastest,
        /// <summary>
        /// Indicates searching for the shortest routes (car mode only).
        /// </summary>
        Shortest = Interop.RouteOptimization.Shortest,
        /// <summary>
        /// Indicates searching for the most economic routes (car mode only).
        /// </summary>
        Economic = Interop.RouteOptimization.Economic,
        /// <summary>
        /// Indicates searching for the most scenic routes.
        /// </summary>
        Scenic = Interop.RouteOptimization.Scenic,
        /// <summary>
        /// Indicates searching for most the fastest routes now, based on the current traffic condition.
        /// </summary>
        FastestNow = Interop.RouteOptimization.FastestNow,
        /// <summary>
        /// Indicates searching for the direct drive routes.
        /// </summary>
        DirectDrive = Interop.RouteOptimization.DirectDrive,
    }
}
