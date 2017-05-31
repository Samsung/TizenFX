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

namespace Tizen.Location.Geofence
{
    /// <summary>
    /// Enumeration for geofence type.
    /// </summary>
    public enum FenceType
    {
        /// <summary>
        /// Geofence is specified by geospatial coordinate.
        /// </summary>
        GeoPoint = 1,

        /// <summary>
        /// Geofence is specified by Wi-Fi access point.
        /// </summary>
        Wifi,

        /// <summary>
        /// Geofence is specified by Bluetooth device.
        /// </summary>
        Bluetooth
    };

    /// <summary>
    /// Enumerations for the state of geofence.
    /// </summary>
    public enum GeofenceState
    {
        /// <summary>
        /// Uncertain state of geofence.
        /// </summary>
        Uncertain = 0,

        /// <summary>
        /// Geofence In state.
        /// </summary>
        In,

        /// <summary>
        /// Geofence Out state.
        /// </summary>
        Out
    };

    /// <summary>
    /// Enumerations for geofence management events.
    /// </summary>
    public enum GeofenceEventType
    {
        /// <summary>
        /// Geofence is added.
        /// </summary>
        FenceAdded = 0,

        /// <summary>
        /// Geofence is removed.
        /// </summary>
        FenceRemoved,

        /// <summary>
        /// Geofencing is started.
        /// </summary>
        FenceStarted,

        /// <summary>
        /// Geofencing is stopped.
        /// </summary>
        FenceStopped,

        /// <summary>
        /// Place is added.
        /// </summary>
        PlaceAdded = 0x10,

        /// <summary>
        /// Place is removed.
        /// </summary>
        PlaceRemoved,

        /// <summary>
        /// Place is updated.
        /// </summary>
        PlaceUpdated,

        /// <summary>
        /// Setting for geofencing is enabled.
        /// </summary>
        SettingEnabled = 0x20,

        /// <summary>
        /// Setting for geofencing is disabled.
        /// </summary>
        SettingDisabled
    };

    /// <summary>
    /// Enumeration for the provider of proximity.
    /// </summary>
    public enum ProximityProvider
    {
        /// <summary>
        /// Proximity is specified by geospatial coordinate.
        /// </summary>
        Location = 0,

        /// <summary>
        /// Proximity is specified by Wi-Fi access point.
        /// </summary>
        Wifi,

        /// <summary>
        /// Proximity is specified by Bluetooth device.
        /// </summary>
        Bluetooth,

        /// <summary>
        /// Proximity is specified by Bluetooth low energy device.
        /// </summary>
        BLE,

        /// <summary>
        /// Proximity is specified by Sensor.
        /// </summary>
        Sensor
    }

    /// <summary>
    /// Enumeration for the state of proximity.
    /// </summary>
    public enum ProximityState
    {
        /// <summary>
        /// Uncertain state of proximity.
        /// </summary>
        Uncertain = 0,

        /// <summary>
        /// Far state of proximity.
        /// </summary>
        Far,

        /// <summary>
        /// Far state of proximity.
        /// </summary>
        Near,

        /// <summary>
        /// Immediate state of proximity.
        /// </summary>
        Immediate
    }
}
