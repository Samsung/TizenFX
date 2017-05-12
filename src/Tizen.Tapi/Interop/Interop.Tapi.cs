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
using Tizen.Tapi;

/// <summary>
/// Interop class for Tapi
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// Tapi Native Apis
    /// </summary>
    internal static partial class Tapi
    {
        //Callback for event
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TapiNotificationCallback(IntPtr handle, string id, IntPtr data, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TapiResponseCallback(IntPtr handle, int result, IntPtr data, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TapiStateCallback(int state, IntPtr userData);

        //Tapi-common
        [DllImport(Libraries.Tapi, EntryPoint = "tel_get_cp_name_list")]
        internal static extern string[] GetCpNames();
        [DllImport(Libraries.Tapi, EntryPoint = "tel_init")]
        internal static extern IntPtr InitTapi(string cpName);
        [DllImport(Libraries.Tapi, EntryPoint = "tel_deinit")]
        internal static extern int DeinitTapi(IntPtr handle);
        [DllImport(Libraries.Tapi, EntryPoint = "tel_register_noti_event")]
        internal static extern int RegisterNotiEvent(IntPtr handle, string notificationId, TapiNotificationCallback cb, IntPtr userData);
        [DllImport(Libraries.Tapi, EntryPoint = "tel_deregister_noti_event")]
        internal static extern int DeregisterNotiEvent(IntPtr handle, string notificationId);
        [DllImport(Libraries.Tapi, EntryPoint = "tel_get_property_int")]
        internal static extern int GetIntProperty(IntPtr handle, string property, out int result);
        [DllImport(Libraries.Tapi, EntryPoint = "tel_get_property_string")]
        internal static extern int GetStringProperty(IntPtr handle, string property, out string result);
        [DllImport(Libraries.Tapi, EntryPoint = "tel_get_ready_state")]
        internal static extern int GetReadyState(out int state);
        [DllImport(Libraries.Tapi, EntryPoint = "tel_register_ready_state_cb")]
        internal static extern int RegisterReadyStateCb(TapiStateCallback cb, IntPtr userData);
        [DllImport(Libraries.Tapi, EntryPoint = "tel_deregister_ready_state_cb")]
        internal static extern int DeregisterReadyStateCb(TapiStateCallback cb);

        //Phonebook
        internal static class Phonebook
        {
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_pb_init_info")]
            internal static extern int GetPhonebookInitInfo(IntPtr handle, out int initCompleted, out IntPtr pbList);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_pb_count")]
            internal static extern int GetPhonebookStorage(IntPtr handle, PhonebookType pbType, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_pb_meta_info")]
            internal static extern int GetPhonebookMetaInfo(IntPtr handle, PhonebookType pbType, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_pb_usim_meta_info")]
            internal static extern int GetPhonebookMetaInfo3G(IntPtr handle, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_read_sim_pb_record")]
            internal static extern int ReadPhonebookRecord(IntPtr handle, PhonebookType pbType, ushort pbIndex, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_update_sim_pb_record")]
            internal static extern int UpdatePhonebookRecord(IntPtr handle, ref PhonebookRecordStruct data, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_delete_sim_pb_record")]
            internal static extern int DeletePhonebookRecord(IntPtr handle, PhonebookType pbType, ushort pbIndex, TapiResponseCallback cb, IntPtr userData);
        }

        //Sat
        internal static class Sat
        {
            [DllImport(Libraries.Tapi, EntryPoint = "tel_select_sat_menu")]
            internal static extern int SatSendSelectMenu(IntPtr handle, ref SatMenuSelectionInfoStruct info, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_download_sat_event")]
            internal static extern int SatDownloadEvent(IntPtr handle, ref SatEventDownloadInfoStruct info, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_send_sat_ui_display_status")]
            internal static extern int SatSendUiDisplayStatus(IntPtr handle, int commandId, SatUiDisplayStatus status);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_send_sat_ui_user_confirm")]
            internal static extern int SatSendUiUserConfim(IntPtr handle, ref SatUiUserConfirmInfoStruct confirmInfo);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sat_main_menu_info")]
            internal static extern int SatGetMainMenuInfo(IntPtr handle, out SatMainMenuInfoStruct mainMenuInfo);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_send_sat_app_exec_result")]
            internal static extern int SatExecutionResult(IntPtr handle, out SatResultDataStruct resultData);
        }

        //Sim
        internal static class Sim
        {
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_init_info")]
            internal static extern int SimGetInitInfo(IntPtr handle, out SimCardStatus status, out int cardChanged);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_type")]
            internal static extern int SimGetType(IntPtr handle, out SimType type);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_imsi")]
            internal static extern int SimGetImsi(IntPtr handle, out SimImsiInfoStruct imsiInfo);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_ecc")]
            internal static extern int SimGetEcc(IntPtr handle, out SimEccInfoStruct eccInfo);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_iccid")]
            internal static extern int SimGetIccId(IntPtr handle, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_language")]
            internal static extern int SimGetLanguage(IntPtr handle, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_set_sim_language")]
            internal static extern int SimSetLanguage(IntPtr handle, SimLanguagePreference language, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_callforwarding_info")]
            internal static extern int SimGetCallForwardingInfo(IntPtr handle, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_set_sim_callforwarding_info")]
            internal static extern int SimSetCallForwardingInfo(IntPtr handle, SimCallForwardRequestStruct request, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_messagewaiting_info")]
            internal static extern int SimGetMessageWaitingInfo(IntPtr handle, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_set_sim_messagewaiting_info")]
            internal static extern int SimSetMessageWaitingInfo(IntPtr handle, SimMessageWaitingRequestStruct request, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_mailbox_info")]
            internal static extern int SimGetMailboxInfo(IntPtr handle, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_set_sim_mailbox_info")]
            internal static extern int SimSetMailboxInfo(IntPtr handle, SimMailboxNumberStruct mailbox, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_cphs_info")]
            internal static extern int SimGetCphsInfo(IntPtr handle, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_service_table")]
            internal static extern int SimGetServiceTable(IntPtr handle, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_msisdn")]
            internal static extern int SimGetMsisdn(IntPtr handle, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_oplmnwact")]
            internal static extern int SimGetOplmnwact(IntPtr handle, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_spn")]
            internal static extern int SimGetSpn(IntPtr handle, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_cphs_netname")]
            internal static extern int SimGetCphsNetName(IntPtr handle, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_req_sim_authentication")]
            internal static extern int SimExecuteAuthentication(IntPtr handle, ref SimAuthenticationDataStruct authenticationData, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_verifiy_sim_pins")]
            internal static extern int SimVerifyPins(IntPtr handle, ref SimPinDataStruct pinData, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_verify_sim_puks")]
            internal static extern int SimVerifyPuks(IntPtr handle, ref SimPinDataStruct pukData, ref SimPinDataStruct newPinData, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_change_sim_pins")]
            internal static extern int SimChangePins(IntPtr handle, ref SimPinDataStruct oldPin, ref SimPinDataStruct newPin, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_disable_sim_facility")]
            internal static extern int SimDisableFacility(IntPtr handle, ref SimFacilityStruct facility, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_enable_sim_facility")]
            internal static extern int SimEnableFacility(IntPtr handle, ref SimFacilityStruct facility, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_facility")]
            internal static extern int SimGetFacility(IntPtr handle, SimLockType lockType, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_lock_info")]
            internal static extern int SimGetLockInfo(IntPtr handle, SimLockType lockType, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_set_sim_power_state")]
            internal static extern int SimSetPowerState(IntPtr handle, SimPowerState state, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_req_sim_apdu")]
            internal static extern int SimRequestApdu(IntPtr handle, ref SimApduStruct apdu, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_req_sim_atr")]
            internal static extern int SimRequestAtr(IntPtr handle, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_application_list")]
            internal static extern int SimGetApplicationList(IntPtr handle, out byte appList);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_impi")]
            internal static extern int SimGetImpi(IntPtr handle, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_impu")]
            internal static extern int SimGetImpu(IntPtr handle, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_domain")]
            internal static extern int SimGetDomain(IntPtr handle, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_pcscf")]
            internal static extern int SimGetPcscf(IntPtr handle, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_sim_isim_service_table")]
            internal static extern int SimGetIsimServiceTable(IntPtr handle, TapiResponseCallback cb, IntPtr userData);

        }

        //Ss
        internal static class Ss
        {
            [DllImport(Libraries.Tapi, EntryPoint = "tel_set_ss_barring")]
            internal static extern int SsSetBarring(IntPtr handle, ref SsBarringInfoStruct info, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_ss_barring_status")]
            internal static extern int SsGetBarringStatus(IntPtr handle, SsClass ssClass, SsBarringType type, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_change_ss_barring_password")]
            internal static extern int SsChangeBarringPassword(IntPtr handle, string oldPassword, string newPassword, string newPasswordAgain, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_set_ss_forward")]
            internal static extern int SsSetForward(IntPtr handle, ref SsForwardInfoStruct info, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_ss_forward_status")]
            internal static extern int SsGetForwardStatus(IntPtr handle, SsClass ssClass, SsForwardCondition condition, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_set_ss_waiting")]
            internal static extern int SsSetWaiting(IntPtr handle, ref SsWaitingInfoStruct info, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_ss_waiting_status")]
            internal static extern int SsGetWaitingStatus(IntPtr handle, SsClass ssClass, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_set_ss_cli_status")]
            internal static extern int SsSetCliStatus(IntPtr handle, SsCliType type, SsCliStatus status, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_get_ss_cli_status")]
            internal static extern int SsGetCliStatus(IntPtr handle, SsCliType type, TapiResponseCallback cb, IntPtr userData);
            [DllImport(Libraries.Tapi, EntryPoint = "tel_send_ss_ussd_request")]
            internal static extern int SsSendUssdRequest(IntPtr handle, ref SsUssdMsgInfoStruct info, TapiResponseCallback cb, IntPtr userData);
        }
    }
}
