/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ForegroundColorSpanBuilder
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ForegroundColorSpanBuilder_Initialize")]
            public static extern global::System.IntPtr Initialize();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ForegroundColorSpanBuilder_Build")]
            public static extern global::System.IntPtr Build(global::System.Runtime.InteropServices.HandleRef refBuilder);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ForegroundColorSpanBuilder_WithForegroundColor")]
            public static extern global::System.IntPtr WithForegroundColor(global::System.Runtime.InteropServices.HandleRef refBuilder, global::System.Runtime.InteropServices.HandleRef argColor);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ForegroundColorSpanBuilder")]
            public static extern void DeleteForegroundColorSpanBuilder(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
