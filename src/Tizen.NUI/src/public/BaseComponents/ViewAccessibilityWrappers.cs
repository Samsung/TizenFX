/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;

namespace Tizen.NUI.BaseComponents
{
    public partial class View
    {
        private static AccessibilityStates AccessibilityInitialStates = new AccessibilityStates();

        private static void RegisterAccessibilityDelegate()
        {
            InitializeAccessibilityDelegateAccessibleInterface();
            InitializeAccessibilityDelegateActionInterface();
            InitializeAccessibilityDelegateComponentInterface();
            InitializeAccessibilityDelegateEditableTextInterface();
            InitializeAccessibilityDelegateSelectionInterface();
            InitializeAccessibilityDelegateTextInterface();
            InitializeAccessibilityDelegateValueInterface();
            InitializeAccessibilityDelegateTizenExtensions();

            var ad   = Interop.ControlDevel.AccessibilityDelegate.Instance;
            var size = Marshal.SizeOf<Interop.ControlDevel.AccessibilityDelegate>();
            var ptr  = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(ad, ptr, false);
            Interop.ControlDevel.DaliAccessibilitySetAccessibilityDelegate(ptr, size);
        }

        private static View GetViewFromRefObject(IntPtr refObjectPtr)
        {
            return Registry.GetManagedBaseHandleFromRefObject(refObjectPtr) as View;
        }

        private static IntPtr DuplicateString(string value)
        {
            return Interop.ControlDevel.DaliAccessibilityDuplicateString(value ?? "");
        }

        private static IntPtr DuplicateAccessibilityRange(AccessibilityRange range)
        {
            return Interop.ControlDevel.DaliAccessibilityNewRange(range.StartOffset, range.EndOffset, range.Content);
        }

        //
        // Accessible interface
        //

        private static void InitializeAccessibilityDelegateAccessibleInterface()
        {
            var ad = Interop.ControlDevel.AccessibilityDelegate.Instance;

            ad.CalculateStates = AccessibilityCalculateStatesWrapper;
            ad.GetDescription  = AccessibilityGetDescriptionWrapper;
            ad.GetName         = AccessibilityGetNameWrapper;
        }

        private static ulong AccessibilityCalculateStatesWrapper(IntPtr self, ulong initialStates)
        {
            View view = GetViewFromRefObject(self);
            ulong bitMask = 0UL;

            lock (AccessibilityInitialStates)
            {
                AccessibilityInitialStates.BitMask = initialStates;
                bitMask = view.AccessibilityCalculateStates().BitMask;
                AccessibilityInitialStates.BitMask = 0UL;
            }

            return bitMask;
        }

        private static IntPtr AccessibilityGetDescriptionWrapper(IntPtr self)
        {
            string description = GetViewFromRefObject(self).AccessibilityGetDescription();

            return DuplicateString(description);
        }

        private static IntPtr AccessibilityGetNameWrapper(IntPtr self)
        {
            string name = GetViewFromRefObject(self).AccessibilityGetName();

            return DuplicateString(name);
        }

        //
        // Action interface
        //

        private static void InitializeAccessibilityDelegateActionInterface()
        {
            var ad = Interop.ControlDevel.AccessibilityDelegate.Instance;

            ad.DoAction       = AccessibilityDoActionWrapper;
            ad.GetActionCount = AccessibilityGetActionCountWrapper;
            ad.GetActionName  = AccessibilityGetActionNameWrapper;
        }

        private static bool AccessibilityDoActionWrapper(IntPtr self, IntPtr name)
        {
            return GetViewFromRefObject(self).AccessibilityDoAction(Marshal.PtrToStringAnsi(name));
        }

        private static int AccessibilityGetActionCountWrapper(IntPtr self)
        {
            return GetViewFromRefObject(self).AccessibilityGetActionCount();
        }

        private static IntPtr AccessibilityGetActionNameWrapper(IntPtr self, int index)
        {
            string name = GetViewFromRefObject(self).AccessibilityGetActionName(index);

            return DuplicateString(name);
        }

        //
        // Component interface
        //

        private static void InitializeAccessibilityDelegateComponentInterface()
        {
            var ad = Interop.ControlDevel.AccessibilityDelegate.Instance;

            ad.IsScrollable = AccessibilityIsScrollableWrapper;
        }

        private static bool AccessibilityIsScrollableWrapper(IntPtr self)
        {
            return GetViewFromRefObject(self).AccessibilityIsScrollable();
        }

        //
        // EditableText interface
        //

