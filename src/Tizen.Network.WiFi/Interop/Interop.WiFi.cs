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
using Tizen.Network.WiFi;
using Tizen.Network.Connection;

internal static partial class Interop
{
    internal static partial class WiFi
    {
        //Callback for async method
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VoidCallback(int result, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool HandleCallback(IntPtr handle, IntPtr userData);

        //Callback for event
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DeviceStateChangedCallback(int deviceState, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ConnectionStateChangedCallback(int connectionState, IntPtr ap, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RssiLevelChangedCallback(int level, IntPtr userData);

        //capi-network-wifi-1.0.65-19.23.armv7l
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_initialize_cs")]
        internal static extern int Initialize(int tid, out SafeWiFiManagerHandle wifi);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_deinitialize_cs")]
        internal static extern int Deinitialize(int tid, IntPtr wifi);

        ////Wi-Fi Manager
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_activate")]
        internal static extern int Activate(SafeWiFiManagerHandle wifi, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_activate_with_wifi_picker_tested")]
        internal static extern int ActivateWithWiFiPickerTested(SafeWiFiManagerHandle wifi, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_deactivate")]
        internal static extern int Deactivate(SafeWiFiManagerHandle wifi, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_is_activated")]
        internal static extern int IsActive(SafeWiFiManagerHandle wifi, out bool activated);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_get_mac_address")]
        internal static extern int GetMacAddress(SafeWiFiManagerHandle wifi, out string macAddress);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_get_network_interface_name")]
        internal static extern int GetNetworkInterfaceName(SafeWiFiManagerHandle wifi, out string interfaceName);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_scan")]
        internal static extern int Scan(SafeWiFiManagerHandle wifi, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_scan_specific_ap")]
        internal static extern int ScanSpecificAP(SafeWiFiManagerHandle wifi, string essid, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_bssid_scan")]
        internal static extern int BssidScan(SafeWiFiManagerHandle wifi, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_get_connected_ap")]
        internal static extern int GetConnectedAP(SafeWiFiManagerHandle wifi, out IntPtr ap);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_foreach_found_ap")]
        internal static extern int GetForeachFoundAPs(SafeWiFiManagerHandle wifi, HandleCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_foreach_found_specific_ap")]
        internal static extern int GetForeachFoundSpecificAPs(SafeWiFiManagerHandle wifi, HandleCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_foreach_found_bssid_ap")]
        internal static extern int GetForeachFoundBssids(SafeWiFiManagerHandle wifi, HandleCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_connect")]
        internal static extern int Connect(SafeWiFiManagerHandle wifi, IntPtr ap, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_disconnect")]
        internal static extern int Disconnect(SafeWiFiManagerHandle wifi, IntPtr ap, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_connect_by_wps_pbc")]
        internal static extern int ConnectByWpsPbc(SafeWiFiManagerHandle wifi, IntPtr ap, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_connect_by_wps_pin")]
        internal static extern int ConnectByWpsPin(SafeWiFiManagerHandle wifi, IntPtr ap, string pin, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_connect_by_wps_pbc_without_ssid")]
        internal static extern int ConnectByWpsPbcWithoutSsid(SafeWiFiManagerHandle wifi, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_connect_by_wps_pin_without_ssid")]
        internal static extern int ConnectByWpsPinWithoutSsid(SafeWiFiManagerHandle wifi, string pin, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_cancel_wps")]
        internal static extern int CancelWps(SafeWiFiManagerHandle wifi);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_forget_ap")]
        internal static extern int RemoveAP(SafeWiFiManagerHandle wifi, IntPtr ap);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_update_ap")]
        internal static extern int UpdateAP(SafeWiFiManagerHandle wifi, IntPtr ap);

        //Wi-Fi Monitor
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_get_connection_state")]
        internal static extern int GetConnectionState(SafeWiFiManagerHandle wifi, out int connectionState);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_set_device_state_changed_cb")]
        internal static extern int SetDeviceStateChangedCallback(SafeWiFiManagerHandle wifi, DeviceStateChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_unset_device_state_changed_cb")]
        internal static extern int UnsetDeviceStateChangedCallback(SafeWiFiManagerHandle wifi);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_set_background_scan_cb")]
        internal static extern int SetBackgroundScanCallback(SafeWiFiManagerHandle wifi, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_unset_background_scan_cb")]
        internal static extern int UnsetBackgroundScanCallback(SafeWiFiManagerHandle wifi);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_set_connection_state_changed_cb")]
        internal static extern int SetConnectionStateChangedCallback(SafeWiFiManagerHandle wifi, ConnectionStateChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_unset_connection_state_changed_cb")]
        internal static extern int UnsetConnectionStateChangedCallback(SafeWiFiManagerHandle wifi);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_set_rssi_level_changed_cb")]
        internal static extern int SetRssiLevelchangedCallback(SafeWiFiManagerHandle wifi, RssiLevelChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_unset_rssi_level_changed_cb")]
        internal static extern int UnsetRssiLevelchangedCallback(SafeWiFiManagerHandle wifi);

        internal static class AP
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate bool FoundBssidCallback(string bssid, int rssi, int freq, IntPtr userData);

            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_create")]
            internal static extern int Create(SafeWiFiManagerHandle wifi, string essid, out IntPtr ap);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_hidden_create")]
            internal static extern int CreateHiddenAP(SafeWiFiManagerHandle wifi, string essid, out IntPtr ap);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_destroy")]
            internal static extern int Destroy(IntPtr ap);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_clone")]
            internal static extern int Clone(out IntPtr cloned, IntPtr original);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_refresh")]
            internal static extern int Refresh(IntPtr ap);

            ////Network Information
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_essid")]
            internal static extern int GetEssid(SafeWiFiAPHandle ap, out IntPtr essid);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_raw_ssid")]
            internal static extern int GetRawSsid(SafeWiFiAPHandle ap, out IntPtr raw_ssid, out int length);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_bssid")]
            internal static extern int GetBssid(SafeWiFiAPHandle ap, out IntPtr bssid);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_foreach_found_bssid")]
            internal static extern int GetBssids(SafeWiFiAPHandle ap, FoundBssidCallback callback, IntPtr userData);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_rssi")]
            internal static extern int GetRssi(SafeWiFiAPHandle ap, out int rssi);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_rssi_level")]
            internal static extern int GetRssiLevel(SafeWiFiAPHandle ap, out int rssi_level);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_frequency")]
            internal static extern int GetFrequency(SafeWiFiAPHandle ap, out int frequency);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_max_speed")]
            internal static extern int GetMaxSpeed(SafeWiFiAPHandle ap, out int maxSpeed);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_is_favorite")]
            internal static extern int IsFavorite(SafeWiFiAPHandle ap, out bool isFavorite);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_is_passpoint")]
            internal static extern int IsPasspoint(SafeWiFiAPHandle ap, out bool isPasspoint);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_connection_state")]
            internal static extern int GetConnectionState(SafeWiFiAPHandle ap, out int connectionState);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_ip_config_type")]
            internal static extern int GetIPConfigType(SafeWiFiAPHandle ap, int addressFamily, out int ipConfigType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_ip_config_type")]
            internal static extern int SetIPConfigType(SafeWiFiAPHandle ap, int addressFamily, int ipConfigType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_ip_address")]
            internal static extern int GetIPAddress(SafeWiFiAPHandle ap, int addressFamily, out IntPtr ipAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_foreach_ipv6_address")]
            internal static extern int GetAllIPv6Addresses(SafeWiFiAPHandle ap, HandleCallback callback, IntPtr userData);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_countrycode")]
            internal static extern int GetCountryCode(SafeWiFiAPHandle ap, out IntPtr code);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_ip_address")]
            internal static extern int SetIPAddress(SafeWiFiAPHandle ap, int addressFamily, string ipAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_subnet_mask")]
            internal static extern int GetSubnetMask(SafeWiFiAPHandle ap, int addressFamily, out IntPtr subnetMask);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_subnet_mask")]
            internal static extern int SetSubnetMask(SafeWiFiAPHandle ap, int addressFamily, string subnetMask);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_gateway_address")]
            internal static extern int GetGatewayAddress(SafeWiFiAPHandle ap, int addressFamily, out IntPtr gatewayAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_gateway_address")]
            internal static extern int SetGatewayAddress(SafeWiFiAPHandle ap, int addressFamily, string gatewayAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_dhcp_server_address")]
            internal static extern int GetDhcpServerAddress(SafeWiFiAPHandle ap, AddressFamily addressFamily, out string dhcpServer);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_proxy_address")]
            internal static extern int GetProxyAddress(SafeWiFiAPHandle ap, int addressFamily, out IntPtr proxyAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_proxy_address")]
            internal static extern int SetProxyAddress(SafeWiFiAPHandle ap, int addressFamily, string proxyAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_proxy_type")]
            internal static extern int GetProxyType(SafeWiFiAPHandle ap, out int proxyType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_proxy_type")]
            internal static extern int SetProxyType(SafeWiFiAPHandle ap, int proxyType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_dns_address")]
            internal static extern int GetDnsAddress(SafeWiFiAPHandle ap, int order, int addressFamily, out IntPtr dnsAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_dns_address")]
            internal static extern int SetDnsAddress(SafeWiFiAPHandle ap, int order, int addressFamily, string dnsAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_prefix_length")]
            internal static extern int GetPrefixLength(SafeWiFiAPHandle ap, int addressFamily, out int length);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_prefix_length")]
            internal static extern int SetPrefixLength(SafeWiFiAPHandle ap, int addressFamily, int length);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_dns_config_type")]
            internal static extern int GetDnsConfigType(SafeWiFiAPHandle ap, int addressFamily, out int type);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_dns_config_type")]
            internal static extern int SetDnsConfigType(SafeWiFiAPHandle ap, int addressFamily, int type);

            ////Security Information
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_security_type")]
            internal static extern int GetSecurityType(SafeWiFiAPHandle ap, out int securityType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_security_type")]
            internal static extern int SetSecurityType(SafeWiFiAPHandle ap, int securityType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_encryption_type")]
            internal static extern int GetEncryptionType(SafeWiFiAPHandle ap, out int encryptionType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_encryption_type")]
            internal static extern int SetEncryptionType(SafeWiFiAPHandle ap, int encryptionType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_is_passphrase_required")]
            internal static extern int IsPassphraseRequired(SafeWiFiAPHandle ap, out bool required);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_passphrase")]
            internal static extern int SetPassphrase(SafeWiFiAPHandle ap, string passphrase);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_is_wps_supported")]
            internal static extern int IsWpsSupported(SafeWiFiAPHandle ap, out bool supported);

            ////EAP
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_eap_passphrase")]
            internal static extern int SetEapPassphrase(SafeWiFiAPHandle ap, string userName, string password);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_eap_passphrase")]
            internal static extern int GetEapPassphrase(SafeWiFiAPHandle ap, out IntPtr userName, out bool isPasswordSet);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_eap_ca_cert_file")]
            internal static extern int GetEapCaCertFile(SafeWiFiAPHandle ap, out IntPtr file);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_eap_ca_cert_file")]
            internal static extern int SetEapCaCertFile(SafeWiFiAPHandle ap, string file);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_eap_client_cert_file")]
            internal static extern int GetEapClientCertFile(SafeWiFiAPHandle ap, out IntPtr file);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_eap_client_cert_file")]
            internal static extern int SetEapClientCertFile(SafeWiFiAPHandle ap, string file);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_eap_private_key_file")]
            internal static extern int GetEapPrivateKeyFile(SafeWiFiAPHandle ap, out IntPtr file);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_eap_private_key_info")]
            internal static extern int SetEapPrivateKeyFile(SafeWiFiAPHandle ap, string file, string password);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_eap_type")]
            internal static extern int GetEapType(SafeWiFiAPHandle ap, out int eapType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_eap_type")]
            internal static extern int SetEapType(SafeWiFiAPHandle ap, int eapType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_eap_auth_type")]
            internal static extern int GetEapAuthType(SafeWiFiAPHandle ap, out int file);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_eap_auth_type")]
            internal static extern int SetEapAuthType(SafeWiFiAPHandle ap, int file);
        }

        internal static class Config
        {
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_create")]
            internal static extern int Create(SafeWiFiManagerHandle wifi, string name, string passPhrase, int securityType, out IntPtr config);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_clone")]
            internal static extern int Clone(IntPtr origin, out IntPtr cloned);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_destroy")]
            internal static extern int Destroy(IntPtr config);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_save")]
            internal static extern int SaveConfiguration(SafeWiFiManagerHandle wifi, IntPtr config);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_foreach_configuration")]
            internal static extern int GetForeachConfiguration(SafeWiFiManagerHandle wifi, HandleCallback callback, IntPtr userData);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_get_name")]
            internal static extern int GetName(IntPtr config, out IntPtr name);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_get_security_type")]
            internal static extern int GetSecurityType(IntPtr config, out int securityType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_set_proxy_address")]
            internal static extern int SetProxyAddress(IntPtr config, int addressFamily, string proxyAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_get_proxy_address")]
            internal static extern int GetProxyAddress(IntPtr config, out int addressFamily, out IntPtr proxyAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_set_hidden_ap_property")]
            internal static extern int SetHiddenAPProperty(IntPtr config, bool isHidden);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_get_hidden_ap_property")]
            internal static extern int GetHiddenAPProperty(IntPtr config, out bool isHidden);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_get_eap_anonymous_identity")]
            internal static extern int GetEapAnonymousIdentity(SafeWiFiConfigHandle config, out IntPtr anonymousIdentify);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_set_eap_anonymous_identity")]
            internal static extern int SetEapAnonymousIdentity(SafeWiFiConfigHandle config, string anonymousIdentify);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_get_eap_ca_cert_file")]
            internal static extern int GetEapCaCertFile(SafeWiFiConfigHandle config, out IntPtr caCert);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_set_eap_ca_cert_file")]
            internal static extern int SetEapCaCertFile(SafeWiFiConfigHandle config, string caCert);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_get_eap_client_cert_file")]
            internal static extern int GetEapClientCertFile(SafeWiFiConfigHandle config, out IntPtr clientCert);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_set_eap_client_cert_file")]
            internal static extern int SetEapClientCertFile(SafeWiFiConfigHandle config, string privateKey, string clientCert);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_get_eap_identity")]
            internal static extern int GetEapIdentity(SafeWiFiConfigHandle config, out IntPtr identify);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_set_eap_identity")]
            internal static extern int SetEapIdentity(SafeWiFiConfigHandle config, string identify);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_get_eap_type")]
            internal static extern int GetEapType(SafeWiFiConfigHandle config, out int eapType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_set_eap_type")]
            internal static extern int SetEapType(SafeWiFiConfigHandle config, int eapType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_get_eap_auth_type")]
            internal static extern int GetEapAuthType(SafeWiFiConfigHandle config, out int eapAuthType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_set_eap_auth_type")]
            internal static extern int SetEapAuthType(SafeWiFiConfigHandle config, int eapAuthType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_get_eap_subject_match")]
            internal static extern int GetEapSubjectMatch(SafeWiFiConfigHandle config, out IntPtr subjectMatch);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_set_eap_subject_match")]
            internal static extern int SetEapSubjectMatch(SafeWiFiConfigHandle config, string subjectMatch);
        }

        internal sealed class SafeWiFiAPHandle : SafeHandle
        {
            public SafeWiFiAPHandle() : base(IntPtr.Zero, true)
            {
            }

            public SafeWiFiAPHandle(IntPtr handle) : base(handle, true)
            {
            }

            public override bool IsInvalid
            {
                get
                {
                    return this.handle == IntPtr.Zero;
                }
            }

            protected override bool ReleaseHandle()
            {
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }

        internal sealed class SafeWiFiConfigHandle : SafeHandle
        {
            public SafeWiFiConfigHandle() : base(IntPtr.Zero, true)
            {
            }

            public SafeWiFiConfigHandle(IntPtr handle) : base(handle, true)
            {
            }

            public override bool IsInvalid
            {
                get
                {
                    return this.handle == IntPtr.Zero;
                }
            }

            protected override bool ReleaseHandle()
            {
                WiFi.Config.Destroy(this.handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }

    }

    internal static partial class Libc
    {
        [DllImport(Libraries.Libc, EntryPoint = "free")]
        public static extern void Free(IntPtr userData);
    }
}
