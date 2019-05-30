// Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;
using static Interop.VoiceControlCommand;
using Tizen.Uix.VoiceControlManager;

internal static partial class Interop
{
    internal static partial class VoiceControlManager
    {
        internal static string LogTag = "Tizen.Uix.VoiceControlManager";

        private const int ErrorVoiceControl = -0x02F50000;

        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,                           /* Successful */
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,             /* Out of Memory */
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,                     /* I/O error */
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,   /* Invalid parameter */
            TimedOut = Tizen.Internals.Errors.ErrorCode.TimedOut,                   /* No answer from service */
            RecorderBusy = Tizen.Internals.Errors.ErrorCode.ResourceBusy,           /* Busy recorder */
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,   /* Permission denied */
            NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,           /* VC NOT supported */
            InvalidState = ErrorVoiceControl | 0x011,                               /* Invalid state */
            InvalidLanguage = ErrorVoiceControl | 0x012,                            /* Invalid language */
            EngineNotFound = ErrorVoiceControl | 0x013,                             /* No available engine */
            OperationFailed = ErrorVoiceControl | 0x014,                            /* Operation failed */
            OperationRejected = ErrorVoiceControl | 0x015,                          /* Operation rejected */
            IterationEnd = ErrorVoiceControl | 0x016,                               /* List reached end */
            Empty = ErrorVoiceControl | 0x017,                                      /* List empty */
            ServiceReset = ErrorVoiceControl | 0x018,                               /* Service daemon reset (Since 3.0) */
            InProgressToReady = ErrorVoiceControl | 0x019,                          /* In progress to ready (Since 3.0) */
            InProgressToRecording = ErrorVoiceControl | 0x020,                      /* In progress to recording (Since 3.0) */
            InProgressToProcessing = ErrorVoiceControl | 0x021,                     /* In progress to processing (Since 3.0) */
            NotSupportedFeature = ErrorVoiceControl | 0x022                         /* Not supported feature of current engine (Since 4.0) */
        };

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_initialize")]
        internal static extern ErrorCode VcMgrInitialize();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_deinitialize")]
        internal static extern ErrorCode VcMgrDeinitialize();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_prepare")]
        internal static extern ErrorCode VcMgrPrepare();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_unprepare")]
        internal static extern ErrorCode VcMgrUnprepare();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_foreach_supported_languages")]
        internal static extern ErrorCode VcMgrForeachSupportedLanguages(VcMgrSupportedLanguageCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_get_current_language")]
        internal static extern ErrorCode VcMgrGetCurrentLanguage(out string language);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_get_state")]
        internal static extern ErrorCode VcMgrGetState(out State state);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_get_service_state")]
        internal static extern ErrorCode VcMgrGetServiceState(out ServiceState state);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_is_command_format_supported")]
        internal static extern ErrorCode VcMgrIsCommandFormatSupported(CommandFormat format, out bool support);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_command_list")]
        internal static extern ErrorCode VcMgrSetCommandList(SafeCommandListHandle vcCmdList);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_unset_command_list")]
        internal static extern ErrorCode VcMgrUnsetCommandList();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_command_list_from_file")]
        internal static extern ErrorCode VcMgrSetCommandListFromFile(string filePath, CommandType type);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_get_current_commands")]
        internal static extern ErrorCode VcMgrGetCurrentCommands(out IntPtr vcCmdList);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_audio_type")]
        internal static extern ErrorCode VcMgrSetAudioType(string audioId);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_get_audio_type")]
        internal static extern ErrorCode VcMgrGetAudioType(out string audioId);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_recognition_mode")]
        internal static extern ErrorCode VcMgrSetRecognitionMode(RecognitionModeType mode);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_get_recognition_mode")]
        internal static extern ErrorCode VcMgrGetRecognitionMode(out RecognitionModeType mode);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_private_data")]
        internal static extern ErrorCode VcMgrSetPrivateData(string key, string data);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_get_private_data")]
        internal static extern ErrorCode VcMgrGetPrivateData(string key, out string data);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_do_action")]
        internal static extern ErrorCode VcMgrDoAction(SendEventType type, string sendEvent);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_send_specific_engine_request")]
        internal static extern ErrorCode VcMgrSendSpecificEngineRequest(string engineAppId, string evt, string request);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_start")]
        internal static extern ErrorCode VcMgrStart(bool exclusiveCommandOption);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_stop")]
        internal static extern ErrorCode VcMgrStop();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_cancel")]
        internal static extern ErrorCode VcMgrCancel();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_get_recording_volume")]
        internal static extern ErrorCode VcMgrGetRecordingVolume(out float volume);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_selected_results")]
        internal static extern ErrorCode VcMgrSetSelectedResults(SafeCommandListHandle vcCmdList);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_all_result_cb")]
        internal static extern ErrorCode VcMgrSetAllResultCb(VcMgrAllResultCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_unset_all_result_cb")]
        internal static extern ErrorCode VcMgrUnsetAllResultCb();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_pre_result_cb")]
        internal static extern ErrorCode VcMgrSetPreResultCb(VcMgrPreResultCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_unset_pre_result_cb")]
        internal static extern ErrorCode VcMgrUnsetPreResultCb();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_specific_engine_result_cb")]
        internal static extern ErrorCode VcMgrSetSpecificEngineResultCb(VcMgrSpecificEngineResultCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_unset_specific_engine_result_cb")]
        internal static extern ErrorCode VcMgrUnsetSpecificEngineResultCb();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_result_cb")]
        internal static extern ErrorCode VcMgrSetResultCb(VcMgrResultCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_unset_result_cb")]
        internal static extern ErrorCode VcMgrUnsetResultCb();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_state_changed_cb")]
        internal static extern ErrorCode VcMgrSetStateChangedCb(VcMgrStateChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_unset_state_changed_cb")]
        internal static extern ErrorCode VcMgrUnsetStateChangedCb();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_service_state_changed_cb")]
        internal static extern ErrorCode VcMgrSetServiceStateChangedCb(VcMgrServiceStateChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_unset_service_state_changed_cb")]
        internal static extern ErrorCode VcMgrUnsetServiceStateChangedCb();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_speech_detected_cb")]
        internal static extern ErrorCode VcMgrSetSpeechDetectedCb(VcMgrBeginSpeechDetectedCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_unset_speech_detected_cb")]
        internal static extern ErrorCode VcMgrUnsetSpeechDetectedCb();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_current_language_changed_cb")]
        internal static extern ErrorCode VcMgrSetCurrentLanguageChangedCb(VcMgrCurrentLanguageChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_unset_current_language_changed_cb")]
        internal static extern ErrorCode VcMgrUnsetCurrentLanguageChangedCb();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_get_error_message")]
        internal static extern ErrorCode VcMgrGetErrorMessage(out string errMsg);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_error_cb")]
        internal static extern ErrorCode VcMgrSetErrorCb(VcMgrErrorCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_unset_error_cb")]
        internal static extern ErrorCode VcMgrUnsetErrorCb();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_dialog_request_cb")]
        internal static extern ErrorCode VcMgrSetDialogRequestCb(VcMgrDialogRequestCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_unset_dialog_request_cb")]
        internal static extern ErrorCode VcMgrUnsetDialogRequestCb();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_enable_command_type")]
        internal static extern ErrorCode VcMgrEnableCommandType(CommandType cmdType);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_disable_command_type")]
        internal static extern ErrorCode VcMgrDisableCommandType(CommandType cmdType);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_private_data_set_cb")]
        internal static extern ErrorCode VcMgrSetPrivateDataSetCb(VcMgrPrivateDataSetCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_unset_private_data_set_cb")]
        internal static extern ErrorCode VcMgrUnsetPrivateDataSetCb();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_private_data_requested_cb")]
        internal static extern ErrorCode VcMgrSetPrivateDataRequestedCb(VcMgrPrivateDataRequestedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_unset_private_data_requested_cb")]
        internal static extern ErrorCode VcMgrUnsetPrivateDataRequestedCb();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_feedback_audio_format_cb")]
        internal static extern ErrorCode VcMgrSetFeedbackAudioFormatCb(VcMgrFeedbackAudioFormatCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_unset_feedback_audio_format_cb")]
        internal static extern ErrorCode VcMgrUnsetFeedbackAudioFormatCb();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_feedback_streaming_cb")]
        internal static extern ErrorCode VcMgrSetFeedbackStreamingCb(VcMgrFeedbackStreamingCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_unset_feedback_streaming_cb")]
        internal static extern ErrorCode VcMgrUnsetFeedbackStreamingCb();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_start_feedback")]
        internal static extern ErrorCode VcMgrStartFeedback();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_stop_feedback")]
        internal static extern ErrorCode VcMgrStopFeedback();

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_set_vc_tts_streaming_cb")]
        internal static extern ErrorCode VcMgrSetVcTtsStreamingCb(VcMgrVcTtsStreamingCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlManager, EntryPoint = "vc_mgr_unset_vc_tts_streaming_cb")]
        internal static extern ErrorCode VcMgrUnsetVcTtsStreamingCb();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool VcMgrAllResultCallback(RecognizedResult result, IntPtr vcCmdList, IntPtr recognizedText, IntPtr msg, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcMgrPreResultCallback(PreResultEventType evt, IntPtr result, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcMgrSpecificEngineResultCallback(IntPtr engineAppId, IntPtr evt, IntPtr result, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcMgrBeginSpeechDetectedCallback(IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcMgrDialogRequestCallback(int pid, IntPtr dispText, IntPtr uttText, bool continuous, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int VcMgrPrivateDataSetCallback(IntPtr key, IntPtr data, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate VoiceError VcMgrPrivateDataRequestedCallback(string key, out string data, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcMgrFeedbackAudioFormatCallback(int rate, AudioChanelType channel, AudioType audioType, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcMgrFeedbackStreamingCallback(FeedbackType type, IntPtr buffer, int len, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcMgrVcTtsStreamingCallback(int pid, int uttId, FeedbackType type, IntPtr buffer, int len, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcMgrResultCallback(RecognizedResult result, IntPtr cmdList, IntPtr recognizedText, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcMgrCurrentLanguageChangedCallback(IntPtr previous, IntPtr current, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool VcMgrSupportedLanguageCallback(IntPtr language, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcMgrStateChangedCallback(State previous, State current, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcMgrServiceStateChangedCallback(ServiceState previous, ServiceState current, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcMgrErrorCallback(ErrorCode reason, IntPtr userData);

    }
}
