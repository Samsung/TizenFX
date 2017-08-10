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
    /// Preferences for route searches
    /// </summary>
    /// <since_tizen>3</since_tizen>
    public interface IRouteSearchPreference
    {
        /// <summary>
        /// Gets or sets distance unit.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        DistanceUnit Unit { get; set; }

        /// <summary>
        /// Gets or sets route optimization.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        RouteOptimization Optimization { get; set; }

        /// <summary>
        /// Gets or sets route transport mode.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        TransportMode Mode { get; set; }

        /// <summary>
        /// Gets or sets route feature weight.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        RouteFeatureWeight RouteFeatureWeight { get; set; }

        /// <summary>
        /// Gets or sets route feature.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        RouteFeature RouteFeature { get; set; }

        /// <summary>
        /// Gets or sets if searching for alternative routes is enabled.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        bool SearchAlternativeRoutes { get; set; }
    }
}
