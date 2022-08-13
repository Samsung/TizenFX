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
        internal static partial class FontSpanBuilder
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpanBuilder_Initialize")]
            public static extern global::System.IntPtr Initialize();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpanBuilder_Build")]
            public static extern global::System.IntPtr Build(global::System.Runtime.InteropServices.HandleRef refBuilder);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpanBuilder_WithFamilyName")]
            public static extern global::System.IntPtr WithFamilyName(global::System.Runtime.InteropServices.HandleRef refBuilder, string argFamilyName);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpanBuilder_WithFontWeight")]
            public static extern global::System.IntPtr WithFontWeight(global::System.Runtime.InteropServices.HandleRef refBuilder, int argWeight);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpanBuilder_WithFontWidth")]
            public static extern global::System.IntPtr WithFontWidth(global::System.Runtime.InteropServices.HandleRef refBuilder, int argWidth);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpanBuilder_WithFontSlant")]
            public static extern global::System.IntPtr WithFontSlant(global::System.Runtime.InteropServices.HandleRef refBuilder, int argSlant);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpanBuilder_WithFontSize")]
            public static extern global::System.IntPtr WithFontSize(global::System.Runtime.InteropServices.HandleRef refBuilder, float argSize);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_FontSpanBuilder")]
            public static extern void DeleteFontSpanBuilder(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
