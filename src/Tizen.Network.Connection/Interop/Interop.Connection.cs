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
using System.Runtime.InteropServices.Marshalling;
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
        [return: MarshalAs(UnmanagedType.U1)] public delegate bool IPv6AddressCallback(IntPtr ipv6, IntPtr userData);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_create")]
        public static partial int Create(out IntPtr handle);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_destroy")]
        public static partial int Destroy(IntPtr handle);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_get_type")]
        public static partial int GetType(IntPtr handle, out int type);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_get_ip_address")]
        public static partial int GetIPAddress(IntPtr handle, int family, out IntPtr address);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_foreach_ipv6_address")]
        public static partial int GetAllIPv6Addresses(IntPtr handle, int type, IPv6AddressCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_get_proxy")]
        public static partial int GetProxy(IntPtr handle, int family, out IntPtr address);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_get_mac_address")]
        public static partial int GetMacAddress(IntPtr handle, int family, out IntPtr address);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_get_wifi_state")]
        public static partial int GetWiFiState(IntPtr handle, out int state);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_get_cellular_state")]
        public static partial int GetCellularState(IntPtr handle, out int state);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_get_ethernet_state")]
        public static partial int GetEthernetState(IntPtr handle, out int state);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_get_ethernet_cable_state")]
        public static partial int GetEthernetCableState(IntPtr handle, out int state);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_get_bt_state")]
        public static partial int GetBtState(IntPtr handle, out int state);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_get_statistics")]
        public static partial int GetStatistics(IntPtr handle, int connectionType, int statisticsType, out long size);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_reset_statistics")]
        public static partial int ResetStatistics(IntPtr handle, int connectionType, int statisticsType);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_add_route_entry", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int AddRoute(IntPtr handle, AddressFamily family, string interfaceName, string address, string gateway);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_remove_route_entry", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int RemoveRoute(IntPtr handle, AddressFamily family, string interfaceName, string address, string gateway);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_set_type_changed_cb")]
        public static partial int SetTypeChangedCallback(IntPtr handle, ConnectionTypeChangedCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_set_ip_address_changed_cb")]
        public static partial int SetIPAddressChangedCallback(IntPtr handle, ConnectionAddressChangedCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_set_ethernet_cable_state_changed_cb")]
        public static partial int SetEthernetCableStateChagedCallback(IntPtr handle, EthernetCableStateChangedCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_set_proxy_address_changed_cb")]
        public static partial int SetProxyAddressChangedCallback(IntPtr handle, ConnectionAddressChangedCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_unset_type_changed_cb")]
        public static partial int UnsetTypeChangedCallback(IntPtr handle);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_unset_ip_address_changed_cb")]
        public static partial int UnsetIPAddressChangedCallback(IntPtr handle);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_unset_ethernet_cable_state_changed_cb")]
        public static partial int UnsetEthernetCableStateChagedCallback(IntPtr handle);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_unset_proxy_address_changed_cb")]
        public static partial int UnsetProxyAddressChangedCallback(IntPtr handle);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_add_profile")]
        public static partial int AddProfile(IntPtr handle, IntPtr profileHandle);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_remove_profile")]
        public static partial int RemoveProfile(IntPtr handle, IntPtr profileHandle);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_update_profile")]
        public static partial int UpdateProfile(IntPtr handle, IntPtr profileHandle);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_get_default_cellular_service_profile")]
        public static partial int GetDefaultCellularServiceProfile(IntPtr handle, int type, out IntPtr profileHandle);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_get_current_profile")]
        public static partial int GetCurrentProfile(IntPtr handle, out IntPtr profileHandle);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_open_profile")]
        public static partial int OpenProfile(IntPtr handle, IntPtr profileHandle, ConnectionCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_close_profile")]
        public static partial int CloseProfile(IntPtr handle, IntPtr profileHandle, ConnectionCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_reset_profile")]
        public static partial int ResetProfile(IntPtr handle, int Option, int Id, ConnectionCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_set_default_cellular_service_profile_async")]
        public static partial int SetDefaultCellularServiceProfileAsync(IntPtr handle, int Type, IntPtr profileHandle, ConnectionCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_get_profile_iterator")]
        public static partial int GetProfileIterator(IntPtr handle, int type, out IntPtr iterHandle);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_iterator_next")]
        public static partial int GetNextProfileIterator(IntPtr iterHandle, out IntPtr profileHandle);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_iterator_has_next")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static partial bool HasNextProfileIterator(IntPtr iterHandle);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_destroy_profile_iterator")]
        public static partial int DestroyProfileIterator(IntPtr iterHandle);
    }

    internal static partial class ConnectionProfile
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ProfileStateChangedCallback(ProfileState type, IntPtr userData);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_create", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int Create(int ProfileType, string Keyword, out IntPtr profileHandle);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_clone")]
        public static partial int Clone(out IntPtr cloneHandle, IntPtr profileHandle);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_destroy")]
        public static partial int Destroy(IntPtr profileHandle);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_id")]
        public static partial int GetId(IntPtr profileHandle, out IntPtr profileId);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_name")]
        public static partial int GetName(IntPtr profileHandle, out IntPtr name);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_type")]
        public static partial int GetType(IntPtr profileHandle, out int type);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_network_interface_name")]
        public static partial int GetNetworkInterfaceName(IntPtr profileHandle, out IntPtr interfaceName);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_state")]
        public static partial int GetState(IntPtr profileHandle, out int type);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_ipv6_state")]
        public static partial int GetIPv6State(IntPtr profileHandle, out int type);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_ip_config_type")]
        public static partial int GetIPConfigType(IntPtr profileHandle, int family, out int type);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_proxy_type")]
        public static partial int GetProxyType(IntPtr profileHandle, out int type);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_ip_address")]
        public static partial int GetIPAddress(IntPtr profileHandle, int family, out IntPtr address);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_subnet_mask")]
        public static partial int GetSubnetMask(IntPtr profileHandle, int family, out IntPtr address);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_gateway_address")]
        public static partial int GetGatewayAddress(IntPtr profileHandle, int family, out IntPtr address);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_dns_address")]
        public static partial int GetDnsAddress(IntPtr profileHandle, int order, int Family, out IntPtr address);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_proxy_address")]
        public static partial int GetProxyAddress(IntPtr profileHandle, int family, out IntPtr address);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_prefix_length")]
        public static partial int GetPrefixLength(IntPtr profileHandle, int family, out int length);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_dns_config_type")]
        public static partial int GetDnsConfigType(IntPtr profileHandle, int family, out int type);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_dhcp_server_address", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int GetDhcpServerAddress(IntPtr profileHandle, AddressFamily family, out string dhcpServerAddress);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_dhcp_lease_duration")]
        public static partial int GetDhcpLeaseDuration(IntPtr profileHandle, AddressFamily family, out int dhcpLeaseDuration);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_refresh")]
        public static partial int Refresh(IntPtr profileHandle);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_set_ip_config_type")]
        public static partial int SetIPConfigType(IntPtr profileHandle, int family, int type);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_set_proxy_type")]
        public static partial int SetProxyType(IntPtr profileHandle, int type);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_set_ip_address", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int SetIPAddress(IntPtr profileHandle, int family, string address);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_set_subnet_mask", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int SetSubnetMask(IntPtr profileHandle, int family, string address);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_set_gateway_address", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int SetGatewayAddress(IntPtr profileHandle, int family, string address);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_set_dns_address", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int SetDnsAddress(IntPtr profileHandle, int order, int family, string address);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_set_proxy_address", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int SetProxyAddress(IntPtr profileHandle, int family, string address);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_set_prefix_length")]
        public static partial int SetPrefixLength(IntPtr profileHandle, int family, int length);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_set_dns_config_type")]
        public static partial int SetDnsConfigType(IntPtr profileHandle, int family, int type);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_set_state_changed_cb")]
        public static partial int SetStateChangeCallback(IntPtr profileHandle, ProfileStateChangedCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_unset_state_changed_cb")]
        public static partial int UnsetStateChangeCallback(IntPtr profileHandle);
    }

    internal static partial class ConnectionCellularProfile
    {
        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_cellular_service_type")]
        public static partial int GetServiceType(IntPtr profileHandle, out int type);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_cellular_apn")]
        public static partial int GetApn(IntPtr profileHandle, out IntPtr apn);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_cellular_auth_info", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int GetAuthInfo(IntPtr profileHandle, out int authType, out string name, out string password);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_cellular_home_url")]
        public static partial int GetHomeUrl(IntPtr profileHandle, out IntPtr homeUrl);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_cellular_pdn_type")]
        public static partial int GetPdnType(IntPtr profileHandle, out int pdnType);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_cellular_roam_pdn_type")]
        public static partial int GetRoamingPdnType(IntPtr profileHandle, out int roamPdnType);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_is_cellular_roaming")]
        public static partial int IsRoaming(IntPtr profileHandle, [MarshalAs(UnmanagedType.U1)] out bool roaming);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_is_cellular_hidden")]
        public static partial int IsHidden(IntPtr profileHandle, [MarshalAs(UnmanagedType.U1)] out bool hidden);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_is_cellular_editable")]
        public static partial int IsEditable(IntPtr profileHandle, [MarshalAs(UnmanagedType.U1)] out bool editable);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_is_cellular_default")]
        public static partial int IsDefault(IntPtr profileHandle, [MarshalAs(UnmanagedType.U1)] out bool isDefault);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_set_cellular_service_type")]
        public static partial int SetServiceType(IntPtr profileHandle, int type);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_set_cellular_apn", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int SetApn(IntPtr profileHandle, string apn);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_set_cellular_auth_info", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int SetAuthInfo(IntPtr profileHandle, int authType, string name, string password);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_set_cellular_home_url", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int SetHomeUrl(IntPtr profileHandle, string homeUrl);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_set_cellular_pdn_type")]
        public static partial int SetPdnType(IntPtr profileHandle, int pdnType);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_set_cellular_roam_pdn_type")]
        public static partial int SetRoamingPdnType(IntPtr profileHandle, int roamPdnType);
    }

    internal static partial class ConnectionWiFiProfile
    {
        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_wifi_essid")]
        public static partial int GetEssid(IntPtr profileHandle, out IntPtr essid);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_wifi_bssid")]
        public static partial int GetBssid(IntPtr profileHandle, out IntPtr bssid);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_wifi_rssi")]
        public static partial int GetRssi(IntPtr profileHandle, out int rssi);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_wifi_frequency")]
        public static partial int GetFrequency(IntPtr profileHandle, out int frequency);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_wifi_max_speed")]
        public static partial int GetMaxSpeed(IntPtr profileHandle, out int maxSpeed);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_wifi_security_type")]
        public static partial int GetSecurityType(IntPtr profileHandle, out int type);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_get_wifi_encryption_type")]
        public static partial int GetEncryptionType(IntPtr profileHandle, out int type);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_is_wifi_passphrase_required")]
        public static partial int IsRequiredPassphrase(IntPtr profileHandle, [MarshalAs(UnmanagedType.U1)] out bool required);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_set_wifi_passphrase", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int SetPassphrase(IntPtr profileHandle, string passphrase);

        [LibraryImport(Libraries.Connection, EntryPoint = "connection_profile_is_wifi_wps_supported")]
        public static partial int IsSupportedWps(IntPtr profileHandle, [MarshalAs(UnmanagedType.U1)] out bool supported);
    }
	
    internal static partial class Libc
    {
        [LibraryImport(Libraries.Libc, EntryPoint = "free")]
        public static partial void Free(IntPtr userData);

    }
}





