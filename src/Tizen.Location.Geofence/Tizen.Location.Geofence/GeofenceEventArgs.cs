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

namespace Tizen.Location.Geofence
{
    /// <summary>
    /// Event arguments passed when Event is triggered to notify proximity state change.
    /// </summary>
    public class ProximityStateEventArgs : EventArgs
    {
        /// <summary>
        /// Internal constructor
        /// </summary>
        /// <param name="id">The geofence id </param>
        /// <param name="state">The proximity state</param>
        /// <param name="provider">The proximity provider</param>
        internal ProximityStateEventArgs(int id, ProximityState state, ProximityProvider provider)
        {
            GeofenceId = id;
            State = state;
            Provider = provider;
        }

        /// <summary>
        /// The geofence id
        /// </summary>
        public int GeofenceId
        {
            get;
        }

        /// <summary>
        /// The proximity state
        /// </summary>
        public ProximityState State
        {
            get;
        }

        /// <summary>
        /// The proximity provider
        /// </summary>
        public ProximityProvider Provider
        {
            get;
        }
    };

    /// <summary>
    /// Event arguments passed when Event is triggered to notify Geofence state change.
    /// </summary>
    public class GeofenceStateEventArgs : EventArgs
    {
        /// <summary>
        /// Internal constructor
        /// </summary>
        /// <param name="fenceId">The specified geofence id</param>
        /// <param name="state">The geofence state</param>
        internal GeofenceStateEventArgs(int fenceId, GeofenceState state)
        {
            GeofenceId = fenceId;
            State = state;
        }

        /// <summary>
        /// The specified geofence id
        /// </summary>
        public int GeofenceId
        {
            get;
        }

        /// <summary>
        /// The geofence state
        /// </summary>
        public GeofenceState State
        {
            get;
        }
    }

    /// <summary>
    /// Event arguments passed when Event occurs in geofence and place such as add, update, etc..
    /// </summary>
    public class GeofenceResponseEventArgs : EventArgs
    {
        /// <summary>
        /// Internal constructor
        /// </summary>
        /// <param name="placeId">The place id </param>
        /// <param name="fenceId">The specified geofence id</param>
        /// <param name="error">The error code for the particular action </param>
        /// <param name="eventType">The result code for the particular place and geofence management</param>
        internal GeofenceResponseEventArgs(int placeId, int fenceId, GeofenceError error, GeoFenceEventType eventType)
        {
            PlaceId = placeId;
            FenceId = fenceId;
            ErrorCode = error;
            EventType = eventType;
        }

        /// <summary>
        /// The place id
        /// </summary>
        public int PlaceId
        {
            get;
        }

        /// <summary>
        /// The specified geofence id
        /// </summary>
        public int FenceId
        {
            get;
        }

        /// <summary>
        /// The error code for the particular action
        /// </summary>
        public GeofenceError ErrorCode
        {
            get;
        }

        /// <summary>
        /// The result code for the particular place and geofence management
        /// </summary>
        public GeoFenceEventType EventType
        {
            get;
        }
    };
}
