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
    /// Features available in the Map Service
    /// </summary>
    /// <since_tizen>3</since_tizen>
    public enum ServiceData
    {
        /// <summary>
        /// Indicates availability of address value in the Place data.
        /// </summary>
        PlaceAddress = Interop.ServiceData.PlaceAddress,
        /// <summary>
        /// Indicates availability of rating value in the Place data.
        /// </summary>
        PlaceRating = Interop.ServiceData.PlaceRating,
        /// <summary>
        /// Indicates availability of place category list in the Place data.
        /// </summary>
        PlaceCategories = Interop.ServiceData.PlaceCategories,
        /// <summary>
        /// Indicates availability of place attribute list in the Place data.
        /// </summary>
        PlaceAttributes = Interop.ServiceData.PlaceAttributes,
        /// <summary>
        /// Indicates availability of place contact list in the Place data.
        /// </summary>
        PlaceContacts = Interop.ServiceData.PlaceContacts,
        /// <summary>
        /// Indicates availability of place editorial list in the Place data.
        /// </summary>
        PlaceEditorials = Interop.ServiceData.PlaceEditorials,
        /// <summary>
        /// Indicates availability of place review list in the Place data.
        /// </summary>
        PlaceReviews = Interop.ServiceData.PlaceReviews,
        /// <summary>
        /// Indicates availability of place image in Place the data.
        /// </summary>
        PlaceImage = Interop.ServiceData.PlaceImage,
        /// <summary>
        /// Indicates availability of place supplier link value in the Place data.
        /// </summary>
        PlaceSupplier = Interop.ServiceData.PlaceSupplier,
        /// <summary>
        /// Indicates availability of related place link in the Place data.
        /// </summary>
        PlaceRelated = Interop.ServiceData.PlaceRelated,

        /// <summary>
        /// Indicates that the Route Data Structure is defined as a Path (a list of geographical coordinates).
        /// </summary>
        RoutePath = Interop.ServiceData.RoutePath,
        /// <summary>
        /// Indicates that the Route Data Structure is defined as a list of Segments while each segment is defined as a Path.
        /// </summary>
        RouteSegmentsPath = Interop.ServiceData.RouteSegmentsPath,
        /// <summary>
        /// Indicates that the Route Data Structure is defined as a list of Segments while each segment is defined as a list of Maneuvers.
        /// </summary>
        RouteSegmentsManeuvers = Interop.ServiceData.RouteSegmentsManeuvers,

        /// <summary>
        /// Indicates availability of traffic information on the Map.
        /// </summary>
        ViewTraffic = Interop.ServiceData.ViewTraffic,
        /// <summary>
        /// Indicates availability of public transit information on the Map.
        /// </summary>
        ViewPublicTransit = Interop.ServiceData.ViewPublicTransit,
        /// <summary>
        /// Indicates availability of 3D building drawable on the Map.
        /// </summary>
        ViewBuilding = Interop.ServiceData.ViewBuilding,
        /// <summary>
        /// Indicates availability of scale bar on the Map.
        /// </summary>
        ViewScaleBar = Interop.ServiceData.ViewScaleBar,
    }
}
