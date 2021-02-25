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

namespace Tizen.NUI
{
    using global::System;
    internal static partial class Interop
    {
        internal static partial class NativeImageSource
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_Upcast")]
            public static extern IntPtr Upcast(IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_New")]
            public static extern IntPtr New(IntPtr handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_Delete")]
            public static extern void Delete(IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_New_Handle")]
            public static extern IntPtr NewHandle(uint jarg1, uint jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_AcquireBuffer")]
            public static extern IntPtr AcquireBuffer(IntPtr jarg1, ref int jarg2, ref int jarg3, ref int jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_ReleaseBuffer")]
            public static extern bool ReleaseBuffer(IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_GenerateUrl")]
            public static extern string GenerateUrl(IntPtr handle);
        }
    }
}
