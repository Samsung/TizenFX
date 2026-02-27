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

using global::System;
using global::System.Collections.Generic;
using global::System.ComponentModel;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;
using global::System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ControlDevel
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AppendAccessibilityRelation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DaliToolkitDevelControlAppendAccessibilityRelation(IntPtr arg1, IntPtr arg2, int arg3);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_RemoveAccessibilityRelation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DaliToolkitDevelControlRemoveAccessibilityRelation(IntPtr arg1, IntPtr arg2, int arg3);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void GetAccessibilityRelationsCallback(int relationType, IntPtr relationTarget, IntPtr userData);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_GetAccessibilityRelations", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DaliToolkitDevelControlGetAccessibilityRelations(IntPtr arg1_control, GetAccessibilityRelationsCallback arg2_callback, IntPtr arg3_userData);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_ClearAccessibilityRelations", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DaliToolkitDevelControlClearAccessibilityRelations(IntPtr arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AppendAccessibilityAttribute", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DaliToolkitDevelControlAppendAccessibilityAttribute(IntPtr arg1, string arg2_key, string arg3_value);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_RemoveAccessibilityAttribute", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DaliToolkitDevelControlRemoveAccessibilityAttribute(IntPtr arg1, string arg2_key);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_SetAccessibilityReadingInfoType2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DaliToolkitDevelControlSetAccessibilityReadingInfoTypes(IntPtr arg1, int arg2);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_GetAccessibilityReadingInfoType2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int DaliToolkitDevelControlGetAccessibilityReadingInfoTypes(IntPtr arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_ClearAccessibilityHighlight", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool DaliToolkitDevelControlClearAccessibilityHighlight(IntPtr arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_GrabAccessibilityHighlight", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool DaliToolkitDevelControlGrabAccessibilityHighlight(IntPtr arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_GetAccessibilityStates", StringMarshalling = StringMarshalling.Utf8)]
            public static partial ulong DaliToolkitDevelControlGetAccessibilityStates(IntPtr arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_NotifyAccessibilityStateChange", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr DaliToolkitDevelControlNotifyAccessibilityStateChange(IntPtr arg1, ulong arg2, int arg3);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_EmitAccessibilityEvent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr DaliAccessibilityEmitAccessibilityEvent(IntPtr arg1, int arg2_event);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_EmitAccessibilityStateChangedEvent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr DaliAccessibilityEmitAccessibilityStateChangedEvent(IntPtr arg1, int arg2_state, int arg3);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_EmitTextInsertedEvent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr DaliAccessibilityEmitTextInsertedEvent(IntPtr arg1, int arg2_pos, int arg3_len, string arg3_content);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_EmitTextDeletedEvent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr DaliAccessibilityEmitTextDeletedEvent(IntPtr arg1, int arg2_pos, int arg3_len, string arg3_content);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_EmitTextCursorMovedEvent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr DaliAccessibilityEmitTextCursorMovedEvent(IntPtr arg1, int arg2_pos);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_EmitScrollStartedEvent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr DaliAccessibilityEmitScrollStartedEvent(IntPtr arg1_actor);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_EmitScrollFinishedEvent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr DaliAccessibilityEmitScrollFinishedEvent(IntPtr arg1_actor);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_IsSuppressedEvent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial bool DaliAccessibilityIsSuppressedEvent(IntPtr arg1, int accessibilityEvent);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_SetSuppressedEvent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DaliAccessibilitySetSuppressedEvent(IntPtr arg1, int accessibilityEvent, [MarshalAs(UnmanagedType.U1)] bool isSuppressed);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_new_Range", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr DaliAccessibilityNewRange(int arg1_start, int arg2_end, string arg3_content);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_Bridge_RegisterDefaultLabel", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DaliAccessibilityBridgeRegisterDefaultLabel(IntPtr arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_Bridge_UnregisterDefaultLabel", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DaliAccessibilityBridgeUnregisterDefaultLabel(IntPtr arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_Accessible_GetCurrentlyHighlightedActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr DaliAccessibilityAccessibleGetCurrentlyHighlightedActor();

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_Accessible_GetHighlightActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr DaliAccessibilityAccessibleGetHighlightActor();

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_Accessible_SetHighlightActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DaliAccessibilityAccessibleSetHighlightActor(IntPtr arg1);

#if false
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityActionSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr DaliToolkitDevelControlAccessibilityActionSignal(BaseComponents.View.ControlHandle arg1);
#endif

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_SetCustomHighlightOverlay", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetCustomHighlightOverlay(IntPtr control, IntPtr position, IntPtr size);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_ResetCustomHighlightOverlay", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ResetCustomHighlightOverlay(IntPtr control);
        }
    }
}





