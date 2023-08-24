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
using Tizen.Network.Connection;

internal static partial class Interop
{
    internal static partial class Connection
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ConnectionTypeChangedCallback(ConnectionType type, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void EthernetCableStateChangedCallback(EthernetCableState state, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ConnectionAddressChangedCallback(IntPtr ipv4, IntPtr ipv6, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ConnectionCallback(ConnectionError result, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool IPv6AddressCallback(IntPtr ipv6, IntPtr userData);

        [DllImport(Libraries.Connection, EntryPoint = "connection_create")]
        public static extern int Create(out IntPtr handle);

        [DllImport(Libraries.Connection, EntryPoint = "connection_destroy")]
        public static extern int Destroy(IntPtr handle);

        [DllImport(Libraries.Connection, EntryPoint = "connection_get_type")]
        public static extern int GetType(IntPtr handle, out int type);

        [DllImport(Libraries.Connection, EntryPoint = "connection_get_ip_address")]
        public static extern int GetIPAddress(IntPtr handle, int family, out IntPtr address);

        [DllImport(Libraries.Connection, EntryPoint = "connection_foreach_ipv6_address")]
        public static extern int GetAllIPv6Addresses(IntPtr handle, int type, IPv6AddressCallback callback, IntPtr userData);

        [DllImport(Libraries.Connection, EntryPoint = "connection_get_proxy")]
        public static extern int GetProxy(IntPtr handle, int family, out IntPtr address);

        [DllImport(Libraries.Connection, EntryPoint = "connection_get_mac_address")]
        public static extern int GetMacAddress(IntPtr handle, int family, out IntPtr address);

        [DllImport(Libraries.Connection, EntryPoint = "connection_get_wifi_state")]
        public static extern int GetWiFiState(IntPtr handle, out int state);

        [DllImport(Libraries.Connection, EntryPoint = "connection_get_cellular_state")]
        public static extern int GetCellularState(IntPtr handle, out int state);

        [DllImport(Libraries.Connection, EntryPoint = "connection_get_ethernet_state")]
        public static extern int GetEthernetState(IntPtr handle, out int state);

        [DllImport(Libraries.Connection, EntryPoint = "connection_get_ethernet_cable_state")]
        public static extern int GetEthernetCableState(IntPtr handle, out int state);

        [DllImport(Libraries.Connection, EntryPoint = "connection_get_bt_state")]
        public static extern int GetBtState(IntPtr handle, out int state);

        [DllImport(Libraries.Connection, EntryPoint = "connection_get_statistics")]
        public static extern int GetStatistics(IntPtr handle, int connectionType, int statisticsType, out long size);

        [DllImport(Libraries.Connection, EntryPoint = "connection_reset_statistics")]
        public static extern int ResetStatistics(IntPtr handle, int connectionType, int statisticsType);

        [DllImport(Libraries.Connection, EntryPoint = "connection_add_route_entry")]
        public static extern int AddRoute(IntPtr handle, AddressFamily family, string interfaceName, string address, string gateway);

        [DllImport(Libraries.Connection, EntryPoint = "connection_remove_route_entry")]
        public static extern int RemoveRoute(IntPtr handle, AddressFamily family, string interfaceName, string address, string gateway);

        [DllImport(Libraries.Connection, EntryPoint = "connection_set_type_changed_cb")]
        public static extern int SetTypeChangedCallback(IntPtr handle, ConnectionTypeChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Connection, EntryPoint = "connection_set_ip_address_changed_cb")]
        public static extern int SetIPAddressChangedCallback(IntPtr handle, ConnectionAddressChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Connection, EntryPoint = "connection_set_ethernet_cable_state_changed_cb")]
        public static extern int SetEthernetCableStateChagedCallback(IntPtr handle, EthernetCableStateChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Connection, EntryPoint = "connection_set_proxy_address_changed_cb")]
        public static extern int SetProxyAddressChangedCallback(IntPtr handle, ConnectionAddressChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Connection, EntryPoint = "connection_unset_type_changed_cb")]
        public static extern int UnsetTypeChangedCallback(IntPtr handle);

        [DllImport(Libraries.Connection, EntryPoint = "connection_unset_ip_address_changed_cb")]
        public static extern int UnsetIPAddressChangedCallback(IntPtr handle);

        [DllImport(Libraries.Connection, EntryPoint = "connection_unset_ethernet_cable_state_changed_cb")]
        public static extern int UnsetEthernetCableStateChagedCallback(IntPtr handle);

        [DllImport(Libraries.Connection, EntryPoint = "connection_unset_proxy_address_changed_cb")]
        public static extern int UnsetProxyAddressChangedCallback(IntPtr handle);

