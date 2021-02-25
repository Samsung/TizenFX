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
        internal static partial class GLWindowFocusSignalType
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_FocusSignalType_Empty")]
            public static extern bool GlWindowFocusSignalTypeEmpty(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_FocusSignalType_GetConnectionCount")]
            public static extern uint GlWindowFocusSignalTypeGetConnectionCount(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_FocusSignalType_Connect")]
            public static extern void GlWindowFocusSignalTypeConnect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_FocusSignalType_Disconnect")]
            public static extern void GlWindowFocusSignalTypeDisconnect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_FocusSignalType_Emit")]
            public static extern void GlWindowFocusSignalTypeEmit(HandleRef signalType, HandleRef window, bool focusIn);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GlWindow_FocusSignalType")]
            public static extern global::System.IntPtr NewGlWindowFocusSignalType();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_GlWindow_FocusSignalType")]
            public static extern void DeleteGlWindowFocusSignalType(HandleRef jarg1);
        }
    }
}
