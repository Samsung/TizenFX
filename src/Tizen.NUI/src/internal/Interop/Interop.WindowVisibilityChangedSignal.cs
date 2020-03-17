﻿/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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

using System;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class WindowVisibilityChangedSignal
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Visibility_Changed_Signal")]
            public static extern global::System.IntPtr GetSignal(global::System.Runtime.InteropServices.HandleRef window);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Visibility_Changed_Signal_Empty")]
            public static extern bool Empty(global::System.Runtime.InteropServices.HandleRef signalType);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Visibility_Changed_Signal_GetConnectionCount")]
            public static extern uint GetConnectionCount(global::System.Runtime.InteropServices.HandleRef signalType);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Visibility_Changed_Signal_Connect")]
            public static extern void Connect(global::System.Runtime.InteropServices.HandleRef signalType, global::System.Runtime.InteropServices.HandleRef callback);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Visibility_Changed_Signal_Disconnect")]
            public static extern void Disconnect(global::System.Runtime.InteropServices.HandleRef signalType, global::System.Runtime.InteropServices.HandleRef callback);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Visibility_Changed_Signal_Emit")]
            public static extern void Emit(global::System.Runtime.InteropServices.HandleRef signalType, global::System.Runtime.InteropServices.HandleRef window, bool visibility);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Visibility_Changed_Signal_delete")]
            public static extern void DeleteSignal(global::System.Runtime.InteropServices.HandleRef signalType);
        }
    }
}