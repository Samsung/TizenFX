/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using global::System;
using global::System.Runtime.InteropServices;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class KeyInputFocusManager
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusManager_SWIGUpcast")]
            public static extern IntPtr Upcast(IntPtr jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_KeyInputFocusManager")]
            public static extern IntPtr NewKeyInputFocusManager();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_KeyInputFocusManager")]
            public static extern void DeleteKeyInputFocusManager(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusManager_Get")]
            public static extern IntPtr Get();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusManager_SetFocus")]
            public static extern void SetFocus(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusManager_GetCurrentFocusControl")]
            public static extern IntPtr GetCurrentFocusControl(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusManager_RemoveFocus")]
            public static extern void RemoveFocus(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusManager_KeyInputFocusChangedSignal")]
            public static extern IntPtr KeyInputFocusChangedSignal(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusSignal_Empty")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool KeyInputFocusSignalEmpty(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusSignal_GetConnectionCount")]
            public static extern uint KeyInputFocusSignalGetConnectionCount(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusSignal_Connect", CallingConvention = CallingConvention.Cdecl)]
            public static extern void KeyInputFocusSignalConnect(HandleRef jarg1, Delegate jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusSignal_Disconnect", CallingConvention = CallingConvention.Cdecl)]
            public static extern void KeyInputFocusSignalDisconnect(HandleRef jarg1, Delegate jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusSignal_Emit")]
            public static extern void KeyInputFocusSignalEmit(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_KeyInputFocusSignal")]
            public static extern IntPtr NewKeyInputFocusSignal();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_KeyInputFocusSignal")]
            public static extern void DeleteKeyInputFocusSignal(HandleRef jarg1);
        }
    }
}
