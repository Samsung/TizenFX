using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class TtsPlayer
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TtsPlayer_SWIGUpcast")]
            public static extern global::System.IntPtr TtsPlayer_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TtsPlayer__SWIG_0")]
            public static extern global::System.IntPtr new_TtsPlayer__SWIG_0();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TtsPlayer_Get__SWIG_0")]
            public static extern global::System.IntPtr TtsPlayer_Get__SWIG_0(int jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TtsPlayer_Get__SWIG_1")]
            public static extern global::System.IntPtr TtsPlayer_Get__SWIG_1();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TtsPlayer")]
            public static extern void delete_TtsPlayer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TtsPlayer__SWIG_1")]
            public static extern global::System.IntPtr new_TtsPlayer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TtsPlayer_Assign")]
            public static extern global::System.IntPtr TtsPlayer_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TtsPlayer_Play")]
            public static extern void TtsPlayer_Play(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TtsPlayer_Stop")]
            public static extern void TtsPlayer_Stop(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TtsPlayer_Pause")]
            public static extern void TtsPlayer_Pause(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TtsPlayer_Resume")]
            public static extern void TtsPlayer_Resume(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TtsPlayer_GetState")]
            public static extern int TtsPlayer_GetState(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TtsPlayer_StateChangedSignal")]
            public static extern global::System.IntPtr TtsPlayer_StateChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}