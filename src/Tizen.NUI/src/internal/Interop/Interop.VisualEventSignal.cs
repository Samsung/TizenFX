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

using System;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class VisualEventSignal
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualEventSignal_Empty")]
            public static extern bool Empty(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualEventSignal_GetConnectionCount")]
            public static extern uint GetConnectionCount(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualEventSignal_Connect")]
            public static extern void Connect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualEventSignal_Disconnect")]
            public static extern void Disconnect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualEventSignal_Emit")]
            public static extern void Emit(HandleRef jarg1, HandleRef jarg2, int jarg3, int jarg4);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_VisualEventSignal")]
            public static extern IntPtr New();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_VisualEventSignal")]
            public static extern void Delete(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_VisualEventSignal")]
            public static extern IntPtr NewWithView(HandleRef jarg1);
        }
    }
}
