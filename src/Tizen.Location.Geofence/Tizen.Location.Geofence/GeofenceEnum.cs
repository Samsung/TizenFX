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
    /// Enumeration for the geofence types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum FenceType
    {
        /// <summary>
        /// Geofence is specified by the geospatial coordinate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        GeoPoint = 1,

        /// <summary>
        /// Geofence is specified by the Wi-Fi access point.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Wifi,

        /// <summary>
        /// Geofence is specified by the Bluetooth device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Bluetooth
    };

    /// <summary>
    /// Enumeration for the state of geofence.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum GeofenceState
    {
        /// <summary>
        /// Uncertain state of geofence.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Uncertain = 0,

        /// <summary>
        /// Geofence In state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        In,

        /// <summary>
        /// Geofence Out state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Out
    };

    /// <summary>
    /// Enumeration for the geofence management events.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum GeofenceEventType
    {
        /// <summary>
        /// Geofence is added.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        FenceAdded = 0,

        /// <summary>
        /// Geofence is removed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        FenceRemoved,

        /// <summary>
        /// Geofencing is started.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        FenceStarted,

        /// <summary>
        /// Geofencing is stopped.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        FenceStopped,

        /// <summary>
        /// Place is added.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        PlaceAdded = 0x10,

        /// <summary>
        /// Place is removed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        PlaceRemoved,

        /// <summary>
        /// Place is updated.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        PlaceUpdated,

        /// <summary>
        /// Setting for geofencing is enabled.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        SettingEnabled = 0x20,

        /// <summary>
        /// Setting for geofencing is disabled.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        SettingDisabled
    };

    /// <summary>
    /// Enumeration for the provider of proximity.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ProximityProvider
    {
        /// <summary>
        /// Proximity is specified by the geospatial coordinate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Location = 0,

        /// <summary>
        /// Proximity is specified by the Wi-Fi access point.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Wifi,

        /// <summary>
        /// Proximity is specified by the Bluetooth device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Bluetooth,

        /// <summary>
        /// Proximity is specified by the Bluetooth low-energy device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        BLE,

        /// <summary>
        /// Proximity is specified by the sensor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Sensor
    }

    /// <summary>
    /// Enumeration for the state of proximity.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ProximityState
    {
        /// <summary>
        /// Uncertain state of proximity.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Uncertain = 0,

        /// <summary>
        /// Far state of proximity.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Far,

        /// <summary>
        /// Far state of proximity.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Near,

        /// <summary>
        /// Immediate state of proximity.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Immediate
    }
}
