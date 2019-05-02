using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Timer
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Timer__SWIG_0")]
            public static extern global::System.IntPtr new_Timer__SWIG_0();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Timer_New")]
            public static extern global::System.IntPtr Timer_New(uint jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Timer__SWIG_1")]
            public static extern global::System.IntPtr new_Timer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Timer_Assign")]
            public static extern global::System.IntPtr Timer_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Timer")]
            public static extern void delete_Timer(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Timer_DownCast")]
            public static extern global::System.IntPtr Timer_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Timer_Start")]
            public static extern void Timer_Start(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Timer_Stop")]
            public static extern void Timer_Stop(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Timer_SetInterval")]
            public static extern void Timer_SetInterval(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Timer_GetInterval")]
            public static extern uint Timer_GetInterval(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Timer_IsRunning")]
            public static extern bool Timer_IsRunning(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Timer_TickSignal")]
            public static extern global::System.IntPtr Timer_TickSignal(global::System.Runtime.InteropServices.HandleRef jarg1);



            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TimerSignalType_Empty")]
            public static extern bool TimerSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TimerSignalType_GetConnectionCount")]
            public static extern uint TimerSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TimerSignalType_Connect")]
            public static extern void TimerSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TimerSignalType_Disconnect")]
            public static extern void TimerSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TimerSignalType_Emit")]
            public static extern bool TimerSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TimerSignalType")]
            public static extern global::System.IntPtr new_TimerSignalType();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TimerSignalType")]
            public static extern void delete_TimerSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);



            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Timer_SWIGUpcast")]
            public static extern global::System.IntPtr Timer_SWIGUpcast(global::System.IntPtr jarg1);
        }
    }
}
