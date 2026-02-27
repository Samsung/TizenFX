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

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class WindowBlurInfo
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WindowBlurInfo", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WindowBlurInfo_SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(int nuiBlurType, int nuiBlurRadius, int nuiCornerRadius);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WindowBlurInfo_SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(int nuiBlurType, int nuiBlurRadius);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WindowBlurInfo_SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(int nuiBlurType, int nuiBlurRadius, int nuiCornerRadius, global::System.IntPtr nuiDimInfo);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WindowBlurInfo", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteWindowBlurInfo(global::System.IntPtr nuiWindowBlurInfo);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowBlurInfo_GetBlurType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetBlurType(global::System.IntPtr nuiWindowBlurInfo);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowBlurInfo_GetBlurRadius", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetBlurRadius(global::System.IntPtr nuiWindowBlurInfo);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowBlurInfo_GetBackgroundCornerRadius", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetBackgroundCornerRadius(global::System.IntPtr nuiWindowBlurInfo);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowBlurInfo_SetBehindBlurDimInfo", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetBehindBlurDimInfo(global::System.IntPtr nuiWindowBlurInfo, global::System.IntPtr nuiDimInfo);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowBlurInfo_GetBehindBlurDimInfo", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetBehindBlurDimInfo(global::System.IntPtr nuiWindowBlurInfo);
        }

        internal static partial class WindowDimInfo
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WindowDimInfo", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(int enable, global::System.IntPtr dimColor);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WindowDimInfo", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteWindowDimInfo(global::System.IntPtr nuiWindowDimInfo);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowDimInfo_GetIsEnabled", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetIsEnabled(global::System.IntPtr nuiWindowDimInfo);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowDimInfo_GetDimColor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetDimColor(global::System.IntPtr nuiWindowDimInfo);
        }
    }
}



