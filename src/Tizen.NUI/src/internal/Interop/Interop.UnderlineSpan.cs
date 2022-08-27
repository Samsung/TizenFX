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
        internal static partial class UnderlineSpan
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_type_get")]
            public static extern int UnderlineTypeGet(global::System.Runtime.InteropServices.HandleRef refUnderlineSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_type_defined_get")]
            public static extern bool UnderlineTypeDefinedGet(global::System.Runtime.InteropServices.HandleRef refUnderlineSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_color_get")]
            public static extern global::System.IntPtr UnderlineColorGet(global::System.Runtime.InteropServices.HandleRef refUnderlineSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_color_defined_get")]
            public static extern bool UnderlineColorDefinedGet(global::System.Runtime.InteropServices.HandleRef refUnderlineSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_height_get")]
            public static extern float UnderlineHeightGet(global::System.Runtime.InteropServices.HandleRef refUnderlineSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_height_defined_get")]
            public static extern bool UnderlineHeightDefinedGet(global::System.Runtime.InteropServices.HandleRef refUnderlineSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_dashgap_get")]
            public static extern float UnderlineDashGapGet(global::System.Runtime.InteropServices.HandleRef refUnderlineSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_dashgap_defined_get")]
            public static extern bool UnderlineDashGapDefinedGet(global::System.Runtime.InteropServices.HandleRef refUnderlineSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_dashwidth_get")]
            public static extern float UnderlineDashWidthGet(global::System.Runtime.InteropServices.HandleRef refUnderlineSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_dashwidth_defined_get")]
            public static extern bool UnderlineDashWidthDefinedGet(global::System.Runtime.InteropServices.HandleRef refUnderlineSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_UnderlineSpan")]
            public static extern void DeleteUnderlineSpan(global::System.Runtime.InteropServices.HandleRef refUnderlineSpan);
        }
    }
}
