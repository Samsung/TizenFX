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
        internal static partial class UnderlineSpanBuilder
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpanBuilder_Initialize")]
            public static extern global::System.IntPtr Initialize();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpanBuilder_Build")]
            public static extern global::System.IntPtr Build(global::System.Runtime.InteropServices.HandleRef refBuilder);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpanBuilder_WithUnderlineType")]
            public static extern global::System.IntPtr WithUnderlineType(global::System.Runtime.InteropServices.HandleRef refBuilder, int argType);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpanBuilder_WithUnderlineColor")]
            public static extern global::System.IntPtr WithUnderlineColor(global::System.Runtime.InteropServices.HandleRef refBuilder, global::System.Runtime.InteropServices.HandleRef argColor);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpanBuilder_WithUnderlineHeight")]
            public static extern global::System.IntPtr WithUnderlineHeight(global::System.Runtime.InteropServices.HandleRef refBuilder, float argHeight);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpanBuilder_WithUnderlineDashGap")]
            public static extern global::System.IntPtr WithUnderlineDashGap(global::System.Runtime.InteropServices.HandleRef refBuilder, float argDashGap);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpanBuilder_WithUnderlineDashWidth")]
            public static extern global::System.IntPtr WithUnderlineDashWidth(global::System.Runtime.InteropServices.HandleRef refBuilder, float argDashWidth);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_UnderlineSpanBuilder")]
            public static extern void DeleteUnderlineSpanBuilder(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
