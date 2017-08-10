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
using Tizen.Uix.VoiceControl;
using static Interop.VoiceControlCommand;

/// <summary>
/// Partial Interop Class
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// VoiceControl Interop Class
    /// </summary>
    internal static class VoiceControl
    {
        internal static string LogTag = "Tizen.Uix.VoiceControl";

        private const int ErrorVoiceControl = -0x02F50000;

        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,            /**< Successful */
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,        /**< Out of Memory */
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,         /**< I/O error */
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,   /**< Invalid parameter */
            TimedOut = Tizen.Internals.Errors.ErrorCode.TimedOut,       /**< No answer from service */
            RecorderBusy = Tizen.Internals.Errors.ErrorCode.ResourceBusy,       /**< Busy recorder */
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,   /**< Permission denied */
            NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,       /**< VC NOT supported */
            InvalidState = ErrorVoiceControl | 0x011,   /**< Invalid state */
            InvalidLanguage = ErrorVoiceControl | 0x012,    /**< Invalid language */
            EngineNotFound = ErrorVoiceControl | 0x013, /**< No available engine */
            OperationFailed = ErrorVoiceControl | 0x014,    /**< Operation failed */
            OperationRejected = ErrorVoiceControl | 0x015,  /**< Operation rejected */
            IterationEnd = ErrorVoiceControl | 0x016,   /**< List reached end */
            Empty = ErrorVoiceControl | 0x017,  /**< List empty */
            ServiceReset = ErrorVoiceControl | 0x018,   /**< Service daemon reset (Since 3.0) */
            InProgressToReady = ErrorVoiceControl | 0x019,  /**< In progress to ready (Since 3.0) */
            InProgressToRecording = ErrorVoiceControl | 0x020,  /**< In progress to recording (Since 3.0) */
            InProgressToProcessing = ErrorVoiceControl | 0x021	/**< In progress to processing (Since 3.0) */
        };

        internal enum VoiceCommandType
        {
            Foreground = 1,   /* Foreground command type. */
            BackGround = 2   /* background command type. */
        };

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_initialize")]
        internal static extern ErrorCode VcInitialize();

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_deinitialize")]
        internal static extern ErrorCode VcDeinitialize();

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_prepare")]
        internal static extern ErrorCode VcPrepare();

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_unprepare")]
        internal static extern ErrorCode VcUnprepare();

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_foreach_supported_languages")]
        internal static extern ErrorCode VcForeachSupportedLanguages(VcSupportedLanguageCb callback, IntPtr userData);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_get_current_language")]
        internal static extern ErrorCode VcGetCurrentLanguage(out string language);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_get_state")]
        internal static extern ErrorCode VcGetState(out State state);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_get_service_state")]
        internal static extern ErrorCode VcGetServiceState(out ServiceState state);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_get_system_command_list")]
        internal static extern ErrorCode VcGetSystemCommandList(out IntPtr vc_sys_cmd_list);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_set_invocation_name")]
        internal static extern ErrorCode VcSetInvocationName(string name);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_request_dialog")]
        internal static extern ErrorCode VcRequestDialog(string dispText, string uttText, bool autoStart);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_set_command_list")]
        internal static extern ErrorCode VcSetCommandList(SafeCommandListHandle cmdList, VoiceCommandType type);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_unset_command_list")]
        internal static extern ErrorCode VcUnsetCommandList(VoiceCommandType type);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_get_result")]
        internal static extern ErrorCode VcGetResult(VcResultCb callback, IntPtr userData);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_set_result_cb")]
        internal static extern ErrorCode VcSetResultCb(VcResultCb callback, IntPtr userData);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_unset_result_cb")]
        internal static extern ErrorCode VcUnsetResultCb();

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_set_service_state_changed_cb")]
        internal static extern ErrorCode VcSetServiceStateChangedCb(VcServiceStateChangedCb callback, IntPtr userData);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_unset_service_state_changed_cb")]
        internal static extern ErrorCode VcUnsetServiceStateChangedCb();

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_set_state_changed_cb")]
        internal static extern ErrorCode VcSetStateChangedCb(VcStateChangedCb callback, IntPtr userData);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_unset_state_changed_cb")]
        internal static extern ErrorCode VcUnsetStateChangedCb();

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_set_current_language_changed_cb")]
        internal static extern ErrorCode VcSetCurrentLanguageChangedCb(VcCurrentLanguageChangedCb callback, IntPtr userData);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_unset_current_language_changed_cb")]
        internal static extern ErrorCode VcUnsetCurrentLanguageChangedCb();

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_set_error_cb")]
        internal static extern ErrorCode VcSetErrorCb(VcErrorCb callback, IntPtr userData);

        [DllImport(Libraries.VoiceControl, EntryPoint = "vc_unset_error_cb")]
        internal static extern ErrorCode VcUnsetErrorCb();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcResultCb(ResultEvent evt, IntPtr cmdList, IntPtr result, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcCurrentLanguageChangedCb(IntPtr previous, IntPtr current, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool VcSupportedLanguageCb(IntPtr language, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcStateChangedCb(State previous, State current, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcServiceStateChangedCb(ServiceState previous, ServiceState current, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcErrorCb(ErrorCode reason, IntPtr userData);
    }
}