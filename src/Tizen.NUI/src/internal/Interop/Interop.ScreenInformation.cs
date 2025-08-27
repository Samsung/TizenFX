/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
        internal static partial class ScreenInformation
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScreenInformation")]
            public static extern global::System.IntPtr New();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScreenInformation_SWIG_0")]
            public static extern global::System.IntPtr New(string nuiName, int nuiWidth, int nuiHeight);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScreenInformation")]
            public static extern void DeleteScreenInformation(global::System.IntPtr nuiScreenInformation);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScreenInformation_EqualTo")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool EqualTo(global::System.IntPtr nuiScreenInformation1, global::System.IntPtr nuiScreenInformation2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScreenInformation_SetScreenName")]
            public static extern void SetScreenName(global::System.IntPtr nuiScreenInformation, string nuiName);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScreenInformation_GetScreenName")]
            public static extern string GetScreenName(global::System.IntPtr nuiScreenInformation);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScreenInformation_SetScreenWidth")]
            public static extern void SetScreenWidth(global::System.IntPtr nuiScreenInformation, int nuiWidth);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScreenInformation_GetScreenWidth")]
            public static extern int GetScreenWidth(global::System.IntPtr nuiScreenInformation);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScreenInformation_SetScreenHeight")]
            public static extern void SetScreenHeight(global::System.IntPtr nuiScreenInformation, int nuiHeight);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScreenInformation_GetScreenHeight")]
            public static extern int GetScreenHeight(global::System.IntPtr nuiScreenInformation);
        }
    }
}
