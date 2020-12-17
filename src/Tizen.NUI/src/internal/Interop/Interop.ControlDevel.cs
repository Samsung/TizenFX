/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd.
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
            public static extern global::System.IntPtr Dali_Toolkit_DevelControl_AccessibilityActivateSignal(Tizen.NUI.BaseComponents.View.ControlHandle arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingSkippedSignal")]
            public static extern global::System.IntPtr Dali_Toolkit_DevelControl_AccessibilityReadingSkippedSignal(Tizen.NUI.BaseComponents.View.ControlHandle arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingPausedSignal")]
            public static extern global::System.IntPtr Dali_Toolkit_DevelControl_AccessibilityReadingPausedSignal(Tizen.NUI.BaseComponents.View.ControlHandle arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingResumedSignal")]
            public static extern global::System.IntPtr Dali_Toolkit_DevelControl_AccessibilityReadingResumedSignal(Tizen.NUI.BaseComponents.View.ControlHandle arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingCancelledSignal")]
            public static extern global::System.IntPtr Dali_Toolkit_DevelControl_AccessibilityReadingCancelledSignal(Tizen.NUI.BaseComponents.View.ControlHandle arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingStoppedSignal")]
            public static extern global::System.IntPtr Dali_Toolkit_DevelControl_AccessibilityReadingStoppedSignal(Tizen.NUI.BaseComponents.View.ControlHandle arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityGetNameSignal")]
            public static extern global::System.IntPtr Dali_Toolkit_DevelControl_AccessibilityGetNameSignal(Tizen.NUI.BaseComponents.View.ControlHandle arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityGetDescriptionSignal")]
            public static extern global::System.IntPtr Dali_Toolkit_DevelControl_AccessibilityGetDescriptionSignal(Tizen.NUI.BaseComponents.View.ControlHandle arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityDoGestureSignal")]
            public static extern global::System.IntPtr Dali_Toolkit_DevelControl_AccessibilityDoGestureSignal(Tizen.NUI.BaseComponents.View.ControlHandle arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AppendAccessibilityRelation")]
            public static extern void                  Dali_Toolkit_DevelControl_AppendAccessibilityRelation(global::System.Runtime.InteropServices.HandleRef arg1, global::System.Runtime.InteropServices.HandleRef arg2, int arg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_RemoveAccessibilityRelation")]
            public static extern void                  Dali_Toolkit_DevelControl_RemoveAccessibilityRelation(global::System.Runtime.InteropServices.HandleRef arg1, global::System.Runtime.InteropServices.HandleRef arg2, int arg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_new_GetAccessibilityRelations")]
            public static extern global::System.IntPtr Dali_Toolkit_DevelControl_new_GetAccessibilityRelations(global::System.Runtime.InteropServices.HandleRef arg1);

//            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityRelations_Size")]
//            public static extern uint                  Dali_Toolkit_DevelControl_AccessibilityRelations_Size(Tizen.NUI.BaseComponents.View.AddressCollection arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityRelations_RelationSize")]
            public static extern uint                  Dali_Toolkit_DevelControl_AccessibilityRelations_RelationSize(Tizen.NUI.BaseComponents.View.AddressCollection arg1, int relation);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityRelations_At")]
            public static extern string                Dali_Toolkit_DevelControl_AccessibilityRelations_At(Tizen.NUI.BaseComponents.View.AddressCollection arg1, int rel, int pos, int id);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_delete_AccessibilityRelations")]
            public static extern void                  Dali_Toolkit_DevelControl_delete_AccessibilityRelations(Tizen.NUI.BaseComponents.View.AddressCollection arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_ClearAccessibilityRelations")]
            public static extern void                  Dali_Toolkit_DevelControl_ClearAccessibilityRelations(global::System.Runtime.InteropServices.HandleRef arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AppendAccessibilityAttribute")]
            public static extern void                  Dali_Toolkit_DevelControl_AppendAccessibilityAttribute(global::System.Runtime.InteropServices.HandleRef arg1, string arg2, string arg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_RemoveAccessibilityAttribute")]
            public static extern void                  Dali_Toolkit_DevelControl_RemoveAccessibilityAttribute(global::System.Runtime.InteropServices.HandleRef arg1, string arg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_ClearAccessibilityAttributes")]
            public static extern void                  Dali_Toolkit_DevelControl_ClearAccessibilityAttributes(global::System.Runtime.InteropServices.HandleRef arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_SetAccessibilityReadingInfoType")]
            public static extern void                  Dali_Toolkit_DevelControl_SetAccessibilityReadingInfoType(global::System.Runtime.InteropServices.HandleRef arg1, Tizen.NUI.BaseComponents.View.ReadingInfoTypes arg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_new_ReadingInfoType")]
            public static extern global::System.IntPtr Dali_Toolkit_DevelControl_new_ReadingInfoType();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_new_GetAccessibilityReadingInfoType")]
            public static extern global::System.IntPtr Dali_Toolkit_DevelControl_new_GetAccessibilityReadingInfoType(global::System.Runtime.InteropServices.HandleRef arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_delete_ReadingInfoType")]
            public static extern void                  Dali_Toolkit_DevelControl_delete_ReadingInfoType(Tizen.NUI.BaseComponents.View.ReadingInfoTypes arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_ReadingInfoTypes_Get")]
            public static extern bool                  Dali_Toolkit_DevelControl_ReadingInfoTypes_Get(Tizen.NUI.BaseComponents.View.ReadingInfoTypes arg1, int arg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_ReadingInfoTypes_Set")]
            public static extern void                  Dali_Toolkit_DevelControl_ReadingInfoTypes_Set(Tizen.NUI.BaseComponents.View.ReadingInfoTypes arg1, int arg2, int arg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_ClearAccessibilityHighlight")]
            public static extern bool                  Dali_Toolkit_DevelControl_ClearAccessibilityHighlight(global::System.Runtime.InteropServices.HandleRef arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_GrabAccessibilityHighlight")]
            public static extern bool                  Dali_Toolkit_DevelControl_GrabAccessibilityHighlight(global::System.Runtime.InteropServices.HandleRef arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_new_GetAccessibilityStates")]
            public static extern global::System.IntPtr Dali_Toolkit_DevelControl_new_GetAccessibilityStates(global::System.Runtime.InteropServices.HandleRef arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_new_States")]
            public static extern global::System.IntPtr Dali_Toolkit_DevelControl_new_States();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_delete_States")]
            public static extern void                  Dali_Toolkit_DevelControl_delete_States(Tizen.NUI.BaseComponents.View.AccessibilityStates arg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_States_Get")]
            public static extern bool                  Dali_Toolkit_DevelControl_States_Get(Tizen.NUI.BaseComponents.View.AccessibilityStates arg1, int arg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_States_Set")]
            public static extern void                  Dali_Toolkit_DevelControl_States_Set(Tizen.NUI.BaseComponents.View.AccessibilityStates arg1, int arg2, int arg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_NotifyAccessibilityStateChange")]
            public static extern global::System.IntPtr Dali_Toolkit_DevelControl_NotifyAccessibilityStateChange(global::System.Runtime.InteropServices.HandleRef arg1, Tizen.NUI.BaseComponents.View.AccessibilityStates arg2, int arg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_GetBoundAccessibilityObject")]
            public static extern global::System.IntPtr Dali_Toolkit_DevelControl_GetBoundAccessibilityObject(global::System.Runtime.InteropServices.HandleRef arg1);
        }
    }
}

