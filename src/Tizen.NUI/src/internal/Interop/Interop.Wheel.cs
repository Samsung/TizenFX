using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Wheel
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Wheel__SWIG_0")]
            public static extern global::System.IntPtr new_Wheel__SWIG_0();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Wheel__SWIG_1")]
            public static extern global::System.IntPtr new_Wheel__SWIG_1(int jarg1, int jarg2, uint jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, int jarg5, uint jarg6);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Wheel")]
            public static extern void delete_Wheel(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_IsShiftModifier")]
            public static extern bool Wheel_IsShiftModifier(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_IsCtrlModifier")]
            public static extern bool Wheel_IsCtrlModifier(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_IsAltModifier")]
            public static extern bool Wheel_IsAltModifier(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_type_set")]
            public static extern void Wheel_type_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_type_get")]
            public static extern int Wheel_type_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_direction_set")]
            public static extern void Wheel_direction_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_direction_get")]
            public static extern int Wheel_direction_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_modifiers_set")]
            public static extern void Wheel_modifiers_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_modifiers_get")]
            public static extern uint Wheel_modifiers_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_point_set")]
            public static extern void Wheel_point_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_point_get")]
            public static extern global::System.IntPtr Wheel_point_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_z_set")]
            public static extern void Wheel_z_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_z_get")]
            public static extern int Wheel_z_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_timeStamp_set")]
            public static extern void Wheel_timeStamp_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_timeStamp_get")]
            public static extern uint Wheel_timeStamp_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StageWheelSignal_Empty")]
            public static extern bool StageWheelSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StageWheelSignal_GetConnectionCount")]
            public static extern uint StageWheelSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StageWheelSignal_Connect")]
            public static extern void StageWheelSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StageWheelSignal_Disconnect")]
            public static extern void StageWheelSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StageWheelSignal_Emit")]
            public static extern void StageWheelSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_StageWheelSignal")]
            public static extern global::System.IntPtr new_StageWheelSignal();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_StageWheelSignal")]
            public static extern void delete_StageWheelSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


        }
    }
}
