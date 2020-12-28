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
            public static extern global::System.IntPtr NewTimePeriod(float jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TimePeriod__SWIG_1")]
            public static extern global::System.IntPtr NewTimePeriod(float jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TimePeriod")]
            public static extern void DeleteTimePeriod(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TimePeriod_delaySeconds_set")]
            public static extern void DelaySecondsSet(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TimePeriod_delaySeconds_get")]
            public static extern float DelaySecondsGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TimePeriod_durationSeconds_set")]
            public static extern void DurationSecondsSet(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TimePeriod_durationSeconds_get")]
            public static extern float DurationSecondsGet(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
