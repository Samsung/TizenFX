/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;

namespace Tizen.System
{
    /// <summary>
    /// Enumeration for keys for runtime information
    /// </summary>
    public enum RuntimeInformationKey
    {
        /// <summary>
        /// Indicates whether Bluetooth is enabled.
        /// </summary>
        Bluetooth = 2,
        /// <summary>
        /// Indicates whether Wi-Fi hotspot is enabled.
        /// <see cref="WifiStatus"/>
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
        /// Indicates whether the location service is allowed to use location data from GPS satellites.
        /// </summary>
        LocationService = 6,
        /// <summary>
        /// Indicates whether the location service is allowed to use location data from cellular and Wi-Fi.
        /// </summary>
        LocationNetworkPosition = 8,
        /// <summary>
        /// Indicates Whether the packet data through 3G network is enabled.
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
        /// Indicates the battery is currently charging.
        /// </summary>
        BatteryIsCharging = 19,
        /// <summary>
        /// Indicates whether TV out is connected.
        /// </summary>
        TvOut = 20,
        /// <summary>
        /// Indicates the change in audio jack connector type.
        /// <see cref="AudioJackConnectionType"/>
        /// </summary>
        AudioJackConnector = 21,
        /// <summary>
        /// Indicates whether USB is connected.
        /// </summary>
        Usb = 23,
        /// <summary>
        /// Indicates whether charger is connected.
        /// </summary>
        Charger = 24,
        /// <summary>
        /// Indicates whether auto rotation is enabled.
        /// </summary>
        AutoRotation = 26
    }

    /// <summary>
    /// Enumeration for Wi-Fi status
    /// </summary>
    public enum WifiStatus
    {
        /// <summary>
        /// Wi-Fi is disabled.
        /// </summary>
        Disabled,
        /// <summary>
        /// Wi-Fi is enabled and network connection is not established.
        /// </summary>
        Unconnected,
        /// <summary>
        ///  Network connection is established in Wi-Fi network.
        /// </summary>
        Connected
    }

    /// <summary>
    /// Enumeration for GPS status.
    /// </summary>
    public enum GpsStatus
    {
        /// <summary>
        /// GPS is disabled.
        /// </summary>
        Disabled,
        /// <summary>
        /// GPS is searching for satellites.
        /// </summary>
        Searching,
        /// <summary>
        /// GPS connection is established.
        /// </summary>
        Connected
    }

    /// <summary>
    /// Enumeration for type of audio jack connected.
    /// </summary>
    public enum AudioJackConnectionType
    {
        /// <summary>
        /// Audio jack is not connected
        /// </summary>
        Unconnected,
        /// <summary>
        /// 3-conductor wire is connected.
        /// </summary>
        ThreeWireConnected,
        /// <summary>
        /// 4-conductor wire is connected.
        /// </summary>
        FourWireConnected
    }
}
