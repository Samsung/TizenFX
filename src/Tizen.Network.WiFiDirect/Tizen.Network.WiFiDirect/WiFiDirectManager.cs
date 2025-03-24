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
using System.ComponentModel;
using System.Collections.Generic;

namespace Tizen.Network.WiFiDirect
{
    /// <summary>
    /// A class which is used to manage settings of Wi-Fi Direct.<br/>
    /// This class is used to discover peer devices and manage settings of Wi-Fi Direct.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public static class WiFiDirectManager
    {
        /// <summary>
        /// Gets the IsInitialized.
        /// </summary>
        /// <value>
        /// A property to check whether the Wifidirect is initialized or not.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <remarks>
        /// If it is not initialized, false will be returned.
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool IsInitialized
        {
            get
            {
                return WiFiDirectManagerImpl.Instance.IsInitialize;
            }
        }
        /// <summary>
        /// Gets the IsGroupOwner.
        /// </summary>
        /// <value>
        /// A property to check whether the device is group owner or not.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, false will be returned.
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets the IsAutonomousGroup.
        /// </summary>
        /// <value>
        /// A property to check whether the current group is the autonomous group or not.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, false will be returned.
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets the Ssid.
        /// </summary>
        /// <value>
        /// SSID of local device.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <remarks>
        /// If there is any error, null will be returned.
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets the NetworkInterface.
        /// </summary>
        /// <value>
        /// Name of network interface.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, null will be returned.
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets the IpAddress.
        /// </summary>
        /// <value>
        /// IP address of a local device.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, null will be returned.
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets the SubnetMask.
        /// </summary>
        /// <value>
        /// Subnet mask.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, null will be returned.
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets the GatewayAddress.
        /// </summary>
        /// <value>
        /// Gateway address.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, null will be returned.
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets the MacAddress.
        /// </summary>
        /// <value>
        /// Mac address of a local device.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <remarks>
        /// If there is any error, null will be returned.
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets the State.
        /// </summary>
        /// <value>
        /// State of Wi-Fi direct service.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <value>
        ///
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets the IsListenOnly.
        /// </summary>
        /// <value>
        /// A property to check whether the local device is listening only.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, false will be returned.
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets the PrimaryType.
        /// </summary>
        /// <value>
        /// Primary device type of local device.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <remarks>
        /// If there is any error, 0 will be returned.
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets the SecondaryType.
        /// </summary>
        /// <value>
        /// Secondary device type of local device.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <remarks>
        /// If there is any error, 0 will be returned.
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets the WpsMode.
        /// </summary>
        /// <value>
        /// Supported WPS (Wi-Fi Protected Setup) types at local device.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <remarks>
        /// If there is any error, -1 will be returned.
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets the Wps.
        /// </summary>
        /// <value>
        /// WPS (Wi-Fi Protected Setup) type.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets the OperatingChannel.
        /// </summary>
        /// <value>
        /// Channel number on which the P2P Device is operating as the P2P Group.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <remarks>
        /// If there is any error, -1 will be returned.
        /// </remarks>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets and sets the PersistentGroupEnabled.
        /// </summary>
        /// <value>
        /// A property to check whether persistent group is enabled.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets and sets the AutoConnect.
        /// </summary>
        /// <value>
        /// Autoconnection mode status.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets and sets the WpsPin.
        /// </summary>
        /// <value>
        /// WPS PIN number.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, null will be returned during get and Not permitted exception message will be returned during set.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets and sets the Name.
        /// </summary>
        /// <value>
        /// Name of local device.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets and sets the RequestedWps.
        /// </summary>
        /// <value>
        /// Requested WPS (Wi-Fi Protected Setup) type.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets and sets the GroupOwnerIntent.
        /// </summary>
        /// <value>
        /// Intent of the group owner.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets and sets the MaxClients.
        /// </summary>
        /// <value>
        /// Max number of clients.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets and sets the Passphrase.
        /// It is used during Wi-Fi Direct Group creation.
        /// </summary>
        /// <value>
        /// Wi-Fi Protected Access (WPA) password.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, null will be returned during get and Not permitted exception message will be returned during set.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets and sets the SessionTimer.
        /// </summary>
        /// <value>
        /// Connection session timer value in second.
        /// </value>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If it is deactivated, -1 will be returned during get and Not permitted exception message will be returned during set.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If this succeeds, DeviceStateChanged event will be invoked.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <param name="listenOnly">Listen status.If False, then cycle between Scan and Listen.If True, then skip the initial 802.11 Scan and enter Listen state.</param>
        /// <param name="duration">Duration of discovery period, in seconds.</param>
        /// <param name="channel">Discovery channel.It is optional, default enum value FullScan is assigned.</param>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If this succeeds, DiscoveryStateChanged and PeerFound event will be invoked.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <remarks>
        /// Discovery must be started by StartDiscovery.
        /// If this succeeds, DiscoveryStateChanged and PeerFound event will be invoked.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <returns> List of discovered peer objects.</returns>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <returns> List of connected peer objects.</returns>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If this succeeds, ConnectionStatusChanged event will be invoked.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If this succeeds, ConnectionStatusChanged event will be invoked with GroupCreated.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Creates a Wi-Fi Direct group with given SSID and sets up device as the group owner.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If this succeeds, <see cref="ConnectionStatusChanged"/> event will be invoked with <see cref="WiFiDirectConnectionState.GroupCreated"/>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 12 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void CreateGroup(string ssid)
        {
            if (Globals.IsActivated)
            {
                WiFiDirectManagerImpl.Instance.CreateGroup(ssid);
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
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If this succeeds, ConnectionStatusChanged event will be invoked with GroupDestroyed.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <returns>The list of supported wps types.</returns>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <returns>List of the persistent group objects.</returns>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <param name="group">Persistent group owner.</param>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// Initializes or Deintializes the Wi-Fi Direct Display(MIRACAST) service.
        /// </summary>
        /// <param name="enable">Enables/Disables service.</param>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// http://tizen.org/feature/network.wifi.direct.display
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// </remarks>
        /// <exception cref="NotSupportedException">
        /// Thrown during one of the following cases :
        /// 1. When the wifidirect is not supported
        /// 2. When the wifidirect display feature is not supported
        /// </exception>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// http://tizen.org/feature/network.wifi.direct.display
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// </remarks>
        /// <exception cref="NotSupportedException">
        /// Thrown during one of the following cases :
        /// 1. When the wifidirect is not supported
        /// 2. When the wifidirect display feature is not supported
        /// </exception>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// http://tizen.org/feature/network.wifi.direct.display
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated and WFD must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">
        /// Thrown during one of the following cases :
        /// 1. When the wifidirect is not supported
        /// 2. When the wifidirect display feature is not supported
        /// </exception>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <param name="type">WFD Device Type: define the Role of WFD device like source or sink.</param>
        /// <param name="port">Specifies Session Management Control Port number. It should be 2 bytes(0~65535).</param>
        /// <param name="hdcp">CP support bit: (1 = enable the hdcp support, 0 = disable the hdcp support).</param>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// http://tizen.org/feature/network.wifi.direct.display
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated and WFD must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">
        /// Thrown during one of the following cases :
        /// 1. When the wifidirect is not supported
        /// 2. When the wifidirect display feature is not supported
        /// </exception>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <param name="availability">Wi-Fi Display session availability.</param>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// http://tizen.org/feature/network.wifi.direct.display
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated and WFD must be enabled.
        /// </remarks>
        /// <exception cref="NotSupportedException">
        /// Thrown during one of the following cases :
        /// 1. When the wifidirect is not supported
        /// 2. When the wifidirect display feature is not supported
        /// </exception>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <param name="enable">Enables/Disables group removal feature.</param>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// ConnectionStatusChanged event will be invoked with GroupDestroyed when this feature is enabled and there's no connected group client and if device is group owner.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <returns>The service Id of service getting registered.</returns>
        /// <param name="type">Type of Wi-Fi Direct Service.</param>
        /// <param name="info">Service specific information.</param>
        /// <param name="serviceInfo">Service information.</param>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// http://tizen.org/feature/network.wifi.direct.service_discovery
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If there is any error while registering service, 0 will be returned.
        /// </remarks>
        /// <exception cref="NotSupportedException">
        /// Thrown during one of the following cases :
        /// 1. When the wifidirect is not supported
        /// 2. When the wifidirect service discovery is not supported
        /// </exception>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// <param name="serviceId"> Service ID for which service has to be deregistered.</param>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// http://tizen.org/feature/network.wifi.direct.service_discovery
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// </remarks>
        /// <exception cref="NotSupportedException">
        /// Thrown during one of the following cases :
        /// 1. When the wifidirect is not supported
        /// 2. When the wifidirect service discovery is not supported
        /// </exception>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Adds the Wi-Fi Vendor Specific Information Element (VSIE) to specific frame type.
        /// </summary>
        /// <param name="frameType">frame type for setting VSIE.</param>
        /// <param name="vsie">VSIE value. A valid string contains hexadecimal characters i.e. [0-9a-f]</param>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// <paramref name="vsie"/> for <paramref name="frameType"/> will be in effect until Wi-Fi Direct is deactivated.
        /// A valid VSIE value if not already added, will be appended to already added VSIE values. Already present VSIE value will do nothing.
        /// In case of invalid VSIE, an InvalidOperationException exception will thrown.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void AddVsie(WiFiDirectVsieFrameType frameType, string vsie)
        {
            if (Globals.IsActivated)
            {
                WiFiDirectManagerImpl.Instance.AddVsie(frameType, vsie);
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Gets the Wi-Fi Vendor Specific Information Elements (VSIE) from specific frame type.
        /// </summary>
        /// <param name="frameType">frame type for getting VSIE.</param>
        /// <returns>VSIE value if success else null value.</returns>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static string GetVsie(WiFiDirectVsieFrameType frameType)
        {
            if (Globals.IsActivated)
            {
                return WiFiDirectManagerImpl.Instance.GetVsie(frameType);
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
                return null;
            }
        }

        /// <summary>
        /// Removes the Wi-Fi Vendor Specific Information Element (VSIE) from specific frame type.
        /// </summary>
        /// <param name="frameType">frame type for removing VSIE.</param>
        /// <param name="vsie">VSIE value</param>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// A VSIE value if already added, will be removed from VSIE value else InvalidOperationException will be thrown.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void RemoveVsie(WiFiDirectVsieFrameType frameType, string vsie)
        {
            if (Globals.IsActivated)
            {
                WiFiDirectManagerImpl.Instance.RemoveVsie(frameType, vsie);
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Gets the information of peer devices which is in the connecting state.
        /// </summary>
        /// <returns>Connecting peer object.</returns>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct service must be in connecting state.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static WiFiDirectPeer GetConnectingPeer()
        {
            if (Globals.IsActivated)
            {
                return WiFiDirectManagerImpl.Instance.GetConnectingPeer();
            }

            else
            {
                return null;
            }
        }

        /// <summary>
        /// Accepts a connection requested from peer.
        /// </summary>
        /// <param name="peerMacAddress">MAC Address of the peer.</param>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void AcceptConnection(string peerMacAddress)
        {
            if (Globals.IsActivated)
            {
                WiFiDirectManagerImpl.Instance.AcceptConnection(peerMacAddress);
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Rejects the connection request from other device now in progress.
        /// </summary>
        /// <param name="peerMacAddress">The MAC address of rejected device.</param>
        /// <privilege>
        /// http://tizen.org/privilege/wifidirect
        /// </privilege>
        /// <feature>
        /// http://tizen.org/feature/network.wifidirect
        /// </feature>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// </remarks>
        /// <exception cref="InvalidOperationException">The object is in invalid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method.</exception>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void RejectConnection(string peerMacAddress)
        {
            if (Globals.IsActivated)
            {
                WiFiDirectManagerImpl.Instance.RejectConnection(peerMacAddress);
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }
    }
}
