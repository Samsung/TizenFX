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

namespace Tizen.System
{
    /// <summary>
    /// Enumeration for the runtime information key.
    /// </summary>
    internal enum RuntimeInfoKey
    {
        /// <summary>
        /// Indicates whether Bluetooth is enabled.
        /// </summary>
        Bluetooth = 2,
        /// <summary>
        /// Indicates whether Wi-Fi hotspot is enabled.
        /// </summary>
        WifiHotspot = 3,
        /// <summary>
        /// Indicates whether Bluetooth tethering is enabled.
        /// </summary>
        BluetoothTethering = 4,
        /// <summary>
        /// Indicates whether USB tethering is enabled.
        /// </summary>
        UsbTethering = 5,
        /// <summary>
        /// Indicates whether packet data through 3G network is enabled.
        /// </summary>
        PacketData = 9,
        /// <summary>
        /// Indicates whether data roaming is enabled.
        /// </summary>
        DataRoaming = 10,
        /// <summary>
        /// Indicates whether vibration is enabled.
        /// </summary>
        Vibration = 12,
        /// <summary>
        /// Indicates whether audio jack is connected.
        /// </summary>
        AudioJack = 17,
        /// <summary>
        /// Indicates the current status of GPS.
        /// <see cref="GpsStatus"/>
        /// </summary>
        Gps = 18,
        /// <summary>
        /// Indicates whether the battery is currently charging.
        /// </summary>
        BatteryIsCharging = 19,
        /// <summary>
        /// Indicates whether TV out is connected.
        /// </summary>
        TvOut = 20,
        /// <summary>
        /// Indicates change in the audio jack connector type.
        /// <see cref="AudioJackConnectionType"/>
        /// </summary>
        AudioJackConnector = 21,
        /// <summary>
        /// Indicates whether the charger is connected.
        /// </summary>
        Charger = 24,
        /// <summary>
        /// Indicates whether auto rotation is enabled.
        /// </summary>
        AutoRotation = 26
    }

    /// <summary>
    /// Enumeration for the GPS status.
    /// </summary>
    public enum GpsStatus
    {
        /// <summary>
        /// The GPS is disabled.
        /// </summary>
        Disabled,
        /// <summary>
        /// The GPS is searching for satellites.
        /// </summary>
        Searching,
        /// <summary>
        /// The GPS connection is established.
        /// </summary>
        Connected
    }

    /// <summary>
    /// Enumeration for the type of audio jack connected.
    /// </summary>
    public enum AudioJackConnectionType
    {
        /// <summary>
        /// The audio jack is not connected.
        /// </summary>
        Unconnected,
        /// <summary>
        /// The 3-conductor wire is connected.
        /// </summary>
        ThreeWireConnected,
        /// <summary>
        /// The 4-conductor wire is connected.
        /// </summary>
        FourWireConnected
    }
}
