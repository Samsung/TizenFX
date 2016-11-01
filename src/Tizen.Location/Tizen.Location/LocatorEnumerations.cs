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
    public enum ServiceState
    {
        Disabled = 0, /**<Service is disabled.*/
        Enabled /**<Service is enabled.*/
    }

    /// <summary>
    /// Enumeration for the type of connection used in acquiring Location data.
    /// </summary>
    public enum LocationType
    {
        None = -1, /**<Undefined method.*/
        Hybrid, /**<This method selects the best method available at the moment.*/
        Gps, /**<This method uses Global Positioning System.*/
        Wps, /**<This method uses WiFi Positioning System.*/
    }

    /// <summary>
    /// Enumeration for Approximate accuracy level of given information.
    /// </summary>
    public enum LocationAccuracy
    {
        None = 0, /**< Invalid Data */
        Country, /**< Country accuracy level */
        Region, /**< Regional accuracy level */
        Locality, /**< Local accuracy level*/
        PostalCode, /**< Postal accuracy level */
        Street, /**< Street accuracy level */
        Detailed /**< Detailed accuracy level*/
    }

    /// <summary>
    /// Enumeration for the location service accessibility state.
    /// </summary>
    public enum AccessibilityState
    {
        None = 0, /**< Access state is not determined */
        Denied, /**< Access denied */
        Allowed /**< Access authorized */
    }

    /// <summary>
    /// Enumeration for the created boundary type.
    /// </summary>
    public enum BoundaryType
    {
        Rectangle = 0, /**<Rectangular geographical area type. */
        Circle, /**<Rectangular geographical area type. */
        Polygon /**<Rectangular geographical area type. */
    }

    /// <summary>
    /// Enumeration for error code for Location manager.
    /// </summary>
    public enum BoundaryState
    {
        In = 0, /**< Boundary In (Zone In) */
        Out /**< Boundary Out (Zone Out) */
    }
}
