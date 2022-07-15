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
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityActivateSignal")]
            public static extern IntPtr DaliToolkitDevelControlAccessibilityActivateSignal(BaseComponents.View.ControlHandle arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingSkippedSignal")]
            public static extern IntPtr DaliToolkitDevelControlAccessibilityReadingSkippedSignal(BaseComponents.View.ControlHandle arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingPausedSignal")]
            public static extern IntPtr DaliToolkitDevelControlAccessibilityReadingPausedSignal(BaseComponents.View.ControlHandle arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingResumedSignal")]
            public static extern IntPtr DaliToolkitDevelControlAccessibilityReadingResumedSignal(BaseComponents.View.ControlHandle arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingCancelledSignal")]
            public static extern IntPtr DaliToolkitDevelControlAccessibilityReadingCancelledSignal(BaseComponents.View.ControlHandle arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingStoppedSignal")]
            public static extern IntPtr DaliToolkitDevelControlAccessibilityReadingStoppedSignal(BaseComponents.View.ControlHandle arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityGetNameSignal")]
            public static extern IntPtr DaliToolkitDevelControlAccessibilityGetNameSignal(BaseComponents.View.ControlHandle arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityGetDescriptionSignal")]
            public static extern IntPtr DaliToolkitDevelControlAccessibilityGetDescriptionSignal(BaseComponents.View.ControlHandle arg1);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityDoGestureSignal")]
            public static extern IntPtr DaliToolkitDevelControlAccessibilityDoGestureSignal(BaseComponents.View.ControlHandle arg1);

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
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_IsSuppressedEvent")]
            public static extern bool DaliAccessibilityIsSuppressedEvent(HandleRef arg1, int accessibilityEvent);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_SetSuppressedEvent")]
            public static extern void DaliAccessibilitySetSuppressedEvent(HandleRef arg1, int accessibilityEvent, bool isSuppressed);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_new_Range")]
            public static extern IntPtr DaliAccessibilityNewRange(int arg1_start, int arg2_end, string arg3_content);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_delete_Range")]
            public static extern void DaliAccessibilityDeleteRange(IntPtr arg1);

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

            // Keep this structure layout binary compatible with the respective C++ structure!
            [EditorBrowsable(EditorBrowsableState.Never)]
            [StructLayout(LayoutKind.Sequential)]
            public class AccessibilityDelegate
            {
                private AccessibilityDelegate()
                {
                }

                [EditorBrowsable(EditorBrowsableState.Never)]
                public static AccessibilityDelegate Instance { get; } = new AccessibilityDelegate();

                // TODO (C# 9.0):
                // Replace the following syntax (3 lines of code per field):
                //
                //     [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                //     public delegate ReturnType AccessibilityMethodName(IntPtr self, ArgumentTypes...)
                //     public AccessibilityMethodName MethodName;
                //
                // with the function pointer syntax (1 line of code per field):
                //
                //     public delegate* unmanaged[Cdecl]<ReturnType, ArgumentTypes...> MethodName;
                //
                // This will make it easier to verify that the structures are compatible between C# and C++
                // when adding new fields (preferably at the end), because the C# syntax will look very similar
                // to the C++ syntax.

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate IntPtr AccessibilityGetName(IntPtr self);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetName GetName; // 1

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate IntPtr AccessibilityGetDescription(IntPtr self);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetDescription GetDescription; // 2

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate bool AccessibilityDoAction(IntPtr self, IntPtr name);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityDoAction DoAction; // 3

                // Note: this method departs from the usual idiom of having the same
                // parameter types as the Accessible method in DALi, because states
                // calculated by ControlAccessible::CalculateStates are passed here
                // as a parameter.
                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate ulong AccessibilityCalculateStates(IntPtr self, ulong states);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityCalculateStates CalculateStates; // 4

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate int AccessibilityGetActionCount(IntPtr self);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetActionCount GetActionCount; // 5

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate IntPtr AccessibilityGetActionName(IntPtr self, int index);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetActionName GetActionName; // 6

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate uint AccessibilityGetInterfaces(IntPtr self);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetInterfaces GetInterfaces; // 7

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate double AccessibilityGetMinimum(IntPtr self);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetMinimum GetMinimum; // 8

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate double AccessibilityGetCurrent(IntPtr self);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetCurrent GetCurrent; // 9

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate double AccessibilityGetMaximum(IntPtr self);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetMaximum GetMaximum; // 10

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate bool AccessibilitySetCurrent(IntPtr self, double value);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilitySetCurrent SetCurrent; // 11

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate double AccessibilityGetMinimumIncrement(IntPtr self);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetMinimumIncrement GetMinimumIncrement; // 12

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate bool AccessibilityIsScrollable(IntPtr self);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityIsScrollable IsScrollable; // 13

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate IntPtr AccessibilityGetText(IntPtr self, int startOffset, int endOffset);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetText GetText; // 14

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate int AccessibilityGetCharacterCount(IntPtr self);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetCharacterCount GetCharacterCount; // 15

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate int AccessibilityGetCursorOffset(IntPtr self);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetCursorOffset GetCursorOffset; // 16

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate bool AccessibilitySetCursorOffset(IntPtr self, int offset);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilitySetCursorOffset SetCursorOffset; // 17

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate IntPtr AccessibilityGetTextAtOffset(IntPtr self, int offset, int boundary);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetTextAtOffset GetTextAtOffset; // 18

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate IntPtr AccessibilityGetSelection(IntPtr self, int selectionNum);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetSelection GetSelection; // 19

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate bool AccessibilityRemoveSelection(IntPtr self, int selectionNum);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityRemoveSelection RemoveSelection; // 20

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate bool AccessibilitySetSelection(IntPtr self, int selectionNum, int startOffset, int endOffset);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilitySetSelection SetSelection; // 21

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate bool AccessibilityCopyText(IntPtr self, int startPosition, int endPosition);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityCopyText CopyText; // 22

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate bool AccessibilityCutText(IntPtr self, int startPosition, int endPosition);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityCutText CutText; // 23

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate bool AccessibilityInsertText(IntPtr self, int startPosition, IntPtr text);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityInsertText InsertText; // 24

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate bool AccessibilitySetTextContents(IntPtr self, IntPtr newContents);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilitySetTextContents SetTextContents; // 25

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate bool AccessibilityDeleteText(IntPtr self, int startPosition, int endPosition);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityDeleteText DeleteText; // 26

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate bool AccessibilityScrollToChild(IntPtr self, IntPtr child);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityScrollToChild ScrollToChild; // 27

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate int AccessibilityGetSelectedChildrenCount(IntPtr self);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetSelectedChildrenCount GetSelectedChildrenCount; // 28

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate IntPtr AccessibilityGetSelectedChild(IntPtr self, int selectedChildIndex);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetSelectedChild GetSelectedChild; // 29

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate bool AccessibilitySelectChild(IntPtr self, int childIndex);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilitySelectChild SelectChild; // 30

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate bool AccessibilityDeselectSelectedChild(IntPtr self, int selectedChildIndex);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityDeselectSelectedChild DeselectSelectedChild; // 31

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate bool AccessibilityIsChildSelected(IntPtr self, int childIndex);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityIsChildSelected IsChildSelected; // 32

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate bool AccessibilitySelectAll(IntPtr self);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilitySelectAll SelectAll; // 33

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate bool AccessibilityClearSelection(IntPtr self);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityClearSelection ClearSelection; // 34

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate bool AccessibilityDeselectChild(IntPtr self, int childIndex);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityDeselectChild DeselectChild; // 35

                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate IntPtr AccessibilityGetRangeExtents(IntPtr self, int startOffset, int endOffset, int coordType);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetRangeExtents GetRangeExtents; // 36

                [EditorBrowsable(EditorBrowsableState.Never)]
                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate void AccessibilityGetAttributesCallback(string key, string value, IntPtr userData);
                [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
                public delegate void AccessibilityGetAttributes(IntPtr self, AccessibilityGetAttributesCallback callback, IntPtr userData);
                [EditorBrowsable(EditorBrowsableState.Never)]
                public AccessibilityGetAttributes GetAttributes; // 37
            }

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_DuplicateString")]
            public static extern IntPtr DaliAccessibilityDuplicateString(string arg);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_SetAccessibilityDelegate")]
            public static extern IntPtr DaliAccessibilitySetAccessibilityDelegate(IntPtr arg1_accessibilityDelegate, int arg2_accessibilityDelegateSize);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Accessibility_SetAccessibilityAttribute")]
            public static extern void DaliAccessibilitySetAccessibilityAttribute(HandleRef arg1_control, string arg2_key, string arg3_value);
        }
    }
}
