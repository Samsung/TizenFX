using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class TimePeriod
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TimePeriod__SWIG_0")]
            public static extern global::System.IntPtr new_TimePeriod__SWIG_0(float jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TimePeriod__SWIG_1")]
            public static extern global::System.IntPtr new_TimePeriod__SWIG_1(float jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TimePeriod")]
            public static extern void delete_TimePeriod(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TimePeriod_delaySeconds_set")]
            public static extern void TimePeriod_delaySeconds_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TimePeriod_delaySeconds_get")]
            public static extern float TimePeriod_delaySeconds_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TimePeriod_durationSeconds_set")]
            public static extern void TimePeriod_durationSeconds_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TimePeriod_durationSeconds_get")]
            public static extern float TimePeriod_durationSeconds_get(global::System.Runtime.InteropServices.HandleRef jarg1);


        }
    }
}
