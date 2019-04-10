using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class TableView
        {
            static TableView()
            {
                Tizen.Log.Error("NUI", "TableView");
            }


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_Property_ROWS_get")]
            public static extern int TableView_Property_ROWS_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_Property_COLUMNS_get")]
            public static extern int TableView_Property_COLUMNS_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_Property_CELL_PADDING_get")]
            public static extern int TableView_Property_CELL_PADDING_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_Property_LAYOUT_ROWS_get")]
            public static extern int TableView_Property_LAYOUT_ROWS_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_Property_LAYOUT_COLUMNS_get")]
            public static extern int TableView_Property_LAYOUT_COLUMNS_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_TableView_Property")]
            public static extern global::System.IntPtr new_TableView_Property();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_TableView_Property")]
            public static extern void delete_TableView_Property(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_ChildProperty_CELL_INDEX_get")]
            public static extern int TableView_ChildProperty_CELL_INDEX_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_ChildProperty_ROW_SPAN_get")]
            public static extern int TableView_ChildProperty_ROW_SPAN_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_ChildProperty_COLUMN_SPAN_get")]
            public static extern int TableView_ChildProperty_COLUMN_SPAN_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_ChildProperty_CELL_HORIZONTAL_ALIGNMENT_get")]
            public static extern int TableView_ChildProperty_CELL_HORIZONTAL_ALIGNMENT_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_ChildProperty_CELL_VERTICAL_ALIGNMENT_get")]
            public static extern int TableView_ChildProperty_CELL_VERTICAL_ALIGNMENT_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_TableView_ChildProperty")]
            public static extern global::System.IntPtr new_TableView_ChildProperty();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_TableView_ChildProperty")]
            public static extern void delete_TableView_ChildProperty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_TableView_CellPosition__SWIG_0")]
            public static extern global::System.IntPtr new_TableView_CellPosition__SWIG_0(uint jarg1, uint jarg2, uint jarg3, uint jarg4);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_TableView_CellPosition__SWIG_1")]
            public static extern global::System.IntPtr new_TableView_CellPosition__SWIG_1(uint jarg1, uint jarg2, uint jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_TableView_CellPosition__SWIG_2")]
            public static extern global::System.IntPtr new_TableView_CellPosition__SWIG_2(uint jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_TableView_CellPosition__SWIG_3")]
            public static extern global::System.IntPtr new_TableView_CellPosition__SWIG_3(uint jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_TableView_CellPosition__SWIG_4")]
            public static extern global::System.IntPtr new_TableView_CellPosition__SWIG_4();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_CellPosition_rowIndex_set")]
            public static extern void TableView_CellPosition_rowIndex_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_CellPosition_rowIndex_get")]
            public static extern uint TableView_CellPosition_rowIndex_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_CellPosition_columnIndex_set")]
            public static extern void TableView_CellPosition_columnIndex_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_CellPosition_columnIndex_get")]
            public static extern uint TableView_CellPosition_columnIndex_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_CellPosition_rowSpan_set")]
            public static extern void TableView_CellPosition_rowSpan_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_CellPosition_rowSpan_get")]
            public static extern uint TableView_CellPosition_rowSpan_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_CellPosition_columnSpan_set")]
            public static extern void TableView_CellPosition_columnSpan_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_CellPosition_columnSpan_get")]
            public static extern uint TableView_CellPosition_columnSpan_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_TableView_CellPosition")]
            public static extern void delete_TableView_CellPosition(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_TableView__SWIG_0")]
            public static extern global::System.IntPtr new_TableView__SWIG_0();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_TableView__SWIG_1")]
            public static extern global::System.IntPtr new_TableView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_Assign")]
            public static extern global::System.IntPtr TableView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_TableView")]
            public static extern void delete_TableView(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_New")]
            public static extern global::System.IntPtr TableView_New(uint jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_DownCast")]
            public static extern global::System.IntPtr TableView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_AddChild")]
            public static extern bool TableView_AddChild(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_GetChildAt")]
            public static extern global::System.IntPtr TableView_GetChildAt(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_RemoveChildAt")]
            public static extern global::System.IntPtr TableView_RemoveChildAt(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_FindChildPosition")]
            public static extern bool TableView_FindChildPosition(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_InsertRow")]
            public static extern void TableView_InsertRow(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_DeleteRow__SWIG_0")]
            public static extern void TableView_DeleteRow__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_DeleteRow__SWIG_1")]
            public static extern void TableView_DeleteRow__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_InsertColumn")]
            public static extern void TableView_InsertColumn(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_DeleteColumn__SWIG_0")]
            public static extern void TableView_DeleteColumn__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_DeleteColumn__SWIG_1")]
            public static extern void TableView_DeleteColumn__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_Resize__SWIG_0")]
            public static extern void TableView_Resize__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_Resize__SWIG_1")]
            public static extern void TableView_Resize__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_SetCellPadding")]
            public static extern void TableView_SetCellPadding(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_GetCellPadding")]
            public static extern global::System.IntPtr TableView_GetCellPadding(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_SetFitHeight")]
            public static extern void TableView_SetFitHeight(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_IsFitHeight")]
            public static extern bool TableView_IsFitHeight(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_SetFitWidth")]
            public static extern void TableView_SetFitWidth(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_IsFitWidth")]
            public static extern bool TableView_IsFitWidth(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_SetFixedHeight")]
            public static extern void TableView_SetFixedHeight(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_GetFixedHeight")]
            public static extern float TableView_GetFixedHeight(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_SetRelativeHeight")]
            public static extern void TableView_SetRelativeHeight(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_GetRelativeHeight")]
            public static extern float TableView_GetRelativeHeight(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_SetFixedWidth")]
            public static extern void TableView_SetFixedWidth(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_GetFixedWidth")]
            public static extern float TableView_GetFixedWidth(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_SetRelativeWidth")]
            public static extern void TableView_SetRelativeWidth(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_GetRelativeWidth")]
            public static extern float TableView_GetRelativeWidth(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_GetRows")]
            public static extern uint TableView_GetRows(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_GetColumns")]
            public static extern uint TableView_GetColumns(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_SetCellAlignment")]
            public static extern void TableView_SetCellAlignment(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4);
            
            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TableView_SWIGUpcast")]
            public static extern global::System.IntPtr TableView_SWIGUpcast(global::System.IntPtr jarg1);
        }
    }
}
