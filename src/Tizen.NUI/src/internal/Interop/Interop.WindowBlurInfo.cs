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
        internal static partial class WindowBlurInfo
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WindowBlurInfo")]
            public static extern global::System.IntPtr New();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WindowBlurInfo_SWIG_0")]
            public static extern global::System.IntPtr New(int nuiBlurType, int nuiBlurRadius, int nuiCornerRadius);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WindowBlurInfo_SWIG_1")]
            public static extern global::System.IntPtr New(int nuiBlurType, int nuiBlurRadius);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WindowBlurInfo_SWIG_2")]
            public static extern global::System.IntPtr New(int nuiBlurType, int nuiBlurRadius, int nuiCornerRadius, global::System.IntPtr nuiDimInfo);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WindowBlurInfo")]
            public static extern void DeleteWindowBlurInfo(global::System.IntPtr nuiWindowBlurInfo);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowBlurInfo_GetBlurType")]
            public static extern int GetBlurType(global::System.IntPtr nuiWindowBlurInfo);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowBlurInfo_GetBlurRadius")]
            public static extern int GetBlurRadius(global::System.IntPtr nuiWindowBlurInfo);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowBlurInfo_GetBackgroundCornerRadius")]
            public static extern int GetBackgroundCornerRadius(global::System.IntPtr nuiWindowBlurInfo);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowBlurInfo_SetBehindBlurDimInfo")]
            public static extern void SetBehindBlurDimInfo(global::System.IntPtr nuiWindowBlurInfo, global::System.IntPtr nuiDimInfo);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowBlurInfo_GetBehindBlurDimInfo")]
            public static extern global::System.IntPtr GetBehindBlurDimInfo(global::System.IntPtr nuiWindowBlurInfo);
        }

        internal static partial class WindowBehindBlurDimInfo
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WindowBehindBlurDimInfo")]
            public static extern global::System.IntPtr New(int isEnable, global::System.IntPtr dimColor);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WindowBehindBlurDimInfo")]
            public static extern void DeleteWindowBehindBlurDimInfo(global::System.IntPtr nuiWindowBehindBlurDimInfo);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowBehindBlurDimInfo_GetIsEnable")]
            public static extern int GetIsEnable(global::System.IntPtr nuiWindowBehindBlurDimInfo);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowBehindBlurDimInfo_GetDimColor")]
            public static extern global::System.IntPtr GetDimColor(global::System.IntPtr nuiWindowBehindBlurDimInfo);
        }
    }
}
