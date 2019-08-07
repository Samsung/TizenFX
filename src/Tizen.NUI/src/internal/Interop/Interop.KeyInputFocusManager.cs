using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class KeyInputFocusManager
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusManager_SWIGUpcast")]
            public static extern global::System.IntPtr KeyInputFocusManager_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_KeyInputFocusManager")]
            public static extern global::System.IntPtr new_KeyInputFocusManager();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_KeyInputFocusManager")]
            public static extern void delete_KeyInputFocusManager(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusManager_Get")]
            public static extern global::System.IntPtr KeyInputFocusManager_Get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusManager_SetFocus")]
            public static extern void KeyInputFocusManager_SetFocus(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusManager_GetCurrentFocusControl")]
            public static extern global::System.IntPtr KeyInputFocusManager_GetCurrentFocusControl(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusManager_RemoveFocus")]
            public static extern void KeyInputFocusManager_RemoveFocus(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusManager_KeyInputFocusChangedSignal")]
            public static extern global::System.IntPtr KeyInputFocusManager_KeyInputFocusChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusSignal_Empty")]
            public static extern bool KeyInputFocusSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusSignal_GetConnectionCount")]
            public static extern uint KeyInputFocusSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusSignal_Connect")]
            public static extern void KeyInputFocusSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusSignal_Disconnect")]
            public static extern void KeyInputFocusSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusSignal_Emit")]
            public static extern void KeyInputFocusSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_KeyInputFocusSignal")]
            public static extern global::System.IntPtr new_KeyInputFocusSignal();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_KeyInputFocusSignal")]
            public static extern void delete_KeyInputFocusSignal(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}