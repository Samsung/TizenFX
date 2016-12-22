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
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_initialize")]
        internal static extern int Initialize();
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_deinitialize")]
        internal static extern int Deinitialize();

        ////Wi-Fi Manager
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_activate")]
        internal static extern int Activate(VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_activate_with_wifi_picker_tested")]
        internal static extern int ActivateWithWiFiPickerTested(VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_deactivate")]
        internal static extern int Deactivate(VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_is_activated")]
        internal static extern int IsActivated(out bool activated);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_get_mac_address")]
        internal static extern int GetMacAddress(out string macAddress);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_get_network_interface_name")]
        internal static extern int GetNetworkInterfaceName(out string interfaceName);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_scan")]
        internal static extern int Scan(VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_scan_specific_ap")]
        internal static extern int ScanSpecificAp(string essid, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_get_connected_ap")]
        internal static extern int GetConnectedAp(out IntPtr ap);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_foreach_found_aps")]
        internal static extern int GetForeachFoundAps(HandleCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_foreach_found_specific_aps")]
        internal static extern int GetForeachFoundSpecificAps(HandleCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_connect")]
        internal static extern int Connect(IntPtr ap, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_disconnect")]
        internal static extern int Disconnect(IntPtr ap, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_connect_by_wps_pbc")]
        internal static extern int ConnectByWpsPbc(IntPtr ap, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_connect_by_wps_pin")]
        internal static extern int ConnectByWpsPin(IntPtr ap, string pin, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_forget_ap")]
        internal static extern int RemoveAp(IntPtr ap);

        //Wi-Fi Monitor
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_get_connection_state")]
        internal static extern int GetConnectionState(out int connectionState);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_set_device_state_changed_cb")]
        internal static extern int SetDeviceStateChangedCallback(DeviceStateChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_unset_device_state_changed_cb")]
        internal static extern int UnsetDeviceStateChangedCallback();
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_set_background_scan_cb")]
        internal static extern int SetBackgroundScanCallback(VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_unset_background_scan_cb")]
        internal static extern int UnsetBackgroundScanCallback();
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_set_connection_state_changed_cb")]
        internal static extern int SetConnectionStateChangedCallback(ConnectionStateChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_unset_connection_state_changed_cb")]
        internal static extern int UnsetConnectionStateChangedCallback();
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_set_rssi_level_changed_cb")]
        internal static extern int SetRssiLevelchangedCallback(RssiLevelChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.WiFi, EntryPoint = "wifi_unset_rssi_level_changed_cb")]
        internal static extern int UnsetRssiLevelchangedCallback();

        internal static class Ap
        {
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_create")]
            internal static extern int Create(string essid, out IntPtr ap);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_hidden_create")]
            internal static extern int CreateHiddenAp(string essid, out IntPtr ap);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_destroy")]
            internal static extern int Destroy(IntPtr ap);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_clone")]
            internal static extern int Clone(out IntPtr cloned, IntPtr original);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_refresh")]
            internal static extern int Refresh(IntPtr ap);

            ////Network Information
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_essid")]
            internal static extern int GetEssid(IntPtr ap, out IntPtr essid);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_bssid")]
            internal static extern int GetBssid(IntPtr ap, out IntPtr bssid);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_rssi")]
            internal static extern int GetRssi(IntPtr ap, out int rssi);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_frequency")]
            internal static extern int GetFrequency(IntPtr ap, out int frequency);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_max_speed")]
            internal static extern int GetMaxSpeed(IntPtr ap, out int maxSpeed);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_is_favorite")]
            internal static extern int IsFavorite(IntPtr ap, out bool isFavorite);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_is_passpoint")]
            internal static extern int IsPasspoint(IntPtr ap, out bool isPasspoint);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_connection_state")]
            internal static extern int GetConnectionState(IntPtr ap, out int connectionState);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_ip_config_type")]
            internal static extern int GetIpConfigType(IntPtr ap, int addressFamily, out int ipConfigType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_set_ip_config_type")]
            internal static extern int SetIpConfigType(IntPtr ap, int addressFamily, int ipConfigType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_ip_address")]
            internal static extern int GetIpAddress(IntPtr ap, int addressFamily, out IntPtr ipAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_set_ip_address")]
            internal static extern int SetIpAddress(IntPtr ap, int addressFamily, string ipAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_subnet_mask")]
            internal static extern int GetSubnetMask(IntPtr ap, int addressFamily, out IntPtr subnetMask);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_set_subnet_mask")]
            internal static extern int SetSubnetMask(IntPtr ap, int addressFamily, string subnetMask);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_gateway_address")]
            internal static extern int GetGatewayAddress(IntPtr ap, int addressFamily, out IntPtr gatewayAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_set_gateway_address")]
            internal static extern int SetGatewayAddress(IntPtr ap, int addressFamily, string gatewayAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_proxy_address")]
            internal static extern int GetProxyAddress(IntPtr ap, int addressFamily, out IntPtr proxyAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_set_proxy_address")]
            internal static extern int SetProxyAddress(IntPtr ap, int addressFamily, string proxyAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_proxy_type")]
            internal static extern int GetProxyType(IntPtr ap, out int proxyType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_set_proxy_type")]
            internal static extern int SetProxyType(IntPtr ap, int proxyType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_dns_address")]
            internal static extern int GetDnsAddress(IntPtr ap, int order, int addressFamily, out IntPtr dnsAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_set_dns_address")]
            internal static extern int SetDnsAddress(IntPtr ap, int order, int addressFamily, string dnsAddress);

            ////Security Information
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_security_type")]
            internal static extern int GetSecurityType(IntPtr ap, out int securityType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_set_security_type")]
            internal static extern int SetSecurityType(IntPtr ap, int securityType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_encryption_type")]
            internal static extern int GetEncryptionType(IntPtr ap, out int encryptionType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_set_encryption_type")]
            internal static extern int SetEncryptionType(IntPtr ap, int encryptionType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_is_passphrase_required")]
            internal static extern int IsPassphraseRequired(IntPtr ap, out bool required);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_set_passphrase")]
            internal static extern int SetPassphrase(IntPtr ap, string passphrase);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_is_wps_supported")]
            internal static extern int IsWpsSupported(IntPtr ap, out bool supported);

            ////EAP
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_set_eap_passphrase")]
            internal static extern int SetEapPassphrase(IntPtr ap, string userName, string password);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_eap_passphrase")]
            internal static extern int GetEapPassphrase(IntPtr ap, out IntPtr userName, out bool isPasswordSet);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_eap_ca_cert_file")]
            internal static extern int GetEapCaCertFile(IntPtr ap, out IntPtr file);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_set_eap_ca_cert_file")]
            internal static extern int SetEapCaCertFile(IntPtr ap, string file);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_eap_client_cert_file")]
            internal static extern int GetEapClientCertFile(IntPtr ap, out IntPtr file);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_set_eap_client_cert_file")]
            internal static extern int SetEapClientCertFile(IntPtr ap, string file);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_eap_private_key_file")]
            internal static extern int GetEapPrivateKeyFile(IntPtr ap, out IntPtr file);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_set_eap_private_key_info")]
            internal static extern int SetEapPrivateKeyInfo(IntPtr ap, string file, string password);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_eap_type")]
            internal static extern int GetEapType(IntPtr ap, out int eapType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_set_eap_type")]
            internal static extern int SetEapType(IntPtr ap, int eapType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_get_eap_auth_type")]
            internal static extern int GetEapAuthType(IntPtr ap, out int file);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_ap_set_eap_auth_type")]
            internal static extern int SetEapAuthType(IntPtr ap, int file);
        }

        internal static class Config
        {
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_create")]
            internal static extern int Create(string name, string passPhrase, int securityType, out IntPtr config);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_clone")]
            internal static extern int Clone(IntPtr origin, out IntPtr cloned);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_destroy")]
            internal static extern int Destroy(IntPtr config);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_save_configuration")]
            internal static extern int SaveConfiguration(IntPtr config);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_foreach_configuration")]
            internal static extern int GetForeachConfiguration(HandleCallback callback, IntPtr userData);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_get_name")]
            internal static extern int GetName(IntPtr config, out IntPtr name);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_get_security_type")]
            internal static extern int GetSecurityType(IntPtr config, out int securityType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_set_proxy_address")]
            internal static extern int SetProxyAddress(IntPtr config, int addressFamily, string proxyAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_get_proxy_address")]
            internal static extern int GetProxyAddress(IntPtr config, out int addressFamily, out IntPtr proxyAddress);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_set_hidden_ap_property")]
            internal static extern int SetHiddenApProperty(IntPtr config, bool isHidden);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_get_hidden_ap_property")]
            internal static extern int GetHiddenApProperty(IntPtr config, out bool isHidden);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_get_eap_anonymous_identity")]
            internal static extern int GetEapAnonymousIdentity(IntPtr config, out IntPtr anonymousIdentify);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_set_eap_anonymous_identity")]
            internal static extern int SetEapAnonymousIdentity(IntPtr config, string anonymousIdentify);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_get_eap_ca_cert_file")]
            internal static extern int GetEapCaCertFile(IntPtr config, out IntPtr caCert);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_set_eap_ca_cert_file")]
            internal static extern int SetEapCaCertFile(IntPtr config, string caCert);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_get_eap_client_cert_file")]
            internal static extern int GetEapClientCertFile(IntPtr config, out IntPtr clientCert);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_set_eap_client_cert_file")]
            internal static extern int SetEapClientCertFile(IntPtr config, string privateKey, string clientCert);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_get_eap_identity")]
            internal static extern int GetEapIdentity(IntPtr config, out IntPtr identify);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_set_eap_identity")]
            internal static extern int SetEapIdentity(IntPtr config, string identify);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_get_eap_type")]
            internal static extern int GetEapType(IntPtr config, out int eapType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_set_eap_type")]
            internal static extern int SetEapType(IntPtr config, int eapType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_get_eap_auth_type")]
            internal static extern int GetEapAuthType(IntPtr config, out int eapAuthType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_set_eap_auth_type")]
            internal static extern int SetEapAuthType(IntPtr config, int eapAuthType);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_get_eap_subject_match")]
            internal static extern int GetEapSubjectMatch(IntPtr config, out IntPtr subjectMatch);
            [DllImport(Libraries.WiFi, EntryPoint = "wifi_config_set_eap_subject_match")]
            internal static extern int SetEapSubjectMatch(IntPtr config, string subjectMatch);
        }
    }
}
