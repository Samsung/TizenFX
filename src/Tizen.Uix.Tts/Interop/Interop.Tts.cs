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
using Tizen.Uix.Tts;

/// <summary>
/// Partial interop class.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// Tts interop class.
    /// </summary>
    internal static class Tts
    {
        internal const string LogTag = "Tizen.Uix.Tts";

        private const int ErrorTts = -0x02F10000;

        internal enum TtsError
        {
            None = Tizen.Internals.Errors.ErrorCode.None,                           /* Successful */
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,             /* Out of Memory */
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,                     /* I/O error */
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,   /* Invalid parameter */
            OutOfNetwork = Tizen.Internals.Errors.ErrorCode.Networkdown,            /* Network is down */
            TimedOut = Tizen.Internals.Errors.ErrorCode.TimedOut,                   /* No answer from the STT service */
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,   /* Permission denied */
            NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,           /* STT NOT supported */
            InvalidState = ErrorTts | 0x01,                                         /* Invalid state */
            InvalidVoice = ErrorTts | 0x02,                                         /* Invalid language */
            EngineNotFound = ErrorTts | 0x03,                                       /* No available engine */
            OperationFailed = ErrorTts | 0x04,                                      /* Operation failed */
            AudioPolicyBlocked = ErrorTts | 0x05,                                   /* Audio policy blocked */
            NotSupportedFeature = ErrorTts | 0x06,                                  /* Not supported feature of current engine */
            ServiceReset = ErrorTts | 0x07,                                         /* Service reset*/
            ScreenReaderOff = ErrorTts | 0x08                                       /* Screen reader off */
        };

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TtsStateChangedCB(IntPtr handle, State previous, State current, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TtsUtteranceStartedCB(IntPtr handle, int uttId, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TtsUtteranceCompletedCB(IntPtr handle, int uttId, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TtsErrorCB(IntPtr handle, int uttId, TtsError reason, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool TtsSupportedVoiceCB(IntPtr handle, IntPtr language, int voiceType, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TtsDefaultVoiceChangedCB(IntPtr handle, IntPtr previous_language, int previous_voice_type, IntPtr current_language, int current_voice_type, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TtsEngineChangedCB(IntPtr handle, IntPtr engine_id, IntPtr language, int voice_type, bool need_credential, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TtsScreenReaderChangedCB(IntPtr handle, bool is_on, IntPtr userData);

        [DllImport(Libraries.Tts, EntryPoint = "tts_create", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsCreate(out IntPtr handle);

        [DllImport(Libraries.Tts, EntryPoint = "tts_destroy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsDestroy(IntPtr handle);

        [DllImport(Libraries.Tts, EntryPoint = "tts_set_mode", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsSetMode(IntPtr handle, Mode m);

        [DllImport(Libraries.Tts, EntryPoint = "tts_get_mode", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsGetMode(IntPtr handle, out Mode m);

        [DllImport(Libraries.Tts, EntryPoint = "tts_set_credential", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsSetCredential(IntPtr handle, string credential);

        [DllImport(Libraries.Tts, EntryPoint = "tts_prepare", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsPrepare(IntPtr handle);

        [DllImport(Libraries.Tts, EntryPoint = "tts_unprepare", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsUnprepare(IntPtr handle);

        [DllImport(Libraries.Tts, EntryPoint = "tts_foreach_supported_voices", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsForeachSupportedVoices(IntPtr handle, TtsSupportedVoiceCB callback, IntPtr userData);

        [DllImport(Libraries.Tts, EntryPoint = "tts_get_default_voice", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsGetDefaultVoice(IntPtr handle, out string language, out int voice_type);

        [DllImport(Libraries.Tts, EntryPoint = "tts_set_private_data", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsSetPrivateData(IntPtr handle, string key, string data);

        [DllImport(Libraries.Tts, EntryPoint = "tts_get_private_data", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsGetPrivateData(IntPtr handle, string key, out string data);

        [DllImport(Libraries.Tts, EntryPoint = "tts_get_max_text_size", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsGetMaxTextSize(IntPtr handle, out uint size);

        [DllImport(Libraries.Tts, EntryPoint = "tts_get_state", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsGetState(IntPtr handle, out State state);

        [DllImport(Libraries.Tts, EntryPoint = "tts_get_speed_range", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsGetSpeedRange(IntPtr handle, out int min, out int normal, out int max);

        [DllImport(Libraries.Tts, EntryPoint = "tts_get_error_message", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsGetErrorMessage(IntPtr handle, out string err_msg);

        [DllImport(Libraries.Tts, EntryPoint = "tts_is_recognition_type_supported", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsIsRecognitionTypeSupported(IntPtr handle, string type, out bool support);

        [DllImport(Libraries.Tts, EntryPoint = "tts_check_screen_reader_on", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsCheckScreenReaderOn(IntPtr handle, out bool isOn);

        [DllImport(Libraries.Tts, EntryPoint = "tts_add_text", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsAddText(IntPtr handle, string text, string language, int voice_type, int speed, out int uttId);

        [DllImport(Libraries.Tts, EntryPoint = "tts_play", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsPlay(IntPtr handle);

        [DllImport(Libraries.Tts, EntryPoint = "tts_stop", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsStop(IntPtr handle);

        [DllImport(Libraries.Tts, EntryPoint = "tts_pause", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsPause(IntPtr handle);

        [DllImport(Libraries.Tts, EntryPoint = "tts_set_state_changed_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsSetStateChangedCB(IntPtr handle, TtsStateChangedCB callback, IntPtr userData);

        [DllImport(Libraries.Tts, EntryPoint = "tts_unset_state_changed_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsUnsetStateChangedCB(IntPtr handle);

        [DllImport(Libraries.Tts, EntryPoint = "tts_set_utterance_started_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsSetUtteranceStartedCB(IntPtr handle, TtsUtteranceStartedCB callback, IntPtr userData);

        [DllImport(Libraries.Tts, EntryPoint = "tts_unset_utterance_started_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsUnsetUtteranceStartedCB(IntPtr handle);

        [DllImport(Libraries.Tts, EntryPoint = "tts_set_utterance_completed_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsSetUtteranceCompletedCB(IntPtr handle, TtsUtteranceCompletedCB callback, IntPtr userData);

        [DllImport(Libraries.Tts, EntryPoint = "tts_unset_utterance_completed_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsUnsetUtteranceCompletedCB(IntPtr handle);

        [DllImport(Libraries.Tts, EntryPoint = "tts_set_error_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsSetErrorCB(IntPtr handle, TtsErrorCB callback, IntPtr userData);

        [DllImport(Libraries.Tts, EntryPoint = "tts_unset_error_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsUnsetErrorCB(IntPtr handle);

        [DllImport(Libraries.Tts, EntryPoint = "tts_set_default_voice_changed_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsSetDefaultVoiceChangedCB(IntPtr handle, TtsDefaultVoiceChangedCB callback, IntPtr userData);

        [DllImport(Libraries.Tts, EntryPoint = "tts_unset_default_voice_changed_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsUnsetDefaultVoiceChangedCB(IntPtr handle);

        [DllImport(Libraries.Tts, EntryPoint = "tts_set_engine_changed_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsSetEngineChangedCB(IntPtr handle, TtsEngineChangedCB callback, IntPtr userData);

        [DllImport(Libraries.Tts, EntryPoint = "tts_unset_engine_changed_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsUnsetEngineChangedCB(IntPtr handle);

        [DllImport(Libraries.Tts, EntryPoint = "tts_set_screen_reader_changed_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsSetScreenReaderChangedCB(IntPtr handle, TtsScreenReaderChangedCB callback, IntPtr userData);

        [DllImport(Libraries.Tts, EntryPoint = "tts_unset_screen_reader_changed_cb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern TtsError TtsUnsetScreenReaderChangedCB(IntPtr handle);
    }
}
