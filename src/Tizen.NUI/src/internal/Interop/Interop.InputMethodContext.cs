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

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class InputMethodContext
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_InputMethodContext_EventData__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewInputMethodContextEventData();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_InputMethodContext_EventData__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewInputMethodContextEventData(int jarg1, string jarg2, int jarg3, int jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_predictiveString_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EventDataPredictiveStringSet(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_predictiveString_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string EventDataPredictiveStringGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_eventName_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EventDataEventNameSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_eventName_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EventDataEventNameGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_cursorOffset_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EventDataCursorOffsetSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_cursorOffset_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EventDataCursorOffsetGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_numberOfChars_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EventDataNumberOfCharsSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_EventData_numberOfChars_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EventDataNumberOfCharsGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_InputMethodContext_EventData", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteInputMethodContextEventData(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_InputMethodContext_CallbackData__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewInputMethodContextCallbackData();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_InputMethodContext_CallbackData__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewInputMethodContextCallbackData([MarshalAs(UnmanagedType.U1)] bool jarg1, int jarg2, string jarg3, [MarshalAs(UnmanagedType.U1)] bool jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_currentText_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void CallbackDataCurrentTextSet(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_currentText_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string CallbackDataCurrentTextGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_cursorPosition_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void CallbackDataCursorPositionSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_cursorPosition_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int CallbackDataCursorPositionGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_update_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void CallbackDataUpdateSet(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_update_get", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool CallbackDataUpdateGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_preeditResetRequired_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void CallbackDataPreeditResetRequiredSet(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_CallbackData_preeditResetRequired_get", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool CallbackDataPreeditResetRequiredGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_InputMethodContext_CallbackData", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteInputMethodContextCallbackData(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_Finalize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Finalize(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_InputMethodContext", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteInputMethodContext(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_InputMethodContext__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewInputMethodContext(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Assign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_DownCast", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr DownCast(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_Activate", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Activate(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_Deactivate", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Deactivate(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_RestoreAfterFocusLost", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool RestoreAfterFocusLost(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_SetRestoreAfterFocusLost", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetRestoreAfterFocusLost(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_Reset", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Reset(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_NotifyCursorPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void NotifyCursorPosition(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_SetCursorPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetCursorPosition(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_GetCursorPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetCursorPosition(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_SetSurroundingText", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetSurroundingText(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_GetSurroundingText", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetSurroundingText(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_NotifyTextInputMultiLine", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void NotifyTextInputMultiLine(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_GetTextDirection", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetTextDirection(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_GetInputMethodArea", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetInputMethodArea(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_SetInputPanelUserData", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetInputPanelUserData(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_GetInputPanelUserData", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GetInputPanelUserData(IntPtr jarg1, out string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_GetInputPanelState", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetInputPanelState(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_SetReturnKeyState", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetReturnKeyState(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_AutoEnableInputPanel", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AutoEnableInputPanel(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_ShowInputPanel", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ShowInputPanel(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_HideInputPanel", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void HideInputPanel(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_GetKeyboardType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetKeyboardType(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_GetInputPanelLocale", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetInputPanelLocale(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_SetMIMEType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetMIMEType(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_AllowTextPrediction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AllowTextPrediction(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_IsTextPredictionAllowed", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsTextPredictionAllowed(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_SetFullScreenMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFullScreenMode(IntPtr inputMethodContext, [MarshalAs(UnmanagedType.U1)] bool fullScreen);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_IsFullScreenMode", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsFullScreenMode(IntPtr inputMethodContext);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_SetInputPanelLanguage", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetInputPanelLanguage(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_GetInputPanelLanguage", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetInputPanelLanguage(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_SetInputPanelPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetInputPanelPosition(IntPtr jarg1, uint jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_SetInputPanelPositionAlign", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool SetInputPanelPositionAlign(IntPtr inputMethodContext, int x, int y, int align);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_ActivatedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ActivatedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_EventReceivedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr EventReceivedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_StatusChangedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr StatusChangedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_ResizedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ResizedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_LanguageChangedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr LanguageChangedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_KeyboardTypeChangedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr KeyboardTypeChangedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodContext_ContentReceivedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ContentReceivedSignal(IntPtr jarg1);
        }
    }
}