        [DllImport(Libraries.Connection, EntryPoint = "connection_add_profile")]
        public static extern int AddProfile(IntPtr handle, IntPtr profileHandle);

        [DllImport(Libraries.Connection, EntryPoint = "connection_remove_profile")]
        public static extern int RemoveProfile(IntPtr handle, IntPtr profileHandle);

        [DllImport(Libraries.Connection, EntryPoint = "connection_update_profile")]
        public static extern int UpdateProfile(IntPtr handle, IntPtr profileHandle);

        [DllImport(Libraries.Connection, EntryPoint = "connection_get_default_cellular_service_profile")]
        public static extern int GetDefaultCellularServiceProfile(IntPtr handle, int type, out IntPtr profileHandle);

        [DllImport(Libraries.Connection, EntryPoint = "connection_get_current_profile")]
        public static extern int GetCurrentProfile(IntPtr handle, out IntPtr profileHandle);

        [DllImport(Libraries.Connection, EntryPoint = "connection_open_profile")]
        public static extern int OpenProfile(IntPtr handle, IntPtr profileHandle, ConnectionCallback callback, IntPtr userData);

        [DllImport(Libraries.Connection, EntryPoint = "connection_close_profile")]
        public static extern int CloseProfile(IntPtr handle, IntPtr profileHandle, ConnectionCallback callback, IntPtr userData);

        [DllImport(Libraries.Connection, EntryPoint = "connection_reset_profile")]
        public static extern int ResetProfile(IntPtr handle, int Option, int Id, ConnectionCallback callback, IntPtr userData);

        [DllImport(Libraries.Connection, EntryPoint = "connection_set_default_cellular_service_profile_async")]
        public static extern int SetDefaultCellularServiceProfileAsync(IntPtr handle, int Type, IntPtr profileHandle, ConnectionCallback callback, IntPtr userData);

        [DllImport(Libraries.Connection, EntryPoint = "connection_get_profile_iterator")]
        public static extern int GetProfileIterator(IntPtr handle, int type, out IntPtr iterHandle);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_iterator_next")]
        public static extern int GetNextProfileIterator(IntPtr iterHandle, out IntPtr profileHandle);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_iterator_has_next")]
        public static extern bool HasNextProfileIterator(IntPtr iterHandle);

