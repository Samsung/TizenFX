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

namespace Tizen.Network.WiFiDirect
{
    /// <summary>
    /// WiFiDirectPeer class is used to handle the connection with remote devices using WiFi Direct.
    /// </summary>
    /// <privilege> http://tizen.org/privilege/wifidirect </privilege>
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
        /// Name of Peer device.
        /// </summary>
        public string Name
        {
            get
            {
                return _peerDeviceName;
            }
        }

        /// <summary>
        /// Ip address of the peer device.
        /// </summary>
        public string IpAddress
        {
            get
            {
                return _peerIpAddress;
            }
        }

        /// <summary>
        /// Mac address of the peer device.
        /// </summary>
        public string MacAddress
        {
            get
            {
                return _peerMacAddress;
            }
        }

        /// <summary>
        /// Interface address of the peer device.
        /// </summary>
        public string InterfaceAddress
        {
            get
            {
                return _peerInterfaceAddress;
            }
        }

        /// <summary>
        /// Listening channel of the peer device.
        /// </summary>
        public int Channel
        {
            get
            {
                return _peerChannel;
            }
        }

        /// <summary>
        /// Connected state of the peer device.
        /// </summary>
        public bool IsConnected
        {
            get
            {
                return _isPeerConnected;
            }
        }

        /// <summary>
        /// P2P group state of the peer device.
        /// </summary>
        public bool IsGroupOwner
        {
            get
            {
                return _isPeerGroupOwner;
            }
        }

        /// <summary>
        /// P2P state of the peer device.
        /// </summary>
        public bool P2PSupport
        {
            get
            {
                return _peerP2PSupport;
            }
        }

        /// <summary>
        /// Primary catagory of the peer device.
        /// </summary>
        public WiFiDirectPrimaryDeviceType PrimaryType
        {
            get
            {
                return _peerPrimaryType;
            }
        }

        /// <summary>
        /// Sub category of the peer device.
        /// </summary>
        public WiFiDirectSecondaryDeviceType SecondaryType
        {
            get
            {
                return _peerSecondaryType;
            }
        }

        /// <summary>
        /// List of supported WPS type of the peer device.
        /// </summary>
        public int WpsTypes
        {
            get
            {
                return _peerWpsTypes;
            }
        }

        /// <summary>
        /// P2P invitation state of the peer device.
        /// </summary>
        public bool IsP2PInvitationSupported
        {
            get
            {
                return _p2PInvitationSupported;
            }
        }

        /// <summary>
        /// Number of registered services of the peer device.
        /// </summary>
        public uint ServiceCount
        {
            get
            {
                return _peerServiceCount;
            }
        }

        /// <summary>
        /// List of registered services of the peer device.
        /// </summary>
        public IEnumerable<string> ServiceList
        {
            get
            {
                return _peerServiceList;
            }
        }

        /// <summary>
        /// Checks if peer device is a wifi display device.
        /// </summary>
        public bool IsMiracastDevice
        {
            get
            {
                return _isPeerMiracastDevice;
            }
        }

        /// <summary>
        /// Wi-Fi Display device type of the peer device.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If there is any error, default value of WiFiDirectDisplayType will be returned.
        /// </remarks>
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
        /// Wi-Fi Display Session Availability of the peer device.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If there is any error, false will be returned.
        /// </remarks>
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
        /// Hdcp information of the peer device.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If there is any error, -1 will be returned.
        /// </remarks>
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
        /// Port of the connected peer device.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If there is any error, -1 will be returned.
        /// </remarks>
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
        /// WiFi Display max throughput of the peer device.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If there is any error, -1 will be returned.
        /// </remarks>
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
        /// WiFi RSSI value of the peer device.
        /// </summary>
        /// <remarks>
        /// Wi-Fi Direct must be activated.
        /// If there is any error, -1 will be returned.
        /// </remarks>
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
        /// (event) ConnectionStateChanged event is raised when the connection state of the peer device changes.
        /// </summary>
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
        /// (event) IpAddressAssigned event is raised when ip address of the peer device is assigned.
        /// </summary>
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
        /// (event) ServiceStateChanged is raised when state of service discovery is changed.
        /// </summary>
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
        /// If this succeeds, ConnectionStateChanged event will be invoked.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the wifidirect is not supported</exception>
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
        /// <exception cref="NotSupportedException">Thrown when the wifidirect is not supported</exception>
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
        /// If this succeeds, ConnectionStateChanged event will be invoked.
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the wifidirect is not supported</exception>
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
        /// <exception cref="NotSupportedException">Thrown when the wifidirect is not supported</exception>
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
        /// If this succeeds, ServiceStateChanged event will be invoked.
        /// </remarks>
        /// <exception cref="NotSupportedException">
        /// Thrown during one of the following cases :
        /// 1. When the wifidirect is not supported
        /// 2. When the wifidirect service discovery is not supported
        /// </exception>
        /// <param name="type">Type of service.</param>
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
        /// Thrown during one of the following cases :
        /// 1. When the wifidirect is not supported
        /// 2. When the wifidirect service discovery is not supported
        /// </exception>
        /// <param name="type">Type of service.</param>
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
    }
}
