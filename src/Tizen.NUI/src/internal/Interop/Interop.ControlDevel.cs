/*
 * Copyright (c) 2020-2021 Samsung Electronics Co., Ltd.
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ControlDevel
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityActivateSignal")]
            public static extern global::System.IntPtr DaliToolkitDevelControlAccessibilityActivateSignal(Tizen.NUI.BaseComponents.View.ControlHandle arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingSkippedSignal")]
            public static extern global::System.IntPtr DaliToolkitDevelControlAccessibilityReadingSkippedSignal(Tizen.NUI.BaseComponents.View.ControlHandle arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingPausedSignal")]
            public static extern global::System.IntPtr DaliToolkitDevelControlAccessibilityReadingPausedSignal(Tizen.NUI.BaseComponents.View.ControlHandle arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingResumedSignal")]
            public static extern global::System.IntPtr DaliToolkitDevelControlAccessibilityReadingResumedSignal(Tizen.NUI.BaseComponents.View.ControlHandle arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingCancelledSignal")]
            public static extern global::System.IntPtr DaliToolkitDevelControlAccessibilityReadingCancelledSignal(Tizen.NUI.BaseComponents.View.ControlHandle arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingStoppedSignal")]
            public static extern global::System.IntPtr DaliToolkitDevelControlAccessibilityReadingStoppedSignal(Tizen.NUI.BaseComponents.View.ControlHandle arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityGetNameSignal")]
            public static extern global::System.IntPtr DaliToolkitDevelControlAccessibilityGetNameSignal(Tizen.NUI.BaseComponents.View.ControlHandle arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityGetDescriptionSignal")]
            public static extern global::System.IntPtr DaliToolkitDevelControlAccessibilityGetDescriptionSignal(Tizen.NUI.BaseComponents.View.ControlHandle arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityDoGestureSignal")]
            public static extern global::System.IntPtr DaliToolkitDevelControlAccessibilityDoGestureSignal(Tizen.NUI.BaseComponents.View.ControlHandle arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AppendAccessibilityRelation")]
            public static extern void                  DaliToolkitDevelControlAppendAccessibilityRelation(global::System.Runtime.InteropServices.HandleRef arg1, global::System.Runtime.InteropServices.HandleRef arg2, int arg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_RemoveAccessibilityRelation")]
            public static extern void                  DaliToolkitDevelControlRemoveAccessibilityRelation(global::System.Runtime.InteropServices.HandleRef arg1, global::System.Runtime.InteropServices.HandleRef arg2, int arg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_new_GetAccessibilityRelations")]
            public static extern global::System.IntPtr DaliToolkitDevelControlNewGetAccessibilityRelations(global::System.Runtime.InteropServices.HandleRef arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityRelations_RelationSize")]
            public static extern uint                  DaliToolkitDevelControlAccessibilityRelationsRelationSize(Tizen.NUI.BaseComponents.AddressCollection arg1, int relation);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityRelations_At")]
            public static extern string                DaliToolkitDevelControlAccessibilityRelationsAt(Tizen.NUI.BaseComponents.AddressCollection arg1, int rel, int pos, int id);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_delete_AccessibilityRelations")]
            public static extern void                  DaliToolkitDevelControlDeleteAccessibilityRelations(IntPtr arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_ClearAccessibilityRelations")]
            public static extern void                  DaliToolkitDevelControlClearAccessibilityRelations(global::System.Runtime.InteropServices.HandleRef arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AppendAccessibilityAttribute")]
            public static extern void                  DaliToolkitDevelControlAppendAccessibilityAttribute(global::System.Runtime.InteropServices.HandleRef arg1, string arg2, string arg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_RemoveAccessibilityAttribute")]
            public static extern void                  DaliToolkitDevelControlRemoveAccessibilityAttribute(global::System.Runtime.InteropServices.HandleRef arg1, string arg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_ClearAccessibilityAttributes")]
            public static extern void                  DaliToolkitDevelControlClearAccessibilityAttributes(global::System.Runtime.InteropServices.HandleRef arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_SetAccessibilityReadingInfoType")]
            public static extern void                  DaliToolkitDevelControlSetAccessibilityReadingInfoType(global::System.Runtime.InteropServices.HandleRef arg1, Tizen.NUI.BaseComponents.ReadingInfoTypes arg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_new_ReadingInfoType")]
            public static extern global::System.IntPtr DaliToolkitDevelControlNewReadingInfoType();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_new_GetAccessibilityReadingInfoType")]
            public static extern global::System.IntPtr DaliToolkitDevelControlNewGetAccessibilityReadingInfoType(global::System.Runtime.InteropServices.HandleRef arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_delete_ReadingInfoType")]
            public static extern void                  DaliToolkitDevelControlDeleteReadingInfoType(IntPtr arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_ReadingInfoTypes_Get")]
            public static extern bool                  DaliToolkitDevelControlReadingInfoTypesGet(Tizen.NUI.BaseComponents.ReadingInfoTypes arg1, int arg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_ReadingInfoTypes_Set")]
            public static extern void                  DaliToolkitDevelControlReadingInfoTypesSet(Tizen.NUI.BaseComponents.ReadingInfoTypes arg1, int arg2, int arg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_ClearAccessibilityHighlight")]
            public static extern bool                  DaliToolkitDevelControlClearAccessibilityHighlight(global::System.Runtime.InteropServices.HandleRef arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_GrabAccessibilityHighlight")]
            public static extern bool                  DaliToolkitDevelControlGrabAccessibilityHighlight(global::System.Runtime.InteropServices.HandleRef arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_new_GetAccessibilityStates")]
            public static extern global::System.IntPtr DaliToolkitDevelControlNewGetAccessibilityStates(global::System.Runtime.InteropServices.HandleRef arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_new_States")]
            public static extern global::System.IntPtr DaliToolkitDevelControlNewStates();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_delete_States")]
            public static extern void                  DaliToolkitDevelControlDeleteStates(IntPtr arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_States_Get")]
            public static extern bool                  DaliToolkitDevelControlStatesGet(Tizen.NUI.BaseComponents.AccessibilityStates arg1, int arg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_States_Set")]
            public static extern void                  DaliToolkitDevelControlStatesSet(Tizen.NUI.BaseComponents.AccessibilityStates arg1, int arg2, int arg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_NotifyAccessibilityStateChange")]
            public static extern global::System.IntPtr DaliToolkitDevelControlNotifyAccessibilityStateChange(global::System.Runtime.InteropServices.HandleRef arg1, Tizen.NUI.BaseComponents.AccessibilityStates arg2, int arg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_GetBoundAccessibilityObject")]
            public static extern global::System.IntPtr DaliToolkitDevelControlGetBoundAccessibilityObject(global::System.Runtime.InteropServices.HandleRef arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_EmitAccessibilityEvent")]
            public static extern global::System.IntPtr DaliAccessibilityEmitAccessibilityEvent(global::System.Runtime.InteropServices.HandleRef arg1, int arg2_event);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_EmitAccessibilityStateChangedEvent")]
            public static extern global::System.IntPtr DaliAccessibilityEmitAccessibilityStateChangedEvent(global::System.Runtime.InteropServices.HandleRef arg1, int arg2_state, int arg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_EmitTextInsertedEvent")]
            public static extern global::System.IntPtr DaliAccessibilityEmitTextInsertedEvent(global::System.Runtime.InteropServices.HandleRef arg1, int arg2_pos, int arg3_len, string arg3_content);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_EmitTextDeletedEvent")]
            public static extern global::System.IntPtr DaliAccessibilityEmitTextDeletedEvent(global::System.Runtime.InteropServices.HandleRef arg1, int arg2_pos, int arg3_len, string arg3_content);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_EmitTextCaretMovedEvent")]
            public static extern global::System.IntPtr DaliAccessibilityEmitTextCaretMovedEvent(global::System.Runtime.InteropServices.HandleRef arg1, int arg2_pos);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_new_Range")]
            public static extern global::System.IntPtr DaliAccessibilityNewRange(int arg1_start, int arg2_end, string arg3_content);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_delete_Range")]
            public static extern void                  DaliAccessibilityDeleteRange(IntPtr arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_Bridge_Add_Popup")]
            public static extern void                  DaliAccessibilityBridgeAddPopup(global::System.Runtime.InteropServices.HandleRef arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_Bridge_Remove_Popup")]
            public static extern void                  DaliAccessibilityBridgeRemovePopup(global::System.Runtime.InteropServices.HandleRef arg1);
        }
    }
}
