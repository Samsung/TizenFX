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
    internal static partial class Nfc
    {
        //Callback for async method
        //nfc_activation_completed_cb
        //nfc_tag_write_completed_cb
        //nfc_tag_format_completed_cb
        //nfc_mifare_authenticate_with_keyA_completed_cb
        //nfc_mifare_authenticate_with_keyB_completed_cb
        //nfc_mifare_write_block_completed_cb
        //nfc_mifare_write_page_completed_cb
        //nfc_mifare_increment_completed_cb
        //nfc_mifare_decrement_completed_cb
        //nfc_mifare_transfer_completed_cb
        //nfc_mifare_restore_completed_cb
        //nfc_p2p_send_completed_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VoidCallback(int result, IntPtr userData);
        //nfc_tag_information_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool TagInformationCallback(IntPtr key, IntPtr value, int valueSize, IntPtr userData);
        //nfc_tag_transceive_completed_cb
        //nfc_mifare_read_block_completed_cb
        //nfc_mifare_read_page_completed_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TagTransceiveCompletedCallback(int result, IntPtr value, int bufferSize, IntPtr userData);
        //nfc_tag_read_completed_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool TagReadCompletedCallback(int result, IntPtr message, IntPtr userData);
        //nfc_snep_event_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SnepEventCallback(IntPtr handle, int snepEvent, int result, IntPtr message, IntPtr userData);
        //nfc_se_registered_aid_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SecureElementRegisteredAidCallback(int seType, IntPtr aid, bool readOnly, IntPtr userData);


        //Callback for event
        //nfc_activation_changed_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ActivationChangedCallback(bool activated, IntPtr userData);
        //nfc_tag_discovered_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TagDiscoveredCallback(int type, IntPtr tag, IntPtr userData);
        //nfc_p2p_target_discovered_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void P2pTargetDiscoveredCallback(int type, IntPtr p2pTaget, IntPtr userData);
        //nfc_ndef_discovered_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void NdefMessageDiscoveredCallback(IntPtr message, IntPtr userData);
        //nfc_se_event_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SecureElementEventCallback(int eventType, IntPtr userData);
        //nfc_se_transaction_event_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SecureElementTransactionEventCallback(int type, IntPtr aid, int aidSize, IntPtr param, int paramSize, IntPtr userData);
        //nfc_p2p_data_received_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void P2pDataReceivedCallback(IntPtr target, IntPtr message, IntPtr userData);
        //nfc_hce_event_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void HostCardEmulationEventCallback(IntPtr handle, int eventType, IntPtr apdu, uint apduLen, IntPtr userData);

        //capi-network-nfc-0.2.5-6.1.armv7l
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_initialize")]
        internal static extern int Initialize();
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_deinitialize")]
        internal static extern int Deinitialize();

        ////Nfc Manager
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_is_supported")]
        internal static extern bool IsSupported();
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_activation")]
        internal static extern int SetActivation(bool activation, VoidCallback callback, IntPtr userData);
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_is_activated")]
        internal static extern bool IsActivated();
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_activation_changed_cb")]
        internal static extern int SetActivationChangedCallback(ActivationChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_unset_activation_changed_cb")]
        internal static extern void UnsetActivationChangedCallback();
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_tag_discovered_cb")]
        internal static extern int SetTagDiscoveredCallback(TagDiscoveredCallback callback, IntPtr userData);
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_unset_tag_discovered_cb")]
        internal static extern void UnsetTagDiscoveredCallback();
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_ndef_discovered_cb")]
        internal static extern int SetNdefDiscoveredCallback(NdefMessageDiscoveredCallback callback, IntPtr userData);
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_unset_ndef_discovered_cb")]
        internal static extern void UnsetNdefDiscoveredCallback();
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_p2p_target_discovered_cb")]
        internal static extern int SetP2pTargetDiscoveredCallback(P2pTargetDiscoveredCallback callback, IntPtr userData);
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_unset_p2p_target_discovered_cb")]
        internal static extern void UnsetP2pTargetDiscoveredCallback();
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_se_event_cb")]
        internal static extern int SetSecureElementEventCallback(SecureElementEventCallback callback, IntPtr userData);
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_unset_se_event_cb")]
        internal static extern void UnsetSecureElementEventCallback();
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_se_transaction_event_cb")]
        internal static extern int SetSecureElementTransactionEventCallback(int setype, SecureElementTransactionEventCallback callback, IntPtr userData);
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_unset_se_transaction_event_cb")]
        internal static extern int UnsetSecureElementTransactionEventCallback(int setype);
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_hce_event_cb")]
        internal static extern int SetHostCardEmulationEventCallback(HostCardEmulationEventCallback callback, IntPtr userData);
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_unset_hce_event_cb")]
        internal static extern void UnsetHostCardEmulationEventCallback();
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_enable_transaction_fg_dispatch")]
        internal static extern int EnableTransactionForegroundDispatch();
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_disable_transaction_fg_dispatch")]
        internal static extern int DisableTransactionForegroundDispatch();
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_get_cached_message")]
        internal static extern int GetCachedMessage(out IntPtr ndefMessage);
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_tag_filter")]
        internal static extern void SetTagFilter(int filter);
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_get_tag_filter")]
        internal static extern int GetTagFilter();
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_get_connected_tag")]
        internal static extern int GetConnectedTag(out IntPtr tag);
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_get_connected_target")]
        internal static extern int GetConnectedTarget(out IntPtr target);
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_system_handler_enable")]
        internal static extern int SetSystemHandlerEnable(bool enable);
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_is_system_handler_enabled")]
        internal static extern bool IsSystemHandlerEnabled();
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_se_type")]
        internal static extern int SetSecureElementType(int type);
        [DllImport(Libraries.Nfc, EntryPoint = "nfc_manager_get_se_type")]
        internal static extern int GetSecureElementType(out int type);

        ////NDEF - NFC Data Exchange Format, TNF - Type Name Format
        internal static class NdefRecord
        {
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_create")]
            internal static extern int Create(out IntPtr record, int tnf, byte[] type, int typeSize, byte[] id, int idSize, byte[] payload, uint payloadSize);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_create_text")]
            internal static extern int CreateText(out IntPtr record, string text, string languageCode, int encode);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_create_uri")]
            internal static extern int CreateUri(out IntPtr record, string uri);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_create_mime")]
            internal static extern int CreateMime(out IntPtr record, string mimeType, byte[] data, uint dataSize);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_destroy")]
            internal static extern int Destroy(IntPtr record);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_set_id")]
            internal static extern int SetId(IntPtr record, byte[] id, int idSize);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_get_id")]
            internal static extern int GetId(IntPtr record, out IntPtr id, out int size);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_get_payload")]
            internal static extern int GetPayload(IntPtr record, out IntPtr payload, out uint size);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_get_type")]
            internal static extern int GetType(IntPtr record, out IntPtr type, out int size);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_get_tnf")]
            internal static extern int GetTnf(IntPtr record, out int tnf);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_get_text")]
            internal static extern int GetText(IntPtr record, out string text);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_get_langcode")]
            internal static extern int GetLanguageCode(IntPtr record, out string languageCode);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_get_encode_type")]
            internal static extern int GetEncodeType(IntPtr record, out int encode);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_get_uri")]
            internal static extern int GetUri(IntPtr record, out string uri);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_get_mime_type")]
            internal static extern int GetMimeType(IntPtr record, out string mimeType);
        }

        internal static class NdefMessage
        {
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_message_create")]
            internal static extern int Create(out IntPtr ndefMessage);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_message_create_from_rawdata")]
            internal static extern int CreateRawData(out IntPtr ndefMessage, byte[] rawData, uint rawDataSize);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_message_destroy")]
            internal static extern int Destroy(IntPtr ndefMessage);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_message_get_record_count")]
            internal static extern int GetRecordCount(IntPtr ndefMessage, out int count);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_message_get_rawdata")]
            internal static extern int GetRawData(IntPtr ndefMessage, out IntPtr rawData, out uint rawDataSize);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_message_append_record")]
            internal static extern int AppendRecord(IntPtr ndefMessage, IntPtr record);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_message_insert_record")]
            internal static extern int InsertRecord(IntPtr ndefMessage, int index, IntPtr record);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_message_remove_record")]
            internal static extern int RemoveRecord(IntPtr ndefMessage, int index);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_ndef_message_get_record")]
            internal static extern int GetRecord(IntPtr ndefMessage, int index, out IntPtr record);
        }

        internal static class Tag
        {
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_tag_get_type")]
            internal static extern int GetType(IntPtr tag, out int type);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_tag_is_support_ndef")]
            internal static extern int IsSupportNdef(IntPtr tag, out bool isSupported);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_tag_get_maximum_ndef_size")]
            internal static extern int GetMaximumNdefSize(IntPtr tag, out uint maximunNdefBytesSize);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_tag_get_ndef_size")]
            internal static extern int GetNdefSize(IntPtr tag, out uint ndefBytesSize);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_tag_foreach_information")]
            internal static extern int ForeachInformation(IntPtr tag, TagInformationCallback callback, IntPtr userData);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_tag_transceive")]
            internal static extern int Transceive(IntPtr tag, byte[] buffer, int bufferSize, TagTransceiveCompletedCallback callback, IntPtr userData);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_tag_read_ndef")]
            internal static extern int ReadNdef(IntPtr tag, TagReadCompletedCallback callback, IntPtr userData);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_tag_write_ndef")]
            internal static extern int WriteNdef(IntPtr tag, IntPtr ndefMessage, VoidCallback callback, IntPtr userData);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_tag_format_ndef")]
            internal static extern int FormatNdef(IntPtr tag, byte[] key, int kyeSize, VoidCallback callback, IntPtr userData);

            ////Mifare
        }

        ////SNEP - Simple NDEF Exchange Protocol
        internal static class P2p
        {
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_p2p_set_data_received_cb")]
            internal static extern int SetDataReceivedCallback(IntPtr target, P2pDataReceivedCallback callback, IntPtr userData);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_p2p_unset_data_received_cb")]
            internal static extern int UnsetDataReceivedCallback(IntPtr target);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_p2p_send")]
            internal static extern int Send(IntPtr target, IntPtr ndefMessage, VoidCallback callback, IntPtr userData);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_snep_start_server")]
            internal static extern int SnepStartServer(IntPtr target, string san, int sap, SnepEventCallback callback, IntPtr userData);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_snep_start_client")]
            internal static extern int SnepStartClient(IntPtr target, string san, int sap, SnepEventCallback callback, IntPtr userData);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_snep_send_client_request")]
            internal static extern int SnepSendClientRequest(IntPtr snepHandle, int type, IntPtr ndefMessage, SnepEventCallback callback, IntPtr userData);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_snep_stop_service")]
            internal static extern int SnepStopService(IntPtr target, IntPtr snepHandle);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_snep_register_server")]
            internal static extern int SnepRegisterServer(string san, int sap, SnepEventCallback callback, IntPtr userData);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_snep_unregister_server")]
            internal static extern int SnepUnregisterServer(string sam, int sap);
        }

        ////SE - Secure Element, HCE - Host Card Emulation, APDU - Application Protocol Data Unit, AID - Application Identifier
        internal static class CardEmulation
        {
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_se_enable_card_emulation")]
            internal static extern int EnableCardEmulation();
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_se_disable_card_emulation")]
            internal static extern int DisableCardEmulatiion();
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_se_get_card_emulation_mode")]
            internal static extern int GetCardEmulationMode(out int type);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_hce_send_apdu_response")]
            internal static extern int HceSendApduRespondse(IntPtr seHandle, byte[] response, uint responseLength);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_se_set_default_route")]
            internal static extern int SetDefaultRoute(int poweredOnStatus, int poweredOffStatus, int lowBatteryStatus);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_se_is_activated_handler_for_aid")]
            internal static extern int IsActivatedHandlerForAid(int seType, string aid, out bool isActivatedHandler);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_se_is_activated_handler_for_category")]
            internal static extern int IsActivatedHandlerForCategory(int seType, int category, out bool isActivatedHandler);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_se_register_aid")]
            internal static extern int RegisterAid(int seType, int category, string aid);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_se_unregister_aid")]
            internal static extern int UnregisterAid(int seType, int category, string aid);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_se_foreach_registered_aids")]
            internal static extern int ForeachRegisterdAids(int seType, int category, SecureElementRegisteredAidCallback callback, IntPtr userData);
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_se_set_preferred_handler")]
            internal static extern int SetPreferredHandler();
            [DllImport(Libraries.Nfc, EntryPoint = "nfc_se_unset_preferred_handler")]
            internal static extern int UnsetPreferredHandler();
        }
    }
}
