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
        internal delegate bool DiscoveredPeerCallback(ref DiscoveredPeerStruct peer, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ConnectedPeerCallback(ref ConnectedPeerStruct peer, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool WpsTypeCallback(WiFiDirectWpsType type, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PersistentGroupCallback(string address, string ssid, IntPtr userData);

        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_state_changed_cb")]
        internal static extern int SetStateChangedCallback(StateChangedCallback stateChangedCb, IntPtr userData);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_unset_state_changed_cb")]
        internal static extern int UnsetStateChangedCallback();

        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_device_state_changed_cb")]
        internal static extern int SetDeviceStateChangedCallback(DeviceStateChangedCallback deviceChangedCb, IntPtr userData);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_unset_device_state_changed_cb")]
        internal static extern int UnsetDeviceStateChangedCallback();

        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_discovery_state_changed_cb")]
        internal static extern int SetDiscoveryStateChangedCallback(DiscoveryStateChangedCallback discoveryStateChangedCb, IntPtr userData);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_unset_discovery_state_changed_cb")]
        internal static extern int UnsetDiscoveryStateChangedCallback();

        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_peer_found_cb")]
        internal static extern int SetPeerFoundCallback(PeerFoundCallback peerFoundCb, IntPtr userData);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_unset_peer_found_cb")]
        internal static extern int UnsetPeerFoundCallback();

        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_connection_state_changed_cb")]
        internal static extern int SetConnectionChangedCallback(ConnectionStateChangedCallback connectionCb, IntPtr userData);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_unset_connection_state_changed_cb")]
        internal static extern int UnsetConnectionChangedCallback();

        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_client_ip_address_assigned_cb")]
        internal static extern int SetIpAddressAssignedCallback(ClientIpAddressAssignedCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_unset_client_ip_address_assigned_cb")]
        internal static extern int UnsetIpAddressAssignedCallback();

        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_service_state_changed_cb")]
        internal static extern int SetServiceStateChangedCallback(ServiceStateChangedCallback serviceStateChangedCb, IntPtr userData);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_unset_service_state_changed_cb")]
        internal static extern int UnsetServiceStateChangedCallback();

        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_initialize")]
        internal static extern int Initialize();
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_deinitialize")]
        internal static extern int Deinitialize();
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_activate")]
        internal static extern int Activate();
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_deactivate")]
        internal static extern int Deactivate();
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_start_discovery_specific_channel")]
        internal static extern int StartDiscoveryInChannel(bool listenOnly, int timeout, WiFiDirectDiscoveryChannel channel);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_cancel_discovery")]
        internal static extern int StopDiscovery();
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_foreach_discovered_peers")]
        internal static extern int GetDiscoveredPeers(DiscoveredPeerCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_connect")]
        internal static extern int Connect(string address);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_cancel_connection")]
        internal static extern int CancelConnection(string address);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_disconnect_all")]
        internal static extern int DisconnectAll();
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_disconnect")]
        internal static extern int Disconnect(string address);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_foreach_connected_peers")]
        internal static extern int GetConnectedPeers(ConnectedPeerCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_create_group")]
        internal static extern int CreateGroup();
        [DllImport(Libraries.WiFiDirect, EntryPoint = "wifi_direct_create_group_with_ssid")]
        internal static extern int CreateGroupWithSsid(string ssid);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_destroy_group")]
        internal static extern int DestroyGroup();
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_is_group_owner")]
        internal static extern int IsGroupOwner(out bool isGroupOwner);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_is_autonomous_group")]
        internal static extern int IsAutonomousGroup(out bool isAutonomous);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_device_name")]
        internal static extern int SetName(string name);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_device_name")]
        internal static extern int GetName(out string name);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_ssid")]
        internal static extern int GetSsid(out string ssid);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_network_interface_name")]
        internal static extern int GetInterfaceName(out string name);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_ip_address")]
        internal static extern int GetIpAddress(out string address);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_subnet_mask")]
        internal static extern int GetSubnetMask(out string mask);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_gateway_address")]
        internal static extern int GetGatewayAddress(out string address);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_mac_address")]
        internal static extern int GetMacAddress(out string address);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_state")]
        internal static extern int GetState(out WiFiDirectState state);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_is_discoverable")]
        internal static extern int IsDiscoverable(out bool isDiscoverable);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_is_listening_only")]
        internal static extern int IsListeningOnly(out bool listenOnly);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_primary_device_type")]
        internal static extern int GetPrimaryType(out WiFiDirectPrimaryDeviceType type);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_secondary_device_type")]
        internal static extern int GetSecondaryType(out WiFiDirectSecondaryDeviceType type);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_activate_pushbutton")]
        internal static extern int ActivatePushButton();
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_wps_pin")]
        internal static extern int SetWpsPin(string pin);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_wps_pin")]
        internal static extern int GetWpsPin(out string pin);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_supported_wps_mode")]
        internal static extern int GetWpsMode(out int mode);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_foreach_supported_wps_types")]
        internal static extern int GetWpsTypes(WpsTypeCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_local_wps_type")]
        internal static extern int GetLocalWpsType(out WiFiDirectWpsType type);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_req_wps_type")]
        internal static extern int SetReqWpsType(WiFiDirectWpsType type);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_req_wps_type")]
        internal static extern int GetReqWpsType(out WiFiDirectWpsType type);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_group_owner_intent")]
        internal static extern int SetIntent(int intent);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_group_owner_intent")]
        internal static extern int GetIntent(out int intent);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_max_clients")]
        internal static extern int SetMaxClients(int max);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_max_clients")]
        internal static extern int GetMaxClients(out int max);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_passphrase")]
        internal static extern int SetPassPhrase(string passphrase);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_passphrase")]
        internal static extern int GetPassPhrase(out string passphrase);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_operating_channel")]
        internal static extern int GetChannel(out int channel);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_autoconnection_mode")]
        internal static extern int SetAutoConnectionMode(bool mode);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_is_autoconnection_mode")]
        internal static extern int GetAutoConnectionMode(out bool mode);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_autoconnection_peer")]
        internal static extern int SetAutoConnectionPeer(string address);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_persistent_group_enabled")]
        internal static extern int SetPersistentGroupState(bool enabled);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_is_persistent_group_enabled")]
        internal static extern int GetPersistentGroupState(out bool enabled);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_foreach_persistent_groups")]
        internal static extern int GetPersistentGroups(PersistentGroupCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_remove_persistent_group")]
        internal static extern int RemovePersistentGroup(string address, string ssid);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_start_service_discovery")]
        internal static extern int StartServiceDiscovery(string address, WiFiDirectServiceType type);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_cancel_service_discovery")]
        internal static extern int StopServiceDiscovery(string address, WiFiDirectServiceType type);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_register_service")]
        internal static extern int RegisterService(WiFiDirectServiceType type, string info1, string info2, out uint serviceId);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_deregister_service")]
        internal static extern int DeregisterService(uint serviceId);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_init_miracast")]
        internal static extern int InitMiracast(bool enable);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_peer_info")]
        internal static extern int GetDiscoveredPeerInfo(string address, out IntPtr peer);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_init_display")]
        internal static extern int InitDisplay();
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_deinit_display")]
        internal static extern int DeinitDisplay();
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_display")]
        internal static extern int SetDisplay(WiFiDirectDisplayType type, int port, int hdcp);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_display_availability")]
        internal static extern int SetDisplayAvailability(bool availability);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_peer_display_type")]
        internal static extern int GetDisplayType(string address, out WiFiDirectDisplayType type);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_peer_display_availability")]
        internal static extern int GetDisplayAvailability(string address, out bool availability);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_peer_display_hdcp")]
        internal static extern int GetDisplayHdcp(string address, out int hdcp);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_peer_display_port")]
        internal static extern int GetDisplayPort(string address, out int port);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_peer_display_throughput")]
        internal static extern int GetDisplayThroughput(string address, out int throughput);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_peer_rssi")]
        internal static extern int GetRssi(string address, out int rssi);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_get_session_timer")]
        internal static extern int GetSessionTimer(out int seconds);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_session_timer")]
        internal static extern int SetSessionTimer(int seconds);
        [DllImport(Libraries.WiFiDirect,EntryPoint = "wifi_direct_set_auto_group_removal")]
        internal static extern int SetAutoGroupRemoval(bool enable);
        [DllImport(Libraries.WiFiDirect, EntryPoint = "wifi_direct_add_vsie")]
        internal static extern int AddVsie(WiFiDirectVsieFrame frameId, string vsie);
        [DllImport(Libraries.WiFiDirect, EntryPoint = "wifi_direct_get_vsie")]
        internal static extern int GetVsie(WiFiDirectVsieFrame frameId, out string vsie);
        [DllImport(Libraries.WiFiDirect, EntryPoint = "wifi_direct_remove_vsie")]
        internal static extern int RemoveVsie(WiFiDirectVsieFrame frameId, string vsie);
        [DllImport(Libraries.WiFiDirect, EntryPoint = "wifi_direct_get_connecting_peer_info")]
        internal static extern int GetConnectingPeerInfo(out IntPtr peer);
        [DllImport(Libraries.WiFiDirect, EntryPoint = "wifi_direct_get_peer_vsie")]
        internal static extern int GetPeerVsie(string macAddress, out string vsie);
        [DllImport(Libraries.WiFiDirect, EntryPoint = "wifi_direct_accept_connection")]
        internal static extern int AcceptConnection(string macAddress);
        [DllImport(Libraries.WiFiDirect, EntryPoint = "wifi_direct_reject_connection")]
        internal static extern int RejectConnection(string macAddress);
    }
}
