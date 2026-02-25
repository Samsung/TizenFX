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
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ControlDevel
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AppendAccessibilityRelation")]
            public static extern void DaliToolkitDevelControlAppendAccessibilityRelation(HandleRef arg1, HandleRef arg2, int arg3);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_RemoveAccessibilityRelation")]
            public static extern void DaliToolkitDevelControlRemoveAccessibilityRelation(HandleRef arg1, HandleRef arg2, int arg3);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void GetAccessibilityRelationsCallback(int relationType, IntPtr relationTarget, IntPtr userData);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_GetAccessibilityRelations")]
            public static extern void DaliToolkitDevelControlGetAccessibilityRelations(HandleRef arg1_control, GetAccessibilityRelationsCallback arg2_callback, IntPtr arg3_userData);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_ClearAccessibilityRelations")]
            public static extern void DaliToolkitDevelControlClearAccessibilityRelations(HandleRef arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AppendAccessibilityAttribute")]
            public static extern void DaliToolkitDevelControlAppendAccessibilityAttribute(HandleRef arg1, string arg2_key, string arg3_value);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_RemoveAccessibilityAttribute")]
            public static extern void DaliToolkitDevelControlRemoveAccessibilityAttribute(HandleRef arg1, string arg2_key);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_SetAccessibilityReadingInfoType2")]
            public static extern void DaliToolkitDevelControlSetAccessibilityReadingInfoTypes(HandleRef arg1, int arg2);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_GetAccessibilityReadingInfoType2")]
            public static extern int DaliToolkitDevelControlGetAccessibilityReadingInfoTypes(HandleRef arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_ClearAccessibilityHighlight")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool DaliToolkitDevelControlClearAccessibilityHighlight(HandleRef arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_GrabAccessibilityHighlight")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool DaliToolkitDevelControlGrabAccessibilityHighlight(HandleRef arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_GetAccessibilityStates")]
            public static extern ulong DaliToolkitDevelControlGetAccessibilityStates(HandleRef arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_NotifyAccessibilityStateChange")]
            public static extern IntPtr DaliToolkitDevelControlNotifyAccessibilityStateChange(HandleRef arg1, ulong arg2, int arg3);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_EmitAccessibilityEvent")]
            public static extern IntPtr DaliAccessibilityEmitAccessibilityEvent(HandleRef arg1, int arg2_event);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_EmitAccessibilityStateChangedEvent")]
            public static extern IntPtr DaliAccessibilityEmitAccessibilityStateChangedEvent(HandleRef arg1, int arg2_state, int arg3);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_EmitTextInsertedEvent")]
            public static extern IntPtr DaliAccessibilityEmitTextInsertedEvent(HandleRef arg1, int arg2_pos, int arg3_len, string arg3_content);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_EmitTextDeletedEvent")]
            public static extern IntPtr DaliAccessibilityEmitTextDeletedEvent(HandleRef arg1, int arg2_pos, int arg3_len, string arg3_content);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_EmitTextCursorMovedEvent")]
            public static extern IntPtr DaliAccessibilityEmitTextCursorMovedEvent(HandleRef arg1, int arg2_pos);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_EmitScrollStartedEvent")]
            public static extern IntPtr DaliAccessibilityEmitScrollStartedEvent(HandleRef arg1_actor);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_EmitScrollFinishedEvent")]
            public static extern IntPtr DaliAccessibilityEmitScrollFinishedEvent(HandleRef arg1_actor);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_IsSuppressedEvent")]
            public static extern bool DaliAccessibilityIsSuppressedEvent(HandleRef arg1, int accessibilityEvent);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_SetSuppressedEvent")]
            public static extern void DaliAccessibilitySetSuppressedEvent(HandleRef arg1, int accessibilityEvent, bool isSuppressed);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_new_Range")]
            public static extern IntPtr DaliAccessibilityNewRange(int arg1_start, int arg2_end, string arg3_content);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_Bridge_RegisterDefaultLabel")]
            public static extern void DaliAccessibilityBridgeRegisterDefaultLabel(HandleRef arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_Bridge_UnregisterDefaultLabel")]
            public static extern void DaliAccessibilityBridgeUnregisterDefaultLabel(HandleRef arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_Accessible_GetCurrentlyHighlightedActor")]
            public static extern IntPtr DaliAccessibilityAccessibleGetCurrentlyHighlightedActor();

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_Accessible_GetHighlightActor")]
            public static extern IntPtr DaliAccessibilityAccessibleGetHighlightActor();

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_Accessible_SetHighlightActor")]
            public static extern void DaliAccessibilityAccessibleSetHighlightActor(HandleRef arg1);

#if false
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityActionSignal")]
            public static extern IntPtr DaliToolkitDevelControlAccessibilityActionSignal(BaseComponents.View.ControlHandle arg1);
#endif

            [EditorBrowsable(EditorBrowsableState.Never)]
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_SetCustomHighlightOverlay")]
            public static extern void SetCustomHighlightOverlay(global::System.Runtime.InteropServices.HandleRef control, global::System.Runtime.InteropServices.HandleRef position, global::System.Runtime.InteropServices.HandleRef size);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_ResetCustomHighlightOverlay")]
            public static extern void ResetCustomHighlightOverlay(global::System.Runtime.InteropServices.HandleRef control);
        }
    }
}
