using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class FocusManager
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_new_KeyboardFocusManager")]
            public static extern global::System.IntPtr new_FocusManager();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_delete_KeyboardFocusManager")]
            public static extern void delete_FocusManager(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_Get")]
            public static extern global::System.IntPtr FocusManager_Get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_SetCurrentFocusActor")]
            public static extern bool FocusManager_SetCurrentFocusActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_GetCurrentFocusActor")]
            public static extern global::System.IntPtr FocusManager_GetCurrentFocusActor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_MoveFocus")]
            public static extern bool FocusManager_MoveFocus(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_ClearFocus")]
            public static extern void FocusManager_ClearFocus(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_SetFocusGroupLoop")]
            public static extern void FocusManager_SetFocusGroupLoop(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_GetFocusGroupLoop")]
            public static extern bool FocusManager_GetFocusGroupLoop(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_SetAsFocusGroup")]
            public static extern void FocusManager_SetAsFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, bool jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_IsFocusGroup")]
            public static extern bool FocusManager_IsFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_GetFocusGroup")]
            public static extern global::System.IntPtr FocusManager_GetFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_SetFocusIndicatorActor")]
            public static extern void FocusManager_SetFocusIndicatorActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_GetFocusIndicatorActor")]
            public static extern global::System.IntPtr FocusManager_GetFocusIndicatorActor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_MoveFocusBackward")]
            public static extern void FocusManager_MoveFocusBackward(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_PreFocusChangeSignal")]
            public static extern global::System.IntPtr FocusManager_PreFocusChangeSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_FocusChangedSignal")]
            public static extern global::System.IntPtr FocusManager_FocusChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_FocusGroupChangedSignal")]
            public static extern global::System.IntPtr FocusManager_FocusGroupChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_FocusedActorEnterKeySignal")]
            public static extern global::System.IntPtr FocusManager_FocusedActorEnterKeySignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyboardFocusManager_EnableDefaultAlgorithm")]
            public static extern void EnableDefaultAlgorithm(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyboardFocusManager_IsDefaultAlgorithmEnabled")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsDefaultAlgorithmEnabled(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_SWIGUpcast")]
            public static extern global::System.IntPtr FocusManager_SWIGUpcast(global::System.IntPtr jarg1);
        }
    }
}