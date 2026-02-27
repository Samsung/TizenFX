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
        internal static partial class TableView
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_Property_ROWS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RowsGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_Property_COLUMNS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ColumnsGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_Property_CELL_PADDING_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int CellPaddingGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_Property_LAYOUT_ROWS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LayoutRowsGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_Property_LAYOUT_COLUMNS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LayoutColumnsGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_ChildProperty_CELL_INDEX_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ChildPropertyCellIndexGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_ChildProperty_ROW_SPAN_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ChildPropertyRowSpanGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_ChildProperty_COLUMN_SPAN_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ChildPropertyColumnSpanGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_ChildProperty_CELL_HORIZONTAL_ALIGNMENT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ChildPropertyCellHorizontalAlignmentGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_ChildProperty_CELL_VERTICAL_ALIGNMENT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ChildPropertyCellVerticalAlignmentGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TableView_CellPosition__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewTableViewCellPosition(uint jarg1, uint jarg2, uint jarg3, uint jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TableView_CellPosition__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewTableViewCellPosition(uint jarg1, uint jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TableView_CellPosition__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewTableViewCellPosition(uint jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TableView_CellPosition__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewTableViewCellPosition(uint jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TableView_CellPosition__SWIG_4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewTableViewCellPosition();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_CellPosition_rowIndex_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void CellPositionRowIndexSet(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_CellPosition_rowIndex_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint CellPositionRowIndexGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_CellPosition_columnIndex_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void CellPositionColumnIndexSet(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_CellPosition_columnIndex_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint CellPositionColumnIndexGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_CellPosition_rowSpan_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void CellPositionRowSpanSet(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_CellPosition_rowSpan_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint CellPositionRowSpanGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_CellPosition_columnSpan_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void CellPositionColumnSpanSet(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_CellPosition_columnSpan_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint CellPositionColumnSpanGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TableView_CellPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteTableViewCellPosition(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TableView__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewTableView(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TableView", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteTableView(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(uint jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_AddChild", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AddChild(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_GetChildAt", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetChildAt(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_RemoveChildAt", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr RemoveChildAt(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_FindChildPosition", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FindChildPosition(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_InsertRow", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void InsertRow(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_DeleteRow__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteRow(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_InsertColumn", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void InsertColumn(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_DeleteColumn__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteColumn(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_Resize__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Resize(IntPtr jarg1, uint jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_SetCellPadding", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetCellPadding(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_GetCellPadding", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetCellPadding(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_SetFitHeight", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFitHeight(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_IsFitHeight", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsFitHeight(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_SetFitWidth", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFitWidth(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_IsFitWidth", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsFitWidth(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_SetFixedHeight", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFixedHeight(IntPtr jarg1, uint jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_GetFixedHeight", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetFixedHeight(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_SetRelativeHeight", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetRelativeHeight(IntPtr jarg1, uint jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_GetRelativeHeight", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetRelativeHeight(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_SetFixedWidth", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFixedWidth(IntPtr jarg1, uint jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_GetFixedWidth", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetFixedWidth(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_SetRelativeWidth", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetRelativeWidth(IntPtr jarg1, uint jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_GetRelativeWidth", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetRelativeWidth(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TableView_SetCellAlignment", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetCellAlignment(IntPtr jarg1, IntPtr jarg2, int jarg3, int jarg4);
        }
    }
}