        private static void InitializeAccessibilityDelegateEditableTextInterface()
        {
            var ad = Interop.ControlDevel.AccessibilityDelegate.Instance;

            ad.CopyText        = AccessibilityCopyTextWrapper;
            ad.CutText         = AccessibilityCutTextWrapper;
            ad.DeleteText      = AccessibilityDeleteTextWrapper;
            ad.InsertText      = AccessibilityInsertTextWrapper;
            ad.SetTextContents = AccessibilitySetTextContentsWrapper;
        }

        private static bool AccessibilityCopyTextWrapper(IntPtr self, int startPosition, int endPosition)
        {
            return GetViewFromRefObject(self).AccessibilityCopyText(startPosition, endPosition);
        }

        private static bool AccessibilityCutTextWrapper(IntPtr self, int startPosition, int endPosition)
        {
            return GetViewFromRefObject(self).AccessibilityCutText(startPosition, endPosition);
        }

        private static bool AccessibilityDeleteTextWrapper(IntPtr self, int startPosition, int endPosition)
        {
            return GetViewFromRefObject(self).AccessibilityDeleteText(startPosition, endPosition);
        }

        private static bool AccessibilityInsertTextWrapper(IntPtr self, int startPosition, IntPtr text)
        {
            return GetViewFromRefObject(self).AccessibilityInsertText(startPosition, Marshal.PtrToStringAnsi(text));
        }

        private static bool AccessibilitySetTextContentsWrapper(IntPtr self, IntPtr newContents)
        {
            return GetViewFromRefObject(self).AccessibilitySetTextContents(Marshal.PtrToStringAnsi(newContents));
        }

        //
        // Selection interface
        //

        private static void InitializeAccessibilityDelegateSelectionInterface()
        {
            var ad = Interop.ControlDevel.AccessibilityDelegate.Instance;

            ad.ClearSelection           = AccessibilityClearSelectionWrapper;
            ad.DeselectChild            = AccessibilityDeselectChildWrapper;
            ad.DeselectSelectedChild    = AccessibilityDeselectSelectedChildWrapper;
            ad.GetSelectedChild         = AccessibilityGetSelectedChildWrapper;
            ad.GetSelectedChildrenCount = AccessibilityGetSelectedChildrenCountWrapper;
            ad.IsChildSelected          = AccessibilityIsChildSelectedWrapper;
            ad.SelectAll                = AccessibilitySelectAllWrapper;
            ad.SelectChild              = AccessibilitySelectChildWrapper;
        }

        private static bool AccessibilityClearSelectionWrapper(IntPtr self)
        {
            return GetViewFromRefObject(self).AccessibilityClearSelection();
        }

        private static bool AccessibilityDeselectChildWrapper(IntPtr self, int childIndex)
        {
            return GetViewFromRefObject(self).AccessibilityDeselectChild(childIndex);
        }

        private static bool AccessibilityDeselectSelectedChildWrapper(IntPtr self, int selectedChildIndex)
        {
            return GetViewFromRefObject(self).AccessibilityDeselectSelectedChild(selectedChildIndex);
        }

        private static IntPtr AccessibilityGetSelectedChildWrapper(IntPtr self, int selectedChildIndex)
        {
            View child = GetViewFromRefObject(self).AccessibilityGetSelectedChild(selectedChildIndex);

            return View.getCPtr(child).Handle;
        }

        private static int AccessibilityGetSelectedChildrenCountWrapper(IntPtr self)
        {
            return GetViewFromRefObject(self).AccessibilityGetSelectedChildrenCount();
        }

        private static bool AccessibilityIsChildSelectedWrapper(IntPtr self, int childIndex)
        {
            return GetViewFromRefObject(self).AccessibilityIsChildSelected(childIndex);
        }

        private static bool AccessibilitySelectAllWrapper(IntPtr self)
        {
            return GetViewFromRefObject(self).AccessibilitySelectAll();
        }

        private static bool AccessibilitySelectChildWrapper(IntPtr self, int childIndex)
        {
            return GetViewFromRefObject(self).AccessibilitySelectChild(childIndex);
        }

        //
        // Text interface
        //

        private static void InitializeAccessibilityDelegateTextInterface()
        {
            var ad = Interop.ControlDevel.AccessibilityDelegate.Instance;

            ad.GetCharacterCount = AccessibilityGetCharacterCountWrapper;
            ad.GetCursorOffset   = AccessibilityGetCursorOffsetWrapper;
            ad.GetSelection      = AccessibilityGetSelectionWrapper;
            ad.GetText           = AccessibilityGetTextWrapper;
            ad.GetTextAtOffset   = AccessibilityGetTextAtOffsetWrapper;
            ad.RemoveSelection   = AccessibilityRemoveSelectionWrapper;
            ad.SetCursorOffset   = AccessibilitySetCursorOffsetWrapper;
            ad.SetSelection      = AccessibilitySetSelectionWrapper;
        }

