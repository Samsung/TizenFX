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
using Tizen.Network.Bluetooth;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Bluetooth
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void StateChangedCallback(int result, int state, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void NameChangedCallback(string deviceName, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VisibilityModeChangedCallback(int result, int visibility, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VisibilityDurationChangedCallback(int duration, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DiscoveryStateChangedCallback(int result, BluetoothDeviceDiscoveryState state, IntPtr deviceInfo, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool BondedDeviceCallback([MarshalAs(UnmanagedType.Struct)]ref BluetoothDeviceStruct device, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void BondCreatedCallback(int result, [MarshalAs(UnmanagedType.Struct)]ref BluetoothDeviceStruct device, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void BondDestroyedCallback(int result, string deviceAddress, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void AuthorizationChangedCallback(int authorization, string deviceAddress, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ServiceSearchedCallback(int result, [MarshalAs(UnmanagedType.Struct)]ref BluetoothDeviceSdpStruct sdp, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DeviceConnectionStateChangedCallback(bool connected, [MarshalAs(UnmanagedType.Struct)]ref BluetoothDeviceConnectionStruct device, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ConnectedProfileCallback(int profile, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DataReceivedCallback([MarshalAs(UnmanagedType.Struct)]ref SocketDataStruct socketData, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SocketConnectionStateChangedCallback(int result, BluetoothSocketState connectionState, [MarshalAs(UnmanagedType.Struct)]ref SocketConnectionStruct socketConnection, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void AudioConnectionStateChangedCallback(int result, bool connected, string deviceAddress, int profileType, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ConnectionRequestedCallback(string deviceAddress, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PushRequestedCallback(string file, long size, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TransferProgressCallback(string file, long size, int percent, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TransferFinishedCallback(int result, string file, long size, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PushRespondedCallback(int result, string deviceAddress, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PushProgressCallback(string file, long size, int percent, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PushFinishedCallback(int result, string deviceAddress, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TargetConnectionStateChangedCallback(bool connected, string deviceAddress, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void EqualizerStateChangedCallback(int equalizer, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RepeatModeChangedCallback(int repeat, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ShuffleModeChangedCallback(int shuffle, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ScanModeChangedCallback(int scan, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void AvrcpControlConnectionChangedCallback(bool connected, string remoteAddress, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PositionChangedCallback(uint position, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PlayStatusChangedCallback(int play_status, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TrackInfoChangedCallback([MarshalAs(UnmanagedType.Struct)]ref TrackInfoStruct track, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ConnectionChangedCallback(int result, bool connected, string deviceAddress, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ClientCharacteristicValueChangedCallback(IntPtr characteristicHandle, string value, int len, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void GattClientRequestedCallback(int result, IntPtr handle, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool GattForEachCallback(int total, int index, IntPtr handle, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_initialize")]
        internal static extern int Initialize();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_deinitialize")]
        internal static extern int Deinitialize();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_enable")]
        internal static extern int EnableAdapter();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_disable")]
        internal static extern int DisableAdapter();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_get_name")]
        internal static extern int GetName(out string name);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_set_name")]
        internal static extern int SetName(string name);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_get_state")]
        internal static extern int GetState(out BluetoothState isActivated);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_get_address")]
        internal static extern int GetAddress(out string address);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_set_visibility")]
        internal static extern int SetVisibility(VisibilityMode visibilityMode, int duration);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_get_visibility")]
        internal static extern int GetVisibility(out int visibility, out int duration);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_is_discovering")]
        internal static extern int IsDiscovering(out bool isDiscovering);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_start_device_discovery")]
        internal static extern int StartDiscovery();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_stop_device_discovery")]
        internal static extern int StopDiscovery();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_foreach_bonded_device")]
        internal static extern int GetBondedDevices(BondedDeviceCallback bondedDeviceCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_get_bonded_device_info")]
        internal static extern int GetBondedDeviceByAddress(string deviceAddress, out IntPtr deviceInfo);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_free_device_info")]
        internal static extern int FreeDeviceInfo(IntPtr deviceInfo);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_is_service_used")]
        internal static extern int IsServiceUsed(string serviceUuid, out bool used);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_get_local_oob_data")]
        internal static extern int GetOobData(out IntPtr hash, out IntPtr randomizer, out int hashLen, out int randomizerLen);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_set_remote_oob_data")]
        internal static extern int SetOobData(string deviceAddress, IntPtr hash, IntPtr randomizer, int hashLen, int randomizerLen);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_remove_remote_oob_data")]
        internal static extern int RemoveOobData(string deviceAddress);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_set_state_changed_cb")]
        internal static extern int SetStateChangedCallback(StateChangedCallback stateChangedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_unset_state_changed_cb")]
        internal static extern int UnsetStateChangedCallback();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_set_name_changed_cb")]
        internal static extern int SetNameChangedCallback(NameChangedCallback nameChangedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_unset_name_changed_cb")]
        internal static extern int UnsetNameChangedCallback();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_set_visibility_mode_changed_cb")]
        internal static extern int SetVisibilityModeChangedCallback(VisibilityModeChangedCallback visibilityChangedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_unset_visibility_mode_changed_cb")]
        internal static extern int UnsetVisibilityModeChangedCallback();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_set_visibility_duration_changed_cb")]
        internal static extern int SetVisibilityDurationChangedCallback(VisibilityDurationChangedCallback durationChangedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_unset_visibility_duration_changed_cb")]
        internal static extern int UnsetVisibilityDurationChangedCallback();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_set_device_discovery_state_changed_cb")]
        internal static extern int SetDiscoveryStateChangedCallback(DiscoveryStateChangedCallback discoveryChangedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_unset_device_discovery_state_changed_cb")]
        internal static extern int UnsetDiscoveryStateChangedCallback();

        //Bluetooth Device
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_device_create_bond")]
        internal static extern int CreateBond(string deviceAddress);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_device_destroy_bond")]
        internal static extern int DestroyBond(string deviceAddress);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_device_cancel_bonding")]
        internal static extern int CancelBonding();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_device_set_alias")]
        internal static extern int SetAlias(string deviceAddress, string alias);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_device_set_authorization")]
        internal static extern int SetAuthorization(string deviceAddress, int state);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_device_get_service_mask_from_uuid_list")]
        internal static extern int GetMaskFromUuid([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 1)] string[] uuids, int count, out BluetoothServiceClassType serviceMask);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_device_start_service_search")]
        internal static extern int StartServiceSearch(string deviceAddress);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_device_foreach_connected_profiles")]
        internal static extern int GetConnectedProfiles(string deviceAddress, ConnectedProfileCallback connectedProfileCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_device_is_profile_connected")]
        internal static extern int IsProfileConnected(string deviceAddress, int profile, out bool connectionStatus);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_device_set_bond_created_cb")]
        internal static extern int SetBondCreatedCallback(BondCreatedCallback bondCreatedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_device_unset_bond_created_cb")]
        internal static extern int UnsetBondCreatedCallback();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_device_set_bond_destroyed_cb")]
        internal static extern int SetBondDestroyedCallback(BondDestroyedCallback bondDestroyedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_device_unset_bond_destroyed_cb")]
        internal static extern int UnsetBondDestroyedCallback();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_device_set_authorization_changed_cb")]
        internal static extern int SetAuthorizationChangedCallback(AuthorizationChangedCallback authorizationChangedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_device_unset_authorization_changed_cb")]
        internal static extern int UnsetAuthorizationChangedCallback();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_device_set_service_searched_cb")]
        internal static extern int SetServiceSearchedCallback(ServiceSearchedCallback serviceSearchedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_device_unset_service_searched_cb")]
        internal static extern int UnsetServiceSearchedCallback();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_device_set_connection_state_changed_cb")]
        internal static extern int SetConnectionStateChangedCallback(DeviceConnectionStateChangedCallback connectionChangedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_device_unset_connection_state_changed_cb")]
        internal static extern int UnsetConnectionStateChangedCallback();

        // Bluetooth LE Adapter

        //Callback for event
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void AdapterLeScanResultChangedCallBack(int result,
            [MarshalAs(UnmanagedType.Struct)]ref BluetoothLeScanDataStruct scanData, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void AdvertisingStateChangedCallBack(int result, IntPtr advertiserHandle,
                            BluetoothLeAdvertisingState advertisingState, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void GattConnectionStateChangedCallBack(int result, bool connected,
                                        string remoteAddress, IntPtr userData);

        //Bluetooth Le Adapter Apis
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_start_scan")]
        public static extern int StartScan(AdapterLeScanResultChangedCallBack callback, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_stop_scan")]
        public static extern int StopScan();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_set_scan_mode")]
        public static extern int SetLeScanMode(BluetoothLeScanMode mode);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_get_scan_result_service_uuids")]
        public static extern int GetScanResultServiceUuid(ref BluetoothLeScanDataStruct scanData,
            BluetoothLePacketType packetType, ref IntPtr uuids, ref int count);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_get_scan_result_device_name")]
        public static extern int GetLeScanResultDeviceName(ref BluetoothLeScanDataStruct scanData,
                            BluetoothLePacketType packetType, out string deviceName);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_get_scan_result_tx_power_level")]
        public static extern int GetScanResultTxPowerLevel(ref BluetoothLeScanDataStruct scanData,
                            BluetoothLePacketType packetType, out int txPowerLevel);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_get_scan_result_service_solicitation_uuids")]
        public static extern int GetScanResultSvcSolicitationUuids(ref BluetoothLeScanDataStruct scanData,
                            BluetoothLePacketType packetType, out IntPtr uuids, out int count);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_get_scan_result_service_data_list")]
        public static extern int GetScanResultServiceDataList(ref BluetoothLeScanDataStruct scanData,
                            BluetoothLePacketType PacketType, out IntPtr serviceDataArray, out int count);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_free_service_data_list")]
        public static extern int FreeServiceDataList(IntPtr serviceData, int count);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_get_scan_result_appearance")]
        public static extern int GetScanResultAppearance(ref BluetoothLeScanDataStruct scanData,
                            BluetoothLePacketType packetType, out int appearance);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_get_scan_result_manufacturer_data")]
        public static extern int GetScanResultManufacturerData(ref BluetoothLeScanDataStruct scanData,
                            BluetoothLePacketType packetType, out int manufId, out IntPtr manufData,
                            out int manufDataLength);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_connect")]
        internal static extern int GattConnect(string deviceAddress, bool autoConnect);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_disconnect")]
        internal static extern int GattDisconnect(string deviceAddress);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_set_connection_state_changed_cb")]
        internal static extern int SetGattConnectionStateChangedCallback(
            GattConnectionStateChangedCallBack gattConnectionChangedCb, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_unset_connection_state_changed_cb")]
        internal static extern int UnsetGattConnectionStateChangedCallback();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_create_advertiser")]
        public static extern int CreateAdvertiser(out IntPtr advertiserHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_destroy_advertiser")]
        public static extern int DestroyAdvertiser(IntPtr advertiserHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_add_advertising_service_uuid")]
        public static extern int AddAdvertisingServiceUuid(IntPtr advertiserHandle,
                                    BluetoothLePacketType PacketType, string uuid);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_add_advertising_service_solicitation_uuid")]
        public static extern int AddAdvertisingServiceSolicitationUuid(IntPtr advertiserHandle,
            BluetoothLePacketType PacketType, string uuid);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_add_advertising_service_data")]
        public static extern int AddAdvertisingServiceData(IntPtr advertiserHandle,
            BluetoothLePacketType PacketType, string uuid, IntPtr serviceData, int serviceDatalength);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_set_advertising_appearance")]
        public static extern int SetAdvertisingAppearance(IntPtr advertiserHandle,
                                    BluetoothLePacketType packetType, int appearance);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_add_advertising_manufacturer_data")]
        public static extern int AddAdvertisingManufData(IntPtr advertiserHandle, BluetoothLePacketType packetType,
            int manufId, IntPtr manufData, int manufacturerDataLength);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_set_advertising_device_name")]
        public static extern int SetAdvertisingDeviceName(IntPtr advertiserHandle, BluetoothLePacketType packetType,
                                                bool includeName);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_set_advertising_tx_power_level")]
        public static extern int SetAdvertisingTxPowerLevel(IntPtr advertiserHandle, BluetoothLePacketType packetType,
                                                bool includePowerLevel);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_clear_advertising_data")]
        public static extern int ClearAdvertisingData(IntPtr advertiserHandle, BluetoothLePacketType packetType);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_start_advertising_new")]
        public static extern int BluetoothLeStartAdvertising(IntPtr advertiserHandle,
                                         AdvertisingStateChangedCallBack callback, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_stop_advertising")]
        public static extern int BluetoothLeStopAdvertising(IntPtr advertiserHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_set_advertising_mode")]
        public static extern int SetAdvertisingMode(IntPtr advertiserHandle,
                                        BluetoothLeAdvertisingMode advertisingMode);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_adapter_le_set_advertising_connectable")]
        public static extern int SetAdvertisingConnectable(IntPtr advertiserHandle,
                                        bool connectable);

        //Bluetooth Socket
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SocketConnectionRequestedCallback(int socket_fd, string remoteAddress, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_socket_create_rfcomm")]
        internal static extern int CreateServerSocket(string serviceUuid, out int socketFd);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_socket_destroy_rfcomm")]
        internal static extern int DestroyServerSocket(int socketFd);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_socket_listen_and_accept_rfcomm")]
        internal static extern int Listen(int socketFd, int pendingConnections);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_socket_listen")]
        internal static extern int ListenWithoutAccept(int socketFd, int pendingConnections);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_socket_accept")]
        internal static extern int Accept(int socketFd);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_socket_reject")]
        internal static extern int Reject(int socketFd);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_socket_connect_rfcomm")]
        internal static extern int ConnectSocket(string address, string serviceUuid);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_socket_disconnect_rfcomm")]
        internal static extern int DisconnectSocket(int socketFd);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_socket_send_data")]
        internal static extern int SendData(int socketFd, string data, int dataLength);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_socket_send_data")]
        internal static extern int SendData(int socketFd, byte[] data, int dataLength);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_socket_set_data_received_cb")]
        internal static extern int SetDataReceivedCallback(DataReceivedCallback callback, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_socket_unset_data_received_cb")]
        internal static extern int UnsetDataReceivedCallback();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_socket_set_connection_state_changed_cb")]
        internal static extern int SetConnectionStateChangedCallback(SocketConnectionStateChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_socket_unset_connection_state_changed_cb")]
        internal static extern int UnsetSocketConnectionStateChangedCallback();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_socket_set_connection_requested_cb")]
        internal static extern int SetSocketConnectionRequestedCallback(SocketConnectionRequestedCallback socketConnectionRequestedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_socket_unset_connection_requested_cb")]
        internal static extern int UnsetSocketConnectionRequestedCallback();

        // Bluetooth Audio
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void AgScoStateChangedCallback(int result, bool opened, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_audio_initialize")]
        internal static extern int InitializeAudio();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_audio_deinitialize")]
        internal static extern int DeinitializeAudio();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_audio_connect")]
        internal static extern int Connect(string deviceAddress, int profileType);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_audio_disconnect")]
        internal static extern int Disconnect(string deviceAddress, int profileType);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_audio_set_connection_state_changed_cb")]
        internal static extern int SetAudioConnectionStateChangedCallback(AudioConnectionStateChangedCallback audioStateChangedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_audio_unset_connection_state_changed_cb")]
        internal static extern int UnsetAudioConnectionStateChangedCallback();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_ag_open_sco")]
        internal static extern int OpenAgSco();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_ag_close_sco")]
        internal static extern int CloseAgSco();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_ag_is_sco_opened")]
        internal static extern int IsAgScoOpened(out bool opened);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_ag_set_sco_state_changed_cb")]
        internal static extern int SetAgScoStateChangedCallback(AgScoStateChangedCallback scoStateChangedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_ag_unset_sco_state_changed_cb")]
        internal static extern int UnsetAgScoStateChangedCallback();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_ag_notify_voice_recognition_state")]
        internal static extern int NotifyAgVoiceRecognitionState(bool enable);

        // Bluetooth Hid
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void HidConnectionStateChangedCallback(int result, bool connected, string deviceAddress, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void HidDeviceConnectionStateChangedCallback(int result, bool connected, string deviceAddress, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void HidDeviceDataReceivedCallback(ref BluetoothHidDeviceReceivedDataStruct receivedData, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_hid_host_initialize")]
        internal static extern int InitializeHid(HidConnectionStateChangedCallback hidConnectionChangedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_hid_host_deinitialize")]
        internal static extern int DeinitializeHid();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_hid_host_connect")]
        internal static extern int Connect(string deviceAddress);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_hid_host_disconnect")]
        internal static extern int Disconnect(string deviceAddress);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_hid_device_activate")]
        internal static extern int ActivateHidDevice(HidDeviceConnectionStateChangedCallback stateChangedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_hid_device_deactivate")]
        internal static extern int DeactivateHidDevice();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_hid_device_connect")]
        internal static extern int ConnectHidDevice(string deviceAddress);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_hid_device_disconnect")]
        internal static extern int DisconnectHidDevice(string deviceAddress);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_hid_device_send_mouse_event")]
        internal static extern int SendHidDeviceMouseEvent(string deviceAddress, BluetoothHidMouseData mouseData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_hid_device_send_key_event")]
        internal static extern int SendHidDeviceKeyEvent(string deviceAddress, BluetoothHidKeyData keyData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_hid_device_set_data_received_cb")]
        internal static extern int SetHidDeviceDataReceivedCallback(HidDeviceDataReceivedCallback dataReceivedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_hid_device_unset_data_received_cb")]
        internal static extern int UnsetHidDeviceDataReceivedCallback();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_hid_device_reply_to_report")]
        internal static extern int ReplyToReportHidDevice(string deviceAddress, BluetoothHidHeaderType headerType, BluetoothHidParamType paramType, byte[] value, int len, IntPtr userData);

        // Bluetooth OPP
        // Opp Server
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_opp_server_initialize")]
        internal static extern int InitializeOppServer(string deviceAddress, PushRequestedCallback pushRequestedCb, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_opp_server_deinitialize")]
        internal static extern int DinitializeOppServer();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_opp_server_initialize_by_connection_request")]
        internal static extern int InitializeOppServerCustom(string deviceAddress, ConnectionRequestedCallback connectionRequestedCb, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_opp_server_accept")]
        internal static extern int OppServerAcceptPush(TransferProgressCallback transferProgressCb, TransferFinishedCallback transferFinishedCb, string name, IntPtr userData, out int transferId);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_opp_server_reject")]
        internal static extern int OppServerRejectPush();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_opp_server_cancel_transfer")]
        internal static extern int OppServerCancelTransfer(int transferId);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_opp_server_set_destination")]
        internal static extern int OppServerSetDestinationPath(string path);

        // Opp Client
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_opp_client_initialize")]
        internal static extern int InitializeOppClient();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_opp_client_deinitialize")]
        internal static extern int DeinitializeOppClient();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_opp_client_add_file")]
        internal static extern int OppClientAddFile(string filePath);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_opp_client_clear_files")]
        internal static extern int OppClientClearFiles();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_opp_client_cancel_push")]
        internal static extern int OppClientCancelPush();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_opp_client_push_files")]
        internal static extern int OppClientPushFile(string filePath, PushRespondedCallback pushRespondedCb, PushProgressCallback pushProgressCb, PushFinishedCallback pushFinishedCb, IntPtr userData);

        //Bluetooth Avrcp
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_target_initialize")]
        internal static extern int InitializeAvrcp(TargetConnectionStateChangedCallback targetStateChangedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_target_deinitialize")]
        internal static extern int DeinitializeAvrcp();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_target_notify_equalizer_state")]
        internal static extern int NotifyEqualizerState(int state);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_target_notify_repeat_mode")]
        internal static extern int NotifyRepeatMode(int repeat);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_target_notify_shuffle_mode")]
        internal static extern int NotifyShuffleMode(int shuffle);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_target_notify_scan_mode")]
        internal static extern int NotifyScanMode(int scan);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_target_notify_player_state")]
        internal static extern int NotifyPlayerState(int state);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_target_notify_position")]
        internal static extern int NotifyCurrentPosition(uint position);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_target_notify_track")]
        internal static extern int NotifyTrack(string title, string artist, string album, string genre, uint trackNum, uint totaltracks, uint duration);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_set_equalizer_state_changed_cb")]
        internal static extern int SetEqualizerStateChangedCallback(EqualizerStateChangedCallback equalizerStateChangedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_unset_equalizer_state_changed_cb")]
        internal static extern int UnsetEqualizerStateChangedCallback();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_set_repeat_mode_changed_cb")]
        internal static extern int SetRepeatModeChangedCallback(RepeatModeChangedCallback repeatModeChangedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_unset_repeat_mode_changed_cb")]
        internal static extern int UnsetRepeatModeChangedCallback();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_set_shuffle_mode_changed_cb")]
        internal static extern int SetShuffleModeChangedCallback(ShuffleModeChangedCallback shuffleModeChangedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_unset_shuffle_mode_changed_cb")]
        internal static extern int UnsetShuffleModeChangedCallback();
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_set_scan_mode_changed_cb")]
        internal static extern int SetScanModeChangedCallback(ScanModeChangedCallback scanModeChangedCb, IntPtr userData);
        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_unset_scan_mode_changed_cb")]
        internal static extern int UnsetScanModeChangedCallback();

        // Bluetooth AVRCP Control

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_initialize")]
        internal static extern int AvrcpControlInitialize(AvrcpControlConnectionChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_deinitialize")]
        internal static extern int AvrcpControlDeinitialize();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_connect")]
        internal static extern int AvrcpControlConnect(string address);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_disconnect")]
        internal static extern int AvrcpControlDisconnect(string address);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_set_equalizer_state")]
        internal static extern int SetEqualizerState(EqualizerState state);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_get_equalizer_state")]
        internal static extern int GetEqualizerState(out EqualizerState state);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_set_repeat_mode")]
        internal static extern int SetRepeatMode(RepeatMode mode);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_get_repeat_mode")]
        internal static extern int GetRepeatMode(out RepeatMode mode);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_set_shuffle_mode")]
        internal static extern int SetShuffleMode(ShuffleMode mode);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_get_shuffle_mode")]
        internal static extern int GetShuffleMode(out ShuffleMode mode);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_set_scan_mode")]
        internal static extern int SetScanMode(ScanMode mode);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_get_scan_mode")]
        internal static extern int GetScanMode(out ScanMode mode);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_get_position")]
        internal static extern int GetPosition(out uint position);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_get_play_status")]
        internal static extern int GetPlayStatus(out PlayerState state);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_get_track_info")]
        internal static extern int GetTrackInfo(out IntPtr infoptr);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_free_track_info")]
        internal static extern int FreeTrackInfo(IntPtr infoptr);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_send_player_command")]
        internal static extern int SendPlayerCommand(PlayerCommand command);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_send_player_command_to")]
        internal static extern int SendPlayerCommandTo(PlayerCommand command, string remoteAddress);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_set_absolute_volume")]
        internal static extern int SetAbsoluteVolume(uint volume);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_increase_volume")]
        internal static extern int IncreaseVolume();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_decrease_volume")]
        internal static extern int DecreaseVolume();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_control_send_delay_report")]
        internal static extern int SendDelayReport(uint value);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_set_position_changed_cb")]
        internal static extern int SetPositionChangedCallback(PositionChangedCallback PositionChangedCb, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_unset_position_changed_cb")]
        internal static extern int UnsetPositionChangedCallback();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_set_play_status_changed_cb")]
        internal static extern int SetPlayStatusChangedCallback(PlayStatusChangedCallback PlayStatusChangedCb, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_unset_play_status_changed_cb")]
        internal static extern int UnsetPlayStatusChangedCallback();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_set_track_info_changed_cb")]
        internal static extern int SetTrackInfoChangedCallback(TrackInfoChangedCallback TrackInfoChangedCb, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_avrcp_unset_track_info_changed_cb")]
        internal static extern int UnsetTrackInfoChangedCallback();

        // Bluetooth GATT

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate bool BtGattForeachCallback(int total, int index, IntPtr gattHandle, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void BtGattServerReadValueRequestedCallback(string clientAddress, int requestId, IntPtr serverHandle, IntPtr gattHandle, int offset, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void BtGattServerWriteValueRequestedCallback(string clientAddress, int requestId, IntPtr serverHandle, IntPtr gattHandle, bool response_needed, int offset, IntPtr value, int len, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void BtClientCharacteristicValueChangedCallback(IntPtr characteristicHandle, IntPtr value, int len, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void BtGattServerNotificationStateChangeCallback(bool notify, IntPtr serverHandle, IntPtr characteristicHandle, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void BtGattServerNotificationSentCallback(int result, string clientAddress, IntPtr serverHandle, IntPtr characteristicHandle, bool completed, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void BtGattClientRequestCompletedCallback(int result, IntPtr requestHandle, IntPtr userData);

        // Gatt Attribute

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_destroy")]
        internal static extern int BtGattDestroy(IntPtr gattHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_get_uuid")]
        internal static extern int BtGattGetUuid(BluetoothGattAttributeHandle gattHandle, out string uuid);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_get_value")]
        internal static extern int BtGattGetValue(BluetoothGattAttributeHandle gattHandle, out IntPtr nativeValue, out int valueLength);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_set_value")]
        internal static extern int BtGattSetValue(BluetoothGattAttributeHandle gattHandle, byte[] value, int valueLength);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_get_int_value")]
        internal static extern int BtGattGetIntValue(BluetoothGattAttributeHandle gattHandle, int type, int offset, out int value);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_set_int_value")]
        internal static extern int BtGattSetIntValue(BluetoothGattAttributeHandle gattHandle, int type, int value, int offset);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_get_float_value")]
        internal static extern int BtGattGetFloatValue(BluetoothGattAttributeHandle gattHandle, int type, int offset, out float value);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_set_float_value")]
        internal static extern int BtGattSetFloatValue(BluetoothGattAttributeHandle gattHandle, int type, int mantissa, int exponent, int offset);

        // GATT Descriptor

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_descriptor_create")]
        internal static extern int BtGattDescriptorCreate(string uuid, int permissions, byte[] value, int valueLength, out BluetoothGattAttributeHandle descriptorHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_descriptor_get_permissions")]
        internal static extern int BtGattDescriptorGetPermissions(BluetoothGattAttributeHandle descriptorHandle, out int permissions);

        // GATT Characteristic

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_characteristic_create")]
        internal static extern int BtGattCharacteristicCreate(string uuid, int permissions, int properties, byte[] value, int valueLength, out BluetoothGattAttributeHandle characteristicHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_characteristic_get_permissions")]
        internal static extern int BtGattCharacteristicGetPermissions(BluetoothGattAttributeHandle characteristicHandle, out int permissions);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_characteristic_get_properties")]
        internal static extern int BtGattCharacteristicGetProperties(BluetoothGattAttributeHandle characteristicHandle, out int properties);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_characteristic_set_properties")]
        internal static extern int BtGattCharacteristicSetProperties(BluetoothGattAttributeHandle characteristicHandle, int properties);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_characteristic_get_write_type")]
        internal static extern int BtGattCharacteristicGetWriteType(BluetoothGattAttributeHandle characteristicHandle, out int writeType);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_characteristic_set_write_type")]
        internal static extern int BtGattCharacteristicSetWriteType(BluetoothGattAttributeHandle characteristicHandle, int writeType);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_characteristic_add_descriptor")]
        internal static extern int BtGattCharacteristicAddDescriptor(BluetoothGattAttributeHandle characteristicHandle, BluetoothGattAttributeHandle descriptorHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_characteristic_get_descriptor")]
        internal static extern int BtGattCharacteristicGetDescriptor(BluetoothGattAttributeHandle characteristicHandle, string uuid, out BluetoothGattAttributeHandle descriptorHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_characteristic_foreach_descriptors")]
        internal static extern int BtGattCharacteristicForeachDescriptors(BluetoothGattAttributeHandle characteristicHandle, BtGattForeachCallback callback, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_client_set_characteristic_value_changed_cb")]
        internal static extern int BtGattClientSetCharacteristicValueChangedCallback(BluetoothGattAttributeHandle characteristicHandle, BtClientCharacteristicValueChangedCallback cb, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_client_unset_characteristic_value_changed_cb")]
        internal static extern int BtGattClientUnsetCharacteristicValueChangedCallback(BluetoothGattAttributeHandle characteristicHandle);

        // GATT Service

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_service_create")]
        internal static extern int BtGattServiceCreate(string uuid, int type, out BluetoothGattAttributeHandle serviceHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_service_add_characteristic")]
        internal static extern int BtGattServiceAddCharacteristic(BluetoothGattAttributeHandle serviceHandle, BluetoothGattAttributeHandle characteristicHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_service_get_characteristic")]
        internal static extern int BtGattServiceGetCharacteristic(BluetoothGattAttributeHandle serviceHandle, string uuid, out BluetoothGattAttributeHandle characteristicHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_service_foreach_characteristics")]
        internal static extern int BtGattServiceForeachCharacteristics(BluetoothGattAttributeHandle serviceHandle, BtGattForeachCallback callback, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_service_add_included_service")]
        internal static extern int BtGattServiceAddIncludedService(BluetoothGattAttributeHandle serviceHandle, BluetoothGattAttributeHandle includedServiceHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_service_get_included_service")]
        internal static extern int BtGattServiceGetIncludedService(BluetoothGattAttributeHandle serviceHandle, string uuid, out BluetoothGattAttributeHandle includedServiceHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_service_foreach_included_services")]
        internal static extern int BtGattServiceForeachIncludedServices(BluetoothGattAttributeHandle serviceHandle, BtGattForeachCallback callback, IntPtr userData);

        // GATT Client

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_client_destroy")]
        internal static extern int BtGattClientDestroy(IntPtr clientHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_client_create")]
        internal static extern int BtGattClientCreate(string remoteAddress, out BluetoothGattClientHandle clientHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_client_get_remote_address")]
        internal static extern int BtGattClientGetRemoteAddress(BluetoothGattClientHandle clientHandle, out string remoteAddress);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_client_get_service")]
        internal static extern int BtGattClientGetService(BluetoothGattClientHandle clientHandle, string uuid, out BluetoothGattAttributeHandle serviceHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_client_foreach_services")]
        internal static extern int BtGattClientForeachServices(BluetoothGattClientHandle clientHandle, BtGattForeachCallback callback, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_client_read_value")]
        internal static extern int BtGattClientReadValue(BluetoothGattAttributeHandle gattHandle, BtGattClientRequestCompletedCallback callback, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_client_write_value")]
        internal static extern int BtGattClientWriteValue(BluetoothGattAttributeHandle gattHandle, BtGattClientRequestCompletedCallback callback, IntPtr userData);

        // GATT Server

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_server_destroy")]
        internal static extern int BtGattServerDestroy(IntPtr serverHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_server_create")]
        internal static extern int BtGattServerCreate(out BluetoothGattServerHandle serverHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_server_initialize")]
        internal static extern int BtGattServerInitialize();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_server_deinitialize")]
        internal static extern int BtGattServerDeinitialize();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_server_set_read_value_requested_cb")]
        internal static extern int BtGattServerSetReadValueRequestedCallback(BluetoothGattAttributeHandle gattHandle, BtGattServerReadValueRequestedCallback callback, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_server_set_write_value_requested_cb")]
        internal static extern int BtGattServerSetWriteValueRequestedCallback(BluetoothGattAttributeHandle gattHandle, BtGattServerWriteValueRequestedCallback callback, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_server_set_characteristic_notification_state_change_cb")]
        internal static extern int BtGattServeSetNotificationStateChangeCallback(BluetoothGattAttributeHandle characteristicHandle, BtGattServerNotificationStateChangeCallback callback, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_server_start")]
        internal static extern int BtGattServerStart();

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_server_register_service")]
        internal static extern int BtGattServerRegisterService(BluetoothGattServerHandle serverHandle, BluetoothGattAttributeHandle serviceHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_server_unregister_service")]
        internal static extern int BtGattServerUnregisterService(BluetoothGattServerHandle serverHandle, BluetoothGattAttributeHandle serviceHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_server_unregister_all_services")]
        internal static extern int BtGattServerUnregisterAllServices(BluetoothGattServerHandle serverHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_server_get_service")]
        internal static extern int BtGattServerGetService(BluetoothGattServerHandle serverHandle, string uuid, out BluetoothGattAttributeHandle serviceHandle);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_server_foreach_services")]
        internal static extern int BtGattServerForeachServices(BluetoothGattServerHandle serverHandle, BtGattForeachCallback callback, IntPtr userData);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_server_send_response")]
        internal static extern int BtGattServerSendResponse(int requestId, int requestType, int offset, int status, byte[] value, int valueLen);

        [DllImport(Libraries.Bluetooth, EntryPoint = "bt_gatt_server_notify_characteristic_changed_value")]
        internal static extern int BtGattServerNotify(BluetoothGattAttributeHandle characteristicHandle, BtGattServerNotificationSentCallback callback, string clientAddress, IntPtr userData);
    }
}


