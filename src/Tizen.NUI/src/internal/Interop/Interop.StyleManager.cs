/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
        internal static partial class StyleManager
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_StyleManager", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewStyleManager();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StyleManager_Get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Get();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StyleManager_ApplyTheme", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ApplyTheme(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StyleManager_ApplyDefaultTheme", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ApplyDefaultTheme(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StyleManager_SetStyleConstant", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetStyleConstant(IntPtr jarg1, string jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StyleManager_GetStyleConstant", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetStyleConstant(IntPtr jarg1, string jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StyleManager_ApplyStyle", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ApplyStyle(IntPtr jarg1, IntPtr jarg2, string jarg3, string jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StyleManager_StyleChangedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr StyleChangedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StyleManager_SetBrokenImageUrl", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetBrokenImageUrl(IntPtr jarg1,uint jarg2, string jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StyleManager_GetBrokenImageUrl", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetBrokenImageUrl(IntPtr jarg1, uint jarg2);
        }
    }
}