        private static int AccessibilityGetCharacterCountWrapper(IntPtr self)
        {
            return GetViewFromRefObject(self).AccessibilityGetCharacterCount();
        }

        private static int AccessibilityGetCursorOffsetWrapper(IntPtr self)
        {
            return GetViewFromRefObject(self).AccessibilityGetCursorOffset();
        }

        private static IntPtr AccessibilityGetSelectionWrapper(IntPtr self, int selectionNumber)
        {
            AccessibilityRange range = GetViewFromRefObject(self).AccessibilityGetSelection(selectionNumber);

            return DuplicateAccessibilityRange(range);
        }

        private static IntPtr AccessibilityGetTextWrapper(IntPtr self, int startOffset, int endOffset)
        {
            string text = GetViewFromRefObject(self).AccessibilityGetText(startOffset, endOffset);

            return DuplicateString(text);
        }

        private static IntPtr AccessibilityGetTextAtOffsetWrapper(IntPtr self, int offset, int boundary)
        {
            AccessibilityRange range = GetViewFromRefObject(self).AccessibilityGetTextAtOffset(offset, (AccessibilityTextBoundary)boundary);

            return DuplicateAccessibilityRange(range);
        }

        private static bool AccessibilityRemoveSelectionWrapper(IntPtr self, int selectionNumber)
        {
            return GetViewFromRefObject(self).AccessibilityRemoveSelection(selectionNumber);
        }

        private static bool AccessibilitySetCursorOffsetWrapper(IntPtr self, int offset)
        {
            return GetViewFromRefObject(self).AccessibilitySetCursorOffset(offset);
        }

        private static bool AccessibilitySetSelectionWrapper(IntPtr self, int selectionNumber, int startOffset, int endOffset)
        {
            return GetViewFromRefObject(self).AccessibilitySetSelection(selectionNumber, startOffset, endOffset);
        }

        //
        // Value interface
        //

        private static void InitializeAccessibilityDelegateValueInterface()
        {
            var ad = Interop.ControlDevel.AccessibilityDelegate.Instance;

            ad.GetCurrent          = AccessibilityGetCurrentWrapper;
            ad.GetMaximum          = AccessibilityGetMaximumWrapper;
            ad.GetMinimum          = AccessibilityGetMinimumWrapper;
            ad.GetMinimumIncrement = AccessibilityGetMinimumIncrementWrapper;
            ad.SetCurrent          = AccessibilitySetCurrentWrapper;
        }

        private static double AccessibilityGetCurrentWrapper(IntPtr self)
        {
            return GetViewFromRefObject(self).AccessibilityGetCurrent();
        }

        private static double AccessibilityGetMaximumWrapper(IntPtr self)
        {
            return GetViewFromRefObject(self).AccessibilityGetMaximum();
        }

        private static double AccessibilityGetMinimumWrapper(IntPtr self)
        {
            return GetViewFromRefObject(self).AccessibilityGetMinimum();
        }

        private static double AccessibilityGetMinimumIncrementWrapper(IntPtr self)
        {
            return GetViewFromRefObject(self).AccessibilityGetMinimumIncrement();
        }

        private static bool AccessibilitySetCurrentWrapper(IntPtr self, double value)
        {
            return GetViewFromRefObject(self).AccessibilitySetCurrent(value);
        }

        //
        // Tizen extensions
        //

        private static void InitializeAccessibilityDelegateTizenExtensions()
        {
            var ad = Interop.ControlDevel.AccessibilityDelegate.Instance;

            ad.ScrollToChild            = AccessibilityScrollToChildWrapper;
            ad.ShouldReportZeroChildren = AccessibilityShouldReportZeroChildrenWrapper;
        }

        private static bool AccessibilityScrollToChildWrapper(IntPtr self, IntPtr child)
        {
            View view = GetViewFromRefObject(self);

            return view.AccessibilityScrollToChild(view.GetInstanceSafely<View>(child));
        }

        private static bool AccessibilityShouldReportZeroChildrenWrapper(IntPtr self)
        {
            return GetViewFromRefObject(self).AccessibilityShouldReportZeroChildren();
        }
    }
}