        [DllImport(Libraries.Connection, EntryPoint = "connection_destroy_profile_iterator")]
        public static extern int DestroyProfileIterator(IntPtr iterHandle);
    }

    internal static partial class ConnectionProfile
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ProfileStateChangedCallback(ProfileState type, IntPtr userData);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_create")]
        public static extern int Create(int ProfileType, string Keyword, out IntPtr profileHandle);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_clone")]
        public static extern int Clone(out IntPtr cloneHandle, IntPtr profileHandle);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_destroy")]
        public static extern int Destroy(IntPtr profileHandle);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_id")]
        public static extern int GetId(IntPtr profileHandle, out IntPtr profileId);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_name")]
        public static extern int GetName(IntPtr profileHandle, out IntPtr name);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_type")]
        public static extern int GetType(IntPtr profileHandle, out int type);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_network_interface_name")]
        public static extern int GetNetworkInterfaceName(IntPtr profileHandle, out IntPtr interfaceName);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_state")]
        public static extern int GetState(IntPtr profileHandle, out int type);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_ipv6_state")]
        public static extern int GetIPv6State(IntPtr profileHandle, out int type);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_ip_config_type")]
        public static extern int GetIPConfigType(IntPtr profileHandle, int family, out int type);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_proxy_type")]
        public static extern int GetProxyType(IntPtr profileHandle, out int type);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_ip_address")]
        public static extern int GetIPAddress(IntPtr profileHandle, int family, out IntPtr address);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_subnet_mask")]
        public static extern int GetSubnetMask(IntPtr profileHandle, int family, out IntPtr address);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_gateway_address")]
        public static extern int GetGatewayAddress(IntPtr profileHandle, int family, out IntPtr address);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_dns_address")]
        public static extern int GetDnsAddress(IntPtr profileHandle, int order, int Family, out IntPtr address);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_proxy_address")]
        public static extern int GetProxyAddress(IntPtr profileHandle, int family, out IntPtr address);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_prefix_length")]
        public static extern int GetPrefixLength(IntPtr profileHandle, int family, out int length);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_dns_config_type")]
        public static extern int GetDnsConfigType(IntPtr profileHandle, int family, out int type);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_dhcp_server_address")]
        public static extern int GetDhcpServerAddress(IntPtr profileHandle, AddressFamily family, out string dhcpServerAddress);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_dhcp_lease_duration")]
        public static extern int GetDhcpLeaseDuration(IntPtr profileHandle, AddressFamily family, out int dhcpLeaseDuration);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_refresh")]
        public static extern int Refresh(IntPtr profileHandle);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_set_ip_config_type")]
        public static extern int SetIPConfigType(IntPtr profileHandle, int family, int type);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_set_proxy_type")]
        public static extern int SetProxyType(IntPtr profileHandle, int type);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_set_ip_address")]
        public static extern int SetIPAddress(IntPtr profileHandle, int family, string address);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_set_subnet_mask")]
        public static extern int SetSubnetMask(IntPtr profileHandle, int family, string address);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_set_gateway_address")]
        public static extern int SetGatewayAddress(IntPtr profileHandle, int family, string address);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_set_dns_address")]
        public static extern int SetDnsAddress(IntPtr profileHandle, int order, int family, string address);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_set_proxy_address")]
        public static extern int SetProxyAddress(IntPtr profileHandle, int family, string address);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_set_prefix_length")]
        public static extern int SetPrefixLength(IntPtr profileHandle, int family, int length);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_set_dns_config_type")]
        public static extern int SetDnsConfigType(IntPtr profileHandle, int family, int type);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_set_state_changed_cb")]
        public static extern int SetStateChangeCallback(IntPtr profileHandle, ProfileStateChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_unset_state_changed_cb")]
        public static extern int UnsetStateChangeCallback(IntPtr profileHandle);
    }

    internal static partial class ConnectionCellularProfile
    {
        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_cellular_service_type")]
        public static extern int GetServiceType(IntPtr profileHandle, out int type);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_cellular_apn")]
        public static extern int GetApn(IntPtr profileHandle, out IntPtr apn);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_cellular_auth_info")]
        public static extern int GetAuthInfo(IntPtr profileHandle, out int authType, out string name, out string password);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_cellular_home_url")]
        public static extern int GetHomeUrl(IntPtr profileHandle, out IntPtr homeUrl);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_cellular_pdn_type")]
        public static extern int GetPdnType(IntPtr profileHandle, out int pdnType);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_cellular_roam_pdn_type")]
        public static extern int GetRoamingPdnType(IntPtr profileHandle, out int roamPdnType);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_is_cellular_roaming")]
        public static extern int IsRoaming(IntPtr profileHandle, out bool roaming);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_is_cellular_hidden")]
        public static extern int IsHidden(IntPtr profileHandle, out bool hidden);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_is_cellular_editable")]
        public static extern int IsEditable(IntPtr profileHandle, out bool editable);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_is_cellular_default")]
        public static extern int IsDefault(IntPtr profileHandle, out bool isDefault);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_set_cellular_service_type")]
        public static extern int SetServiceType(IntPtr profileHandle, int type);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_set_cellular_apn")]
        public static extern int SetApn(IntPtr profileHandle, string apn);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_set_cellular_auth_info")]
        public static extern int SetAuthInfo(IntPtr profileHandle, int authType, string name, string password);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_set_cellular_home_url")]
        public static extern int SetHomeUrl(IntPtr profileHandle, string homeUrl);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_set_cellular_pdn_type")]
        public static extern int SetPdnType(IntPtr profileHandle, int pdnType);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_set_cellular_roam_pdn_type")]
        public static extern int SetRoamingPdnType(IntPtr profileHandle, int roamPdnType);
    }

    internal static partial class ConnectionWiFiProfile
    {
        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_wifi_essid")]
        public static extern int GetEssid(IntPtr profileHandle, out IntPtr essid);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_wifi_bssid")]
        public static extern int GetBssid(IntPtr profileHandle, out IntPtr bssid);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_wifi_rssi")]
        public static extern int GetRssi(IntPtr profileHandle, out int rssi);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_wifi_frequency")]
        public static extern int GetFrequency(IntPtr profileHandle, out int frequency);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_wifi_max_speed")]
        public static extern int GetMaxSpeed(IntPtr profileHandle, out int maxSpeed);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_wifi_security_type")]
        public static extern int GetSecurityType(IntPtr profileHandle, out int type);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_get_wifi_encryption_type")]
        public static extern int GetEncryptionType(IntPtr profileHandle, out int type);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_is_wifi_passphrase_required")]
        public static extern int IsRequiredPassphrase(IntPtr profileHandle, out bool required);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_set_wifi_passphrase")]
        public static extern int SetPassphrase(IntPtr profileHandle, string passphrase);

        [DllImport(Libraries.Connection, EntryPoint = "connection_profile_is_wifi_wps_supported")]
        public static extern int IsSupportedWps(IntPtr profileHandle, out bool supported);
    }
	
    internal static partial class Libc
    {
        [DllImport(Libraries.Libc, EntryPoint = "free")]
        public static extern void Free(IntPtr userData);

    }
}
