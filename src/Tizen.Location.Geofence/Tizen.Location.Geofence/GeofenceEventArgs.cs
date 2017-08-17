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
    /// Event arguments are passed when an event is triggered to notify the proximity state change.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ProximityStateEventArgs : EventArgs
    {
        /// <summary>
        /// The internal constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="id">The geofence ID.</param>
        /// <param name="state">The proximity state.</param>
        /// <param name="provider">The proximity provider.</param>
        internal ProximityStateEventArgs(int id, ProximityState state, ProximityProvider provider)
        {
            GeofenceId = id;
            State = state;
            Provider = provider;
        }

        /// <summary>
        /// The geofence ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int GeofenceId
        {
            get;
        }

        /// <summary>
        /// The proximity state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ProximityState State
        {
            get;
        }

        /// <summary>
        /// The proximity provider.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ProximityProvider Provider
        {
            get;
        }
    };

    /// <summary>
    /// Event arguments are passed when an event is triggered to notify the geofence state change.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class GeofenceStateEventArgs : EventArgs
    {
        /// <summary>
        /// The internal constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="fenceId">The specified geofence ID.</param>
        /// <param name="state">The geofence state.</param>
        internal GeofenceStateEventArgs(int fenceId, GeofenceState state)
        {
            GeofenceId = fenceId;
            State = state;
        }

        /// <summary>
        /// The specified geofence ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int GeofenceId
        {
            get;
        }

        /// <summary>
        /// The geofence state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public GeofenceState State
        {
            get;
        }
    }

    /// <summary>
    /// Event arguments are passed when an event occurs in geofence and the place, such as add, update, etc..
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class GeofenceResponseEventArgs : EventArgs
    {
        /// <summary>
        /// The internal constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="placeId">The place ID.</param>
        /// <param name="fenceId">The specified geofence ID.</param>
        /// <param name="error">The error code for the particular action.</param>
        /// <param name="eventType">The result code for the particular place and geofence management.</param>
        internal GeofenceResponseEventArgs(int placeId, int fenceId, GeofenceError error, GeofenceEventType eventType)
        {
            PlaceId = placeId;
            FenceId = fenceId;
            ErrorCode = error;
            EventType = eventType;
        }

        /// <summary>
        /// The place ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int PlaceId
        {
            get;
        }

        /// <summary>
        /// The specified geofence ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int FenceId
        {
            get;
        }

        /// <summary>
        /// The error code for the particular action.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public GeofenceError ErrorCode
        {
            get;
        }

        /// <summary>
        /// The result code for the particular place and geofence management.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public GeofenceEventType EventType
        {
            get;
        }
    };
}
