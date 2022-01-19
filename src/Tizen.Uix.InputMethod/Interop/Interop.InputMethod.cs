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
using Tizen.Internals;
using Tizen.Uix.InputMethod;

/// <summary>
/// The Partial Interop class.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// The InputMethod Interop class.
    /// </summary>
    internal static class InputMethod
    {
        internal static string LogTag = "Tizen.Uix.InputMethod";

        private const int ErrorInputMethod = -0x02F20000;

        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            NoCallbackFunction = ErrorInputMethod | 0x0001,
            NotRunning = ErrorInputMethod | 0x0002,
            OperationFailed = ErrorInputMethod | 0x0010,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory
        };

        internal enum ImeEventType
        {
            Language = 1,    /* The language of the input panel */
            ShiftMode = 2,   /* The shift key state of the input panel */
            Geometry = 3     /* The size of the input panel */
        };

        internal enum ImeShiftMode
        {
            Off,
            On
        };

        [NativeStruct("ime_callback_s", Include="inputmethod.h", PkgConfig="capi-ui-inputmethod")]
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        internal struct ImeCallbackStruct
        {
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal ImeCreateCb create;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal ImeTerminateCb terminate;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal ImeShowCb show;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal ImeHideCb hide;
        };

        [NativeStruct("ime_preedit_attribute", Include="inputmethod.h", PkgConfig="capi-ui-inputmethod")]
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        internal struct ImePreEditAttributeStruct
        {
            internal uint start;
            internal uint length;
            internal int type;
            internal uint value;
        };

        internal sealed class ImeCallbackStructGCHandle : IDisposable
        {
            internal ImeCallbackStruct _imeCallbackStruct;
            internal GCHandle _imeCallbackStructHandle;
            public ImeCallbackStructGCHandle()
            {
                _imeCallbackStruct = new ImeCallbackStruct();
                _imeCallbackStructHandle = GCHandle.Alloc(_imeCallbackStruct);
            }

            #region IDisposable Support
            private bool disposedValue = false;

            void Dispose(bool disposing)
            {
                Tizen.Log.Info(LogTag, "In Dispose");
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        Tizen.Log.Info(LogTag, "In Dispose free called");
                        _imeCallbackStructHandle.Free();
                    }

                    disposedValue = true;
                }
            }

            public void Dispose()
            {
                Dispose(true);
            }
            #endregion
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeRunCb();

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_run")]
        internal static extern ErrorCode ImeRun(ref ImeCallbackStruct basicCB, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_focus_in_cb")]
        internal static extern ErrorCode ImeEventSetFocusedInCb(ImeFocusedInCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_focus_out_cb")]
        internal static extern ErrorCode ImeEventSetFocusedOutCb(ImeFocusedOutCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_surrounding_text_updated_cb")]
        internal static extern ErrorCode ImeEventSetSurroundingTextUpdatedCb(ImeSurroundingTextUpdatedCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_input_context_reset_cb")]
        internal static extern ErrorCode ImeEventSetInputContextResetCb(ImeInputContextResetCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_cursor_position_updated_cb")]
        internal static extern ErrorCode ImeEventSetCursorPositionUpdatedCb(ImeCursorPositionUpdatedCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_language_requested_cb")]
        internal static extern ErrorCode ImeEventSetLanguageRequestedCallbackCb(ImeLanguageRequestedCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_language_set_cb")]
        internal static extern ErrorCode ImeEventSetLanguageSetCb(ImeLanguageSetCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_imdata_set_cb")]
        internal static extern ErrorCode ImeEventSetImdataSetCb(ImeImdataSetCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_imdata_requested_cb")]
        internal static extern ErrorCode ImeEventSetImdataRequestedCb(ImeImdataRequestedCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_layout_set_cb")]
        internal static extern ErrorCode ImeEventSetLayoutSetCb(ImeLayoutSetCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_return_key_type_set_cb")]
        internal static extern ErrorCode ImeEventSetReturnKeySetCb(ImeReturnKeySetCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_return_key_state_set_cb")]
        internal static extern ErrorCode ImeEventSetReturnKeyStateSetCb(ImeReturnKeyStateSetCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_geometry_requested_cb")]
        internal static extern ErrorCode ImeEventSetGeometryRequestedCallbackCb(ImeGeometryRequestedCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_process_key_event_cb")]
        internal static extern ErrorCode ImeEventSetProcessKeyEventCb(ImeProcessKeyEventCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_display_language_changed_cb")]
        internal static extern ErrorCode ImeEventSetDisplayLanguageChangedCb(ImeDisplayLanguageChangedCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_rotation_degree_changed_cb")]
        internal static extern ErrorCode ImeEventSetRotationChangedCb(ImeRotationChangedCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_accessibility_state_changed_cb")]
        internal static extern ErrorCode ImeEventSetAccessibilityStateChangedCb(ImeAccessibilityStateChangedCb callbackFunction, IntPtr userData);

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

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_request_hide")]
        internal static extern ErrorCode ImeRequestHide();

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_prepare")]
        internal static extern ErrorCode ImePrepare();

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_initialize")]
        internal static extern ErrorCode ImeInitialize();

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_finalize")]
        internal static extern ErrorCode ImeFinalize();

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_set_dotnet_flag")]
        internal static extern ErrorCode ImeSetDotnetFlag(bool set);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_set_size")]
        internal static extern ErrorCode ImeSetSize(int portraitWidth, int portraitHeight, int landscapeWidth, int landscapeHeight);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_layout")]
        internal static extern ErrorCode ImeContextGetLayout(IntPtr context, out InputPanelLayout layout);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_layout_variation")]
        internal static extern ErrorCode ImeContextGetLayoutVariation(IntPtr context, out LayoutVariation layoutVariation);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_cursor_position")]
        internal static extern ErrorCode ImeContextGetCursorPosition(IntPtr context, out int cursorPos);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_autocapital_type")]
        internal static extern ErrorCode ImeContextGetAutocapitalType(IntPtr context, out AutoCapitalization autocapitalType);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_return_key_type")]
        internal static extern ErrorCode ImeContextGetReturnKey(IntPtr context, out InputPanelReturnKey returnKeyType);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_return_key_state")]
        internal static extern ErrorCode ImeContextGetReturnKeyState(IntPtr context, out bool returnKeyState);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_prediction_mode")]
        internal static extern ErrorCode ImeContextGetPredictionMode(IntPtr context, out bool predictionMode);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_password_mode")]
        internal static extern ErrorCode ImeContextGetPasswordMode(IntPtr context, out bool passwordMode);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_input_hint")]
        internal static extern ErrorCode ImeContextGetInputHint(IntPtr context, out InputHints inputHint);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_bidi_direction")]
        internal static extern ErrorCode ImeContextGetBidiDirection(IntPtr context, out BiDirection bidi);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_context_get_language")]
        internal static extern ErrorCode ImeContextGetLanguage(IntPtr context, out InputPanelLanguage language);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_device_info_get_name")]
        internal static extern ErrorCode ImeDeviceInfoGetName(IntPtr dev_info, out string devName);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_device_info_get_class")]
        internal static extern ErrorCode ImeDeviceInfoGetClass(IntPtr dev_info, out DeviceClass devClass);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_device_info_get_subclass")]
        internal static extern ErrorCode ImeDeviceInfoGetSubclass(IntPtr dev_info, out DeviceSubclass devSubClass);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_set_floating_mode")]
        internal static extern ErrorCode ImeSetFloatingMode(bool floatingMode);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_set_floating_drag_start")]
        internal static extern ErrorCode ImeSetFloatingDragStart();

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_set_floating_drag_end")]
        internal static extern ErrorCode ImeSetFloatingDragEnd();

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_update_input_panel_event")]
        internal static extern ErrorCode ImeUpdateInputPanelEvent(ImeEventType type, uint value);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_get_selected_text")]
        internal static extern ErrorCode ImeGetSelectedText(out IntPtr text);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_prediction_hint_set_cb")]
        internal static extern ErrorCode ImeEventSetPredictionHintSetCb(ImePredictionHintSetCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_prediction_hint_data_set_cb")]
        internal static extern ErrorCode ImeEventSetPredictionHintDataSetCb(ImePredictionHintDataSetCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_mime_type_set_request_cb")]
        internal static extern ErrorCode ImeEventSetMimeTypeSetRequestCb(ImeMimeTypeSetRequestCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_send_private_command")]
        internal static extern ErrorCode ImeSendPrivateCommand(string command);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_commit_content")]
        internal static extern ErrorCode ImeCommitContent(string content, string description, string mimeType);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_set_native_window_size")]
        internal static extern ErrorCode ImeSetNativeWindowSize(IntPtr window, int portraitWidth, int portraitHeight, int landscapeWidth, int landscapeHeight);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_process_key_event_with_keycode_cb")]
        internal static extern ErrorCode ImeEventSetProcessKeyEventWithKeycodeCb(ImeProcessKeyEventWithKeycodeCb callbackFunction, IntPtr userData);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_update_preedit_cursor")]
        internal static extern ErrorCode ImeUpdatePreeditCursor(uint position);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_set_candidate_visibility_state")]
        internal static extern ErrorCode ImeSetCandidateVisibilityState(bool visible);

        [DllImport(Libraries.InputMethod, EntryPoint = "ime_event_set_input_hint_set_cb")]
        internal static extern ErrorCode ImeEventSetInputHintSetCb(ImeInputHintSetCb callbackFunction, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeCreateCb(IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeTerminateCb(IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeShowCb(int contextId, IntPtr context, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeHideCb(int contextId, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeFocusedInCb(int contextId, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeFocusedOutCb(int contextId, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeSurroundingTextUpdatedCb(int contextId, IntPtr text, int cursorPos, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeInputContextResetCb(IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeCursorPositionUpdatedCb(int cursorPos, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeLanguageRequestedCb(IntPtr userData, out IntPtr langCode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeLanguageSetCb(InputPanelLanguage language, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeImdataSetCb(IntPtr data, uint dataLength, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeImdataRequestedCb(IntPtr userData, out IntPtr data, out uint dataLength);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeLayoutSetCb(InputPanelLayout layout, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeReturnKeySetCb(InputPanelReturnKey type, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeReturnKeyStateSetCb(bool disabled, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeGeometryRequestedCb(IntPtr userData, out int x, out int y, out int w, out int h);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ImeProcessKeyEventCb(KeyCode keycode, KeyMask keymask, IntPtr devInfo, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeDisplayLanguageChangedCb(IntPtr language, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeRotationChangedCb(int degree, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeAccessibilityStateChangedCb(bool state, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImePredictionHintSetCb(IntPtr predictionHint, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImePredictionHintDataSetCb(IntPtr key, IntPtr keyValue, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeMimeTypeSetRequestCb(IntPtr mimeType, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ImeProcessKeyEventWithKeycodeCb(uint keyCode, KeyCode keySym, KeyMask keyMask, IntPtr devInfo, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ImeInputHintSetCb(InputHints hint, IntPtr userData);
    }
}
