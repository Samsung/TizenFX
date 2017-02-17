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
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_initialize")]
        internal static extern int Initialize(out IntPtr wifi);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_deinitialize")]
        internal static extern int Deinitialize(IntPtr wifi);

        ////Wi-Fi Manager
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_activate")]
        internal static extern int Activate(IntPtr wifi, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_activate_with_wifi_picker_tested")]
        internal static extern int ActivateWithWiFiPickerTested(IntPtr wifi, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_deactivate")]
        internal static extern int Deactivate(IntPtr wifi, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_is_activated")]
        internal static extern int IsActive(IntPtr wifi, out bool activated);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_get_mac_address")]
        internal static extern int GetMacAddress(IntPtr wifi, out string macAddress);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_get_network_interface_name")]
        internal static extern int GetNetworkInterfaceName(IntPtr wifi, out string interfaceName);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_scan")]
        internal static extern int Scan(IntPtr wifi, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_scan_specific_ap")]
        internal static extern int ScanSpecificAP(IntPtr wifi, string essid, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_get_connected_ap")]
        internal static extern int GetConnectedAP(IntPtr wifi, out IntPtr ap);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_foreach_found_ap")]
        internal static extern int GetForeachFoundAPs(IntPtr wifi, HandleCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_foreach_found_specific_ap")]
        internal static extern int GetForeachFoundSpecificAPs(IntPtr wifi, HandleCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_connect")]
        internal static extern int Connect(IntPtr wifi, IntPtr ap, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_disconnect")]
        internal static extern int Disconnect(IntPtr wifi, IntPtr ap, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_connect_by_wps_pbc")]
        internal static extern int ConnectByWpsPbc(IntPtr wifi, IntPtr ap, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_connect_by_wps_pin")]
        internal static extern int ConnectByWpsPin(IntPtr wifi, IntPtr ap, string pin, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_forget_ap")]
        internal static extern int RemoveAP(IntPtr wifi, IntPtr ap);

        //Wi-Fi Monitor
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_get_connection_state")]
        internal static extern int GetConnectionState(IntPtr wifi, out int connectionState);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_set_device_state_changed_cb")]
        internal static extern int SetDeviceStateChangedCallback(IntPtr wifi, DeviceStateChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_unset_device_state_changed_cb")]
        internal static extern int UnsetDeviceStateChangedCallback(IntPtr wifi);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_set_background_scan_cb")]
        internal static extern int SetBackgroundScanCallback(IntPtr wifi, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_unset_background_scan_cb")]
        internal static extern int UnsetBackgroundScanCallback(IntPtr wifi);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_set_connection_state_changed_cb")]
        internal static extern int SetConnectionStateChangedCallback(IntPtr wifi, ConnectionStateChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_unset_connection_state_changed_cb")]
        internal static extern int UnsetConnectionStateChangedCallback(IntPtr wifi);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_set_rssi_level_changed_cb")]
        internal static extern int SetRssiLevelchangedCallback(IntPtr wifi, RssiLevelChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_unset_rssi_level_changed_cb")]
        internal static extern int UnsetRssiLevelchangedCallback(IntPtr wifi);

        internal static class AP
        {
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_create")]
            internal static extern int Create(IntPtr wifi, string essid, out IntPtr ap);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_hidden_create")]
            internal static extern int CreateHiddenAP(IntPtr wifi, string essid, out IntPtr ap);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_destroy")]
            internal static extern int Destroy(IntPtr ap);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_clone")]
            internal static extern int Clone(out IntPtr cloned, IntPtr original);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_refresh")]
            internal static extern int Refresh(IntPtr ap);

            ////Network Information
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_essid")]
            internal static extern int GetEssid(IntPtr ap, out IntPtr essid);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_bssid")]
            internal static extern int GetBssid(IntPtr ap, out IntPtr bssid);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_rssi")]
            internal static extern int GetRssi(IntPtr ap, out int rssi);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_frequency")]
            internal static extern int GetFrequency(IntPtr ap, out int frequency);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_max_speed")]
            internal static extern int GetMaxSpeed(IntPtr ap, out int maxSpeed);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_is_favorite")]
            internal static extern int IsFavorite(IntPtr ap, out bool isFavorite);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_is_passpoint")]
            internal static extern int IsPasspoint(IntPtr ap, out bool isPasspoint);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_connection_state")]
            internal static extern int GetConnectionState(IntPtr ap, out int connectionState);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_ip_config_type")]
            internal static extern int GetIPConfigType(IntPtr ap, int addressFamily, out int ipConfigType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_ip_config_type")]
            internal static extern int SetIPConfigType(IntPtr ap, int addressFamily, int ipConfigType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_ip_address")]
            internal static extern int GetIPAddress(IntPtr ap, int addressFamily, out IntPtr ipAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_ip_address")]
            internal static extern int SetIPAddress(IntPtr ap, int addressFamily, string ipAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_subnet_mask")]
            internal static extern int GetSubnetMask(IntPtr ap, int addressFamily, out IntPtr subnetMask);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_subnet_mask")]
            internal static extern int SetSubnetMask(IntPtr ap, int addressFamily, string subnetMask);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_gateway_address")]
            internal static extern int GetGatewayAddress(IntPtr ap, int addressFamily, out IntPtr gatewayAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_gateway_address")]
            internal static extern int SetGatewayAddress(IntPtr ap, int addressFamily, string gatewayAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_proxy_address")]
            internal static extern int GetProxyAddress(IntPtr ap, int addressFamily, out IntPtr proxyAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_proxy_address")]
            internal static extern int SetProxyAddress(IntPtr ap, int addressFamily, string proxyAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_proxy_type")]
            internal static extern int GetProxyType(IntPtr ap, out int proxyType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_proxy_type")]
            internal static extern int SetProxyType(IntPtr ap, int proxyType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_dns_address")]
            internal static extern int GetDnsAddress(IntPtr ap, int order, int addressFamily, out IntPtr dnsAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_dns_address")]
            internal static extern int SetDnsAddress(IntPtr ap, int order, int addressFamily, string dnsAddress);

            ////Security Information
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_security_type")]
            internal static extern int GetSecurityType(IntPtr ap, out int securityType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_security_type")]
            internal static extern int SetSecurityType(IntPtr ap, int securityType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_encryption_type")]
            internal static extern int GetEncryptionType(IntPtr ap, out int encryptionType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_encryption_type")]
            internal static extern int SetEncryptionType(IntPtr ap, int encryptionType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_is_passphrase_required")]
            internal static extern int IsPassphraseRequired(IntPtr ap, out bool required);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_passphrase")]
            internal static extern int SetPassphrase(IntPtr ap, string passphrase);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_is_wps_supported")]
            internal static extern int IsWpsSupported(IntPtr ap, out bool supported);

            ////EAP
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_eap_passphrase")]
            internal static extern int SetEapPassphrase(IntPtr ap, string userName, string password);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_eap_passphrase")]
            internal static extern int GetEapPassphrase(IntPtr ap, out IntPtr userName, out bool isPasswordSet);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_eap_ca_cert_file")]
            internal static extern int GetEapCaCertFile(IntPtr ap, out IntPtr file);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_eap_ca_cert_file")]
            internal static extern int SetEapCaCertFile(IntPtr ap, string file);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_eap_client_cert_file")]
            internal static extern int GetEapClientCertFile(IntPtr ap, out IntPtr file);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_eap_client_cert_file")]
            internal static extern int SetEapClientCertFile(IntPtr ap, string file);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_eap_private_key_file")]
            internal static extern int GetEapPrivateKeyFile(IntPtr ap, out IntPtr file);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_eap_private_key_info")]
            internal static extern int SetEapPrivateKeyFile(IntPtr ap, string file, string password);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_eap_type")]
            internal static extern int GetEapType(IntPtr ap, out int eapType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_eap_type")]
            internal static extern int SetEapType(IntPtr ap, int eapType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_get_eap_auth_type")]
            internal static extern int GetEapAuthType(IntPtr ap, out int file);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_ap_set_eap_auth_type")]
            internal static extern int SetEapAuthType(IntPtr ap, int file);
        }

        internal static class Config
        {
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_create")]
            internal static extern int Create(IntPtr wifi, string name, string passPhrase, int securityType, out IntPtr config);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_clone")]
            internal static extern int Clone(IntPtr origin, out IntPtr cloned);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_destroy")]
            internal static extern int Destroy(IntPtr config);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_save")]
            internal static extern int SaveConfiguration(IntPtr wifi, IntPtr config);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_foreach_configuration")]
            internal static extern int GetForeachConfiguration(IntPtr wifi, HandleCallback callback, IntPtr userData);
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
            internal static extern int GetEapAnonymousIdentity(IntPtr config, out IntPtr anonymousIdentify);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_set_eap_anonymous_identity")]
            internal static extern int SetEapAnonymousIdentity(IntPtr config, string anonymousIdentify);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_get_eap_ca_cert_file")]
            internal static extern int GetEapCaCertFile(IntPtr config, out IntPtr caCert);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_set_eap_ca_cert_file")]
            internal static extern int SetEapCaCertFile(IntPtr config, string caCert);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_get_eap_client_cert_file")]
            internal static extern int GetEapClientCertFile(IntPtr config, out IntPtr clientCert);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_set_eap_client_cert_file")]
            internal static extern int SetEapClientCertFile(IntPtr config, string privateKey, string clientCert);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_get_eap_identity")]
            internal static extern int GetEapIdentity(IntPtr config, out IntPtr identify);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_set_eap_identity")]
            internal static extern int SetEapIdentity(IntPtr config, string identify);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_get_eap_type")]
            internal static extern int GetEapType(IntPtr config, out int eapType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_set_eap_type")]
            internal static extern int SetEapType(IntPtr config, int eapType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_get_eap_auth_type")]
            internal static extern int GetEapAuthType(IntPtr config, out int eapAuthType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_set_eap_auth_type")]
            internal static extern int SetEapAuthType(IntPtr config, int eapAuthType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_get_eap_subject_match")]
            internal static extern int GetEapSubjectMatch(IntPtr config, out IntPtr subjectMatch);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_manager_config_set_eap_subject_match")]
            internal static extern int SetEapSubjectMatch(IntPtr config, string subjectMatch);
        }
    }
}
