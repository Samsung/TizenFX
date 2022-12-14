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
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_New")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_NewSolid")]
            public static extern global::System.IntPtr NewSolid(global::System.Runtime.InteropServices.HandleRef argColor, float argHeight);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_NewDouble")]
            public static extern global::System.IntPtr NewDouble(global::System.Runtime.InteropServices.HandleRef argColor, float argHeight);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_NewDashed")]
            public static extern global::System.IntPtr NewDashed(global::System.Runtime.InteropServices.HandleRef argColor, float argHeight, float argDashGap, float argDashWidth);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_GetType")]
            public static extern int GetType(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_IsTypeDefined")]
            public static extern bool IsTypeDefined(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_GetColor")]
            public static extern global::System.IntPtr GetColor(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_IsColorDefined")]
            public static extern bool IsColorDefined(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_GetHeight")]
            public static extern float GetHeight(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_IsHeightDefined")]
            public static extern bool IsHeightDefined(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_GetDashGap")]
            public static extern float GetDashGap(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_IsDashGapDefined")]
            public static extern bool IsDashGapDefined(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_GetDashWidth")]
            public static extern float GetDashWidth(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UnderlineSpan_IsDashWidthDefined")]
            public static extern bool IsDashWidthDefined(global::System.Runtime.InteropServices.HandleRef refSpan);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_UnderlineSpan")]
            public static extern void DeleteUnderlineSpan(global::System.Runtime.InteropServices.HandleRef refSpan);
        }
    }
}