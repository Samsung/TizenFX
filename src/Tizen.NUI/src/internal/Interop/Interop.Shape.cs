using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Shape
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_New")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_AddRect")]            
            public static extern bool AddRect(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, float jarg5, float jarg6, float jarg7);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_AddCircle")]
            public static extern bool AddCircle(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, float jarg5);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_AddArc")]
            public static extern bool AddArc(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, float jarg5, float jarg6, bool jarg7);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_AddMoveTo")]
            public static extern bool AddMoveTo(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_AddLineTo")]
            public static extern bool AddLineTo(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_AddCubicTo")]
            public static extern bool AddCubicTo(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, float jarg5, float jarg6, float jarg7);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_Close")]
            public static extern bool Close(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_SetFillColor")]
            public static extern bool SetFillColor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_GetFillColor")]
            public static extern global::System.IntPtr GetFillColor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_SetFillRule")]
            public static extern bool SetFillRule(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_GetFillRule")]
            public static extern int GetFillRule(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_SetStrokeWidth")]
            public static extern bool SetStrokeWidth(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_GetStrokeWidth")]
            public static extern float GetStrokeWidth(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_SetStrokeColor")]
            public static extern bool SetStrokeColor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_GetStrokeColor")]
            public static extern global::System.IntPtr GetStrokeColor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_SetStrokeDash")]
            public static extern bool SetStrokeDash(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)] float[] jarg2, int jarg3);
            
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_GetStrokeDashIndexOf")]
            public static extern float GetStrokeDashIndexOf(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);
            
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_GetStrokeDashCount")]
            public static extern int GetStrokeDashCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_SetStrokeCap")]
            public static extern bool SetStrokeCap(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_GetStrokeCap")]
            public static extern int GetStrokeCap(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_SetStrokeJoin")]
            public static extern bool SetStrokeJoin(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_GetStrokeJoin")]
            public static extern int GetStrokeJoin(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
