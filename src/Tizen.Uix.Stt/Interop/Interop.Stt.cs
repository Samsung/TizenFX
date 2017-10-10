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

/// <summary>
/// Partial interop class.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// Stt interop class.
    /// </summary>
    internal static class Stt
    {
        internal static string LogTag = "Tizen.Uix.Stt";

        private const int ErrorStt = -0x02F00000;

        internal enum SttError
        {
            None = Tizen.Internals.Errors.ErrorCode.None,                           /* Successful */
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,             /* Out of Memory */
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,                     /* I/O error */
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,   /* Invalid parameter */
            TimedOut = Tizen.Internals.Errors.ErrorCode.TimedOut,                   /* No answer from the STT service */
            RecorderBusy = Tizen.Internals.Errors.ErrorCode.ResourceBusy,           /* Device or resource busy */
            OutOfNetwork = Tizen.Internals.Errors.ErrorCode.Networkdown,            /* Network is down */
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,   /* Permission denied */
            NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,           /* STT NOT supported */
            InvalidState = ErrorStt | 0x01,                                         /* Invalid state */
            InvalidLanguage = ErrorStt | 0x02,                                      /* Invalid language */
            EngineNotFound = ErrorStt | 0x03,                                       /* No available engine  */
            OperationFailed = ErrorStt | 0x04,                                      /* Operation failed  */
            NotSupportedFeature = ErrorStt | 0x05,                                  /* Not supported feature of current engine */
            RecordingTimedOut = ErrorStt | 0x06,                                    /* Recording timed out */
            NoSpeech = ErrorStt | 0x07,                                             /* No speech while recording */
            InProgressToReady = ErrorStt | 0x08,                                    /* Progress to ready is not finished */
            InProgressToRecording = ErrorStt | 0x09,                                /* Progress to recording is not finished */
            InProgressToProcessing = ErrorStt | 0x10,                               /* Progress to processing is not finished */
            ServiceReset = ErrorStt | 0x11                                          /* Service reset */
        };

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SupportedEngineCallback(IntPtr handle, IntPtr engineId, IntPtr engineName, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RecognitionResultCallback(IntPtr handle, Tizen.Uix.Stt.ResultEvent e, IntPtr data, int dataCount, IntPtr msg, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ResultTimeCallback(IntPtr handle, int index, Tizen.Uix.Stt.TimeEvent e, IntPtr text, IntPtr startTime, IntPtr endTime, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void StateChangedCallback(IntPtr handle, Tizen.Uix.Stt.State previous, Tizen.Uix.Stt.State current, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ErrorCallback(IntPtr handle, SttError reason, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SupportedLanguageCallback(IntPtr handle, IntPtr language, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DefaultLanguageChangedCallback(IntPtr handle, IntPtr previousLanguage, IntPtr currentLanguage, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void EngineChangedCallback(IntPtr handle, IntPtr engineId, IntPtr language, bool supportSilence, bool needCredential, IntPtr userData);

        [DllImport(Libraries.Stt, EntryPoint = "stt_create", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttCreate(out IntPtr handle);

        [DllImport(Libraries.Stt, EntryPoint = "stt_destroy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttDestroy(IntPtr handle);

        [DllImport(Libraries.Stt, EntryPoint = "stt_foreach_supported_engines", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttForeEachSupportedEngines(IntPtr handle, SupportedEngineCallback callback, IntPtr userData);

        [DllImport(Libraries.Stt, EntryPoint = "stt_get_engine", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttGetEngine(IntPtr handle, out string engineId);

        [DllImport(Libraries.Stt, EntryPoint = "stt_set_engine", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttSetEngine(IntPtr handle, string engineId);

        [DllImport(Libraries.Stt, EntryPoint = "stt_set_credential", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttSetcredential(IntPtr handle, string credential);

        [DllImport(Libraries.Stt, EntryPoint = "stt_set_private_data", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttSetPrivateData(IntPtr handle, string key, string data);

        [DllImport(Libraries.Stt, EntryPoint = "stt_get_private_data", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttGetPrivateData(IntPtr handle, string key, out string data);

        [DllImport(Libraries.Stt, EntryPoint = "stt_prepare", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttPrepare(IntPtr handle);

        [DllImport(Libraries.Stt, EntryPoint = "stt_unprepare", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttUnprepare(IntPtr handle);

        [DllImport(Libraries.Stt, EntryPoint = "stt_foreach_supported_languages", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttForeachSupportedLanguages(IntPtr handle, SupportedLanguageCallback callback, IntPtr userData);

        [DllImport(Libraries.Stt, EntryPoint = "stt_get_default_language", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttGetDefaultLanguage(IntPtr handle, out string language);

        [DllImport(Libraries.Stt, EntryPoint = "stt_get_state", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttGetState(IntPtr handle, out Tizen.Uix.Stt.State state);

        [DllImport(Libraries.Stt, EntryPoint = "stt_get_error_message", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttGetErrorMessage(IntPtr handle, out string err_msg);

        [DllImport(Libraries.Stt, EntryPoint = "stt_is_recognition_type_supported", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttIsRecognitionTypeSupported(IntPtr handle, string type, out bool support);

        [DllImport(Libraries.Stt, EntryPoint = "stt_set_silence_detection", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttSetSilenceDetection(IntPtr handle, Tizen.Uix.Stt.SilenceDetection type);

        [DllImport(Libraries.Stt, EntryPoint = "stt_set_start_sound", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttSetStartSound(IntPtr handle, string filename);

        [DllImport(Libraries.Stt, EntryPoint = "stt_unset_start_sound", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttUnsetStartSound(IntPtr handle);

        [DllImport(Libraries.Stt, EntryPoint = "stt_set_stop_sound", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttSetStopSound(IntPtr handle, string filename);

        [DllImport(Libraries.Stt, EntryPoint = "stt_unset_stop_sound", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttUnsetStopSound(IntPtr handle);

        [DllImport(Libraries.Stt, EntryPoint = "stt_start", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttStart(IntPtr handle, string language, string type);

        [DllImport(Libraries.Stt, EntryPoint = "stt_stop", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttStop(IntPtr handle);

        [DllImport(Libraries.Stt, EntryPoint = "stt_cancel", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttCancel(IntPtr handle);

        [DllImport(Libraries.Stt, EntryPoint = "stt_get_recording_volume", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttGetRecordingVolume(IntPtr handle, out float volume);

        [DllImport(Libraries.Stt, EntryPoint = "stt_foreach_detailed_result", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttForeachDetailedResult(IntPtr handle, ResultTimeCallback callback, IntPtr userData);

        [DllImport(Libraries.Stt, EntryPoint = "stt_set_recognition_result_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttSetRecognitionResultCB(IntPtr handle, RecognitionResultCallback callback, IntPtr userData);

        [DllImport(Libraries.Stt, EntryPoint = "stt_unset_recognition_result_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttUnsetRecognitionResultCB(IntPtr handle);

        [DllImport(Libraries.Stt, EntryPoint = "stt_set_state_changed_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttSetStateChangedCB(IntPtr handle, StateChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Stt, EntryPoint = "stt_unset_state_changed_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttUnsetStateChangedCB(IntPtr handle);

        [DllImport(Libraries.Stt, EntryPoint = "stt_set_error_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttSetErrorCB(IntPtr handle, ErrorCallback callback, IntPtr userData);

        [DllImport(Libraries.Stt, EntryPoint = "stt_unset_error_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttUnsetErrorCB(IntPtr handle);

        [DllImport(Libraries.Stt, EntryPoint = "stt_set_default_language_changed_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttSetDefaultLanguageChangedCB(IntPtr handle, DefaultLanguageChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Stt, EntryPoint = "stt_unset_default_language_changed_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttUnsetDefaultLanguageChangedCB(IntPtr handle);

        [DllImport(Libraries.Stt, EntryPoint = "stt_set_engine_changed_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttSetEngineChangedCB(IntPtr handle, EngineChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Stt, EntryPoint = "stt_unset_engine_changed_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern SttError SttUnsetEngineChangedCB(IntPtr handle);
    }
}