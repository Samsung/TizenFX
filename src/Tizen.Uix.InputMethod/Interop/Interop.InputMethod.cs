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
using Tizen.Uix.InputMethod;

/// <summary>
/// Partial Interop Class
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// InputMethod Interop Class
    /// </summary>
    internal static class InputMethod
    {
        internal static string LogTag = "Tizen.Uix.InputMethod";

        private const int ErrorInputMethod = -0x02F20000;

        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,                           /**< Successful */
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,   /**< Invalid parameter */
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,   /**< Permission denied */
            NoCallbackFunction = ErrorInputMethod | 0x0001,                         /**< Necessary callback function is not set */
            NotRunning = ErrorInputMethod | 0x0002,                                 /**< IME main loop isn't started yet */
            OperationFailed = ErrorInputMethod | 0x0010,                            /**< Operation failed  */
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory              /**< out of memory */
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        internal struct ImeCallbackStruct
        {
            internal ImeCreateCb create;
            internal ImeTerminateCb terminate;
            internal ImeShowCb show;
            internal ImeHideCb hide;
        };

        public enum ImeOptionWindowType
        {
            Keyborad, /**< Open from Keyboard */
            SettingApplication /**< Open from Setting application */
        };

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_run")]
        internal static extern ErrorCode ImeRun(ref ImeCallbackStruct basicCB, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_focus_in_cb")]
        internal static extern ErrorCode ImeEventSetFocusInCb(ImeFocusInCb callbackFunction, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_focus_out_cb")]
        internal static extern ErrorCode ImeEventSetFocusOutCb(ImeFocusOutCb callbackFunction, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_surrounding_text_updated_cb")]
        internal static extern ErrorCode ImeEventSetSurroundingTextUpdatedCb(ImeSurroundingTextUpdatedCb callbackFunction, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_input_context_reset_cb")]
        internal static extern ErrorCode ImeEventSetInputContextResetCb(ImeInputContextResetCb callbackFunction, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_cursor_position_updated_cb")]
        internal static extern ErrorCode ImeEventSetCursorPositionUpdatedCb(ImeCursorPositionUpdatedCb callbackFunction, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_language_requested_cb")]
        internal static extern ErrorCode ImeEventSetLanguageRequestedCb(ImeLanguageRequestedCb callbackFunction, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_language_set_cb")]
        internal static extern ErrorCode ImeEventSetLanguageSetCb(ImeLanguageSetCb callbackFunction, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_imdata_set_cb")]
        internal static extern ErrorCode ImeEventSetImdataSetCb(ImeImdataSetCb callbackFunction, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_imdata_requested_cb")]
        internal static extern ErrorCode ImeEventSetImdataRequestedCb(ImeImdataRequestedCb callbackFunction, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_layout_set_cb")]
        internal static extern ErrorCode ImeEventSetLayoutSetCb(ImeLayoutSetCb callbackFunction, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_return_key_type_set_cb")]
        internal static extern ErrorCode ImeEventSetReturnKeyTypeSetCb(ImeReturnKeyTypeSetCb callbackFunction, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_return_key_state_set_cb")]
        internal static extern ErrorCode ImeEventSetReturnKeyStateSetCb(ImeReturnKeyStateSetCb callbackFunction, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_geometry_requested_cb")]
        internal static extern ErrorCode ImeEventSetGeometryRequestedCb(ImeGeometryRequestedCb callbackFunction, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_process_key_event_cb")]
        internal static extern ErrorCode ImeEventSetProcessKeyEventCb(ImeProcessKeyEventCb callbackFunction, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_display_language_changed_cb")]
        internal static extern ErrorCode ImeEventSetDisplayLanguageChangedCb(ImeDisplayLanguageChangedCb callbackFunction, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_rotation_degree_changed_cb")]
        internal static extern ErrorCode ImeEventSetRotationDegreeChangedCb(ImeRotationDegreeChangedCb callbackFunction, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_accessibility_state_changed_cb")]
        internal static extern ErrorCode ImeEventSetAccessibilityStateChangedCb(ImeAccessibilityStateChangedCb callbackFunction, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_option_window_created_cb")]
        internal static extern ErrorCode ImeEventSetOptionWindowCreatedCb(ImeOptionWindowCreatedCb callbackFunction, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_option_window_destroyed_cb")]
        internal static extern ErrorCode ImeEventSetOptionWindowDestroyedCb(ImeOptionWindowDestroyedCb callbackFunction, IntPtr userData);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_send_key_event")]
        internal static extern ErrorCode ImeSendKeyEvent(KeyCode keycode, KeyMask keymask, bool forwardKey);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_commit_string")]
        internal static extern ErrorCode ImeCommitString(string str);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_show_preedit_string")]
        internal static extern ErrorCode ImeShowPreeditString();
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_hide_preedit_string")]
        internal static extern ErrorCode ImeHidePreeditString();
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_update_preedit_string")]
        internal static extern ErrorCode ImeUpdatePreeditString(string str, IntPtr attrs);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_request_surrounding_text")]
        internal static extern ErrorCode ImeRequestSurroundingText(int maxlenBefore, int maxlenAfter);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_delete_surrounding_text")]
        internal static extern ErrorCode ImeDeleteSurroundingText(int offset, int len);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_get_surrounding_text")]
        internal static extern ErrorCode ImeGetSurroundingText(int maxlenBefore, int maxlenAfter, out IntPtr text, out int cursorPos);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_set_selection")]
        internal static extern ErrorCode ImeSetSelection(int start, int end);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_get_main_window")]
        internal static extern IntPtr ImeGetMainWindow();
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_set_size")]
        internal static extern ErrorCode ImeSetSize(int portraitWidth, int portraitHeight, int landscapeWidth, int landscapeHeight);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_create_option_window")]
        internal static extern ErrorCode ImeCreateOptionWindow();
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_destroy_option_window")]
        internal static extern ErrorCode ImeDestroyOptionWindow(IntPtr window);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_layout")]
        internal static extern ErrorCode ImeContextGetLayout(IntPtr context, out EcoreIMFInputPanelLayout layout);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_layout_variation")]
        internal static extern ErrorCode ImeContextGetLayoutVariation(IntPtr context, out ImeLayoutVariation layoutVariation);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_cursor_position")]
        internal static extern ErrorCode ImeContextGetCursorPosition(IntPtr context, out int cursorPos);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_autocapital_type")]
        internal static extern ErrorCode ImeContextGetAutocapitalType(IntPtr context, out EcoreIMFAutocapitalType autocapitalType);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_return_key_type")]
        internal static extern ErrorCode ImeContextGetReturnKeyType(IntPtr context, out EcoreIMFInputPanelReturnKeyType returnKeyType);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_return_key_state")]
        internal static extern ErrorCode ImeContextGetReturnKeyState(IntPtr context, out bool returnKeyState);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_prediction_mode")]
        internal static extern ErrorCode ImeContextGetPredictionMode(IntPtr context, out bool predictionMode);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_password_mode")]
        internal static extern ErrorCode ImeContextGetPasswordMode(IntPtr context, out bool passwordMode);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_input_hint")]
        internal static extern ErrorCode ImeContextGetInputHint(IntPtr context, out EcoreIMFInputHints inputHint);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_bidi_direction")]
        internal static extern ErrorCode ImeContextGetBidiDirection(IntPtr context, out EcoreIMFBiDiDirection bidi);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_language")]
        internal static extern ErrorCode ImeContextGetLanguage(IntPtr context, out EcoreIMFInputPanelLang language);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_device_info_get_name")]
        internal static extern ErrorCode ImeDeviceInfoGetName(IntPtr dev_info, out string devName);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_device_info_get_class")]
        internal static extern ErrorCode ImeDeviceInfoGetClass(IntPtr dev_info, out EcoreIMFDeviceClass devClass);
        [DllImport(Libraries.InputMethod, EntryPoint = "ime_device_info_get_subclass")]
        internal static extern ErrorCode ImeDeviceInfoGetSubclass(IntPtr dev_info, out EcoreIMFDeviceSubclass devSubClass);



        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeCreateCb(IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeTerminateCb(IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeShowCb(int contextId, IntPtr context, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeHideCb(int contextId, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeFocusInCb(int contextId, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeFocusOutCb(int contextId, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeSurroundingTextUpdatedCb(int contextId, IntPtr text, int cursorPos, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeInputContextResetCb(IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeCursorPositionUpdatedCb(int cursorPos, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeLanguageRequestedCb(IntPtr userData, out IntPtr langCode);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeLanguageSetCb(EcoreIMFInputPanelLang language, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeImdataSetCb(IntPtr data, uint dataLength, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeImdataRequestedCb(IntPtr userData, out IntPtr data, out uint dataLength);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeLayoutSetCb(EcoreIMFInputPanelLayout layout, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeReturnKeyTypeSetCb(EcoreIMFInputPanelReturnKeyType type, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeReturnKeyStateSetCb(bool disabled, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeGeometryRequestedCb(IntPtr userData, out int x, out int y, out int w, out int h);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ImeProcessKeyEventCb(KeyCode keycode, KeyMask keymask, IntPtr devInfo, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeDisplayLanguageChangedCb(IntPtr language, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeRotationDegreeChangedCb(int degree, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeAccessibilityStateChangedCb(bool state, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeOptionWindowCreatedCb(IntPtr window, ImeOptionWindowType type, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeOptionWindowDestroyedCb(IntPtr window, IntPtr userData);
    }
}