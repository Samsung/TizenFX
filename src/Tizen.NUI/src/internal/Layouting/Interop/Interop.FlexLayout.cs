using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class FlexLayout
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_New")]
            public static extern global::System.IntPtr FlexLayout_New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_SetContext")]
            public static extern global::System.IntPtr FlexLayout_SetContext( global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_SetMeasureFunction")]
            public static extern global::System.IntPtr FlexLayout_SetMeasureFunction( global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_AddChildWithMargin")]
            public static extern void FlexLayout_AddChildWithMargin( global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, Tizen.NUI.FlexLayout.ChildMeasureCallback jarg4, int jarg5);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_RemoveChild")]
            public static extern global::System.IntPtr FlexLayout_RemoveChild( global::System.Runtime.InteropServices.HandleRef jarg1, LayoutItem jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_CalculateLayout")]
            public static extern global::System.IntPtr FlexLayout_CalculateLayout( global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, bool jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_GetWidth")]
            public static extern float FlexLayout_GetWidth(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_GetHeight")]
            public static extern float FlexLayout_GetHeight(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_GetNodeFrame")]
            public static extern global::System.IntPtr FlexLayout_GetNodeFrame(global::System.Runtime.InteropServices.HandleRef jarg1, int index);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_MarkDirty")]
            public static extern global::System.IntPtr FlexLayout_MarkDirty (global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_SetMargin")]
            public static extern global::System.IntPtr FlexLayout_SetMargin( global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_SetPadding")]
            public static extern global::System.IntPtr FlexLayout_SetPadding( global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_DownCast")]
            public static extern global::System.IntPtr FlexLayout_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_FlexLayout__SWIG_1")]
            public static extern global::System.IntPtr new_FlexLayout__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_Assign")]
            public static extern global::System.IntPtr FlexLayout_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_FlexLayout")]
            public static extern void delete_FlexLayout(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_SetFlexDirection")]
            public static extern void FlexLayout_SetFlexDirection(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_GetFlexDirection")]
            public static extern int FlexLayout_GetFlexDirection(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_SetFlexJustification")]
            public static extern void FlexLayout_SetFlexJustification(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_GetFlexJustification")]
            public static extern int FlexLayout_GetFlexJustification(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_SetFlexWrap")]
            public static extern void FlexLayout_SetFlexWrap(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_GetFlexWrap")]
            public static extern int FlexLayout_GetFlexWrap(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_SetFlexAlignment")]
            public static extern void FlexLayout_SetFlexAlignment(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_GetFlexAlignment")]
            public static extern int FlexLayout_GetFlexAlignment(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_SetFlexItemsAlignment")]
            public static extern void FlexLayout_SetFlexItemsAlignment(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_GetFlexItemsAlignment")]
            public static extern int FlexLayout_GetFlexItemsAlignment(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_SetMaximumWidth")]
            public static extern void FlexLayout_SetFlexMaximumWidth(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_SetMaximumHeight")]
            public static extern void FlexLayout_SetFlexMaximumHeight(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_SetMinimumWidth")]
            public static extern void FlexLayout_SetFlexMinimumWidth(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexLayout_SetMinimumHeight")]
            public static extern void FlexLayout_SetFlexMinimumHeight(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);
        }
    }
}
