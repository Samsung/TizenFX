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
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_New")]
            public static extern global::System.IntPtr New(string argFamilyName,float argSize, int argWeight, int argWidth, int argSlant);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_GetFamilyName")]
            public static extern string GetFamilyName(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_IsFamilyNameDefined")]
            public static extern bool IsFamilyNameDefined(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_GetWeight")]
            public static extern int GetWeight(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_IsWeightDefined")]
            public static extern bool IsWeightDefined(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_GetWidth")]
            public static extern int GetWidth(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_IsWidthDefined")]
            public static extern bool IsWidthDefined(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_GetSlant")]
            public static extern int GetSlant(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_IsSlantDefined")]
            public static extern bool IsSlantDefined(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_GetSize")]
            public static extern float GetSize(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FontSpan_IsSizeDefined")]
            public static extern bool IsSizeDefined(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_FontSpan")]
            public static extern void DeleteFontSpan(global::System.Runtime.InteropServices.HandleRef refSpan);
        }
    }
}