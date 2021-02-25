/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class InputMethodContext
        {
            //////////////////////InputMethodContext
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_SWIGUpcast")]
            public static extern global::System.IntPtr Upcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_InputMethodContext_EventData__SWIG_0")]
            public static extern global::System.IntPtr NewInputMethodContextEventData();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_InputMethodContext_EventData__SWIG_1")]
            public static extern global::System.IntPtr NewInputMethodContextEventData(int jarg1, string jarg2, int jarg3, int jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_predictiveString_set")]
            public static extern void EventDataPredictiveStringSet(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_predictiveString_get")]
            public static extern string EventDataPredictiveStringGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_eventName_set")]
            public static extern void EventDataEventNameSet(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_eventName_get")]
            public static extern int EventDataEventNameGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_cursorOffset_set")]
            public static extern void EventDataCursorOffsetSet(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_cursorOffset_get")]
            public static extern int EventDataCursorOffsetGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_numberOfChars_set")]
            public static extern void EventDataNumberOfCharsSet(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_numberOfChars_get")]
            public static extern int EventDataNumberOfCharsGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_InputMethodContext_EventData")]
            public static extern void DeleteInputMethodContextEventData(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_InputMethodContext_CallbackData__SWIG_0")]
            public static extern global::System.IntPtr NewInputMethodContextCallbackData();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_InputMethodContext_CallbackData__SWIG_1")]
            public static extern global::System.IntPtr NewInputMethodContextCallbackData(bool jarg1, int jarg2, string jarg3, bool jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_currentText_set")]
            public static extern void CallbackDataCurrentTextSet(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_currentText_get")]
            public static extern string CallbackDataCurrentTextGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_cursorPosition_set")]
            public static extern void CallbackDataCursorPositionSet(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_cursorPosition_get")]
            public static extern int CallbackDataCursorPositionGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_update_set")]
            public static extern void CallbackDataUpdateSet(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_update_get")]
            public static extern bool CallbackDataUpdateGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_preeditResetRequired_set")]
            public static extern void CallbackDataPreeditResetRequiredSet(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_preeditResetRequired_get")]
            public static extern bool CallbackDataPreeditResetRequiredGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_InputMethodContext_CallbackData")]
            public static extern void DeleteInputMethodContextCallbackData(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_Finalize")]
            public static extern void Finalize(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_InputMethodContext__SWIG_0")]
            public static extern global::System.IntPtr NewInputMethodContext();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_InputMethodContext")]
            public static extern void DeleteInputMethodContext(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_New")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_InputMethodContext__SWIG_1")]
            public static extern global::System.IntPtr NewInputMethodContext(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_Assign")]
            public static extern global::System.IntPtr Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_DownCast")]
            public static extern global::System.IntPtr DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_Activate")]
            public static extern void Activate(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_Deactivate")]
            public static extern void Deactivate(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_RestoreAfterFocusLost")]
            public static extern bool RestoreAfterFocusLost(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_SetRestoreAfterFocusLost")]
            public static extern void SetRestoreAfterFocusLost(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_Reset")]
            public static extern void Reset(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_NotifyCursorPosition")]
            public static extern void NotifyCursorPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_SetCursorPosition")]
            public static extern void SetCursorPosition(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_GetCursorPosition")]
            public static extern uint GetCursorPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_SetSurroundingText")]
            public static extern void SetSurroundingText(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_GetSurroundingText")]
            public static extern string GetSurroundingText(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_NotifyTextInputMultiLine")]
            public static extern void NotifyTextInputMultiLine(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_GetTextDirection")]
            public static extern int GetTextDirection(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_GetInputMethodArea")]
            public static extern global::System.IntPtr GetInputMethodArea(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_ApplyOptions")]
            public static extern void ApplyOptions(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_SetInputPanelUserData")]
            public static extern void SetInputPanelUserData(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_GetInputPanelUserData")]
            public static extern void GetInputPanelUserData(global::System.Runtime.InteropServices.HandleRef jarg1, out string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_GetInputPanelState")]
            public static extern int GetInputPanelState(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_SetReturnKeyState")]
            public static extern void SetReturnKeyState(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_AutoEnableInputPanel")]
            public static extern void AutoEnableInputPanel(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_ShowInputPanel")]
            public static extern void ShowInputPanel(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_HideInputPanel")]
            public static extern void HideInputPanel(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_GetKeyboardType")]
            public static extern int GetKeyboardType(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_GetInputPanelLocale")]
            public static extern string GetInputPanelLocale(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_SetMIMEType")]
            public static extern void SetMIMEType(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_AllowTextPrediction")]
            public static extern void AllowTextPrediction(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_IsTextPredictionAllowed")]
            public static extern bool IsTextPredictionAllowed(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_SetInputPanelLanguage")]
            public static extern void SetInputPanelLanguage(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_GetInputPanelLanguage")]
            public static extern int GetInputPanelLanguage(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_SetInputPanelPosition")]
            public static extern void SetInputPanelPosition(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_ActivatedSignal")]
            public static extern global::System.IntPtr ActivatedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_EventReceivedSignal")]
            public static extern global::System.IntPtr EventReceivedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_StatusChangedSignal")]
            public static extern global::System.IntPtr StatusChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_ResizedSignal")]
            public static extern global::System.IntPtr ResizedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_LanguageChangedSignal")]
            public static extern global::System.IntPtr LanguageChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_KeyboardTypeChangedSignal")]
            public static extern global::System.IntPtr KeyboardTypeChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_ContentReceivedSignal")]
            public static extern global::System.IntPtr ContentReceivedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
