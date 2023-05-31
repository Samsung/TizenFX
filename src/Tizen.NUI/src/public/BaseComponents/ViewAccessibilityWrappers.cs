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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Tizen.NUI.Accessibility;

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
            InitializeAccessibilityDelegateTableInterface();
            InitializeAccessibilityDelegateTableCellInterface();
            InitializeAccessibilityDelegateTextInterface();
            InitializeAccessibilityDelegateValueInterface();
            InitializeAccessibilityDelegateTizenExtensions();

            var ad   = Interop.ControlDevel.AccessibilityDelegate.Instance;
            var size = Marshal.SizeOf<Interop.ControlDevel.AccessibilityDelegate>();
            var ptr  = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(ad, ptr, false);
            Interop.ControlDevel.DaliAccessibilitySetAccessibilityDelegate(ptr, Convert.ToUInt32(size));
        }

        private static View GetViewFromRefObject(IntPtr refObjectPtr)
        {
            View view = Registry.GetManagedBaseHandleFromRefObject(refObjectPtr) as View;

            if (view is null)
            {
                NUILog.Error($"RefObject 0x{refObjectPtr:x} is not a View");
            }

            return view;
        }

        private static T GetInterfaceFromRefObject<T>(IntPtr refObjectPtr)
        {
            var view = GetViewFromRefObject(refObjectPtr);

            // NUIViewAccessible::CallMethod<T> checks whether a given interface is implemented
            // before jumping to managed code, so this condition should always be true.
            if (view is T atspiInterface)
            {
                return atspiInterface;
            }

            NUILog.Error($"RefObject 0x{refObjectPtr:x} is not a {typeof(T).FullName}");

            return default(T);
        }

        private static IntPtr DuplicateString(string value)
        {
            return Interop.ControlDevel.DaliAccessibilityDuplicateString(value ?? "");
        }

        private static IntPtr DuplicateAccessibilityRange(AccessibilityRange range)
        {
            return Interop.ControlDevel.DaliAccessibilityNewRange(range.StartOffset, range.EndOffset, range.Content);
        }

        private static IntPtr DuplicateAccessibilityRectangle(Rectangle rect)
        {
            return Interop.Rectangle.NewRectangle(rect.X, rect.Y, rect.Width, rect.Height);
        }

        private static IntPtr DuplicateIntPair(Tuple<int, int> pair)
        {
            return Interop.ControlDevel.DaliAccessibilityMakeIntPair(pair.Item1, pair.Item2);
        }

        //
        // Accessible interface
        //

        private static void InitializeAccessibilityDelegateAccessibleInterface()
        {
            var ad = Interop.ControlDevel.AccessibilityDelegate.Instance;

            ad.CalculateStates = AccessibilityCalculateStatesWrapper;
            ad.GetAttributes   = AccessibilityGetAttributes; // Not a wrapper, entirely private implementation
            ad.GetDescription  = AccessibilityGetDescriptionWrapper;
            ad.GetInterfaces   = AccessibilityGetInterfaces; // Not a wrapper, entirely private implementation
            ad.GetName         = AccessibilityGetNameWrapper;
        }

        private static ulong AccessibilityCalculateStatesWrapper(IntPtr self, ulong initialStates)
        {
            View view = GetViewFromRefObject(self);
            if (view == null)
                return 0UL;

            ulong bitMask = 0UL;

            lock (AccessibilityInitialStates)
            {
                AccessibilityInitialStates.BitMask = initialStates;
                bitMask = view.AccessibilityCalculateStates().BitMask;
                AccessibilityInitialStates.BitMask = 0UL;
            }

            return bitMask;
        }

        private static void AccessibilityGetAttributes(IntPtr self, Interop.ControlDevel.AccessibilityDelegate.AccessibilityGetAttributesCallback callback, IntPtr userData)
        {
            var view = GetViewFromRefObject(self);
            var attributes = view.AccessibilityAttributes;
            var classKey = "class";

            if (!attributes.ContainsKey(classKey))
            {
                attributes[classKey] = view.GetType().Name;
            }

            foreach (var attribute in attributes)
            {
                callback(attribute.Key, attribute.Value, userData);
            }

            foreach (var attribute in view.AccessibilityDynamicAttributes)
            {
                callback(attribute.Key, attribute.Value.Invoke(), userData);
            }
        }

        private static IntPtr AccessibilityGetDescriptionWrapper(IntPtr self)
        {
            string description = GetViewFromRefObject(self).AccessibilityGetDescription();

            return DuplicateString(description);
        }

        private static uint AccessibilityGetInterfaces(IntPtr self)
        {
            View view = GetViewFromRefObject(self);
            uint flags = 0U;

            if (view is IAtspiEditableText)
            {
                flags |= (1U << (int)AccessibilityInterface.EditableText);
            }

            if (view is IAtspiSelection)
            {
                flags |= (1U << (int)AccessibilityInterface.Selection);
            }

            if (view is IAtspiTable)
            {
                flags |= (1U << (int)AccessibilityInterface.Table);
            }

            if (view is IAtspiTableCell)
            {
                flags |= (1U << (int)AccessibilityInterface.TableCell);
            }

            if (view is IAtspiText)
            {
                flags |= (1U << (int)AccessibilityInterface.Text);
            }

            if (view is IAtspiValue)
            {
                flags |= (1U << (int)AccessibilityInterface.Value);
            }

            return flags;
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
            return GetInterfaceFromRefObject<IAtspiEditableText>(self).AccessibilityCopyText(startPosition, endPosition);
        }

        private static bool AccessibilityCutTextWrapper(IntPtr self, int startPosition, int endPosition)
        {
            return GetInterfaceFromRefObject<IAtspiEditableText>(self).AccessibilityCutText(startPosition, endPosition);
        }

        private static bool AccessibilityDeleteTextWrapper(IntPtr self, int startPosition, int endPosition)
        {
            return GetInterfaceFromRefObject<IAtspiEditableText>(self).AccessibilityDeleteText(startPosition, endPosition);
        }

        private static bool AccessibilityInsertTextWrapper(IntPtr self, int startPosition, IntPtr text)
        {
            return GetInterfaceFromRefObject<IAtspiEditableText>(self).AccessibilityInsertText(startPosition, Marshal.PtrToStringAnsi(text));
        }

        private static bool AccessibilitySetTextContentsWrapper(IntPtr self, IntPtr newContents)
        {
            return GetInterfaceFromRefObject<IAtspiEditableText>(self).AccessibilitySetTextContents(Marshal.PtrToStringAnsi(newContents));
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
            return GetInterfaceFromRefObject<IAtspiSelection>(self).AccessibilityClearSelection();
        }

        private static bool AccessibilityDeselectChildWrapper(IntPtr self, int childIndex)
        {
            return GetInterfaceFromRefObject<IAtspiSelection>(self).AccessibilityDeselectChild(childIndex);
        }

        private static bool AccessibilityDeselectSelectedChildWrapper(IntPtr self, int selectedChildIndex)
        {
            return GetInterfaceFromRefObject<IAtspiSelection>(self).AccessibilityDeselectSelectedChild(selectedChildIndex);
        }

        private static IntPtr AccessibilityGetSelectedChildWrapper(IntPtr self, int selectedChildIndex)
        {
            View child = GetInterfaceFromRefObject<IAtspiSelection>(self).AccessibilityGetSelectedChild(selectedChildIndex);

            return View.getCPtr(child).Handle;
        }

        private static int AccessibilityGetSelectedChildrenCountWrapper(IntPtr self)
        {
            return GetInterfaceFromRefObject<IAtspiSelection>(self).AccessibilityGetSelectedChildrenCount();
        }

        private static bool AccessibilityIsChildSelectedWrapper(IntPtr self, int childIndex)
        {
            return GetInterfaceFromRefObject<IAtspiSelection>(self).AccessibilityIsChildSelected(childIndex);
        }

        private static bool AccessibilitySelectAllWrapper(IntPtr self)
        {
            return GetInterfaceFromRefObject<IAtspiSelection>(self).AccessibilitySelectAll();
        }

        private static bool AccessibilitySelectChildWrapper(IntPtr self, int childIndex)
        {
            return GetInterfaceFromRefObject<IAtspiSelection>(self).AccessibilitySelectChild(childIndex);
        }

        //
        // Table interface
        //

        private static void InitializeAccessibilityDelegateTableInterface()
        {
            var ad = Interop.ControlDevel.AccessibilityDelegate.Instance;

            ad.AddColumnSelection      = AccessibilityAddColumnSelectionWrapper;
            ad.AddRowSelection         = AccessibilityAddRowSelectionWrapper;
            ad.GetCaption              = AccessibilityGetCaptionWrapper;
            ad.GetCell                 = AccessibilityGetCellWrapper;
            ad.GetChildIndex           = AccessibilityGetChildIndexWrapper;
            ad.GetColumnCount          = AccessibilityGetColumnCountWrapper;
            ad.GetColumnDescription    = AccessibilityGetColumnDescriptionWrapper;
            ad.GetColumnHeader         = AccessibilityGetColumnHeaderWrapper;
            ad.GetPositionByChildIndex = AccessibilityGetPositionByChildIndexWrapper;
            ad.GetRowCount             = AccessibilityGetRowCountWrapper;
            ad.GetRowDescription       = AccessibilityGetRowDescriptionWrapper;
            ad.GetRowHeader            = AccessibilityGetRowHeaderWrapper;
            ad.GetSelectedColumnCount  = AccessibilityGetSelectedColumnCountWrapper;
            ad.GetSelectedColumns      = AccessibilityGetSelectedColumnsWrapper;
            ad.GetSelectedRowCount     = AccessibilityGetSelectedRowCountWrapper;
            ad.GetSelectedRows         = AccessibilityGetSelectedRowsWrapper;
            ad.GetSummary              = AccessibilityGetSummaryWrapper;
            ad.IsCellSelected          = AccessibilityIsCellSelectedWrapper;
            ad.IsColumnSelected        = AccessibilityIsColumnSelectedWrapper;
            ad.IsRowSelected           = AccessibilityIsRowSelectedWrapper;
            ad.RemoveColumnSelection   = AccessibilityRemoveColumnSelectionWrapper;
            ad.RemoveRowSelection      = AccessibilityRemoveRowSelectionWrapper;
        }

        private static bool AccessibilityAddColumnSelectionWrapper(IntPtr self, int column)
        {
            return GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityAddColumnSelection(column);
        }

        private static bool AccessibilityAddRowSelectionWrapper(IntPtr self, int row)
        {
            return GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityAddRowSelection(row);
        }

        private static IntPtr AccessibilityGetCaptionWrapper(IntPtr self)
        {
            View caption = GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityGetCaption();

            return View.getCPtr(caption).Handle;
        }

        private static IntPtr AccessibilityGetCellWrapper(IntPtr self, int row, int column)
        {
            IAtspiTableCell cell = GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityGetCell(row, column);

            if (cell is View view)
            {
                return View.getCPtr(view).Handle;
            }

            NUILog.Error("Cannot get Actor handle from IAtspiTableCell");

            return IntPtr.Zero;
        }

        private static ulong AccessibilityGetChildIndexWrapper(IntPtr self, int row, int column)
        {
            return (ulong)GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityGetChildIndex(row, column);
        }

        private static int AccessibilityGetColumnCountWrapper(IntPtr self)
        {
            return GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityGetColumnCount();
        }

        private static IntPtr AccessibilityGetColumnDescriptionWrapper(IntPtr self, int column)
        {
            string description = GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityGetColumnDescription(column);

            return DuplicateString(description);
        }

        private static IntPtr AccessibilityGetColumnHeaderWrapper(IntPtr self, int column)
        {
            View header = GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityGetColumnHeader(column);

            return View.getCPtr(header).Handle;
        }

        private static IntPtr AccessibilityGetPositionByChildIndexWrapper(IntPtr self, ulong childIndex)
        {
            Tuple<int, int> position = GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityGetPositionByChildIndex((int)childIndex);

            return DuplicateIntPair(position);
        }

        private static int AccessibilityGetRowCountWrapper(IntPtr self)
        {
            return GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityGetRowCount();
        }

        private static IntPtr AccessibilityGetRowDescriptionWrapper(IntPtr self, int row)
        {
            string description = GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityGetRowDescription(row);

            return DuplicateString(description);
        }

        private static IntPtr AccessibilityGetRowHeaderWrapper(IntPtr self, int row)
        {
            View header = GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityGetRowHeader(row);

            return View.getCPtr(header).Handle;
        }

        private static int AccessibilityGetSelectedColumnCountWrapper(IntPtr self)
        {
            return GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityGetSelectedColumnCount();
        }

        private static void AccessibilityGetSelectedColumnsWrapper(IntPtr self, Interop.ControlDevel.AccessibilityDelegate.AccessibilityGetSelectedRowsColumnsCallback callback, IntPtr userData)
        {
            IEnumerable<int> columns = GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityGetSelectedColumns();

            foreach (int column in columns)
            {
                callback(column, userData);
            }
        }

        private static int AccessibilityGetSelectedRowCountWrapper(IntPtr self)
        {
            return GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityGetSelectedRowCount();
        }

        private static void AccessibilityGetSelectedRowsWrapper(IntPtr self, Interop.ControlDevel.AccessibilityDelegate.AccessibilityGetSelectedRowsColumnsCallback callback, IntPtr userData)
        {
            IEnumerable<int> rows = GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityGetSelectedRows();

            foreach (int row in rows)
            {
                callback(row, userData);
            }
        }

        private static IntPtr AccessibilityGetSummaryWrapper(IntPtr self)
        {
            View summary = GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityGetSummary();

            return View.getCPtr(summary).Handle;
        }

        private static bool AccessibilityIsCellSelectedWrapper(IntPtr self, int row, int column)
        {
            return GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityIsCellSelected(row, column);
        }

        private static bool AccessibilityIsColumnSelectedWrapper(IntPtr self, int column)
        {
            return GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityIsColumnSelected(column);
        }

        private static bool AccessibilityIsRowSelectedWrapper(IntPtr self, int row)
        {
            return GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityIsRowSelected(row);
        }

        private static bool AccessibilityRemoveColumnSelectionWrapper(IntPtr self, int column)
        {
            return GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityRemoveColumnSelection(column);
        }

        private static bool AccessibilityRemoveRowSelectionWrapper(IntPtr self, int row)
        {
            return GetInterfaceFromRefObject<IAtspiTable>(self).AccessibilityRemoveRowSelection(row);
        }

        //
        // TableCell interface
        //

        private static void InitializeAccessibilityDelegateTableCellInterface()
        {
            var ad = Interop.ControlDevel.AccessibilityDelegate.Instance;

            ad.GetCellColumnSpan = AccessibilityGetCellColumnSpanWrapper;
            ad.GetCellPosition   = AccessibilityGetCellPositionWrapper;
            ad.GetCellRowSpan    = AccessibilityGetCellRowSpanWrapper;
            ad.GetTable          = AccessibilityGetTableWrapper;
        }

        private static int AccessibilityGetCellColumnSpanWrapper(IntPtr self)
        {
            return GetInterfaceFromRefObject<IAtspiTableCell>(self).AccessibilityGetCellColumnSpan();
        }

        private static IntPtr AccessibilityGetCellPositionWrapper(IntPtr self)
        {
            Tuple<int, int> position = GetInterfaceFromRefObject<IAtspiTableCell>(self).AccessibilityGetCellPosition();

            return DuplicateIntPair(position);
        }

        private static int AccessibilityGetCellRowSpanWrapper(IntPtr self)
        {
            return GetInterfaceFromRefObject<IAtspiTableCell>(self).AccessibilityGetCellRowSpan();
        }

        private static IntPtr AccessibilityGetTableWrapper(IntPtr self)
        {
            IAtspiTable table = GetInterfaceFromRefObject<IAtspiTableCell>(self).AccessibilityGetTable();

            if (table is View view)
            {
                return View.getCPtr(view).Handle;
            }

            NUILog.Error("Cannot get Actor handle from IAtspiTable");

            return IntPtr.Zero;
        }

        //
        // Text interface
        //

        private static void InitializeAccessibilityDelegateTextInterface()
        {
            var ad = Interop.ControlDevel.AccessibilityDelegate.Instance;

            ad.GetCharacterCount = AccessibilityGetCharacterCountWrapper;
            ad.GetCursorOffset   = AccessibilityGetCursorOffsetWrapper;
            ad.GetRangeExtents   = AccessibilityGetRangeExtentsWrapper;
            ad.GetSelection      = AccessibilityGetSelectionWrapper;
            ad.GetText           = AccessibilityGetTextWrapper;
            ad.GetTextAtOffset   = AccessibilityGetTextAtOffsetWrapper;
            ad.RemoveSelection   = AccessibilityRemoveSelectionWrapper;
            ad.SetCursorOffset   = AccessibilitySetCursorOffsetWrapper;
            ad.SetSelection      = AccessibilitySetSelectionWrapper;
        }

        private static int AccessibilityGetCharacterCountWrapper(IntPtr self)
        {
            return GetInterfaceFromRefObject<IAtspiText>(self).AccessibilityGetCharacterCount();
        }

        private static int AccessibilityGetCursorOffsetWrapper(IntPtr self)
        {
            return GetInterfaceFromRefObject<IAtspiText>(self).AccessibilityGetCursorOffset();
        }

        private static IntPtr AccessibilityGetRangeExtentsWrapper(IntPtr self, int startOffset, int endOffset, int coordType)
        {
            using Rectangle rect = GetInterfaceFromRefObject<IAtspiText>(self).AccessibilityGetRangeExtents(startOffset, endOffset, (AccessibilityCoordinateType)coordType);

            return DuplicateAccessibilityRectangle(rect);
        }

        private static IntPtr AccessibilityGetSelectionWrapper(IntPtr self, int selectionNumber)
        {
            AccessibilityRange range = GetInterfaceFromRefObject<IAtspiText>(self).AccessibilityGetSelection(selectionNumber);

            return DuplicateAccessibilityRange(range);
        }

        private static IntPtr AccessibilityGetTextWrapper(IntPtr self, int startOffset, int endOffset)
        {
            string text = GetInterfaceFromRefObject<IAtspiText>(self).AccessibilityGetText(startOffset, endOffset);

            return DuplicateString(text);
        }

        private static IntPtr AccessibilityGetTextAtOffsetWrapper(IntPtr self, int offset, int boundary)
        {
            AccessibilityRange range = GetInterfaceFromRefObject<IAtspiText>(self).AccessibilityGetTextAtOffset(offset, (AccessibilityTextBoundary)boundary);

            return DuplicateAccessibilityRange(range);
        }

        private static bool AccessibilityRemoveSelectionWrapper(IntPtr self, int selectionNumber)
        {
            return GetInterfaceFromRefObject<IAtspiText>(self).AccessibilityRemoveSelection(selectionNumber);
        }

        private static bool AccessibilitySetCursorOffsetWrapper(IntPtr self, int offset)
        {
            return GetInterfaceFromRefObject<IAtspiText>(self).AccessibilitySetCursorOffset(offset);
        }

        private static bool AccessibilitySetSelectionWrapper(IntPtr self, int selectionNumber, int startOffset, int endOffset)
        {
            return GetInterfaceFromRefObject<IAtspiText>(self).AccessibilitySetSelection(selectionNumber, startOffset, endOffset);
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
            ad.GetValueText        = AccessibilityGetValueTextWrapper;
            ad.SetCurrent          = AccessibilitySetCurrentWrapper;
        }

        private static double AccessibilityGetCurrentWrapper(IntPtr self)
        {
            return GetInterfaceFromRefObject<IAtspiValue>(self).AccessibilityGetCurrent();
        }

        private static double AccessibilityGetMaximumWrapper(IntPtr self)
        {
            return GetInterfaceFromRefObject<IAtspiValue>(self).AccessibilityGetMaximum();
        }

        private static double AccessibilityGetMinimumWrapper(IntPtr self)
        {
            return GetInterfaceFromRefObject<IAtspiValue>(self).AccessibilityGetMinimum();
        }

        private static double AccessibilityGetMinimumIncrementWrapper(IntPtr self)
        {
            return GetInterfaceFromRefObject<IAtspiValue>(self).AccessibilityGetMinimumIncrement();
        }

        private static IntPtr AccessibilityGetValueTextWrapper(IntPtr self)
        {
            var view = GetViewFromRefObject(self);
            var value = GetInterfaceFromRefObject<IAtspiValue>(self);
            string text;

            // Mimic the behaviour of the pairs AccessibilityNameRequested & AccessibilityGetName(),
            // and AccessibilityDescriptionRequested & AccessibilityGetDescription(),
            // i.e. a higher-priority Accessibility[…]Requested event for application developers,
            // and a lower-priority AccessibilityGet[…]() virtual method for component developers.
            // The difference is that event-or-virtual-method dispatching is done in C++ for
            // Name and Description, and here in this wrapper method for ValueText (because there
            // is no signal for ValueText in DALi.)
            if (view.AccessibilityValueTextRequested?.GetInvocationList().Length > 0)
            {
                var args = new AccessibilityValueTextRequestedEventArgs();
                view.AccessibilityValueTextRequested.Invoke(view, args);
                text = args.Text;
            }
            else
            {
                text = value.AccessibilityGetValueText();
            }

            return DuplicateString(text);
        }

        private static bool AccessibilitySetCurrentWrapper(IntPtr self, double value)
        {
            return GetInterfaceFromRefObject<IAtspiValue>(self).AccessibilitySetCurrent(value);
        }

        //
        // Tizen extensions
        //

        private static void InitializeAccessibilityDelegateTizenExtensions()
        {
            var ad = Interop.ControlDevel.AccessibilityDelegate.Instance;

            ad.ScrollToChild            = AccessibilityScrollToChildWrapper;
        }

        private static bool AccessibilityScrollToChildWrapper(IntPtr self, IntPtr child)
        {
            View view = GetViewFromRefObject(self);

            return view.AccessibilityScrollToChild(view.GetInstanceSafely<View>(child));
        }
    }
}
