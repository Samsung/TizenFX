// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;
using static Interop.VoiceControlCommand;
using Tizen.Uix.VoiceControlWidget;
using Tizen;

internal static partial class Interop
{
    internal static partial class VoiceControlWidget
    {
        internal static string LogTag = "Tizen.Uix.VoiceControlWidget";

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

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_initialize")]
        internal static extern ErrorCode VcWidgetInitialize(out IntPtr widget);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_deinitialize")]
        internal static extern ErrorCode VcWidgetDeinitialize(IntPtr widget);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_prepare")]
        internal static extern ErrorCode VcWidgetPrepare(IntPtr widget);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_unprepare")]
        internal static extern ErrorCode VcWidgetUnprepare(IntPtr widget);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_foreach_supported_languages")]
        internal static extern ErrorCode VcWidgetForeachSupportedLanguages(IntPtr widget, VcWidgetSupportedLanguageCb callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_get_current_language")]
        internal static extern ErrorCode VcWidgetGetCurrentLanguage(IntPtr widget, out string language);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_get_state")]
        internal static extern ErrorCode VcWidgetGetState(IntPtr widget, out State state);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_get_service_state")]
        internal static extern ErrorCode VcWidgetGetServiceState(IntPtr widget, out ServiceState state);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_is_command_format_supported")]
        internal static extern ErrorCode VcWidgetIsCommandFormatSupported(IntPtr widget, CommandFormat format, out bool support);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_set_foreground")]
        internal static extern ErrorCode VcWidgetSetForeground(IntPtr widget, bool value);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_cancel")]
        internal static extern ErrorCode VcWidgetCancel(IntPtr widget);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_set_result_cb")]
        internal static extern ErrorCode VcWidgetSetResultCb(IntPtr widget, VcWidgetResultCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_unset_result_cb")]
        internal static extern ErrorCode VcWidgetUnsetResultCb(IntPtr widget);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_set_state_changed_cb")]
        internal static extern ErrorCode VcWidgetSetStateChangedCb(IntPtr widget, VcWidgetStateChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_unset_state_changed_cb")]
        internal static extern ErrorCode VcWidgetUnsetStateChangedCb(IntPtr widget);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_set_service_state_changed_cb")]
        internal static extern ErrorCode VcWidgetSetServiceStateChangedCb(IntPtr widget, VcWidgetServiceStateChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_unset_service_state_changed_cb")]
        internal static extern ErrorCode VcWidgetUnsetServiceStateChangedCb(IntPtr widget);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_set_show_tooltip_cb")]
        internal static extern ErrorCode VcWidgetSetShowTooltipCb(IntPtr widget, VcWidgetShowTooltipCb callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_unset_show_tooltip_cb")]
        internal static extern ErrorCode VcWidgetUnSetShowTooltipCb(IntPtr widget);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_set_current_language_changed_cb")]
        internal static extern ErrorCode VcWidgetSetCurrentLanguageChangedCb(IntPtr widget, VcWidgetCurrentLanguageChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_unset_current_language_changed_cb")]
        internal static extern ErrorCode VcWidgetUnsetCurrentLanguageChangedCb(IntPtr widget);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_set_error_cb")]
        internal static extern ErrorCode VcWidgetSetErrorCb(IntPtr widget, VcWidgetErrorCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_unset_error_cb")]
        internal static extern ErrorCode VcWidgetUnsetErrorCb(IntPtr widget);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_set_send_current_command_list_cb")]
        internal static extern ErrorCode VcWidgetSetSendCurrentCommandListCb(IntPtr widget, VcWidgetSendCurrentCommandListCb callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_unset_send_current_command_list_cb")]
        internal static extern ErrorCode VcWidgetUnSetSendCurrentCommandListCb(IntPtr widget);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_enable_asr_result")]
        internal static extern ErrorCode VcWidgetEnableAsrResult(IntPtr widget, bool enable);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_set_asr_result_cb")]
        internal static extern ErrorCode VcWidgetSetAsrResultCb(IntPtr widget, VcWidgetAsrResultCallback callback, IntPtr userData);

        [DllImport(Libraries.VoiceControlWidget, EntryPoint = "vc_widget_unset_asr_result_cb")]
        internal static extern ErrorCode VcWidgetUnSetAsrResultCb(IntPtr widget);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate bool VcWidgetAsrResultCallback(ResultEvent evt, IntPtr result, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate bool VcWidgetSupportedLanguageCb(IntPtr language, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void VcWidgetShowTooltipCb(bool show, IntPtr userData);

        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void VcWidgetSendCurrentCommandListCb(out IntPtr listPtr, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcWidgetCurrentLanguageChangedCallback(IntPtr previous, IntPtr current, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcWidgetStateChangedCallback(State previous, State current, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcWidgetServiceStateChangedCallback(ServiceState previous, ServiceState current, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcWidgetErrorCallback(ErrorCode reason, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VcWidgetResultCallback(ResultEvent evt, IntPtr cmdList, IntPtr result, IntPtr userData);
    }
}
