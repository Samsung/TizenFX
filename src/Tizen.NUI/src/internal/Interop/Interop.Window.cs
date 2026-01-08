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
        internal static partial class Window
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_New__SWIG_0")]
            public static extern global::System.IntPtr New(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, bool jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_New__WithWindowData")]
            public static extern global::System.IntPtr New(string name, string className, global::System.Runtime.InteropServices.HandleRef windowData);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Window")]
            public static extern void DeleteWindow(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetClass")]
            public static extern void SetClass(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Raise")]
            public static extern void Raise(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Lower")]
            public static extern void Lower(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Activate")]
            public static extern void Activate(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_AddAvailableOrientation")]
            public static extern void AddAvailableOrientation(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_RemoveAvailableOrientation")]
            public static extern void RemoveAvailableOrientation(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetPreferredOrientation")]
            public static extern void SetPreferredOrientation(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetPreferredOrientation")]
            public static extern int GetPreferredOrientation(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetCurrentOrientation")]
            public static extern int GetCurrentOrientation(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetAvailableOrientations")]
            public static extern void SetAvailableOrientations(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetPositionSize")]
            public static extern void SetPositionSize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FocusChangedSignal")]
            public static extern global::System.IntPtr FocusChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SetAcceptFocus")]
            public static extern void SetAcceptFocus(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IsFocusAcceptable")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsFocusAcceptable(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Show")]
            public static extern void Show(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Hide")]
            public static extern void Hide(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IsVisible")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsVisible(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetSupportedAuxiliaryHintCount")]
            public static extern uint GetSupportedAuxiliaryHintCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetSupportedAuxiliaryHint")]
            public static extern string GetSupportedAuxiliaryHint(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AddAuxiliaryHint")]
            public static extern uint AddAuxiliaryHint(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RemoveAuxiliaryHint")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool RemoveAuxiliaryHint(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SetAuxiliaryHintValue")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool SetAuxiliaryHintValue(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, string jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetAuxiliaryHintValue")]
            public static extern string GetAuxiliaryHintValue(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetAuxiliaryHintId")]
            public static extern uint GetAuxiliaryHintId(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SetInputRegion")]
            public static extern void SetInputRegion(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SetType")]
            public static extern void SetType(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetType")]
            public static extern int GetType(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SetNotificationLevel")]
            public static extern int SetNotificationLevel(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetNotificationLevel")]
            public static extern int GetNotificationLevel(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SetOpaqueState")]
            public static extern void SetOpaqueState(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IsOpaqueState")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsOpaqueState(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SetScreenOffMode")]
            public static extern int SetScreenOffMode(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetScreenOffMode")]
            public static extern int GetScreenOffMode(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SetBrightness")]
            public static extern int SetBrightness(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetBrightness")]
            public static extern int GetBrightness(global::System.Runtime.InteropServices.HandleRef jarg1);

            // For windows resized signal
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_ResizeSignal")]
            public static extern global::System.IntPtr ResizeSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetSize")]
            public static extern void SetSize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetSize")]
            public static extern global::System.IntPtr GetSize(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetPosition")]
            public static extern void SetPosition(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetPosition")]
            public static extern global::System.IntPtr GetPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetPartialUpdateEnabled")]
            public static extern void SetPartialUpdateEnabled(global::System.Runtime.InteropServices.HandleRef window, bool enabled);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_IsPartialUpdateEnabled")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsPartialUpdateEnabled(global::System.Runtime.InteropServices.HandleRef window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetTransparency")]
            public static extern global::System.IntPtr SetTransparency(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_FeedKey_Default_Window")]
            public static extern void FeedKeyEvent(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_FeedKey")]
            public static extern void FeedKeyEvent(global::System.Runtime.InteropServices.HandleRef window, global::System.Runtime.InteropServices.HandleRef keyEvent);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_FeedTouch")]
            public static extern void FeedTouchPoint(global::System.Runtime.InteropServices.HandleRef window, global::System.Runtime.InteropServices.HandleRef touchPoint, int timeStamp);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_FeedWheel")]
            public static extern void FeedWheelEvent(global::System.Runtime.InteropServices.HandleRef window, global::System.Runtime.InteropServices.HandleRef wheelEvent);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_FeedHover")]
            public static extern void FeedHoverEvent(global::System.Runtime.InteropServices.HandleRef window, global::System.Runtime.InteropServices.HandleRef touchPoint);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_RenderOnce")]
            public static extern void RenderOnce(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Add")]
            public static extern void Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Remove")]
            public static extern void Remove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetBackgroundColor")]
            public static extern void SetBackgroundColor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetBackgroundColor")]
            public static extern global::System.IntPtr GetBackgroundColor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetRootLayer")]
            public static extern global::System.IntPtr GetRootLayer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetOverlayLayer")]
            public static extern global::System.IntPtr GetOverlayLayer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_KeyEventSignal")]
            public static extern global::System.IntPtr KeyEventSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_InterceptKeyEventSignal")]
            public static extern global::System.IntPtr InterceptKeyEventSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GrabKeyTopmost")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool GrabKeyTopmost(System.IntPtr Window, int DaliKey);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UngrabKeyTopmost")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool UngrabKeyTopmost(System.IntPtr Window, int DaliKey);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GrabKey")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool GrabKey(System.IntPtr Window, int DaliKey, int GrabMode);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UngrabKey")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool UngrabKey(System.IntPtr Window, int DaliKey);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Keyboard_SetRepeatInfo")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool SetKeyboardRepeatInfo(float rate, float delay);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Keyboard_GetRepeatInfo")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool GetKeyboardRepeatInfo(out float rate, out float delay);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Keyboard_Set_Horizental_RepeatInfo")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool SetKeyboardHorizentalRepeatInfo(float rate, float delay);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Keyboard_Get_Horizental_RepeatInfo")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool GetKeyboardHorizentalRepeatInfo(out float rate, out float delay);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Keyboard_Set_Vertical_RepeatInfo")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool SetKeyboardVerticalRepeatInfo(float rate, float delay);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Keyboard_Get_Vertical_RepeatInfo")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool GetKeyboardVerticalRepeatInfo(out float rate, out float delay);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetNativeWindowHandler")]
            public static extern System.IntPtr GetNativeWindowHandler(System.IntPtr Window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetParent")]
            public static extern void SetParent(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetParent_With_Stack")]
            public static extern void SetParentWithStack(global::System.Runtime.InteropServices.HandleRef child, global::System.Runtime.InteropServices.HandleRef parent, bool belowParent);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Unparent")]
            public static extern void Unparent(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetParent")]
            public static extern global::System.IntPtr GetParent(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetNativeId")]
            public static extern int GetNativeId(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_EnableFloatingMode")]
            public static extern void EnableFloatingMode(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_IsFloatingModeEnabled")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsFloatingModeEnabled(global::System.Runtime.InteropServices.HandleRef window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_RequestMoveToServer")]
            public static extern void RequestMoveToServer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_RequestResizeToServer")]
            public static extern void RequestResizeToServer(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetWindow")]
            public static extern global::System.IntPtr Get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_IncludeInputRegion")]
            public static extern void IncludeInputRegion(global::System.Runtime.InteropServices.HandleRef window, global::System.Runtime.InteropServices.HandleRef inputRegion);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_ExcludeInputRegion")]
            public static extern void ExcludeInputRegion(global::System.Runtime.InteropServices.HandleRef window, global::System.Runtime.InteropServices.HandleRef inputRegion);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Maximize")]
            public static extern void Maximize(global::System.Runtime.InteropServices.HandleRef window, bool maximize);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_IsMaximized")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsMaximized(global::System.Runtime.InteropServices.HandleRef window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Set_Maximum_Size")]
            public static extern void SetMaximumSize(global::System.Runtime.InteropServices.HandleRef window, global::System.Runtime.InteropServices.HandleRef size);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Minimize")]
            public static extern void Minimize(global::System.Runtime.InteropServices.HandleRef window, bool minimize);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_IsMinimized")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsMinimized(global::System.Runtime.InteropServices.HandleRef window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Set_Minimum_Size")]
            public static extern void SetMimimumSize(global::System.Runtime.InteropServices.HandleRef window, global::System.Runtime.InteropServices.HandleRef size);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Maximize_With_RestoreSize")]
            public static extern void MaximizeWithRestoreSize(global::System.Runtime.InteropServices.HandleRef window, bool maximize, global::System.Runtime.InteropServices.HandleRef size);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetLayout")]
            public static extern void SetLayout(global::System.Runtime.InteropServices.HandleRef window, uint numCols, uint numRows, uint column, uint row, uint colSpan, uint rowSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_IsWindowRotating")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsWindowRotating(global::System.Runtime.InteropServices.HandleRef window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_InternalRetrievingLastKeyEvent")]
            public static extern void InternalRetrievingLastKeyEvent(global::System.Runtime.InteropServices.HandleRef window, global::System.Runtime.InteropServices.HandleRef key);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_InternalRetrievingLastTouchEvent")]
            public static extern void InternalRetrievingLastTouchEvent(global::System.Runtime.InteropServices.HandleRef window, global::System.Runtime.InteropServices.HandleRef touch);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_InternalRetrievingLastHoverEvent")]
            public static extern void InternalRetrievingLastHoverEvent(global::System.Runtime.InteropServices.HandleRef window, global::System.Runtime.InteropServices.HandleRef hover);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_InternalRetrievingLastPanGestureState")]
            public static extern int InternalRetrievingLastPanGestureState(global::System.Runtime.InteropServices.HandleRef window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetNeedsRotationCompletedAcknowledgement")]
            public static extern void SetNeedsRotationCompletedAcknowledgement(global::System.Runtime.InteropServices.HandleRef window, bool needAcknowledgement);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SendRotationCompletedAcknowledgement")]
            public static extern void SendRotationCompletedAcknowledgement(global::System.Runtime.InteropServices.HandleRef window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_KeepRendering")]
            public static extern void KeepRendering(global::System.Runtime.InteropServices.HandleRef window, float durationSeconds);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_PointerConstraintsLock")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool PointerConstraintsLock(global::System.Runtime.InteropServices.HandleRef window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_PointerConstraintsUnlock")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool PointerConstraintsUnlock(global::System.Runtime.InteropServices.HandleRef window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_LockedPointerRegionSet")]
            public static extern void LockedPointerRegionSet(global::System.Runtime.InteropServices.HandleRef window, int x, int y, int w, int h);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_LockedPointerCursorPositionHintSet")]
            public static extern void LockedPointerCursorPositionHintSet(global::System.Runtime.InteropServices.HandleRef window, int x, int y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_PointerWarp")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool PointerWarp(global::System.Runtime.InteropServices.HandleRef window, int x, int y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_CursorVisibleSet")]
            public static extern void CursorVisibleSet(global::System.Runtime.InteropServices.HandleRef window, bool visible);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_KeyboardGrab")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool KeyboardGrab(global::System.Runtime.InteropServices.HandleRef window, uint deviceSubclass);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_KeyboardUnGrab")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool KeyboardUnGrab(global::System.Runtime.InteropServices.HandleRef window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetFullScreen")]
            public static extern void SetFullScreen(global::System.Runtime.InteropServices.HandleRef window, bool fullscreen);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetFullScreen")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool GetFullScreen(global::System.Runtime.InteropServices.HandleRef window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetModal")]
            public static extern void SetModal(global::System.Runtime.InteropServices.HandleRef window, bool modal);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_IsModal")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsModal(global::System.Runtime.InteropServices.HandleRef window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetAlwaysOnTop")]
            public static extern void SetAlwaysOnTop(global::System.Runtime.InteropServices.HandleRef window, bool alwaysTop);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_IsAlwaysOnTop")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsAlwaysOnTop(global::System.Runtime.InteropServices.HandleRef window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetBottom")]
            public static extern void SetBottom(global::System.Runtime.InteropServices.HandleRef window, bool enable);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_IsBottom")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsBottom(global::System.Runtime.InteropServices.HandleRef window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_RelativeMotionGrab")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool RelativeMotionGrab(global::System.Runtime.InteropServices.HandleRef window, uint boundary);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_RelativeMotionUnGrab")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool RelativeMotionUnGrab(global::System.Runtime.InteropServices.HandleRef window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetBlur")]
            public static extern void SetBlur(global::System.Runtime.InteropServices.HandleRef window, global::System.IntPtr blurInfo);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetBlur")]
            public static extern global::System.IntPtr GetBlur(global::System.Runtime.InteropServices.HandleRef window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetInsets__SWIG_0")]
            public static extern global::System.IntPtr GetInsets(global::System.Runtime.InteropServices.HandleRef window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetInsets__SWIG_1")]
            public static extern global::System.IntPtr GetInsets(global::System.Runtime.InteropServices.HandleRef window, int insetsFlags);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetScreen")]
            public static extern void SetScreen(global::System.Runtime.InteropServices.HandleRef window, string name);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetScreen")]
            public static extern string GetScreen(global::System.Runtime.InteropServices.HandleRef window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetFrontBufferRendering")]
            public static extern void SetFrontBufferRendering(global::System.Runtime.InteropServices.HandleRef window, bool enable);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetFrontBufferRendering")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool GetFrontBufferRendering(global::System.Runtime.InteropServices.HandleRef window);
        }
    }
}
