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

namespace Tizen.Network.WiFiDirect
{
    /// <summary>
    /// A class which is used to manage settings of Wi-Fi Direct.<br>
    /// This class is used to discover peer devices and manage settings of Wi-Fi Direct.
    /// </summary>
    /// <privilege> http://tizen.org/privilege/wifidirect </privilege>
    public static class WiFiDirectManager
    {
        /// <summary>
        /// A property to check whether the device is group owner or not.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, false will be returned.
        /// </remarks>
        public static bool IsGroupOwner
        {
            get
            {
                if (Globals.IsActivated)
                {
                    return WiFiDirectManagerImpl.Instance.IsGroupOwner;
                }

                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// A property to check whether the current group is the autonomous group or not.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, false will be returned.
        /// </remarks>
        public static bool IsAutonomousGroup
        {
            get
            {
                if (Globals.IsActivated)
                {
                    return WiFiDirectManagerImpl.Instance.IsAutonomousGroup;
                }

                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// SSID of local device.
        /// </summary>
        /// <remarks>
        /// If there is any error, null will be returned.
        /// </remarks>
        public static string Ssid
        {
            get
            {
                if (Globals.IsInitialize)
                {
                    return WiFiDirectManagerImpl.Instance.Ssid;
                }

                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Name of network interface.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, null will be returned.
        /// </remarks>
        public static string NetworkInterface
        {
            get
            {
                if (Globals.IsActivated)
                {
                    return WiFiDirectManagerImpl.Instance.NetworkInterface;
                }

                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// IP address of a local device.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, null will be returned.
        /// </remarks>
        public static string IpAddress
        {
            get
            {
                if (Globals.IsActivated)
                {
                    return WiFiDirectManagerImpl.Instance.IpAddress;
                }

                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Subnet mask.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, null will be returned.
        /// </remarks>
        public static string SubnetMask
        {
            get
            {
                if (Globals.IsActivated)
                {
                    return WiFiDirectManagerImpl.Instance.SubnetMask;
                }

                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gateway address.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, null will be returned.
        /// </remarks>
        public static string GatewayAddress
        {
            get
            {
                if (Globals.IsActivated)
                {
                    return WiFiDirectManagerImpl.Instance.GatewayAddress;
                }

                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Mac address of a local device.
        /// </summary>
        /// <remarks>
        /// If there is any error, null will be returned.
        /// </remarks>
        public static string MacAddress
        {
            get
            {
                if (Globals.IsInitialize)
                {
                    return WiFiDirectManagerImpl.Instance.MacAddress;
                }

                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// State of Wi-Fi direct service.
        /// </summary>
        public static WiFiDirectState State
        {
            get
            {
                return WiFiDirectManagerImpl.Instance.State;
            }
        }

        /// <summary>
        /// A property to check whether the device is discoverable or not by P2P discovery.
        /// </summary>
        public static bool IsDiscoverable
        {
            get
            {
                if (Globals.IsInitialize)
                {
                    return WiFiDirectManagerImpl.Instance.IsDiscoverable;
                }

                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// A property to check whether the local device is listening only.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, false will be returned.
        /// </remarks>
        public static bool IsListenOnly
        {
            get
            {
                if (Globals.IsActivated)
                {
                    return WiFiDirectManagerImpl.Instance.IsListenOnly;
                }

                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Primary device type of local device.
        /// </summary>
        /// <remarks>
        /// If there is any error, 0 will be returned.
        /// </remarks>
        public static WiFiDirectPrimaryDeviceType PrimaryType
        {
            get
            {
                if (Globals.IsInitialize)
                {
                    return WiFiDirectManagerImpl.Instance.PrimaryType;
                }

                else
                {
                    return default(WiFiDirectPrimaryDeviceType);
                }
            }
        }

        /// <summary>
        /// Secondary device type of local device.
        /// </summary>
        /// <remarks>
        /// If there is any error, 0 will be returned.
        /// </remarks>
        public static WiFiDirectSecondaryDeviceType SecondaryType
        {
            get
            {
                if (Globals.IsInitialize)
                {
                    return WiFiDirectManagerImpl.Instance.SecondaryType;
                }

                else
                {
                    return default(WiFiDirectSecondaryDeviceType);
                }
            }
        }

        /// <summary>
        /// Supported WPS (Wi-Fi Protected Setup) types at local device.
        /// </summary>
        /// <remarks>
        /// If there is any error, -1 will be returned.
        /// </remarks>
        public static int WpsMode
        {
            get
            {
                if (Globals.IsInitialize)
                {
                    return WiFiDirectManagerImpl.Instance.WpsMode;
                }

                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// WPS (Wi-Fi Protected Setup) type.
        /// </summary>
        public static WiFiDirectWpsType Wps
        {
            get
            {
                if (Globals.IsInitialize)
                {
                    return WiFiDirectManagerImpl.Instance.WpsType;
                }

                else
                {
                    return default(WiFiDirectWpsType);
                }
            }
        }

        /// <summary>
        /// Channel number on which the P2P Device is operating as the P2P Group.
        /// </summary>
        /// <remarks>
        /// If there is any error, -1 will be returned.
        /// </remarks>
        public static int OperatingChannel
        {
            get
            {
                if (Globals.IsInitialize)
                {
                    return WiFiDirectManagerImpl.Instance.OperatingChannel;
                }

                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// A property to check whether persistent group is enabled.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown while setting this property when the wifidirect is not supported</exception>
        public static bool PersistentGroupEnabled
        {
            get
            {
                if (Globals.IsInitialize)
                {
                    return WiFiDirectManagerImpl.Instance.PersistentGroupEnabled;
                }

                else
                {
                    return false;
                }
            }

            set
            {
                if (Globals.IsInitialize)
                {
                    WiFiDirectManagerImpl.Instance.PersistentGroupEnabled = value;
                }
            }
        }

        /// <summary>
        /// Autoconnection mode status.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown while setting this property when the wifidirect is not supported</exception>
        public static bool AutoConnect
        {
            get
            {
                if (Globals.IsInitialize)
                {
                    return WiFiDirectManagerImpl.Instance.AutoConnect;
                }

                else
                {
                    return false;
                }
            }

            set
            {
                if (Globals.IsInitialize)
                {
                    WiFiDirectManagerImpl.Instance.AutoConnect = value;
                }
            }
        }

        /// <summary>
        /// WPS PIN number.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, null will be returned during get and Not permitted exception message will be returned during set.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown while setting this property when the wifidirect is not supported</exception>
        public static string WpsPin
        {
            get
            {
                if (Globals.IsActivated)
                {
                    return WiFiDirectManagerImpl.Instance.WpsPin;
                }

                else
                {
                    return null;
                }
            }

            set
            {
                if (Globals.IsActivated)
                {
                    WiFiDirectManagerImpl.Instance.WpsPin = value;
                }

                else
                {
                    Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                    WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
                }
            }
        }

        /// <summary>
        /// Name of local device.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown while setting this property when the wifidirect is not supported</exception>
        public static string Name
        {
            get
            {
                if (Globals.IsInitialize)
                {
                    return WiFiDirectManagerImpl.Instance.Name;
                }

                else
                {
                    return null;
                }
            }

            set
            {
                if (Globals.IsInitialize)
                {
                    WiFiDirectManagerImpl.Instance.Name = value;
                }
            }
        }

        /// <summary>
        /// Requested WPS (Wi-Fi Protected Setup) type.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown while setting this property when the wifidirect is not supported</exception>
        public static WiFiDirectWpsType RequestedWps
        {
            get
            {
                if (Globals.IsInitialize)
                {
                    return WiFiDirectManagerImpl.Instance.RequestedWps;
                }

                else
                {
                    return default(WiFiDirectWpsType);
                }
            }

            set
            {
                if (Globals.IsInitialize)
                {
                    WiFiDirectManagerImpl.Instance.RequestedWps = value;
                }
            }
        }

        /// <summary>
        /// Intent of the group owner.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown while setting this property when the wifidirect is not supported</exception>
        public static int GroupOwnerIntent
        {
            get
            {
                if (Globals.IsInitialize)
                {
                    return WiFiDirectManagerImpl.Instance.GroupOwnerIntent;
                }

                else
                {
                    return -1;
                }
            }

            set
            {
                if (Globals.IsInitialize)
                {
                    WiFiDirectManagerImpl.Instance.GroupOwnerIntent = value;
                }
            }
        }

        /// <summary>
        /// Max number of clients.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown while setting this property when the wifidirect is not supported</exception>
        public static int MaxClients
        {
            get
            {
                if (Globals.IsInitialize)
                {
                    return WiFiDirectManagerImpl.Instance.MaxClients;
                }

                else
                {
                    return -1;
                }
            }

            set
            {
                if (Globals.IsInitialize)
                {
                    WiFiDirectManagerImpl.Instance.MaxClients = value;
                }
            }
        }

        /// <summary>
        /// Wi-Fi Protected Access (WPA) password.
        /// It is used during Wi-Fi Direct Group creation.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, null will be returned during get and Not permitted exception message will be returned during set.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown while setting this property when the wifidirect is not supported</exception>
        public static string Passphrase
        {
            get
            {
                if (Globals.IsActivated)
                {
                    return WiFiDirectManagerImpl.Instance.Passphrase;
                }

                else
                {
                    return null;
                }
            }

            set
            {
                if (Globals.IsActivated)
                {
                    WiFiDirectManagerImpl.Instance.Passphrase = value;
                }

                else
                {
                    Log.Error(Globals.LogTag, "Wi-Fi direct is not activated");
                    WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
                }
            }
        }

        /// <summary>
        /// Connection session timer value in second.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, -1 will be returned during get and Not permitted exception message will be returned during set.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown while setting this property when the wifidirect is not supported</exception>
        public static int SessionTimer
        {
            get
            {
                if (Globals.IsActivated)
                {
                    return WiFiDirectManagerImpl.Instance.SessionTimer;
                }

                else
                {
                    return -1;
                }
            }

            set
            {
                if (Globals.IsActivated)
                {
                    WiFiDirectManagerImpl.Instance.SessionTimer = value;
                }

                else
                {
                    Log.Error(Globals.LogTag, "Wi-Fi direct is not activated");
                    WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
                }
            }
        }

        /// <summary>
        /// (event) StateChanged is raised when Wi-Fi Direct state is changed.
        /// </summary>
        public static event EventHandler<StateChangedEventArgs> StateChanged
        {
            add
            {
                WiFiDirectManagerImpl.Instance.StateChanged += value;
            }

            remove
            {
                WiFiDirectManagerImpl.Instance.StateChanged -= value;
            }
        }

        /// <summary>
        /// (event) DiscoveryStateChanged is raised when Wi-Fi Direct discovery state is changed.
        /// </summary>
        public static event EventHandler<DiscoveryStateChangedEventArgs> DiscoveryStateChanged
        {
            add
            {
                if (Globals.IsInitialize)
                {
                    WiFiDirectManagerImpl.Instance.DiscoveryStateChanged += value;
                }
            }

            remove
            {
                if (Globals.IsInitialize)
                {
                    WiFiDirectManagerImpl.Instance.DiscoveryStateChanged -= value;
                }
            }
        }

        /// <summary>
        /// (event) DeviceStateChanged is raised when device state is changed.
        /// </summary>
        public static event EventHandler<DeviceStateChangedEventArgs> DeviceStateChanged
        {
            add
            {
                if (Globals.IsInitialize)
                {
                    WiFiDirectManagerImpl.Instance.DeviceStateChanged += value;
                }
            }

            remove
            {
                if (Globals.IsInitialize)
                {
                    WiFiDirectManagerImpl.Instance.DeviceStateChanged -= value;
                }
            }
        }

        /// <summary>
        /// (event) PeerFound is raised when peer is found.
        /// </summary>
        public static event EventHandler<PeerFoundEventArgs> PeerFound
        {
            add
            {
                if (Globals.IsInitialize)
                {
                    WiFiDirectManagerImpl.Instance.PeerFound += value;
                }
            }

            remove
            {
                if (Globals.IsInitialize)
                {
                    WiFiDirectManagerImpl.Instance.PeerFound -= value;
                }
            }
        }

        /// <summary>
        /// (event) ConnectionStatusChanged is raised when status of connection is changed.
        /// </summary>
        public static event EventHandler<ConnectionStatusChangedEventArgs> ConnectionStatusChanged
        {
            add
            {
                if (Globals.IsInitialize)
                {
                    WiFiDirectManagerImpl.Instance.ConnectionStatusChanged += value;
                }
            }

            remove
            {
                if (Globals.IsInitialize)
                {
                    WiFiDirectManagerImpl.Instance.ConnectionStatusChanged -= value;
                }
            }
        }

        /// <summary>
        /// Activates the Wi-Fi Direct service.
        /// </summary>
        /// <remarks>
        /// If this succeeds, DeviceStateChanged event will be invoked.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the wifidirect is not supported</exception>
        public static void Activate()
        {
            if (Globals.IsInitialize)
            {
                WiFiDirectManagerImpl.Instance.Activate();
            }

            else
            {
                Log.Error(Globals.LogTag, "Wi-Fi direct is not initialized");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotInitialized);
            }
        }

        /// <summary>
        /// Deactivates the Wi-Fi Direct service.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If this succeeds, DeviceStateChanged event will be invoked.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the wifidirect is not supported</exception>
        public static void Deactivate()
        {
            if (Globals.IsActivated)
            {
                WiFiDirectManagerImpl.Instance.Deactivate();
            }

            else
            {
                Log.Error(Globals.LogTag, "Wi-Fi direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Starts discovery to find all P2P capable devices.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If this succeeds, DiscoveryStateChanged and PeerFound event will be invoked.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the wifidirect is not supported</exception>
        /// <param name="listenOnly">Listen status.If False, then cycle between Scan and Listen.If True, then skip the initial 802.11 Scan and enter Listen state.</param>
        /// <param name="duration">Duration of discovery period, in seconds.</param>
        /// <param name="channel">Discovery channel.It is optional, default enum value FullScan is assigned.</param>
        public static void StartDiscovery(bool listenOnly, int duration, WiFiDirectDiscoveryChannel channel = WiFiDirectDiscoveryChannel.FullScan)
        {
            if (Globals.IsActivated)
            {
                WiFiDirectManagerImpl.Instance.StartDiscovery(listenOnly, duration, channel);
            }

            else
            {
                Log.Error(Globals.LogTag, "Wi-Fi direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Cancels discovery process.
        /// </summary>
        /// <remarks>
        /// Discovery must be started by StartDiscovery.
        /// If this succeeds, DiscoveryStateChanged and PeerFound event will be invoked.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the wifidirect is not supported</exception>
        public static void CancelDiscovery()
        {
            if (WiFiDirectManager.State == WiFiDirectState.Discovering)
            {
                WiFiDirectManagerImpl.Instance.CancelDiscovery();
            }

            else
            {
                Log.Error(Globals.LogTag, "Wi-Fi direct discovery is not started");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Gets the information of discovered peers.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the wifidirect is not supported</exception>
        /// <returns> List of discovered peer objects.</returns>
        public static IEnumerable<WiFiDirectPeer> GetDiscoveredPeers()
        {
            if (Globals.IsActivated)
            {
                return WiFiDirectManagerImpl.Instance.GetDiscoveredPeers();
            }

            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the information of connected peers.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the wifidirect is not supported</exception>
        /// <returns> List of connected peer objects.</returns>
        public static IEnumerable<WiFiDirectPeer> GetConnectedPeers()
        {
            if (Globals.IsActivated)
            {
                return WiFiDirectManagerImpl.Instance.GetConnectedPeers();
            }

            else
            {
                return null;
            }
        }

        /// <summary>
        /// Disconnects all connected links to peers.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If this succeeds, ConnectionStatusChanged event will be invoked.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the wifidirect is not supported</exception>
        public static void DisconnectAll()
        {
            if (Globals.IsActivated)
            {
                WiFiDirectManagerImpl.Instance.DisconnectAll();
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Creates a Wi-Fi Direct group and sets up device as the group owner.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If this succeeds, ConnectionStatusChanged event will be invoked with GroupCreated.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the wifidirect is not supported</exception>
        public static void CreateGroup()
        {
            if (Globals.IsActivated)
            {
                WiFiDirectManagerImpl.Instance.CreateGroup();
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Destroys the Wi-Fi Direct group owned by a local device.If creating a group is in progress, this API cancels that process.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If this succeeds, ConnectionStatusChanged event will be invoked with GroupDestroyed.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the wifidirect is not supported</exception>
        public static void DestroyGroup()
        {
            if (Globals.IsActivated)
            {
                WiFiDirectManagerImpl.Instance.DestroyGroup();
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Set the WPS config PBC as preferred method for connection.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the wifidirect is not supported</exception>
        public static void ActivatePushButton()
        {
            if (Globals.IsActivated)
            {
                WiFiDirectManagerImpl.Instance.ActivatePushButton();
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Gets the supported WPS types.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the wifidirect is not supported</exception>
        /// <returns>The list of supported wps types.</returns>
        public static IEnumerable<WiFiDirectWpsType> GetSupportedWpsTypes()
        {
            if (Globals.IsInitialize)
            {
                return WiFiDirectManagerImpl.Instance.GetSupportedWpsTypes();
            }

            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the persistent groups.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the wifidirect is not supported</exception>
        /// <returns>List of the persistent group objects.</returns>
        public static IEnumerable<WiFiDirectPersistentGroup> GetPersistentGroups()
        {
            if (Globals.IsInitialize)
            {
                return WiFiDirectManagerImpl.Instance.GetPersistentGroups();
            }

            else
            {
                return null;
            }
        }

        /// <summary>
        /// Removes a persistent group.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the wifidirect is not supported</exception>
        /// <param name="group">Persistent group owner.</param>
        public static void RemovePersistentGroup(WiFiDirectPersistentGroup group)
        {
            if (Globals.IsInitialize)
            {
                WiFiDirectManagerImpl.Instance.RemovePersistentGroup(group);
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotInitialized);
            }
        }

        /// <summary>
        /// Initializes or Deintializes the WiFi-Direct Display(MIRACAST) service.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// </remarks>
        /// <exception cref="NotSupportedException">
        /// Thrown during one of the following cases :
        /// 1. When the wifidirect is not supported
        /// 2. When the wifidirect display feature is not supported
        /// </exception>
        /// <param name="enable">Enables/Disables service.</param>
        public static void InitMiracast(bool enable)
        {
            if (Globals.IsActivated)
            {
                WiFiDirectManagerImpl.Instance.InitMiracast(enable);
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Enables Wi-Fi Display functionality.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// </remarks>
        /// <exception cref="NotSupportedException">
        /// Thrown during one of the following cases :
        /// 1. When the wifidirect is not supported
        /// 2. When the wifidirect display feature is not supported
        /// </exception>
        public static void InitDisplay()
        {
            if (Globals.IsActivated)
            {
                WiFiDirectManagerImpl.Instance.InitDisplay();
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Disable Wi-Fi Display(WFD) functionality and disable the support of WFD Information Element(IE).
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated and WFD must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">
        /// Thrown during one of the following cases :
        /// 1. When the wifidirect is not supported
        /// 2. When the wifidirect display feature is not supported
        /// </exception>
        public static void DeinitDisplay()
        {
            if (Globals.IsActivated && Globals.s_isDisplay)
            {
                WiFiDirectManagerImpl.Instance.DeinitDisplay();
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated and/or Wi-Fi display is not enabled");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Sets the Wi-Fi Display parameters for the WFD IE of local device.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated and WFD must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">
        /// Thrown during one of the following cases :
        /// 1. When the wifidirect is not supported
        /// 2. When the wifidirect display feature is not supported
        /// </exception>
        /// <param name="type">WFD Device Type: define the Role of WFD device like source or sink.</param>
        /// <param name="port">Specifies Session Management Control Port number. It should be 2 bytes(0~65535).</param>
        /// <param name="hdcp">CP support bit: (1 = enable the hdcp support, 0 = disable the hdcp support).</param>
        public static void SetDisplay(WiFiDirectDisplayType type, int port, int hdcp)
        {
            if (Globals.IsActivated && Globals.s_isDisplay)
            {
                WiFiDirectManagerImpl.Instance.SetDisplay(type, port, hdcp);
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated and/or Wi-Fi display is not enabled");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Sets the Wi-Fi Display session availability.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated and WFD must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">
        /// Thrown during one of the following cases :
        /// 1. When the wifidirect is not supported
        /// 2. When the wifidirect display feature is not supported
        /// </exception>
        /// <param name="availability">Wi-Fi Display session availability.</param>
        public static void SetDisplayAvailability(bool availability)
        {
            if (Globals.IsActivated && Globals.s_isDisplay)
            {
                WiFiDirectManagerImpl.Instance.SetDisplayAvailability(availability);
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated and/or Wi-Fi display is not enabled");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Sets the automatic group removal feature when all peers are disconnected.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// ConnectionStatusChanged event will be invoked with GroupDestroyed when this feature is enabled and there's no connected group client and if device is group owner.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the wifidirect is not supported</exception>
        /// <param name="enable">Enables/Disables group removal feature.</param>
        public static void SetAutoGroupRemove(bool enable)
        {
            if (Globals.IsActivated)
            {
                WiFiDirectManagerImpl.Instance.SetAutoGroupRemove(enable);
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Registers the service.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If there is any error while registering service, 0 will be returned.
        /// </remarks>
        /// <exception cref="NotSupportedException">
        /// Thrown during one of the following cases :
        /// 1. When the wifidirect is not supported
        /// 2. When the wifidirect service discovery is not supported
        /// </exception>
        /// <returns>The service Id of service getting registered.</returns>
        /// <param name="type">Type of Wi-Fi Direct Service.</param>
        /// <param name="info">Service specific information.</param>
        /// <param name="serviceInfo">Service information.</param>
        public static uint RegisterService(WiFiDirectServiceType type, string info, string serviceInfo)
        {
            if (Globals.IsActivated)
            {
                return WiFiDirectManagerImpl.Instance.RegisterService(type, info, serviceInfo);
            }

            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Deregisters for a service used for WiFi Direct Service Discovery.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// </remarks>
        /// <exception cref="NotSupportedException">
        /// Thrown during one of the following cases :
        /// 1. When the wifidirect is not supported
        /// 2. When the wifidirect service discovery is not supported
        /// </exception>
        /// <param name="serviceId"> Service ID for which service has to be deregistered.</param>
        public static void DeregisterService(uint serviceId)
        {
            if (Globals.IsActivated)
            {
                WiFiDirectManagerImpl.Instance.DeregisterService(serviceId);
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }
    }
}
