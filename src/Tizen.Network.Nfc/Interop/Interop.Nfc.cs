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
        [return: MarshalAs(UnmanagedType.U1)] internal delegate bool TagInformationCallback(IntPtr key, IntPtr value, int valueSize, IntPtr userData);
        //nfc_tag_transceive_completed_cb
        //nfc_mifare_read_block_completed_cb
        //nfc_mifare_read_page_completed_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TagTransceiveCompletedCallback(int result, IntPtr value, int bufferSize, IntPtr userData);
        //nfc_tag_read_completed_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)] internal delegate bool TagReadCompletedCallback(int result, IntPtr message, IntPtr userData);
        //nfc_snep_event_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SnepEventCallback(IntPtr handle, int snepEvent, int result, IntPtr message, IntPtr userData);
        //nfc_se_registered_aid_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SecureElementRegisteredAidCallback(int seType, IntPtr aid, [MarshalAs(UnmanagedType.U1)] bool readOnly, IntPtr userData);


        //Callback for event
        //nfc_activation_changed_cb
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ActivationChangedCallback([MarshalAs(UnmanagedType.U1)] bool activated, IntPtr userData);
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
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_initialize")]
        internal static partial int Initialize();
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_deinitialize")]
        internal static partial int Deinitialize();

        ////Nfc Manager
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_is_supported")]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static partial bool IsSupported();
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_activation")]
        internal static partial int SetActivation([MarshalAs(UnmanagedType.U1)] bool activation, VoidCallback callback, IntPtr userData);
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_is_activated")]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static partial bool IsActivated();
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_activation_changed_cb")]
        internal static partial int SetActivationChangedCallback(ActivationChangedCallback callback, IntPtr userData);
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_unset_activation_changed_cb")]
        internal static partial void UnsetActivationChangedCallback();
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_tag_discovered_cb")]
        internal static partial int SetTagDiscoveredCallback(TagDiscoveredCallback callback, IntPtr userData);
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_unset_tag_discovered_cb")]
        internal static partial void UnsetTagDiscoveredCallback();
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_ndef_discovered_cb")]
        internal static partial int SetNdefDiscoveredCallback(NdefMessageDiscoveredCallback callback, IntPtr userData);
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_unset_ndef_discovered_cb")]
        internal static partial void UnsetNdefDiscoveredCallback();
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_p2p_target_discovered_cb")]
        internal static partial int SetP2pTargetDiscoveredCallback(P2pTargetDiscoveredCallback callback, IntPtr userData);
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_unset_p2p_target_discovered_cb")]
        internal static partial void UnsetP2pTargetDiscoveredCallback();
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_se_event_cb")]
        internal static partial int SetSecureElementEventCallback(SecureElementEventCallback callback, IntPtr userData);
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_unset_se_event_cb")]
        internal static partial void UnsetSecureElementEventCallback();
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_se_transaction_event_cb")]
        internal static partial int SetSecureElementTransactionEventCallback(int setype, SecureElementTransactionEventCallback callback, IntPtr userData);
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_unset_se_transaction_event_cb")]
        internal static partial int UnsetSecureElementTransactionEventCallback(int setype);
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_hce_event_cb")]
        internal static partial int SetHostCardEmulationEventCallback(HostCardEmulationEventCallback callback, IntPtr userData);
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_unset_hce_event_cb")]
        internal static partial void UnsetHostCardEmulationEventCallback();
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_enable_transaction_fg_dispatch")]
        internal static partial int EnableTransactionForegroundDispatch();
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_disable_transaction_fg_dispatch")]
        internal static partial int DisableTransactionForegroundDispatch();
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_get_cached_message")]
        internal static partial int GetCachedMessage(out IntPtr ndefMessage);
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_tag_filter")]
        internal static partial void SetTagFilter(int filter);
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_get_tag_filter")]
        internal static partial int GetTagFilter();
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_get_connected_tag")]
        internal static partial int GetConnectedTag(out IntPtr tag);
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_get_connected_target")]
        internal static partial int GetConnectedTarget(out IntPtr target);
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_system_handler_enable")]
        internal static partial int SetSystemHandlerEnable([MarshalAs(UnmanagedType.U1)] bool enable);
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_is_system_handler_enabled")]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static partial bool IsSystemHandlerEnabled();
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_set_se_type")]
        internal static partial int SetSecureElementType(int type);
        [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_manager_get_se_type")]
        internal static partial int GetSecureElementType(out int type);

        ////NDEF - NFC Data Exchange Format, TNF - Type Name Format
        internal static partial class NdefRecord
        {
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_create")]
            internal static partial int Create(out IntPtr record, int tnf, byte[] type, int typeSize, byte[] id, int idSize, byte[] payload, uint payloadSize);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_create_text", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int CreateText(out IntPtr record, string text, string languageCode, int encode);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_create_uri", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int CreateUri(out IntPtr record, string uri);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_create_mime", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int CreateMime(out IntPtr record, string mimeType, byte[] data, uint dataSize);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_destroy")]
            internal static partial int Destroy(IntPtr record);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_set_id")]
            internal static partial int SetId(IntPtr record, byte[] id, int idSize);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_get_id")]
            internal static partial int GetId(IntPtr record, out IntPtr id, out int size);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_get_payload")]
            internal static partial int GetPayload(IntPtr record, out IntPtr payload, out uint size);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_get_type")]
            internal static partial int GetType(IntPtr record, out IntPtr type, out int size);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_get_tnf")]
            internal static partial int GetTnf(IntPtr record, out int tnf);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_get_text", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetText(IntPtr record, out string text);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_get_langcode", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetLanguageCode(IntPtr record, out string languageCode);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_get_encode_type")]
            internal static partial int GetEncodeType(IntPtr record, out int encode);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_get_uri", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetUri(IntPtr record, out string uri);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_record_get_mime_type", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetMimeType(IntPtr record, out string mimeType);
        }

        internal static partial class NdefMessage
        {
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_message_create")]
            internal static partial int Create(out IntPtr ndefMessage);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_message_create_from_rawdata")]
            internal static partial int CreateRawData(out IntPtr ndefMessage, byte[] rawData, uint rawDataSize);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_message_destroy")]
            internal static partial int Destroy(IntPtr ndefMessage);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_message_get_record_count")]
            internal static partial int GetRecordCount(IntPtr ndefMessage, out int count);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_message_get_rawdata")]
            internal static partial int GetRawData(IntPtr ndefMessage, out IntPtr rawData, out uint rawDataSize);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_message_append_record")]
            internal static partial int AppendRecord(IntPtr ndefMessage, IntPtr record);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_message_insert_record")]
            internal static partial int InsertRecord(IntPtr ndefMessage, int index, IntPtr record);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_message_remove_record")]
            internal static partial int RemoveRecord(IntPtr ndefMessage, int index);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_ndef_message_get_record")]
            internal static partial int GetRecord(IntPtr ndefMessage, int index, out IntPtr record);
        }

        internal static partial class Tag
        {
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_tag_get_type")]
            internal static partial int GetType(IntPtr tag, out int type);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_tag_is_support_ndef")]
            internal static partial int IsSupportNdef(IntPtr tag, [MarshalAs(UnmanagedType.U1)] out bool isSupported);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_tag_get_maximum_ndef_size")]
            internal static partial int GetMaximumNdefSize(IntPtr tag, out uint maximunNdefBytesSize);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_tag_get_ndef_size")]
            internal static partial int GetNdefSize(IntPtr tag, out uint ndefBytesSize);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_tag_foreach_information")]
            internal static partial int ForeachInformation(IntPtr tag, TagInformationCallback callback, IntPtr userData);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_tag_transceive")]
            internal static partial int Transceive(IntPtr tag, byte[] buffer, int bufferSize, TagTransceiveCompletedCallback callback, IntPtr userData);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_tag_read_ndef")]
            internal static partial int ReadNdef(IntPtr tag, TagReadCompletedCallback callback, IntPtr userData);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_tag_write_ndef")]
            internal static partial int WriteNdef(IntPtr tag, IntPtr ndefMessage, VoidCallback callback, IntPtr userData);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_tag_format_ndef")]
            internal static partial int FormatNdef(IntPtr tag, byte[] key, int kyeSize, VoidCallback callback, IntPtr userData);

            ////Mifare
        }

        ////SNEP - Simple NDEF Exchange Protocol
        internal static partial class P2p
        {
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_p2p_set_data_received_cb")]
            internal static partial int SetDataReceivedCallback(IntPtr target, P2pDataReceivedCallback callback, IntPtr userData);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_p2p_unset_data_received_cb")]
            internal static partial int UnsetDataReceivedCallback(IntPtr target);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_p2p_send")]
            internal static partial int Send(IntPtr target, IntPtr ndefMessage, VoidCallback callback, IntPtr userData);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_snep_start_server", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SnepStartServer(IntPtr target, string san, int sap, SnepEventCallback callback, IntPtr userData);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_snep_start_client", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SnepStartClient(IntPtr target, string san, int sap, SnepEventCallback callback, IntPtr userData);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_snep_send_client_request")]
            internal static partial int SnepSendClientRequest(IntPtr snepHandle, int type, IntPtr ndefMessage, SnepEventCallback callback, IntPtr userData);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_snep_stop_service")]
            internal static partial int SnepStopService(IntPtr target, IntPtr snepHandle);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_snep_register_server", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SnepRegisterServer(string san, int sap, SnepEventCallback callback, IntPtr userData);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_snep_unregister_server", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SnepUnregisterServer(string sam, int sap);
        }

        ////SE - Secure Element, HCE - Host Card Emulation, APDU - Application Protocol Data Unit, AID - Application Identifier
        internal static partial class CardEmulation
        {
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_se_enable_card_emulation")]
            internal static partial int EnableCardEmulation();
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_se_disable_card_emulation")]
            internal static partial int DisableCardEmulatiion();
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_se_get_card_emulation_mode")]
            internal static partial int GetCardEmulationMode(out int type);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_hce_send_apdu_response")]
            internal static partial int HceSendApduRespondse(IntPtr seHandle, byte[] response, uint responseLength);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_se_set_default_route")]
            internal static partial int SetDefaultRoute(int poweredOnStatus, int poweredOffStatus, int lowBatteryStatus);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_se_is_activated_handler_for_aid", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int IsActivatedHandlerForAid(int seType, string aid, [MarshalAs(UnmanagedType.U1)] out bool isActivatedHandler);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_se_is_activated_handler_for_category")]
            internal static partial int IsActivatedHandlerForCategory(int seType, int category, [MarshalAs(UnmanagedType.U1)] out bool isActivatedHandler);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_se_register_aid", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int RegisterAid(int seType, int category, string aid);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_se_unregister_aid", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int UnregisterAid(int seType, int category, string aid);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_se_foreach_registered_aids")]
            internal static partial int ForeachRegisterdAids(int seType, int category, SecureElementRegisteredAidCallback callback, IntPtr userData);
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_se_set_preferred_handler")]
            internal static partial int SetPreferredHandler();
            [LibraryImport(Libraries.Nfc, EntryPoint = "nfc_se_unset_preferred_handler")]
            internal static partial int UnsetPreferredHandler();
        }
    }
}





