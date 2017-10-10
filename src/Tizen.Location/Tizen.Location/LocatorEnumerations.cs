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
using System.Collections.Generic;

namespace Tizen.Location
{
    /// <summary>
    /// Enumeration for the state of the location service.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ServiceState
    {
        /// <summary>
        /// Service is disabled.
        /// </summary>
        Disabled = 0,

        /// <summary>
        /// Service is enabled.
        /// </summary>
        Enabled
    }

    /// <summary>
    /// Enumeration for the type of connection used in acquiring the location data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum LocationType
    {
        /// <summary>
        /// This method selects the best method available at the moment.
        /// </summary>
        Hybrid = 0,

        /// <summary>
        /// This method uses Global Positioning System.
        /// </summary>
        Gps,

        /// <summary>
        /// This method uses WiFi Positioning System.
        /// </summary>
        Wps,

        /// <summary>
        /// This method uses passive mode.
        /// </summary>
        Passive,
    }

    /// <summary>
    /// Enumeration for the created boundary type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BoundaryType
    {
        /// <summary>
        /// Rectangular geographical area type.
        /// </summary>
        Rectangle = 0,

        /// <summary>
        /// Circle geographical area type.
        /// </summary>
        Circle,

        /// <summary>
        /// Polygon geographical area type.
        /// </summary>
        Polygon
    }

    /// <summary>
    /// Enumeration for the error code for location manager.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BoundaryState
    {
        /// <summary>
        /// Boundary In (Zone In).
        /// </summary>
        In = 0,

        /// <summary>
        /// Boundary Out (Zone Out).
        /// </summary>
        Out
    }
}
