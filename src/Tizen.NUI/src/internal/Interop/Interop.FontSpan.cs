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
        internal static partial class FontSpan
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_familyname_get")]
            public static extern string FamilyNameGet(global::System.Runtime.InteropServices.HandleRef refFontSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_familyname_defined_get")]
            public static extern bool FamilyNameDefinedGet(global::System.Runtime.InteropServices.HandleRef refFontSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_weight_get")]
            public static extern int WeightGet(global::System.Runtime.InteropServices.HandleRef refFontSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_weight_defined_get")]
            public static extern bool WeightDefinedGet(global::System.Runtime.InteropServices.HandleRef refFontSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_width_get")]
            public static extern int WidthGet(global::System.Runtime.InteropServices.HandleRef refFontSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_width_defined_get")]
            public static extern bool WidthDefinedGet(global::System.Runtime.InteropServices.HandleRef refFontSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_slant_get")]
            public static extern int SlantGet(global::System.Runtime.InteropServices.HandleRef refFontSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_slant_defined_get")]
            public static extern bool SlantDefinedGet(global::System.Runtime.InteropServices.HandleRef refFontSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_size_get")]
            public static extern float SizeGet(global::System.Runtime.InteropServices.HandleRef refFontSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_size_defined_get")]
            public static extern bool SizeDefinedGet(global::System.Runtime.InteropServices.HandleRef refFontSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_FontSpan")]
            public static extern void DeleteFontSpan(global::System.Runtime.InteropServices.HandleRef refFontSpan);
        }
    }
}
