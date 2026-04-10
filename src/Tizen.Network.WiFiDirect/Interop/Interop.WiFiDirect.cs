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
using Tizen.Network.WiFiDirect;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

/// <summary>
/// The Interop class for Wi-Fi Direct.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// The Wi-Fi Direct native APIs.
    /// </summary>
    internal static partial class WiFiDirect
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DiscoveryStateChangedCallback(int result, WiFiDirectDiscoveryState state, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PeerFoundCallback(int result, WiFiDirectDiscoveryState state, string address, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DeviceStateChangedCallback(int result, WiFiDirectDeviceState state, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ConnectionStateChangedCallback(int result, WiFiDirectConnectionState state, string address, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ClientIpAddressAssignedCallback(string macAddress, string ipAddress, string interfaceAddress, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ServiceStateChangedCallback(int result, WiFiDirectServiceDiscoveryState state, WiFiDirectServiceType type, IntPtr responseData, string address, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void StateChangedCallback(WiFiDirectState state, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)] internal delegate bool DiscoveredPeerCallback(ref DiscoveredPeerStruct peer, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)] internal delegate bool ConnectedPeerCallback(ref ConnectedPeerStruct peer, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)] internal delegate bool WpsTypeCallback(WiFiDirectWpsType type, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)] internal delegate bool PersistentGroupCallback(string address, string ssid, IntPtr userData);

        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_state_changed_cb")]
        internal static partial int SetStateChangedCallback(StateChangedCallback stateChangedCb, IntPtr userData);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_unset_state_changed_cb")]
        internal static partial int UnsetStateChangedCallback();

        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_device_state_changed_cb")]
        internal static partial int SetDeviceStateChangedCallback(DeviceStateChangedCallback deviceChangedCb, IntPtr userData);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_unset_device_state_changed_cb")]
        internal static partial int UnsetDeviceStateChangedCallback();

        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_discovery_state_changed_cb")]
        internal static partial int SetDiscoveryStateChangedCallback(DiscoveryStateChangedCallback discoveryStateChangedCb, IntPtr userData);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_unset_discovery_state_changed_cb")]
        internal static partial int UnsetDiscoveryStateChangedCallback();

        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_peer_found_cb")]
        internal static partial int SetPeerFoundCallback(PeerFoundCallback peerFoundCb, IntPtr userData);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_unset_peer_found_cb")]
        internal static partial int UnsetPeerFoundCallback();

        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_connection_state_changed_cb")]
        internal static partial int SetConnectionChangedCallback(ConnectionStateChangedCallback connectionCb, IntPtr userData);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_unset_connection_state_changed_cb")]
        internal static partial int UnsetConnectionChangedCallback();

        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_client_ip_address_assigned_cb")]
        internal static partial int SetIpAddressAssignedCallback(ClientIpAddressAssignedCallback callback, IntPtr userData);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_unset_client_ip_address_assigned_cb")]
        internal static partial int UnsetIpAddressAssignedCallback();

        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_service_state_changed_cb")]
        internal static partial int SetServiceStateChangedCallback(ServiceStateChangedCallback serviceStateChangedCb, IntPtr userData);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_unset_service_state_changed_cb")]
        internal static partial int UnsetServiceStateChangedCallback();

        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_initialize")]
        internal static partial int Initialize();
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_deinitialize")]
        internal static partial int Deinitialize();
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_activate")]
        internal static partial int Activate();
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_deactivate")]
        internal static partial int Deactivate();
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_start_discovery_specific_channel")]
        internal static partial int StartDiscoveryInChannel([MarshalAs(UnmanagedType.U1)] bool listenOnly, int timeout, WiFiDirectDiscoveryChannel channel);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_cancel_discovery")]
        internal static partial int StopDiscovery();
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_foreach_discovered_peers")]
        internal static partial int GetDiscoveredPeers(DiscoveredPeerCallback callback, IntPtr userData);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_connect", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int Connect(string address);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_cancel_connection", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int CancelConnection(string address);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_disconnect_all")]
        internal static partial int DisconnectAll();
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_disconnect", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int Disconnect(string address);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_foreach_connected_peers")]
        internal static partial int GetConnectedPeers(ConnectedPeerCallback callback, IntPtr userData);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_create_group")]
        internal static partial int CreateGroup();
        [LibraryImport(Libraries.WiFiDirect, EntryPoint = "wifi_direct_create_group_with_ssid", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int CreateGroupWithSsid(string ssid);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_destroy_group")]
        internal static partial int DestroyGroup();
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_is_group_owner")]
        internal static partial int IsGroupOwner([MarshalAs(UnmanagedType.U1)] out bool isGroupOwner);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_is_autonomous_group")]
        internal static partial int IsAutonomousGroup([MarshalAs(UnmanagedType.U1)] out bool isAutonomous);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_device_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetName(string name);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_device_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetName(out string name);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_ssid", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetSsid(out string ssid);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_network_interface_name", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetInterfaceName(out string name);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_ip_address", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetIpAddress(out string address);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_subnet_mask", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetSubnetMask(out string mask);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_gateway_address", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetGatewayAddress(out string address);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_mac_address", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetMacAddress(out string address);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_state")]
        internal static partial int GetState(out WiFiDirectState state);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_is_discoverable")]
        internal static partial int IsDiscoverable([MarshalAs(UnmanagedType.U1)] out bool isDiscoverable);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_is_listening_only")]
        internal static partial int IsListeningOnly([MarshalAs(UnmanagedType.U1)] out bool listenOnly);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_primary_device_type")]
        internal static partial int GetPrimaryType(out WiFiDirectPrimaryDeviceType type);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_secondary_device_type")]
        internal static partial int GetSecondaryType(out WiFiDirectSecondaryDeviceType type);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_activate_pushbutton")]
        internal static partial int ActivatePushButton();
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_wps_pin", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetWpsPin(string pin);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_wps_pin", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetWpsPin(out string pin);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_supported_wps_mode")]
        internal static partial int GetWpsMode(out int mode);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_foreach_supported_wps_types")]
        internal static partial int GetWpsTypes(WpsTypeCallback callback, IntPtr userData);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_local_wps_type")]
        internal static partial int GetLocalWpsType(out WiFiDirectWpsType type);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_req_wps_type")]
        internal static partial int SetReqWpsType(WiFiDirectWpsType type);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_req_wps_type")]
        internal static partial int GetReqWpsType(out WiFiDirectWpsType type);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_group_owner_intent")]
        internal static partial int SetIntent(int intent);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_group_owner_intent")]
        internal static partial int GetIntent(out int intent);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_max_clients")]
        internal static partial int SetMaxClients(int max);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_max_clients")]
        internal static partial int GetMaxClients(out int max);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_passphrase", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetPassPhrase(string passphrase);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_passphrase", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetPassPhrase(out string passphrase);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_operating_channel")]
        internal static partial int GetChannel(out int channel);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_autoconnection_mode")]
        internal static partial int SetAutoConnectionMode([MarshalAs(UnmanagedType.U1)] bool mode);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_is_autoconnection_mode")]
        internal static partial int GetAutoConnectionMode([MarshalAs(UnmanagedType.U1)] out bool mode);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_autoconnection_peer", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SetAutoConnectionPeer(string address);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_persistent_group_enabled")]
        internal static partial int SetPersistentGroupState([MarshalAs(UnmanagedType.U1)] bool enabled);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_is_persistent_group_enabled")]
        internal static partial int GetPersistentGroupState([MarshalAs(UnmanagedType.U1)] out bool enabled);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_foreach_persistent_groups")]
        internal static partial int GetPersistentGroups(PersistentGroupCallback callback, IntPtr userData);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_remove_persistent_group", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RemovePersistentGroup(string address, string ssid);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_start_service_discovery", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int StartServiceDiscovery(string address, WiFiDirectServiceType type);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_cancel_service_discovery", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int StopServiceDiscovery(string address, WiFiDirectServiceType type);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_register_service", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RegisterService(WiFiDirectServiceType type, string info1, string info2, out uint serviceId);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_deregister_service")]
        internal static partial int DeregisterService(uint serviceId);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_init_miracast")]
        internal static partial int InitMiracast([MarshalAs(UnmanagedType.U1)] bool enable);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_peer_info", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetDiscoveredPeerInfo(string address, out IntPtr peer);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_init_display")]
        internal static partial int InitDisplay();
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_deinit_display")]
        internal static partial int DeinitDisplay();
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_display")]
        internal static partial int SetDisplay(WiFiDirectDisplayType type, int port, int hdcp);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_display_availability")]
        internal static partial int SetDisplayAvailability([MarshalAs(UnmanagedType.U1)] bool availability);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_peer_display_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetDisplayType(string address, out WiFiDirectDisplayType type);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_peer_display_availability", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetDisplayAvailability(string address, [MarshalAs(UnmanagedType.U1)] out bool availability);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_peer_display_hdcp", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetDisplayHdcp(string address, out int hdcp);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_peer_display_port", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetDisplayPort(string address, out int port);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_peer_display_throughput", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetDisplayThroughput(string address, out int throughput);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_peer_rssi", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetRssi(string address, out int rssi);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_session_timer")]
        internal static partial int GetSessionTimer(out int seconds);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_session_timer")]
        internal static partial int SetSessionTimer(int seconds);
        [LibraryImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_auto_group_removal")]
        internal static partial int SetAutoGroupRemoval([MarshalAs(UnmanagedType.U1)] bool enable);
        [LibraryImport(Libraries.WiFiDirect, EntryPoint = "wifi_direct_add_vsie", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int AddVsie(WiFiDirectVsieFrameType frameType, string vsie);
        [LibraryImport(Libraries.WiFiDirect, EntryPoint = "wifi_direct_get_vsie", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetVsie(WiFiDirectVsieFrameType frameType, out string vsie);
        [LibraryImport(Libraries.WiFiDirect, EntryPoint = "wifi_direct_remove_vsie", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RemoveVsie(WiFiDirectVsieFrameType frameType, string vsie);
        [LibraryImport(Libraries.WiFiDirect, EntryPoint = "wifi_direct_get_connecting_peer_info")]
        internal static partial int GetConnectingPeerInfo(out IntPtr peer);
        [LibraryImport(Libraries.WiFiDirect, EntryPoint = "wifi_direct_get_peer_vsie", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int GetPeerVsie(string macAddress, out string vsie);
        [LibraryImport(Libraries.WiFiDirect, EntryPoint = "wifi_direct_accept_connection", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int AcceptConnection(string macAddress);
        [LibraryImport(Libraries.WiFiDirect, EntryPoint = "wifi_direct_reject_connection", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RejectConnection(string macAddress);
    }
}




