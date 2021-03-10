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

using System.Runtime.InteropServices;

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
