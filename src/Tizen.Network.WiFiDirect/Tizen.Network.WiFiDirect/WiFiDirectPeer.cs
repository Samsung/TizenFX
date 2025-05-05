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
using System.Runtime.InteropServices;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Tizen.Network.WiFiDirect
{
    /// <summary>
    /// The WiFiDirectPeer class is used to handle the connection with remote devices using Wi-Fi Direct.
    /// </summary>
    /// <privilege> http://tizen.org/privilege/wifidirect </privilege>
    /// <since_tizen> 3 </since_tizen>
    public class WiFiDirectPeer
    {
        private event EventHandler<ConnectionStateChangedEventArgs> _connectionStateChanged;
        private event EventHandler<IpAddressAssignedEventArgs> _ipAddressAssigned;
        private event EventHandler<ServiceStateChangedEventArgs> _serviceStateChanged;

        private Interop.WiFiDirect.ConnectionStateChangedCallback _connectionStateChangedCallback;
        private Interop.WiFiDirect.ClientIpAddressAssignedCallback _ipAddressAssignedCallback;
        private Interop.WiFiDirect.ServiceStateChangedCallback _serviceStateChangedCallback;

        internal string _peerDeviceName;
        internal string _peerIpAddress;
        internal string _peerMacAddress;
        internal string _peerInterfaceAddress;
        internal int _peerChannel;
        internal bool _isPeerConnected;
        internal bool _isPeerGroupOwner;
        internal bool _peerP2PSupport;
        internal WiFiDirectPrimaryDeviceType _peerPrimaryType;
        internal WiFiDirectSecondaryDeviceType _peerSecondaryType;
        internal int _peerWpsTypes;
        internal bool _p2PInvitationSupported;
        internal uint _peerServiceCount;
        internal IEnumerable<string> _peerServiceList;
        internal bool _isPeerMiracastDevice;

        internal WiFiDirectPeer()
        {
        }

        /// <summary>
        /// The name of the peer device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Name
        {
            get
            {
                return _peerDeviceName;
            }
        }

        /// <summary>
        /// The IP address of the peer device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string IpAddress
        {
            get
            {
                return _peerIpAddress;
            }
        }

        /// <summary>
        /// The MAC address of the peer device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string MacAddress
        {
            get
            {
                return _peerMacAddress;
            }
        }

        /// <summary>
        /// The Interface address of the peer device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InterfaceAddress
        {
            get
            {
                return _peerInterfaceAddress;
            }
        }

        /// <summary>
        /// The listening channel of the peer device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Channel
        {
            get
            {
                return _peerChannel;
            }
        }

        /// <summary>
        /// The connected state of the peer device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsConnected
        {
            get
            {
                return _isPeerConnected;
            }
        }

        /// <summary>
        /// The P2P group state of the peer device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsGroupOwner
        {
            get
            {
                return _isPeerGroupOwner;
            }
        }

        /// <summary>
        /// The P2P state of the peer device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool P2PSupport
        {
            get
            {
                return _peerP2PSupport;
            }
        }

        /// <summary>
        /// The primary catagory of the peer device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectPrimaryDeviceType PrimaryType
        {
            get
            {
                return _peerPrimaryType;
            }
        }

        /// <summary>
        /// The sub category of the peer device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectSecondaryDeviceType SecondaryType
        {
            get
            {
                return _peerSecondaryType;
            }
        }

        /// <summary>
        /// The list of the supported WPS type of the peer device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int WpsTypes
        {
            get
            {
                return _peerWpsTypes;
            }
        }

        /// <summary>
        /// The P2P invitation state of the peer device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsP2PInvitationSupported
        {
            get
            {
                return _p2PInvitationSupported;
            }
        }

        /// <summary>
        /// The number of registered services of the peer device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint ServiceCount
        {
            get
            {
                return _peerServiceCount;
            }
        }

        /// <summary>
        /// The list of registered services of the peer device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public IEnumerable<string> ServiceList
        {
            get
            {
                return _peerServiceList;
            }
        }

        /// <summary>
        /// Checks if the peer device is a Wi-Fi display device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsMiracastDevice
        {
            get
            {
                return _isPeerMiracastDevice;
            }
        }

        /// <summary>
        /// The Wi-Fi display device type of the peer device.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If there is any error, a default value of WiFiDirectDisplayType will be returned.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectDisplayType Display
        {
            get
            {
                if (Globals.IsActivated)
                {
                    WiFiDirectDisplayType displayType;
                    int ret = Interop.WiFiDirect.GetDisplayType(_peerMacAddress, out displayType);
                    if (ret != (int)WiFiDirectError.None)
                    {
                        Log.Error(Globals.LogTag, "Failed to get the peer display type, Error - " + (WiFiDirectError)ret);
                    }

                    return displayType;
                }

                else
                {
                    return default(WiFiDirectDisplayType);
                }
            }
        }

        /// <summary>
        /// The Wi-Fi display session availability of the peer device.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If there is any error, false will be returned.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public bool DisplayAvailability
        {
            get
            {
                if (Globals.IsActivated)
                {
                    bool displayAvailability;
                    int ret = Interop.WiFiDirect.GetDisplayAvailability(_peerMacAddress, out displayAvailability);
                    if (ret != (int)WiFiDirectError.None)
                    {
                        Log.Error(Globals.LogTag, "Failed to get the peer display availability, Error - " + (WiFiDirectError)ret);
                    }

                    return displayAvailability;
                }

                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// The HDCP information of the peer device.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If there is any error, -1 will be returned.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public int Hdcp
        {
            get
            {
                if (Globals.IsActivated)
                {
                    int hdcpSupport;
                    int ret = Interop.WiFiDirect.GetDisplayHdcp(_peerMacAddress, out hdcpSupport);
                    if (ret != (int)WiFiDirectError.None)
                    {
                        Log.Error(Globals.LogTag, "Failed to get the peer display hdcp support, Error - " + (WiFiDirectError)ret);
                        return -1;
                    }

                    return hdcpSupport;
                }

                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// The port of the connected peer device.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If there is any error, -1 will be returned.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public int Port
        {
            get
            {
                if (Globals.IsActivated)
                {
                    int displayPort;
                    int ret = Interop.WiFiDirect.GetDisplayPort(_peerMacAddress, out displayPort);
                    if (ret != (int)WiFiDirectError.None)
                    {
                        Log.Error(Globals.LogTag, "Failed to get the peer display port, Error - " + (WiFiDirectError)ret);
                        return -1;
                    }

                    return displayPort;
                }

                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// The Wi-Fi display maximum throughput of the peer device.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If there is any error, -1 will be returned.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public int Throughput
        {
            get
            {
                if (Globals.IsActivated)
                {
                    int displayThroughput;
                    int ret = Interop.WiFiDirect.GetDisplayThroughput(_peerMacAddress, out displayThroughput);
                    if (ret != (int)WiFiDirectError.None)
                    {
                        Log.Error(Globals.LogTag, "Failed to get the peer display max throughput, Error - " + (WiFiDirectError)ret);
                        return -1;
                    }

                    return displayThroughput;
                }

                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// The Wi-Fi RSSI value of the peer device.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If there is any error, -1 will be returned.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public int Rssi
        {
            get
            {
                if (Globals.IsActivated)
                {
                    int rssi;
                    int ret = Interop.WiFiDirect.GetRssi(_peerMacAddress, out rssi);
                    if (ret != (int)WiFiDirectError.None)
                    {
                        Log.Error(Globals.LogTag, "Failed to get the peer RSSI, Error - " + (WiFiDirectError)ret);
                        return -1;
                    }

                    return rssi;
                }

                else
                {
                    return -1;
                }
            }
        }
        /// <summary>
        /// The ConnectionStateChanged event is raised when the connection state of the peer device changes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<ConnectionStateChangedEventArgs> ConnectionStateChanged
        {
            add
            {
                if (Globals.IsInitialize)
                {
                    if (_connectionStateChanged == null)
                    {
                        RegisterConnectionStateChangedEvent();
                    }

                    _connectionStateChanged += value;
                }
            }

            remove
            {
                if (Globals.IsInitialize)
                {
                    _connectionStateChanged -= value;
                    if (_connectionStateChanged == null)
                    {
                        UnregisterConnectionStateChangedEvent();
                    }
                }
            }
        }

        /// <summary>
        /// The IpAddressAssigned event is raised when the IP address of the peer device is assigned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<IpAddressAssignedEventArgs> IpAddressAssigned
        {
            add
            {
                if (Globals.IsInitialize)
                {
                    if (_ipAddressAssigned == null)
                    {
                        RegisterIpAddressAssignedEvent();
                    }

                    _ipAddressAssigned += value;
                }
            }

            remove
            {
                if (Globals.IsInitialize)
                {
                    _ipAddressAssigned -= value;
                    if (_ipAddressAssigned == null)
                    {
                        UnregisterIpAddressAssignedEvent();
                    }
                }
            }
        }

        /// <summary>
        /// The ServiceStateChanged event is raised when the state of service discovery is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<ServiceStateChangedEventArgs> ServiceStateChanged
        {
            add
            {
                if (Globals.IsInitialize)
                {
                    if (_serviceStateChanged == null)
                    {
                        RegisterServiceStateChangedEvent();
                    }

                    _serviceStateChanged += value;
                }
            }

            remove
            {
                if (Globals.IsInitialize)
                {
                    _serviceStateChanged -= value;
                    if (_serviceStateChanged == null)
                    {
                        UnregisterServiceStateChangedEvent();
                    }
                }
            }
        }

        private void RegisterConnectionStateChangedEvent()
        {
            _connectionStateChangedCallback = (int result, WiFiDirectConnectionState state, string address, IntPtr userData) =>
            {
                if (_connectionStateChanged != null)
                {
                    WiFiDirectError res = (WiFiDirectError)result;
                    _connectionStateChanged(null, new ConnectionStateChangedEventArgs(res, state, address));
                }
            };
            int ret = Interop.WiFiDirect.SetConnectionChangedCallback(_connectionStateChangedCallback, IntPtr.Zero);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set connection state changed callback, Error - " + (WiFiDirectError)ret);
            }
        }

        private void UnregisterConnectionStateChangedEvent()
        {
            int ret = Interop.WiFiDirect.UnsetConnectionChangedCallback();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset connection state changed callback, Error - " + (WiFiDirectError)ret);
            }
        }

        private void RegisterIpAddressAssignedEvent()
        {
            _ipAddressAssignedCallback = (string macAddress, string ipAddress, string interfaceAddress, IntPtr userData) =>
            {
                if (_ipAddressAssigned != null)
                {
                    _ipAddressAssigned(null, new IpAddressAssignedEventArgs(macAddress, ipAddress, interfaceAddress));
                }
            };
            int ret = Interop.WiFiDirect.SetIpAddressAssignedCallback(_ipAddressAssignedCallback, IntPtr.Zero);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set ip address assigned callback, Error - " + (WiFiDirectError)ret);
            }
        }

        private void UnregisterIpAddressAssignedEvent()
        {
            int ret = Interop.WiFiDirect.UnsetIpAddressAssignedCallback();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset ip address assigned callback, Error - " + (WiFiDirectError)ret);
            }
        }

        private void RegisterServiceStateChangedEvent()
        {
            _serviceStateChangedCallback = (int result, WiFiDirectServiceDiscoveryState stateInfo, WiFiDirectServiceType typeInfo, IntPtr responseData, string address, IntPtr userData) =>
            {
                if (_serviceStateChanged != null)
                {
                    WiFiDirectError error = (WiFiDirectError)result;
                    WiFiDirectServiceDiscoveryState state = stateInfo;
                    WiFiDirectServiceType type = typeInfo;
                    string response = Marshal.PtrToStringAnsi(responseData);
                    IntPtr peer;
                    Interop.WiFiDirect.GetDiscoveredPeerInfo(address, out peer);
                    DiscoveredPeerStruct peerStruct = (DiscoveredPeerStruct)Marshal.PtrToStructure(peer, typeof(DiscoveredPeerStruct));

                    _serviceStateChanged(null, new ServiceStateChangedEventArgs(error, state, type, response, WiFiDirectUtils.ConvertStructToDiscoveredPeer(peerStruct)));
                }
            };
            int ret = Interop.WiFiDirect.SetServiceStateChangedCallback(_serviceStateChangedCallback, IntPtr.Zero);
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set service state changed callback, Error - " + (WiFiDirectError)ret);
            }
        }

        private void UnregisterServiceStateChangedEvent()
        {
            int ret = Interop.WiFiDirect.UnsetServiceStateChangedCallback();
            if (ret != (int)WiFiDirectError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset service state changed callback, Error - " + (WiFiDirectError)ret);
            }
        }

        /// <summary>
        /// Connects to a specified remote device.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If this succeeds, the ConnectionStateChanged event will be invoked.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi Direct is not supported</exception>
        /// <since_tizen> 3 </since_tizen>
        public void Connect()
        {
            if (Globals.IsActivated)
            {
                int ret = Interop.WiFiDirect.Connect(_peerMacAddress);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to connect, Error - " + (WiFiDirectError)ret);
                    WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
                }
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Cancels the connection now in progress.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi Direct is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void CancelConnection()
        {
            if (Globals.IsActivated)
            {
                int ret = Interop.WiFiDirect.CancelConnection(_peerMacAddress);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to cancel the connection, Error - " + (WiFiDirectError)ret);
                    WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
                }
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Disconnects the specified remote device.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If this succeeds, the ConnectionStateChanged event will be invoked.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi Direct is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void Disconnect()
        {
            if (Globals.IsActivated)
            {
                int ret = Interop.WiFiDirect.Disconnect(_peerMacAddress);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to disconnect, Error - " + (WiFiDirectError)ret);
                    WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
                }
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Allows a device to connect automatically.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi Direct is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void SetAutoConnect()
        {
            if (Globals.IsActivated)
            {
                int ret = Interop.WiFiDirect.SetAutoConnectionPeer(_peerMacAddress);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set auto connection, Error - " + (WiFiDirectError)ret);
                    WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
                }
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Starts the Wi-Fi Direct service discovery.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If this succeeds, the ServiceStateChanged event will be invoked.
        /// </remarks>
        /// <exception cref="NotSupportedException">
        /// Thrown during one of the following cases:
        /// 1. When the Wi-Fi Direct is not supported.
        /// 2. When the Wi-Fi Direct service discovery is not supported.
        /// </exception>
        /// <param name="type">The type of the service.</param>
        /// <since_tizen> 3 </since_tizen>
        public void StartServiceDiscovery(WiFiDirectServiceType type)
        {
            if (Globals.IsActivated)
            {
                int ret = Interop.WiFiDirect.StartServiceDiscovery(_peerMacAddress, type);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to start Wi-Fi Direct service discovery, Error - " + (WiFiDirectError)ret);
                    WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
                }
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// Stops the Wi-Fi Direct service discovery.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// </remarks>
        /// <exception cref="NotSupportedException">
        /// Thrown during one of the following cases:
        /// 1. When the Wi-Fi Direct is not supported.
        /// 2. When the Wi-Fi Direct service discovery is not supported.
        /// </exception>
        /// <param name="type">The type of the service.</param>
        /// <since_tizen> 3 </since_tizen>
        public void CancelServiceDiscovery(WiFiDirectServiceType type)
        {
            if (Globals.IsActivated)
            {
                int ret = Interop.WiFiDirect.StopServiceDiscovery(_peerMacAddress, type);
                if (ret != (int)WiFiDirectError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to stop Wi-Fi Direct service discovery, Error - " + (WiFiDirectError)ret);
                    WiFiDirectErrorFactory.ThrowWiFiDirectException(ret);
                }
            }

            else
            {
                Log.Error(Globals.LogTag, "Wifi-direct is not activated");
                WiFiDirectErrorFactory.ThrowWiFiDirectException((int)WiFiDirectError.NotPermitted);
            }
        }

        /// <summary>
        /// The vendor specific information element (VSIE) of a peer.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If there is any error, null will be returned.
        /// </remarks>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Vsie
        {
            get
            {
                if (Globals.IsActivated)
                {
                    string vsie;
                    int ret = Interop.WiFiDirect.GetPeerVsie(_peerMacAddress, out vsie);

                    if (ret != (int)WiFiDirectError.None)
                    {
                        Log.Error(Globals.LogTag, "Failed to get the peer VSIE, Error - " + (WiFiDirectError)ret);
                        return null;
                    }

                    return vsie;
                }
                return null;
            }
        }
    }
}
