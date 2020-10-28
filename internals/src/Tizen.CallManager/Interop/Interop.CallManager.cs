/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.CallManager;

/// <summary>
/// Interop class for CallManager
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// CallManager Native Apis
    /// </summary>
    internal static partial class CallManager
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CallStatusChangedCallback(CallStatus callStatus, IntPtr number, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CallMuteStatusChangedCallback(CallMuteStatus muteStatus, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DialStatusChangedCallback(DialStatus dialStatus, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DtmfIndicationChangedCallback(DtmfIndication indiType, string number, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void AudioStateChangedCallback(AudioState state, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void GoForegroundCallback(IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VoiceRecordStatusChangedCallback(VrStatus vrStatus, VrStatusExtraType extraType, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CallEventNotificationCallback(CallEvent callEvent, IntPtr eventData, IntPtr userData);

        [DllImport(Libraries.CallManager, EntryPoint = "cm_init")]
        internal static extern int InitCm(out IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_deinit")]
        internal static extern int DeinitCm(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_reject_call")]
        internal static extern int RejectCall(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_stop_alert")]
        internal static extern int StopAlert(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_get_call_status")]
        internal static extern int GetStatus(IntPtr handle, out CallStatus callStatus);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_set_call_status_cb")]
        internal static extern int SetCallStatusCallback(IntPtr handle, CallStatusChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_unset_call_status_cb")]
        internal static extern int UnsetCallstatusCallback(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_get_mute_status")]
        internal static extern int GetMuteStatus(IntPtr handle, out CallMuteStatus muteStatus);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_set_mute_status_cb")]
        internal static extern int SetCallMuteStatusCallback(IntPtr handle, CallMuteStatusChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_unset_mute_status_cb")]
        internal static extern int UnsetCallMuteStatusCallback(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_enable_recovery")]
        internal static extern int EnableRecovery(IntPtr handle, string appId);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_dial_call")]
        internal static extern int DialCall(IntPtr handle, string number, CallType type, MultiSimSlot simSlot);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_swap_call")]
        internal static extern int SwapCall(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_join_call")]
        internal static extern int JoinCall(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_split_call")]
        internal static extern int SplitCall(IntPtr handle, uint callId);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_transfer_call")]
        internal static extern int TransferCall(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_answer_call_ex")]
        internal static extern int AnswerCallEx(IntPtr handle, CallAnswerType answerType, CallType callType);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_answer_call")]
        internal static extern int AnswerCall(IntPtr handle, CallAnswerType answerType);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_upgrade_call")]
        internal static extern int UpgradeCall(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_downgrade_call")]
        internal static extern int DowngradeCall(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_confirm_upgrade_call")]
        internal static extern int ConfirmUpgradeCall(IntPtr handle, CallUpgradeResponseType respType);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_speaker_on")]
        internal static extern int SpeakerOn(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_speaker_off")]
        internal static extern int SpeakerOff(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_bluetooth_on")]
        internal static extern int BluetoothOn(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_bluetooth_off")]
        internal static extern int BluetoothOff(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_set_extra_vol")]
        internal static extern int SetExtraVolume(IntPtr handle, bool isExtraVolume);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_set_noise_reduction")]
        internal static extern int SetNoiseReduction(IntPtr handle, bool isNoiseReduction);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_set_mute_state")]
        internal static extern int SetMuteState(IntPtr handle, bool isMuteState);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_start_dtmf")]
        internal static extern int StartDtmf(IntPtr handle, byte dtmfDigit);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_stop_dtmf")]
        internal static extern int StopDtmf(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_burst_dtmf")]
        internal static extern int BurstDtmf(IntPtr handle, string dtmfDigits);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_send_dtmf_resp")]
        internal static extern int SendDtmfResponse(IntPtr handle, DtmfResponseType respType);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_get_audio_state")]
        internal static extern int GetAudioState(IntPtr handle, out AudioState state);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_activate_ui")]
        internal static extern int ActivateUi(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_set_lcd_timeout")]
        internal static extern int SetLcdTimeOut(IntPtr handle, LcdTimeOut timeOut);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_get_all_call_list")]
        internal static extern int GetAllCallList(IntPtr handle, out IntPtr list);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_get_conference_call_list")]
        internal static extern int GetConferenceCallList(IntPtr handle, out IntPtr list);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_get_all_calldata")]
        internal static extern int GetAllCallData(IntPtr handle, out IntPtr incoming, out IntPtr active, out IntPtr held);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_start_voice_record")]
        internal static extern int StartVoiceRecord(IntPtr handle, string number);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_stop_voice_record")]
        internal static extern int StopVoiceRecord(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_set_dial_status_cb")]
        internal static extern int SetDialStatusCb(IntPtr handle, DialStatusChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_unset_dial_status_cb")]
        internal static extern int UnsetDialStatusCb(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_set_audio_state_changed_cb")]
        internal static extern int SetAudioStateChangedCb(IntPtr handle, AudioStateChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_unset_audio_state_changed_cb")]
        internal static extern int UnsetAudioStateChangedCb(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_set_dtmf_indication_cb")]
        internal static extern int SetDtmfIndicationCb(IntPtr handle, DtmfIndicationChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_unset_dtmf_indication_cb")]
        internal static extern int UnsetDtmfIndicationCb(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_set_foreground_cb")]
        internal static extern int SetForegroundCb(IntPtr handle, GoForegroundCallback callback, IntPtr userData);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_unset_foreground_cb")]
        internal static extern int UnsetForegroundCb(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_set_voice_record_status_cb")]
        internal static extern int SetVoiceRecordStatusCb(IntPtr handle, VoiceRecordStatusChangedCallback callback, IntPtr userData);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_unset_voice_record_status_cb")]
        internal static extern int UnsetVoiceRecordStatusCb(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_get_person_id")]
        internal static extern int GetPersonId(IntPtr handle, out int personId);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_get_call_member_count")]
        internal static extern int GetCallMemberCount(IntPtr handle, out int memberCount);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_is_emergency_call")]
        internal static extern int IsEmergencyCall(IntPtr handle, out bool isEmergency);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_is_voicemail_number")]
        internal static extern int IsVoiceMailNumber(IntPtr handle, out bool isVoiceMailNumber);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_get_start_time")]
        internal static extern int GetStartTime(IntPtr handle, out long startTime);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_get_session_id")]
        internal static extern int GetSessionId(IntPtr handle, out int sessionId);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_get_hd_icon_state")]
        internal static extern int GetHdIconState(IntPtr handle, out int IsHdEnable);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_get_is_wifi_calling")]
        internal static extern int IsWiFiCalling(IntPtr handle, out int isWiFiCalling);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_get_upgrade_downgrade_state")]
        internal static extern int GetUpgradeDowngradeState(IntPtr handle, out int isUpgradeDowngradeEnable);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_get_is_added_to_conf")]
        internal static extern int IsAddedToConference(IntPtr handle, out int isAddedToConf);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_get_is_remote_on_hold")]
        internal static extern int IsRemoteOnHold(IntPtr handle, out int isRemoteOnHold);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_conf_call_data_get_call_id")]
        internal static extern int GetConfCallId(IntPtr handle, out uint callId);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_conf_call_data_get_call_number")]
        internal static extern int GetConfCallNumber(IntPtr handle, out string number);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_conf_call_data_get_person_id")]
        internal static extern int GetConfCallPersonId(IntPtr handle, out int personId);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_conf_call_data_get_name_mode")]
        internal static extern int GetConfCallNameMode(IntPtr handle, out CallNameMode nameMode);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_conf_call_data_free")]
        internal static extern int FreeConfCallData(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_set_lcd_state")]
        internal static extern int SetLcdState(LcdControlState state);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_start_alert")]
        internal static extern int StartAlert(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_set_call_event_cb")]
        internal static extern int SetCallEventCb(IntPtr handle, CallEventNotificationCallback callback, IntPtr userData);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_unset_call_event_cb")]
        internal static extern int UnsetCallEventCb(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_free")]
        internal static extern int FreeCallData(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_get_call_id")]
        internal static extern int GetCallId(IntPtr handle, out uint callId);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_get_call_direction")]
        internal static extern int GetCallDirection(IntPtr handle, out CallDirection direction);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_get_call_number")]
        internal static extern int GetCallNumber(IntPtr handle, out string number);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_get_calling_name")]
        internal static extern int GetCallingName(IntPtr handle, out string name);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_get_call_type")]
        internal static extern int GetCallType(IntPtr handle, out CallType type);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_get_call_state")]
        internal static extern int GetCallState(IntPtr handle, out CallState state);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_get_call_domain")]
        internal static extern int GetCallDomain(IntPtr handle, out CallDomain domain);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_get_name_mode")]
        internal static extern int GetNameMode(IntPtr handle, out CallNameMode nameMode);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_data_get_mt_forwarded")]
        internal static extern int IsForwardedCall(IntPtr handle, out bool isForwarded);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_event_data_get_sim_slot")]
        internal static extern int GetSimSlot(IntPtr handle, out MultiSimSlot simSlot);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_event_data_get_incom_call")]
        internal static extern int GetIncomingCallData(IntPtr handle, out IntPtr incomCall);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_event_data_get_call_id")]
        internal static extern int GetEventDataCallId(IntPtr handle, out uint callId);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_event_data_get_active_call")]
        internal static extern int GetActiveCall(IntPtr handle, out IntPtr activeCall);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_event_data_get_held_call")]
        internal static extern int GetHeldCall(IntPtr handle, out IntPtr heldCall);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_call_event_data_get_end_cause")]
        internal static extern int GetEndCause(IntPtr handle, out CallEndCause endCause);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_hold_call")]
        internal static extern int HoldCall(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_unhold_call")]
        internal static extern int UnholdCall(IntPtr handle);
        [DllImport(Libraries.CallManager, EntryPoint = "cm_end_call")]
        internal static extern int EndCall(IntPtr handle, uint callId, CallReleaseType releaseType);
    }
}
