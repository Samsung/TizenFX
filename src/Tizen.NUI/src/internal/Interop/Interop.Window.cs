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
        internal static partial class Window
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_New__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(IntPtr jarg1, string jarg2, [MarshalAs(UnmanagedType.U1)] bool jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_New__WithWindowData", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(string name, string className, IntPtr windowData);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Window", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteWindow(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetClass", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetClass(IntPtr jarg1, string jarg2, string jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Raise", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Raise(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Lower", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Lower(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Activate", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Activate(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_AddAvailableOrientation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddAvailableOrientation(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_RemoveAvailableOrientation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RemoveAvailableOrientation(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetPreferredOrientation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPreferredOrientation(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetPreferredOrientation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetPreferredOrientation(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetCurrentOrientation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetCurrentOrientation(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetAvailableOrientations", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetAvailableOrientations(IntPtr jarg1, IntPtr jarg2, int jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetPositionSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPositionSize(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FocusChangedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr FocusChangedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SetAcceptFocus", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetAcceptFocus(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IsFocusAcceptable", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsFocusAcceptable(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Show", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Show(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Hide", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Hide(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IsVisible", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsVisible(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetSupportedAuxiliaryHintCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetSupportedAuxiliaryHintCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetSupportedAuxiliaryHint", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetSupportedAuxiliaryHint(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AddAuxiliaryHint", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint AddAuxiliaryHint(IntPtr jarg1, string jarg2, string jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RemoveAuxiliaryHint", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool RemoveAuxiliaryHint(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SetAuxiliaryHintValue", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool SetAuxiliaryHintValue(IntPtr jarg1, uint jarg2, string jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetAuxiliaryHintValue", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetAuxiliaryHintValue(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetAuxiliaryHintId", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetAuxiliaryHintId(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SetInputRegion", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetInputRegion(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SetType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetType(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetType(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SetNotificationLevel", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SetNotificationLevel(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetNotificationLevel", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetNotificationLevel(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SetOpaqueState", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetOpaqueState(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IsOpaqueState", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsOpaqueState(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SetScreenOffMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SetScreenOffMode(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetScreenOffMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetScreenOffMode(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SetBrightness", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SetBrightness(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetBrightness", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetBrightness(IntPtr jarg1);

            // For windows resized signal
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_ResizeSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ResizeSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetSize(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetSize(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPosition(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetPosition(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetPartialUpdateEnabled", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPartialUpdateEnabled(IntPtr window, [MarshalAs(UnmanagedType.U1)] bool enabled);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_IsPartialUpdateEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsPartialUpdateEnabled(IntPtr window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetTransparency", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr SetTransparency(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_FeedKey_Default_Window", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FeedKeyEvent(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_FeedKey", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FeedKeyEvent(IntPtr window, IntPtr keyEvent);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_FeedTouch", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FeedTouchPoint(IntPtr window, IntPtr touchPoint, int timeStamp);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_FeedWheel", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FeedWheelEvent(IntPtr window, IntPtr wheelEvent);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_FeedHover", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FeedHoverEvent(IntPtr window, IntPtr touchPoint);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_RenderOnce", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RenderOnce(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Add", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Add(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Remove", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Remove(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetBackgroundColor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetBackgroundColor(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetBackgroundColor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetBackgroundColor(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetRootLayer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetRootLayer(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetOverlayLayer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetOverlayLayer(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_KeyEventSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr KeyEventSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_InterceptKeyEventSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr InterceptKeyEventSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GrabKeyTopmost", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GrabKeyTopmost(System.IntPtr Window, int DaliKey);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UngrabKeyTopmost", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool UngrabKeyTopmost(System.IntPtr Window, int DaliKey);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GrabKey", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GrabKey(System.IntPtr Window, int DaliKey, int GrabMode);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UngrabKey", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool UngrabKey(System.IntPtr Window, int DaliKey);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Keyboard_SetRepeatInfo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool SetKeyboardRepeatInfo(float rate, float delay);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Keyboard_GetRepeatInfo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetKeyboardRepeatInfo(out float rate, out float delay);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Keyboard_Set_Horizental_RepeatInfo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool SetKeyboardHorizentalRepeatInfo(float rate, float delay);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Keyboard_Get_Horizental_RepeatInfo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetKeyboardHorizentalRepeatInfo(out float rate, out float delay);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Keyboard_Set_Vertical_RepeatInfo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool SetKeyboardVerticalRepeatInfo(float rate, float delay);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Keyboard_Get_Vertical_RepeatInfo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetKeyboardVerticalRepeatInfo(out float rate, out float delay);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetNativeWindowHandler", StringMarshalling = StringMarshalling.Utf8)]
            public static partial System.IntPtr GetNativeWindowHandler(System.IntPtr Window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetParent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetParent(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetParent_With_Stack", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetParentWithStack(IntPtr child, IntPtr parent, [MarshalAs(UnmanagedType.U1)] bool belowParent);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Unparent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Unparent(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetParent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetParent(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetNativeId", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetNativeId(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_EnableFloatingMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableFloatingMode(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_IsFloatingModeEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsFloatingModeEnabled(IntPtr window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_RequestMoveToServer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RequestMoveToServer(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_RequestResizeToServer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RequestResizeToServer(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetWindow", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Get(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_IncludeInputRegion", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void IncludeInputRegion(IntPtr window, IntPtr inputRegion);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_ExcludeInputRegion", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ExcludeInputRegion(IntPtr window, IntPtr inputRegion);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Maximize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Maximize(IntPtr window, [MarshalAs(UnmanagedType.U1)] bool maximize);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_IsMaximized", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsMaximized(IntPtr window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Set_Maximum_Size", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetMaximumSize(IntPtr window, IntPtr size);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Minimize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Minimize(IntPtr window, [MarshalAs(UnmanagedType.U1)] bool minimize);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_IsMinimized", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsMinimized(IntPtr window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Set_Minimum_Size", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetMimimumSize(IntPtr window, IntPtr size);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Maximize_With_RestoreSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void MaximizeWithRestoreSize(IntPtr window, [MarshalAs(UnmanagedType.U1)] bool maximize, IntPtr size);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetLayout", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetLayout(IntPtr window, uint numCols, uint numRows, uint column, uint row, uint colSpan, uint rowSpan);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_IsWindowRotating", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsWindowRotating(IntPtr window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_InternalRetrievingLastKeyEvent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void InternalRetrievingLastKeyEvent(IntPtr window, IntPtr key);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_InternalRetrievingLastTouchEvent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void InternalRetrievingLastTouchEvent(IntPtr window, IntPtr touch);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_InternalRetrievingLastHoverEvent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void InternalRetrievingLastHoverEvent(IntPtr window, IntPtr hover);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_InternalRetrievingLastPanGestureState", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalRetrievingLastPanGestureState(IntPtr window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetNeedsRotationCompletedAcknowledgement", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetNeedsRotationCompletedAcknowledgement(IntPtr window, [MarshalAs(UnmanagedType.U1)] bool needAcknowledgement);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SendRotationCompletedAcknowledgement", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SendRotationCompletedAcknowledgement(IntPtr window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_KeepRendering", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void KeepRendering(IntPtr window, float durationSeconds);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_PointerConstraintsLock", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool PointerConstraintsLock(IntPtr window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_PointerConstraintsUnlock", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool PointerConstraintsUnlock(IntPtr window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_LockedPointerRegionSet", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void LockedPointerRegionSet(IntPtr window, int x, int y, int w, int h);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_LockedPointerCursorPositionHintSet", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void LockedPointerCursorPositionHintSet(IntPtr window, int x, int y);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_PointerWarp", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool PointerWarp(IntPtr window, int x, int y);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_CursorVisibleSet", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void CursorVisibleSet(IntPtr window, [MarshalAs(UnmanagedType.U1)] bool visible);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_KeyboardGrab", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool KeyboardGrab(IntPtr window, uint deviceSubclass);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_KeyboardUnGrab", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool KeyboardUnGrab(IntPtr window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetFullScreen", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFullScreen(IntPtr window, [MarshalAs(UnmanagedType.U1)] bool fullscreen);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetFullScreen", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetFullScreen(IntPtr window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetModal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetModal(IntPtr window, [MarshalAs(UnmanagedType.U1)] bool modal);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_IsModal", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsModal(IntPtr window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetAlwaysOnTop", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetAlwaysOnTop(IntPtr window, [MarshalAs(UnmanagedType.U1)] bool alwaysTop);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_IsAlwaysOnTop", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsAlwaysOnTop(IntPtr window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetBottom", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetBottom(IntPtr window, [MarshalAs(UnmanagedType.U1)] bool enable);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_IsBottom", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsBottom(IntPtr window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_RelativeMotionGrab", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool RelativeMotionGrab(IntPtr window, uint boundary);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_RelativeMotionUnGrab", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool RelativeMotionUnGrab(IntPtr window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetBlur", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetBlur(IntPtr window, global::System.IntPtr blurInfo);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetBlur", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetBlur(IntPtr window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetInsets__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetInsets(IntPtr window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetInsets__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetInsets(IntPtr window, int insetsFlags);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetScreen", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetScreen(IntPtr window, string name);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetScreen", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetScreen(IntPtr window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_SetFrontBufferRendering", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFrontBufferRendering(IntPtr window, [MarshalAs(UnmanagedType.U1)] bool enable);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetFrontBufferRendering", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetFrontBufferRendering(IntPtr window);
        }
    }
}





