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

namespace Tizen.Maps
{
    /// <summary>
    /// The preferences for route search.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API11. Might be removed in API13.")]
    public interface IRouteSearchPreference
    {
        /// <summary>
        /// Gets or sets the distance unit.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        DistanceUnit Unit { get; set; }

        /// <summary>
        /// Gets or sets the route optimization.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        RouteOptimization Optimization { get; set; }

        /// <summary>
        /// Gets or sets the route transport mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        TransportMode Mode { get; set; }

        /// <summary>
        /// Gets or sets the route feature weight.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        RouteFeatureWeight RouteFeatureWeight { get; set; }

        /// <summary>
        /// Gets or sets the route feature.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        RouteFeature RouteFeature { get; set; }

        /// <summary>
        /// Gets or sets if a search for alternative routes is enabled.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        bool SearchAlternativeRoutes { get; set; }
    }
}
