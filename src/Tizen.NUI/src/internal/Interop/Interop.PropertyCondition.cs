using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class PropertyCondition
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PropertyCondition__SWIG_0")]
            public static extern global::System.IntPtr new_PropertyCondition__SWIG_0();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_PropertyCondition")]
            public static extern void delete_PropertyCondition(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PropertyCondition__SWIG_1")]
            public static extern global::System.IntPtr new_PropertyCondition__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyCondition_Assign")]
            public static extern global::System.IntPtr PropertyCondition_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyCondition_GetArgumentCount")]
            public static extern uint PropertyCondition_GetArgumentCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyCondition_GetArgument")]
            public static extern float PropertyCondition_GetArgument(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyCondition_SWIGUpcast")]
            public static extern global::System.IntPtr PropertyCondition_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LessThanCondition")]
            public static extern global::System.IntPtr LessThanCondition(float jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GreaterThanCondition")]
            public static extern global::System.IntPtr GreaterThanCondition(float jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InsideCondition")]
            public static extern global::System.IntPtr InsideCondition(float jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_OutsideCondition")]
            public static extern global::System.IntPtr OutsideCondition(float jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StepCondition__SWIG_0")]
            public static extern global::System.IntPtr StepCondition__SWIG_0(float jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StepCondition__SWIG_1")]
            public static extern global::System.IntPtr StepCondition__SWIG_1(float jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VariableStepCondition")]
            public static extern global::System.IntPtr VariableStepCondition(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
