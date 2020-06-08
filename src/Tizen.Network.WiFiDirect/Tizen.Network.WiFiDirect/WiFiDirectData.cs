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
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;

using Tizen.Internals;

namespace Tizen.Network.WiFiDirect
{
    [NativeStruct("wifi_direct_discovered_peer_info_s", Include="wifi-direct.h", PkgConfig="capi-network-wifi-direct")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct DiscoveredPeerStruct
    {
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string _name;

        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string _macAddress;

        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string _interfaceAddress;

        internal int _channel;

        [MarshalAsAttribute(UnmanagedType.I1)]
        internal bool _isConnected;

        [MarshalAsAttribute(UnmanagedType.I1)]
        internal bool _isGroupOwner;

        internal WiFiDirectPrimaryDeviceType _primaryType;

        internal WiFiDirectSecondaryDeviceType _secondaryType;

        internal int _wpsTypes;

        [MarshalAsAttribute(UnmanagedType.I1)]
        internal bool _isP2PInvitationSupported;

        internal uint _serviceCount;

        internal IntPtr _serviceList;

        [MarshalAsAttribute(UnmanagedType.I1)]
        internal bool _isMiracast;
    }

    [NativeStruct("wifi_direct_connected_peer_info_s", Include="wifi-direct.h", PkgConfig="capi-network-wifi-direct")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct ConnectedPeerStruct
    {
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string _name;

        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string _ipAddress;

        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string _macAddress;

        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string _interfaceAddress;

        internal int _channel;

        [MarshalAsAttribute(UnmanagedType.I1)]
        internal bool _isP2PSupport;

        internal WiFiDirectPrimaryDeviceType _primaryType;

        internal WiFiDirectSecondaryDeviceType _secondaryType;

        internal uint _serviceCount;

        internal IntPtr _serviceList;

        [MarshalAsAttribute(UnmanagedType.I1)]
        internal bool _isMiracast;
    }

    internal static class WiFiDirectUtils
    {
        internal static WiFiDirectPeer ConvertStructToDiscoveredPeer(DiscoveredPeerStruct peer)
        {
            WiFiDirectPeer resultPeer = new WiFiDirectPeer();
            resultPeer._peerDeviceName = peer._name;
            resultPeer._peerMacAddress = peer._macAddress;
            resultPeer._peerInterfaceAddress = peer._interfaceAddress;
            resultPeer._peerChannel = peer._channel;
            resultPeer._isPeerConnected = peer._isConnected;
            resultPeer._isPeerGroupOwner = peer._isGroupOwner;
            resultPeer._peerPrimaryType = peer._primaryType;
            resultPeer._peerSecondaryType = peer._secondaryType;
            resultPeer._peerWpsTypes = peer._wpsTypes;
            resultPeer._p2PInvitationSupported = peer._isP2PInvitationSupported;
            Collection<string> uuidList = null;

            if (peer._serviceCount > 0)
            {
                IntPtr[] serviceList = new IntPtr[peer._serviceCount];
                Marshal.Copy(peer._serviceList, serviceList, 0, (int)peer._serviceCount);
                uuidList = new Collection<string>();
                foreach (IntPtr service in serviceList)
                {
                    string registeredService = Marshal.PtrToStringAnsi(service);
                    uuidList.Add(registeredService);
                }

                resultPeer._peerServiceCount = peer._serviceCount;
                resultPeer._peerServiceList = uuidList;
            }

            resultPeer._isPeerMiracastDevice = peer._isMiracast;
            return resultPeer;
        }

        internal static WiFiDirectPeer ConvertStructToConnectedPeer(ConnectedPeerStruct peer)
        {
            WiFiDirectPeer resultPeer = new WiFiDirectPeer();
            resultPeer._peerDeviceName = peer._name;
            resultPeer._peerIpAddress = peer._ipAddress;
            resultPeer._peerMacAddress = peer._macAddress;
            resultPeer._peerInterfaceAddress = peer._interfaceAddress;
            resultPeer._peerChannel = peer._channel;
            resultPeer._peerP2PSupport = peer._isP2PSupport;
            resultPeer._peerPrimaryType = peer._primaryType;
            resultPeer._peerSecondaryType = peer._secondaryType;
            Collection<string> uuidList = null;

            if (peer._serviceCount > 0)
            {
                IntPtr[] serviceList = new IntPtr[peer._serviceCount];
                Marshal.Copy(peer._serviceList, serviceList, 0, (int)peer._serviceCount);
                uuidList = new Collection<string>();
                foreach (IntPtr service in serviceList)
                {
                    string registeredService = Marshal.PtrToStringAnsi(service);
                    uuidList.Add(registeredService);
                }

                resultPeer._peerServiceCount = peer._serviceCount;
                resultPeer._peerServiceList = uuidList;
            }

            resultPeer._isPeerMiracastDevice = peer._isMiracast;
            return resultPeer;
        }
    }

}
