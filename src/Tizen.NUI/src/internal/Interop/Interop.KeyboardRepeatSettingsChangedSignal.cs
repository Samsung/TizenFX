using global::System;
using global::System.Runtime.InteropServices;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class KeyboardRepeatSettingsChangedSignal
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Keyboard_Repeat_Settings_ChangedSignal")]
            public static extern global::System.IntPtr GetSignal(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Keyboard_Repeat_Settings_Changed_Signal_Empty")]
            public static extern bool Empty(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Keyboard_Repeat_Settings_Changed_Signal_GetConnectionCount")]
            public static extern uint GetConnectionCount(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Keyboard_Repeat_Settings_Changed_Signal_Connect")]
            public static extern void Connect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Keyboard_Repeat_Settings_Changed_Signal_Disconnect")]
            public static extern void Disconnect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Keyboard_Repeat_Settings_Changed_Signal_Emit")]
            public static extern bool Emit(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Keyboard_Repeat_Settings_Changed_Signal_new")]
            public static extern global::System.IntPtr NewSignal();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Keyboard_Repeat_Settings_Changed_Signal_delete")]
            public static extern void DeleteSignal(HandleRef jarg1);
        }
    }
}
