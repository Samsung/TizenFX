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
        internal static partial class GLWindowVisibilityChangedSignal
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Visibility_Changed_Signal")]
            public static extern global::System.IntPtr GetSignal(HandleRef glWindow);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Visibility_Changed_Signal_Empty")]
            public static extern bool Empty(HandleRef signalType);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Visibility_Changed_Signal_GetConnectionCount")]
            public static extern uint GetConnectionCount(HandleRef signalType);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Visibility_Changed_Signal_Connect")]
            public static extern void Connect(HandleRef signalType, HandleRef callback);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Visibility_Changed_Signal_Disconnect")]
            public static extern void Disconnect(HandleRef signalType, HandleRef callback);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Visibility_Changed_Signal_Emit")]
            public static extern void Emit(HandleRef signalType, HandleRef window, bool visibility);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Visibility_Changed_Signal_delete")]
            public static extern void DeleteSignal(HandleRef signalType);
        }
    }
}
